using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace QVLEGS.Algoritmi
{
    public class AlgoritmoLavoro : Algoritmo, IDisposable
    {

        private const int TIMEOUT_SHPAE = 50;
        private const int DELTA_PIXEL_POS = 5;

        private object objLock = new object();

        #region Variabili Private

        private bool disposed = false;

        private DataType.ParametriAlgoritmo[] parametriArr = null;
        private string idFormato = null;

        private DateTime dataRiferimentoTurno = DateTime.MinValue;
        private int nomeTurno = -1;

        private DataType.TipoAlgoritmo tipoAlgoritmo = DataType.TipoAlgoritmo.Normale;

        private bool caricamentoParametri = false;

        #endregion Variabili Private

        public AlgoritmoLavoro(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
            this.parametriArr = new DataType.ParametriAlgoritmo[2];
        }

        public void SetDatiTurno(DateTime dataRiferimentoTurno, int nomeTurno)
        {
            this.dataRiferimentoTurno = dataRiferimentoTurno;
            this.nomeTurno = nomeTurno;
        }

        public void LoadFiles(string idFormato)
        {
            this.idFormato = idFormato;
            LoadMask();
        }

        public void SaveFiles(string idFormato)
        {

        }

        public void SetCaricamentoParametri(bool v)
        {
            caricamentoParametri = v;
        }

        public void SetAlgoritmoParam(DataType.ParametriAlgoritmo param, int numTest)
        {
            lock (objLock)
            {
                this.parametriArr[numTest - 1] = param;
                if (this.parametriArr[numTest - 1] != null)
                {
                    this.parametriArr[numTest - 1].Template = DataType.TemplateFormato.GetTemplateByName(this.parametriArr[numTest - 1].TemplateName);
                }
            }
        }

        public DataType.ParametriAlgoritmo GetAlgoritmoParam(int numTest)
        {
            lock (objLock)
            {
                return this.parametriArr[numTest - 1];
            }
        }

        public void SetTipoAlgoritmo(DataType.TipoAlgoritmo tipoAlgoritmo)
        {
            this.tipoAlgoritmo = tipoAlgoritmo;
        }

        public void AlgoritmoLavoroFunction(HImage image, int numTest, DataType.PrevImageData prevImageData, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            DataType.ParametriAlgoritmo parametri = null;

            ArrayList workingList = new ArrayList();
            DataType.ElaborateResult res = new DataType.ElaborateResult() { Success = true };
            res.StatisticheObj.IdStazione = this.idStazione;
            res.StatisticheObj.IdCamera = this.idCamera;
            res.StatisticheObj.IdFormato = this.idFormato;
            res.StatisticheObj.DataRiferimentoTurno = this.dataRiferimentoTurno;
            res.StatisticheObj.NomeTurno = this.nomeTurno;

            StringBuilder sbTempi = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();

            ClassInputAlgoritmi inputAlg = null;
            HRegion regionMain = null;

            try
            {
                workingList.Add(new Utilities.ObjectToDisplay(image.CopyImage()));

                parametri = this.parametriArr[numTest - 1];

                if (caricamentoParametri)
                {
                    //Se sto caricando i parametri do OK
                    res.Success = true;
                }

                else if (parametri == null)
                {
                    res.Success = false;
                    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_PARAMETRI_KO"));
                }
                else if (parametri.WizardAcqCompleto == false)
                {
                    res.Success = false;
                    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ACQ_WIZARD_KO"));
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(parametri.RoiMain.Row1, parametri.RoiMain.Column1, parametri.RoiMain.Row2, parametri.RoiMain.Column2);

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                    if (parametri.AllineamentoParam.WizardCompleto /*&& false*/)
                    {
                        sw.Restart();
                        inputAlg = CreaClassInputAlgoritmi(parametri, image, regionMain);
                        sbTempi.AppendLine();
                        sbTempi.AppendFormat("{0:00000}ms - CreaClassInputAlgoritmi", sw.ElapsedMilliseconds);

                        bool ok = true;

                        if (idStazione == 0 && numTest == 1)
                        {
                            ok = Centraggio(image, regionMain, parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList);
                            res.StatisticheObj.AddObjContatore("ALLINEAMENTO_OK", ok);

                            if (ok)
                            {
                                res.PrevImageData = new DataType.PrevImageData();
                                res.PrevImageData.Image = image.Clone();
                                res.PrevImageData.RowRef = parametri.AllineamentoParam.ShapeParam.RowRef;
                                res.PrevImageData.ColumnRef = parametri.AllineamentoParam.ShapeParam.ColumnRef;
                                res.PrevImageData.AngleRef = parametri.AllineamentoParam.ShapeParam.AngleRef;
                                res.PrevImageData.Row = row;
                                res.PrevImageData.Col = col;
                                res.PrevImageData.Angle = angle;

                                inputAlg.ImageRotate = image.Clone();

                                //inputAlg.Row = row;
                                //inputAlg.Col = col;
                                //inputAlg.Angle = angle;

                                //HHomMat2D hh = new HHomMat2D();
                                //hh.HomMat2dIdentity();
                                //hh = hh.HomMat2dTranslate(parametri.AllineamentoParam.ShapeParam.RowRef - row, parametri.AllineamentoParam.ShapeParam.ColumnRef - col);
                                //hh = hh.HomMat2dRotate(-angle, parametri.AllineamentoParam.ShapeParam.RowRef, parametri.AllineamentoParam.ShapeParam.ColumnRef);
                                //inputAlg.ImageRotate = hh.AffineTransImage(inputAlg.Image, "constant", "false");
                            }
                        }
                        else if (idStazione == 0 && numTest == 2)
                        {
                            //inputAlg.Row = prevImageData.Row;
                            //inputAlg.Col = prevImageData.Col;
                            //inputAlg.Angle = prevImageData.Angle;

                            HHomMat2D hh = new HHomMat2D();
                            hh.HomMat2dIdentity();
                            hh = hh.HomMat2dTranslate(prevImageData.RowRef - prevImageData.Row, prevImageData.ColumnRef - prevImageData.Col);
                            hh = hh.HomMat2dRotate(-prevImageData.Angle, prevImageData.RowRef, prevImageData.ColumnRef);
                            inputAlg.ImageRotate = hh.AffineTransImage(inputAlg.Image, "constant", "false");
                        }
                        else if (idStazione == 3)
                        {
                            ok = Centraggio(image, regionMain, parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList);
                            res.StatisticheObj.AddObjContatore("ALLINEAMENTO_OK", ok);

                            if (ok)
                            {
                                inputAlg.Row = row;
                                inputAlg.Col = col;
                                inputAlg.Angle = angle;

                                HHomMat2D hh = new HHomMat2D();
                                hh.HomMat2dIdentity();
                                hh = hh.HomMat2dTranslate(parametri.AllineamentoParam.ShapeParam.RowRef - row, parametri.AllineamentoParam.ShapeParam.ColumnRef - col);
                                hh = hh.HomMat2dRotate(-angle, parametri.AllineamentoParam.ShapeParam.RowRef, parametri.AllineamentoParam.ShapeParam.ColumnRef);
                                inputAlg.ImageRotate = hh.AffineTransImage(inputAlg.Image, "constant", "false");
                                inputAlg.ImageRotateGray = inputAlg.ImageRotate.Rgb1ToGray();
                            }
                        }
                        else
                        {
                            inputAlg.ImageRotate = image.Clone();
                        }


                        //bool ok = Centraggio(image, regionMain, parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList);
                        //res.StatisticheObj.AddObjContatore("ALLINEAMENTO_OK", ok);
                        if (ok)
                        {
                            //inputAlg.Row = row;
                            //inputAlg.Col = col;
                            //inputAlg.Angle = angle;

                            //HHomMat2D hh = new HHomMat2D();
                            //hh.HomMat2dIdentity();
                            //hh = hh.HomMat2dTranslate(parametri.AllineamentoParam.ShapeParam.RowRef - row, parametri.AllineamentoParam.ShapeParam.ColumnRef - col);
                            //hh = hh.HomMat2dRotate(-angle, parametri.AllineamentoParam.ShapeParam.RowRef, parametri.AllineamentoParam.ShapeParam.ColumnRef);
                            //inputAlg.ImageRotate = hh.AffineTransImage(inputAlg.Image, "constant", "false");

                            workingList.Add(new Utilities.ObjectToDisplay(inputAlg.ImageRotate.CopyImage()));

                            res.Success = true;

                            if (parametri.Cam1_Foto1Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam1_Foto1(inputAlg, parametri.Cam1_Foto1Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM1_FOTO1_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam1_Foto1", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam1_Foto2Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam1_Foto2(inputAlg, parametri.Cam1_Foto2Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM1_FOTO2_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam1_Foto2", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam2_Foto1Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam2_Foto1(inputAlg, parametri.Cam2_Foto1Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM2_FOTO1_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam2_Foto1", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam3_Foto1Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam3_Foto1(inputAlg, parametri.Cam3_Foto1Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM3_FOTO1_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam3_Foto1", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam3_Foto2Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam3_Foto2(inputAlg, parametri.Cam3_Foto2Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM3_FOTO2_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam3_Foto2", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam4_Foto1Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam4_Foto1(inputAlg, parametri.Cam4_Foto1Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM4_FOTO1_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam4_Foto1", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam5_Foto1Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam5_Foto1(inputAlg, parametri.Cam5_Foto1Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM5_FOTO1_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam5_Foto1", sw.ElapsedMilliseconds);
                            }
                            if (parametri.Cam5_Foto2Param.WizardCompleto)
                            {
                                sw.Restart();
                                ok = TestCam5_Foto2(inputAlg, parametri.Cam5_Foto2Param, false, ref res, ref workingList);
                                res.Success &= ok;
                                res.StatisticheObj.AddObjContatore("TEST_CAM5_FOTO2_OK", ok);

                                sbTempi.AppendLine();
                                sbTempi.AppendFormat("{0:00000}ms - Test_Cam5_Foto2", sw.ElapsedMilliseconds);
                            }
                        }
                        //else
                        //{
                        //    res.Success = false;
                        //    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_KO_ALLINEAMENTO"));
                        //}
                    }
                }
            }
            catch (Exception)
            {
                res.Success = false;
                //throw;
            }
            finally
            {
                workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));

                AddTestiOutAlgoritmi(res, ref workingList);
                //AddTestiRagioneScarto(res, ref workingList);

                res.DescrizioneTempi = sbTempi.ToString();

                res.StatisticheObj.AddObjContatore("ALG_OK", res.Success);
                res.StatisticheObj.AddObjContatore($"CNT_KO_CAM{this.idCamera + 1}", !res.Success);

                iconicList = workingList;
                result = res;

                inputAlg?.Dispose();
                regionMain?.Dispose();
            }
        }

        public static string[] GetAllKey(int idStaz)
        {
            switch (idStaz)
            {
                case 0:
                    return new string[] {
                 "TEST_1_CAM_1_FOTO_1"
                , "TEST_2_CAM_1_FOTO_1"
                , "TEST_3_CAM_1_FOTO_1"
                , "TEST_4_CAM_1_FOTO_1"
                , "TEST_5A_CAM_1_FOTO_1"
                , "TEST_5B_CAM_1_FOTO_1"
                , "TEST_6_CAM_1_FOTO_1"
                , "TEST_1_CAM_1_FOTO_2"
                , "TEST_2_CAM_1_FOTO_2"
                , "TEST_3_CAM_1_FOTO_2"
                , "TEST_4_CAM_1_FOTO_2"
                , "TEST_5_CAM_1_FOTO_2"
                , "TEST_6_CAM_1_FOTO_2"
                , "TEST_7_CAM_1_FOTO_2"
                , "TEST_8_CAM_1_FOTO_2"
                , "TEST_9_CAM_1_FOTO_2"
                , "TEST_10_CAM_1_FOTO_2"
                };

                case 1:
                    return new string[] {
                  "TEST_1_CAM_2_FOTO_1"
                , "TEST_2_CAM_2_FOTO_1"
                , "TEST_3_CAM_2_FOTO_1"
                };
                case 2:
                    return new string[] {
                  "TEST_1_CAM_3_FOTO_1"
                , "TEST_2_CAM_3_FOTO_1"
                , "TEST_3_CAM_3_FOTO_1"
                , "TEST_4_CAM_3_FOTO_1"
                , "TEST_1_CAM_3_FOTO_2"
                , "TEST_2_CAM_3_FOTO_2"
                , "TEST_3_CAM_3_FOTO_2"
                };
                case 3:
                    return new string[] {
                  "TEST_1_CAM_4_FOTO_1"
                , "TEST_2_CAM_4_FOTO_1"
                , "TEST_3_CAM_4_FOTO_1"
                , "TEST_4_CAM_4_FOTO_1"
                , "TEST_5_CAM_4_FOTO_1"
                , "TEST_6_CAM_4_FOTO_1"
                , "TEST_7_CAM_4_FOTO_1"
                , "TEST_8_CAM_4_FOTO_1"
                , "TEST_9_CAM_4_FOTO_1"
               , "TEST_10_CAM_4_FOTO_1"
               , "TEST_11_CAM_4_FOTO_1"
               , "TEST_12_CAM_4_FOTO_1"
               , "TEST_13_CAM_4_FOTO_1"
               , "TEST_14_CAM_4_FOTO_1"
               , "TEST_15_CAM_4_FOTO_1"
                };


                case 4:
                    return new string[] {
                  "TEST_1_CAM_5_FOTO_1"
                , "TEST_1_CAM_5_FOTO_2"
                };


                default:
                    return null;
            }

        }

        public static double GetBucketByKey(string key)
        {
            double ret = 0.1;

            //switch (key)
            //{
            //    // TOP
            //    case "TEST_1_CAM_1":
            //        ret = 0.5;
            //        break;

            //    default:
            //        throw new Exception("SOGLIA INESISTENTE");
            //        break;
            //}

            return ret;
        }

        public Dictionary<string, double> GetSoglieByKey(string key)
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();

            if (this.parametriArr.Length > 0)
            {
                switch (key)
                {
                    // TOP
                    case "TEST_1_CAM_1_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle1);
                        break;

                    case "TEST_2_CAM_1_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle2);
                        break;

                    case "TEST_3_CAM_1_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle3);
                        break;

                    case "TEST_4_CAM_1_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle4);
                        break;

                    case "TEST_5A_CAM_1_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam1_Foto1Param.DistMinRectangle);
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.DistMaxRectangle);
                        break;

                    case "TEST_5B_CAM_1_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam1_Foto1Param.DistMinRectangle);
                        ret.Add("max", this.parametriArr[0].Cam1_Foto1Param.DistMaxRectangle);
                        break;

                    case "TEST_6_CAM_1_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam1_Foto1Param.DistMinCircle);
                        break;

                    case "TEST_1_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_1);
                        break;

                    case "TEST_2_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_2);
                        break;

                    case "TEST_3_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_3);
                        break;

                    case "TEST_4_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_4);
                        break;

                    case "TEST_5_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_5);
                        break;

                    case "TEST_6_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_6);
                        break;

                    case "TEST_7_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_7);
                        break;

                    case "TEST_8_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_8);
                        break;

                    case "TEST_9_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_9);
                        break;

                    case "TEST_10_CAM_1_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_10);
                        break;

                    case "TEST_1_CAM_2_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam2_Foto1Param.DistMax);
                        break;

                    case "TEST_2_CAM_2_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam2_Foto1Param.AreaMaxLeft);
                        break;

                    case "TEST_3_CAM_2_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam2_Foto1Param.AreaMaxRight);
                        break;

                    case "TEST_1_CAM_3_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam3_Foto1Param.DistMin_Calipper_1);
                        ret.Add("max", this.parametriArr[0].Cam3_Foto1Param.DistMax_Calipper_1);
                        break;

                    case "TEST_2_CAM_3_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam3_Foto1Param.DistMin_Height_1);
                        ret.Add("max", this.parametriArr[0].Cam3_Foto1Param.DistMax_Height_1);
                        break;

                    case "TEST_3_CAM_3_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam3_Foto1Param.DistMin_Height_2);
                        ret.Add("max", this.parametriArr[0].Cam3_Foto1Param.DistMax_Height_2);
                        break;

                    case "TEST_4_CAM_3_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam3_Foto1Param.DistMin_Calipper_2);
                        ret.Add("max", this.parametriArr[0].Cam3_Foto1Param.DistMax_Calipper_2);
                        break;

                    case "TEST_1_CAM_3_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_1);
                        ret.Add("max", this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_1);
                        break;

                    case "TEST_2_CAM_3_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_2);
                        ret.Add("max", this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_2);
                        break;

                    case "TEST_3_CAM_3_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_3);
                        ret.Add("max", this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_3);
                        break;

                    case "TEST_1_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxCircleCenter);
                        break;

                    case "TEST_2_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMinGrayLeft);
                        break;

                    case "TEST_3_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMinGrayRight);
                        break;

                    case "TEST_4_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft);
                        break;

                    case "TEST_5_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueRight);
                        break;

                    case "TEST_6_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxYellowRight);
                        break;

                    case "TEST_7_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxYellowCenter);
                        break;

                    case "TEST_8_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft2);
                        break;

                    case "TEST_9_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueRight2);
                        break;

                    case "TEST_10_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueUp);
                        break;

                    case "TEST_11_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft3);
                        break;

                    case "TEST_12_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft4);
                        break;

                    case "TEST_13_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMaxRedLeft);
                        break;

                    case "TEST_14_CAM_4_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam4_Foto1Param.AreaMaxRedRight);
                        break;

                    case "TEST_15_CAM_4_FOTO_1":
                        ret.Add("max", this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueCenter);
                        break;

                    case "TEST_1_CAM_5_FOTO_1":
                        ret.Add("min", this.parametriArr[0].Cam5_Foto1Param.AreaMin);
                        break;

                    case "TEST_1_CAM_5_FOTO_2":
                        ret.Add("min", this.parametriArr[1].Cam5_Foto2Param.AreaMin);
                        break;

                    default:
                        throw new Exception("SOGLIA INESISTENTE");
                        break;

                }
            }

            return ret;
        }

        public void SetSoglieByKey(string key, double[] soglie)
        {
            if (this.parametriArr.Length > 0)
            {
                switch (key)
                {
                    // TOP
                    case "TEST_1_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle1 = soglie[1];
                        break;

                    case "TEST_2_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle2 = soglie[1];
                        break;

                    case "TEST_3_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle3 = soglie[1];
                        break;

                    case "TEST_4_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.AreaMaxCircle4 = soglie[1];
                        break;

                    case "TEST_5A_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.DistMinRectangle = soglie[0];
                        this.parametriArr[0].Cam1_Foto1Param.DistMaxRectangle = soglie[1];
                        break;

                    case "TEST_5B_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.DistMinRectangle = soglie[0];
                        this.parametriArr[0].Cam1_Foto1Param.DistMaxRectangle = soglie[1];
                        break;

                    case "TEST_6_CAM_1_FOTO_1":
                        this.parametriArr[0].Cam1_Foto1Param.DistMinCircle = soglie[0];
                        break;

                    case "TEST_1_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_1 = soglie[0];
                        break;

                    case "TEST_2_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_2 = soglie[0];
                        break;

                    case "TEST_3_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_3 = soglie[0];
                        break;

                    case "TEST_4_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_4 = soglie[0];
                        break;

                    case "TEST_5_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_5 = soglie[0];
                        break;

                    case "TEST_6_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_6 = soglie[0];
                        break;

                    case "TEST_7_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_7 = soglie[0];
                        break;

                    case "TEST_8_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_8 = soglie[0];
                        break;

                    case "TEST_9_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_9 = soglie[0];
                        break;

                    case "TEST_10_CAM_1_FOTO_2":
                        this.parametriArr[1].Cam1_Foto2Param.AreaMinBig_10 = soglie[0];
                        break;

                    case "TEST_1_CAM_2_FOTO_1":
                        this.parametriArr[0].Cam2_Foto1Param.DistMax = soglie[1];
                        break;

                    case "TEST_2_CAM_2_FOTO_1":
                        this.parametriArr[0].Cam2_Foto1Param.AreaMaxLeft = soglie[1];
                        break;

                    case "TEST_3_CAM_2_FOTO_1":
                        this.parametriArr[0].Cam2_Foto1Param.AreaMaxRight = soglie[1];
                        break;

                    case "TEST_1_CAM_3_FOTO_1":
                        this.parametriArr[0].Cam3_Foto1Param.DistMin_Calipper_1 = soglie[0];
                        this.parametriArr[0].Cam3_Foto1Param.DistMax_Calipper_1 = soglie[1];
                        break;

                    case "TEST_2_CAM_3_FOTO_1":
                        this.parametriArr[0].Cam3_Foto1Param.DistMin_Height_1 = soglie[0];
                        this.parametriArr[0].Cam3_Foto1Param.DistMax_Height_1 = soglie[1];
                        break;

                    case "TEST_3_CAM_3_FOTO_1":
                        this.parametriArr[0].Cam3_Foto1Param.DistMin_Height_2 = soglie[0];
                        this.parametriArr[0].Cam3_Foto1Param.DistMax_Height_2 = soglie[1];
                        break;

                    case "TEST_4_CAM_3_FOTO_1":
                        this.parametriArr[0].Cam3_Foto1Param.DistMin_Calipper_2 = soglie[0];
                        this.parametriArr[0].Cam3_Foto1Param.DistMax_Calipper_2 = soglie[1];
                        break;

                    case "TEST_1_CAM_3_FOTO_2":
                        this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_1 = soglie[0];
                        this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_1 = soglie[1];
                        break;

                    case "TEST_2_CAM_3_FOTO_2":
                        this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_2 = soglie[0];
                        this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_2 = soglie[1];
                        break;

                    case "TEST_3_CAM_3_FOTO_2":
                        this.parametriArr[1].Cam3_Foto2Param.DistMin_Height_3 = soglie[0];
                        this.parametriArr[1].Cam3_Foto2Param.DistMax_Height_3 = soglie[1];
                        break;

                    case "TEST_1_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxCircleCenter = soglie[0];
                        break;

                    case "TEST_2_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMinGrayLeft = soglie[0];
                        break;

                    case "TEST_3_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMinGrayRight = soglie[0];
                        break;

                    case "TEST_4_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft = soglie[0];
                        break;

                    case "TEST_5_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueRight = soglie[0];
                        break;

                    case "TEST_6_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxYellowRight = soglie[0];
                        break;

                    case "TEST_7_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxYellowCenter = soglie[0];
                        break;

                    case "TEST_8_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft2 = soglie[0];
                        break;

                    case "TEST_9_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueRight2 = soglie[0];
                        break;

                    case "TEST_10_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueUp = soglie[0];
                        break;

                    case "TEST_11_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft3 = soglie[0];
                        break;

                    case "TEST_12_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueLeft4 = soglie[0];
                        break;

                    case "TEST_13_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxRedLeft = soglie[0];
                        break;

                    case "TEST_14_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxRedRight = soglie[0];
                        break;

                    case "TEST_15_CAM_4_FOTO_1":
                        this.parametriArr[0].Cam4_Foto1Param.AreaMaxBlueCenter = soglie[0];
                        break;

                    case "TEST_1_CAM_5_FOTO_1":
                        this.parametriArr[0].Cam5_Foto1Param.AreaMin = soglie[0];
                        break;

                    case "TEST_1_CAM_5_FOTO_2":
                        this.parametriArr[1].Cam5_Foto2Param.AreaMin = soglie[0];
                        break;

                    default:
                        throw new Exception("SOGLIA INESISTENTE");
                        break;
                }
            }
        }

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    base.DisposeBase();
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AlgoritmoLavoro()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}