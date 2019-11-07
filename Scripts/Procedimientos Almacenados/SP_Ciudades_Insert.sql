USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Ciudades_Insert')
DROP PROCEDURE SP_Ciudades_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Ciudades_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Ciudad char(3),
	@Nombre_Ciudad varchar(30),
	@Id_Estado char(3)
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
		select @maximo=right(Concat('000', isnull(max(Id_Ciudad),0)+1),3) from dbo.Ciudades

		declare @Existe int
		select @Existe = count(Id_Ciudad) from dbo.Ciudades a where (a.Id_Ciudad=@Id_Ciudad)

		if @Existe>0 
		
			UPDATE dbo.Ciudades
		        SET Nombre_Ciudad=@Nombre_Ciudad,
				Id_Estado=@Id_Estado
		    WHERE
		    	Id_Ciudad=@Id_Ciudad
				
		else
		
			INSERT INTO dbo.Ciudades
	           (Id_Ciudad
	           ,Nombre_Ciudad
			   ,Id_Estado)
	     	VALUES
	           (@maximo
	           ,@Nombre_Ciudad
			   ,@Id_Estado)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
