using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStep1Cam1_Foto2 : TSWizards.BaseExteriorStep
    {

        private const int bigRect_1 = 1;
        private int numRect = 0;

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly int idCamera = -1;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly DataType.Impostazioni impostazioni = null;
        private readonly DBL.LinguaManager linguaManager = null;
        private readonly object repaintLock = null;
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        private HalconDotNet.HImage lastTestImage = null;
        private DataType.PrevImageData lastPrevImageData = null;

        private HalconDotNet.HRegion roi1 = null;
        private HalconDotNet.HRegion roi2 = null;
        private HalconDotNet.HRegion roi3 = null;

        #endregion Variabili Private

        public UCStep1Cam1_Foto2(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock, int numRect)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.idCamera = idCamera;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;
                this.numRect = numRect;
                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);

                // this.hWndCtrlManager.SetOnRoiUpdate(OnRoiUpdate);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_INTEGRITA");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnLog.Text = linguaManager.GetTranslation("BTN_LOG");

                btnDisegnaManoRem.Text = linguaManager.GetTranslation("BTN_GOMMA");
                btnDisegnaManoAdd.Text = linguaManager.GetTranslation("BTN_MANO_LIBERA");
                btnDisegnaManoRem2.Text = linguaManager.GetTranslation("BTN_GOMMA_2");
                btnDisegnaManoAdd2.Text = linguaManager.GetTranslation("BTN_MANO_LIBERA_2");
                btnDisegnaManoRem3.Text = linguaManager.GetTranslation("BTN_GOMMA_3");
                btnDisegnaManoAdd3.Text = linguaManager.GetTranslation("BTN_MANO_LIBERA_3");
                lblThresholdMin.Text = linguaManager.GetTranslation("LBL_THRESHOLD_BLACK");
                lblAreaMax.Text = linguaManager.GetTranslation("LBL_AREA_MAX_BLACK_CAM2");
                lblAreaMin.Text = linguaManager.GetTranslation("LBL_AREA_MIN_BLACK_CAM2");
                lblThresholdMin2.Text = linguaManager.GetTranslation("LBL_THRESHOLD_WHITE");
                lblAreaMax2.Text = linguaManager.GetTranslation("LBL_AREA_MAX_WHITE_CAM2");
                lblAreaMin2.Text = linguaManager.GetTranslation("LBL_AREA_MIN_WHITE_CAM2");
                lblThresholdMin3.Text = linguaManager.GetTranslation("LBL_THRESHOLD_BLACK_2");
                lblAreaMax3.Text = linguaManager.GetTranslation("LBL_AREA_MAX_BLACK_CAM2");
                lblAreaMin3.Text = linguaManager.GetTranslation("LBL_AREA_MIN_BLACK_CAM2");
                btnDrawRect1.Text = linguaManager.GetTranslation("BTN_ROI_1_CAM2");
                chbInvertBlack.Text = linguaManager.GetTranslation("LBL_INVERT_BLACK");
                chbInvertWhite.Text = linguaManager.GetTranslation("LBL_INVERT_WHITE");
                chbInvertBlack2.Text = linguaManager.GetTranslation("LBL_INVERT_BLACK_2");
                chbEnableWhite.Text = linguaManager.GetTranslation("LBL_ENABLE_WHITE");
                chbEnableBlack2.Text = linguaManager.GetTranslation("LBL_ENABLE_BLACK_2");

                //propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
                if (numRect == 1)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_1;
                    lblDescrizione.Text = "Protettore pin 1";
                }
                if (numRect == 2)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_2;
                    lblDescrizione.Text = "Protettore pin 2";
                }
                if (numRect == 3)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_3;
                    lblDescrizione.Text = "Condensatore lat. M. pin 1";
                }
                if (numRect == 4)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_4;
                    lblDescrizione.Text = "Condensatore lat. M. pin 2";
                }
                if (numRect == 5)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_5;
                    lblDescrizione.Text = "Impedenza lat. M.";
                }
                if (numRect == 6)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_6;
                    lblDescrizione.Text = "Varistore pin 1";
                }
                if (numRect == 7)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_7;
                    lblDescrizione.Text = "Varistore pin 2";
                }
                if (numRect == 8)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_8;
                    lblDescrizione.Text = "Condensatore lat. P. pin 1";
                }
                if (numRect == 9)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_9;
                    lblDescrizione.Text = "Condensatore lat. P. pin 2";
                }
                if (numRect == 10)
                {
                    pbImgHelp.BackgroundImage = Properties.Resources.Cam1foto2_10;
                    lblDescrizione.Text = "Impedenza lat. P";
                }

                nud_ValueChanged(null, null);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);
                EseguiStep(image, prevImageData);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo paramAlg)
        {
            DataType.Cam1_Foto2Param param = paramAlg.Cam1_Foto2Param;
            this.roi1 = new HalconDotNet.HRegion();
            this.roi2 = new HalconDotNet.HRegion();
            this.roi3 = new HalconDotNet.HRegion();
            if (numRect == 1)
            {
                chbEnableWhite.Checked = param.checked1;
                chbEnableBlack2.Checked = param.checked1_2;
                chbInvertBlack.Checked = param.invertedBlack1;
                chbInvertWhite.Checked = param.invertedWhite1;
                chbInvertBlack2.Checked = param.invertedBlack1_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_1;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_1;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_1;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_1;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_1;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_1;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_1;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_1;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_1;
                this.roi1 = param.bigRegion_1;
                this.roi2 = param.bigRegion2_1;
                this.roi3 = param.bigRegion3_1;
            }
            if (numRect == 2)
            {
                chbEnableWhite.Checked = param.checked2;
                chbEnableBlack2.Checked = param.checked2_2;
                chbInvertBlack.Checked = param.invertedBlack2;
                chbInvertWhite.Checked = param.invertedWhite2;
                chbInvertBlack2.Checked = param.invertedBlack2_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_2;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_2;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_2;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_2;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_2;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_2;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_2;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_2;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_2;
                this.roi1 = param.bigRegion_2;
                this.roi2 = param.bigRegion2_2;
                this.roi3 = param.bigRegion3_2;
            }
            if (numRect == 3)
            {
                chbEnableWhite.Checked = param.checked3;
                chbEnableBlack2.Checked = param.checked3_2;
                chbInvertBlack.Checked = param.invertedBlack3;
                chbInvertWhite.Checked = param.invertedWhite3;
                chbInvertBlack2.Checked = param.invertedBlack3_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_3;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_3;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_3;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_3;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_3;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_3;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_3;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_3;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_3;
                this.roi1 = param.bigRegion_3;
                this.roi2 = param.bigRegion2_3;
                this.roi3 = param.bigRegion3_3;
            }
            if (numRect == 4)
            {
                chbEnableWhite.Checked = param.checked4;
                chbEnableBlack2.Checked = param.checked4_2;
                chbInvertBlack.Checked = param.invertedBlack4;
                chbInvertWhite.Checked = param.invertedWhite4;
                chbInvertBlack2.Checked = param.invertedBlack4_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_4;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_4;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_4;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_4;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_4;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_4;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_4;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_4;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_4;
                this.roi1 = param.bigRegion_4;
                this.roi2 = param.bigRegion2_4;
                this.roi3 = param.bigRegion3_4;
            }
            if (numRect == 5)
            {
                chbEnableWhite.Checked = param.checked5;
                chbEnableBlack2.Checked = param.checked5_2;
                chbInvertBlack.Checked = param.invertedBlack5;
                chbInvertWhite.Checked = param.invertedWhite5;
                chbInvertBlack2.Checked = param.invertedBlack5_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_5;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_5;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_5;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_5;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_5;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_5;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_5;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_5;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_5;
                this.roi1 = param.bigRegion_5;
                this.roi2 = param.bigRegion2_5;
                this.roi3 = param.bigRegion3_5;
            }
            if (numRect == 6)
            {
                chbEnableWhite.Checked = param.checked6;
                chbEnableBlack2.Checked = param.checked6_2;
                chbInvertBlack.Checked = param.invertedBlack6;
                chbInvertWhite.Checked = param.invertedWhite6;
                chbInvertBlack2.Checked = param.invertedBlack6_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_6;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_6;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_6;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_6;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_6;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_6;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_6;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_6;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_6;
                this.roi1 = param.bigRegion_6;
                this.roi2 = param.bigRegion2_6;
                this.roi3 = param.bigRegion3_6;
            }
            if (numRect == 7)
            {
                chbEnableWhite.Checked = param.checked7;
                chbEnableBlack2.Checked = param.checked7_2;
                chbInvertBlack.Checked = param.invertedBlack7;
                chbInvertWhite.Checked = param.invertedWhite7;
                chbInvertBlack2.Checked = param.invertedBlack7_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_7;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_7;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_7;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_7;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_7;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_7;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_7;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_7;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_7;
                this.roi1 = param.bigRegion_7;
                this.roi2 = param.bigRegion2_7;
                this.roi3 = param.bigRegion3_7;
            }
            if (numRect == 8)
            {
                chbEnableWhite.Checked = param.checked8;
                chbEnableBlack2.Checked = param.checked8_2;
                chbInvertBlack.Checked = param.invertedBlack8;
                chbInvertWhite.Checked = param.invertedWhite8;
                chbInvertBlack2.Checked = param.invertedBlack8_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_8;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_8;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_8;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_8;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_8;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_8;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_8;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_8;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_8;
                this.roi1 = param.bigRegion_8;
                this.roi2 = param.bigRegion2_8;
                this.roi3 = param.bigRegion3_8;
            }
            if (numRect == 9)
            {
                chbEnableWhite.Checked = param.checked9;
                chbEnableBlack2.Checked = param.checked9_2;
                chbInvertBlack.Checked = param.invertedBlack9;
                chbInvertWhite.Checked = param.invertedWhite9;
                chbInvertBlack2.Checked = param.invertedBlack9_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_9;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_9;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_9;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_9;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_9;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_9;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_9;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_9;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_9;
                this.roi1 = param.bigRegion_9;
                this.roi2 = param.bigRegion2_9;
                this.roi3 = param.bigRegion3_9;
            }
            if (numRect == 10)
            {
                chbEnableWhite.Checked = param.checked10;
                chbEnableBlack2.Checked = param.checked10_2;
                chbInvertBlack.Checked = param.invertedBlack10;
                chbInvertWhite.Checked = param.invertedWhite10;
                chbInvertBlack2.Checked = param.invertedBlack10_2;
                nudThresholdBlack.Value = (decimal)param.ThresholdBig_10;
                nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_10;
                nudAreaMinBlack.Value = (decimal)param.AreaMinBig_10;
                nudThresholdWhite.Value = (decimal)param.ThresholdBig2_10;
                nudAreaMaxWhite.Value = (decimal)param.AreaMAxBig2_10;
                nudAreaMinWhite.Value = (decimal)param.AreaMinBig2_10;
                nudThresholdBlack2.Value = (decimal)param.ThresholdBig3_10;
                nudAreaMaxBlack2.Value = (decimal)param.AreaMAxBig3_10;
                nudAreaMinBlack2.Value = (decimal)param.AreaMinBig3_10;
                this.roi1 = param.bigRegion_10;
                this.roi2 = param.bigRegion2_10;
                this.roi3 = param.bigRegion3_10;
            }

            if(chbEnableWhite.Checked)
            {
                lblThresholdMin2.Enabled = true;
                nudThresholdWhite.Enabled = true;
                lblAreaMax2.Enabled = true;
                nudAreaMaxWhite.Enabled = true;
                lblAreaMin2.Enabled = true;
                nudAreaMinWhite.Enabled = true;
                btnDisegnaManoAdd2.Enabled = true;
                btnDisegnaManoRem2.Enabled = true;
                chbInvertWhite.Enabled = true;
            }

            if (chbEnableBlack2.Checked)
            {
                lblThresholdMin3.Enabled = true;
                nudThresholdBlack2.Enabled = true;
                lblAreaMax3.Enabled = true;
                nudAreaMaxBlack.Enabled = true;
                lblAreaMin3.Enabled = true;
                nudAreaMinBlack2.Enabled = true;
                btnDisegnaManoAdd3.Enabled = true;
                btnDisegnaManoRem3.Enabled = true;
                chbInvertBlack2.Enabled = true;
            }

            this.hWndCtrlManager.SetMask(roi1, 0);
            this.hWndCtrlManager.SetMask(roi2, 1);
            this.hWndCtrlManager.SetMask(roi3, 2);

            //this.roi1 = new ViewROI.ROIRectangle1();
            //this.roi1.setModelData(new HalconDotNet.HTuple(param.bigRect_1.Row1, param.bigRect_1.Column1, param.bigRect_1.Row2, param.bigRect_1.Column2));
            //this.hWndCtrlManager.SetRoiWithValueNoReset(roi1, bigRect_1);

            //propertyGrid1.SelectedObject = param;
        }

        private void EseguiStep(HalconDotNet.HImage image, DataType.PrevImageData prevImageData)
        {
            if (image != null)
            {
                this.lastTestImage?.Dispose();
                this.lastTestImage = image.CopyImage();
                this.lastPrevImageData = prevImageData;

                ArrayList arrayList = new ArrayList();
                DataType.ElaborateResult res = new DataType.ElaborateResult();
                
                if (numRect == 1)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step1Wizard(image, 2, prevImageData, out res);
                if (numRect == 2)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step2Wizard(image, 2, prevImageData, out res);
                if (numRect == 3)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step3Wizard(image, 2, prevImageData, out res);
                if (numRect == 4)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step4Wizard(image, 2, prevImageData, out res);
                if (numRect == 5)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step5Wizard(image, 2, prevImageData, out res);
                if (numRect == 6)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step6Wizard(image, 2, prevImageData, out res);
                if (numRect == 7)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step7Wizard(image, 2, prevImageData, out res);
                if (numRect == 8)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step8Wizard(image, 2, prevImageData, out res);
                if (numRect == 9)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step9Wizard(image, 2, prevImageData, out res);
                if (numRect == 10)
                    arrayList = this.algoritmoWizard.TestCam1_Foto2_Step10Wizard(image, 2, prevImageData, out res);

                this.hWndCtrlManager.DisplaySetupOutputCamera(arrayList, res);
            }
        }

        private void AddChangeEvent()
        {
            nudThresholdBlack.ValueChanged += nud_ValueChanged;
            nudAreaMaxBlack.ValueChanged += nud_ValueChanged;
            nudAreaMinBlack.ValueChanged += nud_ValueChanged;
            nudThresholdWhite.ValueChanged += nud_ValueChanged;
            nudAreaMaxWhite.ValueChanged += nud_ValueChanged;
            nudAreaMinWhite.ValueChanged += nud_ValueChanged;
            nudThresholdBlack2.ValueChanged += nud_ValueChanged;
            nudAreaMaxBlack2.ValueChanged += nud_ValueChanged;
            nudAreaMinBlack2.ValueChanged += nud_ValueChanged;
            chbEnableWhite.CheckedChanged += nud_ValueChanged;
            chbEnableBlack2.CheckedChanged += nud_ValueChanged;
            chbInvertBlack.CheckedChanged += nud_ValueChanged;
            chbInvertWhite.CheckedChanged += nud_ValueChanged;
            chbInvertBlack2.CheckedChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudThresholdBlack.ValueChanged -= nud_ValueChanged;
            nudAreaMaxBlack.ValueChanged -= nud_ValueChanged;
            nudAreaMinBlack.ValueChanged -= nud_ValueChanged;
            nudThresholdWhite.ValueChanged -= nud_ValueChanged;
            nudAreaMaxWhite.ValueChanged -= nud_ValueChanged;
            nudAreaMinWhite.ValueChanged -= nud_ValueChanged;
            nudThresholdBlack2.ValueChanged -= nud_ValueChanged;
            nudAreaMaxBlack2.ValueChanged -= nud_ValueChanged;
            nudAreaMinBlack2.ValueChanged -= nud_ValueChanged;
            chbEnableWhite.CheckedChanged -= nud_ValueChanged;
            chbEnableBlack2.CheckedChanged -= nud_ValueChanged;
            chbInvertBlack.CheckedChanged -= nud_ValueChanged;
            chbInvertWhite.CheckedChanged -= nud_ValueChanged;
            chbInvertBlack2.CheckedChanged -= nud_ValueChanged;
        }

        #region Eventi form

        private void btnTest_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            this.roi1 = this.hWndCtrlManager.GetMask(0);
            this.roi2 = this.hWndCtrlManager.GetMask(1);
            this.roi3 = this.hWndCtrlManager.GetMask(2);
            try
            {
                if (roi1 != null && hWndCtrlManager.GetBlackWhite() == 0)
                {
                    if (numRect == 1)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_1(roi1);

                    if (numRect == 2)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_2(roi1);

                    if (numRect == 3)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_3(roi1);

                    if (numRect == 4)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_4(roi1);

                    if (numRect == 5)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_5(roi1);

                    if (numRect == 6)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_6(roi1);

                    if (numRect == 7)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_7(roi1);

                    if (numRect == 8)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_8(roi1);

                    if (numRect == 9)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_9(roi1);

                    if (numRect == 10)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_10(roi1);
                }
                else if (roi2 != null && hWndCtrlManager.GetBlackWhite() == 1)
                {
                    if (numRect == 1)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_1(roi2, 1);

                    if (numRect == 2)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_2(roi2, 1);

                    if (numRect == 3)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_3(roi2, 1);

                    if (numRect == 4)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_4(roi2, 1);

                    if (numRect == 5)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_5(roi2, 1);

                    if (numRect == 6)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_6(roi2, 1);

                    if (numRect == 7)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_7(roi2, 1);

                    if (numRect == 8)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_8(roi2, 1);

                    if (numRect == 9)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_9(roi2, 1);

                    if (numRect == 10)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_10(roi2, 1);
                }
                else if (roi3 != null)
                {
                    if (numRect == 1)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_1(roi3, 2);

                    if (numRect == 2)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_2(roi3, 2);

                    if (numRect == 3)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_3(roi3, 2);

                    if (numRect == 4)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_4(roi3, 2);

                    if (numRect == 5)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_5(roi3, 2);

                    if (numRect == 6)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_6(roi3, 2);

                    if (numRect == 7)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_7(roi3, 2);

                    if (numRect == 8)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_8(roi3, 2);

                    if (numRect == 9)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_9(roi3, 2);

                    if (numRect == 10)
                        this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_10(roi3, 2);
                }

                image = this.lastTestImage.Clone();
                EseguiStep(image, this.lastPrevImageData);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.appManager?.Snap();
                btnUltimaFoto_Click(this, null);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnUltimaFoto_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                image = this.core.GetLastGrabImage(out DataType.PrevImageData prevImageData);
                EseguiStep(image, prevImageData);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                FormScegliImgLog f = new FormScegliImgLog(this.appManager, this.idCamera, this.impostazioni, this.linguaManager, this.repaintLock);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    image = f.GetImage(out DataType.PrevImageData prevImageData);
                    EseguiStep(image, prevImageData);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.Cam1_Foto2Param param = this.algoritmoWizard.GetAlgoritmoParam().Cam1_Foto2Param;

                if (numRect == 1)
                {
                    param.AreaMinBig_1 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_1 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_1 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_1 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_1 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_1 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_1 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_1 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_1 = (double)nudThresholdBlack.Value;
                    param.checked1 = chbEnableWhite.Checked;
                    param.checked1_2 = chbEnableBlack2.Checked;
                    param.invertedBlack1 = chbInvertBlack.Checked;
                    param.invertedWhite1 = chbInvertWhite.Checked;
                    param.invertedBlack1_2 = chbInvertBlack.Checked;
                }

                if (numRect == 2)
                {
                    param.AreaMinBig_2 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_2 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_2 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_2 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_2 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_2 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_2 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_2 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_2 = (double)nudThresholdBlack.Value;
                    param.checked2 = chbEnableWhite.Checked;
                    param.checked2_2 = chbEnableBlack2.Checked;
                    param.invertedBlack2 = chbInvertBlack.Checked;
                    param.invertedWhite2 = chbInvertWhite.Checked;
                    param.invertedBlack2_2 = chbInvertBlack.Checked;
                }
                if (numRect == 3)
                {
                    param.AreaMinBig_3 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_3 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_3 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_3 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_3 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_3 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_3 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_3 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_3 = (double)nudThresholdBlack.Value;
                    param.checked3 = chbEnableWhite.Checked;
                    param.checked3_2 = chbEnableBlack2.Checked;
                    param.invertedBlack3 = chbInvertBlack.Checked;
                    param.invertedWhite3 = chbInvertWhite.Checked;
                    param.invertedBlack3_2 = chbInvertBlack.Checked;
                }
                if (numRect == 4)
                {
                    param.AreaMinBig_4 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_4 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_4 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_4 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_4 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_4 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_4 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_4 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_4 = (double)nudThresholdBlack.Value;
                    param.checked4 = chbEnableWhite.Checked;
                    param.checked4_2 = chbEnableBlack2.Checked;
                    param.invertedBlack4 = chbInvertBlack.Checked;
                    param.invertedWhite4 = chbInvertWhite.Checked;
                    param.invertedBlack4_2 = chbInvertBlack.Checked;
                }
                if (numRect == 5)
                {
                    param.AreaMinBig_5 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_5 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_5 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_5 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_5 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_5 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_5 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_5 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_5 = (double)nudThresholdBlack.Value;
                    param.checked5 = chbEnableWhite.Checked;
                    param.checked5_2 = chbEnableBlack2.Checked;
                    param.invertedBlack5 = chbInvertBlack.Checked;
                    param.invertedWhite5 = chbInvertWhite.Checked;
                    param.invertedBlack5_2 = chbInvertBlack.Checked;
                }
                if (numRect == 6)
                {
                    param.AreaMinBig_6 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_6 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_6 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_6 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_6 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_6 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_6 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_6 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_6 = (double)nudThresholdBlack.Value;
                    param.checked6 = chbEnableWhite.Checked;
                    param.checked6_2 = chbEnableBlack2.Checked;
                    param.invertedBlack6 = chbInvertBlack.Checked;
                    param.invertedWhite6 = chbInvertWhite.Checked;
                    param.invertedBlack6_2 = chbInvertBlack.Checked;
                }
                if (numRect == 7)
                {
                    param.AreaMinBig_7 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_7 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_7 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_7 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_7 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_7 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_7 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_7 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_7 = (double)nudThresholdBlack.Value;
                    param.checked7 = chbEnableWhite.Checked;
                    param.checked7_2 = chbEnableBlack2.Checked;
                    param.invertedBlack7 = chbInvertBlack.Checked;
                    param.invertedWhite7 = chbInvertWhite.Checked;
                    param.invertedBlack7_2 = chbInvertBlack.Checked;
                }
                if (numRect == 8)
                {
                    param.AreaMinBig_8 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_8 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_8 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_8 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_8 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_8 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_8 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_8 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_8 = (double)nudThresholdBlack.Value;
                    param.checked8 = chbEnableWhite.Checked;
                    param.checked8_2 = chbEnableBlack2.Checked;
                    param.invertedBlack8 = chbInvertBlack.Checked;
                    param.invertedWhite8 = chbInvertWhite.Checked;
                    param.invertedBlack8_2 = chbInvertBlack.Checked;
                }
                if (numRect == 9)
                {
                    param.AreaMinBig_9 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_9 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_9 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_9 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_9 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_9 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_9 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_9 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_9 = (double)nudThresholdBlack.Value;
                    param.checked9 = chbEnableWhite.Checked;
                    param.checked9_2 = chbEnableBlack2.Checked;
                    param.invertedBlack9 = chbInvertBlack.Checked;
                    param.invertedWhite9 = chbInvertWhite.Checked;
                    param.invertedBlack9_2 = chbInvertBlack.Checked;
                }
                if (numRect == 10)
                {
                    param.AreaMinBig_10 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig_10 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig_10 = (double)nudThresholdBlack.Value;
                    param.AreaMinBig2_10 = (double)nudAreaMinWhite.Value;
                    param.AreaMAxBig2_10 = (double)nudAreaMaxWhite.Value;
                    param.ThresholdBig2_10 = (double)nudThresholdWhite.Value;
                    param.AreaMinBig3_10 = (double)nudAreaMinBlack.Value;
                    param.AreaMAxBig3_10 = (double)nudAreaMaxBlack.Value;
                    param.ThresholdBig3_10 = (double)nudThresholdBlack.Value;
                    param.checked10 = chbEnableWhite.Checked;
                    param.checked10_2 = chbEnableBlack2.Checked;
                    param.invertedBlack10 = chbInvertBlack.Checked;
                    param.invertedWhite10 = chbInvertWhite.Checked;
                    param.invertedBlack10_2 = chbInvertBlack.Checked;
                }
                
                if (!chbEnableWhite.Checked)
                {
                    this.hWndCtrlManager.ClearMask(roi2, 1);
                    this.hWndCtrlManager.SetBlackWhite(0);
                    this.hWndCtrlManager.DisplayMask();
                }


                if (!chbEnableBlack2.Checked)
                {
                    this.hWndCtrlManager.ClearMask(roi3, 2);
                    this.hWndCtrlManager.SetBlackWhite(0);
                    this.hWndCtrlManager.DisplayMask();
                }

                lblThresholdMin2.Enabled = chbEnableWhite.Checked;
                nudThresholdWhite.Enabled = chbEnableWhite.Checked;
                lblAreaMax2.Enabled = chbEnableWhite.Checked;
                nudAreaMaxWhite.Enabled = chbEnableWhite.Checked;
                lblAreaMin2.Enabled = chbEnableWhite.Checked;
                nudAreaMinWhite.Enabled = chbEnableWhite.Checked;
                btnDisegnaManoAdd2.Enabled = chbEnableWhite.Checked;
                btnDisegnaManoRem2.Enabled = chbEnableWhite.Checked;
                chbInvertWhite.Enabled = chbEnableWhite.Checked;

                lblThresholdMin2.Visible = chbEnableWhite.Checked;
                nudThresholdWhite.Visible = chbEnableWhite.Checked;
                lblAreaMax2.Visible = chbEnableWhite.Checked;
                nudAreaMaxWhite.Visible = chbEnableWhite.Checked;
                lblAreaMin2.Visible = chbEnableWhite.Checked;
                nudAreaMinWhite.Visible = chbEnableWhite.Checked;
                btnDisegnaManoAdd2.Visible = chbEnableWhite.Checked;
                btnDisegnaManoRem2.Visible = chbEnableWhite.Checked;
                chbInvertWhite.Visible = chbEnableWhite.Checked;

                lblThresholdMin3.Enabled = chbEnableBlack2.Checked;
                nudThresholdBlack2.Enabled = chbEnableBlack2.Checked;
                lblAreaMax3.Enabled = chbEnableBlack2.Checked;
                nudAreaMaxBlack2.Enabled = chbEnableBlack2.Checked;
                lblAreaMin3.Enabled = chbEnableBlack2.Checked;
                nudAreaMinBlack2.Enabled = chbEnableBlack2.Checked;
                btnDisegnaManoAdd3.Enabled = chbEnableBlack2.Checked;
                btnDisegnaManoRem3.Enabled = chbEnableBlack2.Checked;
                chbInvertBlack2.Enabled = chbEnableBlack2.Checked;

                lblThresholdMin3.Visible = chbEnableBlack2.Checked;
                nudThresholdBlack2.Visible = chbEnableBlack2.Checked;
                lblAreaMax3.Visible = chbEnableBlack2.Checked;
                nudAreaMaxBlack2.Visible = chbEnableBlack2.Checked;
                lblAreaMin3.Visible = chbEnableBlack2.Checked;
                nudAreaMinBlack2.Visible = chbEnableBlack2.Checked;
                btnDisegnaManoAdd3.Visible = chbEnableBlack2.Checked;
                btnDisegnaManoRem3.Visible = chbEnableBlack2.Checked;
                chbInvertBlack2.Visible = chbEnableBlack2.Checked;

                HalconDotNet.HImage image = null;
                try
                {
                    image = this.lastTestImage.Clone();
                    EseguiStep(image, this.lastPrevImageData);
                }
                catch (Exception ex)
                {
                    Class.ExceptionManager.AddException(ex);
                }
                finally
                {
                    image?.Dispose();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDrawRect1_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

                this.hWndCtrlManager.SetRoiNoReset(new ViewROI.ROIRectangle1(), bigRect_1);
                this.roi1 = this.hWndCtrlManager.GetMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

        bool draw = false;
        bool erase = false;

        private void btnDisegnaManoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetBlackWhite(0);
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Brush);
                this.hWndCtrlManager.SetMask(roi1, 0);
                draw = true;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetBlackWhite(1);
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Brush);
                this.hWndCtrlManager.SetMask(roi2, 1);
                draw = true;
                erase = false;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoAdd3_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetBlackWhite(2);
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Brush);
                this.hWndCtrlManager.SetMask(roi3, 2);
                draw = true;
                erase = false;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoRem_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Rubber);
                this.hWndCtrlManager.SetBlackWhite(0);
                erase = true;
                draw = false;
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoRem2_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Rubber);
                this.hWndCtrlManager.SetBlackWhite(1);
                erase = true;
                draw = false;
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoRem3_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Rubber);
                this.hWndCtrlManager.SetBlackWhite(2);
                erase = true;
                draw = false;
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }
    }
}