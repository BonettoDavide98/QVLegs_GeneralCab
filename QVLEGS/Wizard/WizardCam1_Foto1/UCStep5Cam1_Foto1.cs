using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStep5Cam1_Foto1 : TSWizards.BaseExteriorStep
    {

        private const int ROI_MAIN1 = 1;

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

        private ViewROI.ROIRectangle2 roi1 = null;

        #endregion Variabili Private

        public UCStep5Cam1_Foto1(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
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

                lblThreshold.Text = linguaManager.GetTranslation("LBL_THRESHOLD_LEFT_CAM2");
                lblDistMaxLeft.Text = linguaManager.GetTranslation("LBL_DIST_MIN");
                lblDistMaxRight.Text = linguaManager.GetTranslation("LBL_DIST_MAX");
                btnDrawRect.Text = linguaManager.GetTranslation("BTN_ROI_RECT");

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
            DataType.Cam1_Foto1Param param = paramAlg.Cam1_Foto1Param;
            nudThreshold.Value = (decimal)param.ThresholdRectangle;
            nudMaxDistLeft.Value = (decimal)param.DistMinRectangle;
            nudMaxDistRight.Value = (decimal)param.DistMaxRectangle;

            this.roi1 = new ViewROI.ROIRectangle2();
            this.roi1.setModelData(new HalconDotNet.HTuple(param.RoiCalliper.Row, param.RoiCalliper.Column, param.RoiCalliper.Angle, param.RoiCalliper.Length1, param.RoiCalliper.Length2));
            this.hWndCtrlManager.SetRoiWithValueNoReset(roi1, ROI_MAIN1);


            this.hWndCtrlManager.SetRoiWithValue(roi1, ROI_MAIN1);

            propertyGrid1.SelectedObject = param;
        }

        private void EseguiStep(HalconDotNet.HImage image, DataType.PrevImageData prevImageData)
        {
            if (image != null)
            {
                this.lastTestImage?.Dispose();
                this.lastTestImage = image.CopyImage();
                this.lastPrevImageData = prevImageData;

                ArrayList arrayList = this.algoritmoWizard.TestCam1_Foto1_Step5Wizard(image, 1, prevImageData, out DataType.ElaborateResult res);
                this.hWndCtrlManager.DisplaySetupOutputCamera(arrayList, res);
            }
        }

        private void AddChangeEvent()
        {
            nudThreshold.ValueChanged += nud_ValueChanged;
            nudMaxDistLeft.ValueChanged += nud_ValueChanged;
            nudMaxDistRight.ValueChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {

            nudThreshold.ValueChanged -= nud_ValueChanged;
            nudMaxDistLeft.ValueChanged -= nud_ValueChanged;
            nudMaxDistRight.ValueChanged -= nud_ValueChanged;
        }

        private void OnRoiUpdate(ViewROI.ROI roi)
        {
            try
            {
                int roiId = roi.getRoiId();

                HalconDotNet.HTuple data = roi.getModelData();
                if (roiId == ROI_MAIN1)
                {
                    this.algoritmoWizard.SetRoiCam1_Foto1_Rect(data);
                    this.roi1 = (ViewROI.ROIRectangle2)roi;
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
                DataType.Cam1_Foto1Param param = this.algoritmoWizard.GetAlgoritmoParam().Cam1_Foto1Param;
                param.ThresholdRectangle = (double)nudThreshold.Value;
                param.DistMaxRectangle = (double)nudMaxDistRight.Value;
                param.DistMinRectangle = (double)nudMaxDistLeft.Value;

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

        private void btnDrawCircle1_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

                this.hWndCtrlManager.SetRoiWithValue(new ViewROI.ROIRectangle2(), ROI_MAIN1);


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