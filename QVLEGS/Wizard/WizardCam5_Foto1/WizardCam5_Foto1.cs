using System;

namespace QVLEGS.Wizard
{
    public partial class WizardCam5_Foto1 : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStep1Cam5_Foto1 step1 = null;

        #endregion Variabili Private

        public WizardCam5_Foto1(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();

                step1 = new UCStep1Cam5_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "FINISHED";
                step1.PreviousStep = "";

                this.AddStep("Step1", step1);

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

            this.algoritmoWizard.SetWizarCam5_Foto1Complete();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}