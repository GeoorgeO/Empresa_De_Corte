USE [AvoHarvest]
GO
IF OBJECT_ID('SalidasEncabezado') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[SalidasEncabezado](
		[Serie_Salida] [varchar](30) NOT NULL,
		[Folio_Salida] [char](8) NOT NULL,
		[Id_JefeCuadrilla] [char](8) NULL,
		[Id_TipoSalida] [char](3) NULL,
		[Fecha_Salida] [datetime] NULL,
		[Numero_Articulossalida] [int] NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_SalidasEncabezado] PRIMARY KEY CLUSTERED 
	(
		[Serie_Salida] ASC,
		[Folio_Salida] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end