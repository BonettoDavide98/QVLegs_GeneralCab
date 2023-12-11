using System;
using System.Windows.Forms;

namespace QVLEGS.UCEditAlgoritmo
{
    public partial class UCEditCentraggio : UserControl
    {

        public event EventHandler OnComplete = null;

        private int idCamera = -1;
        private int numTest = -1;
        private DataType.Impostazioni impostazioni = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;
        private Class.AppManager appManager = null;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        private bool completo = false;

        public UCEditCentraggio()
        {
            InitializeComponent();
        }

        public void Init(int num, Class.AppManager appManager, int idCamera, int numTest, DataType.Impostazioni impostazioni, Utilities.SimpleDirtyTracker simpleDirtyTracker, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.idCamera = idCamera;
            this.numTest = numTest;
            this.impostazioni = impostazioni;
            this.simpleDirtyTracker = simpleDirtyTracker;
            this.appManager = appManager;
            this.linguaManager = linguaManager;
            this.repaintLock = repaintLock;

            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_CENTRAGGIO");
            lblNum.Text = num.ToString();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_CENTRAGGIO");

            if (completo)
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
            else
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
        }

        public void SetAlgoritmo(Algoritmi.AlgoritmoWizard algoritmoWizard)
        {
            try
            {
                this.algoritmoWizard = algoritmoWizard;
                CheckForComplete();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void CheckForComplete()
        {
            if (this.algoritmoWizard != null)
            {
                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();

                //Se non ho fatto il wizard acq non sono abilitato
                this.Enabled = parametri.WizardAcqCompleto;

                if (parametri.AllineamentoParam.WizardCompleto)
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
                    completo = true;

                    btnEdit.Enabled = true;
                    panelComplete.BackColor = System.Drawing.Color.Green;

                    OnComplete?.Invoke(this, null);
                }
                else
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
                    completo = false;

                    btnEdit.Enabled = false;
                    panelComplete.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void OpenWizard(bool modifica)
        {
            Class.CoreRegolazioni core = null;
            try
            {
                core = this.appManager.GetCoreRegolazioni(this.idCamera, this.numTest);
                core.Run();

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();
                string parXml = DataType.Extension.SerializeAsString(pAlg);

                if (!modifica)
                {
                    pAlg.AllineamentoParam?.Dispose();
                    pAlg.AllineamentoParam = new DataType.AllineamentoParam();
                }

                Wizard.WizardCentraggio wizard = new Wizard.WizardCentraggio(this.appManager, this.idCamera, core, this.algoritmoWizard, this.impostazioni, modifica, this.linguaManager, this.repaintLock);
                if (wizard.ShowDialog() == DialogResult.OK)
                {
                    wizard.Salva();
                    this.simpleDirtyTracker.SetAsDirty();
                }
                else
                {
                    this.algoritmoWizard.SetAlgoritmoParam(DataType.Extension.DeSerializeStringAsT<DataType.ParametriAlgoritmo>(parXml));
                }
                CheckForComplete();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                core?.StopAndWaitEnd(true);
                core?.CloseFrameGrabber();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenWizard(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenWizard(true);
        }

    }
}