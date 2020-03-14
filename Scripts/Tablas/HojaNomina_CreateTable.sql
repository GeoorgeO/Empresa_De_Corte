USE [AvoHarvest]
GO
IF OBJECT_ID('HojaNomina') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[HojaNomina](
		[Id_HojaNomina] [varchar](10) NOT NULL,
		[Fecha_HojaNomina] [datetime] NOT NULL,
		[Id_Cuadrilla] [char](4) NULL,
		[Empresa] [varchar](30) NULL,
		[Pago_Diario] [numeric](10,2) NULL,
		[Id_JefeCuadrilla] [char](6) NULL,
		[Tope_pgo_x_dia] [numeric](10,2) NULL,
		[Total_corte_pgo_x_dia] [numeric](10,2) NULL,
		[Kgs_cortados_x_dia] [numeric](10,2) NULL,
		[Cajas_cortados_x_dia] [numeric](10,2) NULL,
		[Pago_jefe_cuadrilla] [numeric](10,2) NULL,
		[Peso_promedio_caja] [numeric](10,2) NULL,
		[Precio_caja_1] [numeric](10,2) NULL,
		[Precio_caja_2] [numeric](10,2) NULL,
		[Total_cortadores] [numeric](10,2) NULL,
		[Total_Cajas] [numeric](10,2) NULL,
		[Total_Importe] [numeric](10,2) NULL,
		[Pago_x_dia] [bit] NULL,
		[Pago_falso] [bit] NULL,
		[Festivo] [bit] NULL,
	 CONSTRAINT [PK_HojaNomina] PRIMARY KEY CLUSTERED 
	(
		[Id_HojaNomina] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end