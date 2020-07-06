USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Duenio_Insert')
DROP PROCEDURE SP_Duenio_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Duenio_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Duenio char(4),
	@Nombre_Duenio varchar(100),
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

		declare @maximo char(4)
		select @maximo=right(Concat('0000', isnull(max(Id_Duenio),0)+1),4) from dbo.Duenio

		declare @Existe int
		select @Existe = count(Id_Duenio) from dbo.Duenio a where (a.Id_Duenio=@Id_Duenio)

		if @Existe>0 
		
			UPDATE dbo.Duenio
		        SET Nombre_Duenio=@Nombre_Duenio,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Duenio=@Id_Duenio
				
		else
		
			INSERT INTO dbo.Duenio
	           (Id_Duenio
	           ,Nombre_Duenio
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Duenio
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
