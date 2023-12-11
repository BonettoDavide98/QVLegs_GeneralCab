using System;

namespace QVLEGS.Wizard
{
    public partial class WizardCam1_Foto2 : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStep1Cam1_Foto2 step1 = null;
        private readonly UCStep1Cam1_Foto2 step2 = null;
        private readonly UCStep1Cam1_Foto2 step3 = null;
        private readonly UCStep1Cam1_Foto2 step4 = null;
        private readonly UCStep1Cam1_Foto2 step5 = null;
        private readonly UCStep1Cam1_Foto2 step6 = null;
        private readonly UCStep1Cam1_Foto2 step7 = null;
        private readonly UCStep1Cam1_Foto2 step8 = null;
        private readonly UCStep1Cam1_Foto2 step9 = null;
        private readonly UCStep1Cam1_Foto2 step10 = null;
        private readonly UCStep11Cam1_Foto2 step11 = null;
        private readonly UCStep12Cam1_Foto2 step12 = null;
        private readonly UCStep13Cam1_Foto2 step13 = null;
        private readonly UCStep14Cam1_Foto2 step14 = null;
        private readonly UCStep15Cam1_Foto2 step15 = null;
        private readonly UCStep16Cam1_Foto2 step16 = null;
        private readonly UCStep17Cam1_Foto2 step17 = null;
        private readonly UCStep18Cam1_Foto2 step18 = null;


        #endregion Variabili Private

        public WizardCam1_Foto2(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();

                step1 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 1);
                step1.NextStep = "Step2";
                step1.PreviousStep = "";

                step2 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 2);
                step2.NextStep = "Step3";
                step2.PreviousStep = "Step1";

                step3 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 3);
                step3.NextStep = "Step4";
                step3.PreviousStep = "Step2";

                step4 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 4);
                step4.NextStep = "Step5";
                step4.PreviousStep = "Step3";

                step5 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 5);
                step5.NextStep = "Step6";
                step5.PreviousStep = "Step4";

                step6 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 6);
                step6.NextStep = "Step7";
                step6.PreviousStep = "Step5";

                step7 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 7);
                step7.NextStep = "Step8";
                step7.PreviousStep = "Step6";

                step8 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 8);
                step8.NextStep = "Step9";
                step8.PreviousStep = "Step7";

                step9 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 9);
                step9.NextStep = "Step10";
                step9.PreviousStep = "Step8";

                step10 = new UCStep1Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock, 10);
                step10.NextStep = "Step11";
                step10.PreviousStep = "Step9";

                step11 = new UCStep11Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step11.NextStep = "Step12";
                step11.PreviousStep = "Step10";

                step12 = new UCStep12Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step12.NextStep = "Step13";
                step12.PreviousStep = "Step11";

                step13 = new UCStep13Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step13.NextStep = "Step14";
                step13.PreviousStep = "Step12";

                step14 = new UCStep14Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step14.NextStep = "Step15";
                step14.PreviousStep = "Step13";

                step15 = new UCStep15Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step15.NextStep = "Step16";
                step15.PreviousStep = "Step14";

                step16 = new UCStep16Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step16.NextStep = "Step17";
                step16.PreviousStep = "Step15";

                step17 = new UCStep17Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step17.NextStep = "Step18";
                step17.PreviousStep = "Step16";

                step18 = new UCStep18Cam1_Foto2(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step18.NextStep = "FINISHED";
                step18.PreviousStep = "Step17";

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
                this.AddStep("Step16", step16);
                this.AddStep("Step17", step17);
                this.AddStep("Step18", step18);

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

            this.algoritmoWizard.SetWizarCam1_Foto2Complete();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}