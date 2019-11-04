USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Estado_Insert')
DROP PROCEDURE SP_Estado_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Estado_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Estado char(3),
	@Nombre_Estado varchar(20),
	@Id_Pais varchar(20)
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
		select @maximo=right(Concat('000', isnull(max(Id_Estado),0)+1),3) from dbo.Estado

		declare @Existe int
		select @Existe = count(Id_Estado) from dbo.Estado a where (a.Id_Estado=@Id_Estado)

		if @Existe>0 
		
			UPDATE dbo.Estado
		        SET Nombre_Estado=@Nombre_Estado
		    WHERE
		    	Id_Estado=@Id_Estado
				
		else
		
			INSERT INTO dbo.Estado
	           (Id_Estado
	           ,Nombre_Estado
			   ,Id_Pais)
	     	VALUES
	           (@maximo
	           ,@Nombre_Estado,
			   @Id_Pais)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
