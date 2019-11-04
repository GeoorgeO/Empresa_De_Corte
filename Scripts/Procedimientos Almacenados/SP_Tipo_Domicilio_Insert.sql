USE [EmpresaCorte]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Tipo_Domicilio_Insert')
DROP PROCEDURE SP_Tipo_Domicilio_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Tipo_Domicilio_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_TipoDomicilio char(4),
	@Nombre_TipoDomicilio varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(4)
		select @maximo=right(Concat('0000', isnull(max(Id_TipoDomicilio),0)+1),4) from dbo.Tipo_Domicilio

		declare @Existe int
		select @Existe = count(Id_TipoDomicilio) from dbo.Tipo_Domicilio a where (a.Id_TipoDomicilio=@Id_TipoDomicilio)

		if @Existe>0 
		
			UPDATE dbo.Tipo_Domicilio
		        SET Nombre_TipoDomicilio=@Nombre_TipoDomicilio
		    WHERE
		    	Id_TipoDomicilio=@Id_TipoDomicilio
				
		else
		
			INSERT INTO dbo.Tipo_Domicilio
	           (Id_TipoDomicilio
	           ,Nombre_TipoDomicilio)
	     	VALUES
	           (@maximo
	           ,@Nombre_TipoDomicilio)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
