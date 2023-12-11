using System;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaEditRicetta : UserControl
    {

        private Class.AppManager appManager = null;
        private Action<bool, bool, int> actionCaricaRicetta = null;
        private Action actionGoHome = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;
        private int cntTest = -1;

        public UCPaginaEditRicetta()
        {
            InitializeComponent();

            this.simpleDirtyTracker = new Utilities.SimpleDirtyTracker(null);
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, int cntTest, Action<bool, bool, int> actionCaricaRicetta, Action actionGoHome, DBL.LinguaManager linguaManager, object repaintLock)
        {
            try
            {
                this.appManager = appManager;
                this.actionCaricaRicetta = actionCaricaRicetta;
                this.actionGoHome = actionGoHome;
                this.cntTest = cntTest;

                ucPaginaEditRicettaCam1.Init(appManager, impostazioni, appManager.CamereId[0], 1, true, this.simpleDirtyTracker, linguaManager, repaintLock);

                if (cntTest > 1)
                    ucPaginaEditRicettaCam2.Init(appManager, impostazioni, appManager.CamereId[0], 2, false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (cntTest > 2)
                    ucPaginaEditRicettaCam3.Init(appManager, impostazioni, appManager.CamereId[0], 3, false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (cntTest > 3)
                    ucPaginaEditRicettaCam4.Init(appManager, impostazioni, appManager.CamereId[0], 4, false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (cntTest > 4)
                    ucPaginaEditRicettaCam5.Init(appManager, impostazioni, appManager.CamereId[0], 5, false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (cntTest > 5)
                    ucPaginaEditRicettaCam6.Init(appManager, impostazioni, appManager.CamereId[0], 6, false, this.simpleDirtyTracker, linguaManager, repaintLock);

                if (cntTest == 1)
                {
                    flowLayoutPanelBtnCam.Visible = false;
                }

                if (cntTest < 2)
                    btnCam2.Visible = false;

                if (cntTest < 3)
                    btnCam3.Visible = false;

                if (cntTest < 4)
                    btnCam4.Visible = false;

                if (cntTest < 5)
                    btnCam5.Visible = false;

                if (cntTest < 6)
                    btnCam6.Visible = false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_EDIT_FORMATO");

            btnCam1.Text = linguaManager.GetTranslation("BTN_FOTO_1");
            btnCam2.Text = linguaManager.GetTranslation("BTN_FOTO_2");
            btnCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            btnCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            btnCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");
            btnCam6.Text = linguaManager.GetTranslation("BTN_CAM_6");

            btnSave.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");

            ucPaginaEditRicettaCam1.Translate(linguaManager);

            if (cntTest > 1)
                ucPaginaEditRicettaCam2.Translate(linguaManager);
            if (cntTest > 2)
                ucPaginaEditRicettaCam3.Translate(linguaManager);
            if (cntTest > 3)
                ucPaginaEditRicettaCam4.Translate(linguaManager);
            if (cntTest > 4)
                ucPaginaEditRicettaCam5.Translate(linguaManager);
            if (cntTest > 5)
                ucPaginaEditRicettaCam6.Translate(linguaManager);

        }

        public void CaricaRicetta(string idFormato)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                ucPaginaEditRicettaCam1.CaricaRicetta(idFormato);
                System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 1 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                if (cntTest > 1)
                {
                    ucPaginaEditRicettaCam2.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 2 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (cntTest > 2)
                {
                    ucPaginaEditRicettaCam3.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 3 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (cntTest > 3)
                {
                    ucPaginaEditRicettaCam4.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 4 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (cntTest > 4)
                {
                    ucPaginaEditRicettaCam5.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 5 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (cntTest > 5)
                {
                    ucPaginaEditRicettaCam6.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 6 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                System.Diagnostics.Debug.WriteLine("-----------------------------------------------------------------------");

                this.simpleDirtyTracker.SetAsClean();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ResetBackColorBtnCam()
        {
            btnCam1.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnCam2.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnCam3.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnCam4.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnCam5.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            btnCam6.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
        }

        public bool IsDirty()
        {
            return this.simpleDirtyTracker.IsDirty;
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
            // values
            TabControl tabCtrl = (TabControl)sender;

            //BackColor
            //Color[] color = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Magenta, Color.MediumBlue, Color.Pink };

            //e.Graphics.FillRectangle(new SolidBrush(color[e.Index]), e.Bounds);
            //tabCtrl.TabPages[e.Index].BackColor = color[e.Index];

            Brush fontBrush = Brushes.Black;
            string title = tabCtrl.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int indent = 3;
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + indent, e.Bounds.Width, e.Bounds.Height - indent);

            // draw title
            Font f = new Font("Microsoft Sans Serif", 12);
            e.Graphics.DrawString(title, f, fontBrush, rect, sf);

            // draw image if available
            if (tabCtrl.TabPages[e.Index].ImageIndex >= 0)
            {
                Image img = tabCtrl.ImageList.Images[tabCtrl.TabPages[e.Index].ImageIndex];
                float _x = (rect.X + rect.Width) - img.Width - indent;
                float _y = ((rect.Height - img.Height) / 2.0f) + rect.Y;
                e.Graphics.DrawImage(img, _x, _y);
            }
            */
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            try
            {
                //ucPaginaEditRicettaCam1.RicaricaRicetta();

                //if (Class.AppManager.NUM_CAMERE > 1)
                //{
                //    ucPaginaEditRicettaCam2.RicaricaRicetta();
                //    ucPaginaEditRicettaCam3.RicaricaRicetta();
                //    ucPaginaEditRicettaCam4.RicaricaRicetta();
                //    ucPaginaEditRicettaCam5.RicaricaRicetta();
                //}

                this.simpleDirtyTracker.SetAsClean();

                actionGoHome?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            Utilities.WaitManager.OpenWaitForm("LBL_WAIT_SALVATAGGIO");
            try
            {
                ucPaginaEditRicettaCam1.Salva();

                if (cntTest > 1)
                    ucPaginaEditRicettaCam2.Salva();
                if (cntTest > 2)
                    ucPaginaEditRicettaCam3.Salva();
                if (cntTest > 3)
                    ucPaginaEditRicettaCam4.Salva();
                if (cntTest > 4)
                    ucPaginaEditRicettaCam5.Salva();
                if (cntTest > 5)
                    ucPaginaEditRicettaCam6.Salva();

                this.simpleDirtyTracker.SetAsClean();

                this.actionCaricaRicetta?.Invoke(true, false, cntTest);

                actionGoHome?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Utilities.WaitManager.CloseWaitForm();
            }
        }


        private void btnCam1_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam1.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera1;
        }

        private void btnCam2_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam2.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera2;
        }

        private void btnCam3_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam3.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera3;
        }

        private void btnCam4_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam4.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera4;
        }

        private void btnCam5_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam5.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera5;
        }

        private void btnCam6_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam6.BackColor = System.Drawing.Color.Blue;
            tabControlMain.SelectedTab = tabPageCamera6;
        }

    }
}