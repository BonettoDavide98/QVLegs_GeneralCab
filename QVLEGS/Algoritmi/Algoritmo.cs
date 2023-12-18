using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QVLEGS.Algoritmi
{
    public class Algoritmo
    {

        protected const string COLORE_SHAPE = "green";
        protected const string COLORE_ANN_OK = "green";
        protected const string COLORE_ANN_KO = "red";

        protected HRegion regionMask = null;
        int blackwhite = 0;

        protected int idCamera = -1;
        protected int idStazione = -1;
        protected DataType.Impostazioni impostazioni = null;
        protected DataType.ImpostazioniCamera impostazioniCamera = null;
        protected DBL.LinguaManager linguaManager = null;

        private HClassGmm gmmBlueLeft = null;
        private HClassGmm gmmBlueRight = null;
        private HClassGmm gmmYellowRight = null;
        private HClassGmm gmmYellowCenter = null;
        private HClassGmm gmmRed = null;

        private HClassLUT lutBlueLeft = null;
        private HClassLUT lutBlueRight = null;
        private HClassLUT lutYellowRight = null;
        private HClassLUT lutYellowCenter = null;
        private HClassLUT lutRed = null;

        private HShapeModel modelHole = null;

        public Algoritmo(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            this.idCamera = idCamera;
            this.idStazione = idStazione;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;

            switch (idCamera)
            {
                case 0:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera1;
                    break;
                case 1:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera2;
                    break;
                case 2:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera3;
                    break;
                case 3:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera4;
                    break;
                case 4:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera5;
                    break;
                case 5:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera6;
                    break;
            }

            if (idStazione == 3)
            {
                this.gmmBlueLeft = new HClassGmm();
                gmmBlueLeft.ReadClassGmm(Path.Combine(Application.StartupPath, "GMM", "blue_1.ggc"));
                //gmmBlueLeft.ReadSamplesClassGmm(Path.Combine(Application.StartupPath, "GMM", "blue_1_samples.ggc"));
                lutBlueLeft = new HClassLUT();
                lutBlueLeft.CreateClassLutGmm(gmmBlueLeft, "rejection_threshold", 0.000001);


                this.gmmBlueRight = new HClassGmm();
                gmmBlueRight.ReadClassGmm(Path.Combine(Application.StartupPath, "GMM", "blue_1.ggc"));
                //gmmBlueRight.ReadSamplesClassGmm(Path.Combine(Application.StartupPath, "GMM", "blue_1_samples.ggc"));
                lutBlueRight = new HClassLUT();
                lutBlueRight.CreateClassLutGmm(gmmBlueRight, "rejection_threshold", 0.000001);


                this.gmmYellowCenter = new HClassGmm();
                gmmYellowCenter.ReadClassGmm(Path.Combine(Application.StartupPath, "GMM", "yellow_1.ggc"));
                //gmmYellowCenter.ReadSamplesClassGmm(Path.Combine(Application.StartupPath, "GMM", "yellow_1_samples.ggc"));
                lutYellowCenter = new HClassLUT();
                lutYellowCenter.CreateClassLutGmm(gmmYellowCenter, "rejection_threshold", 0.000001);


                this.gmmYellowRight = new HClassGmm();
                gmmYellowRight.ReadClassGmm(Path.Combine(Application.StartupPath, "GMM", "yellow_2.ggc"));
                //gmmYellowRight.ReadSamplesClassGmm(Path.Combine(Application.StartupPath, "GMM", "yellow_2_samples.ggc"));
                lutYellowRight = new HClassLUT();
                lutYellowRight.CreateClassLutGmm(gmmYellowRight, "rejection_threshold", 0.000001);


                this.gmmRed = new HClassGmm();
                gmmRed.ReadClassGmm(Path.Combine(Application.StartupPath, "GMM", "red_1.ggc"));
                //gmmRed.ReadSamplesClassGmm(Path.Combine(Application.StartupPath, "GMM", "red_1_samples.ggc")); 
                lutRed = new HClassLUT();
                lutRed.CreateClassLutGmm(gmmRed, "rejection_threshold", 0.000001);
            }

            if (idStazione == 0)
            {
                modelHole = new HShapeModel();
                modelHole.ReadShapeModel(Path.Combine(Application.StartupPath, "MODEL", "hole.shm"));
            }

        }

        public DataType.TipoCamera GetTipoCamera()
        {
            return this.impostazioniCamera.TipoCamera;
        }


        protected void LoadMask()
        {
            string path = System.IO.Path.Combine(impostazioni.PathDatiBase, "MASK", (idCamera + 1).ToString(), "RegionMask.reg");

            if (System.IO.File.Exists(path))
            {
                this.regionMask = new HRegion();
                this.regionMask.ReadRegion(path);
            }
        }


        public void NOPAlgorithm(HImage image, int numTest, DataType.PrevImageData prevImageData, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            ArrayList workingList = new ArrayList();
            DataType.ElaborateResult res = new DataType.ElaborateResult() { Success = true };

            workingList.Add(new Utilities.ObjectToDisplay(image.CopyImage()));

            iconicList = workingList;
            result = res;
        }

        protected string GetColorTrasparenza(Color c)
        {
            return GetColorTrasparenza(c, 100);
        }

        protected string GetColorTrasparenza(Color c, int a)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2") + a.ToString("X2");
        }

        protected void AddTestiOutAlgoritmi(DataType.ElaborateResult res, ref ArrayList workingList)
        {
            try
            {
                for (int i = 0; i < res.TestiOutAlgoritmi.Count; i++)
                {
                    workingList.Add(new Utilities.ObjectToDisplay(res.TestiOutAlgoritmi[i].Item1, res.TestiOutAlgoritmi[i].Item2, 60 + (i * 20), 10, 16, true));
                }
            }
            catch (Exception) { }
        }

        protected void AddTestiRagioneScarto(DataType.ElaborateResult res, ref ArrayList workingList)
        {
            try
            {
                for (int i = 0; i < res.TestiRagioneScarto.Count; i++)
                {
                    workingList.Add(new Utilities.ObjectToDisplay(res.TestiRagioneScarto[i], "red", 60 + (i * 20), 10, 16, true));
                }
            }
            catch (Exception) { }
        }

        protected ClassInputAlgoritmi CreaClassInputAlgoritmi(DataType.ParametriAlgoritmo parametri, HImage image, HRegion regionMain)
        {
            ClassInputAlgoritmi ret = new ClassInputAlgoritmi() { };

            HImage imageCrop = null;
            HRegion regionToUse = null;
            try
            {
                ret.Template = parametri.Template;

                if (this.regionMask == null)
                    regionToUse = regionMain.Clone();
                else
                    regionToUse = regionMain.Difference(this.regionMask);

                if (image.CountChannels() == 3)
                {
                    ret.ImageGray = image.Rgb1ToGray();
                }

                ret.Image = image.ReduceDomain(regionToUse);
            }
            finally
            {
                imageCrop?.Dispose();
                regionToUse?.Dispose();
            }
            return ret;
        }


        #region CENTRAGGIO

        protected bool FindShapeModel(HImage image, HRegion roi, HShapeModel model, DataType.AllineamentoShapeParam p, out HXLDCont shapeContour, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
        {
            bool ret = false;
            shapeContour = null;
            row = null;
            column = null;
            angle = null;
            scale = null;
            score = null;

            HXLDCont shapeModelContours = null;
            try
            {
                if (model != null)
                {
                    if (FindScaledShapeModel(image, roi, model, p.CreateParam, p.FindParam, out row, out column, out angle, out scale, out score))
                    {
                        shapeModelContours = model.GetShapeModelContours(1);

                        shapeContour = new HXLDCont();
                        shapeContour.GenEmptyObj();

                        for (int i = 0; i < score.TupleLength(); i++)
                        {
                            HXLDCont tmp = null;
                            try
                            {
                                HHomMat2D homMat = new HHomMat2D();
                                homMat.VectorAngleToRigid(0, 0, 0, row[i].D, column[i].D, angle[i].D);
                                //homMat = homMat.HomMat2dScale(scale[i].D, scale[i].D, row[i].D, column[i].D);
                                tmp = homMat.AffineTransContourXld(shapeModelContours);

                                shapeContour = shapeContour.ConcatObj(tmp);
                            }
                            finally
                            {
                                tmp?.Dispose();
                            }
                        }

                        ret = true;
                    }
                }
            }
            finally
            {
                shapeModelContours?.Dispose();
            }

            return ret;
        }

        protected bool FindScaledShapeModel(HImage image, HRegion roi, HShapeModel model, DataType.CreateScaledShapeModelParam pCreate, DataType.FindScaledShapeModelParam pFind, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
        {
            bool ret = true;

            row = new HTuple();
            column = new HTuple();
            angle = new HTuple();
            scale = new HTuple();
            score = new HTuple();

            HImage imageReduced = null;

            try
            {
                if (model != null)
                {
                    if (roi != null)
                        imageReduced = image.ReduceDomain(roi);
                    else
                        imageReduced = image.Clone();

                    HTuple levels = new HTuple(new int[] { pCreate.NumLevels, pFind.LastPyramidLevel });
                    //HTuple subPixel = new HTuple(pFind.SubPixel, "max_deformation 2");
                    HTuple subPixel = new HTuple(pFind.SubPixel);

                    // imageReduced.FindScaledShapeModel(model, pFind.AngleStart, pFind.AngleExtent, pFind.ScaleMin, pFind.ScaleMax, new HTuple(pFind.MinScore), pFind.NumMatches, pFind.MaxOverlap, subPixel, levels, pFind.Greediness, out row, out column, out angle, out scale, out score);

                    //imageReduced.FindScaledShapeModel(model, 0, 6.28, 0.9, 1.1, 0.5, 1, 0.5, "least_squares", 0, 0.9, out row, out column, out angle, out scale, out score);

                    //imageReduced.FindScaledShapeModel(model, 0, 6.28, 0.9, 1.1, 0.5, 1, 0.5, subPixel, levels, 0.9, out row, out column, out angle, out scale, out score);

                    //imageReduced.FindScaledShapeModel(model, new HTuple(-10).TupleRad(), new HTuple(20).TupleRad(), 0.9, 1.1, 0.6, 1, 0, subPixel, levels, pFind.Greediness, out row, out column, out angle, out scale, out score);

                    imageReduced.FindShapeModel(model, new HTuple(-10).TupleRad(), new HTuple(20).TupleRad(), 0.6, 1, 0.5, subPixel, levels, pFind.Greediness, out row, out column, out angle, out score);



                    ret = (score.TupleLength() > 0);
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (imageReduced != null && imageReduced.IsInitialized())
                    imageReduced.Dispose();
            }
            return ret;
        }

        protected bool CentraConShape(HImage image, HRegion roi, HShapeModel model, DataType.AllineamentoShapeParam param, out double row, out double column, out double angle, out HXLDCont contours)
        {
            bool ret = false;
            row = 0;
            column = 0;
            angle = 0;
            contours = null;

            try
            {
                HTuple resRow;
                HTuple resColumn;
                HTuple resAngle;
                HTuple resScale;
                HTuple resScore;

                if (FindShapeModel(image, roi, model, param, out contours, out resRow, out resColumn, out resAngle, out resScale, out resScore))
                {
                    if (resScore.TupleLength() == 1)
                    {
                        row = resRow.D;
                        column = resColumn.D;
                        angle = resAngle.D;

                        ret = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        protected bool Centraggio(HImage image, HRegion region, DataType.AllineamentoParam param, bool isWizard, out double row, out double col, out double angle, ref ArrayList workingList)
        {
            DataType.ElaborateResult res = new DataType.ElaborateResult();
            return Centraggio(image, region, param, isWizard, out row, out col, out angle, ref res, ref workingList);
        }

        protected bool Centraggio(HImage image, HRegion region, DataType.AllineamentoParam param, bool isWizard, out double row, out double col, out double angle, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;
            row = 0;
            col = 0;
            angle = 0;

            HXLDCont detectionContour = null;
            try
            {
                ret = CentraConShape(image, region, param.ShapeParam.ShapeModel, param.ShapeParam, out row, out col, out angle, out detectionContour);

                if (detectionContour != null)
                {
                    workingList.Add(new Utilities.ObjectToDisplay(detectionContour.Clone(), "green", 2));
                }

                if (ret && param.LimitaAngolo)
                {
                    detectionContour.SmallestRectangle2Xld(out double rowsmr, out double columnsmr, out double phismr, out double length1smr, out double length2smr);

                    double angolo = Math.Abs(new HTuple(phismr).TupleDeg().D);
                    ret = angolo <= param.MaxAngolo;

                    if (isWizard)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CENTRAGGIO_ANGOLO"), angolo, param.MaxAngolo), ret ? "green" : "red"));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                detectionContour?.Dispose();
            }
            return ret;
        }

        #endregion CENTRAGGIO


        #region CAM1_FOTO1

        protected bool TestCam1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam1_Step1_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam1_Step2_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam1_Step3_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_4 = TestCam1_Step4_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_5 = TestCam1_Step5_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_6 = TestCam1_Step6_Foto1(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3 && okStep_4 && okStep_5 && okStep_6;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;

        }

        protected bool TestCam1_Step1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle1 = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle1 = new HRegion();
                regionCircle1.GenCircle(param.Circle1.Row, param.Circle1.Column, param.Circle1.Radius);
                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle1);
                regionThresholdCircle1 = imageReducedCircle1.Threshold(param.ThresholdCircle1, 255);

                double areaCircle1 = regionThresholdCircle1.Area;

                workingList.Add(new Utilities.ObjectToDisplay(imageReducedCircle1.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), "red", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircle1 ? true : false;

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP1"), valueToShow1, param.AreaMaxCircle1), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_1_CAM_1_FOTO_1", valueToShow1);

                if (res.ResultOutput.ContainsKey("DO9"))
                {
                    if (res.ResultOutput["DO9"] != (ret ? 1 : 0))
                        res.ResultOutput["DO9"] = 0;
                }
                else
                    res.ResultOutput.Add("DO9", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle1?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam1_Step2_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle1 = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle1 = new HRegion();
                regionCircle1.GenCircle(param.Circle2.Row, param.Circle2.Column, param.Circle2.Radius);
                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle1);
                regionThresholdCircle1 = imageReducedCircle1.Threshold(param.ThresholdCircle2, 255);

                double areaCircle1 = regionThresholdCircle1.Area;

                workingList.Add(new Utilities.ObjectToDisplay(imageReducedCircle1.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), "red", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm2(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircle2 ? true : false;

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP2"), valueToShow1, param.AreaMaxCircle2), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_2_CAM_1_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO9"))
                {
                    if (res.ResultOutput["DO9"] != (ret ? 1 : 0))
                        res.ResultOutput["DO9"] = 0;
                }
                else
                    res.ResultOutput.Add("DO9", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle1?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam1_Step3_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle1 = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle1 = new HRegion();
                regionCircle1.GenCircle(param.Circle3.Row, param.Circle3.Column, param.Circle3.Radius);
                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle1);
                regionThresholdCircle1 = imageReducedCircle1.Threshold(param.ThresholdCircle3, 255);

                double areaCircle1 = regionThresholdCircle1.Area;

                workingList.Add(new Utilities.ObjectToDisplay(imageReducedCircle1.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), "red", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm2(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircle3 ? true : false;

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP3"), valueToShow1, param.AreaMaxCircle3), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_3_CAM_1_FOTO_1", valueToShow1);

                if (res.ResultOutput.ContainsKey("DO13"))
                {
                    if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                        res.ResultOutput["DO13"] = 0;
                }
                else
                    res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle1?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam1_Step4_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle1 = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle1 = new HRegion();
                regionCircle1.GenCircle(param.Circle4.Row, param.Circle4.Column, param.Circle4.Radius);
                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle1);
                regionThresholdCircle1 = imageReducedCircle1.Threshold(param.ThresholdCircle1, 255);

                double areaCircle1 = regionThresholdCircle1.Area;

                workingList.Add(new Utilities.ObjectToDisplay(imageReducedCircle1.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), "red", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm2(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircle4 ? true : false;

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP4"), valueToShow1, param.AreaMaxCircle4), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_4_CAM_1_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO13"))
                {
                    if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                        res.ResultOutput["DO13"] = 0;
                }
                else
                    res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle1?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam1_Step5_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;
            HXLDCont controurLeft = null;
            HXLDCont controurRight = null;

            try
            {

                regionMain = new HRegion();
                regionMain.GenRectangle2(param.RoiCalliper.Row, param.RoiCalliper.Column, 0.0, param.RoiCalliper.Length1, param.RoiCalliper.Length2);
                imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                Calliper(inputAlg.ImageRotate, param.RoiCalliper.Row, param.RoiCalliper.Column, 0.0, param.RoiCalliper.Length1, param.RoiCalliper.Length2, 10, 5, out HTuple edgeRowFirst, out HTuple edgeColFirst, out HTuple edgeRowSecond, out HTuple edgeColSecond, out HTuple distance);

                double distMinPX = CalibraFrom_mmToPx(param.DistMinRectangle);
                double distMaxPX = CalibraFrom_mmToPx(param.DistMaxRectangle);
                HOperatorSet.AreaCenter(imageReduced, out HTuple areaCenter, out HTuple rowCenter, out HTuple columnCenter);
                HOperatorSet.TupleSort(edgeColFirst, out HTuple edgeColFirstSorted);
                HOperatorSet.TupleSort(edgeColSecond, out HTuple edgeColSecondSorted);

                double mediaLeft = 0;
                double mediaRight = 0;

                if (edgeColFirstSorted.Length > 0)
                {
                    for (int i = 1; i < edgeColFirstSorted.Length - 2; i++)
                    {
                        mediaLeft += edgeColFirstSorted[i];
                    }
                    mediaLeft = mediaLeft / (edgeColFirstSorted.Length - 3);
                }

                if (edgeColSecondSorted.Length > 0)
                {
                    for (int i = 1; i < edgeColSecondSorted.Length - 2; i++)
                    {
                        mediaRight += edgeColSecondSorted[i];
                    }
                    mediaRight = mediaRight / (edgeColSecondSorted.Length - 3);
                }
                regionMain.AreaCenter(out double row, out double col);

                double tmpMediaLeft = mediaLeft;
                double tmpMediaRight = mediaRight;
                mediaLeft = col - mediaLeft;
                mediaRight = mediaRight - col;

                double valueToShow1 = CalibraFromPxTo_mm(mediaLeft);
                double valueToShow2 = CalibraFromPxTo_mm(mediaRight);

                ret = valueToShow1 <= param.DistMaxRectangle && valueToShow1 >= param.DistMinRectangle && valueToShow2 <= param.DistMaxRectangle && valueToShow2 >= param.DistMinRectangle ? true : false;

                controurLeft = new HXLDCont();
                controurLeft.GenCrossContourXld(rowCenter, (HTuple)tmpMediaLeft, 20, 0);

                controurRight = new HXLDCont();
                controurRight.GenCrossContourXld(rowCenter, (HTuple)tmpMediaRight, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controurLeft.Clone(), valueToShow1 <= param.DistMaxRectangle && valueToShow1 >= param.DistMinRectangle ? "green" : "red", 2) { DrawMode = "fill" });
                workingList.Add(new Utilities.ObjectToDisplay(controurRight.Clone(), valueToShow2 <= param.DistMaxRectangle && valueToShow2 >= param.DistMinRectangle ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP5_L"), valueToShow1, param.DistMinRectangle, param.DistMaxRectangle), valueToShow1 <= param.DistMaxRectangle && valueToShow1 >= param.DistMinRectangle ? "green" : "red"));
                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP5_R"), valueToShow2, param.DistMinRectangle, param.DistMaxRectangle), valueToShow2 <= param.DistMaxRectangle && valueToShow2 >= param.DistMinRectangle ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_5A_CAM_1_FOTO_1", valueToShow1);
                res.StatisticheObj.AddMisura("TEST_5B_CAM_1_FOTO_1", valueToShow2);

                if (res.ResultOutput.ContainsKey("DO8"))
                {
                    if (res.ResultOutput["DO8"] != (ret ? 1 : 0))
                        res.ResultOutput["DO8"] = 0;
                }
                else
                    res.ResultOutput.Add("DO8", (ret ? ushort.Parse("1") : ushort.Parse("0")));

                if (res.ResultOutput.ContainsKey("DO7"))
                {
                    if (res.ResultOutput["DO7"] != (ret ? 1 : 0))
                        res.ResultOutput["DO7"] = 0;
                }
                else
                    res.ResultOutput.Add("DO7", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionMain?.Dispose();
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                controurLeft?.Dispose();
                controurRight?.Dispose();
            }
            return ret;
        }

        protected bool TestCam1_Step6_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle = null;
            HImage imageReducedCircle = null;
            HXLDCont contourGood = null;
            HXLDCont contourBad = null;

            try
            {
                regionCircle = new HRegion();
                regionCircle.GenCircle(param.CircleEdge.Row, param.CircleEdge.Column, param.CircleEdge.Radius);
                imageReducedCircle = inputAlg.ImageRotate.ReduceDomain(regionCircle);
                FindEdgeCircle(inputAlg.ImageRotate, param.CircleEdge.Row, param.CircleEdge.Column, param.CircleEdge.Radius, 100, 10, 170, out HTuple edgeRow, out HTuple edgeCol);
                double distMaxPX = CalibraFrom_mmToPx(param.LengthMaxCircle);
                double distMinPX = CalibraFrom_mmToPx(param.LengthMinCircle);

                HTuple rowGood = new HTuple();
                HTuple rowBad = new HTuple();
                HTuple colGood = new HTuple();
                HTuple colBad = new HTuple();
                HOperatorSet.AreaCenter(regionCircle, out HTuple area, out HTuple row, out HTuple col);

                double distanceMedia = 0;
                int mediaCounter = 0;

                if (edgeRow.Length > 0)
                {
                    for (int i = 0; i < edgeRow.Length; i++)
                    {
                        HOperatorSet.DistancePp(edgeRow[i], edgeCol[i], row, col, out HTuple distance);

                        if (distance <= (HTuple)distMaxPX && distance >= (HTuple)distMinPX)
                        {
                            rowGood = rowGood.TupleConcat(edgeRow[i]);
                            colGood = colGood.TupleConcat(edgeCol[i]);
                            distanceMedia += distance;
                            mediaCounter++;
                        }
                        else if (distance < (HTuple)distMinPX)
                        {
                            rowBad = rowBad.TupleConcat(edgeRow[i]);
                            colBad = colBad.TupleConcat(edgeCol[i]);
                            distanceMedia += distance;
                            mediaCounter++;
                        }
                    }
                }
                distanceMedia = distanceMedia / mediaCounter;
                if (rowGood.Length > 0)
                {
                    contourGood = new HXLDCont();
                    contourGood.GenCrossContourXld(rowGood, colGood, 5, 0);
                }
                if (rowBad.Length > 0)
                {
                    contourBad = new HXLDCont();
                    contourBad.GenCrossContourXld(rowBad, colBad, 5, 0);
                }

                workingList.Add(new Utilities.ObjectToDisplay(imageReducedCircle.Clone(), "green", 2) { DrawMode = "margin" });

                if (contourGood != null)
                    workingList.Add(new Utilities.ObjectToDisplay(contourGood.Clone(), "green", 2) { DrawMode = "fill" });

                if (contourBad != null)
                    workingList.Add(new Utilities.ObjectToDisplay(contourBad.Clone(), "red", 2) { DrawMode = "fill" });

                if (rowBad.Length <= 2)
                    ret = true;

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO1_STEP6"), CalibraFromPxTo_mm(distanceMedia), param.LengthMinCircle), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_6_CAM_1_FOTO_1", CalibraFromPxTo_mm(distanceMedia));
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle?.Dispose();
                imageReducedCircle?.Dispose();
                contourGood?.Dispose();
                contourBad?.Dispose();
            }
            return ret;
        }

        private void Calliper(HImage image, HTuple row, HTuple column, HTuple rad, HTuple length1, HTuple length2, HTuple numMisure, HTuple dimMisura, out HTuple edgeRowFirst, out HTuple edgeColFirst, out HTuple edgeRowSecond, out HTuple edgeColSecond, out HTuple distance)
        {
            image.GetImageSize(out HTuple Width, out HTuple Height);

            double delta = (length2 * 2 - dimMisura * 2) / (numMisure - 1);
            HRegion regionMain = new HRegion();

            edgeRowFirst = new HTuple();
            edgeColFirst = new HTuple();
            edgeRowSecond = new HTuple();
            edgeColSecond = new HTuple();
            distance = new HTuple();
            try
            {
                for (int i = 1; i <= numMisure; i++)
                {
                    double p = -length2 + (delta * (i - 1)) + dimMisura;

                    HHomMat2D hHomMat2D = new HHomMat2D();
                    hHomMat2D.HomMat2dIdentity();
                    hHomMat2D = hHomMat2D.HomMat2dTranslate(0.0, p);
                    hHomMat2D = hHomMat2D.HomMat2dRotate(-rad, column, row);

                    HTuple Qx = hHomMat2D.AffineTransPoint2d(column, row, out HTuple Qy);

                    regionMain.GenRectangle2(Qy, Qx, rad, length1, dimMisura);
                    HOperatorSet.GenMeasureRectangle2(Qy, Qx, rad, length1, dimMisura, Width, Height, "nearest_neighbor", out HTuple measureHandler);

                    HOperatorSet.MeasurePairs(image, measureHandler, 1, 30, "all", "all", out HTuple RowEdgeFirst, out HTuple ColumnEdgeFirst, out HTuple AmplitudeFirst, out HTuple RowEdgeSecond, out HTuple ColumnEdgeSecond, out HTuple AmplitudeSecond, out HTuple IntraDistance, out HTuple InterDistance);

                    if (RowEdgeFirst.Length == 1)
                    {
                        edgeRowFirst = edgeRowFirst.TupleConcat(RowEdgeFirst);
                        edgeColFirst = edgeColFirst.TupleConcat(ColumnEdgeFirst);
                        edgeRowSecond = edgeRowSecond.TupleConcat(RowEdgeSecond);
                        edgeColSecond = edgeColSecond.TupleConcat(ColumnEdgeSecond);
                        distance = distance.TupleConcat(IntraDistance);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FindEdgeCircle(HImage image, HTuple row, HTuple column, HTuple radius, HTuple numMisure, HTuple dimMisura, HTuple lenMisura, out HTuple edgeRow, out HTuple edgeCol)
        {
            image.GetImageSize(out HTuple Width, out HTuple Height);
            double delta = new HTuple(360).TupleRad().D / numMisure;
            HRegion regionMain = new HRegion();
            edgeRow = new HTuple();
            edgeCol = new HTuple();

            for (int i = 1; i <= numMisure; i++)
            {
                HTuple p = (delta * (i - 1));

                HHomMat2D hHomMat2D = new HHomMat2D();
                hHomMat2D.HomMat2dIdentity();
                hHomMat2D = hHomMat2D.HomMat2dTranslate(radius.D, 0.0);
                hHomMat2D = hHomMat2D.HomMat2dRotate(-p, column, row);

                HTuple Qx = hHomMat2D.AffineTransPoint2d(column, row, out HTuple Qy);
                regionMain.GenRectangle2(Qy, Qx, p, lenMisura / 2, dimMisura);
                HOperatorSet.GenMeasureRectangle2(Qy, Qx, p, lenMisura / 2, dimMisura, Width, Height, "nearest_neighbor", out HTuple measureHandler);
                HOperatorSet.MeasurePos(image, measureHandler, 1, 50, "negative", "last", out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple distance);

                if (rowEdge.Length > 0)
                {
                    edgeRow = edgeRow.TupleConcat(rowEdge);
                    edgeCol = edgeCol.TupleConcat(columnEdge);
                }
            }
        }

        #endregion CAM1_FOTO1


        #region CAM1_FOTO2

        protected bool TestCam1_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam1_Step1_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam1_Step2_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam1_Step3_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked3, param.invertedBlack3, param.invertedWhite3);
                    bool okStep_4 = TestCam1_Step4_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked4, param.invertedBlack4, param.invertedWhite4);
                    bool okStep_5 = TestCam1_Step5_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked5, param.invertedBlack5, param.invertedWhite5);
                    bool okStep_6 = TestCam1_Step6_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked6, param.invertedBlack6, param.invertedWhite6);
                    bool okStep_7 = TestCam1_Step7_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked7, param.invertedBlack7, param.invertedWhite7);
                    bool okStep_8 = TestCam1_Step8_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked8, param.invertedBlack8, param.invertedWhite8);
                    bool okStep_9 = TestCam1_Step9_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked9, param.invertedBlack9, param.invertedWhite9);
                    bool okStep_10 = TestCam1_Step10_Foto2(inputAlg, param, isWizard, ref res, ref workingList, param.checked10, param.invertedBlack10, param.invertedWhite10);
                    bool okStep_11 = TestCam1_Step11_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_12 = TestCam1_Step12_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_13 = TestCam1_Step13_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_14 = TestCam1_Step14_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_15 = TestCam1_Step15_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_16 = TestCam1_Step16_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_17 = TestCam1_Step17_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_18 = TestCam1_Step18_Foto2(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3 && okStep_4 && okStep_5 && okStep_6 && okStep_7 && okStep_8 && okStep_9 && okStep_10 && okStep_11 && okStep_12 && okStep_13 && okStep_14 && okStep_15 && okStep_16 && okStep_17 && okStep_18;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;

        }
        //protected bool TestCam1_Step1_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, int blackwhite = 0)
        //{
        //    bool ret = false;

        //    HImage imageReducedRect1 = null;
        //    HRegion regionThreshold = null;
        //    HXLDCont controurStartGood = null;
        //    HXLDCont controurStartBad = null;
        //    HXLDCont controurEndGood = null;
        //    HXLDCont controurEndBad = null;

        //    try
        //    {
        //        if (blackwhite == 0)
        //        {
        //            imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(param.bigRegion_1);

        //            regionThreshold = imageReducedRect1.Threshold(0.0, param.ThresholdBig_1);
        //            HOperatorSet.AreaCenter(regionThreshold, out HTuple area, out HTuple row, out HTuple column);

        //            workingList.Add(new Utilities.ObjectToDisplay(param.bigRegion_1.Clone(), "green", 2) { DrawMode = "margin" });
        //            workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), area <= param.AreaMAxBig_1 && area >= param.AreaMinBig_1 ? "blue" : "red", 2) { DrawMode = "fill" });
        //            ret = area <= param.AreaMAxBig_1 && area >= param.AreaMinBig_1 ? true : false;
        //            res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_1"), area, param.AreaMinBig_1, param.AreaMAxBig_1), ret ? "green" : "red"));

        //            res.StatisticheObj.AddMisura("TEST_1_CAM_1_FOTO_2", area);
        //        }
        //        else
        //        {
        //            imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(param.bigRegion2_1);

        //            regionThreshold = imageReducedRect1.Threshold(param.ThresholdBig2_1, 255.0);
        //            HOperatorSet.AreaCenter(regionThreshold, out HTuple area, out HTuple row, out HTuple column);

        //            workingList.Add(new Utilities.ObjectToDisplay(param.bigRegion2_1.Clone(), "green", 2) { DrawMode = "margin" });
        //            workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), area <= param.AreaMAxBig2_1 && area >= param.AreaMinBig2_1 ? "blue" : "red", 2) { DrawMode = "fill" });
        //            ret = area <= param.AreaMAxBig2_1 && area >= param.AreaMinBig2_1 ? true : false;
        //            res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_1"), area, param.AreaMinBig2_1, param.AreaMAxBig2_1), ret ? "green" : "red"));

        //            res.StatisticheObj.AddMisura("TEST_1_CAM_1_FOTO_2", area);
        //        }

        //        if (res.ResultOutput.ContainsKey("DO14"))
        //        {
        //            if (res.ResultOutput["DO14"] != (ret ? 1 : 0))
        //                res.ResultOutput["DO14"] = 0;
        //        }
        //        else
        //            res.ResultOutput.Add("DO14", (ret ? ushort.Parse("1") : ushort.Parse("0")));
        //    }
        //    catch (Exception)
        //    {
        //        ret = false;
        //    }
        //    finally
        //    {
        //        imageReducedRect1?.Dispose();
        //        regionThreshold?.Dispose();
        //        controurStartGood?.Dispose();
        //        controurEndBad?.Dispose();
        //        controurStartBad?.Dispose();
        //        controurEndGood?.Dispose();
        //    }
        //    return ret;
        //}





        protected bool TestCam1_Step1_10_Foto2(ClassInputAlgoritmi inputAlg
            , HRegion bigRegion
            , double ThresholdBig
            , double AreaMAxBig
            , double AreaMinBig
            , bool invertedBlack
            , bool whiteEnabled
            , HRegion bigRegion2
            , double ThresholdBig2
            , double AreaMAxBig2
            , double AreaMinBig2
            , bool invertedWhite
            , int idx
            , bool isWizard
            , ref DataType.ElaborateResult res
            , ref ArrayList workingList)
        {
            bool ret = false;
            bool ret1 = false;
            bool ret2 = false;

            HImage imageReducedRect1 = null;
            HRegion regionThreshold = null;
            HXLDCont controurStartGood = null;
            HXLDCont controurStartBad = null;
            HXLDCont controurEndGood = null;
            HXLDCont controurEndBad = null;

            try
            {
                imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(bigRegion);
                regionThreshold = imageReducedRect1.Threshold(0.0, ThresholdBig);
                HOperatorSet.AreaCenter(regionThreshold, out HTuple area, out HTuple row, out HTuple column);
                workingList.Add(new Utilities.ObjectToDisplay(bigRegion.Clone(), "green", 2) { DrawMode = "margin" });

                ret1 = area <= AreaMAxBig && area >= AreaMinBig ? true : false;
                if (invertedBlack)
                    ret1 = !ret1;

                workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret1 ? "blue" : "red", 2) { DrawMode = "fill" });
                string messageString = string.Format("Threshold nero " + linguaManager.GetTranslation($"MSG_OUT_CAM1_FOTO2_STEP_{idx}"), area, AreaMinBig, AreaMAxBig);
                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(messageString, ret1 ? "green" : "red"));

                res.StatisticheObj.AddMisura($"TEST_{idx}_CAM_1_FOTO_2", area);

                if (whiteEnabled)
                {
                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(bigRegion2);
                    regionThreshold = imageReducedRect1.Threshold(ThresholdBig2, 255.0);
                    HOperatorSet.AreaCenter(regionThreshold, out area, out row, out column);
                    workingList.Add(new Utilities.ObjectToDisplay(bigRegion2.Clone(), "green", 2) { DrawMode = "margin" });

                    ret2 = area <= AreaMAxBig2 && area >= AreaMinBig2 ? true : false;
                    if (invertedWhite)
                        ret2 = !ret2;
                    
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret2 ? "blue" : "red", 2) { DrawMode = "fill" });
                    messageString = string.Format("Threshold bianco " + linguaManager.GetTranslation($"MSG_OUT_CAM1_FOTO2_STEP_{idx}"), area, AreaMinBig2, AreaMAxBig2);
                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(messageString, ret2 ? "green" : "red"));

                    res.StatisticheObj.AddMisura($"TEST_{idx}_CAM_1_FOTO_2_W", area);
                }
                else
                {
                    ret2 = true;
                }

                ret = ret1 && ret2;

                if (idx == 5 || idx == 6 || idx == 10)
                {
                    ret = !ret;
                }

                string strOut = string.Empty;

                switch (idx)
                {
                    case 1: strOut = "DO14"; break;
                    case 2: strOut = "DO14"; break;
                    case 3: strOut = "DO13"; break;
                    case 4: strOut = "DO13"; break;
                    case 5: strOut = "DO12"; break;
                    case 6: strOut = "DO10"; break;
                    case 7: strOut = "DO10"; break;
                    case 8: strOut = "DO9"; break;
                    case 9: strOut = "DO9"; break;
                    case 10: strOut = "DO11"; break;
                }


                if (res.ResultOutput.ContainsKey(strOut))
                {
                    if (res.ResultOutput[strOut] != (ret ? 1 : 0))
                        res.ResultOutput[strOut] = 0;
                }
                else
                    res.ResultOutput.Add(strOut, (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReducedRect1?.Dispose();
                regionThreshold?.Dispose();
                controurStartGood?.Dispose();
                controurEndBad?.Dispose();
                controurStartBad?.Dispose();
                controurEndGood?.Dispose();
            }
            return ret;
        }
        
        protected bool TestCam1_Step1_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            //bool ret = false;
            //bool ret2 = false;

            //HImage imageReducedRect1 = null;
            //HRegion regionThreshold = null;
            //HXLDCont controurStartGood = null;
            //HXLDCont controurStartBad = null;
            //HXLDCont controurEndGood = null;
            //HXLDCont controurEndBad = null;

            //try
            //{
            //    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(param.bigRegion_1);

            //    regionThreshold = imageReducedRect1.Threshold(0.0, param.ThresholdBig_1);
            //    HOperatorSet.AreaCenter(regionThreshold, out HTuple area, out HTuple row, out HTuple column);

            //    workingList.Add(new Utilities.ObjectToDisplay(param.bigRegion_1.Clone(), "green", 2) { DrawMode = "margin" });
            //    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), area <= param.AreaMAxBig_1 && area >= param.AreaMinBig_1 ? "blue" : "red", 2) { DrawMode = "fill" });
            //    ret = area <= param.AreaMAxBig_1 && area >= param.AreaMinBig_1 ? true : false;
            //    if (invertedBlack)
            //        ret = !ret;
            //    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format("Threshold nero " + linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_1"), area, param.AreaMinBig_1, param.AreaMAxBig_1), ret ? "green" : "red"));

            //    res.StatisticheObj.AddMisura("TEST_1_CAM_1_FOTO_2", area);

            //    if (whiteEnabled)
            //    {
            //        imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(param.bigRegion2_1);

            //        regionThreshold = imageReducedRect1.Threshold(param.ThresholdBig2_1, 255.0);
            //        HOperatorSet.AreaCenter(regionThreshold, out area, out row, out column);

            //        workingList.Add(new Utilities.ObjectToDisplay(param.bigRegion2_1.Clone(), "green", 2) { DrawMode = "margin" });
            //        workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), area <= param.AreaMAxBig2_1 && area >= param.AreaMinBig2_1 ? "blue" : "red", 2) { DrawMode = "fill" });
            //        ret2 = area <= param.AreaMAxBig2_1 && area >= param.AreaMinBig2_1 ? true : false;
            //        if (invertedWhite)
            //            ret2 = !ret2;
            //        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format("Threshold bianco " + linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_1"), area, param.AreaMinBig2_1, param.AreaMAxBig2_1), ret2 ? "green" : "red"));

            //        res.StatisticheObj.AddMisura("TEST_1_CAM_1_FOTO_2", area);

            //        ret = ret && ret2;
            //    }

            //    if (res.ResultOutput.ContainsKey("DO14"))
            //    {
            //        if (res.ResultOutput["DO14"] != (ret ? 1 : 0))
            //            res.ResultOutput["DO14"] = 0;
            //    }
            //    else
            //        res.ResultOutput.Add("DO14", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            //}
            //catch (Exception)
            //{
            //    ret = false;
            //}
            //finally
            //{
            //    imageReducedRect1?.Dispose();
            //    regionThreshold?.Dispose();
            //    controurStartGood?.Dispose();
            //    controurEndBad?.Dispose();
            //    controurStartBad?.Dispose();
            //    controurEndGood?.Dispose();
            //}
            //return ret;
            
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_1, param.ThresholdBig_1, param.AreaMAxBig_1, param.AreaMinBig_1, param.invertedBlack1, param.checked1, param.bigRegion2_1, param.ThresholdBig2_1, param.AreaMAxBig2_1, param.AreaMinBig2_1, param.invertedWhite1, 1, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step2_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_2, param.ThresholdBig_2, param.AreaMAxBig_2, param.AreaMinBig_2, param.invertedBlack2, param.checked2, param.bigRegion2_2, param.ThresholdBig2_2, param.AreaMAxBig2_2, param.AreaMinBig2_2, param.invertedWhite2, 2, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step3_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_3, param.ThresholdBig_3, param.AreaMAxBig_3, param.AreaMinBig_3, param.invertedBlack3, param.checked3, param.bigRegion2_3, param.ThresholdBig2_3, param.AreaMAxBig2_3, param.AreaMinBig2_3, param.invertedWhite3, 3, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step4_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_4, param.ThresholdBig_4, param.AreaMAxBig_4, param.AreaMinBig_4, param.invertedBlack4, param.checked4, param.bigRegion2_4, param.ThresholdBig2_4, param.AreaMAxBig2_4, param.AreaMinBig2_4, param.invertedWhite4, 4, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step5_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_5, param.ThresholdBig_5, param.AreaMAxBig_5, param.AreaMinBig_5, param.invertedBlack5, param.checked5, param.bigRegion2_5, param.ThresholdBig2_5, param.AreaMAxBig2_5, param.AreaMinBig2_5, param.invertedWhite5, 5, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step6_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_6, param.ThresholdBig_6, param.AreaMAxBig_6, param.AreaMinBig_6, param.invertedBlack6, param.checked6, param.bigRegion2_6, param.ThresholdBig2_6, param.AreaMAxBig2_6, param.AreaMinBig2_6, param.invertedWhite6, 6, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step7_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_7, param.ThresholdBig_7, param.AreaMAxBig_7, param.AreaMinBig_7, param.invertedBlack7, param.checked7, param.bigRegion2_7, param.ThresholdBig2_7, param.AreaMAxBig2_7, param.AreaMinBig2_7, param.invertedWhite7, 7, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step8_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_8, param.ThresholdBig_8, param.AreaMAxBig_8, param.AreaMinBig_8, param.invertedBlack8, param.checked8, param.bigRegion2_8, param.ThresholdBig2_8, param.AreaMAxBig2_8, param.AreaMinBig2_8, param.invertedWhite8, 8, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step9_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_9, param.ThresholdBig_9, param.AreaMAxBig_9, param.AreaMinBig_9, param.invertedBlack9, param.checked9, param.bigRegion2_9, param.ThresholdBig2_9, param.AreaMAxBig2_9, param.AreaMinBig2_9, param.invertedWhite9, 9, isWizard, ref res, ref workingList);
        }

        protected bool TestCam1_Step10_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList, bool whiteEnabled, bool invertedBlack, bool invertedWhite)
        {
            return TestCam1_Step1_10_Foto2(inputAlg, param.bigRegion_10, param.ThresholdBig_10, param.AreaMAxBig_10, param.AreaMinBig_10, param.invertedBlack10, param.checked10, param.bigRegion2_10, param.ThresholdBig2_10, param.AreaMAxBig2_10, param.AreaMinBig2_10, param.invertedWhite10, 10, isWizard, ref res, ref workingList);
        }

        private bool AnalyzeHole(HImage image, HRegion RegionAffineTransHole, HXLDCont ContoursAffineTransHole, double thresholdGray)
        {
            bool isGood = true;

            HOperatorSet.GetContourXld(ContoursAffineTransHole, out HTuple row, out HTuple col);
            HRegion region = new HRegion();
            region.GenRegionPoints(row, col);

            HRegion regionIntersection = RegionAffineTransHole.Intersection(region);

            double areaRegion = region.Area;
            double areaintersection = regionIntersection.Area;

            if (areaintersection > 0.5 * areaRegion)
            {
                HRegion regionTrans = region.ShapeTrans("convex");
                HRegion regionDilata = region.DilationCircle(5.5);
                HRegion regionDiff = regionDilata.Difference(regionTrans);

                HRegion regionConnection = regionDiff.Connection();

                HTuple areasCenter = regionConnection.Area;

                double area1 = 0;
                double areaW = 0;

                if (areasCenter.Length > 0)
                {

                    HTuple Indices = areasCenter.TupleSortIndex();
                    Indices = Indices.TupleInverse();
                    HRegion Reg = regionConnection.SelectObj(Indices[0] + 1);
                    HImage imageReduced = image.ReduceDomain(Reg);
                    HRegion RegWhite = imageReduced.Threshold((HTuple)thresholdGray, (HTuple)255.0);
                    area1 = Reg.AreaCenter(out HTuple Row1, out HTuple Column1);
                    areaW = RegWhite.AreaCenter(out HTuple RowW, out HTuple ColumnW);
                }


                HImage ImageReducedTrans = image.ReduceDomain(regionTrans);
                HRegion RegDark = ImageReducedTrans.Threshold(0.0, 60.0);
                double areaT = regionTrans.AreaCenter(out HTuple RowT, out HTuple ColumnT);
                double areaD = RegDark.AreaCenter(out HTuple RowD, out HTuple ColumnD);

                //if (areaW > 0.45 * area1) // 0.5
                //    isGood = false;

                //if (areaD > 0.5 * areaT) // 0.7
                //    isGood = false;


                if (areaW > 0.45 * area1 && areaD > 0.5 * areaT)
                    isGood = false;
            }

            return isGood;
        }

        protected bool TestCam1_Step11_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_1)
            {
                double minScoreMatch = 0.7;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_1.Row1, param.smallRect_1.Column1, param.smallRect_1.Row2, param.smallRect_1.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });

                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_11"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO13"))
                    {
                        if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                            res.ResultOutput["DO13"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step12_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_2)
            {
                double minScoreMatch = 0.85;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_2.Row1, param.smallRect_2.Column1, param.smallRect_2.Row2, param.smallRect_2.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_12"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO13"))
                    {
                        if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                            res.ResultOutput["DO13"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step13_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_3)
            {
                double minScoreMatch = 0.85;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_3.Row1, param.smallRect_3.Column1, param.smallRect_3.Row2, param.smallRect_3.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_13"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO12"))
                    {
                        if (res.ResultOutput["DO12"] != (ret ? 1 : 0))
                            res.ResultOutput["DO12"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO12", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step14_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_4)
            {
                double minScoreMatch = 0.85;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_4.Row1, param.smallRect_4.Column1, param.smallRect_4.Row2, param.smallRect_4.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_14"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO12"))
                    {
                        if (res.ResultOutput["DO12"] != (ret ? 1 : 0))
                            res.ResultOutput["DO12"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO12", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step15_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_5)
            {
                double minScoreMatch = 0.7;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_5.Row1, param.smallRect_5.Column1, param.smallRect_5.Row2, param.smallRect_5.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_15"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO10"))
                    {
                        if (res.ResultOutput["DO10"] != (ret ? 1 : 0))
                            res.ResultOutput["DO10"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO10", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step16_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_6)
            {
                double minScoreMatch = 0.7;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_6.Row1, param.smallRect_6.Column1, param.smallRect_6.Row2, param.smallRect_6.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });

                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_16"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO10"))
                    {
                        if (res.ResultOutput["DO10"] != (ret ? 1 : 0))
                            res.ResultOutput["DO10"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO10", (ret ? ushort.Parse("1") : ushort.Parse("0")));

                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step17_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_7)
            {
                double minScoreMatch = 0.95;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_7.Row1, param.smallRect_7.Column1, param.smallRect_7.Row2, param.smallRect_7.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 170);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });

                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_17"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO9"))
                    {
                        if (res.ResultOutput["DO9"] != (ret ? 1 : 0))
                            res.ResultOutput["DO9"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO9", (ret ? ushort.Parse("1") : ushort.Parse("0")));

                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        protected bool TestCam1_Step18_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam1_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            if (param.Hole_8)
            {
                double minScoreMatch = 0.75;

                HRegion rect1 = null;
                HImage imageReducedRect1 = null;
                HXLDCont shapeModelContours = null;

                try
                {
                    rect1 = new HRegion();
                    rect1.GenRectangle1(param.smallRect_8.Row1, param.smallRect_8.Column1, param.smallRect_8.Row2, param.smallRect_8.Column2);

                    imageReducedRect1 = inputAlg.ImageRotate.ReduceDomain(rect1);

                    DataType.AllineamentoShapeParam p = new DataType.AllineamentoShapeParam();
                    FindShapeModel(imageReducedRect1, rect1, modelHole, p, out HXLDCont shapeContour, out HTuple rowShape, out HTuple columnShape, out HTuple angleShape, out HTuple scaleShape, out HTuple scoreShape);

                    shapeModelContours = modelHole.GetShapeModelContours(1);

                    if (scoreShape > minScoreMatch)
                        ret = AnalyzeHole(inputAlg.Image, imageReducedRect1, shapeContour, 120);

                    workingList.Add(new Utilities.ObjectToDisplay(rect1.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });
                    if (shapeContour != null)
                        workingList.Add(new Utilities.ObjectToDisplay(shapeContour.Clone(), ret ? "green" : "red", 2) { DrawMode = "margin" });

                    if (scoreShape.Length > 0)
                        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM1_FOTO2_STEP_18"), ret ? "OK" : "KO"), ret ? "green" : "red"));

                    if (res.ResultOutput.ContainsKey("DO11"))
                    {
                        if (res.ResultOutput["DO11"] != (ret ? 1 : 0))
                            res.ResultOutput["DO11"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO11", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
                catch (Exception)
                {
                    ret = false;
                }
                finally
                {
                    rect1?.Dispose();
                    imageReducedRect1?.Dispose();
                    shapeModelContours?.Dispose();
                }
            }
            return ret;
        }

        #endregion CAM1_FOTO2


        #region CAM2_FOTO1

        protected bool TestCam2_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam2_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam2_Step1_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam2_Step2_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam2_Step3_Foto1(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;

        }

        protected bool TestCam2_Step1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam2_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;
            HXLDCont controurStartGood = null;
            HXLDCont controurStartBad = null;
            HXLDCont controurEndGood = null;
            HXLDCont controurEndBad = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectPin.Row1, param.RectPin.Column1, param.RectPin.Row2, param.RectPin.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(0, param.ThresholdPin);
                    GetRegionRuns(regionThreshold, out HTuple row, out HTuple columnBegin, out HTuple columnEnd);

                    HTuple dist = columnEnd - columnBegin;
                    double distMaxPX = CalibraFrom_mmToPx(param.DistMax);
                    HTuple overMax = dist.TupleGreaterElem(distMaxPX);
                    HTuple belowMax = dist.TupleLessEqualElem(distMaxPX);
                    HTuple idx = HTuple.TupleGenSequence(0, row.Length - 1, 1);
                    HTuple listIdxBad = idx.TupleSelectMask(overMax);
                    HTuple listIdxGood = idx.TupleSelectMask(belowMax);

                    HTuple rowGood = row.TupleSelect(listIdxGood);
                    HTuple rowBad = row.TupleSelect(listIdxBad);
                    HTuple columnBeginGood = columnBegin.TupleSelect(listIdxGood);
                    HTuple columnBeginBad = columnBegin.TupleSelect(listIdxBad);
                    HTuple columnEndGood = columnEnd.TupleSelect(listIdxGood);
                    HTuple columnEndBad = columnEnd.TupleSelect(listIdxBad);


                    controurStartGood = new HXLDCont();
                    controurStartGood.GenCrossContourXld(rowGood, columnBeginGood, 5, 0);

                    controurEndGood = new HXLDCont();
                    controurEndGood.GenCrossContourXld(rowGood, columnEndGood, 5, 0);

                    controurStartBad = new HXLDCont();
                    controurStartBad.GenCrossContourXld(rowBad, columnBeginBad, 5, 0);

                    controurEndBad = new HXLDCont();
                    controurEndBad.GenCrossContourXld(rowBad, columnEndBad, 5, 0);

                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), GetColorTrasparenza(Color.Red), 2) { DrawMode = "fill" });
                    workingList.Add(new Utilities.ObjectToDisplay(controurStartGood.Clone(), "green", 2) { DrawMode = "fill" });
                    workingList.Add(new Utilities.ObjectToDisplay(controurEndGood.Clone(), "green", 2) { DrawMode = "fill" });
                    workingList.Add(new Utilities.ObjectToDisplay(controurStartBad.Clone(), "red", 2) { DrawMode = "fill" });
                    workingList.Add(new Utilities.ObjectToDisplay(controurEndBad.Clone(), "red", 2) { DrawMode = "fill" });

                    ret = rowBad.Length <= 2 ? true : false;
                    HTuple goodSorted = (columnEndGood - columnBeginGood).TupleSort();
                    HTuple badSorted = (columnEndBad - columnBeginBad).TupleSort();
                    double valueToShow = ret ? CalibraFromPxTo_mm(goodSorted[goodSorted.Length - 1]) : CalibraFromPxTo_mm(badSorted[badSorted.Length - 1]);

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM2_FOTO1_STEP1"), valueToShow, param.DistMax), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_1_CAM_2_FOTO_1", valueToShow);

                    if (res.ResultOutput.ContainsKey("DO15"))
                    {
                        if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                            res.ResultOutput.Add("DO15", 0);
                    }
                    else
                        res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                controurStartGood?.Dispose();
                controurEndBad?.Dispose();
                controurStartBad?.Dispose();
                controurEndGood?.Dispose();
            }
            return ret;
        }

        protected bool TestCam2_Step2_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam2_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlackLeft.Row1, param.RectBlackLeft.Column1, param.RectBlackLeft.Row2, param.RectBlackLeft.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(0, param.ThresholdLeft);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm2(area);
                    ret = valueToShow <= param.AreaMaxLeft ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(imageReduced.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), GetColorTrasparenza(Color.Red), 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM2_FOTO1_STEP2"), valueToShow, param.AreaMaxLeft), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_2_CAM_2_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO15"))
                    {
                        if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                            res.ResultOutput["DO15"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();

            }
            return ret;
        }

        protected bool TestCam2_Step3_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam2_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlackRight.Row1, param.RectBlackRight.Column1, param.RectBlackRight.Row2, param.RectBlackRight.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(0, param.ThresholdRight);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm2(area);
                    ret = valueToShow <= param.AreaMaxRight ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(imageReduced.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), GetColorTrasparenza(Color.Red), 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM2_FOTO1_STEP3"), valueToShow, param.AreaMaxRight), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_3_CAM_2_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO15"))
                    {
                        if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                            res.ResultOutput["DO15"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();

            }
            return ret;
        }

        private void GetRegionRuns(HRegion region, out HTuple row, out HTuple columnBegin, out HTuple columnEnd)
        {
            HTuple rowTmp;
            HTuple columnBeginTmp;
            HTuple columnEndTmp;

            region.GetRegionRuns(out rowTmp, out columnBeginTmp, out columnEndTmp);

            row = new HTuple();
            columnBegin = new HTuple();
            columnEnd = new HTuple();

            int cnt = rowTmp.TupleLength();

            if (cnt > 0)
            {
                int rowStart = rowTmp.TupleSelect(0);
                long prevRow = -1;

                for (int i = 0; i < cnt; i++)
                {
                    if (prevRow == rowTmp.TupleSelect(i).L)
                    {
                        int cntTmp = row.TupleLength();

                        if (columnBegin.TupleSelect(cntTmp - 1) > columnBeginTmp.TupleSelect(i))
                        {
                            columnBegin[cntTmp - 1] = (double)columnBeginTmp.TupleSelect(i);
                        }

                        if (columnEnd.TupleSelect(cntTmp - 1) < columnEndTmp.TupleSelect(i))
                        {
                            columnEnd[cntTmp - 1] = (double)columnEndTmp.TupleSelect(i);
                        }
                    }
                    else
                    {
                        row = row.TupleConcat((double)rowTmp.TupleSelect(i));
                        columnBegin = columnBegin.TupleConcat((double)columnBeginTmp.TupleSelect(i));
                        columnEnd = columnEnd.TupleConcat((double)columnEndTmp.TupleSelect(i));
                    }

                    prevRow = rowTmp.TupleSelect(i).L;
                }
            }
        }

        #endregion CAM2_FOTO1


        #region CAM3_FOTO1

        protected bool TestCam3_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam3_Step1_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_6 = TestCam3_Step6_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam3_Step2_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam3_Step3_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_4 = TestCam3_Step4_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_5 = TestCam3_Step5_Foto1(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3 && okStep_4 && okStep_5 && okStep_6;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;

        }

        protected bool TestCam3_Step1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            HXLDCont controur = null;

            try
            {
                FindEdgeRect2(inputAlg.ImageRotate, param.RectRif_1.Row, param.RectRif_1.Column, param.RectRif_1.Angle, param.RectRif_1.Length1, param.RectRif_1.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                double media = 0;

                if (edgeRow.Length > 0)
                {
                    for (int i = 0; i < edgeRow.Length; i++)
                    {
                        media += edgeRow[i];
                    }
                    media = media / edgeRow.Length;
                }
                param.RifRow_1 = media;

                media = 0;
                if (edgeCol.Length > 0)
                {
                    for (int i = 0; i < edgeCol.Length; i++)
                    {
                        media += edgeCol[i];
                    }
                    media = media / edgeCol.Length;
                }
                param.RifCol_1 = media;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);


                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step2_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;
            HXLDCont controurLeft = null;
            HXLDCont controurRight = null;

            try
            {
                regionMain = new HRegion();
                regionMain.GenRectangle2(param.RectCalipper_1.Row, param.RectCalipper_1.Column, 0.0, param.RectCalipper_1.Length1, param.RectCalipper_1.Length2);
                imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                Calliper(inputAlg.ImageRotate, param.RectCalipper_1.Row, param.RectCalipper_1.Column, 0.0, param.RectCalipper_1.Length1, param.RectCalipper_1.Length2, 10, 5, out HTuple edgeRowFirst, out HTuple edgeColFirst, out HTuple edgeRowSecond, out HTuple edgeColSecond, out HTuple distance);

                double distMinPX = CalibraFrom_mmToPx(param.DistMin_Calipper_1);
                double distMaxPX = CalibraFrom_mmToPx(param.DistMax_Calipper_1);

                double media = 0;

                if (distance.Length > 0)
                {
                    for (int i = 0; i < distance.Length; i++)
                    {
                        media += distance[i];
                    }
                    media = media / distance.Length;
                }

                double valueToShow1 = CalibraFromPxTo_mm(media);

                ret = valueToShow1 <= param.DistMax_Calipper_1 && valueToShow1 >= param.DistMin_Calipper_1 ? true : false;

                controurLeft = new HXLDCont();
                controurLeft.GenCrossContourXld(edgeRowFirst, edgeColFirst, 20, 0);

                controurRight = new HXLDCont();
                controurRight.GenCrossContourXld(edgeRowSecond, edgeColSecond, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controurLeft.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
                workingList.Add(new Utilities.ObjectToDisplay(controurRight.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO1_STEP_1"), valueToShow1, param.DistMin_Calipper_1, param.DistMax_Calipper_1), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_1_CAM_3_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionMain?.Dispose();
                imageReduced?.Dispose();
                regionThreshold?.Dispose();

                controurLeft?.Dispose();
                controurRight?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step3_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HXLDCont controur = null;
            HHomMat2D mat = null;
            HRegion lineRef = null;
            HRegion lineH = null;
            HRegion lineV = null;

            try
            {
                mat = new HHomMat2D();
                lineRef = new HRegion();
                lineH = new HRegion();
                lineV = new HRegion();

                FindEdgeRect2(inputAlg.ImageRotate, param.RectHeight_1.Row, param.RectHeight_1.Column, param.RectHeight_1.Angle, param.RectHeight_1.Length1, param.RectHeight_1.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                HTuple mediaRow = edgeRow.TupleMedian();
                HTuple mediaCol = edgeCol.TupleMedian();
                HTuple mediaRowLine = (param.RifRow_1 + param.RifRow_2) / 2;
                HTuple mediaColLine = (param.RifCol_1 + param.RifCol_2) / 2;

                lineRef.GenRegionLine(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2);
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "red", 2) { DrawMode = "fill" });

                HOperatorSet.AngleLx(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2, out HTuple angle);
                mat = mat.HomMat2dRotate(-(double)angle, (double)mediaColLine, (double)mediaRowLine);

                lineRef = lineRef.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "blue", 2) { DrawMode = "fill" });

                lineH.GenRegionLine(mediaRow, mediaColLine, mediaRowLine, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "red", 2) { DrawMode = "fill" });

                lineV.GenRegionLine(mediaRow, mediaCol, mediaRow, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "red", 2) { DrawMode = "fill" });

                lineH = lineH.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "blue", 2) { DrawMode = "fill" });

                lineV = lineV.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "blue", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(lineRef.Row - lineV.Row);

                ret = valueToShow1 <= param.DistMax_Height_1 && valueToShow1 >= param.DistMin_Height_1 ? true : false;


                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);
                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO1_STEP_2"), valueToShow1, param.DistMin_Height_1, param.DistMax_Height_1), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_2_CAM_3_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO13"))
                {
                    if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                        res.ResultOutput["DO13"] = 0;
                }
                else
                    res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
                lineRef?.Dispose();
                lineH?.Dispose();
                lineV?.Dispose();

            }
            return ret;
        }

        protected bool TestCam3_Step4_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HXLDCont controur = null;
            HHomMat2D mat = null;
            HRegion lineRef = null;
            HRegion lineH = null;
            HRegion lineV = null;

            try
            {
                mat = new HHomMat2D();
                lineRef = new HRegion();
                lineH = new HRegion();
                lineV = new HRegion();

                FindEdgeRect2(inputAlg.ImageRotate, param.RectHeight_2.Row, param.RectHeight_2.Column, param.RectHeight_2.Angle, param.RectHeight_2.Length1, param.RectHeight_2.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                HTuple mediaRow = edgeRow.TupleMedian();
                HTuple mediaCol = edgeCol.TupleMedian();
                HTuple mediaRowLine = (param.RifRow_1 + param.RifRow_2) / 2;
                HTuple mediaColLine = (param.RifCol_1 + param.RifCol_2) / 2;

                lineRef.GenRegionLine(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2);
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "red", 2) { DrawMode = "fill" });

                HOperatorSet.AngleLx(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2, out HTuple angle);
                mat = mat.HomMat2dRotate(-(double)angle, (double)mediaColLine, (double)mediaRowLine);

                lineRef = lineRef.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "blue", 2) { DrawMode = "fill" });

                lineH.GenRegionLine(mediaRow, mediaColLine, mediaRowLine, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "red", 2) { DrawMode = "fill" });

                lineV.GenRegionLine(mediaRow, mediaCol, mediaRow, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "red", 2) { DrawMode = "fill" });

                lineH = lineH.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "blue", 2) { DrawMode = "fill" });

                lineV = lineV.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "blue", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(lineRef.Row - lineV.Row);

                ret = valueToShow1 <= param.DistMax_Height_2 && valueToShow1 >= param.DistMin_Height_2 ? true : false;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO1_STEP_3"), valueToShow1, param.DistMin_Height_2, param.DistMax_Height_2), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_3_CAM_3_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO14"))
                {
                    if (res.ResultOutput["DO14"] != (ret ? 1 : 0))
                        res.ResultOutput["DO14"] = 0;
                }
                else
                    res.ResultOutput.Add("DO14", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
                lineRef?.Dispose();
                lineH?.Dispose();
                lineV?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step5_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;
            HXLDCont controurLeft = null;
            HXLDCont controurRight = null;

            try
            {
                regionMain = new HRegion();
                regionMain.GenRectangle2(param.RectCalipper_2.Row, param.RectCalipper_2.Column, 0.0, param.RectCalipper_2.Length1, param.RectCalipper_2.Length2);
                imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);
                Calliper(inputAlg.ImageRotate, param.RectCalipper_2.Row, param.RectCalipper_2.Column, 0.0, param.RectCalipper_2.Length1, param.RectCalipper_2.Length2, 10, 5, out HTuple edgeRowFirst, out HTuple edgeColFirst, out HTuple edgeRowSecond, out HTuple edgeColSecond, out HTuple distance);

                double distMinPX = CalibraFrom_mmToPx(param.DistMin_Calipper_2);
                double distMaxPX = CalibraFrom_mmToPx(param.DistMax_Calipper_2);

                double media = 0;

                if (distance.Length > 0)
                {
                    for (int i = 0; i < distance.Length; i++)
                    {
                        media += distance[i];
                    }
                    media = media / distance.Length;
                }


                double valueToShow1 = CalibraFromPxTo_mm(media);

                ret = valueToShow1 <= param.DistMax_Calipper_2 && valueToShow1 >= param.DistMin_Calipper_2 ? true : false;

                controurLeft = new HXLDCont();
                controurLeft.GenCrossContourXld(edgeRowFirst, edgeColFirst, 20, 0);

                controurRight = new HXLDCont();
                controurRight.GenCrossContourXld(edgeRowSecond, edgeColSecond, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controurLeft.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
                workingList.Add(new Utilities.ObjectToDisplay(controurRight.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO1_STEP_4"), valueToShow1, param.DistMin_Calipper_2, param.DistMax_Calipper_2), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_4_CAM_3_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionMain?.Dispose();
                imageReduced?.Dispose();
                regionThreshold?.Dispose();

                controurLeft?.Dispose();
                controurRight?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step6_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            HXLDCont controur = null;

            try
            {
                FindEdgeRect2(inputAlg.ImageRotate, param.RectRif_2.Row, param.RectRif_2.Column, param.RectRif_2.Angle, param.RectRif_2.Length1, param.RectRif_2.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                double media = 0;

                if (edgeRow.Length > 0)
                {
                    for (int i = 0; i < edgeRow.Length; i++)
                    {
                        media += edgeRow[i];
                    }
                    media = media / edgeRow.Length;
                }
                param.RifRow_2 = media;

                media = 0;
                if (edgeCol.Length > 0)
                {
                    for (int i = 0; i < edgeCol.Length; i++)
                    {
                        media += edgeCol[i];
                    }
                    media = media / edgeCol.Length;
                }
                param.RifCol_2 = media;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
            }
            return ret;
        }

        private void FindEdgeRect2(HImage image, HTuple row, HTuple column, HTuple rad, HTuple length1, HTuple length2, HTuple numMisure, HTuple dimMisura, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance)
        {
            image.GetImageSize(out HTuple Width, out HTuple Height);
            double delta = (length2 * 2 - dimMisura * 2) / (numMisure - 1);

            edgeRow = new HTuple();
            edgeCol = new HTuple();
            distance = new HTuple();

            for (int i = 0; i < numMisure; i++)
            {
                double p = -length2 + (delta * (i - 1)) + dimMisura;

                HHomMat2D hHomMat2D = new HHomMat2D();
                hHomMat2D.HomMat2dIdentity();
                hHomMat2D = hHomMat2D.HomMat2dTranslate(0.0, p);
                hHomMat2D = hHomMat2D.HomMat2dRotate(-rad, column, row);

                HTuple Qx = hHomMat2D.AffineTransPoint2d(column, row, out HTuple Qy);
                HOperatorSet.GenMeasureRectangle2(Qy, Qx, rad, length1, dimMisura, Width, Height, "nearest_neighbor", out HTuple measureHandler);

                HOperatorSet.MeasurePos(image, measureHandler, 1, 30, "negative", "first", out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple dist);
                if (rowEdge.Length == 1)
                {
                    edgeRow = edgeRow.TupleConcat(rowEdge);
                    edgeCol = edgeCol.TupleConcat(columnEdge);
                    distance = distance.TupleConcat(dist);
                }
            }
        }

        #endregion CAM3_FOTO1


        #region CAM3_FOTO2

        protected bool TestCam3_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam3_Step1_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_5 = TestCam3_Step5_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam3_Step2_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam3_Step3_Foto2(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_4 = TestCam3_Step4_Foto2(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3 && okStep_4 && okStep_5;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;
        }

        protected bool TestCam3_Step1_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            HXLDCont controur = null;

            try
            {
                FindEdgeRect2(inputAlg.ImageRotate, param.RectRif_1.Row, param.RectRif_1.Column, param.RectRif_1.Angle, param.RectRif_1.Length1, param.RectRif_1.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                double media = 0;

                if (edgeRow.Length > 0)
                {
                    for (int i = 0; i < edgeRow.Length; i++)
                    {
                        media += edgeRow[i];
                    }
                    media = media / edgeRow.Length;
                }
                param.RifRow_1 = media;

                media = 0;
                if (edgeCol.Length > 0)
                {
                    for (int i = 0; i < edgeCol.Length; i++)
                    {
                        media += edgeCol[i];
                    }
                    media = media / edgeCol.Length;
                }
                param.RifCol_1 = media;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);


                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step2_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HXLDCont controur = null;
            HHomMat2D mat = null;
            HRegion lineRef = null;
            HRegion lineH = null;
            HRegion lineV = null;

            try
            {
                mat = new HHomMat2D();
                lineRef = new HRegion();
                lineH = new HRegion();
                lineV = new HRegion();

                FindEdgeRect2(inputAlg.ImageRotate, param.RectHeight_1.Row, param.RectHeight_1.Column, param.RectHeight_1.Angle, param.RectHeight_1.Length1, param.RectHeight_1.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                HTuple mediaRow = edgeRow.TupleMedian();
                HTuple mediaCol = edgeCol.TupleMedian();
                HTuple mediaRowLine = (param.RifRow_1 + param.RifRow_2) / 2;
                HTuple mediaColLine = (param.RifCol_1 + param.RifCol_2) / 2;

                lineRef.GenRegionLine(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2);
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "red", 2) { DrawMode = "fill" });

                HOperatorSet.AngleLx(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2, out HTuple angle);
                mat = mat.HomMat2dRotate(-(double)angle, (double)mediaColLine, (double)mediaRowLine);

                lineRef = lineRef.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "blue", 2) { DrawMode = "fill" });

                lineH.GenRegionLine(mediaRow, mediaColLine, mediaRowLine, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "red", 2) { DrawMode = "fill" });

                lineV.GenRegionLine(mediaRow, mediaCol, mediaRow, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "red", 2) { DrawMode = "fill" });

                lineH = lineH.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "blue", 2) { DrawMode = "fill" });

                lineV = lineV.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "blue", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(lineRef.Row - lineV.Row);

                ret = valueToShow1 <= param.DistMax_Height_1 && valueToShow1 >= param.DistMin_Height_1 ? true : false;

                res.StatisticheObj.AddMisura("DISTMIN_HEIGHT_1", valueToShow1);

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);
                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO2_STEP_1"), valueToShow1, param.DistMin_Height_1, param.DistMax_Height_1), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_1_CAM_3_FOTO_2", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO13"))
                {
                    if (res.ResultOutput["DO13"] != (ret ? 1 : 0))
                        res.ResultOutput["DO13"] = 0;
                }
                else
                    res.ResultOutput.Add("DO13", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
                lineRef?.Dispose();
                lineH?.Dispose();
                lineV?.Dispose();

            }
            return ret;
        }

        protected bool TestCam3_Step3_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HXLDCont controur = null;
            HHomMat2D mat = null;
            HRegion lineRef = null;
            HRegion lineH = null;
            HRegion lineV = null;

            try
            {
                mat = new HHomMat2D();
                lineRef = new HRegion();
                lineH = new HRegion();
                lineV = new HRegion();

                FindEdgeRect2(inputAlg.ImageRotate, param.RectHeight_2.Row, param.RectHeight_2.Column, param.RectHeight_2.Angle, param.RectHeight_2.Length1, param.RectHeight_2.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                HTuple mediaRow = edgeRow.TupleMedian();
                HTuple mediaCol = edgeCol.TupleMedian();
                HTuple mediaRowLine = (param.RifRow_1 + param.RifRow_2) / 2;
                HTuple mediaColLine = (param.RifCol_1 + param.RifCol_2) / 2;

                lineRef.GenRegionLine(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2);
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "red", 2) { DrawMode = "fill" });

                HOperatorSet.AngleLx(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2, out HTuple angle);
                mat = mat.HomMat2dRotate(-(double)angle, (double)mediaColLine, (double)mediaRowLine);

                lineRef = lineRef.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "blue", 2) { DrawMode = "fill" });

                lineH.GenRegionLine(mediaRow, mediaColLine, mediaRowLine, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "red", 2) { DrawMode = "fill" });

                lineV.GenRegionLine(mediaRow, mediaCol, mediaRow, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "red", 2) { DrawMode = "fill" });

                lineH = lineH.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "blue", 2) { DrawMode = "fill" });

                lineV = lineV.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "blue", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(lineRef.Row - lineV.Row);

                ret = valueToShow1 <= param.DistMax_Height_2 && valueToShow1 >= param.DistMin_Height_2 ? true : false;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO2_STEP_2"), valueToShow1, param.DistMin_Height_2, param.DistMax_Height_2), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_2_CAM_3_FOTO_2", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
                lineRef?.Dispose();
                lineH?.Dispose();
                lineV?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step4_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HXLDCont controur = null;
            HHomMat2D mat = null;
            HRegion lineRef = null;
            HRegion lineH = null;
            HRegion lineV = null;

            try
            {
                mat = new HHomMat2D();
                lineRef = new HRegion();
                lineH = new HRegion();
                lineV = new HRegion();

                FindEdgeRect2(inputAlg.ImageRotate, param.RectHeight_3.Row, param.RectHeight_3.Column, param.RectHeight_3.Angle, param.RectHeight_3.Length1, param.RectHeight_3.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                HTuple mediaRow = edgeRow.TupleMedian();
                HTuple mediaCol = edgeCol.TupleMedian();
                HTuple mediaRowLine = (param.RifRow_1 + param.RifRow_2) / 2;
                HTuple mediaColLine = (param.RifCol_1 + param.RifCol_2) / 2;

                lineRef.GenRegionLine(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2);
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "red", 2) { DrawMode = "fill" });

                HOperatorSet.AngleLx(param.RifRow_1, param.RifCol_1, param.RifRow_2, param.RifCol_2, out HTuple angle);
                mat = mat.HomMat2dRotate(-(double)angle, (double)mediaColLine, (double)mediaRowLine);

                lineRef = lineRef.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineRef.Clone(), "blue", 2) { DrawMode = "fill" });

                lineH.GenRegionLine(mediaRow, mediaColLine, mediaRowLine, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "red", 2) { DrawMode = "fill" });

                lineV.GenRegionLine(mediaRow, mediaCol, mediaRow, mediaColLine);
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "red", 2) { DrawMode = "fill" });

                lineH = lineH.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineH.Clone(), "blue", 2) { DrawMode = "fill" });

                lineV = lineV.AffineTransRegion(mat, "nearest_neighbor");
                workingList.Add(new Utilities.ObjectToDisplay(lineV.Clone(), "blue", 2) { DrawMode = "fill" });

                double valueToShow1 = CalibraFromPxTo_mm(lineRef.Row - lineV.Row);

                ret = valueToShow1 <= param.DistMax_Height_3 && valueToShow1 >= param.DistMin_Height_3 ? true : false;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM3_FOTO2_STEP_3"), valueToShow1, param.DistMin_Height_3, param.DistMax_Height_3), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_3_CAM_3_FOTO_2", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO14"))
                {
                    if (res.ResultOutput["DO14"] != (ret ? 1 : 0))
                        res.ResultOutput["DO14"] = 0;
                }
                else
                    res.ResultOutput.Add("DO14", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
                lineRef?.Dispose();
                lineH?.Dispose();
                lineV?.Dispose();
            }
            return ret;
        }

        protected bool TestCam3_Step5_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam3_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            HXLDCont controur = null;

            try
            {
                FindEdgeRect2(inputAlg.ImageRotate, param.RectRif_2.Row, param.RectRif_2.Column, param.RectRif_2.Angle, param.RectRif_2.Length1, param.RectRif_2.Length2, 10, 5, out HTuple edgeRow, out HTuple edgeCol, out HTuple distance);

                double media = 0;

                if (edgeRow.Length > 0)
                {
                    for (int i = 0; i < edgeRow.Length; i++)
                    {
                        media += edgeRow[i];
                    }
                    media = media / edgeRow.Length;
                }
                param.RifRow_2 = media;

                media = 0;
                if (edgeCol.Length > 0)
                {
                    for (int i = 0; i < edgeCol.Length; i++)
                    {
                        media += edgeCol[i];
                    }
                    media = media / edgeCol.Length;
                }
                param.RifCol_2 = media;

                controur = new HXLDCont();
                controur.GenCrossContourXld(edgeRow, edgeCol, 20, 0);

                workingList.Add(new Utilities.ObjectToDisplay(controur.Clone(), ret ? "green" : "red", 2) { DrawMode = "fill" });
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                controur?.Dispose();
            }
            return ret;
        }

        #endregion CAM3_FOTO2


        #region CAM4_FOTO1

        protected bool TestCam4_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam4_Step1_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_2 = TestCam4_Step2_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_3 = TestCam4_Step3_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_4 = TestCam4_Step4_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_5 = TestCam4_Step5_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_6 = TestCam4_Step6_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_7 = TestCam4_Step7_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_8 = TestCam4_Step8_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_9 = TestCam4_Step9_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_10 = TestCam4_Step10_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_11 = TestCam4_Step11_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_12 = TestCam4_Step12_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_13 = TestCam4_Step13_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_14 = TestCam4_Step14_Foto1(inputAlg, param, isWizard, ref res, ref workingList);
                    bool okStep_15 = TestCam4_Step15_Foto1(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1 && okStep_2 && okStep_3 && okStep_4 && okStep_5 && okStep_6 && okStep_7 && okStep_8 && okStep_9 && okStep_10 && okStep_11 && okStep_12 && okStep_13 && okStep_14 && okStep_15;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;
        }

        protected bool TestCam4_Step1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle = new HRegion();
                regionCircle.GenCircle(param.CircleCenter.Row, param.CircleCenter.Column, param.CircleCenter.Radius);

                imageReducedCircle1 = inputAlg.ImageRotateGray.ReduceDomain(regionCircle);

                regionThresholdCircle1 = imageReducedCircle1.Threshold(param.ThresholdCircleCenter, 255);

                double areaCircle1 = regionThresholdCircle1.Area;

                double valueToShow1 = CalibraFromPxTo_mm(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircleCenter ? true : false;

                workingList.Add(new Utilities.ObjectToDisplay(regionCircle.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP1"), valueToShow1, param.AreaMaxCircleCenter), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_1_CAM_4_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));

            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam4_Step2_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectGrayLeft.Row1, param.RectGrayLeft.Column1, param.RectGrayLeft.Row2, param.RectGrayLeft.Column2);

                    imageReduced = inputAlg.ImageRotateGray.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(param.ThresholdGrayLeft, 255);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);
                    ret = valueToShow >= param.AreaMinGrayLeft ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP2"), valueToShow, param.AreaMinGrayLeft), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_2_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO10"))
                    {
                        if (res.ResultOutput["DO10"] != (ret ? 1 : 0))
                            res.ResultOutput["DO10"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO10", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                regionMain?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step3_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectGrayRight.Row1, param.RectGrayRight.Column1, param.RectGrayRight.Row2, param.RectGrayRight.Column2);

                    imageReduced = inputAlg.ImageRotateGray.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(param.ThresholdGrayRight, 255);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);
                    ret = valueToShow >= param.AreaMinGrayRight ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP3"), valueToShow, param.AreaMinGrayRight), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_3_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO10"))
                    {
                        if (res.ResultOutput["DO10"] != (ret ? 1 : 0))
                            res.ResultOutput["DO10"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO10", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                regionMain?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step4_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueLeft.Row1, param.RectBlueLeft.Column1, param.RectBlueLeft.Row2, param.RectBlueLeft.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxBlueLeft ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP4"), valueToShow, param.AreaMaxBlueLeft), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_4_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO8"))
                    {
                        if (res.ResultOutput["DO8"] != (ret ? 1 : 0))
                            res.ResultOutput["DO8"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO8", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step5_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueRight.Row1, param.RectBlueRight.Column1, param.RectBlueRight.Row2, param.RectBlueRight.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueRight.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxBlueRight ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP5"), valueToShow, param.AreaMaxBlueRight), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_5_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO7"))
                    {
                        if (res.ResultOutput["DO7"] != (ret ? 1 : 0))
                            res.ResultOutput["DO7"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO7", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step6_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectYellowRight.Row1, param.RectYellowRight.Column1, param.RectYellowRight.Row2, param.RectYellowRight.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxYellowRight ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP6"), valueToShow, param.AreaMaxYellowRight), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_6_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO8"))
                    {
                        if (res.ResultOutput["DO8"] != (ret ? 1 : 0))
                            res.ResultOutput["DO8"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO8", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step7_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle = new HRegion();
                regionCircle.GenCircle(param.CircleYellowCenter.Row, param.CircleYellowCenter.Column, param.CircleYellowCenter.Radius);

                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle);

                regionThresholdCircle1 = lutYellowCenter.ClassifyImageClassLut(imageReducedCircle1);
                regionThresholdCircle1 = regionThresholdCircle1.ErosionCircle((HTuple)3);
                regionThresholdCircle1 = regionThresholdCircle1.DilationCircle((HTuple)10);

                double areaCircle1 = regionThresholdCircle1.Area;

                double valueToShow1 = CalibraFromPxTo_mm(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxCircleCenter ? true : false;

                workingList.Add(new Utilities.ObjectToDisplay(regionCircle.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP7"), valueToShow1, param.AreaMaxCircleCenter), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_7_CAM_4_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));

            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        protected bool TestCam4_Step8_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueLeft2.Row1, param.RectBlueLeft2.Column1, param.RectBlueLeft2.Row2, param.RectBlueLeft2.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow >= param.AreaMaxBlueLeft2 ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP8"), valueToShow, param.AreaMaxBlueLeft2), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_8_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO8"))
                    {
                        if (res.ResultOutput["DO8"] != (ret ? 1 : 0))
                            res.ResultOutput["DO8"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO8", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step9_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueRight2.Row1, param.RectBlueRight2.Column1, param.RectBlueRight2.Row2, param.RectBlueRight2.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueRight.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow >= param.AreaMaxBlueRight2 ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP9"), valueToShow, param.AreaMaxBlueRight2), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_9_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO7"))
                    {
                        if (res.ResultOutput["DO7"] != (ret ? 1 : 0))
                            res.ResultOutput["DO7"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO7", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step10_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueUp.Row1, param.RectBlueUp.Column1, param.RectBlueUp.Row2, param.RectBlueUp.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxBlueUp ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP10"), valueToShow, param.AreaMaxBlueUp), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_10_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO8"))
                    {
                        if (res.ResultOutput["DO8"] != (ret ? 1 : 0))
                            res.ResultOutput["DO8"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO8", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step11_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueLeft3.Row1, param.RectBlueLeft3.Column1, param.RectBlueLeft3.Row2, param.RectBlueLeft3.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow >= param.AreaMaxBlueLeft3 ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP11"), valueToShow, param.AreaMaxBlueLeft3), ret ? "green" : "red"));

                    res.StatisticheObj.AddMisura("TEST_11_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO9"))
                    {
                        if (res.ResultOutput["DO9"] != (ret ? 1 : 0))
                            res.ResultOutput["DO9"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO9", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step12_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectBlueLeft4.Row1, param.RectBlueLeft4.Column1, param.RectBlueLeft4.Row2, param.RectBlueLeft4.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutBlueLeft.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxBlueLeft4 ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP12"), valueToShow, param.AreaMaxBlueLeft4), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_12_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO7"))
                    {
                        if (res.ResultOutput["DO7"] != (ret ? 1 : 0))
                            res.ResultOutput["DO7"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO7", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step13_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectRedLeft.Row1, param.RectRedLeft.Column1, param.RectRedLeft.Row2, param.RectRedLeft.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutYellowCenter.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxRedLeft ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP13"), valueToShow, param.AreaMaxRedLeft), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_13_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO12"))
                    {
                        if (res.ResultOutput["DO12"] != (ret ? 1 : 0))
                            res.ResultOutput["DO12"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO12", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step14_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HRegion regionThreshold = null;
            HImage imageReduced = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.RectRedRight.Row1, param.RectRedRight.Column1, param.RectRedRight.Row2, param.RectRedRight.Column2);

                    imageReduced = inputAlg.ImageRotate.ReduceDomain(regionMain);

                    regionThreshold = new HRegion();
                    regionThreshold = lutYellowCenter.ClassifyImageClassLut(imageReduced);
                    regionThreshold = regionThreshold.ErosionCircle((HTuple)3);
                    regionThreshold = regionThreshold.DilationCircle((HTuple)10);

                    double area = regionThreshold.Area;
                    double valueToShow = CalibraFromPxTo_mm(area);

                    ret = valueToShow <= param.AreaMaxRedRight ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP14"), valueToShow, param.AreaMaxRedRight), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_14_CAM_4_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO12"))
                    {
                        if (res.ResultOutput["DO12"] != (ret ? 1 : 0))
                            res.ResultOutput["DO12"] = 0;
                    }
                    else
                        res.ResultOutput.Add("DO12", (ret ? ushort.Parse("1") : ushort.Parse("0")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionMain?.Dispose();
                regionThreshold?.Dispose();
            }
            return ret;
        }

        protected bool TestCam4_Step15_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam4_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionCircle = null;
            HImage imageReducedCircle1 = null;
            HRegion regionThresholdCircle1 = null;

            try
            {
                regionCircle = new HRegion();
                regionCircle.GenCircle(param.CircleBlueCenter.Row, param.CircleBlueCenter.Column, param.CircleBlueCenter.Radius);

                imageReducedCircle1 = inputAlg.ImageRotate.ReduceDomain(regionCircle);

                regionThresholdCircle1 = lutBlueLeft.ClassifyImageClassLut(imageReducedCircle1);
                regionThresholdCircle1 = regionThresholdCircle1.ErosionCircle((HTuple)3);
                regionThresholdCircle1 = regionThresholdCircle1.DilationCircle((HTuple)10);

                double areaCircle1 = regionThresholdCircle1.Area;

                double valueToShow1 = CalibraFromPxTo_mm(areaCircle1);
                ret = valueToShow1 <= param.AreaMaxBlueCenter ? true : false;
                workingList.Add(new Utilities.ObjectToDisplay(regionCircle.Clone(), "green", 2) { DrawMode = "margin" });
                workingList.Add(new Utilities.ObjectToDisplay(regionThresholdCircle1.Clone(), ret ? "blue" : "red", 2) { DrawMode = "fill" });

                res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP7"), valueToShow1, param.AreaMaxBlueCenter), ret ? "green" : "red"));
                res.StatisticheObj.AddMisura("TEST_7_CAM_4_FOTO_1", valueToShow1);
                if (res.ResultOutput.ContainsKey("DO15"))
                {
                    if (res.ResultOutput["DO15"] != (ret ? 1 : 0))
                        res.ResultOutput["DO15"] = 0;
                }
                else
                    res.ResultOutput.Add("DO15", (ret ? ushort.Parse("1") : ushort.Parse("0")));
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                regionCircle?.Dispose();
                imageReducedCircle1?.Dispose();
                regionThresholdCircle1?.Dispose();

            }
            return ret;
        }

        #endregion CAM4_FOTO1


        #region CAM5_FOTO1

        protected bool TestCam5_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam5_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam5_Step1_Foto1(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;
        }

        protected bool TestCam5_Step1_Foto1(ClassInputAlgoritmi inputAlg, DataType.Cam5_Foto1Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.Roi.Row1, param.Roi.Column1, param.Roi.Row2, param.Roi.Column2);

                    imageReduced = inputAlg.Image.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(0, param.ThresholdMax);

                    double area = regionThreshold.Area;
                    double valueToShow = area;/*CalibraFromPxTo_mm2(area);*/
                    ret = valueToShow >= param.AreaMin ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(imageReduced.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), GetColorTrasparenza(Color.Red), 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM5_FOTO1_STEP1"), valueToShow, param.AreaMin), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_1_CAM_5_FOTO_1", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO0"))
                    {
                        if (res.ResultOutput["DO0"] != (ret ? 1 : 0))
                            res.ResultOutput["DO0"] = 1;
                    }
                    else
                        res.ResultOutput.Add("DO0", (ret ? ushort.Parse("0") : ushort.Parse("1")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                regionMain?.Dispose();
            }
            return ret;
        }

        #endregion CAM5_FOTO1


        #region CAM5_FOTO2

        protected bool TestCam5_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam5_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = true;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    bool okStep_1 = TestCam5_Step1_Foto2(inputAlg, param, isWizard, ref res, ref workingList);

                    ret = okStep_1;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {

            }
            return ret;
        }

        protected bool TestCam5_Step1_Foto2(ClassInputAlgoritmi inputAlg, DataType.Cam5_Foto2Param param, bool isWizard, ref DataType.ElaborateResult res, ref ArrayList workingList)
        {
            bool ret = false;

            HRegion regionMain = null;
            HImage imageReduced = null;
            HRegion regionThreshold = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(param.Roi.Row1, param.Roi.Column1, param.Roi.Row2, param.Roi.Column2);

                    imageReduced = inputAlg.Image.ReduceDomain(regionMain);
                    regionThreshold = imageReduced.Threshold(param.ThresholdMax, 255);

                    double area = regionThreshold.Area;
                    double valueToShow = area;// CalibraFromPxTo_mm2(area);
                    ret = valueToShow >= param.AreaMin ? true : false;

                    workingList.Add(new Utilities.ObjectToDisplay(imageReduced.Clone(), "green", 2) { DrawMode = "margin" });
                    workingList.Add(new Utilities.ObjectToDisplay(regionThreshold.Clone(), GetColorTrasparenza(Color.Red), 2) { DrawMode = "fill" });

                    res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_CAM4_FOTO1_STEP2"), valueToShow, param.AreaMin), ret ? "green" : "red"));
                    res.StatisticheObj.AddMisura("TEST_1_CAM_5_FOTO_2", valueToShow);
                    if (res.ResultOutput.ContainsKey("DO0"))
                    {
                        if (res.ResultOutput["DO0"] != (ret ? 1 : 0))
                            res.ResultOutput["DO0"] = 1;
                    }
                    else
                        res.ResultOutput.Add("DO0", (ret ? ushort.Parse("0") : ushort.Parse("1")));
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                imageReduced?.Dispose();
                regionThreshold?.Dispose();
                regionMain?.Dispose();
            }
            return ret;
        }

        #endregion CAM5_FOTO2


        protected void my_tuple_find(int startIdx, HTuple tuple, int len, int toFind, out int endIdx, out HTuple indices)
        {
            //indices = new HTuple();
            indices = null;
            List<int> tmp = new List<int>();

            try
            {
                int idx = startIdx;

                while (len > idx && tuple.LArr[idx] <= toFind)
                {
                    if (tuple.LArr[idx] == toFind)
                    {
                        //HOperatorSet.TupleConcat(indices, idx, out indices);
                        tmp.Add(idx);
                    }
                    idx++;
                }
                indices = new HTuple(tmp.ToArray());

                endIdx = idx;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected double CalibraFrom_mm2ToPx(double val)
        {
            return val * this.impostazioniCamera.KConvPX_mm * this.impostazioniCamera.KConvPX_mm;
        }

        protected double CalibraFrom_mmToPx(double val)
        {
            return val / this.impostazioniCamera.KConvPX_mm;
        }

        protected double CalibraFromPxTo_mm2(double val)
        {
            return val * this.impostazioniCamera.KConvPX_mm * this.impostazioniCamera.KConvPX_mm;
        }

        protected double CalibraFromPxTo_mm(double val)
        {
            return val * this.impostazioniCamera.KConvPX_mm;
        }

        protected double CalibraFromPxTo_mm_W(double val)
        {
            return val / this.impostazioniCamera.KConvPX_mm_W;
        }

        protected double CalibraFromPxTo_mm_H(double val)
        {
            return val / this.impostazioniCamera.KConvPX_mm_H;
        }


        protected void DisposeBase()
        {

        }

        protected class ClassInputAlgoritmi : IDisposable
        {

            public DataType.TemplateFormato Template { get; set; }

            public HImage Image { get; set; }
            public HImage ImageGray { get; set; }
            public HImage ImageRotate { get; set; }
            public HImage ImageRotateGray { get; set; }

            public double Row { get; set; }
            public double Col { get; set; }
            public double Angle { get; set; }

            public ClassInputAlgoritmi()
            {
            }

            private bool disposed = false;

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
                        this.Image?.Dispose();
                        this.Image = null;

                        this.ImageGray?.Dispose();
                        this.ImageGray = null;

                        this.ImageRotate?.Dispose();
                        this.ImageRotate = null;

                        this.ImageRotateGray?.Dispose();
                        this.ImageRotateGray = null;
                    }
                    // Free your own state (unmanaged objects).
                    // Set large fields to null.
                    disposed = true;
                }
            }

            // Use C# destructor syntax for finalization code.
            ~ClassInputAlgoritmi()
            {
                // Simply call Dispose(false).
                Dispose(false);
            }

        }

        public void SetBlackWhite(int blackwhite)
        {
            this.blackwhite = blackwhite;
        }

    }
}