using HalconDotNet;
using System;
using System.Collections;

namespace QVLEGS.Algoritmi
{
    public class AlgoritmoWizard : Algoritmo, IDisposable
    {

        private const int TIMEOUT_SHPAE = 500;

        private static object objLock = new object();

        #region Variabili Private

        private bool disposed = false;

        private DataType.ParametriAlgoritmo parametri = null;

        private HImage imgWizard = null;
        private DataType.PrevImageData prevImageData = null;

        #endregion Variabili Private

        public AlgoritmoWizard(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager) { }


        public void LoadFiles(string idFormato)
        {
            LoadMask();
        }

        public void SaveFiles(string idFormato)
        {

        }

        public void SetAlgoritmoParam(DataType.ParametriAlgoritmo param)
        {
            this.parametri = param;

            if (this.parametri != null)
            {
                this.shapeMask = this.parametri.AllineamentoParam.ShapeParam.ShapeMask;
                this.modelHandle = this.parametri.AllineamentoParam.ShapeParam.ShapeModel;
                this.parametri.Template = DataType.TemplateFormato.GetTemplateByName(this.parametri.TemplateName);
            }
        }

        public DataType.ParametriAlgoritmo GetAlgoritmoParam()
        {
            return this.parametri;
        }

        public void ResetWizardImage()
        {
            this.imgWizard?.Dispose();
            this.imgWizard = null;
        }

        public void SetWizardImage(HImage image, DataType.PrevImageData prevImageData)
        {
            this.prevImageData = prevImageData;
            if (image != null && image.IsInitialized())
                this.imgWizard = image.CopyImage();
        }

        public HImage GetWizardImage(out DataType.PrevImageData prevImageData)
        {
            prevImageData = this.prevImageData;
            if (this.imgWizard == null || !this.imgWizard.IsInitialized())
                return null;
            else
                return this.imgWizard.CopyImage();
        }


        private delegate bool TestWizardBaseDelegate(ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res, ref ArrayList workingList);

        private void TestWizardAcqBase(HImage image, TestWizardBaseDelegate foo, out ArrayList workingList, out DataType.ElaborateResult res)
        {
            double startTime = HSystem.CountSeconds();

            workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            ClassInputAlgoritmi inputAlg = null;
            HRegion regionMain = null;

            try
            {
                // oggetti da visualizzare
                workingList.Add(new Utilities.ObjectToDisplay(image.Clone()));
                if (this.parametri == null)
                {
                    res.Success = false;
                    res.TestiRagioneScarto.Add("MSG_PARAMETRI_KO");
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                    inputAlg = CreaClassInputAlgoritmi(this.parametri, image, regionMain);

                    res.Success = foo(inputAlg, ref res, ref workingList);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));

                AddTestiOutAlgoritmi(res, ref workingList);

                double tAnalisi = HSystem.CountSeconds();
                tAnalisi = (tAnalisi - startTime) * 1000.0;
                res.ElapsedTime = tAnalisi;

                inputAlg?.Dispose();
                regionMain?.Dispose();
            }
        }

        private void TestWizardBase(HImage image, int numTest, DataType.PrevImageData prevImageData, TestWizardBaseDelegate foo, out ArrayList workingList, out DataType.ElaborateResult res)
        {
            double startTime = HSystem.CountSeconds();

            workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            ClassInputAlgoritmi inputAlg = null;
            HRegion regionMain = null;

            try
            {
                // oggetti da visualizzare
                workingList.Add(new Utilities.ObjectToDisplay(image.CopyImage()));

                if (this.parametri == null)
                {
                    res.Success = false;
                    res.TestiRagioneScarto.Add("MSG_PARAMETRI_KO");
                }
                else
                {
                    regionMain = new HRegion();
                    regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                    inputAlg = CreaClassInputAlgoritmi(this.parametri, image, regionMain);

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

                    if (ok)
                    //if (Centraggio(image, regionMain, this.parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList))
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

                        res.Success = foo(inputAlg, ref res, ref workingList);
                    }
                    //else
                    //{
                    //    res.TestiOutAlgoritmi.Add(new Tuple<string, string>("MSG_CENTRAGGIO_KO", "red"));
                    //}
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));

                AddTestiOutAlgoritmi(res, ref workingList);

                double tAnalisi = HSystem.CountSeconds();
                tAnalisi = (tAnalisi - startTime) * 1000.0;
                res.ElapsedTime = tAnalisi;

                inputAlg?.Dispose();
                regionMain?.Dispose();
            }
        }


        public void SetRoiMain(HTuple data)
        {
            if (parametri.RoiMain == null)
                parametri.RoiMain = new DataType.Rectangle1Param();
            parametri.RoiMain.Row1 = data.DArr[0];
            parametri.RoiMain.Column1 = data.DArr[1];
            parametri.RoiMain.Row2 = data.DArr[2];
            parametri.RoiMain.Column2 = data.DArr[3];
        }

        public void SetImageRefMain(HImage image, DataType.PrevImageData prevImageData)
        {
            this.parametri.ImageRef = image.CopyImage();
            this.parametri.PrevImageDataRef = prevImageData;
        }

        public void SetWizardAcqComplete()
        {
            this.parametri.WizardAcqCompleto = true;
        }


        #region CENTRAGGIO

        private HShapeModel modelHandle = null;
        private HRegion shapeMask = null;

        public void SetImageRefCentraggio(HImage image, DataType.PrevImageData prevImageData)
        {
            this.parametri.AllineamentoParam.ImageRef = image.CopyImage();
            this.parametri.AllineamentoParam.PrevImageDataRef = prevImageData;
        }

        public void SetRegionTrainAllineamento(HTuple roiData, HRegion mask)
        {
            if (parametri.AllineamentoParam.RoiModel == null)
                parametri.AllineamentoParam.RoiModel = new DataType.Rectangle1Param();
            parametri.AllineamentoParam.RoiModel.Row1 = roiData.DArr[0];
            parametri.AllineamentoParam.RoiModel.Column1 = roiData.DArr[1];
            parametri.AllineamentoParam.RoiModel.Row2 = roiData.DArr[2];
            parametri.AllineamentoParam.RoiModel.Column2 = roiData.DArr[3];

            shapeMask = mask;
        }

        public HRegion GetRegionTrainShape()
        {
            return shapeMask;
        }

        public ArrayList SetAllineamentoShape(HImage image, bool paramAuto, out bool ok)
        {
            ArrayList workingList = new ArrayList();
            ok = false;

            HRegion modelRegionTmp = null;
            HRegion modelRegion = null;
            HXLDCont shapeModelContours = null;
            HXLDCont modelTrans = null;

            ClassInputAlgoritmi inputAlg = null;
            HRegion regionMain = null;


            try
            {
                // oggetti da visualizzare
                workingList.Add(new Utilities.ObjectToDisplay(image.Clone()));

                modelRegionTmp = new HRegion();
                modelRegionTmp.GenRectangle1(this.parametri.AllineamentoParam.RoiModel.Row1
                    , this.parametri.AllineamentoParam.RoiModel.Column1
                    , this.parametri.AllineamentoParam.RoiModel.Row2
                    , this.parametri.AllineamentoParam.RoiModel.Column2);

                if (this.shapeMask != null)
                    modelRegion = modelRegionTmp.Difference(this.shapeMask);
                else
                    modelRegion = modelRegionTmp;

                if (paramAuto)
                    this.parametri.AllineamentoParam.ShapeParam.CreateParam = new DataType.CreateScaledShapeModelParam();

                //creo immagine sintetica
                inputAlg = CreaClassInputAlgoritmi(this.parametri, image, modelRegionTmp);

                image.GetImageSize(out int width, out int height);


                modelHandle = CreateScaledShapeModel(inputAlg.Image, modelRegion, paramAuto, this.parametri.AllineamentoParam.ShapeParam.CreateParam);

                HTuple row, column, angle, scale, score;

                if (FindScaledShapeModel(image, modelRegionTmp, modelHandle, this.parametri.AllineamentoParam.ShapeParam.CreateParam, this.parametri.AllineamentoParam.ShapeParam.FindParam, out row, out column, out angle, out scale, out score))
                {
                    shapeModelContours = modelHandle.GetShapeModelContours(1);
                    HHomMat2D homMat2DRotate = new HHomMat2D();
                    homMat2DRotate.VectorAngleToRigid(0, 0, 0, row, column, angle);
                    HHomMat2D homMat2DScale = homMat2DRotate.HomMat2dScale(1, 1, row, column);
                    modelTrans = homMat2DScale.AffineTransContourXld(shapeModelContours);

                    if (score != null && score.TupleLength() == 1)
                    {
                        this.parametri.AllineamentoParam.ShapeParam.RowRef = row.D;
                        this.parametri.AllineamentoParam.ShapeParam.ColumnRef = column.D;
                        this.parametri.AllineamentoParam.ShapeParam.AngleRef = angle.D;

                        // Regione modello
                        if (modelRegion != null)
                        {
                            workingList.Add(new Utilities.ObjectToDisplay(modelRegion.Clone(), "blue", 3));
                        }

                        // contorno del modello
                        if (modelTrans != null)
                        {
                            workingList.Add(new Utilities.ObjectToDisplay(modelTrans.Clone(), COLORE_SHAPE, 3));
                        }

                        if (this.parametri.AllineamentoParam.ShapeParam.ShapeModel != null && this.parametri.AllineamentoParam.ShapeParam.ShapeModel.IsInitialized())
                        {
                            this.parametri.AllineamentoParam.ShapeParam.ShapeModel.Dispose();
                        }

                        this.parametri.AllineamentoParam.ShapeParam.ShapeMask = shapeMask;
                        this.parametri.AllineamentoParam.ShapeParam.ShapeModel = modelHandle;

                        ok = true;
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                modelRegionTmp?.Dispose();
                modelRegion?.Dispose();
                shapeModelContours?.Dispose();
                modelTrans?.Dispose();
                inputAlg?.Dispose();
                regionMain?.Dispose();
            }
            return workingList;
        }

        private HShapeModel CreateScaledShapeModel(HImage image, HRegion roi, bool paramAuto, DataType.CreateScaledShapeModelParam p)
        {
            HImage imageReduced = image.ReduceDomain(roi);

            if (paramAuto)
                DetermineShapeParameter(imageReduced, ref p);

            HShapeModel ret = imageReduced.CreateScaledShapeModel(p.NumLevels, p.AngleStart, p.AngleExtent, p.AngleStep, p.ScaleMin, p.ScaleMax, p.ScaleStep, p.Optimization, p.Metric, p.Contrast, p.MinContrast);

            //ret.SetShapeModelParam(new HTuple("timeout"), new HTuple(TIMEOUT_SHPAE));

            return ret;
        }

        private bool DetermineShapeParameter(HImage img, ref DataType.CreateScaledShapeModelParam p)
        {
            // upper and lower range
            int contrastLowB = 0;
            int contrastUpB = 255;
            double scaleStepLowB = 0.0;
            double scaleStepUpB = (double)19.0 / 1000.0;
            double angleStepLowB = 0.0;
            double angleStepUpB = (double)(112.0 / 10.0) * Math.PI / 180.0;
            int pyramLevLowB = 1;
            int pyramLevUpB = 6;
            int minContrastLowB = 0;
            int minContrastUpB = 30;

            HTuple paramValue = new HTuple();
            HTuple paramList = new HTuple();

            try
            {
                string[] autoParList = new string[] { "angle_step", "contrast", "min_contrast", "num_levels", "optimization", "scale_step" };

                paramList = img.DetermineShapeModelParams(p.NumLevels,
                                                             (double)p.AngleStart,
                                                             (double)p.AngleExtent,
                                                             p.ScaleMin,
                                                             p.ScaleMax,
                                                             p.Optimization,
                                                             p.Metric,
                                                             (int)p.Contrast,
                                                             (int)p.MinContrast,
                                                             autoParList,
                                                             out paramValue);
            }
            catch (HOperatorException)
            {
                return false;
            }

            double vald;
            int vali;

            for (int i = 0; i < paramList.Length; i++)
            {
                switch ((string)paramList[i])
                {
                    case "angle_step":
                        vald = (double)paramValue[i];

                        angleStepUpB = vald * 3.0;
                        angleStepLowB = vald / 3.0;

                        if (vald > angleStepUpB)
                            vald = angleStepUpB;
                        else if (vald < angleStepLowB)
                            vald = angleStepLowB;

                        p.AngleStep = vald;
                        break;
                    case "contrast":
                        vali = (int)paramValue[i];

                        if (vali > contrastUpB)
                            vali = contrastUpB;
                        else if (vali < contrastLowB)
                            vali = contrastLowB;

                        minContrastUpB = vali;
                        p.Contrast = vali;

                        //inspectShapeModel();
                        break;
                    case "min_contrast":
                        vali = (int)paramValue[i];

                        if (vali > minContrastUpB)
                            vali = minContrastUpB;
                        else if (vali < minContrastLowB)
                            vali = minContrastLowB;

                        p.MinContrast = vali;
                        break;
                    case "num_levels":
                        vali = (int)paramValue[i];

                        if (vali > pyramLevUpB)
                            vali = pyramLevUpB;
                        else if (vali < pyramLevLowB)
                            vali = pyramLevLowB;

                        p.NumLevels = vali;
                        break;
                    case "optimization":
                        p.Optimization = (string)paramValue[i];
                        break;
                    case "scale_step":
                        vald = (double)paramValue[i];

                        scaleStepUpB = vald * 3.0;
                        scaleStepLowB = vald / 3.0;

                        if (vald > scaleStepUpB)
                            vald = scaleStepUpB;
                        else if (vald < scaleStepLowB)
                            vald = scaleStepLowB;

                        p.ScaleStep = vald;
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        public void TestAllineamento(HImage image, int numTest, DataType.PrevImageData prevImageData, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            lock (objLock)
            {
                ArrayList workingList = new ArrayList();
                DataType.ElaborateResult res = new DataType.ElaborateResult() { Success = true };

                HImage imageReduced = null;
                HRegion regionMain = null;

                try
                {
                    workingList.Add(new Utilities.ObjectToDisplay(image.CopyImage()));

                    if (this.parametri == null)
                    {
                    }
                    else
                    {
                        regionMain = new HRegion();
                        regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                        workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                        imageReduced = image.ReduceDomain(regionMain);
                        res.Success = Centraggio(image, regionMain, this.parametri.AllineamentoParam, true, out double row, out double col, out double angle, ref res, ref workingList);
                    }
                }
                catch (Exception)
                {
                    //throw;
                }
                finally
                {
                    workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));

                    AddTestiOutAlgoritmi(res, ref workingList);

                    iconicList = workingList;
                    result = res;

                    imageReduced?.Dispose();
                    regionMain?.Dispose();
                }
            }
        }

        public void SetWizardoAllineamentoComplete()
        {
            this.parametri.AllineamentoParam.WizardCompleto = true;
        }

        #endregion CENTRAGGIO


        #region CAM1_FOTO1

        public void SetAlgCam1_Foto1Enable(bool enable)
        {
            this.parametri.Cam1_Foto1Param.AbilitaControllo = enable;
        }

        public void SetRoiCam1_Foto1_Circle1(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.Circle1 == null)
                parametri.Cam1_Foto1Param.Circle1 = new DataType.CircleParam();
            parametri.Cam1_Foto1Param.Circle1.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.Circle1.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.Circle1.Radius = data.DArr[2];
        }

        public void SetRoiCam1_Foto1_Circle2(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.Circle2 == null)
                parametri.Cam1_Foto1Param.Circle2 = new DataType.CircleParam();
            parametri.Cam1_Foto1Param.Circle2.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.Circle2.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.Circle2.Radius = data.DArr[2];
        }

        public void SetRoiCam1_Foto1_Circle3(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.Circle3 == null)
                parametri.Cam1_Foto1Param.Circle3 = new DataType.CircleParam();
            parametri.Cam1_Foto1Param.Circle3.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.Circle3.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.Circle3.Radius = data.DArr[2];
        }

        public void SetRoiCam1_Foto1_Circle4(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.Circle4 == null)
                parametri.Cam1_Foto1Param.Circle4 = new DataType.CircleParam();
            parametri.Cam1_Foto1Param.Circle4.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.Circle4.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.Circle4.Radius = data.DArr[2];
        }

        public void SetRoiCam1_Foto1_CircleEdge(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.CircleEdge == null)
                parametri.Cam1_Foto1Param.CircleEdge = new DataType.CircleParam();
            parametri.Cam1_Foto1Param.CircleEdge.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.CircleEdge.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.CircleEdge.Radius = data.DArr[2];
        }

        public void SetRoiCam1_Foto1_Rect(HTuple data)
        {
            if (parametri.Cam1_Foto1Param.RoiCalliper == null)
                parametri.Cam1_Foto1Param.RoiCalliper = new DataType.Rectangle2Param();

            parametri.Cam1_Foto1Param.RoiCalliper.Row = data.DArr[0];
            parametri.Cam1_Foto1Param.RoiCalliper.Column = data.DArr[1];
            parametri.Cam1_Foto1Param.RoiCalliper.Angle = data.DArr[2];
            parametri.Cam1_Foto1Param.RoiCalliper.Length1 = data.DArr[3];
            parametri.Cam1_Foto1Param.RoiCalliper.Length2 = data.DArr[4];
        }

        public ArrayList TestCam1_Foto1_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step1_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto1_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step2_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto1_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step3_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto1_Step4Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step4_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto1_Step5Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step5_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto1_Step6Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step6_Foto1(inputAlg, this.parametri.Cam1_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam1_Foto1Complete()
        {
            this.parametri.Cam1_Foto1Param.WizardCompleto = true;
        }

        #endregion CAM1_FOTO1


        #region CAM1_FOTO2

        public void SetAlgCam1_Foto2Enable(bool enable)
        {
            this.parametri.Cam1_Foto2Param.AbilitaControllo = enable;
        }

        public void SetRoiCam1_Foto2_BigRec_1(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_1 == null)
                    parametri.Cam1_Foto2Param.bigRegion_1 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_1 = data;
            }
            else if(index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_1 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_1 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_1 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_1 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_1 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_1 = data;
            }

            //if (parametri.Cam1_Foto2Param.bigRect_1 == null)
            //    parametri.Cam1_Foto2Param.bigRect_1 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_1.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_1.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_1.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_1.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_2(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_2 == null)
                    parametri.Cam1_Foto2Param.bigRegion_2 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_2 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_2 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_2 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_2 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_2 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_2 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_2 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_2 == null)
            //    parametri.Cam1_Foto2Param.bigRect_2 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_2.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_2.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_2.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_2.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_3(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_3 == null)
                    parametri.Cam1_Foto2Param.bigRegion_3 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_3 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_3 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_3 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_3 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_3 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_3 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_3 = data;
            }
            //    if (parametri.Cam1_Foto2Param.bigRect_3 == null)
            //        parametri.Cam1_Foto2Param.bigRect_3 = new DataType.Rectangle1Param();
            //    parametri.Cam1_Foto2Param.bigRect_3.Row1 = data.DArr[0];
            //    parametri.Cam1_Foto2Param.bigRect_3.Column1 = data.DArr[1];
            //    parametri.Cam1_Foto2Param.bigRect_3.Row2 = data.DArr[2];
            //    parametri.Cam1_Foto2Param.bigRect_3.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_4(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_4 == null)
                    parametri.Cam1_Foto2Param.bigRegion_4 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_4 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_4 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_4 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_4 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_4 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_4 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_4 = data;
            }
            //    if (parametri.Cam1_Foto2Param.bigRect_4 == null)
            //        parametri.Cam1_Foto2Param.bigRect_4 = new DataType.Rectangle1Param();
            //    parametri.Cam1_Foto2Param.bigRect_4.Row1 = data.DArr[0];
            //    parametri.Cam1_Foto2Param.bigRect_4.Column1 = data.DArr[1];
            //    parametri.Cam1_Foto2Param.bigRect_4.Row2 = data.DArr[2];
            //    parametri.Cam1_Foto2Param.bigRect_4.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_5(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_5 == null)
                    parametri.Cam1_Foto2Param.bigRegion_5 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_5 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_5 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_5 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_5 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_5 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_5 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_5 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_5 == null)
            //    parametri.Cam1_Foto2Param.bigRect_5 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_5.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_5.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_5.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_5.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_6(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_6 == null)
                    parametri.Cam1_Foto2Param.bigRegion_6 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_6 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_6 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_6 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_6 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_6 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_6 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_6 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_6 == null)
            //    parametri.Cam1_Foto2Param.bigRect_6 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_6.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_6.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_6.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_6.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_7(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_7 == null)
                    parametri.Cam1_Foto2Param.bigRegion_7 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_7 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_7 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_7 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_7 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_7 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_7 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_7 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_7 == null)
            //    parametri.Cam1_Foto2Param.bigRect_7 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_7.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_7.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_7.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_7.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_8(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_8 == null)
                    parametri.Cam1_Foto2Param.bigRegion_8 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_8 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_8 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_8 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_8 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_8 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_8 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_8 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_8 == null)
            //    parametri.Cam1_Foto2Param.bigRect_8 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_8.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_8.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_8.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_8.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_9(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_9 == null)
                    parametri.Cam1_Foto2Param.bigRegion_9 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_9 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_9 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_9 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_9 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_9 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_9 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_9 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_9 == null)
            //    parametri.Cam1_Foto2Param.bigRect_9 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_9.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_9.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_9.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_9.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_BigRec_10(HRegion data, int index = 0)
        {
            if (index == 0)
            {
                if (parametri.Cam1_Foto2Param.bigRegion_10 == null)
                    parametri.Cam1_Foto2Param.bigRegion_10 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion_10 = data;
            }
            else if (index == 1)
            {
                if (parametri.Cam1_Foto2Param.bigRegion2_10 == null)
                    parametri.Cam1_Foto2Param.bigRegion2_10 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion2_10 = data;
            } else
            {
                if (parametri.Cam1_Foto2Param.bigRegion3_10 == null)
                    parametri.Cam1_Foto2Param.bigRegion3_10 = new HRegion();
                parametri.Cam1_Foto2Param.bigRegion3_10 = data;
            }
            //if (parametri.Cam1_Foto2Param.bigRect_10 == null)
            //    parametri.Cam1_Foto2Param.bigRect_10 = new DataType.Rectangle1Param();
            //parametri.Cam1_Foto2Param.bigRect_10.Row1 = data.DArr[0];
            //parametri.Cam1_Foto2Param.bigRect_10.Column1 = data.DArr[1];
            //parametri.Cam1_Foto2Param.bigRect_10.Row2 = data.DArr[2];
            //parametri.Cam1_Foto2Param.bigRect_10.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_1(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_1 == null)
                parametri.Cam1_Foto2Param.smallRect_1 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_1.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_1.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_1.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_1.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_2(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_2 == null)
                parametri.Cam1_Foto2Param.smallRect_2 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_2.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_2.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_2.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_2.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_3(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_3 == null)
                parametri.Cam1_Foto2Param.smallRect_3 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_3.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_3.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_3.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_3.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_4(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_4 == null)
                parametri.Cam1_Foto2Param.smallRect_4 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_4.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_4.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_4.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_4.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_5(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_5 == null)
                parametri.Cam1_Foto2Param.smallRect_5 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_5.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_5.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_5.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_5.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_6(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_6 == null)
                parametri.Cam1_Foto2Param.smallRect_6 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_6.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_6.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_6.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_6.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_7(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_7 == null)
                parametri.Cam1_Foto2Param.smallRect_7 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_7.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_7.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_7.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_7.Column2 = data.DArr[3];
        }

        public void SetRoiCam1_Foto2_SmallRec_8(HTuple data)
        {
            if (parametri.Cam1_Foto2Param.smallRect_8 == null)
                parametri.Cam1_Foto2Param.smallRect_8 = new DataType.Rectangle1Param();
            parametri.Cam1_Foto2Param.smallRect_8.Row1 = data.DArr[0];
            parametri.Cam1_Foto2Param.smallRect_8.Column1 = data.DArr[1];
            parametri.Cam1_Foto2Param.smallRect_8.Row2 = data.DArr[2];
            parametri.Cam1_Foto2Param.smallRect_8.Column2 = data.DArr[3];
        }

        public ArrayList TestCam1_Foto2_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step1_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step2_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step3_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step4Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step4_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step5Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step5_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step6Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step6_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step7Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step7_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step8Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step8_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step9Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step9_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step10Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step10_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1, parametri.Cam1_Foto2Param.checked1, parametri.Cam1_Foto2Param.invertedBlack1, parametri.Cam1_Foto2Param.invertedWhite1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step11Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step11_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step12Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step12_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step13Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step13_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step14Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step14_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step15Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step15_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step16Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step16_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step17Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step17_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam1_Foto2_Step18Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam1_Step18_Foto2(inputAlg, this.parametri.Cam1_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam1_Foto2Complete()
        {
            this.parametri.Cam1_Foto2Param.WizardCompleto = true;
        }

        #endregion


        #region CAM2_FOTO1

        public void SetAlgCam2_Foto1Enable(bool enable)
        {
            this.parametri.Cam2_Foto1Param.AbilitaControllo = enable;
        }

        public void SetRoiWidthCam2_Foto1(HTuple data)
        {
            if (parametri.Cam2_Foto1Param.RectPin == null)
                parametri.Cam2_Foto1Param.RectPin = new DataType.Rectangle1Param();
            parametri.Cam2_Foto1Param.RectPin.Row1 = data.DArr[0];
            parametri.Cam2_Foto1Param.RectPin.Column1 = data.DArr[1];
            parametri.Cam2_Foto1Param.RectPin.Row2 = data.DArr[2];
            parametri.Cam2_Foto1Param.RectPin.Column2 = data.DArr[3];
        }

        public void SetRoiLeftCam2_Foto1(HTuple data)
        {
            if (parametri.Cam2_Foto1Param.RectBlackLeft == null)
                parametri.Cam2_Foto1Param.RectBlackLeft = new DataType.Rectangle1Param();
            parametri.Cam2_Foto1Param.RectBlackLeft.Row1 = data.DArr[0];
            parametri.Cam2_Foto1Param.RectBlackLeft.Column1 = data.DArr[1];
            parametri.Cam2_Foto1Param.RectBlackLeft.Row2 = data.DArr[2];
            parametri.Cam2_Foto1Param.RectBlackLeft.Column2 = data.DArr[3];
        }

        public void SetRoiRightCam2_Foto1(HTuple data)
        {
            if (parametri.Cam2_Foto1Param.RectBlackRight == null)
                parametri.Cam2_Foto1Param.RectBlackRight = new DataType.Rectangle1Param();
            parametri.Cam2_Foto1Param.RectBlackRight.Row1 = data.DArr[0];
            parametri.Cam2_Foto1Param.RectBlackRight.Column1 = data.DArr[1];
            parametri.Cam2_Foto1Param.RectBlackRight.Row2 = data.DArr[2];
            parametri.Cam2_Foto1Param.RectBlackRight.Column2 = data.DArr[3];
        }

        public ArrayList TestCam2_Foto1_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam2_Step1_Foto1(inputAlg, this.parametri.Cam2_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam2_Foto1_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam2_Step2_Foto1(inputAlg, this.parametri.Cam2_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam2_Foto1_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam2_Step3_Foto1(inputAlg, this.parametri.Cam2_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam2_Foto1Complete()
        {
            this.parametri.Cam2_Foto1Param.WizardCompleto = true;
        }

        #endregion CAM2_FOTO1


        #region CAM3_FOTO1

        public void SetAlgCam3_Foto1Enable(bool enable)
        {
            this.parametri.Cam3_Foto1Param.AbilitaControllo = enable;
        }

        public void SetRoiCam3_Foto1_Height_Riff(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectRif_1 == null)
                parametri.Cam3_Foto1Param.RectRif_1 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectRif_1.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectRif_1.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectRif_1.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectRif_1.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectRif_1.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto1_Height_Riff_2(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectRif_2 == null)
                parametri.Cam3_Foto1Param.RectRif_2 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectRif_2.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectRif_2.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectRif_2.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectRif_2.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectRif_2.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto1_Calipper_1(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectCalipper_1 == null)
                parametri.Cam3_Foto1Param.RectCalipper_1 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectCalipper_1.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectCalipper_1.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectCalipper_1.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectCalipper_1.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectCalipper_1.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto1_Calipper_2(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectCalipper_2 == null)
                parametri.Cam3_Foto1Param.RectCalipper_2 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectCalipper_2.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectCalipper_2.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectCalipper_2.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectCalipper_2.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectCalipper_2.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto1_Height_1(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectHeight_1 == null)
                parametri.Cam3_Foto1Param.RectHeight_1 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectHeight_1.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectHeight_1.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectHeight_1.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectHeight_1.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectHeight_1.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto1_Height_2(HTuple data)
        {
            if (parametri.Cam3_Foto1Param.RectHeight_2 == null)
                parametri.Cam3_Foto1Param.RectHeight_2 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto1Param.RectHeight_2.Row = data.DArr[0];
            parametri.Cam3_Foto1Param.RectHeight_2.Column = data.DArr[1];
            parametri.Cam3_Foto1Param.RectHeight_2.Angle = data.DArr[2];
            parametri.Cam3_Foto1Param.RectHeight_2.Length1 = data.DArr[3];
            parametri.Cam3_Foto1Param.RectHeight_2.Length2 = data.DArr[4];

        }

        public ArrayList TestCam3_Foto1_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step1_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto1_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step2_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto1_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step3_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto1_Step4Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step4_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto1_Step5Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step5_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto1_Step6Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step6_Foto1(inputAlg, this.parametri.Cam3_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam3_Foto1Complete()
        {
            this.parametri.Cam3_Foto1Param.WizardCompleto = true;
        }

        #endregion


        #region CAM3_FOTO2

        public void SetAlgCam3_Foto2Enable(bool enable)
        {
            this.parametri.Cam3_Foto2Param.AbilitaControllo = enable;
        }

        public void SetRoiCam3_Foto2_Height_Riff(HTuple data)
        {
            if (parametri.Cam3_Foto2Param.RectRif_1 == null)
                parametri.Cam3_Foto2Param.RectRif_1 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto2Param.RectRif_1.Row = data.DArr[0];
            parametri.Cam3_Foto2Param.RectRif_1.Column = data.DArr[1];
            parametri.Cam3_Foto2Param.RectRif_1.Angle = data.DArr[2];
            parametri.Cam3_Foto2Param.RectRif_1.Length1 = data.DArr[3];
            parametri.Cam3_Foto2Param.RectRif_1.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto2_Height_Riff_2(HTuple data)
        {
            if (parametri.Cam3_Foto2Param.RectRif_2 == null)
                parametri.Cam3_Foto2Param.RectRif_2 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto2Param.RectRif_2.Row = data.DArr[0];
            parametri.Cam3_Foto2Param.RectRif_2.Column = data.DArr[1];
            parametri.Cam3_Foto2Param.RectRif_2.Angle = data.DArr[2];
            parametri.Cam3_Foto2Param.RectRif_2.Length1 = data.DArr[3];
            parametri.Cam3_Foto2Param.RectRif_2.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto2_Height_1(HTuple data)
        {
            if (parametri.Cam3_Foto2Param.RectHeight_1 == null)
                parametri.Cam3_Foto2Param.RectHeight_1 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto2Param.RectHeight_1.Row = data.DArr[0];
            parametri.Cam3_Foto2Param.RectHeight_1.Column = data.DArr[1];
            parametri.Cam3_Foto2Param.RectHeight_1.Angle = data.DArr[2];
            parametri.Cam3_Foto2Param.RectHeight_1.Length1 = data.DArr[3];
            parametri.Cam3_Foto2Param.RectHeight_1.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto2_Height_2(HTuple data)
        {
            if (parametri.Cam3_Foto2Param.RectHeight_2 == null)
                parametri.Cam3_Foto2Param.RectHeight_2 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto2Param.RectHeight_2.Row = data.DArr[0];
            parametri.Cam3_Foto2Param.RectHeight_2.Column = data.DArr[1];
            parametri.Cam3_Foto2Param.RectHeight_2.Angle = data.DArr[2];
            parametri.Cam3_Foto2Param.RectHeight_2.Length1 = data.DArr[3];
            parametri.Cam3_Foto2Param.RectHeight_2.Length2 = data.DArr[4];

        }

        public void SetRoiCam3_Foto2_Height_3(HTuple data)
        {
            if (parametri.Cam3_Foto2Param.RectHeight_3 == null)
                parametri.Cam3_Foto2Param.RectHeight_3 = new DataType.Rectangle2Param();
            parametri.Cam3_Foto2Param.RectHeight_3.Row = data.DArr[0];
            parametri.Cam3_Foto2Param.RectHeight_3.Column = data.DArr[1];
            parametri.Cam3_Foto2Param.RectHeight_3.Angle = data.DArr[2];
            parametri.Cam3_Foto2Param.RectHeight_3.Length1 = data.DArr[3];
            parametri.Cam3_Foto2Param.RectHeight_3.Length2 = data.DArr[4];

        }

        public ArrayList TestCam3_Foto2_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step1_Foto2(inputAlg, this.parametri.Cam3_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto2_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step2_Foto2(inputAlg, this.parametri.Cam3_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto2_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step3_Foto2(inputAlg, this.parametri.Cam3_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto2_Step4Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step4_Foto2(inputAlg, this.parametri.Cam3_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam3_Foto2_Step5Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam3_Step5_Foto2(inputAlg, this.parametri.Cam3_Foto2Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam3_Foto2Complete()
        {
            this.parametri.Cam3_Foto2Param.WizardCompleto = true;
        }

        #endregion


        #region CAM4_FOTO1

        public void SetAlgCam4_Foto1Enable(bool enable)
        {
            this.parametri.Cam4_Foto1Param.AbilitaControllo = enable;
        }

        public void SetRoiCam4_Foto1_CircleCenter(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.CircleCenter == null)
                parametri.Cam4_Foto1Param.CircleCenter = new DataType.CircleParam();
            parametri.Cam4_Foto1Param.CircleCenter.Row = data.DArr[0];
            parametri.Cam4_Foto1Param.CircleCenter.Column = data.DArr[1];
            parametri.Cam4_Foto1Param.CircleCenter.Radius = data.DArr[2];
        }

        public void SetRoiLeftCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectGrayLeft == null)
                parametri.Cam4_Foto1Param.RectGrayLeft = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectGrayLeft.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectGrayLeft.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectGrayLeft.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectGrayLeft.Column2 = data.DArr[3];
        }

        public void SetRoiRightCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectGrayRight == null)
                parametri.Cam4_Foto1Param.RectGrayRight = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectGrayRight.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectGrayRight.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectGrayRight.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectGrayRight.Column2 = data.DArr[3];
        }

        public void SetRoiBlueLeftCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueLeft == null)
                parametri.Cam4_Foto1Param.RectBlueLeft = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueLeft.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueLeft.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueLeft.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueLeft.Column2 = data.DArr[3];
        }

        public void SetRoiBlueLeft2Cam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueLeft2 == null)
                parametri.Cam4_Foto1Param.RectBlueLeft2 = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueLeft2.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueLeft2.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueLeft2.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueLeft2.Column2 = data.DArr[3];
        }

        public void SetRoiBlueLeft3Cam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueLeft3 == null)
                parametri.Cam4_Foto1Param.RectBlueLeft3 = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueLeft3.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueLeft3.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueLeft3.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueLeft3.Column2 = data.DArr[3];
        }

        public void SetRoiBlueLeft4Cam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueLeft4 == null)
                parametri.Cam4_Foto1Param.RectBlueLeft4 = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueLeft4.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueLeft4.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueLeft4.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueLeft4.Column2 = data.DArr[3];
        }

        public void SetRoiBlueRightCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueRight == null)
                parametri.Cam4_Foto1Param.RectBlueRight = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueRight.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueRight.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueRight.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueRight.Column2 = data.DArr[3];
        }

        public void SetRoiBlueRight2Cam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueRight2 == null)
                parametri.Cam4_Foto1Param.RectBlueRight2 = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueRight2.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueRight2.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueRight2.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueRight2.Column2 = data.DArr[3];
        }

        public void SetRoiYellowRightCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectYellowRight == null)
                parametri.Cam4_Foto1Param.RectYellowRight = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectYellowRight.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectYellowRight.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectYellowRight.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectYellowRight.Column2 = data.DArr[3];
        }

        public void SetRoiCam4_Foto1_YellowCenter(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.CircleYellowCenter == null)
                parametri.Cam4_Foto1Param.CircleYellowCenter = new DataType.BullEyeParam();
            parametri.Cam4_Foto1Param.CircleYellowCenter.Row = data.DArr[0];
            parametri.Cam4_Foto1Param.CircleYellowCenter.Column = data.DArr[1];
            parametri.Cam4_Foto1Param.CircleYellowCenter.RadiusInner = data.DArr[2];
            parametri.Cam4_Foto1Param.CircleYellowCenter.RadiusOuter = data.DArr[3];
        }

        public void SetRoiCam4_Foto1_BlueCenter(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.CircleBlueCenter == null)
                parametri.Cam4_Foto1Param.CircleBlueCenter = new DataType.CircleParam();
            parametri.Cam4_Foto1Param.CircleBlueCenter.Row = data.DArr[0];
            parametri.Cam4_Foto1Param.CircleBlueCenter.Column = data.DArr[1];
            parametri.Cam4_Foto1Param.CircleBlueCenter.Radius = data.DArr[2];
        }

        public void SetRoiBlueUpCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectBlueUp == null)
                parametri.Cam4_Foto1Param.RectBlueUp = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectBlueUp.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectBlueUp.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectBlueUp.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectBlueUp.Column2 = data.DArr[3];
        }

        public void SetRoiRedLeftCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectRedLeft == null)
                parametri.Cam4_Foto1Param.RectRedLeft = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectRedLeft.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectRedLeft.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectRedLeft.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectRedLeft.Column2 = data.DArr[3];
        }

        public void SetRoiRedRightCam4_Foto1(HTuple data)
        {
            if (parametri.Cam4_Foto1Param.RectRedRight == null)
                parametri.Cam4_Foto1Param.RectRedRight = new DataType.Rectangle1Param();
            parametri.Cam4_Foto1Param.RectRedRight.Row1 = data.DArr[0];
            parametri.Cam4_Foto1Param.RectRedRight.Column1 = data.DArr[1];
            parametri.Cam4_Foto1Param.RectRedRight.Row2 = data.DArr[2];
            parametri.Cam4_Foto1Param.RectRedRight.Column2 = data.DArr[3];
        }

        public ArrayList TestCam4_Foto1_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step1_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step2Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step2_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step3Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step3_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step4Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step4_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step5Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step5_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step6Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step6_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step7Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step7_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step8Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step8_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step9Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step9_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step10Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step10_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step11Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step11_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step12Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step12_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step13Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step13_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step14Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step14_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public ArrayList TestCam4_Foto1_Step15Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam4_Step15_Foto1(inputAlg, this.parametri.Cam4_Foto1Param, true, ref res1, ref workingList1);
            };

            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam4_Foto1Complete()
        {
            this.parametri.Cam4_Foto1Param.WizardCompleto = true;
        }

        #endregion


        #region CAM5_FOTO1

        public void SetAlgCam5_Foto1Enable(bool enable)
        {
            this.parametri.Cam5_Foto1Param.AbilitaControllo = enable;
        }

        public void SetRoiCam5_Foto1(HTuple data)
        {
            if (parametri.Cam5_Foto1Param.Roi == null)
                parametri.Cam5_Foto1Param.Roi = new DataType.Rectangle1Param();
            parametri.Cam5_Foto1Param.Roi.Row1 = data.DArr[0];
            parametri.Cam5_Foto1Param.Roi.Column1 = data.DArr[1];
            parametri.Cam5_Foto1Param.Roi.Row2 = data.DArr[2];
            parametri.Cam5_Foto1Param.Roi.Column2 = data.DArr[3];
        }

        public ArrayList TestCam5_Foto1_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam5_Step1_Foto1(inputAlg, this.parametri.Cam5_Foto1Param, true, ref res1, ref workingList1);
            };
            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam5_Foto1Complete()
        {
            this.parametri.Cam5_Foto1Param.WizardCompleto = true;
        }

        #endregion CAM5_FOTO1


        #region CAM5_FOTO2

        public void SetAlgCam5_Foto2Enable(bool enable)
        {
            this.parametri.Cam5_Foto2Param.AbilitaControllo = enable;
        }

        public void SetRoiCam5_Foto2(HTuple data)
        {
            if (parametri.Cam5_Foto2Param.Roi == null)
                parametri.Cam5_Foto2Param.Roi = new DataType.Rectangle1Param();
            parametri.Cam5_Foto2Param.Roi.Row1 = data.DArr[0];
            parametri.Cam5_Foto2Param.Roi.Column1 = data.DArr[1];
            parametri.Cam5_Foto2Param.Roi.Row2 = data.DArr[2];
            parametri.Cam5_Foto2Param.Roi.Column2 = data.DArr[3];
        }

        public ArrayList TestCam5_Foto2_Step1Wizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out DataType.ElaborateResult res)
        {
            ArrayList workingList = new ArrayList();
            res = new DataType.ElaborateResult();

            TestWizardBaseDelegate del = (ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res1, ref ArrayList workingList1) =>
            {
                return TestCam5_Step1_Foto2(inputAlg, this.parametri.Cam5_Foto2Param, true, ref res1, ref workingList1);
            };
            TestWizardBase(image, numTest, prevImageData, del, out workingList, out res);

            return workingList;
        }

        public void SetWizarCam5_Foto2Complete()
        {
            this.parametri.Cam5_Foto2Param.WizardCompleto = true;
        }

        #endregion CAM5_FOTO1


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

                    this.imgWizard?.Dispose();
                    this.imgWizard = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AlgoritmoWizard()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}