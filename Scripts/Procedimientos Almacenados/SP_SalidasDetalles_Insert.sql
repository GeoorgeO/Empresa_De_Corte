USE [AvoHarvest]
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_SalidasDetalles_Insert')
DROP PROCEDURE SP_SalidasDetalles_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_SalidasDetalles_Insert
	-- Add the parameters for the stored procedure here
	@Serie_Salida	varchar(30),
	@Folio_Salida	char(8),
	@Registro_SalidaDetalles int,
	@Id_Producto char(8),
	@Nombre_Producto varchar(150),
	@Nombre_UnidadMedida varchar(150),
	@Cantidad_SalidaDetalles int,
	@Precio_SalidaDetalles money,
	@Total_SalidaDetalles money,
	@Observaciones_SalidaDetalles varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try
    -- Insert statements for procedure here
		INSERT INTO SalidasDetalles
							 (Serie_Salida, Folio_Salida, Registro_SalidaDetalles, Id_Producto, Nombre_Producto, Nombre_UnidadMedida, Cantidad_SalidaDetalles, Precio_SalidaDetalles, Total_SalidaDetalles, Observaciones_SalidaDetalles, 
							 AplicadoInventario)
		VALUES        (@Serie_Salida,@Folio_Salida,@Registro_SalidaDetalles,@Id_Producto,@Nombre_Producto,@Nombre_UnidadMedida,@Cantidad_SalidaDetalles,@Precio_SalidaDetalles,@Total_SalidaDetalles,@Observaciones_SalidaDetalles,0)
	
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

END
GO