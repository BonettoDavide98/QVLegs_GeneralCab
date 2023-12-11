using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStepAcq : TSWizards.BaseExteriorStep
    {

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly int numTest = -1;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly object repaintLock = null;
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        private bool modifica = false;

        #endregion Variabili Private

        public UCStepAcq(Class.AppManager appManager, int numTest, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.numTest = numTest;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.repaintLock = repaintLock;
                this.modifica = modifica;

                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                if (!modifica)
                {
                    try
                    {
                        nudExpo.Value = (decimal)this.core.GetFrameGrabberManager().GetExpo();
                        nudGain.Value = (decimal)this.core.GetFrameGrabberManager().GetGain();
                    }
                    catch (Exception) { }
                }

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_ACQ");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_ACQ");

                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                lblExpo.Text = linguaManager.GetTranslation("LBL_EXPO");
                lblGain.Text = linguaManager.GetTranslation("LBL_GAIN");

                propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
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
            this.core.StopAndWaitEnd(true);

            if (!modifica)
            {
                HalconDotNet.HImage image = null;
                try
                {
                    image = this.core.GetLastGrabImage(out DataType.PrevImageData prevImageData);
                    if (image != null)
                    {
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

            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo param)
        {
            nudExpo.Value = (decimal)param.Expo;
            nudGain.Value = (decimal)param.Gain;

            propertyGrid1.SelectedObject = param;
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

        private void AddChangeEvent()
        {
            nudExpo.ValueChanged += NudExpo_ValueChanged;
            nudGain.ValueChanged += NudGain_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudExpo.ValueChanged -= NudExpo_ValueChanged;
            nudGain.ValueChanged -= NudGain_ValueChanged;
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

        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.appManager?.Snap();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void NudExpo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();
                param.Expo = (double)nudExpo.Value;

                //this.core.GetFrameGrabberManager().SetExpo((double)nudExpo.Value);
                this.appManager.SetExpoGain(this.numTest, param.Expo, param.Gain);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void NudGain_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();
                param.Gain = (double)nudGain.Value;

                //this.core.GetFrameGrabberManager().SetGain((double)nudGain.Value);
                this.appManager.SetExpoGain(this.numTest, param.Expo, param.Gain);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Eventi form

    }
}