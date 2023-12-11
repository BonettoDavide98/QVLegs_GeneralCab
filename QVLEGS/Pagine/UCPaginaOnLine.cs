using System;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaOnLine : UserControl
    {

        public enum ShowMode { Show1_N, ShowBad, ShowLock, }

        private Class.AppManager appManager = null;
        private ShowMode showMode = ShowMode.Show1_N;

        private IUCPaginaOnLine ucPaginaOnLineStazioni = null;

        public UCPaginaOnLine()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int cntTest, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;

            int idStazione = this.appManager.GetIdStazione();

            ucPaginaOnLineStazioni = InitPageStazioni(idStazione, cntTest, impostazioni, repaintLock);
        }

        private IUCPaginaOnLine InitPageStazioni(int idStazione, int cntTest, DataType.Impostazioni impostazioni, object repaintLock)
        {
            IUCPaginaOnLine ret = null;

            if (cntTest == 1)
            {
                var uc = new UCPaginaOnLine1Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (cntTest == 2)
            {
                var uc = new UCPaginaOnLine2Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (cntTest == 3)
            {
                var uc = new UCPaginaOnLine3Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (cntTest == 5)
            {
                var uc = new UCPaginaOnLine5Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }

            ret.Init(appManager, idStazione, impostazioni, repaintLock);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_ONLINE");
            rbShowBad.Text = linguaManager.GetTranslation("LBL_SHOW_BAD");
            rbShowLock.Text = linguaManager.GetTranslation("LBL_SHOW_LOCK");
            rbShow1N.Text = linguaManager.GetTranslation("LBL_SHOW_1_N");

            ucPaginaOnLineStazioni?.Translate(linguaManager);
        }

        public void ActivateDisplay()
        {
            ucPaginaOnLineStazioni?.ActivateDisplay();
        }

        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShow1N.Checked)
            {
                this.showMode = ShowMode.Show1_N;
            }
            else if (rbShowBad.Checked)
            {
                this.showMode = ShowMode.ShowBad;
            }
            else if (rbShowLock.Checked)
            {
                this.showMode = ShowMode.ShowLock;
            }

            ucPaginaOnLineStazioni?.SetShowMode(this.showMode);
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            this.appManager?.Snap();
        }

    }
}