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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_CuadrillasNomina_Select')
DROP PROCEDURE SP_CuadrillasNomina_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_CuadrillasNomina_Select
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select C.Id_Cuadrilla+' '+CC.Nombre_Categoria as Cuadrilla,
			C.Id_Cuadrilla,
		    C.Id_Categoria
		from Cuadrillas as C
		inner join (select distinct Id_cuadrilla from Empleados where Activo=1) as E on E.Id_Cuadrilla=C.Id_Cuadrilla
		left join CategoriasCuadrilla as CC on CC.Id_Categoria=C.Id_Categoria


END
GO
