using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStep5Cam4_Foto1 : TSWizards.BaseExteriorStep
    {

        private const int ROI_MAIN = 1;

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

        private ViewROI.ROIRectangle1 roi = null;

        #endregion Variabili Private

        public UCStep5Cam4_Foto1(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
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

                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);
                this.hWndCtrlManager.SetOnRoiUpdate(OnRoiUpdate);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_INTEGRITA");
                lblDescrizione.Text = "Ingombro condensatore DX";// linguaManager.GetTranslation("LBL_DESCRIZIONE_INTEGRITA");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnLog.Text = linguaManager.GetTranslation("BTN_LOG");

                lblThresholdMax.Text = linguaManager.GetTranslation("LBL_THRESHOLD_RIGHT_CAM2");
                lblDistMax.Text = linguaManager.GetTranslation("LBL_AREA_MAX");
                btnDisegnaRettangolo.Text = linguaManager.GetTranslation("BTN_ROI_RIGHT_CAM2");

                propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
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

        //MODIFY ON NEW STEP
        private void Object2Form(DataType.ParametriAlgoritmo paramAlg)
        {
            DataType.Cam4_Foto1Param param = paramAlg.Cam4_Foto1Param;
            nudThresholdMax.Value = (decimal)param.ThresholdBlueRight;
            nudDistMax.Value = (decimal)param.AreaMaxBlueRight;

            this.roi = new ViewROI.ROIRectangle1();
            this.roi.setModelData(new HalconDotNet.HTuple(param.RectBlueRight.Row1, param.RectBlueRight.Column1, param.RectBlueRight.Row2, param.RectBlueRight.Column2));
            this.hWndCtrlManager.SetRoiWithValue(roi, ROI_MAIN);

            propertyGrid1.SelectedObject = param;
        }

        private void EseguiStep(HalconDotNet.HImage image, DataType.PrevImageData prevImageData)
        {
            if (image != null)
            {
                this.lastTestImage?.Dispose();
                this.lastTestImage = image.CopyImage();
                this.lastPrevImageData = prevImageData;

                ArrayList arrayList = this.algoritmoWizard.TestCam4_Foto1_Step5Wizard(image, 1, prevImageData, out DataType.ElaborateResult res);
                this.hWndCtrlManager.DisplaySetupOutputCamera(arrayList, res);
            }
        }

        private void AddChangeEvent()
        {
            nudThresholdMax.ValueChanged += nud_ValueChanged;
            nudDistMax.ValueChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {

            nudThresholdMax.ValueChanged -= nud_ValueChanged;
            nudDistMax.ValueChanged -= nud_ValueChanged;
        }

        //MODIFY ON NEW STEP
        private void OnRoiUpdate(ViewROI.ROI roi)
        {
            try
            {
                int roiId = roi.getRoiId();

                if (roiId == ROI_MAIN)
                {
                    HalconDotNet.HTuple data = roi.getModelData();
                    this.algoritmoWizard.SetRoiBlueRightCam4_Foto1(data);
                    this.roi = (ViewROI.ROIRectangle1)roi;
                }
            }
            catch (Exception) { }
        }

        #region Eventi form

        private void btnTest_Click(object sender, EventArgs e)
        {
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

        //MODIFY ON NEW STEP
        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.Cam4_Foto1Param param = this.algoritmoWizard.GetAlgoritmoParam().Cam4_Foto1Param;
                param.ThresholdBlueRight = (double)nudThresholdMax.Value;
                param.AreaMaxBlueRight = (double)nudDistMax.Value;

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

        private void btnDisegnaRettangolo_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);
                this.hWndCtrlManager.SetRoi(new ViewROI.ROIRectangle1(), ROI_MAIN);
                this.roi = null;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

    }
}