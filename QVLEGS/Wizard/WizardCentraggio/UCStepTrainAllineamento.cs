using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGS.Wizard
{
    public partial class UCStepTrainAllineamento : TSWizards.BaseExteriorStep
    {

        private const int ROI_TRAIN = 1;

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly DBL.LinguaManager linguaManager = null;
        private readonly object repaintLock = null;
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        private ViewROI.ROIRectangle1 roi = null;

        private bool stepOk = false;

        #endregion Variabili Private

        public UCStepTrainAllineamento(Class.AppManager appManager, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;

                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);
                this.hWndCtrlManager.SetOnRoiUpdate(OnRoiUpdate);

                if (modifica)
                {
                    Object2Form(this.algoritmoWizard.GetAlgoritmoParam());
                    stepOk = true;
                }

                VisualizzaControlli();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_TRAIN_ALLINEAMENTO");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_TRAIN_ALLINEAMENTO");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnTrain.Text = linguaManager.GetTranslation("BTN_TRAIN");

                btnDisegnaManoAdd.Text = linguaManager.GetTranslation("BTN_MANO_LIBERA");
                btnDisegnaManoRem.Text = linguaManager.GetTranslation("BTN_GOMMA");

                btnDisegnaRettangolo.Text = linguaManager.GetTranslation("BTN_ROI_TRAIN");

                AddChangeEvent();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            this.hWndCtrlManager.DisplayModelGraphics(this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData));
            this.hWndCtrlManager.DisplayMask();

            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            if (stepOk == false)
            {
                MessageBox.Show(linguaManager.GetTranslation("MSG_TRAIN_ALLINEAMENTO_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo param)
        {
            this.roi = new ViewROI.ROIRectangle1();
            this.roi.setModelData(new HalconDotNet.HTuple(param.AllineamentoParam.RoiModel.Row1
                    , param.AllineamentoParam.RoiModel.Column1
                    , param.AllineamentoParam.RoiModel.Row2
                    , param.AllineamentoParam.RoiModel.Column2));
            this.hWndCtrlManager.SetRoiWithValue(roi, ROI_TRAIN);

            pbImgHelp.BackgroundImage = Properties.Resources.centraggioShape;

            this.hWndCtrlManager.SetMask(this.algoritmoWizard.GetRegionTrainShape());
        }

        private void OnRoiUpdate(ViewROI.ROI roi)
        {
            try
            {
                int roiId = roi.getRoiId();

                if (roiId == ROI_TRAIN)
                {
                    this.roi = (ViewROI.ROIRectangle1)roi;
                }
            }
            catch (Exception) { }
        }

        private void AddChangeEvent()
        {

        }

        private void RemoveChangeEvent()
        {

        }

        private void VisualizzaControlli()
        {
            bool visShape = true;
            btnDisegnaManoAdd.Visible = visShape;
            btnDisegnaManoRem.Visible = visShape;
            trackBarDimensione.Visible = visShape;

            pbImgHelp.BackgroundImage = Properties.Resources.centraggioShape;
        }

        #region Eventi form

        private void btnTest_Click(object sender, EventArgs e)
        {

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
                if (image != null)
                {
                    this.hWndCtrlManager.DisplayModelGraphics(image.CopyImage());
                    this.algoritmoWizard.SetWizardImage(image, prevImageData);
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

        private void btnTrain_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                if (this.roi != null)
                {
                    image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);

                    ArrayList shapeModelList = null;
                    bool ok = false;

                    this.algoritmoWizard.SetRegionTrainAllineamento(this.roi.getModelData(), this.hWndCtrlManager.GetMask());

                    // imposto l'area scelta 
                    shapeModelList = this.algoritmoWizard.SetAllineamentoShape(image, true, out ok);

                    stepOk = ok;

                    this.hWndCtrlManager.DisplaySetupOutputCamera(shapeModelList, null);
                }
                else
                {
                    MessageBox.Show(linguaManager.GetTranslation("MSG_TRAIN_ALLINEAMENTO_ROI_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDisegnaManoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Brush);
                this.hWndCtrlManager.DisplayMask();
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
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void trackBarDimensione_Scroll(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.SetBrushRubberSize(trackBarDimensione.Value);
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
                this.hWndCtrlManager.SetRoi(new ViewROI.ROIRectangle1(), ROI_TRAIN);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

    }
}