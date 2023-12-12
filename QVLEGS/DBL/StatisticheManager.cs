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
                string query = "SELECT ";

                query += AppendToggled(toggled, camera);

                query += " FROM " + camera;

                //if(extraArguments != "")
                //{
                //    query += " WHERE " + extraArguments;
                //}

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

        private static string AppendToggled(bool[] toggled, string camera)
        {
            string output = "";

            switch(camera)
            {
                case "CAM0":
                    output += "Data";
                    if (toggled[1])
                        output += ",[CondLatMpin1]";
                    if (toggled[2])
                        output += ",[CondLatMpin2]";
                    if (toggled[3])
                        output += ",[CondLatPpin1]";
                    if (toggled[4])
                        output += ",[CondLatPpin2]";
                    if (toggled[5])
                        output += ",[SpazzolaSX]";
                    if (toggled[6])
                        output += ",[SpazzolaDX]";
                    if (toggled[7])
                        output += ",[Diametro]";
                    break;
                case "CAM0_2":
                    output += "Data";
                    if (toggled[1])
                        output += ",[ThresholdNeroProtettorepin1]";
                    if (toggled[2])
                        output += ",[ThresholdBiancoProtettorepin1]";
                    if (toggled[3])
                        output += ",[ThresholdNeroProtettorepin2]";
                    if (toggled[4])
                        output += ",[ThresholdBiancoProtettorepin2]";
                    if (toggled[5])
                        output += ",[ThresholdNeroCondensatoreLatMpin1]";
                    if (toggled[6])
                        output += ",[ThresholdBiancoCondensatoreLatMpin1]";
                    if (toggled[7])
                        output += ",[ThresholdNeroCondensatoreLatMpin2]";
                    if (toggled[8])
                        output += ",[ThresholdBiancoCondensatoreLatMpin2]";
                    if (toggled[9])
                        output += ",[ThresholdNeroImpendenzaLatM]";
                    if (toggled[10])
                        output += ",[ThresholdBiancoImpendenzaLatM]";
                    if (toggled[11])
                        output += ",[ThresholdNeroVaristorepin1]";
                    if (toggled[12])
                        output += ",[ThresholdBiancoVaristorepin1]";
                    if (toggled[13])
                        output += ",[ThresholdNeroVaristorepin2]";
                    if (toggled[14])
                        output += ",[ThresholdBiancoVaristorepin2]";
                    if (toggled[15])
                        output += ",[ThresholdNeroCondensatoreLatPpin1]";
                    if (toggled[16])
                        output += ",[ThresholdBiancoCondensatoreLatPpin1]";
                    if (toggled[17])
                        output += ",[ThresholdNeroCondensatoreLatPpin2]";
                    if (toggled[18])
                        output += ",[ThresholdBiancoCondensatoreLatPpin2]";
                    if (toggled[19])
                        output += ",[ThresholdNeroImpendenzaLatP]";
                    if (toggled[20])
                        output += ",[ThresholdBiancoImpendenzaLatP]";
                    break;
                case "CAM1":
                    output += "Data";
                    if (toggled[1])
                        output += ",[AllineamentoContatto]";
                    if (toggled[2])
                        output += ",[IngombroSX]";
                    if (toggled[3])
                        output += ",[IngombroDX]";
                    break;
                case "CAM2":
                    output += "Data";
                    if (toggled[1])
                        output += ",[ColonninaSX]";
                    if (toggled[2])
                        output += ",[TrecciaSX]";
                    if (toggled[3])
                        output += ",[TrecciaDX]";
                    if (toggled[4])
                        output += ",[ColonninaDX]";
                    break;
                case "CAM2_2":
                    output += "Data";
                    if (toggled[1])
                        output += ",[val1]";
                    if (toggled[2])
                        output += ",[val2]";
                    if (toggled[3])
                        output += ",[val3]";
                    if (toggled[4])
                        output += ",[val4]";
                    break;
                case "CAM3":
                    output += "Data";
                    if (toggled[1])
                        output += ",[ZonaLibera]";
                    if (toggled[2])
                        output += ",[MollettaLatM]";
                    if (toggled[3])
                        output += ",[MollettaLatP]";
                    if (toggled[4])
                        output += ",[IngombroSXvaristore]";
                    if (toggled[5])
                        output += ",[IngombroCondensatore]";
                    if (toggled[6])
                        output += ",[IngombroSottoVaristore]";
                    if (toggled[7])
                        output += ",[Diametro]";
                    if (toggled[8])
                        output += ",[Varistore]";
                    if (toggled[9])
                        output += ",[CondensatoreDX]";
                    if (toggled[10])
                        output += ",[IngombroSopraVaristore]";
                    if (toggled[11])
                        output += ",[CondensatoreSX]";
                    if (toggled[12])
                        output += ",[IngombroSXcondensatore]";
                    if (toggled[13])
                        output += ",[InduttanzaLatP]";
                    if (toggled[14])
                        output += ",[InduttanzaLatM]";
                    if (toggled[15])
                        output += ",[Diametro2]";
                    break;
                case "CAM4":
                    output += "Data";
                    if (toggled[1])
                        output += ",[ControlloForo]";
                    break;
                case "CAM4_2":
                    output += "Data";
                    if (toggled[1])
                        output += ",[MollettaLatM]";
                    break;
            }

            return output;
        }

        public static string AddControlloData(DateTime dt)
        {
            return "Data > '" + dt.ToString("yyyy-MM-dd") + "T00:00:00.0000000'";
        }
    }
}