using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QVLEGS.Class
{
    public class Core : CoreBase
    {

        #region delegati

        public delegate void OnNewImageForRegolazioniDelegate(HalconDotNet.HImage image, int numTest, DataType.PrevImageData prevImageData);
        private OnNewImageForRegolazioniDelegate OnNewImageForRegolazioni;

        #endregion

        #region Variabili Private

        private ComunicazioneManager comunicazioneManager = null;
        private Manager.SchedaIO schedaIO = null;
        private GestioneContatori contatori = null;

        private IFrameGrabberManager frameGrabberForThisObject = null;

        private CancellationTokenSource cancelToken;
        private Thread mainTask;

        private bool taskRunning = false;

        private object objLock = new object();

        private Task taskCoreOnNewImageForRegolazioni = null;

        private bool inRegolazione = false;

        private DataType.TipoAlgoritmo tipoAlgoritmo = DataType.TipoAlgoritmo.Normale;

        private GraficiSoglieManager graficiSoglieManager = new GraficiSoglieManager();

        private bool isLive = false;

        #endregion


#if _Simulazione
        private List<string>[] files = new List<string>[2];

        private int[] indexFiles = new int[] { 0, 0 };
#endif

        public Core(int numCamera, int idStazione, ComunicazioneManager comunicazioneManager, Manager.SchedaIO schedaIO, GestioneContatori contatori, DataType.Impostazioni config)
            : base(numCamera, idStazione, config)
        {
            try
            {
                this.comunicazioneManager = comunicazioneManager;
                this.schedaIO = schedaIO;
                this.contatori = contatori;

#if _Simulazione

                if (idStazione == 0)
                {
                    this.files[0] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione2\foto1").ToList();
                    this.files[1] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione2\foto2").ToList();
                }
                else if (idStazione == 1)
                {
                    this.files[0] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione1").ToList();
                }
                else if (idStazione == 2)
                {
                    this.files[0] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione3\foto1").ToList();
                    this.files[1] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione3\foto2").ToList();
                }
                else if (idStazione == 3)
                {
                    this.files[0] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione4").ToList();
                }
                else
                {
                    this.files[0] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione5\foto1").ToList();
                    this.files[1] = System.IO.Directory.GetFiles(@"C:\qualivision\generalCab\DATA\simulazione5\foto2").ToList();
                }
#endif
            }
            catch (Exception)
            {
                throw;
            }
            cancelToken = new CancellationTokenSource();
            cancelToken.Cancel();//Ho bisogno di allocarlo ma non voglio partire bloccato
        }

        public void SetFrameGrabberManager(IFrameGrabberManager frameGrab)
        {
            this.frameGrabberForThisObject = frameGrab;

            if (base.numCamera == 0)
                SetOutput(true, false);
        }

        public IFrameGrabberManager GetFrameGrabberManager()
        {
            return this.frameGrabberForThisObject;
        }

        private DataType.ElaborateResult CoreOnNewImage(HalconDotNet.HImage hImage, int numTest, DataType.PrevImageData prevImageData, long tPreElab)
        {
            DataType.ElaborateResult result = null;

            //if (base.numCamera == 0)
            //{
            //    //SET BUSY OFF
            //    SetOutput(false, false);
            //}

            RaisePreNewImageEvent();

            lock (onNewImageLock)
            {
                double startTime = HalconDotNet.HSystem.CountSeconds();

                ArrayList iconicVarList;
                ElaborateImage(hImage, numTest, prevImageData, out iconicVarList, out result);

                if (!isLive)
                {
                    //CONTATORI
                    if (tipoAlgoritmo == DataType.TipoAlgoritmo.Normale)
                        RaiseContatori(result);

                    //COMUNICO IL RISULTATO DENTRO RaiseContatori
                    ////SET RISULTATO
                    //SetOutput(true, result == null ? false : result.Success);
                }

                // if (this.comunicazioneManager.IsEnable == false)
                //{
                //    result.Success = true;
                //}


                double tAnalisi = HalconDotNet.HSystem.CountSeconds();
                tAnalisi = (tAnalisi - startTime) * 1000.0;
                tAnalisi += tPreElab;
                //if (tAnalisi < DURATA_MINIMA_BUSY)
                //    Thread.Sleep(10);

                result.ElapsedTime = tAnalisi;

                DoPostNewImage(numTest, iconicVarList, result, this.isLive);
                //Utilities.CommonUtility.ClearArrayList(iconicVarList);
                if (!isLive)
                {
                    if (tipoAlgoritmo == DataType.TipoAlgoritmo.Normale)
                        graficiSoglieManager.AddData(result.StatisticheObj.Misure);
                }
            }

            return result;
        }

        private void CoreOnNewImageForRegolazioni(HalconDotNet.HImage image, int numTest, DataType.PrevImageData prevImageData)
        {
            Action action = () =>
            {
                try
                {
                    OnNewImageForRegolazioniDelegate del = OnNewImageForRegolazioni;
                    if (del != null)
                    {
                        del(image, numTest, prevImageData);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
            };

            if (this.taskCoreOnNewImageForRegolazioni == null)
                this.taskCoreOnNewImageForRegolazioni = Task.Run(action);   //Task.Factory.StartNew(action, TaskCreationOptions.PreferFairness);
            else
                this.taskCoreOnNewImageForRegolazioni = this.taskCoreOnNewImageForRegolazioni.ContinueWith(k => action());
        }

        public override void Run()
        {
            //try
            //{
            //    if (frameGrabberForThisObject == null)
            //        return;

            //    if (taskRunning)
            //        return;//test se già in run

            //    if (mainTask != null && mainTask.IsAlive == true)
            //        return;//test se già in run

            //    cancelToken = new CancellationTokenSource();

            //    frameGrabberForThisObject.GrabImageStart();

            //    mainTask = new Thread(new ThreadStart(RunFoo));
            //    mainTask.Priority = ThreadPriority.Normal;
            //    mainTask.Start();

            //    if (base.numCamera == 0)
            //        SetOutput(true, false);

            //    this.IsRunning = true;

            //}
            //catch (Exception ex)
            //{
            //    ExceptionManager.AddException(ex);
            //}
        }

        public override void StopAndWaitEnd(bool forceTrigger)
        {
            try
            {
                if (frameGrabberForThisObject == null)
                    return;

                if (this.IsRunning)
                {
                    if (forceTrigger)
                    {
                        frameGrabberForThisObject.ForceTrigger();
                    }

                    cancelToken.Cancel();

                    mainTask.Join();

                    if (base.numCamera == 0)
                        SetOutput(false, false);

                    this.IsRunning = false;
                }
            }
            catch (Exception) { }
        }

        public override void CloseFrameGrabber()
        {
            if (frameGrabberForThisObject != null)
            {
                if (frameGrabberForThisObject != null)
                    frameGrabberForThisObject.Dispose();
            }
        }

        public void SetOnNewImageForRegolazioni(OnNewImageForRegolazioniDelegate del)
        {
            lock (executeAlgorithmLock)
            {
                OnNewImageForRegolazioni = del;
                inRegolazione = del != null;
            }
        }

        //        private void RunFoo()
        //        {
        //            try
        //            {
        //                taskRunning = true;

        //                while (!cancelToken.Token.IsCancellationRequested)
        //                {
        //                    try
        //                    {
        //                        HalconDotNet.HImage imgGrabTmp = AcquisitionTask(out long tPreElab);

        //                        if (imgGrabTmp != null && imgGrabTmp.IsInitialized())
        //                        {
        //                            //if (this.comunicazioneManager.IsEnable)
        //                            {
        //                                //DateTime dtTemp = DateTime.Now;
        //                                //double delta = (dtTemp - dtLast).TotalMilliseconds;
        //                                //if (delta > 50)
        //                                //{
        //                                //    Debug.WriteLine(delta);
        //                                //}
        //                                //dtLast = dtTemp;

        //                                //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " CAMERA " + numCamera);

        //                                //TODO VEDERE QUESTE CLONE
        //                                //CoreOnNewImage(imgGrabTmp);
        //                                CoreOnNewImage(imgGrabTmp.Clone(), tPreElab);

        //                                if (inRegolazione)
        //                                {
        //                                    //CoreOnNewImageForRegolazioni(imgGrabTmp);
        //                                    CoreOnNewImageForRegolazioni(imgGrabTmp.Clone());
        //                                }

        //                                imgGrabTmp.Dispose();
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        if (!cancelToken.Token.IsCancellationRequested)
        //                        {
        //                            ExceptionManager.AddException(ex);
        //                        }
        //                    }
        //                    finally
        //                    {
        //                        //GC.Collect();
        //                    }
        //#if _Simulazione
        //                    Thread.Sleep(400);
        //#endif
        //                    if (isLive)
        //                    {
        //                        Thread.Sleep(200);
        //                    }

        //                }

        //                taskRunning = false;
        //            }
        //            catch (Exception ex)
        //            {
        //                if (!cancelToken.Token.IsCancellationRequested)
        //                {
        //                    ExceptionManager.AddException(ex);
        //                }
        //            }
        //        }

        private HalconDotNet.HImage AcquisitionTask(out long tPreElab)
        {
            HalconDotNet.HImage imgGrabTmp = null;
            tPreElab = 0;
            try
            {
                imgGrabTmp = frameGrabberForThisObject.GrabASyncNoDelegate(out tPreElab);
            }
            catch (HalconDotNet.HOperatorException ex)
            {
                if (!(ex.GetErrorNumber() == 5322 || ex.GetErrorNumber() == 5306))
                {
                    //Non deve dare errori nel momento in cui ho appena dato ABORT all'acquisizione 
                    if (!cancelToken.Token.IsCancellationRequested)
                        ExceptionManager.AddException(ex);
                }
            }
            return imgGrabTmp;
        }

        public DataType.ElaborateResult GrabAndExecuteAlg(int numTest, DataType.PrevImageData prevImageData)
        {
            DataType.ElaborateResult ret = null;
            try
            {
                HalconDotNet.HImage imgGrabTmp = frameGrabberForThisObject.GrabImage();

#if _Simulazione
                if (indexFiles[numTest - 1] >= files[numTest - 1].Count)
                    indexFiles[numTest - 1] = 0;

                imgGrabTmp.ReadImage(files[numTest - 1][indexFiles[numTest - 1]]);
                indexFiles[numTest - 1]++;
#endif

                if (imgGrabTmp != null && imgGrabTmp.IsInitialized())
                {
                    ret = CoreOnNewImage(imgGrabTmp.CopyImage(), numTest, prevImageData, 0);

                    if (inRegolazione)
                    {
                        CoreOnNewImageForRegolazioni(imgGrabTmp.CopyImage(), numTest, prevImageData);
                    }

                    imgGrabTmp.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (!cancelToken.Token.IsCancellationRequested)
                {
                    ExceptionManager.AddException(ex);
                }
            }
            return ret;
        }

        private void SetOutput(bool ready, bool result)
        {
            try
            {
#if !_Simulazione
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                {
                    //schedaIO.SetOutput(this.IdStazione, ready, result);
                }
                else if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.Camera)
                {
                    if (this.frameGrabberForThisObject != null)
                    {
                        //SET RISULTATO
                        this.frameGrabberForThisObject.SetOutput("Line3", result);
                        //SET BUSY
                        this.frameGrabberForThisObject.SetOutput("Line4", ready);
                    }
                }
#endif
            }
            catch (Exception) { }
        }

        //private Task taskRaiseContatori = null;

        private void RaiseContatori(DataType.ElaborateResult result)
        {
            //Action action = () =>
            //{
            try
            {
                contatori.SetCam(base.numCamera, result);

                //GESTIONE CONTATORI
                if (base.numCamera == 0)
                {
                    //la camera 0 è qulla che dà il risultato
                    //aspetto tutte le camere
                    contatori.WaitAllCam();

                    //guardo se le altre sono buone, incremento contatori
                    //OLD
                    //bool ok = contatori.ControlloRisultati();
                    //ok = true;
                    //SET RISULTATO
                    //SetOutput(true, ok);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
            //};

            //if (this.taskRaiseContatori == null)
            //    this.taskRaiseContatori = Task.Run(action);
            //else
            //    this.taskRaiseContatori = this.taskRaiseContatori.ContinueWith(k => action());
        }

        public void DoTriggerSoftware()
        {
            this.frameGrabberForThisObject?.TriggerSoftware();
        }

        public void SetTriggerSoftware()
        {
            this.frameGrabberForThisObject?.SetTrigger(true, true);
        }

        public void SetTriggerLine1()
        {
            this.frameGrabberForThisObject?.SetTrigger(true, false);
        }

        public void SetFreeRun()
        {
            this.frameGrabberForThisObject?.SetTrigger(false, false);
        }

        public void SetLive(bool live)
        {
            this.isLive = live;
        }

        public void SetTipoAlgoritmo(DataType.TipoAlgoritmo tipoAlgoritmo)
        {
            this.tipoAlgoritmo = tipoAlgoritmo;
        }

        public GraficiSoglieManager GetGraficiSoglieManager()
        {
            return this.graficiSoglieManager;
        }

    }
}