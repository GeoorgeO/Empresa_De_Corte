USE [EmpresaCorte]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_TipoPersona_Insert')
DROP PROCEDURE SP_TipoPersona_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_TipoPersona_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_TipoPersona char(4),
	@TipoPersona varchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(6)
		select @maximo=right(Concat('0000', isnull(max(Id_TipoPersona),0)+1),4) from dbo.TipoPersona

		declare @Existe int
		select @Existe = count(Id_TipoPersona) from dbo.TipoPersona a where (a.Id_TipoPersona=@Id_TipoPersona)

		if @Existe>0 
		
			UPDATE dbo.TipoPersona
		        SET TipoPersona=@TipoPersona
		    WHERE
		    	Id_TipoPersona=@Id_TipoPersona
				
		else
		
			INSERT INTO dbo.TipoPersona
	           (Id_TipoPersona
	           ,TipoPersona)
	     	VALUES
	           (@maximo
	           ,@TipoPersona)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
