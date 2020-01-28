USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Marcas_Insert')
DROP PROCEDURE SP_Marcas_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Marcas_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Marca char(4),
	@Nombre_Marca varchar(30)
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
		select @maximo=right(Concat('0000', isnull(max(Id_Marca),0)+1),4) from dbo.Marcas

		declare @Existe int
		select @Existe = count(Id_Marca) from dbo.Marcas a where (a.Id_Marca=@Id_Marca)

		if @Existe>0 
		
			UPDATE dbo.Marcas
		        SET Nombre_Marca=@Nombre_Marca
		    WHERE
		    	Id_Marca=@Id_Marca
				
		else
		
			INSERT INTO dbo.Marcas
	           (Id_Marca
	           ,Nombre_Marca)
	     	VALUES
	           (@maximo
	           ,@Nombre_Marca)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
