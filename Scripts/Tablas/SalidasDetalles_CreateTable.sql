USE [AvoHarvest]
GO
IF OBJECT_ID('SalidasDetalles') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[SalidasDetalles](
		[Serie_Salida] [varchar](30) NOT NULL,
		[Folio_Salida] [char](8) NOT NULL,
		[Registro_SalidaDetalles] [int] NULL,
		[Id_Producto] [char](8) NULL,
		[Nombre_Producto] [varchar](150) NULL,
		[Nombre_UnidadMedida] [varchar](150) NULL,
		[Cantidad_SalidaDetalles] [int] NULL,
		[Precio_SalidaDetalles] [money] NULL,
		[Total_SalidaDetalles] [money] NULL,
		[Observaciones_SalidaDetalles] [varchar](200) NULL,
		[AplicadoInventario] [bit] NULL
	) ON [PRIMARY]

	end