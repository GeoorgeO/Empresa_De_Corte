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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_JefexFecha_Select')
DROP PROCEDURE SP_JefexFecha_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_JefexFecha_Select
	-- Add the parameters for the stored procedure here
	@Id_Cuadrilla  char(3),
	@Fecha_HojaNomina datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select count(Id_HojaNomina) 
		from HojaNomina where Id_Cuadrilla=@Id_Cuadrilla and Fecha_HojaNomina=@Fecha_HojaNomina

END
GO
