USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Puestos_Insert')
DROP PROCEDURE SP_Puestos_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Puestos_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Puesto char(3),
	@Nombre_Puesto varchar(50),
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

		declare @maximo char(2)
		select @maximo=right(Concat('00', isnull(max(Id_Puesto),0)+1),2) from dbo.Puestos

		declare @Existe int
		select @Existe = count(Id_Puesto) from dbo.Puestos a where (a.Id_Puesto=@Id_Puesto)

		if @Existe>0 
		
			UPDATE dbo.Puestos
		        SET Nombre_Puesto=@Nombre_Puesto,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Puesto=@Id_Puesto
				
		else
		
			INSERT INTO dbo.Puestos
	           (Id_Puesto
	           ,Nombre_Puesto
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Puesto
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
