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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_PrecapturaODC_Select')
DROP PROCEDURE SP_PrecapturaODC_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_PrecapturaODC_Select
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_PrecapturaODC,
			JefeCuadrilla,
			ODC.Id_Huerta,
			hue.Nombre_Huerta,
			Transportista,
			Placas,
			Candado,
			ODC,
			ODC.Id_TipoCorte,
			tc.Nombre_TipoCorte,
			PSobreBanda,
			Precio,
			ODC.Id_Empaque,
			Nombre_Empaque,
			ODC.Id_Jefe_Area,
			Nombre_Jefe_Area,
			ODC.Id_Area,
			Nombre_Area,
			ODC.Id_Duenio,
			Nombre_Duenio
		from PrecapturaODC as ODC
		left join Huerta as hue on hue.Id_Huerta=ODC.Id_Huerta
		left join TiposCorte as tc on tc.Id_TipoCorte=ODC.Id_TipoCorte
		left join Empaques as E on E.Id_Empaque=ODC.Id_Empaque
		left join Areas as A on A.Id_Area=ODC.Id_Area
		left join Jefes_Area as JA on JA.Id_Jefe_Area=ODC.Id_Jefe_Area
		left join Duenio as D on D.Id_Duenio=ODC.Id_Duenio
END
GO
