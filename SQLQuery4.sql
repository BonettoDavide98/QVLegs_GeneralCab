/* Per evitare potenziali problemi di perdita di dati, si consiglia di esaminare dettagliatamente lo script prima di eseguirlo al di fuori del contesto di Progettazione database.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_TabStoricoStatisticheMisure
	(
	IdStazione int NOT NULL,
	DataRiferimentoTurno date NOT NULL,
	NomeTurno smallint NOT NULL,
	IdFormato varchar(50) NOT NULL,
	TimeStamp datetime NOT NULL,
	Chiave varchar(50) NOT NULL,
	Bucket int NOT NULL,
	Valore int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_TabStoricoStatisticheMisure SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_TabStoricoStatisticheMisure ADD CONSTRAINT
	DF_TabStoricoStatisticheMisure_IdStazione DEFAULT 0 FOR IdStazione
GO
IF EXISTS(SELECT * FROM dbo.TabStoricoStatisticheMisure)
	 EXEC('INSERT INTO dbo.Tmp_TabStoricoStatisticheMisure (DataRiferimentoTurno, NomeTurno, IdFormato, TimeStamp, Chiave, Bucket, Valore)
		SELECT DataRiferimentoTurno, NomeTurno, IdFormato, TimeStamp, Chiave, Bucket, Valore FROM dbo.TabStoricoStatisticheMisure WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.TabStoricoStatisticheMisure
GO
EXECUTE sp_rename N'dbo.Tmp_TabStoricoStatisticheMisure', N'TabStoricoStatisticheMisure', 'OBJECT' 
GO
ALTER TABLE dbo.TabStoricoStatisticheMisure ADD CONSTRAINT
	PK_TabStoricoStatisticheMisure PRIMARY KEY CLUSTERED 
	(
	IdStazione,
	DataRiferimentoTurno,
	NomeTurno,
	IdFormato,
	TimeStamp,
	Chiave,
	Bucket
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT