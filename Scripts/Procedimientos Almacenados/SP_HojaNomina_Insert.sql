USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojaNomina_Insert')
DROP PROCEDURE SP_HojaNomina_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_HojaNomina_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_HojaNomina varchar(10),
	@Fecha_HojaNomina datetime,
	@Id_Cuadrilla char(4),
	@Empresa varchar(30),
	@Pago_Diario numeric(10,2),
	@Id_JefeCuadrilla char(6),
	@Tope_pgo_x_dia numeric(10,2),
	@Total_corte_pgo_x_dia numeric(10,2),
	@Kgs_cortados_x_dia numeric(10,2),
	@Cajas_cortados_x_dia numeric(10,2),
	@Pago_jefe_cuadrilla numeric(10,2),
	@Peso_promedio_caja numeric(10,2),
	@Precio_caja_1 numeric(10,2),
	@Precio_caja_2 numeric(10,2),
	@Total_cortadores numeric(10,2),
	@Total_Cajas numeric(10,2),
	@Total_Importe numeric(10,2),
	@Pago_x_dia bit,
	@Pago_falso bit,
	@Festivo bit,
	@Estatus char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try


		declare @Existe int
		select @Existe = count(Id_HojaNomina) from dbo.HojaNomina a where (a.Id_HojaNomina=@Id_HojaNomina)

		if @Existe>0 
		
			UPDATE dbo.HojaNomina
		        SET Fecha_HojaNomina=@Fecha_HojaNomina,
				Id_Cuadrilla=@Id_Cuadrilla,
				Empresa=@Empresa,
				Pago_Diario=@Pago_Diario,
				Id_JefeCuadrilla=@Id_JefeCuadrilla,
				Tope_pgo_x_dia=@Tope_pgo_x_dia,
				Total_corte_pgo_x_dia=@Total_corte_pgo_x_dia,
				Kgs_cortados_x_dia=@Kgs_cortados_x_dia,
				Pago_jefe_cuadrilla=@Pago_jefe_cuadrilla,
				Peso_promedio_caja=@Peso_promedio_caja,
				Precio_caja_1=@Precio_caja_1,
				Precio_caja_2=@Precio_caja_2,
				Total_cortadores=@Total_cortadores,
				Total_Cajas=@Total_Cajas,
				Total_Importe=@Total_Importe,
				Pago_x_dia=@Pago_x_dia,
				Pago_falso=@Pago_falso,
				Festivo=@Festivo,
				Estatus=@Estatus
		    WHERE
		    	Id_HojaNomina=@Id_HojaNomina
				
		else
		
			INSERT INTO dbo.HojaNomina
	           (Id_HojaNomina
	           ,Fecha_HojaNomina
			   ,Id_Cuadrilla
			   ,Empresa
			   ,Pago_Diario
			   ,Id_JefeCuadrilla
			   ,Tope_pgo_x_dia
			   ,Total_corte_pgo_x_dia
			   ,Kgs_cortados_x_dia
			   ,Cajas_cortados_x_dia
			   ,Pago_jefe_cuadrilla
			   ,Peso_promedio_caja
			   ,Precio_caja_1
			   ,Precio_caja_2
			   ,Total_cortadores
			   ,Total_Cajas
			   ,Total_Importe
			   ,Pago_x_dia
			   ,Pago_falso
			   ,Festivo
			   ,Estatus)
	     	VALUES
	           (@Id_HojaNomina
	           ,@Fecha_HojaNomina
			   ,@Id_Cuadrilla
			   ,@Empresa
			   ,@Pago_Diario
			   ,@Id_JefeCuadrilla
			   ,@Tope_pgo_x_dia
			   ,@Total_corte_pgo_x_dia
			   ,@Kgs_cortados_x_dia
			   ,@Cajas_cortados_x_dia
			   ,@Pago_jefe_cuadrilla
			   ,@Peso_promedio_caja
			   ,@Precio_caja_1
			   ,@Precio_caja_2
			   ,@Total_cortadores
			   ,@Total_Cajas
			   ,@Total_Importe
			   ,@Pago_x_dia
			   ,@Pago_falso
			   ,@Festivo
			   ,@Estatus)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
