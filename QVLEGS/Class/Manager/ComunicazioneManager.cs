using ClientEEIP.ClassiMie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;

namespace QVLEGS.Class
{
    public class ComunicazioneManager
    {

        private DataType.Impostazioni impostazioni = null;

        private Manager.SchedaIO schedaIO = null;

        private Thread mainTask = null;
        private Thread mainTask0 = null;
        private Thread mainTask1 = null;
        private Thread mainTask2 = null;
        private Thread mainTask3 = null;
        private Thread mainTask4 = null;
        private Thread mainTask5 = null;
        private Thread mainTaskStep = null;

        private int memRESET = 0;
        private int memDI0 = 0;
        private int memDI1 = 0;
        private int memDI2 = 0;
        private int memDI3 = 0;
        private int memDI4 = 0;
        private int memDI5 = 0;

        private AppManager AppManager_0 = null;
        private AppManager AppManager_1 = null;
        private AppManager AppManager_2 = null;
        private AppManager AppManager_3 = null;
        private AppManager AppManager_4 = null;
        public bool closing = false;

        private DataType.ElaborateResult temp;

        private int stepMemo = 0;

        public ComunicazioneManager(Manager.SchedaIO schedaIO, DataType.Impostazioni impostazioni)
        {
            this.schedaIO = schedaIO;
            this.impostazioni = impostazioni;
        }

        public void SetAppManager(AppManager app0, AppManager app1, AppManager app2, AppManager app3, AppManager app4)
        {
            AppManager_0 = app0;
            AppManager_1 = app1;
            AppManager_2 = app2;
            AppManager_3 = app3;
            AppManager_4 = app4;
        }

        public void StartPolling()
        {

#if !_Simulazione
            schedaIO.adlink_1.WriteDO(3, 1);
            schedaIO.adlink_1.WriteDO(6, 0);
            schedaIO.adlink_1.WriteDO(7, 1);

            schedaIO.adlink_1.WriteDO(13, 0);//out 0
            schedaIO.adlink_1.WriteDO(10, 0);//out 1
            schedaIO.adlink_0.WriteDO(2, 0); //out 2
            schedaIO.adlink_0.WriteDO(14, 1); // RUN st 3C

            schedaIO.adlink_0.WriteDO(12, 0);//3c 

            schedaIO.adlink_1.WriteDO(4, 0);
            schedaIO.adlink_1.WriteDO(5, 0);

            schedaIO.adlink_1.WriteDO(8, 0);
            schedaIO.adlink_1.WriteDO(9, 0);
            schedaIO.adlink_1.WriteDO(10, 0);
            schedaIO.adlink_1.WriteDO(11, 0);
            schedaIO.adlink_1.WriteDO(12, 0);
            schedaIO.adlink_1.WriteDO(13, 0);
            schedaIO.adlink_1.WriteDO(14, 0);
            schedaIO.adlink_1.WriteDO(15, 0);
            schedaIO.adlink_0.WriteDO(0, 0);
            schedaIO.adlink_0.WriteDO(1, 0);
            schedaIO.adlink_0.WriteDO(2, 0);
            schedaIO.adlink_0.WriteDO(3, 0);
            schedaIO.adlink_0.WriteDO(4, 0);
            schedaIO.adlink_0.WriteDO(5, 0);
            schedaIO.adlink_0.WriteDO(6, 0);
            schedaIO.adlink_0.WriteDO(7, 0);

            schedaIO.adlink_0.WriteDO(15, 0);//ready B
            schedaIO.adlink_0.WriteDO(12, 0);//busy B
            schedaIO.adlink_0.WriteDO(13, 0);//out 0 b

            //schedaIO.ResetAll();

            //schedaIO.SetRun(true);
            //schedaIO.SetDone(true);

            this.mainTask = new Thread(new ThreadStart(PollingFoo));
            this.mainTask.Priority = ThreadPriority.Highest;
            this.mainTask.Start();

            this.mainTask0 = new Thread(new ThreadStart(PollingFoo0));
            this.mainTask0.Priority = ThreadPriority.Highest;
            this.mainTask0.Start();

            this.mainTask1 = new Thread(new ThreadStart(PollingFoo1));
            this.mainTask1.Priority = ThreadPriority.Highest;
            this.mainTask1.Start();

            this.mainTask2 = new Thread(new ThreadStart(PollingFoo2));
            this.mainTask2.Priority = ThreadPriority.Highest;
            this.mainTask2.Start();

            this.mainTask3 = new Thread(new ThreadStart(PollingFoo3));
            this.mainTask3.Priority = ThreadPriority.Highest;
            this.mainTask3.Start();

            this.mainTask4 = new Thread(new ThreadStart(PollingFoo4));
            this.mainTask4.Priority = ThreadPriority.Highest;
            this.mainTask4.Start();

            this.mainTask5 = new Thread(new ThreadStart(PollingFoo5));
            this.mainTask5.Priority = ThreadPriority.Highest;
            this.mainTask5.Start();

            this.mainTaskStep = new Thread(new ThreadStart(PoolingStep2));
            this.mainTaskStep.Priority = ThreadPriority.Highest;
            this.mainTaskStep.Start();
#else
            this.mainTask = new Thread(new ThreadStart(PoolingSimulate));
            this.mainTask.Priority = ThreadPriority.Highest;
            this.mainTask.Start();
#endif
        }

        private void resetAll()
        {
            try
            {
                //    this.mainTask?.Abort();
                //    this.mainTask0?.Abort();
                //    this.mainTask1?.Abort();
                //    this.mainTask2?.Abort();
                //    this.mainTask3?.Abort();
                //    this.mainTask4?.Abort();
                //    this.mainTask5?.Abort();
                //    this.mainTaskStep?.Abort();

                schedaIO.adlink_1.WriteDO(3, 1);
                schedaIO.adlink_1.WriteDO(6, 0);
                schedaIO.adlink_1.WriteDO(7, 1);

                schedaIO.adlink_1.WriteDO(13, 0);//out 0
                schedaIO.adlink_1.WriteDO(10, 0);//out 1
                schedaIO.adlink_0.WriteDO(2, 0); //out 2
                schedaIO.adlink_0.WriteDO(14, 1); // RUN st 3C

                schedaIO.adlink_0.WriteDO(12, 0);//3c 

                schedaIO.adlink_1.WriteDO(4, 0);
                schedaIO.adlink_1.WriteDO(5, 0);

                schedaIO.adlink_1.WriteDO(8, 0);
                schedaIO.adlink_1.WriteDO(9, 0);
                schedaIO.adlink_1.WriteDO(10, 0);
                schedaIO.adlink_1.WriteDO(11, 0);
                schedaIO.adlink_1.WriteDO(12, 0);
                schedaIO.adlink_1.WriteDO(13, 0);
                schedaIO.adlink_1.WriteDO(14, 0);
                schedaIO.adlink_1.WriteDO(15, 0);
                schedaIO.adlink_0.WriteDO(0, 0);
                schedaIO.adlink_0.WriteDO(1, 0);
                schedaIO.adlink_0.WriteDO(2, 0);
                schedaIO.adlink_0.WriteDO(3, 0);
                schedaIO.adlink_0.WriteDO(4, 0);
                schedaIO.adlink_0.WriteDO(5, 0);
                schedaIO.adlink_0.WriteDO(6, 0);
                schedaIO.adlink_0.WriteDO(7, 0);

                schedaIO.adlink_0.WriteDO(15, 0);//ready B
                schedaIO.adlink_0.WriteDO(12, 0);//busy B
                schedaIO.adlink_0.WriteDO(13, 0);//out 0 b


                //this.mainTask = new Thread(new ThreadStart(PollingFoo));
                //this.mainTask.Priority = ThreadPriority.Highest;
                //this.mainTask.Start();

                //this.mainTask0 = new Thread(new ThreadStart(PollingFoo0));
                //this.mainTask0.Priority = ThreadPriority.Highest;
                //this.mainTask0.Start();

                //this.mainTask1 = new Thread(new ThreadStart(PollingFoo1));
                //this.mainTask1.Priority = ThreadPriority.Highest;
                //this.mainTask1.Start();

                //this.mainTask2 = new Thread(new ThreadStart(PollingFoo2));
                //this.mainTask2.Priority = ThreadPriority.Highest;
                //this.mainTask2.Start();

                //this.mainTask3 = new Thread(new ThreadStart(PollingFoo3));
                //this.mainTask3.Priority = ThreadPriority.Highest;
                //this.mainTask3.Start();

                //this.mainTask4 = new Thread(new ThreadStart(PollingFoo4));
                //this.mainTask4.Priority = ThreadPriority.Highest;
                //this.mainTask4.Start();

                //this.mainTask5 = new Thread(new ThreadStart(PollingFoo5));
                //this.mainTask5.Priority = ThreadPriority.Highest;
                //this.mainTask5.Start();

                //this.mainTaskStep = new Thread(new ThreadStart(PoolingStep2));
                //this.mainTaskStep.Priority = ThreadPriority.Highest;
                //this.mainTaskStep.Start();

            }
            catch (Exception ex) { ExceptionManager.AddException(ex); }
        }

        public void ResetAllarmi()
        {
        }

        private int counter = 0;

        private void PoolingSimulate()
        {
            int DI0 = 0;
            int DI1 = 0;
            int DI2 = 0;
            int DI3 = 0;
            int DI4 = 0;
            int DI5 = 0;

            while (!closing)
            {
                Thread.Sleep(30);
                if (counter >= 50)
                {
                    DI0 = 1;
                    DI1 = 1;
                    DI2 = 1;
                    DI3 = 1;
                    DI4 = 1;
                    DI5 = 1;

                    counter = 0;
                }
                else
                {
                    DI0 = 0;
                    DI1 = 0;
                    DI2 = 0;
                    DI3 = 0;
                    DI4 = 0;
                    DI5 = 0;

                    counter++;
                }

                //CAM 1 + CAM 2 stazine 5a
                if (DI0 != memDI0)
                {
                    if (DI0 == 1)
                    {
                        DataType.ElaborateResult finalRes = AppManager_0.GrabAndExecuteAlg(1, null);
                        DataType.ElaborateResult res1 = AppManager_0.GrabAndExecuteAlg(2, finalRes.PrevImageData);
                        DataType.ElaborateResult res2 = AppManager_1.GrabAndExecuteAlg(1, null);

                        AppManager_0.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, res1 });
                        AppManager_1.ControlloRisultati(new DataType.ElaborateResult[] { res2 });
                    }
                    memDI0 = DI0;
                }
                //CAM 3 stazione 12 b foto 1
                if (DI1 != memDI1)
                {
                    if (DI1 == 1)
                    {
                        DataType.ElaborateResult finalRes = AppManager_2.GrabAndExecuteAlg(1, null);

                        temp = finalRes;
                        //AppManager_2.ControlloRisultati(new DataType.ElaborateResult[] { finalRes });
                    }
                    memDI1 = DI1;
                }
                if (DI2 != memDI2)
                {
                    if (DI2 == 1)
                    {
                        DataType.ElaborateResult finalRes = AppManager_3.GrabAndExecuteAlg(1, null);

                        AppManager_3.ControlloRisultati(new DataType.ElaborateResult[] { finalRes });
                    }
                    memDI2 = DI2;
                }
                if (DI4 != memDI4)
                {
                    if (DI4 == 1)
                    {
                        DataType.ElaborateResult finalRes = AppManager_2.GrabAndExecuteAlg(2, null);

                        AppManager_2.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, temp });
                    }
                    memDI4 = DI4;
                }
                if (DI5 != memDI5)
                {
                    if (DI5 == 1)
                    {
                        DataType.ElaborateResult finalRes = AppManager_4.GrabAndExecuteAlg(1, null);
                        DataType.ElaborateResult res1 = AppManager_4.GrabAndExecuteAlg(2, null);
                        
                        AppManager_4.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, res1 });
                    }
                    memDI5 = DI5;
                }
            }
        }

        private void PoolingStep()
        {
            Stopwatch timer = Stopwatch.StartNew();
            while (timer.ElapsedMilliseconds < 1000 && !closing)
            {
                if (stepMemo == 1)
                {
                    stepMemo = 0;
                    break;
                }
            }

            if (timer.ElapsedMilliseconds >= 1000)
            {
                Debug.WriteLine("TIMEOUT");
            }
        }

        private void PoolingStep2()
        {
            int step = 0;
            while (!closing)
            {
                schedaIO.adlink_1.ReadDI(10, out step);
                if (step == 0)
                {
                    while (!closing)
                    {
                        schedaIO.adlink_1.ReadDI(10, out step);
                        if (step == 1)
                        {
                            stepMemo = step;
                            Debug.WriteLine($"STEP ON ");
                            break;
                        }
                    }
                }
            }

        }

        private void PollingFoo()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(11, out int RESET);

                    if (RESET != memRESET)
                    {
                        if (RESET == 1)
                        {
                            resetAll();
                        }
                        memRESET = RESET;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo0()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(9, out int DI0);

                    //CAM 1 + CAM 2 stazine 5a
                    if (DI0 != memDI0)
                    {
                        if (DI0 == 1)
                        {
                            TriggerDI0();
                        }
                        memDI0 = DI0;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo1()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(8, out int DI1);

                    //CAM 3 stazione 12 b foto 1
                    if (DI1 != memDI1)
                    {
                        if (DI1 == 1)
                        {
                            TriggerDI1();
                        }
                        memDI1 = DI1;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo2()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(15, out int DI2);

                    //CAM 4 stazione 13 b
                    if (DI2 != memDI2)
                    {
                        if (DI2 == 1)
                        {
                            TriggerDI2();
                        }
                        memDI2 = DI2;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo3()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(14, out int DI3);

                    if (DI3 != memDI3)
                    {
                        if (DI3 == 1)
                        {
                            TriggerDI3();
                        }
                        memDI3 = DI3;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo4()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_1.ReadDI(13, out int DI4);

                    if (DI4 != memDI4)
                    {
                        if (DI4 == 1)
                        {
                            TriggerDI4();
                        }
                        memDI4 = DI4;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void PollingFoo5()
        {
            while (!closing)
            {
                try
                {
                    schedaIO.adlink_0.ReadDI(10, out int DI5);

                    if (DI5 != memDI5)
                    {
                        if (DI5 == 1)
                        {
                            TriggerDI5();
                        }
                        memDI5 = DI5;
                    }

                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
                finally
                {
                    Thread.Sleep(1);
                }
            }
        }

        private ushort GetResult(DataType.ElaborateResult finalRes, string variabile, ushort @default)
        {
            return (finalRes != null && finalRes.ResultOutput.ContainsKey(variabile)) ? finalRes.ResultOutput[variabile] : @default;
        }

        public void SetBitEsito(bool esito)
        {

        }

        private void TriggerDI0()
        {
            Debug.WriteLine("INIZIO DI0");

            PoolingStep();

            schedaIO.adlink_1.WriteDO(14, 0);//out 3, fisso a 1
            schedaIO.adlink_1.WriteDO(15, 0);//out 4, fisso a 1
            schedaIO.adlink_1.WriteDO(11, 0);//out 6
            schedaIO.adlink_1.WriteDO(8, 0); //out 7 spazzole grivory
            schedaIO.adlink_1.WriteDO(9, 0); //out 8 spazzole DOS (induttanza DX)
            schedaIO.adlink_0.WriteDO(7, 0); //out 9 condensatore piccolo dx
            schedaIO.adlink_0.WriteDO(6, 0); //out 10 condensatore grande dx
            schedaIO.adlink_0.WriteDO(5, 0); //out 11 induttanza dx (combacia con spazzole DOS)
            schedaIO.adlink_0.WriteDO(4, 0); //out 12 induttanza sx
            schedaIO.adlink_0.WriteDO(3, 0); //out 13 condensatore piccolo sx
            schedaIO.adlink_0.WriteDO(0, 0); //out 14 protettore
            schedaIO.adlink_0.WriteDO(1, 0); //out 15 alette

            schedaIO.adlink_1.WriteDO(4, 0);//or
            schedaIO.adlink_1.WriteDO(3, 0);//ready
            schedaIO.adlink_1.WriteDO(6, 1);//BUSY

            Thread.Sleep(40);

            //CAM 1 FOTO 1 Backlight
            schedaIO.adlink_0.WriteDO(8, 1);
            Thread.Sleep(50);
            DataType.ElaborateResult finalRes = AppManager_0.GrabAndExecuteAlg(1, null);
            schedaIO.adlink_0.WriteDO(8, 0);

            //Thread.Sleep(150);

            //Accendo luce
            //????????????????
            schedaIO.adlink_1.WriteDO(13, 1);//out 0
            schedaIO.adlink_1.WriteDO(10, 0);//out 1
            schedaIO.adlink_0.WriteDO(2, 1); //out 2

            Thread.Sleep(100);

            //???????????????????
            schedaIO.adlink_1.WriteDO(2, 1);//Accende luce direttamente da Adlink st 5

            //CAM1 FOTO 2
            DataType.ElaborateResult res1 = AppManager_0.GrabAndExecuteAlg(2, finalRes.PrevImageData);
            AppManager_0.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, res1 });

            Thread.Sleep(120);

            //Luce
            schedaIO.adlink_1.WriteDO(13, 0);//out 0
            schedaIO.adlink_1.WriteDO(10, 1);//out 1
            schedaIO.adlink_0.WriteDO(2, 1); //out 2

            schedaIO.adlink_1.WriteDO(2, 0);//Accende luce direttamente da Adlink st 5

            Thread.Sleep(50);

            //CAM2 FOTO1
            schedaIO.adlink_0.WriteDO(9, 1);
            Thread.Sleep(50);

            DataType.ElaborateResult res2 = AppManager_1.GrabAndExecuteAlg(1, null);
            AppManager_1.ControlloRisultati(new DataType.ElaborateResult[] { res2 });
            schedaIO.adlink_0.WriteDO(9, 0);
            
            DataType.ElaborateResult res1tmp = new DataType.ElaborateResult();
            foreach (KeyValuePair<string, ushort> item in res1.ResultOutput)
            {
                if (finalRes.ResultOutput.ContainsKey(item.Key))
                {
                    if (finalRes.ResultOutput[item.Key] != item.Value)
                    {
                        res1tmp.ResultOutput.Add(item.Key, 0);
                        finalRes.ResultOutput.Remove(item.Key);
                    }
                }
                else
                    res1tmp.ResultOutput.Add(item.Key, item.Value);
            }
            finalRes.ResultOutput = finalRes.ResultOutput.Concat(res1tmp.ResultOutput).ToDictionary(x => x.Key, x => x.Value);

            //finalRes.ResultOutput = finalRes.ResultOutput.Concat(res1.ResultOutput).ToDictionary(x => x.Key, x => x.Value);




            DataType.ElaborateResult res2tmp = new DataType.ElaborateResult();

            foreach (KeyValuePair<string, ushort> item in res2.ResultOutput)
            {
                if (finalRes.ResultOutput.ContainsKey(item.Key))
                {
                    if (finalRes.ResultOutput[item.Key] != item.Value)
                    {
                        res2tmp.ResultOutput.Add(item.Key, 0);
                        finalRes.ResultOutput.Remove(item.Key);
                    }
                }
                else
                    res2tmp.ResultOutput.Add(item.Key, item.Value);
            }
            //foreach (KeyValuePair<string, ushort> item in res2.ResultOutput)
            //{
            //    if (finalRes.ResultOutput.ContainsKey(item.Key))
            //    {
            //        if (finalRes.ResultOutput[item.Key] != item.Value)
            //            res2.ResultOutput[item.Key] = 0;

            //        finalRes.ResultOutput.Remove(item.Key);
            //    }
            //}
            // finalRes.ResultOutput = finalRes.ResultOutput.Concat(res2.ResultOutput).ToDictionary(x => x.Key, x => x.Value);

            finalRes.ResultOutput = finalRes.ResultOutput.Concat(res2tmp.ResultOutput).ToDictionary(x => x.Key, x => x.Value);
            //result
            //schedaIO.adlink_1.WriteDO(8, 1); //out 7 spazzole grivory

            schedaIO.adlink_1.WriteDO(8, GetResult(finalRes, "DO7", 0)); //out 7 spazzole grivory
            schedaIO.adlink_1.WriteDO(9, GetResult(finalRes, "DO8", 0)); //out 8 spazzole DOS (induttanza DX)
            schedaIO.adlink_0.WriteDO(7, GetResult(finalRes, "DO9", 0)); //out 9 condensatore piccolo dx
            schedaIO.adlink_0.WriteDO(6, GetResult(finalRes, "DO10", 0)); //out 10 condensatore grande dx
            schedaIO.adlink_0.WriteDO(5, GetResult(finalRes, "DO11", 0)); //out 11 induttanza dx (combacia con spazzole DOS)
            schedaIO.adlink_0.WriteDO(4, GetResult(finalRes, "DO12", 0)); //out 12 induttanza sx
            schedaIO.adlink_0.WriteDO(3, GetResult(finalRes, "DO13", 0)); //out 13 condensatore piccolo sx
            schedaIO.adlink_0.WriteDO(0, GetResult(finalRes, "DO14", 0)); //out 14 protettore
            schedaIO.adlink_0.WriteDO(1, GetResult(finalRes, "DO15", 0)); //out 15 alette



            schedaIO.adlink_0.WriteDO(2, 1); //out 2, fisso a 1
            schedaIO.adlink_1.WriteDO(14, 1);//out 3, fisso a 1
            schedaIO.adlink_1.WriteDO(15, 1);//out 4, fisso a 1
            schedaIO.adlink_1.WriteDO(11, 1);//out 6


            Thread.Sleep(5);

            //ready
            schedaIO.adlink_1.WriteDO(4, 1);//or
            schedaIO.adlink_1.WriteDO(6, 0);//BUSY
            schedaIO.adlink_1.WriteDO(3, 1);//ready

            Debug.WriteLine("FINITO DI0");
        }

        private void TriggerDI1()
        {
            Debug.WriteLine("INIZIO DI1");

            PoolingStep();

            //test
            #region reset
            schedaIO.adlink_1.WriteDO(13, 0);//out 0
            schedaIO.adlink_1.WriteDO(10, 0);//out 1
            schedaIO.adlink_0.WriteDO(2, 0); //out 2
            schedaIO.adlink_1.WriteDO(14, 0);//out 3
            schedaIO.adlink_1.WriteDO(15, 0);//out 4
            schedaIO.adlink_1.WriteDO(12, 0);//out 5
            schedaIO.adlink_1.WriteDO(11, 0);//out 6
            schedaIO.adlink_1.WriteDO(8, 0); //out 7*
            schedaIO.adlink_1.WriteDO(9, 0); //out 8
            schedaIO.adlink_0.WriteDO(7, 0); //out 9
            schedaIO.adlink_0.WriteDO(6, 0); //out 10
            schedaIO.adlink_0.WriteDO(5, 0); //out 11
            schedaIO.adlink_0.WriteDO(4, 0); //out 12
            schedaIO.adlink_0.WriteDO(3, 0); //out 13
            schedaIO.adlink_0.WriteDO(0, 0); //out 14
            schedaIO.adlink_0.WriteDO(1, 0); //out 15
            #endregion
            //test

            Thread.Sleep(50);

            //busy
            schedaIO.adlink_1.WriteDO(4, 0);//or
            schedaIO.adlink_1.WriteDO(3, 0);//ready
            schedaIO.adlink_1.WriteDO(6, 1);//BUSY

            schedaIO.adlink_1.WriteDO(11, 0);//out 6

            DataType.ElaborateResult finalRes = AppManager_2.GrabAndExecuteAlg(1, null);
            temp = finalRes;

            //result
            schedaIO.adlink_0.WriteDO(3, GetResult(finalRes, "DO13", 0));//out 13 treccia SX
            schedaIO.adlink_0.WriteDO(0, GetResult(finalRes, "DO14", 0));//out 14 treccia DX
            schedaIO.adlink_0.WriteDO(1, GetResult(finalRes, "DO15", 0));//out 15 colonnine

            Thread.Sleep(50);

            schedaIO.adlink_1.WriteDO(11, 1);//out 6

            //ready
            schedaIO.adlink_1.WriteDO(6, 0);//BUSY
            schedaIO.adlink_1.WriteDO(3, 1);//ready

            Debug.WriteLine("FINITO DI1");
        }

        private void TriggerDI2()
        {
            Debug.WriteLine("INIZIO DI2");

            PoolingStep();

            #region reset
            schedaIO.adlink_1.WriteDO(13, 0);//out 0
            schedaIO.adlink_1.WriteDO(10, 0);//out 1
            schedaIO.adlink_0.WriteDO(2, 0); //out 2
            schedaIO.adlink_1.WriteDO(14, 0);//out 3
            schedaIO.adlink_1.WriteDO(15, 0);//out 4
            schedaIO.adlink_1.WriteDO(12, 0);//out 5
            schedaIO.adlink_1.WriteDO(11, 0);//out 6
            schedaIO.adlink_1.WriteDO(8, 0); //out 7*
            schedaIO.adlink_1.WriteDO(9, 0); //out 8
            schedaIO.adlink_0.WriteDO(7, 0); //out 9
            schedaIO.adlink_0.WriteDO(6, 0); //out 10
            schedaIO.adlink_0.WriteDO(5, 0); //out 11
            schedaIO.adlink_0.WriteDO(4, 0); //out 12
            schedaIO.adlink_0.WriteDO(3, 0); //out 13
            schedaIO.adlink_0.WriteDO(0, 0); //out 14
            schedaIO.adlink_0.WriteDO(1, 0); //out 15
            #endregion

            //busy
            schedaIO.adlink_1.WriteDO(4, 0);//or
            schedaIO.adlink_1.WriteDO(3, 0);//ready
            schedaIO.adlink_1.WriteDO(6, 1);//BUSY

            DataType.ElaborateResult finalRes = AppManager_3.GrabAndExecuteAlg(1, null);
            AppManager_3.ControlloRisultati(new DataType.ElaborateResult[] { finalRes });

            Thread.Sleep(1);

            //RESULT
            schedaIO.adlink_0.WriteDO(3, 1);//out 13 alette rotte
            schedaIO.adlink_1.WriteDO(12, 1);//out 5 alette rotte grivory
            schedaIO.adlink_1.WriteDO(8, GetResult(finalRes, "DO7", 0));//out 7 condensatore piccolo dx
            schedaIO.adlink_1.WriteDO(9, GetResult(finalRes, "DO8", 0));//out 8 condensatore Grande dx
            schedaIO.adlink_0.WriteDO(7, GetResult(finalRes, "DO9", 0));//out 9 condensatore piccolo sx
            schedaIO.adlink_0.WriteDO(6, GetResult(finalRes, "DO10", 0));//out 10 posizione molle
            schedaIO.adlink_0.WriteDO(5, GetResult(finalRes, "DO11", 0));//out 11 protettore
            schedaIO.adlink_0.WriteDO(1, GetResult(finalRes, "DO15", 0));//out 15 posizione boccola
            schedaIO.adlink_0.WriteDO(4, GetResult(finalRes, "DO12", 0));//out 12 gambi induttori
                                                                         //schedaIO.adlink_0.WriteDO(0, GetResult(finalRes, "DO14", 0));//out 14 contatto massa
                                                                         //schedaIO.adlink_0.WriteDO(4, 1);//out 12 gambi induttori
            schedaIO.adlink_0.WriteDO(0, 1);//out 14 contatto massa
            //schedaIO.adlink_0.WriteDO(3, GetResult(finalRes, "DO13", 0));//out 13 alette rotte




            schedaIO.adlink_0.WriteDO(5, 1);//out 11 protettore


            //schedaIO.adlink_1.WriteDO(8, 1);//out 7 condensatore piccolo dx
            //schedaIO.adlink_1.WriteDO(9,  1);//out 8 condensatore Grande dx
            //schedaIO.adlink_0.WriteDO(7,  1);//out 9 condensatore piccolo sx
            //schedaIO.adlink_0.WriteDO(6, 1);//out 10 posizione molle
            //schedaIO.adlink_0.WriteDO(5,  1);//out 11 protettore
            //schedaIO.adlink_0.WriteDO(1,  1);


            Thread.Sleep(1);

            schedaIO.adlink_1.WriteDO(11, 1);//out 6 (serve per chiudere il ciclo)

            Thread.Sleep(1);

            //ready
            schedaIO.adlink_1.WriteDO(4, 1);//or
            schedaIO.adlink_1.WriteDO(6, 0);//BUSY
            schedaIO.adlink_1.WriteDO(3, 1);//ready

            Debug.WriteLine("FINITO DI2");
        }

        private void TriggerDI3()
        {
            Debug.WriteLine("INIZIO DI3");

            PoolingStep();

            #region reset
            schedaIO.adlink_1.WriteDO(13, 0);//out 0
            schedaIO.adlink_1.WriteDO(10, 0);//out 1
            schedaIO.adlink_0.WriteDO(2, 0); //out 2
            schedaIO.adlink_1.WriteDO(14, 0);//out 3
            schedaIO.adlink_1.WriteDO(15, 0);//out 4
            schedaIO.adlink_1.WriteDO(12, 0);//out 5
            schedaIO.adlink_1.WriteDO(11, 0);//out 6
            schedaIO.adlink_1.WriteDO(8, 0); //out 7*
            schedaIO.adlink_1.WriteDO(9, 0); //out 8
            schedaIO.adlink_0.WriteDO(7, 0); //out 9
            schedaIO.adlink_0.WriteDO(6, 0); //out 10
            schedaIO.adlink_0.WriteDO(5, 0); //out 11
            schedaIO.adlink_0.WriteDO(4, 0); //out 12
            schedaIO.adlink_0.WriteDO(3, 0); //out 13
            schedaIO.adlink_0.WriteDO(0, 0); //out 14
            schedaIO.adlink_0.WriteDO(1, 0); //out 15
            #endregion

            //busy
            schedaIO.adlink_1.WriteDO(3, 0);//ready
            schedaIO.adlink_1.WriteDO(6, 1);//BUSY

            // DataType.ElaborateResult finalRes = AppManager_3.GrabAndExecuteAlg(1);
            Thread.Sleep(50);

            //result allways OK
            schedaIO.adlink_0.WriteDO(7, 1);//out 9
            Thread.Sleep(1);
            schedaIO.adlink_1.WriteDO(11, 1);//out 6

            Thread.Sleep(50);

            //ready
            schedaIO.adlink_1.WriteDO(6, 0);//BUSY
            schedaIO.adlink_1.WriteDO(3, 1);//ready 

            Debug.WriteLine("FINITO DI3");
        }

        private void TriggerDI4()
        {
            Debug.WriteLine("INIZIO DI4");

            PoolingStep();

            //busy
            schedaIO.adlink_1.WriteDO(3, 0);//ready
            schedaIO.adlink_1.WriteDO(6, 1);//BUSY

            schedaIO.adlink_1.WriteDO(11, 0);//out 6 

            DataType.ElaborateResult finalRes = AppManager_2.GrabAndExecuteAlg(2, null);
            AppManager_2.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, temp });

            Thread.Sleep(50);

            schedaIO.adlink_1.WriteDO(11, 1);//out 6

            Thread.Sleep(50);

            //result
            schedaIO.adlink_0.WriteDO(3, GetResult(finalRes, "DO13", 0));//out 13 indut SX
            schedaIO.adlink_0.WriteDO(0, GetResult(finalRes, "DO14", 0));//out 14 indut DX
            schedaIO.adlink_0.WriteDO(1, GetResult(finalRes, "DO15", 0));//out 15 prottetore

            Thread.Sleep(50);

            // ready
            schedaIO.adlink_1.WriteDO(6, 0);//BUSY
            schedaIO.adlink_1.WriteDO(3, 1);//ready

            Debug.WriteLine("FINITO DI4");
        }

        private void TriggerDI5()
        {
            Debug.WriteLine("INIZIO DI5");

            //Thread.Sleep(50);
            //busy
            schedaIO.adlink_0.WriteDO(15, 1);//ready B
            schedaIO.adlink_0.WriteDO(12, 1);//busy B
            schedaIO.adlink_0.WriteDO(13, 0);//out 0 b

            //luce 1....foto 1
            schedaIO.adlink_1.WriteDO(0, 1);//luce 1
            schedaIO.adlink_1.WriteDO(1, 0);//luce 2
            Thread.Sleep(50);
            DataType.ElaborateResult finalRes = AppManager_4.GrabAndExecuteAlg(1, null);

            //luce 2....foto 2
            schedaIO.adlink_1.WriteDO(0, 0);//luce 1
            schedaIO.adlink_1.WriteDO(1, 1);//luce 2
            Thread.Sleep(50);
            DataType.ElaborateResult res1 = AppManager_4.GrabAndExecuteAlg(2, null);

            AppManager_4.ControlloRisultati(new DataType.ElaborateResult[] { finalRes, res1 });

            schedaIO.adlink_1.WriteDO(0, 0);//luce 1
            schedaIO.adlink_1.WriteDO(1, 0);//luce 2

            if (finalRes.ResultOutput.ContainsKey("DO0") && res1.ResultOutput.ContainsKey("DO0"))
                if (finalRes.ResultOutput["DO0"] != res1.ResultOutput["DO0"])
                    finalRes.ResultOutput["DO0"] = 1;

            //ready result
            schedaIO.adlink_0.WriteDO(15, 0);//ready B
            schedaIO.adlink_0.WriteDO(12, 0);//busy B
            schedaIO.adlink_0.WriteDO(13, GetResult(finalRes, "DO0", 1));//result scarto a 1

            Debug.WriteLine("FINITO DI5");
        }

        public void Close()
        {
            try
            {
                this.mainTask?.Join();
                this.mainTask0?.Join();
                this.mainTask1?.Join();
                this.mainTask2?.Join();
                this.mainTask3?.Join();
                this.mainTask4?.Join();
                this.mainTask5?.Join();
                this.mainTaskStep?.Join();
            }
            catch (Exception ex) { ExceptionManager.AddException(ex); }
        }

    }
}