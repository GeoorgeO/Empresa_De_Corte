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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Empleados_Select')
DROP PROCEDURE SP_Empleados_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Empleados_Select
	-- Add the parameters for the stored procedure here
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_Empleado,
			Nombre_Empleado,
			Fecha_Nacimiento,
			NSS,
			Fecha_Alta_Seg_Social,
			Fecha_Baja_Seg_Social,
			Cuenta,
			Tarjeta,
			Fecha_Alta_Seg_Vida,
			Fecha_Baja_Seg_Vida,
			Id_Puesto,
			Nombre_Puesto,
			Id_Cuadrilla,
			Nombre_Cuadrilla,
			Activo
		from Empleados as E
		left join Puestos as P on P.Id_Puesto=E.Id_Puesto
		left join Cuadrillas as C on C.Id_Cuadrilla=E.Id_Cuadrilla
		where Activo=@Activo

END
GO
