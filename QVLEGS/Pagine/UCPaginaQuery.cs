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
using QVLEGS.DataType;

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

            tableLayoutPanelToggles.RowStyles[0].Height = 60;

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

                //riga normale
                if(i != 0)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + i;
                    btn.Dock = DockStyle.Fill;
                    btn.Click += btnToggleComparator_Click;
                    btn.BackColor = Color.White;
                    btn.Text = ">";
                    tableLayoutPanelToggles.Controls.Add(btn, 2, i);

                    TextBox txb = new TextBox();
                    txb.Name = "txb" + i;
                    txb.Dock = DockStyle.Fill;
                    if((appManager.GetIdStazione() == 0 && numCam == 1) || appManager.GetIdStazione() == 2)
                        txb.Click += OpenVirtualKeyboard;
                    else
                        txb.Click += OpenVirtualKeyboardInt;
                    tableLayoutPanelToggles.Controls.Add(txb, 3, i);

                    Button btn2 = new Button();
                    btn2.Name = "btn2" + i;
                    btn2.Dock = DockStyle.Fill;
                    btn2.Click += btnToggleComparator_Click;
                    btn2.BackColor = Color.White;
                    btn2.Text = "<";
                    tableLayoutPanelToggles.Controls.Add(btn2, 4, i);

                    TextBox txb2 = new TextBox();
                    txb2.Name = "txb2" + i;
                    txb2.Dock = DockStyle.Fill;
                    if ((appManager.GetIdStazione() == 0 && numCam == 1) || appManager.GetIdStazione() == 2)
                        txb2.Click += OpenVirtualKeyboard;
                    else
                        txb2.Click += OpenVirtualKeyboardInt;
                    tableLayoutPanelToggles.Controls.Add(txb2, 5, i);
                } else
                //prima riga con data
                {
                    Button btn = new Button();
                    btn.Name = "btn" + i;
                    btn.Dock = DockStyle.Fill;
                    btn.Click += btnToggleComparatorData_Click;
                    btn.BackColor = Color.White;
                    btn.Text = "<>";
                    tableLayoutPanelToggles.Controls.Add(btn, 2, i);

                    TableLayoutPanel tlp = new TableLayoutPanel();
                    tlp.RowCount = 2;
                    tlp.ColumnCount = 5;
                    tlp.Dock = DockStyle.Fill;
                    tableLayoutPanelToggles.Controls.Add(tlp, 3, i);

                    for (int j = 0; j < 4; j++)
                    {
                        if(j == 0)
                        {
                            Label lbl2 = new Label();
                            lbl2.Text = "DAL";
                            lbl2.Dock = DockStyle.Fill;
                            lbl2.Padding = new Padding(0, 6, 0, 0);
                            lbl2.ForeColor = Color.White;
                            tlp.Controls.Add(lbl2, j, 0);

                            Label lbl22 = new Label();
                            lbl22.Text = "AL";
                            lbl22.Dock = DockStyle.Fill;
                            lbl22.Padding = new Padding(0, 6, 0, 0);
                            lbl22.ForeColor = Color.White;
                            tlp.Controls.Add(lbl22, j, 1);
                        } else
                        {
                            TextBox datetime = new TextBox();
                            datetime.Name = "date" + j;
                            datetime.Dock = DockStyle.Fill;
                            datetime.Click += OpenVirtualKeyboardInt;
                            tlp.Controls.Add(datetime, j, 0);
                            
                            TextBox datetime2 = new TextBox();
                            datetime2.Name = "date" + j;
                            datetime2.Dock = DockStyle.Fill;
                            datetime2.Click += OpenVirtualKeyboardInt;
                            tlp.Controls.Add(datetime2, j, 1);
                        }
                    }

                    tlp.ColumnStyles.Clear();
                    for(int j = 0; j < 4; j++)
                    {
                        if(j == 3)
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37));
                        } else if (j == 0)
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35));
                        } else
                        {
                            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
                        }
                    }

                    TableLayoutPanel tlp2 = new TableLayoutPanel();
                    tlp2.RowCount = 2;
                    tlp2.ColumnCount = 5;
                    tlp2.Dock = DockStyle.Fill;
                    tableLayoutPanelToggles.Controls.Add(tlp2, 5, i);

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            Label lbl2 = new Label();
                            lbl2.Text = "ORA";
                            lbl2.Dock = DockStyle.Fill;
                            lbl2.Padding = new Padding(0, 6, 0, 0);
                            lbl2.ForeColor = Color.White;
                            tlp2.Controls.Add(lbl2, j, 0);

                            Label lbl22 = new Label();
                            lbl22.Text = "ORA";
                            lbl22.Dock = DockStyle.Fill;
                            lbl22.Padding = new Padding(0, 6, 0, 0);
                            lbl22.ForeColor = Color.White;
                            tlp2.Controls.Add(lbl22, j, 1);
                        }
                        else
                        {
                            TextBox datetime = new TextBox();
                            datetime.Name = "time" + j;
                            datetime.Dock = DockStyle.Fill;
                            datetime.Click += OpenVirtualKeyboardInt;
                            tlp2.Controls.Add(datetime, j, 0);

                            TextBox datetime2 = new TextBox();
                            datetime2.Name = "time" + j;
                            datetime2.Dock = DockStyle.Fill;
                            datetime2.Click += OpenVirtualKeyboardInt;
                            tlp2.Controls.Add(datetime2, j, 1);
                        }
                    }

                    tlp2.ColumnStyles.Clear();
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            tlp2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37));
                        }
                        else
                        {
                            tlp2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
                        }
                    }
                }
            }

            ((CheckBox)tableLayoutPanelToggles.GetControlFromPosition(1, 0)).Visible = false;

            DateTime date = DateTime.Now;

            TableLayoutPanel datepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(3, 0));
            ((TextBox)(datepanel.GetControlFromPosition(1, 0))).Text = date.Day.ToString();
            ((TextBox)(datepanel.GetControlFromPosition(2, 0))).Text = date.Month.ToString();
            ((TextBox)(datepanel.GetControlFromPosition(3, 0))).Text = date.Year.ToString();
            
            ((TextBox)(datepanel.GetControlFromPosition(1, 1))).Text = date.Day.ToString();
            ((TextBox)(datepanel.GetControlFromPosition(2, 1))).Text = date.Month.ToString();
            ((TextBox)(datepanel.GetControlFromPosition(3, 1))).Text = date.Year.ToString();

            TableLayoutPanel timepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(5, 0));
            ((TextBox)(timepanel.GetControlFromPosition(1, 0))).Text = "00";
            ((TextBox)(timepanel.GetControlFromPosition(2, 0))).Text = "00";
            ((TextBox)(timepanel.GetControlFromPosition(3, 0))).Text = "00";
            
            ((TextBox)(timepanel.GetControlFromPosition(1, 1))).Text = "23";
            ((TextBox)(timepanel.GetControlFromPosition(2, 1))).Text = "59";
            ((TextBox)(timepanel.GetControlFromPosition(3, 1))).Text = "59";
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
                dataGridView1.DataSource = DBL.StatisticheManager.GetStatisticheCAM(cam, GetToggled(), GetComparisons(), GetAdditionalComparisons());

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    col.DisplayIndex = col.Index;
                }

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

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

            comparisons[0] = (((Button)tableLayoutPanelToggles.GetControlFromPosition(2, 0)).Text == "<>" ? ">" : "<") + " '";
            TableLayoutPanel datepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(3, 0));
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(1, 0))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(2, 0))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(3, 0))).Text;
            comparisons[0] += " ";
            TableLayoutPanel timepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(5, 0));
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(1, 0))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(1, 0))).Text : "00";
            comparisons[0] += ":";
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(2, 0))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(2, 0))).Text : "00";
            comparisons[0] += ":";
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(3, 0))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(3, 0))).Text : "00";
            comparisons[0] += "'";

            for (int i = 1; i < tableLayoutPanelToggles.RowCount - 1; i++)
            {
                if(((TextBox)tableLayoutPanelToggles.GetControlFromPosition(3, i)).Text.Length > 0)
                    comparisons[i] = ((Button)tableLayoutPanelToggles.GetControlFromPosition(2, i)).Text + " " + ((TextBox)tableLayoutPanelToggles.GetControlFromPosition(3, i)).Text;
            }

            return comparisons;
        }

        private string[] GetAdditionalComparisons()
        {
            string[] comparisons = new string[tableLayoutPanelToggles.RowCount - 1];

            comparisons[0] = (((Button)tableLayoutPanelToggles.GetControlFromPosition(2, 0)).Text == "<>" ? "<" : ">") + " '";
            TableLayoutPanel datepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(3, 0));
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(1, 1))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(2, 1))).Text;
            comparisons[0] += "-";
            comparisons[0] += ((TextBox)(datepanel.GetControlFromPosition(3, 1))).Text;
            comparisons[0] += " ";
            TableLayoutPanel timepanel = ((TableLayoutPanel)tableLayoutPanelToggles.GetControlFromPosition(5, 0));
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(1, 1))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(1, 1))).Text : "00";
            comparisons[0] += ":";
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(2, 1))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(2, 1))).Text : "00";
            comparisons[0] += ":";
            comparisons[0] += ((TextBox)(timepanel.GetControlFromPosition(3, 1))).Text != "" ? ((TextBox)(timepanel.GetControlFromPosition(3, 1))).Text : "00";
            comparisons[0] += "'";

            for (int i = 1; i < tableLayoutPanelToggles.RowCount - 1; i++)
            {
                if (((TextBox)tableLayoutPanelToggles.GetControlFromPosition(5, i)).Text.Length > 0)
                    comparisons[i] = ((Button)tableLayoutPanelToggles.GetControlFromPosition(4, i)).Text + " " + ((TextBox)tableLayoutPanelToggles.GetControlFromPosition(5, i)).Text;
            }

            return comparisons;
        }

        private void btnCambiaCAM1_Click(object sender, EventArgs e)
        {
            try
            {
                if (appManager.GetIdStazione() == 2)
                {
                    CreateToggleRows(2);
                    LoadData(appManager.GetIdStazione(), 2);
                    currentCam = 2;
                }
                else
                {
                    CreateToggleRows(1);
                    LoadData(appManager.GetIdStazione(), 1);
                    currentCam = 1;
                }
                btnRemoveWhite.Visible = false;
                GoTop();
            } catch
            {
                MessageBox.Show("Errore in selezione CAM.");
            }
        }

        private void btnCambiaCAM2_Click(object sender, EventArgs e)
        {
            try
            {
                if (appManager.GetIdStazione() == 2)
                {
                    CreateToggleRows(1);
                    LoadData(appManager.GetIdStazione(), 1);
                    currentCam = 1;
                }
                else
                {
                    CreateToggleRows(2);
                    LoadData(appManager.GetIdStazione(), 2);
                    currentCam = 2;
                    if (appManager.GetIdStazione() == 0)
                    {
                        btnRemoveWhite.Visible = true;
                    }
                }
                GoTop();
            }
            catch
            {
                MessageBox.Show("Errore in selezione CAM.");
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

        private void btnToggleComparatorData_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Text == "<>")
            {
                b.Text = "><";
            }
            else if (b.Text == "><")
            {
                b.Text = "<>";
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
            sfd.FileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "_CAM" + appManager.GetIdStazione() + (currentCam == 2 ? "_2" : "") + "Dump.csv";
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
            FormNumericInput fni = new FormNumericInput(-1_0000.0m, 1_0000.0m, ((TextBox)sender).Text != "" ? (decimal)(float.Parse(((TextBox)sender).Text)) : 0.0m, 3);
            if (fni.ShowDialog() == DialogResult.OK)
            {
                ((TextBox)sender).Text = fni.Value.ToString().Replace(',','.');
            }
        }

        private void OpenVirtualKeyboardInt(object sender, EventArgs e)
        {
            FormNumericInput fni = new FormNumericInput(-1_0000.0m, 1_0000.0m, ((TextBox)sender).Text != "" ? (decimal)(float.Parse(((TextBox)sender).Text)) : 0.0m, 0);
            if (fni.ShowDialog() == DialogResult.OK)
            {
                ((TextBox)sender).Text = fni.Value.ToString().Replace(',', '.');
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.HorizontalScrollingOffset >= 200)
                    dataGridView1.HorizontalScrollingOffset -= 200;
                else
                    dataGridView1.HorizontalScrollingOffset = 0;
            } catch
            {

            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.HorizontalScrollingOffset += 200;
            } catch
            {

            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.FirstDisplayedScrollingRowIndex > 10)
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex - 10;
                else
                    dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            } catch
            {

            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount - dataGridView1.FirstDisplayedScrollingRowIndex > 0)
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex + 10;
                else
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount;
            } catch
            {

            }
        }

        private void btnDownParamList_Click(object sender, EventArgs e)
        {
            Point current = tableLayoutPanelToggles.AutoScrollPosition;
            Point scrolled = new Point(current.X, -current.Y + 100);
            tableLayoutPanelToggles.AutoScrollPosition = scrolled;
        }

        private void btnUpParamList_Click(object sender, EventArgs e)
        {
            Point current = tableLayoutPanelToggles.AutoScrollPosition;
            Point scrolled = new Point(current.X, -current.Y - 100);
            tableLayoutPanelToggles.AutoScrollPosition = scrolled;
        }

        private void GoTop()
        {
            Point current = tableLayoutPanelToggles.AutoScrollPosition;
            Point scrolled = new Point(current.X, -current.Y - 1000);
            tableLayoutPanelToggles.AutoScrollPosition = scrolled;
        }
    }
}
