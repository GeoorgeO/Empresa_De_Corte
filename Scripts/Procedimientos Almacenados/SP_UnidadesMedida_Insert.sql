USE [EmpresaCorte]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_UnidadesMedida_Insert')
DROP PROCEDURE SP_UnidadesMedida_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_UnidadesMedida_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_UnidadMedida char(3),
	@Nombre_UnidadMedida varchar(150),
	@Abrevia_UnidadMedida varchar(5)
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
		select @maximo=right(Concat('000', isnull(max(Id_UnidadMedida),0)+1),3) from dbo.UnidadesMedida

		declare @Existe int
		select @Existe = count(Id_UnidadMedida) from dbo.UnidadesMedida a where (a.Id_UnidadMedida=@Id_UnidadMedida)

		if @Existe>0 
		
			UPDATE dbo.UnidadesMedida
		        SET Nombre_UnidadMedida=@Nombre_UnidadMedida,
				Abrevia_UnidadMedida=@Abrevia_UnidadMedida
		    WHERE
		    	Id_UnidadMedida=@Id_UnidadMedida
				
		else
		
			INSERT INTO dbo.UnidadesMedida
	           (Id_UnidadMedida
	           ,Nombre_UnidadMedida
			   ,Abrevia_UnidadMedida)
	     	VALUES
	           (@maximo
	           ,@Nombre_UnidadMedida
			   ,@Abrevia_UnidadMedida)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
