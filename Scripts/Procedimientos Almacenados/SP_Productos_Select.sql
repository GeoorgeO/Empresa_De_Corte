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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Productos_Select')
DROP PROCEDURE SP_Productos_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Productos_Select
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_Producto
	      ,Nombre_Producto
		  ,pro.Id_UnidadMedida
		  ,Uni.Nombre_UnidadMedida
		  ,Inventariable
		  ,Stock_Min
		  ,Stock_Max
		  ,Anaquel
		  ,Pasillo
		  ,Repisa 
		from Productos as pro
		left join UnidadesMedida as Uni on Uni.Id_UnidadMedida=pro.Id_UnidadMedida

END
GO
