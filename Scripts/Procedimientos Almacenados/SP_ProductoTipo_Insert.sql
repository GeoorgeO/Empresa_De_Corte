USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ProductoTipo_Insert')
DROP PROCEDURE SP_ProductoTipo_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_ProductoTipo_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_ProductoTipo char(2),
	@Nombre_ProductoTipo varchar(30),
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
		select @maximo=right(Concat('00', isnull(max(Id_ProductoTipo),0)+1),2) from dbo.ProductoTipo

		declare @Existe int
		select @Existe = count(Id_ProductoTipo) from dbo.ProductoTipo a where (a.Id_ProductoTipo=@Id_ProductoTipo)

		if @Existe>0 
		
			UPDATE dbo.ProductoTipo
		        SET Nombre_ProductoTipo=@Nombre_ProductoTipo,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_ProductoTipo=@Id_ProductoTipo
				
		else
		
			INSERT INTO dbo.ProductoTipo
	           (Id_ProductoTipo
	           ,Nombre_ProductoTipo
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_ProductoTipo
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
