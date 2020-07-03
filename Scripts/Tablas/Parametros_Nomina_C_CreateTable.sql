USE [AvoHarvest]
GO
IF OBJECT_ID('Parametros_Nomina_C') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Parametros_Nomina_C](
		[Id] [char](4) NOT NULL,
		[Tipo_Empleado] [char](1) NOT NULL,
		[Dias_trabajo] [numeric](10, 0) NOT NULL,
		[Sueldo_Bruto] [numeric](18, 2) NOT NULL,
		[ISR] [numeric](15, 2) NOT NULL,
		[Sueldo_Neto] [numeric](18, 2) NOT NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_Parametros_Nomina_C] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end