﻿using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGS.Wizard
{
    public partial class UCStepRoiMain : TSWizards.BaseExteriorStep
    {

        private const int ROI_MAIN = 1;

        #region Variabili Private

        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly DBL.LinguaManager linguaManager = null;
        private readonly object repaintLock = null;
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        private ViewROI.ROIRectangle1 roi = null;

        #endregion Variabili Private

        public UCStepRoiMain(Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;

                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);
                this.hWndCtrlManager.SetOnRoiUpdate(OnRoiUpdate);

                if (modifica)
                    Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                Description.Text = linguaManager.GetTranslation("LBL_STEP_ROI_MAIN");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_ROI_MAIN");

                btnDisegnaRettangolo.Text = linguaManager.GetTranslation("BTN_ROI_MAIN");
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            this.core.SetAlgorithm(this.algoritmoWizard.NOPAlgorithm);
            this.core.SetNewImageToDisplayEvent(OnNewImage);

            this.core.Run();

            EseguiStepImgWizard();

            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            if (this.roi == null)
            {
                MessageBox.Show(linguaManager.GetTranslation("MSG_ROI_MAIN_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                this.core.StopAndWaitEnd(true);
            }

            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo param)
        {
            this.roi = new ViewROI.ROIRectangle1();
            this.roi.setModelData(new HalconDotNet.HTuple(param.RoiMain.Row1, param.RoiMain.Column1, param.RoiMain.Row2, param.RoiMain.Column2));
            this.hWndCtrlManager.SetRoiWithValue(roi, ROI_MAIN);
        }

        private DataType.ParametriAlgoritmo Form2Object()
        {
            DataType.ParametriAlgoritmo ret = this.algoritmoWizard.GetAlgoritmoParam();

            return ret;
        }

        public void OnNewImage(int numCamera, int numTest, ArrayList iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => { OnNewImage(numCamera, numTest, iconicVarList, result); }));
                }
                else
                {
                    this.hWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, null);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void OnRoiUpdate(ViewROI.ROI roi)
        {
            try
            {
                int roiId = roi.getRoiId();

                if (roiId == ROI_MAIN)
                {
                    HalconDotNet.HTuple data = roi.getModelData();
                    this.algoritmoWizard.SetRoiMain(data);
                    this.roi = (ViewROI.ROIRectangle1)roi;
                }
            }
            catch (Exception) { }
        }

        private void EseguiStepImgWizard()
        {
            HalconDotNet.HImage image = null;
            try
            {
                image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);
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

        #region Eventi form

        private void btnDisegnaRettangolo_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

                //if (this.roi != null)
                //    this.hWndCtrlManager.SetRoiWithValue(this.roi, ROI_MAIN);
                //else
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