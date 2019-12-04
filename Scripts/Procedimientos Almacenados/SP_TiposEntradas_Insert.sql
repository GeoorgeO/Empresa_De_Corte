
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_TiposEntradas_Insert')
DROP PROCEDURE SP_TiposEntradas_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_TiposEntradas_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_TipoEntrada char(3),
	@Nombre_TipoEntrada varchar(30)
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
		select @maximo=right(Concat('000', isnull(max(Id_TipoEntrada),0)+1),3) from dbo.TiposEntradas

		declare @Existe int
		select @Existe = count(Id_TipoEntrada) from dbo.TiposEntradas a where (a.Id_TipoEntrada=@Id_TipoEntrada)

		if @Existe>0 
		
			UPDATE dbo.TiposEntradas
		        SET Nombre_TipoEntrada=@Nombre_TipoEntrada
		    WHERE
		    	Id_TipoEntrada=@Id_TipoEntrada
				
		else
		
			INSERT INTO dbo.TiposEntradas
	           (Id_TipoEntrada
	           ,Nombre_TipoEntrada)
	     	VALUES
	           (@maximo
	           ,@Nombre_TipoEntrada)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
