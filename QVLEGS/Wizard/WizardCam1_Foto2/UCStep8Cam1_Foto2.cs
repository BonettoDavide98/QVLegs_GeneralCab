﻿using HalconDotNet;
using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStep8Cam1_Foto2 : TSWizards.BaseExteriorStep
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

        private HRegion roi1 = null;

        #endregion Variabili Private

        public UCStep8Cam1_Foto2(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
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
                // this.hWndCtrlManager.SetOnRoiUpdate(OnRoiUpdate);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_INTEGRITA");
                lblDescrizione.Text = "Condensatore lat. P. pin 1";// linguaManager.GetTranslation("LBL_DESCRIZIONE_INTEGRITA");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnLog.Text = linguaManager.GetTranslation("BTN_LOG");

                lblThresholdMin.Text = linguaManager.GetTranslation("LBL_THRESHOLD_BLACK");
                lblAreaMax.Text = linguaManager.GetTranslation("LBL_AREA_MAX_BLACK_CAM2");
                lblAreaMin.Text = linguaManager.GetTranslation("LBL_AREA_MIN_BLACK_CAM2");
                btnDrawRect1.Text = linguaManager.GetTranslation("BTN_ROI_8_CAM2");

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
            nudThresholdBlack.Value = (decimal)param.ThresholdBig_8;
            nudAreaMaxBlack.Value = (decimal)param.AreaMAxBig_8;
            nudAreaMinBlack.Value = (decimal)param.AreaMinBig_8;

            this.roi1 = new HRegion();
            this.roi1 = param.bigRegion_8;
            this.hWndCtrlManager.SetMask(roi1);

            propertyGrid1.SelectedObject = param;
        }

        private void EseguiStep(HalconDotNet.HImage image, DataType.PrevImageData prevImageData)
        {
            if (image != null)
            {
                this.lastTestImage?.Dispose();
                this.lastTestImage = image.CopyImage();
                this.lastPrevImageData = prevImageData;

                ArrayList arrayList = this.algoritmoWizard.TestCam1_Foto2_Step8Wizard(image, 2, prevImageData, out DataType.ElaborateResult res);
                this.hWndCtrlManager.DisplaySetupOutputCamera(arrayList, res);
            }
        }

        private void AddChangeEvent()
        {
            nudThresholdBlack.ValueChanged += nud_ValueChanged;
            nudAreaMaxBlack.ValueChanged += nud_ValueChanged;
            nudAreaMinBlack.ValueChanged += nud_ValueChanged;

        }

        private void RemoveChangeEvent()
        {

            nudThresholdBlack.ValueChanged -= nud_ValueChanged;
            nudAreaMaxBlack.ValueChanged -= nud_ValueChanged;
            nudAreaMinBlack.ValueChanged -= nud_ValueChanged;

        }

        private void OnRoiUpdate(HRegion roi)
        {
            try
            {
                this.algoritmoWizard.SetRoiCam1_Foto2_BigRec_8(roi1);
                this.roi1 = roi;
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
                param.AreaMinBig_8 = (double)nudAreaMinBlack.Value;
                param.AreaMAxBig_8 = (double)nudAreaMaxBlack.Value;
                param.ThresholdBig_8 = (double)nudThresholdBlack.Value;

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