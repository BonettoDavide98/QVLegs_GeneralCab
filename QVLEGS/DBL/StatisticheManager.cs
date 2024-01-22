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

                    query += ", " + (risultati[i].Success ? "1" : "0");

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

                            if (j + 1 < statistiche.Misure.Count && statistiche.Misure[j + 1].Nome.Contains("_B2"))
                            {
                                query += ", " + statistiche.Misure[j + 1].Valore.ToString().Replace(',', '.');
                                j++;
                            }
                            else
                            {
                                query += ", NULL";
                            }
                        }
                    } else
                    {
                        if (i == 0 && statistiche.IdCamera == 2)
                        {
                            statistiche.Misure.RemoveAt(1);
                        }
                        foreach (DataType.StatisticheObj.ObjMisura misura in statistiche.Misure)
                        {
                            query += ", " + misura.Valore.ToString().Replace(',', '.');
                        }
                    }

                    query += ");";
                    Console.WriteLine(query);

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

        public static DataTable GetStatisticheCAM(string camera, bool[] toggled, string[] comparisons, string[] additionalcomparisons)
        {
            try
            {
                DataTable dt = null;
                string appendSelect = "";
                string appendWhere = "";
                AppendToggled(toggled, comparisons, additionalcomparisons, camera, out appendSelect, out appendWhere);

                string query = "SELECT ";

                query += appendSelect;

                query += " FROM " + camera;

                if (appendWhere != "")
                {
                    query += " WHERE " + appendWhere;
                }

                query += " ORDER BY Data DESC";

                query += ";";
                
                using (DBLBaseManager mngr = new DBLBaseManager(ConnectionString, false))
                {
                    dt = mngr.FillDataTable(query);
                }
                return dt;
            } catch
            {
                throw new Exception();
            }
        }

        #region enum colonne tabelle
        enum CAM0
        {
            Data,
            OK,
            CondLatMpin1,
            CondLatMpin2,
            CondLatPpin1,
            CondLatPpin2,
            SpazzolaSX,
            SpazzolaDX,
            Diametro
        }

        enum CAM0_2
        {
            Data,
            OK,
            NeroProtettorepin1,
            BiancoProtettorepin1,
            Nero2Protettorepin1,
            NeroProtettorepin2,
            BiancoProtettorepin2,
            Nero2Protettorepin2,
            NeroCondensatoreLatMpin1,
            BiancoCondensatoreLatMpin1,
            Nero2CondensatoreLatMpin1,
            NeroCondensatoreLatMpin2,
            BiancoCondensatoreLatMpin2,
            Nero2CondensatoreLatMpin2,
            NeroImpendenzaLatM,
            BiancoImpendenzaLatM,
            Nero2ImpendenzaLatM,
            NeroVaristorepin1,
            BiancoVaristorepin1,
            Nero2Varistorepin1,
            NeroVaristorepin2,
            BiancoVaristorepin2,
            Nero2Varistorepin2,
            NeroCondensatoreLatPpin1,
            BiancoCondensatoreLatPpin1,
            Nero2CondensatoreLatPpin1,
            NeroCondensatoreLatPpin2,
            BiancoCondensatoreLatPpin2,
            Nero2CondensatoreLatPpin2,
            NeroImpendenzaLatP,
            BiancoImpendenzaLatP,
            Nero2ImpendenzaLatP
        }

        enum CAM1
        {
            Data,
            OK,
            AllineamentoContatto,
            IngombroSX,
            IngombroDX
        }

        enum CAM2
        {
            Data,
            OK,
            InduttanzaSX,
            Protettore,
            InduttanzaDX
        }

        enum CAM2_2
        {
            Data,
            OK,
            ColonninaSX,
            TrecciaSX,
            TrecciaDX,
            ColonninaDX
        }

        enum CAM3
        {
            Data,
            OK,
            ZonaLibera,
            MollettaLatM,
            MollettaLatP,
            IngombroSXvaristore,
            IngombroCondensatore,
            IngombroSottoVaristore,
            Diametro,
            Varistore,
            CondensatoreDX,
            IngombroSopraVaristore,
            CondensatoreSX,
            IngombroSXcondensatore,
            InduttanzaLatP,
            InduttanzaLatM,
            Diametro2
        }

        enum CAM4
        {
            Data,
            OK,
            ControlloForo
        }

        enum CAM4_2
        {
            Data,
            OK,
            MollettaLatM
        }
        #endregion

        private static void AppendToggled(bool[] toggled, string[] comparisons, string[] additionalComparisons, string camera, out string appendSelect, out string appendWhere)
        {
            string[] columnNames;
            switch(camera)
            {
                case "CAM0":
                    columnNames = Enum.GetNames(typeof(CAM0));
                    break;
                case "CAM0_2":
                    columnNames = Enum.GetNames(typeof(CAM0_2));
                    break;
                case "CAM1":
                    columnNames = Enum.GetNames(typeof(CAM1));
                    break;
                case "CAM2":
                    columnNames = Enum.GetNames(typeof(CAM2));
                    break;
                case "CAM2_2":
                    columnNames = Enum.GetNames(typeof(CAM2_2));
                    break;
                case "CAM3":
                    columnNames = Enum.GetNames(typeof(CAM3));
                    break;
                case "CAM4":
                    columnNames = Enum.GetNames(typeof(CAM4));
                    break;
                case "CAM4_2":
                    columnNames = Enum.GetNames(typeof(CAM4_2));
                    break;
                default:
                    columnNames = new string[0];
                    break;
            }

            appendSelect = "";
            appendWhere = "";

            for(int i = 0; i < columnNames.Length; i++)
            {
                if(toggled[i])
                    appendSelect += ",[" + columnNames[i] + "]";

                if(comparisons[i] != null && comparisons[i] != "")
                    appendWhere += " AND " + columnNames[i] + " " + comparisons[i];

                if (additionalComparisons[i] != null && additionalComparisons[i] != "")
                    appendWhere += " AND " + columnNames[i] + " " + additionalComparisons[i];
            }

            if (appendSelect != "")
            {
                appendSelect = appendSelect.Substring(1);
            } else
            {
                appendSelect = "*";
            }

            if (appendWhere != "")
            {
                appendWhere = appendWhere.Substring(5);
            }
        }
    }
}