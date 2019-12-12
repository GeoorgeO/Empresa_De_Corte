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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Entradas_Select')
DROP PROCEDURE SP_Entradas_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Entradas_Select
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Serie_Entrada
	      ,Folio_Entrada
		  ,E.Id_Proveedor
		  ,P.Nombre_Proveedor
		  ,E.Id_TipoEntrada
		  ,TE.Nombre_TipoEntrada
		  ,Fecha_Entrada
		  ,Numero_ArticulosEntrada 
		from EntradaEncabezado E
		left join Proveedores as P on P.Id_Proveedor=E.Id_Proveedor
		left join TiposEntradas as TE on TE.Id_TipoEntrada=E.Id_TipoEntrada
		

END
GO
