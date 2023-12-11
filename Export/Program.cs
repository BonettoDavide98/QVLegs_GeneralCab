using QVLEGS.DBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Export
{
    class Program
    {
        static void Main(string[] args)
        {
            QVLEGS.Class.ExceptionManager.Init();
            try
            {
                Console.WriteLine("START EXPORT");

                DateTime d = DateTime.Now.Subtract(TimeSpan.FromDays(1));

                DateTime from = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                DateTime to = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);

                Console.WriteLine($"EXPORT DATA FROM {from} - TO {to}");

                string fileName = System.IO.Path.Combine(Properties.Settings.Default.Path, $"EXPORT_{d:yyyyMMdd}.csv");

                DataTable dt = GetDatiGraficoTipoScartoExport(0, from, to);
                Export(dt, fileName);

                Console.WriteLine($"DATA SAVED IN {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                QVLEGS.Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                Console.WriteLine("END EXPORT");
            }
        }

        private static DataTable GetDatiGraficoTipoScartoExport(int idStazione, DateTime from, DateTime to)
        {
            DataTable ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(Properties.Settings.Default.ConnectionString, false))
                {
                    string sqlStr = @"
SELECT 
	IdFormato
	,(CASE WHEN Chiave = 'TOT' THEN 'ALG_CNT' ELSE Chiave END) AS Chiave
	,SUM(Valore) AS Valore 
	,CAST([TimeStamp] AS DATE) AS Data
	,DATEPART(HOUR, [TimeStamp]) AS Ora
FROM TabStoricoStatisticheContatori
WHERE IdStazione = @IdStazione
AND TimeStamp BETWEEN @From AND @To
AND Chiave NOT LIKE 'CNT_KO_CAM%'
--AND Chiave NOT IN ('TOT')
GROUP BY 
      IdFormato
	  ,Chiave
	  ,CAST([TimeStamp] AS DATE)
	  ,DATEPART(HOUR, [TimeStamp])
ORDER BY 4,5,1,2;";

                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@IdStazione", idStazione));
                    param.Add(new SqlParameter("@From", from));
                    param.Add(new SqlParameter("@To", to));

                    ret = mngr.FillDataTable(sqlStr, param);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        private static void Export(DataTable dt, string fileName)
        {
            try
            {
                DataTable ret = new DataTable();
                ret.Columns.Add(new DataColumn("Data", typeof(DateTime)));
                ret.Columns.Add(new DataColumn("Ora", typeof(int)));
                ret.Columns.Add(new DataColumn("IdFormato", typeof(string)));


                string content = string.Empty;

                DateTime prevData = DateTime.MinValue;
                int prevOra = -1;
                string prevId = string.Empty;

                DataRow lastRow = null;

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];
                    int valore = (int)item["Valore"];
                    DateTime data = (DateTime)item["Data"];
                    int ora = (int)item["Ora"];
                    string id = (string)item["IdFormato"];

                    if (prevData != data || prevOra != ora || id != prevId)
                    {
                        lastRow = ret.Rows.Add();

                        lastRow["Data"] = data;
                        lastRow["Ora"] = ora;
                        lastRow["IdFormato"] = id;

                        prevData = data;
                        prevOra = ora;
                        prevId = id;
                    }

                    if (!ret.Columns.Contains(chiave))
                    {
                        ret.Columns.Add(new DataColumn(chiave, typeof(int)));
                    }

                    if (lastRow != null)
                    {
                        lastRow[chiave] = valore;
                    }

                    //string nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + chiave);

                    //content += string.Format("{0};{1};{2};{3}\n\r", nomeColonna, valore, data.ToString("yyyy/MM/dd"), ora);
                }


                foreach (DataColumn item in ret.Columns)
                {
                    string nomeColonna = "";

                    if (item.ColumnName == "Data")
                        nomeColonna = "Date";
                    else if (item.ColumnName == "Ora")
                        nomeColonna = "Time";
                    else if (item.ColumnName == "IdFormato")
                        nomeColonna = "Id Recipe";
                    else
                        nomeColonna = item.ColumnName;   //nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + item.ColumnName);

                    content += nomeColonna + ";";
                }

                content += "\n\r";

                foreach (DataRow item in ret.Rows)
                {

                    foreach (DataColumn item2 in ret.Columns)
                    {
                        string val = "";

                        if (item2.ColumnName == "Data")
                            val = ((DateTime)item[item2.ColumnName]).ToString("yyyy/MM/dd");
                        else if (item2.ColumnName == "IdFormato")
                            val = (string)item[item2.ColumnName];
                        else
                            val = ((int)item[item2.ColumnName]).ToString();

                        content += val + ";";
                    }

                    content += "\n\r";
                    //content += string.Format("{0};{1};{2};{3}\n\r", nomeColonna, valore, data.ToString("yyyy/MM/dd"), ora);
                }


                System.IO.File.WriteAllText(fileName, content);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
