using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QVLEGS.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat2Dettaglio : UserControl
    {

        public class ObjCmb
        {
            public string Colonna { get; set; }
            public string Descrizione { get; set; }
        }

        private int idStazione = -1;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaViewStat2Dettaglio()
        {
            InitializeComponent();
        }

        public void Init(int idStazione, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.idStazione = idStazione;
                this.linguaManager = linguaManager;

                string[] colonne = Algoritmi.AlgoritmoLavoro.GetAllKey(this.idStazione);
                objCmbBindingSource.DataSource = colonne.Select(k => new ObjCmb() { Colonna = k, Descrizione = linguaManager.GetTranslation("LBL_D_" + k) });
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTurnoPrecedente.Text = linguaManager.GetTranslation("LBL_TURNO_PRECEDENTE");
            lblTurnoAttuale.Text = linguaManager.GetTranslation("LBL_TURNO_ATTUALE");
            lblUltimaOra.Text = linguaManager.GetTranslation("LBL_ULTIMA_ORA");
        }

        public void RefreshGrafico()
        {
            try
            {
                ObjCmb o = (ObjCmb)cmbTipoGrafico.SelectedItem;
                if (o != null)
                {
                    string colonna = o.Colonna;
                    if (!string.IsNullOrWhiteSpace(colonna))
                    {
                        double b = Algoritmi.AlgoritmoLavoro.GetBucketByKey(colonna);

                        DataTable dtTurnoPrecedente = DBL.StatisticheManager.GetDatiGraficoMisureTurnoPrecedente(this.idStazione, colonna, b);
                        MostraGrafico(dtTurnoPrecedente, chartTurnoPrecedente);
                        DataTable dtTurnoAttuale = DBL.StatisticheManager.GetDatiGraficoMisureTurnoAttuale(this.idStazione, colonna, b);
                        MostraGrafico(dtTurnoAttuale, chartTurnoAttuale);
                        DataTable dtUltimaOra = DBL.StatisticheManager.GetDatiGraficoMisureUltimaOra(this.idStazione, colonna, b);
                        MostraGrafico(dtUltimaOra, chartUltimaOra);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO MessageBox.Show(ex.ToString());
            }
        }

        public void MostraGrafico(DataTable dt, Chart chart)
        {
            try
            {
                chart.Series[0].Points.Clear();

                foreach (DataRow item in dt.Rows)
                {
                    chart.Series[0].Points.AddXY(item["val"], item["f"]);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrafico();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    ObjCmb o = (ObjCmb)cmbTipoGrafico.SelectedItem;
                    if (o != null)
                    {
                        string colonna = o.Colonna;
                        if (!string.IsNullOrWhiteSpace(colonna))
                        {
                            double b = Algoritmi.AlgoritmoLavoro.GetBucketByKey(colonna);
                            sfd.Filter = "CSV Image|*.csv";
                            sfd.Title = "Export";
                            sfd.FileName = string.Format("{0}.csv", DateTime.Now.ToString("yyyyMMdd_HH_mm_ss.fff"));
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                DataTable dtTurnoAttuale = DBL.StatisticheManager.GetDatiGraficoMisureUltimaOra(this.idStazione, colonna, b);
                                Export(dtTurnoAttuale, sfd.FileName/*, colonna*/);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void Export(DataTable dt, string fileName/*, string chiave*/)
        {
            try
            {
                string content = string.Empty;

                foreach (DataRow item in dt.Rows)
                {
                    for (int i = 0; i < (int)item["f"]; i++)
                    {
                        content += item["val"] + ";";
                    }
                }
                System.IO.File.WriteAllText(fileName, content);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }
    }
}