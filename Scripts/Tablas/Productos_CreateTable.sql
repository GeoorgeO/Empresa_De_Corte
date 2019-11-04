USE [AvoHarvest]
GO
IF OBJECT_ID('Productos') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Productos](
		[Id_Producto] [char](8) NOT NULL,
		[Nombre_Producto] [varchar](150) NULL,
		[Id_UnidadMedida] [char](3) NULL,
		[Inventariable] [bit] NULL,
		[Stock_Min] [numeric](18,0) NULL,
		[Stock_Max] [numeric](18,0) NULL,
		[Anaquel] [varchar](5) NULL,
		[Pasillo] [varchar](5) NULL,
		[Repisa] [varchar](5) NULL,
	 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
	(
		[Id_Producto] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end