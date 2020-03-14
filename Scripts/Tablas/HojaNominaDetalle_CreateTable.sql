USE [AvoHarvest]
GO
IF OBJECT_ID('HojaNominaDetalle') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[HojaNominaDetalle](
		[Id_HojaNomina] [varchar](10) NOT NULL,
		[Id_secuencia] [char](2) NOT NULL,
		[Id_empleado] [char](6) NOT NULL,
		[Cajas] [numeric](10,2) NOT NULL,
		[Importe] [numeric](10,2) NOT NULL,
	 CONSTRAINT [PK_HojaNominaDetalle] PRIMARY KEY CLUSTERED 
	(
		[Id_HojaNomina] ASC,
		[Id_secuencia] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end