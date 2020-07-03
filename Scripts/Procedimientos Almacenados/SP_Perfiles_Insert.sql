USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Perfiles_Insert')
DROP PROCEDURE SP_Perfiles_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Perfiles_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Perfil char(3),
	@Nombre_Perfil varchar(30),
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
		select @maximo=right(Concat('000', isnull(max(Id_Perfil),0)+1),3) from dbo.Perfiles

		declare @Existe int
		select @Existe = count(Id_Perfil) from dbo.Perfiles a where (a.Id_Perfil=@Id_Perfil)

		if @Existe>0 
		
			UPDATE dbo.Perfiles
		        SET Nombre_Perfil=@Nombre_Perfil,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Perfil=@Id_Perfil
				
		else
		
			INSERT INTO dbo.Perfiles
	           (Id_Perfil
	           ,Nombre_Perfil
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Perfil
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
