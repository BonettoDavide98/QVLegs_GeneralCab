using System;

namespace QVLEGS.Wizard
{
    public partial class WizardAcq : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStepAcq step1 = null;
        private readonly UCStepRoiMain step2 = null;
        private readonly UCStepImageRef step3 = null;


        #endregion Variabili Private

        public WizardAcq(Class.AppManager appManager, int idCamera, string idFormato, int numTest, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, Algoritmi.AlgoritmoGMM algoritmoGMM, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                step1 = new UCStepAcq(appManager, numTest, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "Step2";
                step1.PreviousStep = "";

                step2 = new UCStepRoiMain(core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step2.NextStep = "Step3";
                step2.PreviousStep = "Step1";

                step3 = new UCStepImageRef(appManager, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step3.NextStep = "FINISHED";
                step3.PreviousStep = "Step2";

                this.AddStep("Step1", step1);
                this.AddStep("Step2", step2);
                this.AddStep("Step3", step3);

                if (modifica)
                {
                    DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();
                    this.algoritmoWizard.SetWizardImage(parametri.ImageRef, parametri.PrevImageDataRef);
                }
                else
                {
                    this.algoritmoWizard.ResetWizardImage();
                }
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
        }

        public void Salva()
        {
            HalconDotNet.HImage image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);
            this.algoritmoWizard.SetImageRefMain(image, prevImageData);
            this.algoritmoWizard.SetWizardAcqComplete();
        }

    }
}