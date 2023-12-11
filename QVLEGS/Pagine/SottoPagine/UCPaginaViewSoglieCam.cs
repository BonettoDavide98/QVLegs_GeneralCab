using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QVLEGS.Pagine.SottoPagine
{
    public partial class UCPaginaViewSoglieCam : UserControl
    {

        private object objLock = new object();

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private Dictionary<string, UCEditSoglia> ucEdit = new Dictionary<string, UCEditSoglia>();

        private int idCamera = 0;
        private string idFormato = string.Empty;

        public UCPaginaViewSoglieCam()
        {
            InitializeComponent();

            // cambio la dimensione per far vedere solo una riga
            flpMenu.Size = new System.Drawing.Size(flpMenu.Size.Width, 65);

            //try
            //{
            //    Dictionary<string, TableLayoutPanel> testTlp = new Dictionary<string, TableLayoutPanel>();

            //    testTlp.Add("TEST_1_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_2_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_3_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_4_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_5A_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_5B_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_6_CAM_1_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_1_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_2_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_3_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_4_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_5_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_6_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_7_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_8_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_9_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_10_CAM_1_FOTO_2", tlpPageIntegrita);
            //    testTlp.Add("TEST_1_CAM_2_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_2_CAM_2_FOTO_1", tlpPageIntegrita);
            //    testTlp.Add("TEST_3_CAM_2_FOTO_1", tlpPageIntegrita);


            //    foreach (var item in testTlp)
            //    {
            //        TableLayoutPanel tlp = item.Value;
            //        tlp.RowCount += 1;
            //        tlp.RowStyles.Insert(tlp.RowCount - 2, new RowStyle(SizeType.AutoSize, 0));

            //        UCEditSoglia uc = new UCEditSoglia();
            //        uc.Size = new System.Drawing.Size(1520, 150);
            //        uc.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            //        tlp.Controls.Add(uc, 0, tlp.RowCount - 2);

            //        tlp.Size = new System.Drawing.Size(1550, tlp.RowCount * 150 + 50);

            //        //uc.Visible = false;

            //        ucEdit.Add(item.Key, uc);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Class.ExceptionManager.AddException(ex);
            //}
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, int idCamera, string idFormato, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.idCamera = idCamera;

                Dictionary<string, TableLayoutPanel> testTlp = new Dictionary<string, TableLayoutPanel>();

                if (idCamera == 0)
                {
                    testTlp.Add("TEST_1_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_4_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_5A_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_5B_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_6_CAM_1_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_1_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_4_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_5_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_6_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_7_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_8_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_9_CAM_1_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_10_CAM_1_FOTO_2", tlpPageIntegrita);
                }

                if (idCamera == 1)
                {
                    testTlp.Add("TEST_1_CAM_2_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_2_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_2_FOTO_1", tlpPageIntegrita);
                }

                if (idCamera == 2)
                {
                    testTlp.Add("TEST_1_CAM_3_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_3_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_3_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_4_CAM_3_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_1_CAM_3_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_3_FOTO_2", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_3_FOTO_2", tlpPageIntegrita);
                }
                if (idCamera == 3)
                {
                    testTlp.Add("TEST_1_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_2_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_3_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_4_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_5_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_6_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_7_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_8_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_9_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_10_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_11_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_12_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_13_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_14_CAM_4_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_15_CAM_4_FOTO_1", tlpPageIntegrita);
                }
                if (idCamera == 4)
                {
                    testTlp.Add("TEST_1_CAM_5_FOTO_1", tlpPageIntegrita);
                    testTlp.Add("TEST_1_CAM_5_FOTO_2", tlpPageIntegrita);
                }

                foreach (var item in testTlp)
                {
                    TableLayoutPanel tlp = item.Value;
                    tlp.RowCount += 1;
                    tlp.RowStyles.Insert(tlp.RowCount - 2, new RowStyle(SizeType.AutoSize, 0));

                    UCEditSoglia uc = new UCEditSoglia();
                    uc.Size = new System.Drawing.Size(1520, 150);
                    uc.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                    tlp.Controls.Add(uc, 0, tlp.RowCount - 2);

                    tlp.Size = new System.Drawing.Size(1550, tlp.RowCount * 150 + 50);

                    //uc.Visible = false;
                    if (!ucEdit.ContainsKey(item.Key))
                        ucEdit.Add(item.Key, uc);
                }






                this.appManager = appManager;
                this.impostazioni = impostazioni;

                this.idFormato = idFormato;


                Algoritmi.AlgoritmoLavoro algoritmo = this.appManager.GetAlgoritmo(idCamera);
                DataType.ParametriAlgoritmo parametri = algoritmo.GetAlgoritmoParam(1);

                //btnPageIntegrita.Visible = false;
                //btnPageDimensione.Visible = false;
                //btnPageDisegni.Visible = false;
                //btnPageCrepe.Visible = false;
                //btnPageColore.Visible = false;
                //btnPageColore2.Visible = false;
                //btnPageSbordamento.Visible = false;
                //btnPageDimensioneLato.Visible = false;
                //btnPageRakeH.Visible = false;
                //btnPageRakeV.Visible = false;
                //btnPageAltezza.Visible = false;
                //btnPageTop3D.Visible = false;
                //btnPageBuchiLato3D.Visible = false;

                //TabPage nextSelected = null;


                //ucEdit.Clear();

                //if (parametri.Template != null)
                //{

                foreach (var item in ucEdit)
                {
                    item.Value.Init(item.Key, algoritmo, linguaManager);
                }


                //    //// TOP
                //    if (parametri.Template.AlgIntegritaEnable && parametri.IntegritaParam.AbilitaControllo)
                //    {

                //        btnPageIntegrita.Visible = true;

                //        if (nextSelected == null) nextSelected = tabPageIntegrita;
                //    }
                //}

                //if (nextSelected == null)
                //{
                //    nextSelected = tabPageNN;
                //}

                //ucTabControl1.SelectedTab = nextSelected;
                ucTabControl1.SelectedTab = tabPageIntegrita;

                timerUpdateGrafici.Enabled = true;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            btnPageIntegrita.Text = linguaManager.GetTranslation("BTN_INTEGRITA");
            btnPageDisegni.Text = linguaManager.GetTranslation("BTN_DISEGNI");
            btnPageCrepe.Text = linguaManager.GetTranslation("BTN_CREPE");
            btnPageDimensione.Text = linguaManager.GetTranslation("BTN_DIMENSIONE");
            btnPageColore.Text = linguaManager.GetTranslation("BTN_COLORE");
            btnPageColore2.Text = linguaManager.GetTranslation("BTN_COLORE_2");
            btnPageSbordamento.Text = linguaManager.GetTranslation("BTN_SBORDAMENTO");
            btnPageDimensioneLato.Text = linguaManager.GetTranslation("BTN_DIMENSIONE");
            btnPageRakeH.Text = linguaManager.GetTranslation("BTN_RAKE_H");
            btnPageRakeV.Text = linguaManager.GetTranslation("BTN_RAKE_V");
            btnPageAltezza.Text = linguaManager.GetTranslation("BTN_ALTEZZA");
            label1.Text = linguaManager.GetTranslation("LBL_NN_SOGLIE");
            btnPageTop3D.Text = linguaManager.GetTranslation("BTN_TOP_3D");
            btnPageBuchiLato3D.Text = linguaManager.GetTranslation("BTN_BUCHI_LATO_3D");

            foreach (var item in this.ucEdit)
            {
                item.Value.Translate(linguaManager);
            }
        }


        public void Save(int numtest)
        {
            try
            {
                foreach (var item in this.ucEdit)
                {
                    if (item.Value.Visible)
                        item.Value.SaveData();
                }

                Algoritmi.AlgoritmoLavoro algoritmo = this.appManager.GetAlgoritmo(idCamera);

                //if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore)
                // {
                // Utente con livello alto salva su db
                string basePath = System.IO.Path.Combine(impostazioni.PathDatiBase, "RICETTE", this.idFormato, "GMM", (idCamera + 1).ToString());
                //int numTest=item.
                DBL.FormatoManager.WriteParametriAlgoritmo(this.idFormato, this.idCamera, numtest, algoritmo.GetAlgoritmoParam(numtest));
                //}
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Reset()
        {
            lock (objLock)
            {
                Class.GraficiSoglieManager graficiSoglieManager = this.appManager.GetGraficiSoglieManager(idCamera);
                graficiSoglieManager?.ClearData();

                foreach (var item in ucEdit)
                {
                    item.Value.DrawData(new Dictionary<int, int>());
                }
            }
        }

        private void timerUpdateGrafici_Tick(object sender, EventArgs e)
        {
            timerUpdateGrafici.Enabled = false;
            try
            {
                lock (objLock)
                {
                    Class.GraficiSoglieManager graficiSoglieManager = this.appManager.GetGraficiSoglieManager(idCamera);
                    Dictionary<string, Dictionary<int, int>> valori = graficiSoglieManager.GetData();

                    foreach (var item in valori)
                    {
                        if (ucEdit.ContainsKey(item.Key))
                        {
                            UCEditSoglia uc = ucEdit[item.Key];
                            uc.DrawData(item.Value);
                            uc.Visible = true;
                        }
                        else
                        {
                            //MANCA SULLA FORM
                            //AGGIUNGERE
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                timerUpdateGrafici.Enabled = true;
            }
        }


        private void btnPageIntegrita_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageIntegrita;
        }

        private void btnPageDisegni_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDisegni;
        }

        private void btnPageCrepe_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageCrepe;
        }

        private void btnPageDimensione_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDimensione;
        }

        private void btnPageColore_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageColore;
        }

        private void btnPageColore2_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageColore2;
        }

        private void btnPageSbordamento_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageSbordamento;
        }

        private void btnPageDimensioneLato_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDimensioneLato;
        }

        private void btnPageRakeH_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageRakeH;
        }

        private void btnPageRakeV_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageRakeV;
        }

        private void btnPageAltezza_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageAltezza;
        }

        private void btnPageTop3D_Click(object sender, EventArgs e)
        {

        }

        private void btnPageBuchiLato3D_Click(object sender, EventArgs e)
        {

        }

    }
}