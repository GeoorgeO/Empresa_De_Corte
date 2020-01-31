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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_EntradaDetalles_Select')
DROP PROCEDURE SP_EntradaDetalles_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_EntradaDetalles_Select
	-- Add the parameters for the stored procedure here
	@Serie_Entrada varchar(30),
	@Folio_Entrada char(8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Serie_Entrada
	      ,Folio_Entrada
		  ,Registro_EntradaDetalles
		  ,Id_Producto
		  ,Nombre_Producto
		  ,Nombre_UnidadMedida
		  ,Cantidad_EntradaDetalles
		  ,Precio_EntradaDetalles
		  ,Total_EntradaDetalles
		  ,Observaciones_EntradaDetalles
		  ,Guardado=CONVERT(bit,1)
		  ,AplicadoInventario
		  ,Lote
		  ,Fecha_Caducidad
		from EntradaDetalles E
		where Serie_Entrada=@Serie_Entrada and Folio_Entrada=@Folio_Entrada
		

END
GO
