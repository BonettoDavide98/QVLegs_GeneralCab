﻿using System;
using System.Windows.Forms;

namespace QVLEGS.UCEditAlgoritmo
{
    public partial class UCEditAlgCam1_Foto2 : UserControl
    {

        private int idCamera = -1;
        private DataType.Impostazioni impostazioni = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;
        private Class.AppManager appManager = null;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        private bool completo = false;

        public UCEditAlgCam1_Foto2()
        {
            InitializeComponent();
        }

        public void Init(int num, Class.AppManager appManager, int idCamera, DataType.Impostazioni impostazioni, Utilities.SimpleDirtyTracker simpleDirtyTracker, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.idCamera = idCamera;
            this.impostazioni = impostazioni;
            this.simpleDirtyTracker = simpleDirtyTracker;
            this.appManager = appManager;
            this.linguaManager = linguaManager;
            this.repaintLock = repaintLock;

            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_CAM1_FOTO2");
            lblNum.Text = num.ToString();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_CAM1_FOTO2");

            if (completo)
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
            else
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
        }

        public void SetAlgoritmo(Algoritmi.AlgoritmoWizard algoritmoWizard)
        {
            chbEnable.CheckedChanged -= chbEnable_CheckedChanged;
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
                chbEnable.CheckedChanged += chbEnable_CheckedChanged;
            }
        }

        public void CheckForComplete()
        {
            if (this.algoritmoWizard != null)
            {
                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();

                //Se non ho fatto il wizard acq e quello di allineamento non sono abilitato
                this.Enabled = parametri.WizardAcqCompleto && parametri.AllineamentoParam.WizardCompleto;

                btnNew.Enabled = true;
                if (parametri.Cam1_Foto2Param.WizardCompleto)
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
                    completo = true;

                    btnEdit.Enabled = true;
                    panelComplete.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
                    completo = false;

                    btnEdit.Enabled = false;
                    panelComplete.BackColor = System.Drawing.Color.Red;
                }

                chbEnable.Checked = parametri.Cam1_Foto2Param.AbilitaControllo;

                if (chbEnable.Checked == false)
                {
                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
        }

        private void OpenWizard(bool modifica)
        {
            Class.CoreRegolazioni core = null;
            try
            {
                core = this.appManager.GetCoreRegolazioni(this.idCamera, 2);
                core.Run();

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();
                string parXml = DataType.Extension.SerializeAsString(pAlg);

                if (!modifica)
                {
                    pAlg.Cam1_Foto2Param?.Dispose();
                    pAlg.Cam1_Foto2Param = new DataType.Cam1_Foto2Param();
                    pAlg.Cam1_Foto2Param.AbilitaControllo = true;
                }

                Wizard.WizardCam1_Foto2 wizard = new Wizard.WizardCam1_Foto2(this.appManager, this.idCamera, core, this.algoritmoWizard, this.impostazioni, modifica, this.linguaManager, this.repaintLock);
                if (wizard.ShowDialog() == DialogResult.OK)
                {
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

        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.simpleDirtyTracker.SetAsDirty();
                this.algoritmoWizard.SetAlgCam1_Foto2Enable(chbEnable.Checked);
                CheckForComplete();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}