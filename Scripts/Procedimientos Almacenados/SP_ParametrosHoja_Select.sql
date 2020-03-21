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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ParametrosHoja_Select')
DROP PROCEDURE SP_ParametrosHoja_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_ParametrosHoja_Select
	-- Add the parameters for the stored procedure here
	@Id_Tipo char(1),
	@Id_Cuadrilla char(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select case 'A' when 'A' then 'Otra' else 'Mission' end as Empresa,
			case 'A' when 'A' then Pago_x_Dia else Pago_x_Dia_Mission end as PagoDiario,
			(select Id_Empleado from Empleados where Id_Cuadrilla=@Id_Cuadrilla) as IdJefeCuadrilla,
			(select Nombre_Empleado from Empleados where Id_Cuadrilla=@Id_Cuadrilla) as JefeCuadrilla,
			case 'A' when 'A' then Tope_Pago else Tope_Pago_Mission end as TopeaPagar,
			Pago_x_caja,
			Kg_x_Dia_Inf_1,
			Kg_x_Dia_Sup_1,
			case 'A' when 'A' then Pago_Inf_1 else Pago_Inf_1_Mission end as Pago_Inf_1,
			case 'A' when 'A' then Pago_Sup_1 else Pago_Sup_1_Mission end as Pago_Sup_1,
			Kg_x_Dia_Inf_2,
			Kg_x_Dia_Sup_2,
			case 'A' when 'A' then Pago_Inf_2 else Pago_Inf_2_Mission end as Pago_Inf_2,
			case 'A' when 'A' then Pago_Sup_2 else Pago_Sup_2_Mission end as Pago_Sup_2,
			Kg_x_Dia_Inf_3,
			Kg_x_Dia_Sup_3,
			case 'A' when 'A' then Pago_Inf_3 else Pago_Inf_3_Mission end as Pago_Inf_3,
			case 'A' when 'A' then Pago_Sup_3 else Pago_Sup_3_Mission end as Pago_Sup_3,
			case 'A' when 'A' then N_Cortadores else N_Cortadores_Mission end as N_Cortadores
		from Parametros
		where Id_Tipo=@Id_Tipo


END
GO
