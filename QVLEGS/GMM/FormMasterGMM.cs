using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QVLEGS
{
    public partial class FormMasterGMM : Form
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        public FormMasterGMM(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
            this.repaintLock = repaintLock;

            btnImpostazioni.Text = linguaManager.GetTranslation("BTN_IMPOSTAZIONI");
        }

        private void btnImpostazioni_Click(object sender, EventArgs e)
        {
            try
            {
                FormPassword frmPsw = new FormPassword(this.impostazioni);
                if (frmPsw.ShowDialog() == DialogResult.OK)
                {
                    using (FormImpostazioni frm = new FormImpostazioni())
                    {
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}