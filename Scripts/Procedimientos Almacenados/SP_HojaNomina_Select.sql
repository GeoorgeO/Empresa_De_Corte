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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojaNomina_Select')
DROP PROCEDURE SP_HojaNomina_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_HojaNomina_Select
	-- Add the parameters for the stored procedure here
	@Id_HojaNomina varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_HojaNomina,
			Fecha_HojaNomina,
			H.Id_Cuadrilla,
			Empresa,
			Pago_Diario,
			H.Id_JefeCuadrilla,
			E.Nombre_Empleado,
			Tope_pgo_x_dia,
			Total_corte_pgo_x_dia,
			Kgs_cortados_x_dia,
			Cajas_cortados_x_dia,
			Pago_jefe_cuadrilla,
			Peso_promedio_caja,
			Precio_caja_1,
			Precio_caja_2,
			Total_cortadores,
			Total_Cajas,
			Total_Importe,
			Pago_x_dia,
			Pago_falso,
			Festivo
		from HojaNomina as H
		left join Empleados as E on E.Id_Empleado=H.Id_JefeCuadrilla
		where Id_HojaNomina=@Id_HojaNomina

END
GO
