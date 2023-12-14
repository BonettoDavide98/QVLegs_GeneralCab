using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaQuery : UserControl
    {
        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        int currentCam = 1;

        public UCPaginaQuery()
        {
            InitializeComponent();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_QUERY");
            btnCambiaCAM1.Text = linguaManager.GetTranslation("BTN_CAMBIA_CAM_1");
            btnCambiaCAM2.Text = linguaManager.GetTranslation("BTN_CAMBIA_CAM_2");
            btnExecuteQuery.Text = linguaManager.GetTranslation("BTN_ESEGUI_QUERY");
            btnSave.Text = linguaManager.GetTranslation("BTN_SALVA_RIS_QUERY");
            btnRemoveWhite.Text = linguaManager.GetTranslation("BTN_RIMUOVI_BIANCO");
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.appManager = appManager;
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;

                if (appManager.GetIdStazione() % 2 == 1)
                {
                    btnCambiaCAM2.Visible = false;
                }

                CreateToggleRows(1);

                LoadData(appManager.GetIdStazione(), 1);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void CreateToggleRows(int numCam)
        {
            tableLayoutPanelToggles.Controls.Clear();

            List<string> nomiParametri = new List<string>();

            switch (appManager.GetIdStazione())
            {
                case 0:
                    if(numCam == 1)
                    {
                        tableLayoutPanelToggles.RowCount = 8;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Condensatore Laterale M Pin 1");
                        nomiParametri.Add("Condensatore Laterale M Pin 2");
                        nomiParametri.Add("Condensatore Laterale P Pin 1");
                        nomiParametri.Add("Condensatore Laterale P Pin 2");
                        nomiParametri.Add("Spazzola SX");
                        nomiParametri.Add("Spazzola DX");
                        nomiParametri.Add("Diametro");
                    } else
                    {
                        tableLayoutPanelToggles.RowCount = 21;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Nero Protettore Pin 1");
                        nomiParametri.Add("Bianco Protettore Pin 1");
                        nomiParametri.Add("Nero Protettore Pin 2");
                        nomiParametri.Add("Bianco Protettore Pin 2");
                        nomiParametri.Add("Nero Condensatore Lat M Pin 1");
                        nomiParametri.Add("Bianco Condensatore Lat M Pin 1");
                        nomiParametri.Add("Nero Condensatore Lat M Pin 2");
                        nomiParametri.Add("Bianco Condensatore Lat M Pin 2");
                        nomiParametri.Add("Nero Impendenza Lat M");
                        nomiParametri.Add("Bianco Impendenza Lat M");
                        nomiParametri.Add("Nero Varistore Pin 1");
                        nomiParametri.Add("Bianco Varistore Pin 1");
                        nomiParametri.Add("Nero Varistore Pin 2");
                        nomiParametri.Add("Bianco Varistore Pin 2");
                        nomiParametri.Add("Nero Condensatore Lat P Pin 1");
                        nomiParametri.Add("Bianco Condensatore Lat P Pin 1");
                        nomiParametri.Add("Nero Condensatore Lat P Pin 2");
                        nomiParametri.Add("Bianco Condensatore Lat P Pin 2");
                        nomiParametri.Add("Nero Impendenza Lat P");
                        nomiParametri.Add("Bianco Impendenza Lat P");
                    }
                    break;
                case 1:
                    tableLayoutPanelToggles.RowCount = 4;
                    nomiParametri.Add("Data");
                    nomiParametri.Add("Allineamento Contatto");
                    nomiParametri.Add("Ingombro SX");
                    nomiParametri.Add("Ingombro DX");
                    break;
                case 2:
                    if (numCam == 1)
                    {
                        tableLayoutPanelToggles.RowCount = 4;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("InduttanzaSX");
                        nomiParametri.Add("Protettore");
                        nomiParametri.Add("InduttanzaDX");
                    } else
                    {
                        tableLayoutPanelToggles.RowCount = 5;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Colonnina SX");
                        nomiParametri.Add("Treccia SX");
                        nomiParametri.Add("Treccia DX");
                        nomiParametri.Add("Colonnina DX");
                    }
                    break;
                case 3:
                    tableLayoutPanelToggles.RowCount = 16;
                    nomiParametri.Add("Data");
                    nomiParametri.Add("Zona Libera");
                    nomiParametri.Add("Molletta Lam M");
                    nomiParametri.Add("Molletta Lam P");
                    nomiParametri.Add("Ingombro SX Varistore");
                    nomiParametri.Add("Ingombro Condensatore");
                    nomiParametri.Add("Ingombro Sotto Varistore");
                    nomiParametri.Add("Diametro");
                    nomiParametri.Add("Varistore");
                    nomiParametri.Add("Condensatore DX");
                    nomiParametri.Add("Ingombro Sopra Varistore");
                    nomiParametri.Add("Condensatore SX");
                    nomiParametri.Add("Ingombro SX Varistore");
                    nomiParametri.Add("Induttanza Lat P");
                    nomiParametri.Add("Induttanza Lat M");
                    nomiParametri.Add("DIametro 2");
                    break;
                case 4:
                    if (numCam == 1)
                    {
                        tableLayoutPanelToggles.RowCount = 2;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Controllo Foro");
                    } else
                    {
                        tableLayoutPanelToggles.RowCount = 2;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Molletta Lat M");
                    }
                    break;
            }

            tableLayoutPanelToggles.RowCount++;

            TableLayoutRowStyleCollection styles = tableLayoutPanelToggles.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 30;
            }

            for (int i = 0; i < nomiParametri.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = nomiParametri[i];
                lbl.Dock = DockStyle.Fill;
                lbl.Padding = new Padding(0, 12, 0, 0);
                lbl.ForeColor = Color.White;
                tableLayoutPanelToggles.Controls.Add(lbl, 0, i);

                CheckBox chb = new CheckBox();
                chb.Name = "chb" + i;
                chb.Dock = DockStyle.Fill;
                chb.Checked = true;
                tableLayoutPanelToggles.Controls.Add(chb, 1, i);

                Button btn = new Button();
                btn.Name = "btn" + i;
                btn.Dock = DockStyle.Fill;
                btn.Click += btnToggleComparator_Click;
                btn.BackColor = Color.White;
                btn.Text = ">";
                tableLayoutPanelToggles.Controls.Add(btn, 2, i);

                if(i != 0)
                {
                    TextBox txb = new TextBox();
                    txb.Name = "txb" + i;
                    txb.Dock = DockStyle.Fill;
                    txb.Click += OpenVirtualKeyboard;
                    tableLayoutPanelToggles.Controls.Add(txb, 3, i);
                } else
                {
                    TableLayoutPanel tlp = new TableLayoutPanel();
                    tlp.RowCount = 1;
                    tlp.ColumnCount = 9;
                    tlp.Dock = DockStyle.Fill;
                    tableLayoutPanelToggles.Controls.Add(tlp, 3, i);

                    for (int j = 0; j < 8; j++)
                    {
                        if(j == 0)
                        {
                            Label lbl2 = new Label();
                            lbl2.Text = "DATA";
                            lbl2.Dock = DockStyle.Fill;
                            lbl2.Padding = new Padding(0, 6, 0, 0);
                            lbl2.ForeColor = Color.White;
                            tlp.Controls.Add(lbl2, j, 0);
                        } else if (j == 4)
                        {
                            Label lbl3 = new Label();
                            lbl3.Text = "ORA";
                            lbl3.Dock = DockStyle.Fill;
                            lbl3.Padding = new Padding(0, 6, 0, 0);
                            lbl3.ForeColor = Color.White;
                            tlp.Controls.Add(lbl3, j, 0);
                        } else
                        {
                            TextBox datetime = new TextBox();
                            datetime.Name = "datetime" + j;
                            datetime.Dock = DockStyle.Fill;
                            datetime.Click += OpenVirtualKeyboard;
                            tlp.Controls.Add(datetime, j, 0);
                        }
                    }

                    tlp.ColumnStyles.Clear();
                    for(int j = 0; j < 8; j++)
                    {
                        if(j == 0)
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45));
                        } else if(j == 3 || j == 4)
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
                        } else
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
                        }
                    }
                }
            }

            ((CheckBox)tableLayoutPanelToggles.GetControlFromPosition(1, 0)).Visible = false;
            TableLayoutPanel datetimepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(3, 0));
            ((TextBox)(datetimepanel.GetControlFromPosition(1, 0))).Text = DateTime.Now.Day.ToString();
            ((TextBox)(datetimepanel.GetControlFromPosition(2, 0))).Text = DateTime.Now.Month.ToString();
            ((TextBox)(datetimepanel.GetControlFromPosition(3, 0))).Text = DateTime.Now.Year.ToString();
            ((TextBox)(datetimepanel.GetControlFromPosition(5, 0))).Text = "00";
            ((TextBox)(datetimepanel.GetControlFromPosition(6, 0))).Text = "00";
            ((TextBox)(datetimepanel.GetControlFromPosition(7, 0))).Text = "00";
        }

        private void LoadData(int idStazione, int numCam)
        {
            try
            {
                string cam = "CAM" + idStazione.ToString();
                if (numCam == 2)
                {
                    cam += "_2";
                }
                dataGridView1.DataSource = DBL.StatisticheManager.GetStatisticheCAM(cam, GetToggled(), GetComparisons());

                foreach(DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.DisplayIndex = col.Index;
                }

                dataGridView1.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                dataGridView1.Columns[0].Width = 110;
            } catch
            {
                MessageBox.Show("Errore nei parametri immessi.");
            }
            
        }

        private bool[] GetToggled()
        {
            bool[] toggled = new bool[tableLayoutPanelToggles.RowCount - 1];

            for(int i = 0; i < tableLayoutPanelToggles.RowCount - 1; i++)
            {
                toggled[i] = ((CheckBox)tableLayoutPanelToggles.GetControlFromPosition(1, i)).Checked;
            }

            return toggled;
        }

        private string[] GetComparisons()
        {
            string[] comparisons = new string[tableLayoutPanelToggles.RowCount - 1];

            TableLayoutPanel datetimepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(3, 0));
            comparisons[0] = ((Button)tableLayoutPanelToggles.GetControlFromPosition(2, 0)).Text + " '";
            comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(1, 0))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(2, 0))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(3, 0))).Text;
            if(((TextBox)(datetimepanel.GetControlFromPosition(5, 0))).Text != "")
            {
                comparisons[0] += " ";
                comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(5, 0))).Text;
                comparisons[0] += ":";
                comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(6, 0))).Text != "" ? ((TextBox)(datetimepanel.GetControlFromPosition(6, 0))).Text : "00";
                comparisons[0] += ":";
                comparisons[0] += ((TextBox)(datetimepanel.GetControlFromPosition(7, 0))).Text != "" ? ((TextBox)(datetimepanel.GetControlFromPosition(7, 0))).Text : "00";
            }
            comparisons[0] += "'";

            for (int i = 1; i < tableLayoutPanelToggles.RowCount - 1; i++)
            {
                if(((TextBox)tableLayoutPanelToggles.GetControlFromPosition(3, i)).Text.Length > 0)
                    comparisons[i] = ((Button)tableLayoutPanelToggles.GetControlFromPosition(2, i)).Text + " " + ((TextBox)tableLayoutPanelToggles.GetControlFromPosition(3, i)).Text;
            }

            return comparisons;
        }

        private void btnCambiaCAM1_Click(object sender, EventArgs e)
        {
            if(appManager.GetIdStazione() == 2)
            {
                CreateToggleRows(2);
                LoadData(appManager.GetIdStazione(), 2);
                currentCam = 2;
            } else
            {
                CreateToggleRows(1);
                LoadData(appManager.GetIdStazione(), 1);
                currentCam = 1;
            }
            btnRemoveWhite.Visible = false;
        }

        private void btnCambiaCAM2_Click(object sender, EventArgs e)
        {
            if(appManager.GetIdStazione() == 2)
            {
                CreateToggleRows(1);
                LoadData(appManager.GetIdStazione(), 1);
                currentCam = 1;
            } else
            {
                CreateToggleRows(2);
                LoadData(appManager.GetIdStazione(), 2);
                currentCam = 2;
                if (appManager.GetIdStazione() == 0)
                {
                    btnRemoveWhite.Visible = true;
                }
            }
        }

        public void UpdateData()
        {
            btnCambiaCAM1_Click(null, null);
        }

        private void btnToggleComparator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if(b.Text == ">")
            {
                b.Text = "<";
            } else if(b.Text == "<")
            {
                b.Text = "=";
            } else if(b.Text == "=")
            {
                b.Text = "<>";
            }
            else if (b.Text == "<>")
            {
                b.Text = ">";
            }
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            LoadData(appManager.GetIdStazione(), currentCam);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = DateTime.Now.ToString("ddMMyyyy_hhMMss") + "CAM" + appManager.GetIdStazione() + (currentCam == 2 ? "_2" : "") + "Dump.csv";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                if(File.Exists(sfd.FileName))
                {
                    sfd.FileName += 2;
                }

                try
                {
                    string[] csv = new string[dataGridView1.RowCount];
                    for(int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        csv[0] += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                    }
                    
                    for(int i = 1; i < dataGridView1.RowCount; i++)
                    {
                        for(int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            csv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString().Replace(',','.') + ",";
                        }
                    }

                    File.WriteAllLines(sfd.FileName, csv, Encoding.UTF8);
                    MessageBox.Show("File .csv salvato con successo.");
                } catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.StackTrace);
                }
            }
        }

        private void btnRemoveWhite_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 2; i < 21; i += 2)
                {
                    ((CheckBox)tableLayoutPanelToggles.GetControlFromPosition(1, i)).Checked = false;
                }
            } catch
            {

            }
        }

        private void OpenVirtualKeyboard(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            ((TextBox)sender).Focus();
        }
    }
}
