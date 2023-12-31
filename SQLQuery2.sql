USE [TECNOPACK]
GO

/****** Object:  Table [dbo].[TabStatisticheTmp]    Script Date: 01/09/2021 10:15:46 ******/
DROP TABLE [dbo].[TabStatisticheTmp]
GO

/****** Object:  Table [dbo].[TabStatisticheTmp]    Script Date: 01/09/2021 10:15:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TabStatisticheTmp](
	[Prog] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCamera] [bigint] NOT NULL,
	[DataRiferimentoTurno] [date] NOT NULL,
	[NomeTurno] [smallint] NOT NULL,
	[IdFormato] [varchar](50) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[TEST_INTEGRITA_AREA] [float] NULL,
	[TEST_INTEGRITA_DELTA] [float] NULL,
	[TEST_DIMENSIONE_DIAMETRO] [float] NULL,
	[TEST_DIMENSIONE_CIRCOLARITA] [float] NULL,
	[TEST_DIMENSIONE_W] [float] NULL,
	[TEST_DIMENSIONE_H] [float] NULL,
	[TEST_CREPE_LEN] [float] NULL,
	[TEST_DISEGNI_PRESENZA_AREA] [float] NULL,
	[TEST_DISEGNI_MACCHIE_GROSSE_AREA_MAX] [float] NULL,
	[TEST_COLORE_DIST] [float] NULL,
	[TEST_COLORE_DIST_2] [float] NULL,
	[TEST_COLORE_2_AREA] [float] NULL,
	[TEST_SBORDAMENTO_AREA_MAX] [float] NULL,
	[TEST_DIMENSIONE_ALTEZZA] [float] NULL,
	[TEST_DIMENSIONE_LATO_W] [float] NULL,
	[TEST_DIMENSIONE_LATO_H] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_V_0] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_V_1] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_V_2] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_V_3] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_V_4] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_H_0] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_H_1] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_H_2] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_H_3] [float] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_H_4] [float] NULL,
	[ALG_OK] [bit] NOT NULL,
	[ALLINEAMENTO_OK] [bit] NULL,
	[TEST_INTEGRITA_OK] [bit] NULL,
	[TEST_DIMENSIONE_OK] [bit] NULL,
	[TEST_CREPE_OK] [bit] NULL,
	[TEST_DISEGNI_OK] [bit] NULL,
	[TEST_COLORE_OK] [bit] NULL,
	[TEST_COLORE_2_OK] [bit] NULL,
	[TEST_SBORDAMENTO_OK] [bit] NULL,
	[TEST_ALTEZZA_OK] [bit] NULL,
	[TEST_DIMENSIONE_LATO_OK] [bit] NULL,
	[TEST_RAKE_DIMENSIONE_LATO_OK] [bit] NULL,
 CONSTRAINT [PK_TabStatisticheTmp] PRIMARY KEY CLUSTERED 
(
	[Prog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


