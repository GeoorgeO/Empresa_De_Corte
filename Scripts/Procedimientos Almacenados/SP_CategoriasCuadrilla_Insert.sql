USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_CategoriasCuadrilla_Insert')
DROP PROCEDURE SP_CategoriasCuadrilla_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_CategoriasCuadrilla_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Categoria char(4),
	@Nombre_Categoria varchar(20),
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
		select @maximo=right(Concat('0000', isnull(max(Id_Categoria),0)+1),4) from dbo.CategoriasCuadrilla

		declare @Existe int
		select @Existe = count(Id_Categoria) from dbo.CategoriasCuadrilla a where (a.Id_Categoria=@Id_Categoria)

		if @Existe>0 
		
			UPDATE dbo.CategoriasCuadrilla
		        SET Nombre_Categoria=@Nombre_Categoria,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Categoria=@Id_Categoria
				
		else
		
			INSERT INTO dbo.CategoriasCuadrilla
	           (Id_Categoria
	           ,Nombre_Categoria
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Categoria
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
