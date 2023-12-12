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

                if(appManager.GetIdStazione() % 2 == 1)
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
