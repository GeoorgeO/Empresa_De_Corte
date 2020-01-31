USE [AvoHarvest]
GO
IF OBJECT_ID('EntradaDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[EntradaDetalles](
		[Serie_Entrada] [varchar](30) NOT NULL,
		[Folio_Entrada] [char](8) NOT NULL,
		[Registro_EntradaDetalles] [int] NULL,
		[Id_Producto] [char](8) NULL,
		[Nombre_Producto] [varchar](150) NULL,
		[Nombre_UnidadMedida] [varchar](150) NULL,
		[Cantidad_EntradaDetalles] [int] NULL,
		[Precio_EntradaDetalles] [money] NULL,
		[Total_EntradaDetalles] [money] NULL,
		[Observaciones_EntradaDetalles] [varchar](200) NULL,
		[AplicadoInventario] [bit] NULL,
		[Lote][varchar](50) NULL,
		[Fecha_Caducidad][datetime] NULL
	) ON [PRIMARY]

	end