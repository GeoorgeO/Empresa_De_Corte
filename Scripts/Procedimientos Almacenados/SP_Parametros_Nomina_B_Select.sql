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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Parametros_Nomina_B_Select')
DROP PROCEDURE SP_Parametros_Nomina_B_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Parametros_Nomina_B_Select
	-- Add the parameters for the stored procedure here
	@Tipo_Empleado char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Dias_trabajo
	      ,Tipo_Empleado
	      ,Sueldo_Bruto
		from Parametros_Nomina_B
		where Tipo_Empleado=@Tipo_Empleado
		order by Sueldo_Bruto desc

END
GO
