using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace QVLEGS
{
    public partial class FormWizardMaskCamera : Form
    {

        private const int ROI_CLASSIFICATORE = 1000;

        #region Variabili Private

        private Class.CoreRegolazioni setupCore = null;
        private Algoritmi.AlgoritmoMask algoritmo = null;
        private Utilities.HWndCtrlManager hWndCtrlManager = null;
        private DBL.LinguaManager linguaMngr = null;
        private object repaintLock = null;
        private object imgLockCamera = new object();
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;

        private int imageWidth = 0;
        private int imageHeight = 0;

        private bool wizardOk = false;

        #endregion Variabili Private

        public FormWizardMaskCamera(Class.CoreRegolazioni setupCore, Algoritmi.AlgoritmoMask algoritmo, int imageWidth, int imageHeight, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaMngr, object repaintLock)
        {
            InitializeComponent();

            this.setupCore = setupCore;
            this.algoritmo = algoritmo;

            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;

            this.linguaMngr = linguaMngr;

            this.repaintLock = repaintLock;

            this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelContainer, impostazioni, repaintLock);

            this.setupCore.SetAlgorithm(algoritmo.TestWizard);

            this.setupCore.SetNewImageToDisplayEvent(DisplaySetupOutputCamera);

            btnStartAcq.Text = linguaMngr.GetTranslation("LBL_BTN_START_ACQ");
            btnStopAcq.Text = linguaMngr.GetTranslation("LBL_BTN_STOP_ACQ");
            btnTerminaTrain.Text = linguaMngr.GetTranslation("LBL_BTN_TERMINA");
            lblIstruzioni.Text = linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_MASK");
            btnDisegnaManoAdd.Text = linguaMngr.GetTranslation("BTN_MANO_LIBERA");
            btnDisegnaManoRem.Text = linguaMngr.GetTranslation("BTN_GOMMA");

            this.simpleDirtyTracker = new Utilities.SimpleDirtyTracker(this.Controls);
            this.simpleDirtyTracker.SetAsClean();

            this.hWndCtrlManager.SetMask(this.algoritmo.GetMask());
            this.hWndCtrlManager.DisplayMask();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (wizardOk)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this.simpleDirtyTracker.IsDirty && wizardOk == false)
            {
                DialogResult res = MessageBox.Show(linguaMngr.GetTranslation("MSG_WIZARD_CHIUDERE"), linguaMngr.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DisplaySetupOutputCamera(int numCamera, int numTest, ArrayList iconicVarList, DataType.ElaborateResult result)
        {
            hWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, result);
            this.hWndCtrlManager.DisplayMask();
        }

        #region Eventi Form

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Utilities.KeyBoardOsk.showKeypad((sender as Control).Handle);
        }

        private void btnStartAcq_Click(object sender, EventArgs e)
        {
            try
            {
                setupCore.Run();
                btnStartAcq.Enabled = false;
                btnStopAcq.Enabled = true;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnStopAcq_Click(object sender, EventArgs e)
        {
            try
            {
                setupCore.StopAndWaitEnd(true);
                btnStartAcq.Enabled = true;
                btnStopAcq.Enabled = false;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Brush);
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnDisegnaManoRem_Click(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.NessunaModalita();
                this.hWndCtrlManager.SetDraw(true, Utilities.UCHWndCtrlManager.ToolType.Rubber);
                this.hWndCtrlManager.DisplayMask();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void trackBarDimensione_Scroll(object sender, EventArgs e)
        {
            try
            {
                this.hWndCtrlManager.SetBrushRubberSize(trackBarDimensione.Value);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnTerminaTrain_Click(object sender, EventArgs e)
        {
            try
            {
                this.algoritmo.SetMask(this.hWndCtrlManager.GetMask());

                wizardOk = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi Form

    }
}