USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Parametros_Nomina_C_Insert')
DROP PROCEDURE SP_Parametros_Nomina_C_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Parametros_Nomina_C_Insert] 
	-- Add the parameters for the stored procedure here
	@Dias_trabajo numeric(10, 0),
	@Tipo_Empleado char(1),
	@Sueldo_Bruto numeric(18, 2),
	@ISR numeric(15, 2),
	@Sueldo_Neto numeric(18, 2),
	@elimina int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		if @elimina=1
			delete from Parametros_Nomina_C where Tipo_Empleado=@Tipo_Empleado
		else
			select 0

		Insert into Parametros_Nomina_C values (@Dias_trabajo,@Tipo_Empleado,@Sueldo_Bruto,@ISR,@Sueldo_Neto)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
