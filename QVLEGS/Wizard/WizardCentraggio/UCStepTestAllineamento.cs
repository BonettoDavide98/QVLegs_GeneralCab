using System;
using System.Collections;

namespace QVLEGS.Wizard
{
    public partial class UCStepTestAllineamento : TSWizards.BaseExteriorStep
    {

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly object repaintLock = null;
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        #endregion Variabili Private

        public UCStepTestAllineamento(Class.AppManager appManager, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.repaintLock = repaintLock;

                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelShape, impostazioni, repaintLock);
                this.hWndCtrlManager.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                AbilitaDisabilitaControlli();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_TEST_ALLINEAMENTO");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_TEST_ALLINEAMENTO");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnRun.Text = linguaManager.GetTranslation("BTN_RUN");
                btnStop.Text = linguaManager.GetTranslation("BTN_STOP");

                lblMinScore.Text = linguaManager.GetTranslation("LBL_SCORE_MIN");
                chbLimitaAngolo.Text = linguaManager.GetTranslation("LBL_LIMITA_ANGOLO_CENTRAGGIO");
                lblMaxAngolo.Text = linguaManager.GetTranslation("LBL_MAX_ANGOLO_CENTRAGGIO");

                AddChangeEvent();

                propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            this.core.SetAlgorithm(this.algoritmoWizard.TestAllineamento);
            this.core.SetNewImageToDisplayEvent(OnNewImage);

            DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();

            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo paramaAlg)
        {
            DataType.AllineamentoParam param = paramaAlg.AllineamentoParam;

            nudMinScore.Value = (decimal)param.ShapeParam.FindParam.MinScore;
            chbLimitaAngolo.Checked = param.LimitaAngolo;
            nudMaxAngolo.Value = (decimal)param.MaxAngolo;

            propertyGrid1.SelectedObject = param;
        }

        private void OnNewImage(int numCamera, int numTest, ArrayList iconicVarList, DataType.ElaborateResult result)
        {
            this.hWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, result);
        }

        private void AddChangeEvent()
        {
            nudMinScore.ValueChanged += nud_ValueChanged;
            chbLimitaAngolo.CheckedChanged += nud_ValueChanged;
            nudMaxAngolo.ValueChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudMinScore.ValueChanged -= nud_ValueChanged;
            chbLimitaAngolo.CheckedChanged -= nud_ValueChanged;
            nudMaxAngolo.ValueChanged -= nud_ValueChanged;
        }

        private void AbilitaDisabilitaControlli()
        {
            lblMaxAngolo.Visible = chbLimitaAngolo.Checked;
            nudMaxAngolo.Visible = lblMaxAngolo.Visible;
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

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.AllineamentoParam param = this.algoritmoWizard.GetAlgoritmoParam().AllineamentoParam;

                param.ShapeParam.FindParam.MinScore = (double)nudMinScore.Value;

                param.LimitaAngolo = chbLimitaAngolo.Checked;
                param.MaxAngolo = (double)nudMaxAngolo.Value;

                AbilitaDisabilitaControlli();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

    }
}