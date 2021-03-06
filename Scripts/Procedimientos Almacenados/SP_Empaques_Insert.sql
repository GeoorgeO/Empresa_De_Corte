USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Empaques_Insert')
DROP PROCEDURE SP_Empaques_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Empaques_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Empaque char(3),
	@Nombre_Empaque varchar(30),
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
		select @maximo=right(Concat('000', isnull(max(Id_Empaque),0)+1),3) from dbo.Empaques

		declare @Existe int
		select @Existe = count(Id_Empaque) from dbo.Empaques a where (a.Id_Empaque=@Id_Empaque)

		if @Existe>0 
		
			UPDATE dbo.Empaques
		        SET Nombre_Empaque=@Nombre_Empaque,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Empaque=@Id_Empaque
				
		else
		
			INSERT INTO dbo.Empaques
	           (Id_Empaque
	           ,Nombre_Empaque
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Empaque
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
