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
			Id_Huerta,
			hue.Nombre_Huerta,
			Transportista,
			Placas,
			Candado,
			ODC,
			Id_TipoCorte,
			tc.Nombre_TipoCorte
			PSobreBanda,
			Precio,
			Empaque,
			JefeArea 
		from PrecapturaODC as ODC
		left join Huertas as hue on hue.Id_Huerta=ODC.Id_Huerta
		left join TiposCorte as tc on tc.Id_TipoCorte=ODC.Id_TipoCorte
		

END
GO
