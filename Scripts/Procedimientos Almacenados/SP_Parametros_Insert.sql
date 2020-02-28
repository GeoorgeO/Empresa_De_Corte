USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Parametros_Insert')
DROP PROCEDURE SP_Parametros_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Parametros_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Parametro char(3),
	@Pago_x_Dia_Mission numeric(10,2),
	@Pago_x_Dia  numeric(10,2) ,
	@N_Cortadores_Mission  numeric(10,2) ,
	@N_Cortadores numeric(10,2) ,
	@Tope_Pago_Mission numeric(10,2) ,
	@Tope_Pago numeric(10,2) ,
	@Lim_Inf_Cort numeric(10,2) ,
	@Lim_Sup_Cort numeric(10,2) ,
	@Pago_x_caja numeric(10,2) ,
	@Pago_x_caja_Inf numeric(10,2) ,
	@Pago_x_caja_Sup numeric(10,2) ,
	@Kg_x_Dia_Inf_1 numeric(10,2) ,
	@Kg_x_Dia_Sup_1 numeric(10,2) ,
	@Pago_Inf_1 numeric(10,2) ,
	@Pago_Sup_1 numeric(10,2) ,
	@Pago_Inf_1_Mission numeric(10,2) ,
	@Pago_Sup_1_Mission numeric(10,2) ,
	@Kg_x_Dia_Inf_2 numeric(10,2) ,
	@Kg_x_Dia_Sup_2 numeric(10,2) ,
	@Pago_Inf_2 numeric(10,2) ,
	@Pago_Sup_2 numeric(10,2) ,
	@Pago_Inf_2_Mission numeric(10,2) ,
	@Pago_Sup_2_Mission numeric(10,2) ,
	@Kg_x_Dia_Inf_3 numeric(10,2) ,
	@Kg_x_Dia_Sup_3 numeric(10,2) ,
	@Pago_Inf_3 numeric(10,2) ,
	@Pago_Sup_3 numeric(10,2) ,
	@Pago_Inf_3_Mission numeric(10,2) ,
	@Pago_Sup_3_Mission numeric(10,2) ,
	@Id_Tipo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(3)
		select @maximo=right(Concat('000', isnull(max(Id_Parametro),0)+1),3) from dbo.Parametros

		declare @Existe int
		select @Existe = count(Id_Parametro) from dbo.Parametros a where (a.Id_Parametro=@Id_Parametro)

		if @Existe>0 
		
			UPDATE dbo.Parametros
		        SET Pago_x_Dia_Mission=@Pago_x_Dia_Mission,
				Pago_x_Dia=@Pago_x_Dia,
				N_Cortadores_Mission=@N_Cortadores_Mission,
				N_Cortadores=@N_Cortadores,
				Tope_Pago_Mission=@Tope_Pago_Mission,
				Tope_Pago=@Tope_Pago,
				Lim_Inf_Cort=@Lim_Inf_Cort,
				Lim_Sup_Cort=@Lim_Sup_Cort,
				Pago_x_caja=@Pago_x_caja,
				Pago_x_caja_Inf=@Pago_x_caja_Inf,
				Pago_x_caja_Sup=@Pago_x_caja_Sup,
				Kg_x_Dia_Inf_1=@Kg_x_Dia_Inf_1,
				Kg_x_Dia_Sup_1=@Kg_x_Dia_Sup_1,
				Pago_Inf_1=@Pago_Inf_1,
				Pago_Sup_1=@Pago_Sup_1,
				Pago_Inf_1_Mission=@Pago_Inf_1_Mission,
				Pago_Sup_1_Mission=@Pago_Sup_1_Mission,
				Kg_x_Dia_Inf_2=@Kg_x_Dia_Inf_2,
				Kg_x_Dia_Sup_2=@Kg_x_Dia_Sup_2,
				Pago_Inf_2=@Pago_Inf_2,
				Pago_Sup_2=@Pago_Sup_2,
				Pago_Inf_2_Mission=@Pago_Inf_2_Mission,
				Pago_Sup_2_Mission=@Pago_Sup_2_Mission,
				Kg_x_Dia_Inf_3=@Kg_x_Dia_Inf_3,
				Kg_x_Dia_Sup_3=@Kg_x_Dia_Sup_3,
				Pago_Inf_3=@Pago_Inf_3,
				Pago_Sup_3=@Pago_Sup_3,
				Pago_Inf_3_Mission=@Pago_Inf_3_Mission,
				Pago_Sup_3_Mission=@Pago_Sup_3_Mission,
				Id_Tipo=@Id_Tipo
		    WHERE
		    	Id_Parametro=@Id_Parametro
				
		else
		
			INSERT INTO dbo.Parametros
	           (Id_Parametro,
			   	Pago_x_Dia_Mission,
				Pago_x_Dia,
				N_Cortadores_Mission,
				N_Cortadores,
				Tope_Pago_Mission,
				Tope_Pago,
				Lim_Inf_Cort,
				Lim_Sup_Cort,
				Pago_x_caja,
				Pago_x_caja_Inf,
				Pago_x_caja_Sup,
				Kg_x_Dia_Inf_1,
				Kg_x_Dia_Sup_1,
				Pago_Inf_1,
				Pago_Sup_1,
				Pago_Inf_1_Mission,
				Pago_Sup_1_Mission,
				Kg_x_Dia_Inf_2,
				Kg_x_Dia_Sup_2,
				Pago_Inf_2,
				Pago_Sup_2,
				Pago_Inf_2_Mission,
				Pago_Sup_2_Mission,
				Kg_x_Dia_Inf_3,
				Kg_x_Dia_Sup_3,
				Pago_Inf_3,
				Pago_Sup_3,
				Pago_Inf_3_Mission,
				Pago_Sup_3_Mission,
				Id_Tipo)
	     	VALUES
	           (@maximo
	           ,@Pago_x_Dia_Mission,
				@Pago_x_Dia,
				@N_Cortadores_Mission,
				@N_Cortadores,
				@Tope_Pago_Mission,
				@Tope_Pago,
				@Lim_Inf_Cort,
				@Lim_Sup_Cort,
				@Pago_x_caja,
				@Pago_x_caja_Inf,
				@Pago_x_caja_Sup,
				@Kg_x_Dia_Inf_1,
				@Kg_x_Dia_Sup_1,
				@Pago_Inf_1,
				@Pago_Sup_1,
				@Pago_Inf_1_Mission,
				@Pago_Sup_1_Mission,
				@Kg_x_Dia_Inf_2,
				@Kg_x_Dia_Sup_2,
				@Pago_Inf_2,
				@Pago_Sup_2,
				@Pago_Inf_2_Mission,
				@Pago_Sup_2_Mission,
				@Kg_x_Dia_Inf_3,
				@Kg_x_Dia_Sup_3,
				@Pago_Inf_3,
				@Pago_Sup_3,
				@Pago_Inf_3_Mission,
				@Pago_Sup_3_Mission,
				@Id_Tipo)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
