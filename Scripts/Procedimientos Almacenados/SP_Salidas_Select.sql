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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Salidas_Select')
DROP PROCEDURE SP_Salidas_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Salidas_Select
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Serie_Salida,
			Folio_Salida,
			S.Id_JefeCuadrilla,
			E.Nombre_Empleado,
			S.Id_TipoSalida,
			TS.Nombre_TipoSalida,
			Fecha_Salida,
			Numero_Articulossalida
		from SalidasEncabezado as S
		left join Empleados as E on S.Id_JefeCuadrilla=E.Id_Empleado
		left join TiposSalidas as TS on TS.Id_TipoSalida=S.Id_TipoSalida
END
GO
