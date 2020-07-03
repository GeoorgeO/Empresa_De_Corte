USE [AvoHarvest]
GO
IF OBJECT_ID('Domicilios') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Domicilios](
		[Id_Domicilio] [char](6) NOT NULL,
		[Calle] [varchar](100) NULL,
		[NoInterior] [varchar](10) NULL,
		[NoExterior] [varchar](10) NULL,
		[Colonia] [varchar](50) NULL,
		[Codigo_Postal] [char](5) NULL,
		[Id_Ciudad] [char](3) NULL,
		[Id_TipoDomicilio] [char](4) NULL,
		[Id_Persona] [char](8) NULL,
		[id_TipoPersona] [char](4) NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_Domicilios] PRIMARY KEY CLUSTERED 
	(
		[Id_Domicilio] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end