USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojaNomina_Update')
DROP PROCEDURE SP_HojaNomina_Update
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE dbo.SP_HojaNomina_Update
	-- Add the parameters for the stored procedure here
	@Id_HojaNomina varchar(10),
	@Id_HojaNomina_New varchar(10),
	@Usuario varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		DECLARE @existe int;

		set @existe=(select count(Id_HojaNomina) from HojaNomina where Id_HojaNomina=@Id_HojaNomina_New)
		
		if @existe=0
			INSERT INTO HojaNomina ([Id_HojaNomina]
				  ,[Fecha_HojaNomina]
				  ,[Id_Cuadrilla]
				  ,[Empresa]
				  ,[Pago_Diario]
				  ,[Id_JefeCuadrilla]
				  ,[Tope_pgo_x_dia]
				  ,[Total_corte_pgo_x_dia]
				  ,[Kgs_cortados_x_dia]
				  ,[Cajas_cortados_x_dia]
				  ,[Pago_jefe_cuadrilla]
				  ,[Peso_promedio_caja]
				  ,[Precio_caja_1]
				  ,[Precio_caja_2]
				  ,[Total_cortadores]
				  ,[Total_Cajas]
				  ,[Total_Importe]
				  ,[Pago_x_dia]
				  ,[Pago_falso]
				  ,[Festivo]
				  ,[Estatus]
				  ,[Precio_Caja]
				  ,[Pago_Maniobra]
				  ,[Creador]
			   	  ,[Fecha_Creador])
			SELECT 'TEMP01'
				  ,[Fecha_HojaNomina]
				  ,[Id_Cuadrilla]
				  ,[Empresa]
				  ,[Pago_Diario]
				  ,[Id_JefeCuadrilla]
				  ,[Tope_pgo_x_dia]
				  ,[Total_corte_pgo_x_dia]
				  ,[Kgs_cortados_x_dia]
				  ,[Cajas_cortados_x_dia]
				  ,[Pago_jefe_cuadrilla]
				  ,[Peso_promedio_caja]
				  ,[Precio_caja_1]
				  ,[Precio_caja_2]
				  ,[Total_cortadores]
				  ,[Total_Cajas]
				  ,[Total_Importe]
				  ,[Pago_x_dia]
				  ,[Pago_falso]
				  ,[Festivo]
				  ,[Estatus]
				  ,[Precio_Caja]
				  ,[Pago_Maniobra]
				  ,@Usuario
				  ,getdate() FROM HojaNomina
			WHERE Id_HojaNomina=@Id_HojaNomina
		else
			set @existe=1
		if @existe=0
			insert into HojaNominaDetalle ([Id_HojaNomina]
				  ,[Id_secuencia]
				  ,[Id_empleado]
				  ,[Cajas]
				  ,[Importe]
				  ,[Creador]
			   	  ,[Fecha_Creador])
			select 'TEMP01'
				  ,[Id_secuencia]
				  ,[Id_empleado]
				  ,[Cajas]
				  ,[Importe]
				  ,@Usuario
				  ,getdate()
			from HojaNominaDetalle
			where Id_HojaNomina=@Id_HojaNomina
		else
			set @existe=1
		if @existe=0
			delete from HojaNominaDetalle where Id_HojaNomina=@Id_HojaNomina
		else
			set @existe=1
		if @existe=0
			delete from HojaNomina where Id_HojaNomina=@Id_HojaNomina
		else
			set @existe=1
		if @existe=0
			INSERT INTO HojaNomina ([Id_HojaNomina]
				  ,[Fecha_HojaNomina]
				  ,[Id_Cuadrilla]
				  ,[Empresa]
				  ,[Pago_Diario]
				  ,[Id_JefeCuadrilla]
				  ,[Tope_pgo_x_dia]
				  ,[Total_corte_pgo_x_dia]
				  ,[Kgs_cortados_x_dia]
				  ,[Cajas_cortados_x_dia]
				  ,[Pago_jefe_cuadrilla]
				  ,[Peso_promedio_caja]
				  ,[Precio_caja_1]
				  ,[Precio_caja_2]
				  ,[Total_cortadores]
				  ,[Total_Cajas]
				  ,[Total_Importe]
				  ,[Pago_x_dia]
				  ,[Pago_falso]
				  ,[Festivo]
				  ,[Estatus]
				  ,[Precio_Caja]
				  ,[Pago_Maniobra]
				  ,[Creador]
			   	  ,[Fecha_Creador])
			SELECT @Id_HojaNomina_New
				  ,[Fecha_HojaNomina]
				  ,[Id_Cuadrilla]
				  ,[Empresa]
				  ,[Pago_Diario]
				  ,[Id_JefeCuadrilla]
				  ,[Tope_pgo_x_dia]
				  ,[Total_corte_pgo_x_dia]
				  ,[Kgs_cortados_x_dia]
				  ,[Cajas_cortados_x_dia]
				  ,[Pago_jefe_cuadrilla]
				  ,[Peso_promedio_caja]
				  ,[Precio_caja_1]
				  ,[Precio_caja_2]
				  ,[Total_cortadores]
				  ,[Total_Cajas]
				  ,[Total_Importe]
				  ,[Pago_x_dia]
				  ,[Pago_falso]
				  ,[Festivo]
				  ,[Estatus]
				  ,[Precio_Caja]
				  ,[Pago_Maniobra]
				  ,[Creador]
			   	  ,[Fecha_Creador] FROM HojaNomina
			WHERE Id_HojaNomina='TEMP01'
		else
			set @existe=1
		if @existe=0
			insert into HojaNominaDetalle ([Id_HojaNomina]
				  ,[Id_secuencia]
				  ,[Id_empleado]
				  ,[Cajas]
				  ,[Importe]
				  ,[Creador]
			   	  ,[Fecha_Creador])
			select @Id_HojaNomina_New
				  ,[Id_secuencia]
				  ,[Id_empleado]
				  ,[Cajas]
				  ,[Importe]
				  ,[Creador]
			   	  ,[Fecha_Creador]
			from HojaNominaDetalle
			where Id_HojaNomina='TEMP01'
		else
			set @existe=1
		if @existe=0
			delete from HojaNominaDetalle where Id_HojaNomina='TEMP01'
		else
			set @existe=1
		if @existe=0
			delete from HojaNomina where Id_HojaNomina='TEMP01';
		else 
			set @existe=1
			

		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @existe=-1
	end catch

	select @existe  as resultado
END
