using System;

namespace QVLEGS.Wizard
{
    public partial class WizardCam2_Foto1 : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStep1Cam2_Foto1 step1 = null;
        private readonly UCStep2Cam2_Foto1 step2 = null;
        private readonly UCStep3Cam2_Foto1 step3 = null;

        #endregion Variabili Private

        public WizardCam2_Foto1(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();

                step1 = new UCStep1Cam2_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "Step2";
                step1.PreviousStep = "";

                step2 = new UCStep2Cam2_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step2.NextStep = "Step3";
                step2.PreviousStep = "Step1";

                step3 = new UCStep3Cam2_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step3.NextStep = "FINISHED";
                step3.PreviousStep = "Step2";

                this.AddStep("Step1", step1);
                this.AddStep("Step2", step2);
                this.AddStep("Step3", step3);

                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();

                this.algoritmoWizard.SetWizardImage(parametri.ImageRef, parametri.PrevImageDataRef);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Utilities.WaitManager.CloseWaitForm();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnFinishClicked(EventArgs e)
        {
            base.OnFinishClicked(e);

            this.algoritmoWizard.SetWizarCam2_Foto1Complete();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}