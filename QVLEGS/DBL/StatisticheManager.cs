using QVLEGS.DataType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QVLEGS.DBL
{
    public class StatisticheManager
    {

        public static string ConnectionString { get; set; }


        public static bool InserisciTabStatisticheMisureTmp(List<DataType.StatisticheObj> s)
        {
            bool ret = true;
            try
            {
                DataTable tbl = new DataTable();

                tbl.Columns.Add(new DataColumn("IdStazione", typeof(int)));
                tbl.Columns.Add(new DataColumn("IdCamera", typeof(int)));
                tbl.Columns.Add(new DataColumn("DataRiferimentoTurno", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("NomeTurno", typeof(Int16)));
                tbl.Columns.Add(new DataColumn("IdFormato", typeof(string)));
                tbl.Columns.Add(new DataColumn("TimeStamp", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("Chiave", typeof(string)));
                tbl.Columns.Add(new DataColumn("Bucket", typeof(int)));
                tbl.Columns.Add(new DataColumn("Valore", typeof(int)));

                foreach (var item in s)
                {
                    foreach (var mis in item.Misure)
                    {
                        double b = Algoritmi.AlgoritmoLavoro.GetBucketByKey(mis.Nome);

                        DataRow row = tbl.NewRow();
                        row["IdStazione"] = item.IdStazione;
                        row["IdCamera"] = item.IdCamera;
                        row["DataRiferimentoTurno"] = item.DataRiferimentoTurno;
                        row["NomeTurno"] = item.NomeTurno;
                        row["IdFormato"] = item.IdFormato;
                        row["TimeStamp"] = new DateTime(item.TimeStamp.Year, item.TimeStamp.Month, item.TimeStamp.Day, item.TimeStamp.Hour, item.TimeStamp.Minute, 0);
                        row["Chiave"] = mis.Nome;
                        row["Bucket"] = (int)(mis.Valore / b);
                        row["Valore"] = 1;

                        tbl.Rows.Add(row);
                    }
                }

                Dictionary<string, string> mapping = new Dictionary<string, string>();

                mapping.Add("IdStazione", "IdStazione");
                mapping.Add("IdCamera", "IdCamera");
                mapping.Add("DataRiferimentoTurno", "DataRiferimentoTurno");
                mapping.Add("NomeTurno", "NomeTurno");
                mapping.Add("IdFormato", "IdFormato");
                mapping.Add("TimeStamp", "TimeStamp");
                mapping.Add("Chiave", "Chiave");
                mapping.Add("Bucket", "Bucket");
                mapping.Add("Valore", "Valore");

                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    mngr.BulkCopy("TabStatisticheMisureTmp", mapping, tbl);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static bool InserisciTabStatisticheContatoriTmp(DataType.StatisticheObjContatori s)
        {
            bool ret = true;
            try
            {
                DataTable tbl = new DataTable();

                tbl.Columns.Add(new DataColumn("IdStazione", typeof(int)));
                tbl.Columns.Add(new DataColumn("DataRiferimentoTurno", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("NomeTurno", typeof(Int16)));
                tbl.Columns.Add(new DataColumn("IdFormato", typeof(string)));
                tbl.Columns.Add(new DataColumn("TimeStamp", typeof(DateTime)));
                tbl.Columns.Add(new DataColumn("Chiave", typeof(string)));
                tbl.Columns.Add(new DataColumn("Bucket", typeof(int)));
                tbl.Columns.Add(new DataColumn("Valore", typeof(int)));

                foreach (var item in s.Contatori)
                {
                    DataRow row = tbl.NewRow();
                    row["IdStazione"] = s.IdStazione;
                    row["DataRiferimentoTurno"] = s.DataRiferimentoTurno;
                    row["NomeTurno"] = s.NomeTurno;
                    row["IdFormato"] = s.IdFormato;
                    row["TimeStamp"] = new DateTime(s.TimeStamp.Year, s.TimeStamp.Month, s.TimeStamp.Day, s.TimeStamp.Hour, s.TimeStamp.Minute, 0);
                    row["Chiave"] = item.Nome;
                    row["Valore"] = item.Valore;

                    tbl.Rows.Add(row);
                }

                Dictionary<string, string> mapping = new Dictionary<string, string>();

                mapping.Add("IdStazione", "IdStazione");
                mapping.Add("DataRiferimentoTurno", "DataRiferimentoTurno");
                mapping.Add("NomeTurno", "NomeTurno");
                mapping.Add("IdFormato", "IdFormato");
                mapping.Add("TimeStamp", "TimeStamp");
                mapping.Add("Chiave", "Chiave");
                mapping.Add("Valore", "Valore");

                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    mngr.BulkCopy("TabStatisticheContatoriTmp", mapping, tbl);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }

        public static void AggiornaTabStoricoStatisticheMisure()
        {
            try
            {
                bool ok = true;
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    try
                    {
                        string sqlStr = @"
MERGE TabStoricoStatisticheMisure AS ogs
USING (
	SELECT [IdStazione]
		,[IdCamera]
		,[DataRiferimentoTurno]
		,[NomeTurno]
		,[IdFormato]
		,[TimeStamp]
		,[Chiave]
		,[Bucket]
		,SUM([Valore]) AS f
	FROM [dbo].[TabStatisticheMisureTmp]
	GROUP BY [IdStazione]
		,[IdCamera]
		,[DataRiferimentoTurno]
		,[NomeTurno]
		,[IdFormato]
		,[TimeStamp]
		,[Chiave]
		,[Bucket]
) AS ogs_new
ON ogs.[IdStazione] = ogs_new.[IdStazione]
AND ogs.[IdCamera] = ogs_new.[IdCamera]
AND ogs.[DataRiferimentoTurno] = ogs_new.[DataRiferimentoTurno]
AND ogs.[NomeTurno] = ogs_new.[NomeTurno]
AND ogs.[IdFormato] = ogs_new.[IdFormato]
AND ogs.[TimeStamp] = ogs_new.[TimeStamp]
AND ogs.[Chiave] = ogs_new.[Chiave]
AND ogs.[Bucket] = ogs_new.[Bucket]
WHEN MATCHED THEN 
	UPDATE 
		SET Valore = Valore + ogs_new.f
WHEN NOT MATCHED THEN
INSERT ([IdStazione]
		,[IdCamera]
        ,[DataRiferimentoTurno]
        ,[NomeTurno]
        ,[IdFormato]
        ,[TimeStamp]
        ,[Chiave]
        ,[Bucket]
        ,[Valore])
    VALUES
        (ogs_new.[IdStazione]
		,ogs_new.[IdCamera]
        ,ogs_new.[DataRiferimentoTurno]
		,ogs_new.[NomeTurno]
		,ogs_new.[IdFormato]
		,ogs_new.[TimeStamp]
		,ogs_new.[Chiave]
		,ogs_new.[Bucket]
		,ogs_new.[f]);";

                        List<SqlParameter> param = new List<SqlParameter>();

                        mngr.ExecuteNonQuery(sqlStr, param);

                        mngr.ExecuteNonQuery("TRUNCATE TABLE TabStatisticheMisureTmp;");
                    }
                    catch (Exception)
                    {
                        ok = false;
                        throw;
                    }
                    finally
                    {
                        if (ok)
                        {
                            mngr.CommitTransaction();
                        }
                        else
                        {
                            mngr.RollbackTransaction();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AggiornaTabStoricoStatisticheContatori()
        {
            try
            {
                bool ok = true;
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    try
                    {
                        string sqlStr = @"
MERGE TabStoricoStatisticheContatori AS ogs
USING (
	SELECT [IdStazione]
		,[DataRiferimentoTurno]
		,[NomeTurno]
		,[IdFormato]
		,[TimeStamp]
		,[Chiave]
		,SUM([Valore]) AS f
	FROM [dbo].[TabStatisticheContatoriTmp]
	GROUP BY [IdStazione]
		,[DataRiferimentoTurno]
		,[NomeTurno]
		,[IdFormato]
		,[TimeStamp]
		,[Chiave]
) AS ogs_new
ON ogs.[IdStazione] = ogs_new.[IdStazione]
AND ogs.[DataRiferimentoTurno] = ogs_new.[DataRiferimentoTurno]
AND ogs.[NomeTurno] = ogs_new.[NomeTurno]
AND ogs.[IdFormato] = ogs_new.[IdFormato]
AND ogs.[TimeStamp] = ogs_new.[TimeStamp]
AND ogs.[Chiave] = ogs_new.[Chiave]
WHEN MATCHED THEN 
	UPDATE 
		SET Valore = Valore + ogs_new.f
WHEN NOT MATCHED THEN
INSERT ([IdStazione]
        ,[DataRiferimentoTurno]
        ,[NomeTurno]
        ,[IdFormato]
        ,[TimeStamp]
        ,[Chiave]
        ,[Valore])
    VALUES
        (ogs_new.[IdStazione]
        ,ogs_new.[DataRiferimentoTurno]
		,ogs_new.[NomeTurno]
		,ogs_new.[IdFormato]
		,ogs_new.[TimeStamp]
		,ogs_new.[Chiave]
		,ogs_new.[f]);";

                        List<SqlParameter> param = new List<SqlParameter>();

                        mngr.ExecuteNonQuery(sqlStr, param);

                        mngr.ExecuteNonQuery("TRUNCATE TABLE TabStatisticheContatoriTmp;");
                    }
                    catch (Exception)
                    {
                        ok = false;
                        throw;
                    }
                    finally
                    {
                        if (ok)
                        {
                            mngr.CommitTransaction();
                        }
                        else
                        {
                            mngr.RollbackTransaction();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string GetSelectQueryStatisticheTipoScarto()
        {
            return @"
SELECT 
	Chiave
	,SUM(Valore) AS Valore 
FROM TabStoricoStatisticheContatori";
        }

        public static DataTable GetDatiGraficoTipoScartoTurnoAttuale(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheTipoScarto();

                        sqlStr += @"
WHERE NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
AND Chiave NOT LIKE 'CNT_KO_CAM%'
AND Chiave NOT IN ('TOT')
GROUP BY Chiave
ORDER BY Chiave;";

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiGraficoTipoScartoTurnoPrecedente(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheTipoScarto();

                        sqlStr += @"
WHERE NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
AND Chiave NOT LIKE 'CNT_KO_CAM%'
AND Chiave NOT IN ('TOT')
GROUP BY Chiave
ORDER BY Chiave;";

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiGraficoTipoScartoUltimaOra(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheTipoScarto();

                        sqlStr += @"
WHERE [TimeStamp] > DATEADD(HH, -1, GETDATE())
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
AND Chiave NOT LIKE 'CNT_KO_CAM%'
AND Chiave NOT IN ('TOT')
GROUP BY Chiave
ORDER BY Chiave;";

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiGraficoTipoScarto(int idStazione, DateTime from, DateTime to)
        {
            DataTable ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                { 
                    string sqlStr = @"
SELECT 
	(CASE WHEN Chiave = 'TOT' THEN 'ALG_CNT' ELSE Chiave END) AS Chiave
	,SUM(Valore) AS Valore 
FROM TabStoricoStatisticheContatori
WHERE IdStazione = @IdStazione
AND TimeStamp BETWEEN @From AND @To
AND Chiave NOT LIKE 'CNT_KO_CAM%'
--AND Chiave NOT IN ('TOT')
GROUP BY Chiave
ORDER BY Chiave;";

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

        public static DataTable GetDatiGraficoTipoScartoExport(int idStazione, DateTime from, DateTime to)
        {
            DataTable ret = null;
            try
            {
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
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

        public static string GetSelectQueryStatisticheMisure()
        {
            return @"
SELECT 
    [Bucket] * @Bucket AS val
    ,SUM([Valore]) AS f
FROM [TabStoricoStatisticheMisure]
WHERE Chiave = @Chiave
AND IdFormato = @IdFormato
{0}
GROUP BY [Bucket]";
        }

        public static DataTable GetDatiGraficoMisureTurnoAttuale(int idStazione, string colonna, double bucket)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheMisure();

                        string whereClausole = @"
AND NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdStazione = @IdStazione";

                        sqlStr = string.Format(sqlStr, whereClausole);

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@Bucket", bucket));
                        param.Add(new SqlParameter("@Chiave", colonna));
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiGraficoMisureTurnoPrecedente(int idStazione, string colonna, double bucket)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheMisure();

                        string whereClausole = @"
AND NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdStazione = @IdStazione";

                        sqlStr = string.Format(sqlStr, whereClausole);

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@Bucket", bucket));
                        param.Add(new SqlParameter("@Chiave", colonna));
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiGraficoMisureUltimaOra(int idStazione, string colonna, double bucket)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheMisure();

                        string whereClausole = @"
AND [TimeStamp] > DATEADD(HH, -1, GETDATE())
AND IdStazione = @IdStazione";

                        sqlStr = string.Format(sqlStr, whereClausole);

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@Bucket", bucket));
                        param.Add(new SqlParameter("@Chiave", colonna));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }


        public static DataTable GetDatiGraficoMisureUltimaOra4CSV(int idStazione, string colonna, double bucket)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = @"SELECT *
FROM[TabStoricoStatisticheMisure]
WHERE Chiave = @Chiave
AND[TimeStamp] > DATEADD(HH, -1, GETDATE())
AND IdStazione = @IdStazione";

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@Chiave", colonna));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static string GetSelectQueryStatisticheContatori()
        {
            return @"
SELECT 
	Chiave
	,SUM(Valore) AS Valore 
FROM TabStoricoStatisticheContatori";
        }

        public static DataTable GetDatiContatoriTurnoAttuale(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheContatori();

                        string whereClausole = @"
WHERE NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
GROUP BY Chiave;";

                        sqlStr = sqlStr + whereClausole;

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiContatoriTurnoPrecedente(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheContatori();

                        string whereClausole = @"
WHERE NomeTurno = @NomeTurno
AND DataRiferimentoTurno = @DataRiferimentoTurno
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
GROUP BY Chiave;";

                        sqlStr = sqlStr + whereClausole;

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@NomeTurno", turnoAttuale.NomeTurno));
                        param.Add(new SqlParameter("@DataRiferimentoTurno", turnoAttuale.Data));
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static DataTable GetDatiContatoriUltimaOra(int idStazione)
        {
            DataTable ret = null;
            try
            {
                long idTurno = GestioneTurniManager.ReadID_TurnoAttuale();
                DataType.StoricoTurni turnoAttuale = GestioneTurniManager.Select_StoricoTurni(idTurno - 1);

                string idFormato = ImpostazioniManager.ReadFormatoCorrente();

                if (turnoAttuale != null)
                {
                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        string sqlStr = GetSelectQueryStatisticheContatori();

                        string whereClausole = @"
WHERE [TimeStamp] > DATEADD(HH, -1, GETDATE())
AND IdFormato = @IdFormato
AND IdStazione = @IdStazione
GROUP BY Chiave;";

                        sqlStr = sqlStr + whereClausole;

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@IdFormato", idFormato));
                        param.Add(new SqlParameter("@IdStazione", idStazione));

                        ret = mngr.FillDataTable(sqlStr, param);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public static void RegistraStatisticheDettagliate(ElaborateResult[] risultati)
        {
            try
            {
                for (int i = 0; i < risultati.Length; i++)
                {
                    DataType.StatisticheObj statistiche = risultati[i].StatisticheObj;

                    if (statistiche.Misure.Count == 0)
                    {
                        return;
                    }

                    string query = @"INSERT INTO CAM" + statistiche.IdCamera;

                    if (i == 1)
                    {
                        query += "_2";
                    }

                    query += " VALUES ('" + statistiche.TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss") + "'";

                    if (i == 1 && statistiche.IdCamera == 0)
                    {
                        for (int j = 0; j < statistiche.Misure.Count; j++)
                        {
                            query += ", " + statistiche.Misure[j].Valore.ToString().Replace(',', '.');

                            if (j + 1 < statistiche.Misure.Count && statistiche.Misure[j + 1].Nome.Contains("_W"))
                            {
                                query += ", " + statistiche.Misure[j + 1].Valore.ToString().Replace(',', '.');
                                j++;
                            }
                            else
                            {
                                query += ", NULL";
                            }
                        }
                    }
                    else
                    {
                        foreach (DataType.StatisticheObj.ObjMisura misura in statistiche.Misure)
                        {
                            query += ", " + misura.Valore.ToString().Replace(',', '.');
                        }
                    }

                    query += ");";

                    using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                    {
                        mngr.FillDataTable(query);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatisticheCAM(string camera, bool[] toggled, string[] comparisons)
        {
            try
            {
                DataTable dt = null;
                string appendSelect = "";
                string appendWhere = "";
                AppendToggled(toggled, comparisons, camera, out appendSelect, out appendWhere);

                string query = "SELECT ";

                query += appendSelect;

                query += " FROM " + camera;

                if (appendWhere != "")
                {
                    Console.WriteLine(appendWhere);
                    query += " WHERE " + appendWhere;
                }

                query += ";";
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    dt = mngr.FillDataTable(query);
                }
                return dt;
            } catch
            {
                return null;
            }
        }

        public static DataTable GetStatisticheCAM(string camera)
        {
            try
            {
                DataTable dt = null;
                string query = "SELECT * FROM " + camera + ";";
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    dt = mngr.FillDataTable(query);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private static void AppendToggled(bool[] toggled, string[] comparisons, string camera, out string appendSelect, out string appendWhere)
        {
            appendSelect = "Data";
            appendWhere = "";

            switch(camera)
            {
                case"CAM0":
                    if (toggled[1])
                    {
                        appendSelect +=",[CondLatMpin1]";
                        if(comparisons[1] != null)
                            appendWhere +=" AND CondLatMpin1" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[CondLatMpin2]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND CondLatMpin2" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[CondLatPpin1]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND CondLatPpin1" + comparisons[3];
                    }
                    if (toggled[4])
                    {
                        appendSelect +=",[CondLatPpin2]";
                        if (comparisons[4] != null)
                            appendWhere +=" AND CondLatPpin2" + comparisons[4];
                    }
                    if (toggled[5])
                    {
                        appendSelect +=",[SpazzolaSX]";
                        if (comparisons[5] != null)
                            appendWhere +=" AND SpazzolaSX" + comparisons[5];
                    }
                    if (toggled[6])
                    {
                        appendSelect +=",[SpazzolaDX]";
                        if (comparisons[6] != null)
                            appendWhere +=" AND SpazzolaDX" + comparisons[6];
                    }
                    if (toggled[7])
                    {
                        appendSelect +=",[Diametro]";
                        if (comparisons[7] != null)
                            appendWhere +=" AND Diametro" + comparisons[7];
                    }
                    break;
                case"CAM0_2":
                    if (toggled[1])
                    {
                        appendSelect +=",[ThresholdNeroProtettorepin1]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND ThresholdNeroProtettorepin1" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[ThresholdBiancoProtettorepin1]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND ThresholdBiancoProtettorepin1" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[ThresholdNeroProtettorepin2]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND ThresholdNeroProtettorepin2" + comparisons[3];
                    }
                    if (toggled[4])
                    {
                        appendSelect +=",[ThresholdBiancoProtettorepin2]";
                        if (comparisons[4] != null)
                            appendWhere +=" AND ThresholdBiancoProtettorepin2" + comparisons[4];
                    }
                    if (toggled[5])
                    {
                        appendSelect +=",[ThresholdNeroCondensatoreLatMpin1]";
                        if (comparisons[5] != null)
                            appendWhere +=" AND ThresholdNeroCondensatoreLatMpin1" + comparisons[5];
                    }
                    if (toggled[6])
                    {
                        appendSelect +=",[ThresholdBiancoCondensatoreLatMpin1]";
                        if (comparisons[6] != null)
                            appendWhere +=" AND ThresholdBiancoCondensatoreLatMpin1" + comparisons[6];
                    }
                    if (toggled[7])
                    {
                        appendSelect +=",[ThresholdNeroCondensatoreLatMpin2]";
                        if (comparisons[7] != null)
                            appendWhere +=" AND ThresholdNeroCondensatoreLatMpin2" + comparisons[7];
                    }
                    if (toggled[8])
                    {
                        appendSelect +=",[ThresholdBiancoCondensatoreLatMpin2]";
                        if (comparisons[8] != null)
                            appendWhere +=" AND ThresholdBiancoCondensatoreLatMpin2" + comparisons[8];
                    }
                    if (toggled[9])
                    {
                        appendSelect +=",[ThresholdNeroImpendenzaLatM]";
                        if (comparisons[9] != null)
                            appendWhere +=" AND ThresholdNeroImpendenzaLatM" + comparisons[9];
                    }
                    if (toggled[10])
                    {
                        appendSelect +=",[ThresholdBiancoImpendenzaLatM]";
                        if (comparisons[10] != null)
                            appendWhere +=" AND ThresholdBiancoImpendenzaLatM" + comparisons[10];
                    }
                    if (toggled[11])
                    {
                        appendSelect +=",[ThresholdNeroVaristorepin1]";
                        if (comparisons[11] != null)
                            appendWhere +=" AND ThresholdNeroVaristorepin1" + comparisons[11];
                    }
                    if (toggled[12])
                    {
                        appendSelect +=",[ThresholdBiancoVaristorepin1]";
                        if (comparisons[12] != null)
                            appendWhere +=" AND ThresholdBiancoVaristorepin1" + comparisons[12];
                    }
                    if (toggled[13])
                    {
                        appendSelect +=",[ThresholdNeroVaristorepin2]";
                        if (comparisons[13] != null)
                            appendWhere +=" AND ThresholdNeroVaristorepin2" + comparisons[13];
                    }
                    if (toggled[14])
                    {
                        appendSelect +=",[ThresholdBiancoVaristorepin2]";
                        if (comparisons[14] != null)
                            appendWhere +=" AND ThresholdBiancoVaristorepin2" + comparisons[14];
                    }
                    if (toggled[15])
                    {
                        appendSelect +=",[ThresholdNeroCondensatoreLatPpin1]";
                        if (comparisons[15] != null)
                            appendWhere +=" AND ThresholdNeroCondensatoreLatPpin1" + comparisons[15];
                    }
                    if (toggled[16])
                    {
                        appendSelect +=",[ThresholdBiancoCondensatoreLatPpin1]";
                        if (comparisons[16] != null)
                            appendWhere +=" AND ThresholdBiancoCondensatoreLatPpin1" + comparisons[16];
                    }
                    if (toggled[17])
                    {
                        appendSelect +=",[ThresholdNeroCondensatoreLatPpin2]";
                        if (comparisons[17] != null)
                            appendWhere +=" AND ThresholdNeroCondensatoreLatPpin2" + comparisons[17];
                    }
                    if (toggled[18])
                    {
                        appendSelect +=",[ThresholdBiancoCondensatoreLatPpin2]";
                        if (comparisons[18] != null)
                            appendWhere +=" AND ThresholdBiancoCondensatoreLatPpin2" + comparisons[18];
                    }
                    if (toggled[19])
                    {
                        appendSelect +=",[ThresholdNeroImpendenzaLatP]";
                        if (comparisons[19] != null)
                            appendWhere +=" AND ThresholdNeroImpendenzaLatP" + comparisons[19];
                    }
                    if (toggled[20])
                    {
                        appendSelect +=",[ThresholdBiancoImpendenzaLatP]";
                        if (comparisons[20] != null)
                            appendWhere +=" AND ThresholdBiancoImpendenzaLatP" + comparisons[20];
                    }
                    break;
                case"CAM1":
                    if (toggled[1])
                    {
                        appendSelect +=",[AllineamentoContatto]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND AllineamentoContatto" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[IngombroSX]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND IngombroSX" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[IngombroDX]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND IngombroDX" + comparisons[3];
                    }
                    break;
                case"CAM2":
                    if (toggled[1])
                    {
                        appendSelect +=",[ColonninaSX]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND ColonninaSX" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[TrecciaSX]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND TrecciaSX" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[TrecciaDX]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND TrecciaDX" + comparisons[3];
                    }
                    if (toggled[4])
                    {
                        appendSelect +=",[ColonninaDX]";
                        if (comparisons[4] != null)
                            appendWhere +=" AND ColonninaDX" + comparisons[4];
                    }
                    break;
                case"CAM2_2":
                    if (toggled[1])
                    {
                        appendSelect +=",[val1]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND val1" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[val2]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND val2" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[val3]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND val3" + comparisons[3];
                    }
                    if (toggled[4])
                    {
                        appendSelect +=",[val4]";
                        if (comparisons[4] != null)
                            appendWhere +=" AND val4" + comparisons[4];
                    }
                    break;
                case"CAM3":
                    if (toggled[1])
                    {
                        appendSelect +=",[ZonaLibera]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND ZonaLibera" + comparisons[1];
                    }
                    if (toggled[2])
                    {
                        appendSelect +=",[MollettaLatM]";
                        if (comparisons[2] != null)
                            appendWhere +=" AND MollettaLatM" + comparisons[2];
                    }
                    if (toggled[3])
                    {
                        appendSelect +=",[MollettaLatP]";
                        if (comparisons[3] != null)
                            appendWhere +=" AND MollettaLatP" + comparisons[3];
                    }
                    if (toggled[4])
                    {
                        appendSelect +=",[IngombroSXvaristore]";
                        if (comparisons[4] != null)
                            appendWhere +=" AND IngombroSXvaristore" + comparisons[4];
                    }
                    if (toggled[5])
                    {
                        appendSelect +=",[IngombroCondensatore]";
                        if (comparisons[5] != null)
                            appendWhere +=" AND IngombroCondensatore" + comparisons[5];
                    }
                    if (toggled[6])
                    {
                        appendSelect +=",[IngombroSottoVaristore]";
                        if (comparisons[6] != null)
                            appendWhere +=" AND IngombroSottoVaristore" + comparisons[6];
                    }
                    if (toggled[7])
                    {
                        appendSelect +=",[Diametro]";
                        if (comparisons[7] != null)
                            appendWhere +=" AND Diametro" + comparisons[7];
                    }
                    if (toggled[8])
                    {
                        appendSelect +=",[Varistore]";
                        if (comparisons[8] != null)
                            appendWhere +=" AND Varistore" + comparisons[8];
                    }
                    if (toggled[9])
                    {
                        appendSelect +=",[CondensatoreDX]";
                        if (comparisons[9] != null)
                            appendWhere +=" AND CondensatoreDX" + comparisons[9];
                    }
                    if (toggled[10])
                    {
                        appendSelect +=",[IngombroSopraVaristore]";
                        if (comparisons[10] != null)
                            appendWhere +=" AND IngombroSopraVaristore" + comparisons[10];
                    }
                    if (toggled[11])
                    {
                        appendSelect +=",[CondensatoreSX]";
                        if (comparisons[11] != null)
                            appendWhere +=" AND CondensatoreSX" + comparisons[11];
                    }
                    if (toggled[12])
                    {
                        appendSelect +=",[IngombroSXcondensatore]";
                        if (comparisons[12] != null)
                            appendWhere +=" AND IngombroSXcondensatore" + comparisons[12];
                    }
                    if (toggled[13])
                    {
                        appendSelect +=",[InduttanzaLatP]";
                        if (comparisons[13] != null)
                            appendWhere +=" AND InduttanzaLatP" + comparisons[13];
                    }
                    if (toggled[14])
                    {
                        appendSelect +=",[InduttanzaLatM]";
                        if (comparisons[14] != null)
                            appendWhere +=" AND InduttanzaLatM" + comparisons[14];
                    }
                    if (toggled[15])
                    {
                        appendSelect +=",[Diametro2]";
                        if (comparisons[15] != null)
                            appendWhere +=" AND Diametro2" + comparisons[15];
                    }
                    break;
                case"CAM4":
                    if (toggled[1])
                    {
                        appendSelect +=",[ControlloForo]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND ControlloForo" + comparisons[1];
                    }
                    break;
                case"CAM4_2":
                    if (toggled[1])
                    {
                        appendSelect +=",[MollettaLatM]";
                        if (comparisons[1] != null)
                            appendWhere +=" AND MollettaLatM" + comparisons[1];
                    }
                    break;
            }

            if(appendWhere != "")
            {
                appendWhere = appendWhere.Substring(5);
            }
        }

        public static string AddControlloData(DateTime dt)
        {
            return "Data > '" + dt.ToString("yyyy-MM-dd") + "T00:00:00.0000000'";
        }
    }
}