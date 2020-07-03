USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Series_Insert')
DROP PROCEDURE SP_Series_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Series_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Serie char(3),
	@Nombre_Serie varchar(30),
	@Usuario varchar(10)
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
		select @maximo=right(Concat('000', isnull(max(Id_Serie),0)+1),3) from dbo.Series

		declare @Existe int
		select @Existe = count(Id_Serie) from dbo.Series a where (a.Id_Serie=@Id_Serie)

		if @Existe>0 
		
			UPDATE dbo.Series
		        SET Nombre_Serie=@Nombre_Serie,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Serie=@Id_Serie
				
		else
		
			INSERT INTO dbo.Series
	           (Id_Serie
	           ,Nombre_Serie
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Serie
			   ,@Usuario
			   ,getdate())
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END