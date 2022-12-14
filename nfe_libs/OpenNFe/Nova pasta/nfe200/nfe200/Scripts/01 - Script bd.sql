USE [OpenNFe2]
GO
/****** Object:  Table [dbo].[ServicosPendentes]    Script Date: 12/07/2010 13:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServicosPendentes](
	[CNPJ] [varchar](14) NOT NULL,
	[NumeroLote] [int] NOT NULL,
	[CodigoSituacao] [int] NOT NULL,
	[DataSituacao] [datetime] NOT NULL,
	[NumeroRecibo] [varchar](15) NULL,
	[XMLRecibo] [text] NULL,
	[XMLRetConsulta] [text] NULL,
	[erroEnvio] [bit] NOT NULL,
	[TipoOperacao] [int] NOT NULL,
	[ModoOperacao] [int] NOT NULL,
	[UnidadeFederativa] [int] NOT NULL,
 CONSTRAINT [PK_ServicosPendentes] PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC,
	[NumeroLote] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 12/07/2010 13:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parametros](
	[TipoOperacao] [int] NOT NULL,
	[ModoOperacao] [int] NOT NULL,
	[QtdeNFLote] [int] NOT NULL,
	[TempoFechaLote] [int] NOT NULL,
	[TamanhoLote] [int] NOT NULL,
	[DiretorioRecibo] [varchar](160) NOT NULL,
	[DiretorioEntrada] [varchar](160) NOT NULL,
	[DiretorioSaida] [varchar](160) NOT NULL,
	[NomeCertificado] [varchar](300) NOT NULL,
	[UsaProxy] [bit] NOT NULL,
	[UsuarioProxy] [varchar](30) NULL,
	[SenhaProxy] [varchar](30) NULL,
	[DominioProxy] [varchar](30) NULL,
	[UrlProxy] [varchar](50) NULL,
	[UnidadeFederativa] [int] NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[TimeOut] [int] NOT NULL,
	[DiretorioImpressao] [varchar](300) NOT NULL,
	[DiretorioXSD] [varchar](300) NOT NULL,
	[WService] [bit] NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NotasInutilizadas]    Script Date: 12/07/2010 13:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotasInutilizadas](
	[NumeroNota] [varchar](9) NOT NULL,
	[Data] [datetime] NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[XMLPedido] [text] NOT NULL,
	[XMLResposta] [text] NOT NULL,
	[SerieNota] [varchar](3) NOT NULL,
 CONSTRAINT [PK_NotasInutilizadas] PRIMARY KEY CLUSTERED 
(
	[NumeroNota] ASC,
	[CNPJ] ASC,
	[SerieNota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NotasFiscais]    Script Date: 12/07/2010 13:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotasFiscais](
	[NumeroLote] [int] NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[ChaveNota] [varchar](47) NOT NULL,
	[CodigoSituacao] [int] NOT NULL,
	[DescricaoSituacao] [varchar](255) NOT NULL,
	[DataSituacao] [datetime] NOT NULL,
	[XMLNotaFiscal] [text] NOT NULL,
	[XMLProcesso] [text] NULL,
	[cStat] [varchar](3) NULL,
	[xMotivo] [varchar](255) NULL,
	[nProt] [varchar](15) NULL,
	[XMLPedidoCancelamento] [text] NULL,
	[XMLProcessoCancelamento] [text] NULL,
	[nProtCancelamento] [varchar](15) NULL,
 CONSTRAINT [cpNotasFiscais_NumeroLote] PRIMARY KEY CLUSTERED 
(
	[NumeroLote] ASC,
	[ChaveNota] ASC,
	[CNPJ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG]    Script Date: 12/07/2010 13:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG](
	[NumeroLog] [decimal](8, 0) IDENTITY(1,1) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[CodigoSituacao] [int] NOT NULL,
	[DescricaoSituacao] [varchar](max) NOT NULL,
	[DataLog] [datetime] NOT NULL,
	[ChaveNota] [varchar](47) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[vwNotasInutilizadas]    Script Date: 12/07/2010 13:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwNotasInutilizadas] as
SELECT [NumeroNota]
      ,[Data]
      ,[CNPJ]
  FROM [OpenNFe].[dbo].[NotasInutilizadas]
GO
/****** Object:  Default [DF__Parametro__Diret__023D5A04]    Script Date: 12/07/2010 13:08:02 ******/
ALTER TABLE [dbo].[Parametros] ADD  DEFAULT ('.\PrintBox\') FOR [DiretorioImpressao]
GO
/****** Object:  Default [DF__Parametro__Diret__03317E3D]    Script Date: 12/07/2010 13:08:02 ******/
ALTER TABLE [dbo].[Parametros] ADD  DEFAULT ('.\xsd\') FOR [DiretorioXSD]
GO
