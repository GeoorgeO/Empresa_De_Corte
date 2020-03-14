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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ServicioCortes_Select')
DROP PROCEDURE SP_ServicioCortes_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_ServicioCortes_Select
	-- Add the parameters for the stored procedure here
	@PSC_ODC varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		SELECT PSC_Fecha
      ,PSC_ODC
      ,PSC_Ubicacion
      ,PSC_Pesada
      ,PSC_Placas
      ,PSC_Huertas
      ,PSC_Productor
      ,PSC_Cajas
      ,PSC_Kilos
      ,PSC_Variedad
      ,PSC_JefeCuadrilla
      ,PSC_CajasZ
      ,PSC_FolioZ
      ,PSC_JefeArea
      ,PSC_ClaveDia
  FROM ServicioCortes
  where PSC_ODC=@PSC_ODC
END
GO
