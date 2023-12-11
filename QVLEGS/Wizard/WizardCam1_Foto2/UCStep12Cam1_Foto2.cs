using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStep12Cam1_Foto2 : TSWizards.BaseExteriorStep
    {

        private const int bigRect_1 = 1;
         
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

        private ViewROI.ROIRectangle1 roi1 = null;

        #endregion Variabili Private

        public UCStep12Cam1_Foto2(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
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
                lblDescrizione.Text = "";// linguaManager.GetTranslation("LBL_DESCRIZIONE_INTEGRITA");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnLog.Text = linguaManager.GetTranslation("BTN_LOG");

                lblThresholdMin.Text = linguaManager.GetTranslation("LBL_THRESHOLD_BLACK");
                lblAreaMax.Text = linguaManager.GetTranslation("LBL_AREA_MAX_BLACK_CAM2");
                lblAreaMin.Text = linguaManager.GetTranslation("LBL_AREA_MIN_BLACK_CAM2");
                btnDrawRect1.Text = linguaManager.GetTranslation("BTN_ROI_2_CAM2");

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

        private void Object2Form(DataType.ParametriAlgoritmo paramAlg)
        {
            DataType.Cam1_Foto2Param param = paramAlg.Cam1_Foto2Param;
            ucCheckbox1.Checked = param.Hole_2;
            nudAreaMaxBlack.Value = (decimal)param.AreaMAxSmall_2;
            nudAreaMinBlack.Value = (decimal)param.AreaMinSmall_2;

            this.roi1 = new ViewROI.ROIRectangle1();
            this.roi1.setModelData(new HalconDotNet.HTuple(param.smallRect_2.Row1, param.smallRect_2.Column1, param.smallRect_2.Row2, param.smallRect_2.Column2));
            this.hWndCtrlManager.SetRoiWithValueNoReset(roi1, bigRect_1);

            propertyGrid1.SelectedObject = param;
        }

        private void EseguiStep(HalconDotNet.HImage image, DataType.PrevImageData prevImageData)
        {
            if (image != null)
            {
                this.lastTestImage?.Dispose();
                this.lastTestImage = image.CopyImage();
                this.lastPrevImageData = prevImageData;

                ArrayList arrayList = this.algoritmoWizard.TestCam1_Foto2_Step12Wizard(image, 2, prevImageData, out DataType.ElaborateResult res);
                this.hWndCtrlManager.DisplaySetupOutputCamera(arrayList, res);
            }
        }

        private void AddChangeEvent()
        {
            nudAreaMaxBlack.ValueChanged += nud_ValueChanged;
            nudAreaMinBlack.ValueChanged += nud_ValueChanged;
            ucCheckbox1.CheckboxClicked += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {

            nudAreaMaxBlack.ValueChanged -= nud_ValueChanged;
            nudAreaMinBlack.ValueChanged -= nud_ValueChanged;
            ucCheckbox1.CheckboxClicked -= nud_ValueChanged;
        }

        private void OnRoiUpdate(ViewROI.ROI roi)
        {
            try
            {
                int roiId = roi.getRoiId();

                HalconDotNet.HTuple data = roi.getModelData();
                if (roiId == bigRect_1)
                {
                    this.algoritmoWizard.SetRoiCam1_Foto2_SmallRec_2(data);
                    this.roi1 = (ViewROI.ROIRectangle1)roi;
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

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.Cam1_Foto2Param param = this.algoritmoWizard.GetAlgoritmoParam().Cam1_Foto2Param;
                param.AreaMinSmall_2 = (double)nudAreaMinBlack.Value;
                param.AreaMinSmall_2 = (double)nudAreaMaxBlack.Value;
                param.Hole_2 = ucCheckbox1.Checked;

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
                this.roi1 = null;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

    }
}