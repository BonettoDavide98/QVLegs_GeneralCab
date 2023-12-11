using System;

namespace QVLEGS.Wizard
{
    public partial class WizardCentraggio : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;

        private readonly UCStepTrainAllineamento step1 = null;
        private readonly UCStepTestAllineamento step2 = null;

        #endregion Variabili Private

        public WizardCentraggio(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                step1 = new UCStepTrainAllineamento(appManager, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "Step2";
                step1.PreviousStep = "";

                step2 = new UCStepTestAllineamento(appManager, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step2.NextStep = "FINISHED";
                step2.PreviousStep = "Step1";

                this.AddStep("Step1", step1);
                this.AddStep("Step2", step2);

                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();

                if (modifica)
                {
                    HalconDotNet.HImage img = null;
                    DataType.PrevImageData prevData = null;

                    if (parametri.AllineamentoParam.ImageRef == null)
                    {
                        img = parametri.ImageRef;
                        prevData = parametri.PrevImageDataRef;
                    }
                    else
                    {
                        img = parametri.AllineamentoParam.ImageRef;
                        prevData = parametri.AllineamentoParam.PrevImageDataRef;
                    }

                    this.algoritmoWizard.SetWizardImage(img, prevData);
                }
                else
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

            //HalconDotNet.HImage image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);
            //this.algoritmoWizard.SetImageRefCentraggio(image, prevImageData);
            //this.algoritmoWizard.SetWizardoAllineamentoComplete();

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void Salva()
        {
            HalconDotNet.HImage image = this.algoritmoWizard.GetWizardImage(out DataType.PrevImageData prevImageData);
            this.algoritmoWizard.SetImageRefCentraggio(image, prevImageData);
            this.algoritmoWizard.SetWizardoAllineamentoComplete();
        }

    }
}