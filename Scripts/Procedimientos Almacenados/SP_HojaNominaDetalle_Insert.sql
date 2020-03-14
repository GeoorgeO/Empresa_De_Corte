USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_HojaNominaDetalle_Insert')
DROP PROCEDURE SP_HojaNominaDetalle_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_HojaNominaDetalle_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_HojaNomina varchar(10),
	@Id_secuencia char(2),
	@Id_empleado char(6),
	@Cajas numeric(10,2),
	@Importe numeric(10,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(2)
		select @maximo=right(Concat('00', isnull(max(Id_secuencia),0)+1),2) from dbo.HojaNominaDetalle where Id_HojaNomina=@Id_HojaNomina

		declare @Existe int
		select @Existe = count(Id_HojaNomina) from dbo.HojaNominaDetalle a where (a.Id_HojaNomina=@Id_HojaNomina and a.Id_secuencia=@Id_secuencia)

		if @Existe>0 
		
			UPDATE dbo.HojaNominaDetalle
		        SET Id_empleado=@Id_empleado,
				Cajas=@Cajas,
				Importe=@Importe
		    WHERE
		    	Id_HojaNomina=@Id_HojaNomina
				and Id_secuencia=@Id_secuencia
				
		else
		
			INSERT INTO dbo.HojaNominaDetalle
	           (Id_HojaNomina
	           ,Id_secuencia
			   ,Id_empleado
			   ,Cajas
			   ,Importe)
	     	VALUES
	           (@Id_HojaNomina
	           ,@maximo
			   ,@Id_empleado
			   ,@Cajas
			   ,@Importe)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
