using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaQuery : UserControl
    {
        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaQuery()
        {
            InitializeComponent();

            textBoxData.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBoxOra.Text = "00:00:00";
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
                    btnCambiaCAM1.Visible = false;
                }

                

                LoadData(appManager.GetIdStazione(), 1, DBL.StatisticheManager.AddControlloData(DateTime.Parse(textBoxData.Text + " " + textBoxOra.Text)));
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void CreateToggleRows(int numCam)
        {
            //TODO CLEAR TABLELAYOUT

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
                    nomiParametri.Add("Allineamento COntatto");
                    nomiParametri.Add("Ingombro SX");
                    nomiParametri.Add("Ingombro DX");
                    break;
                case 2:
                    if (numCam == 1)
                    {
                        tableLayoutPanelToggles.RowCount = 5;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("Colonnina SX");
                        nomiParametri.Add("Treccia SX");
                        nomiParametri.Add("Treccia DX");
                        nomiParametri.Add("Colonnina DX");
                    } else
                    {
                        tableLayoutPanelToggles.RowCount = 5;
                        nomiParametri.Add("Data");
                        nomiParametri.Add("1");
                        nomiParametri.Add("2");
                        nomiParametri.Add("3");
                        nomiParametri.Add("4");
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
        }

        private void LoadData(int idStazione, int numCam, string extraParameters = "")
        {
            string cam = "CAM" + idStazione.ToString();
            if (numCam == 2)
            {
                cam += "_2";
            }
            dataGridView1.DataSource = DBL.StatisticheManager.GetStatisticheCAM(cam, extraParameters);
        }

        private void btnCambiaCAM1_Click(object sender, EventArgs e)
        {
            LoadData(appManager.GetIdStazione(), 1, DBL.StatisticheManager.AddControlloData(DateTime.Parse(textBoxData.Text + " " + textBoxOra.Text)));
        }

        private void btnCambiaCAM2_Click(object sender, EventArgs e)
        {
            LoadData(appManager.GetIdStazione(), 2, DBL.StatisticheManager.AddControlloData(DateTime.Parse(textBoxData.Text + " " + textBoxOra.Text)));
        }
    }
}
