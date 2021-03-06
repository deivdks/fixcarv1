USE [fixcarv1]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Ano] [int] NOT NULL,
	[km] [int] NOT NULL,
	[FabricanteCarroId] [int] NULL,
	[Transmissao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fabricantes]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabricantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[PaisOrigemId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mecanicas]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mecanicas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Endereco] [varchar](250) NULL,
	[Telefone] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaisesOrigem]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaisesOrigem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Preco] [decimal](18, 0) NOT NULL,
	[ServicoId] [int] NOT NULL,
	[TipoProduto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicos]    Script Date: 18/04/2022 19:50:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataEntrada] [date] NOT NULL,
	[DataEntrega] [date] NOT NULL,
	[ValorTotal] [decimal](18, 0) NULL,
	[CarId] [int] NULL,
	[MecanicaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [Modelo], [Ano], [km], [FabricanteCarroId], [Transmissao]) VALUES (2, N'Civic', 2007, 151000, 1, 1)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Fabricantes] ON 

INSERT [dbo].[Fabricantes] ([Id], [Nome], [PaisOrigemId]) VALUES (1, N'Honda', 1)
INSERT [dbo].[Fabricantes] ([Id], [Nome], [PaisOrigemId]) VALUES (2, N'Mazda', 1)
SET IDENTITY_INSERT [dbo].[Fabricantes] OFF
GO
SET IDENTITY_INSERT [dbo].[Mecanicas] ON 

INSERT [dbo].[Mecanicas] ([Id], [Nome], [Endereco], [Telefone]) VALUES (1, N'Alan', N'Rua Conceissão', N'999999999')
SET IDENTITY_INSERT [dbo].[Mecanicas] OFF
GO
SET IDENTITY_INSERT [dbo].[PaisesOrigem] ON 

INSERT [dbo].[PaisesOrigem] ([Id], [Nome]) VALUES (1, N'Japão')
INSERT [dbo].[PaisesOrigem] ([Id], [Nome]) VALUES (2, N'Estados Unidos')
SET IDENTITY_INSERT [dbo].[PaisesOrigem] OFF
GO
SET IDENTITY_INSERT [dbo].[Produtos] ON 

INSERT [dbo].[Produtos] ([Id], [Nome], [Preco], [ServicoId], [TipoProduto]) VALUES (5, N'limpeza bicos', CAST(100 AS Decimal(18, 0)), 5, 1)
SET IDENTITY_INSERT [dbo].[Produtos] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicos] ON 

INSERT [dbo].[Servicos] ([Id], [DataEntrada], [DataEntrega], [ValorTotal], [CarId], [MecanicaId]) VALUES (5, CAST(N'2022-04-18' AS Date), CAST(N'2022-04-18' AS Date), NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[Servicos] OFF
GO
