using System;

namespace QVLEGS.Wizard
{
    public partial class WizardCam4_Foto1 : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStep1Cam4_Foto1 step1 = null;
        private readonly UCStep2Cam4_Foto1 step2 = null;
        private readonly UCStep3Cam4_Foto1 step3 = null;
        private readonly UCStep4Cam4_Foto1 step4 = null;
        private readonly UCStep5Cam4_Foto1 step5 = null;
        private readonly UCStep6Cam4_Foto1 step6 = null;
        private readonly UCStep7Cam4_Foto1 step7 = null;
        private readonly UCStep8Cam4_Foto1 step8 = null;
        private readonly UCStep9Cam4_Foto1 step9 = null;
        private readonly UCStep10Cam4_Foto1 step10 = null;
        private readonly UCStep11Cam4_Foto1 step11 = null;
        private readonly UCStep12Cam4_Foto1 step12 = null;
        private readonly UCStep13Cam4_Foto1 step13 = null;
        private readonly UCStep14Cam4_Foto1 step14 = null;
        private readonly UCStep15Cam4_Foto1 step15 = null;

        #endregion Variabili Private

        public WizardCam4_Foto1(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();

                step1 = new UCStep1Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "Step2";
                step1.PreviousStep = "";

                step2 = new UCStep2Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step2.NextStep = "Step3";
                step2.PreviousStep = "Step1";

                step3 = new UCStep3Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step3.NextStep = "Step4";
                step3.PreviousStep = "Step2";

                step4 = new UCStep4Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step4.NextStep = "Step5";
                step4.PreviousStep = "Step3";

                step5 = new UCStep5Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step5.NextStep = "Step6";
                step5.PreviousStep = "Step4";

                step6 = new UCStep6Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step6.NextStep = "Step7";
                step6.PreviousStep = "Step5";

                step7 = new UCStep7Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step7.NextStep = "Step8";
                step7.PreviousStep = "Step6";

                step8 = new UCStep8Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step8.NextStep = "Step9";
                step8.PreviousStep = "Step7";

                step9 = new UCStep9Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step9.NextStep = "Step10";
                step9.PreviousStep = "Step8";

                step10 = new UCStep10Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step10.NextStep = "Step11";
                step10.PreviousStep = "Step9";

                step11 = new UCStep11Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step11.NextStep = "Step12";
                step11.PreviousStep = "Step10";

                step12 = new UCStep12Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step12.NextStep = "Step13";
                step12.PreviousStep = "Step11";

                step13 = new UCStep13Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step13.NextStep = "Step14";
                step13.PreviousStep = "Step12";

                step14 = new UCStep14Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step14.NextStep = "Step15";
                step14.PreviousStep = "Step13";

                step15 = new UCStep15Cam4_Foto1(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step15.NextStep = "FINISHED";
                step15.PreviousStep = "Step14";

                this.AddStep("Step1", step1);
                this.AddStep("Step2", step2);
                this.AddStep("Step3", step3);
                this.AddStep("Step4", step4);
                this.AddStep("Step5", step5);
                this.AddStep("Step6", step6);
                this.AddStep("Step7", step7);
                this.AddStep("Step8", step8);
                this.AddStep("Step9", step9);
                this.AddStep("Step10", step10);
                this.AddStep("Step11", step11);
                this.AddStep("Step12", step12);
                this.AddStep("Step13", step13);
                this.AddStep("Step14", step14);
                this.AddStep("Step15", step15);

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

            this.algoritmoWizard.SetWizarCam4_Foto1Complete();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}