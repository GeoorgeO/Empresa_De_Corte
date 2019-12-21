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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_SalidasDetalles_Select')
DROP PROCEDURE SP_SalidasDetalles_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_SalidasDetalles_Select
	-- Add the parameters for the stored procedure here
	@Serie_Salida varchar(30),
	@Folio_Salida char(8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Serie_Salida
	     	,Folio_Salida
		 	,Registro_EntradaDetalles,
			,Registro_SalidaDetalles,
			,Id_Producto,
			,Nombre_Producto,
			,Nombre_UnidadMedida,
			,Cantidad_SalidaDetalles,
			,Precio_SalidaDetalles,
			,Total_SalidaDetalles,
			,Observaciones_SalidaDetalles
			AplicadoInventario
		from SalidasDetalles S
		where Serie_Salida=@Serie_Salida and Folio_Salida=@Folio_Salida
		

END
GO
