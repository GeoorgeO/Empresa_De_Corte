USE [EmpresaCorte]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Pais_Insert')
DROP PROCEDURE SP_Pais_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Pais_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Pais char(3),
	@Nombre_Pais varchar(30)
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
		select @maximo=right(Concat('000', isnull(max(Id_Pais),0)+1),3) from dbo.Pais

		declare @Existe int
		select @Existe = count(Id_Pais) from dbo.Pais a where (a.Id_Pais=@Id_Pais)

		if @Existe>0 
		
			UPDATE dbo.Pais
		        SET Nombre_Pais=@Nombre_Pais
		    WHERE
		    	Id_Pais=@Id_Pais
				
		else
		
			INSERT INTO dbo.Pais
	           (Id_Pais
	           ,Nombre_Pais)
	     	VALUES
	           (@maximo
	           ,@Nombre_Pais)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
