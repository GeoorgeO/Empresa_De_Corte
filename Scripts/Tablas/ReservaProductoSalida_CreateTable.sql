USE [AvoHarvest]
GO
IF OBJECT_ID('ReservaProductoSalida') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[ReservaProductoSalida](
		[Id_Producto] [char](8)NOT NULL,
		[Cantidad] [numeric](18,0)NOT NULL,
		[HoraReservado] [datetime]NOT NULL,
		[EquipoReservo] [varchar](80) NULL	
	) 

	end