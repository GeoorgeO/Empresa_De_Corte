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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojasNomina_Select')
DROP PROCEDURE SP_HojasNomina_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_HojasNomina_Select
	-- Add the parameters for the stored procedure here
	@del datetime,
	@al datetime,
	@categoria char(4),
	@todascategorias char(1),
	@Estatus char(1)
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
			Tope_pgo_x_dia as PrecioCaja,
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
			Festivo,
			Estatus,
			Nombre_Categoria
		from HojaNomina as H
		left join Empleados as E on E.Id_Empleado=H.Id_JefeCuadrilla
		left join Cuadrillas as C on C.Id_Cuadrilla=H.Id_Cuadrilla
		left join CategoriasCuadrilla as CC on CC.Id_Categoria=C.Id_Categoria
		where Fecha_HojaNomina between @del and @al and (('T'=@todascategorias) or ('T'<>@todascategorias and C.Id_Categoria=@categoria))
			and (('T'=@Estatus) or ('T'<>@Estatus and H.Estatus=@Estatus))
END
GO
