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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_EmpleadoxFecha_Select')
DROP PROCEDURE SP_EmpleadoxFecha_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_EmpleadoxFecha_Select
	-- Add the parameters for the stored procedure here
	@Id_empleado  char(6),
	@Fecha_HojaNomina datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select count(D.Id_HojaNomina) 
		from HojaNominaDetalle as D 
		inner join HojaNomina as H on H.Id_HojaNomina=D.Id_HojaNomina 
		where Id_empleado=@Id_empleado and Fecha_HojaNomina=@Fecha_HojaNomina


END
GO
