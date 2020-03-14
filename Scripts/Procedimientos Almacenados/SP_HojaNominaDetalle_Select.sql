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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojaNominaDetalle_Select')
DROP PROCEDURE SP_HojaNominaDetalle_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_HojaNominaDetalle_Select
	-- Add the parameters for the stored procedure here
	@Id_HojaNomina varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_HojaNomina
	      ,Id_secuencia
		  ,D.Id_empleado
		  ,E.Nombre_empleado
		  ,Cajas
		  ,Importe
		  ,E.Id_Puesto
		from HojaNominaDetalle as D
		left join Empleados as E on E.Id_empleado=D.Id_empleado
		where Id_HojaNomina=@Id_HojaNomina
END
GO
