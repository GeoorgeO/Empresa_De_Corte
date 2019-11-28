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
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
				SELECT        pro.Id_Producto, pro.Nombre_Producto, pro.Id_UnidadMedida, Uni.Nombre_UnidadMedida, pro.Inventariable, pro.Stock_Min, pro.Stock_Max, pro.Anaquel, pro.Pasillo, pro.Repisa, pro.Stock, pro.Activo, 
                         ProductoTipo.Nombre_ProductoTipo
		FROM            Productos AS pro INNER JOIN
                         ProductoTipo ON pro.Id_ProductoTipo = ProductoTipo.Id_ProductoTipo LEFT OUTER JOIN
                         UnidadesMedida AS Uni ON Uni.Id_UnidadMedida = pro.Id_UnidadMedida	
		where pro.Activo=@Activo

END
GO
