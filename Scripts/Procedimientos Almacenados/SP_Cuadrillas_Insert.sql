USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Cuadrillas_Insert')
DROP PROCEDURE SP_Cuadrillas_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Cuadrillas_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Cuadrilla char(4),
	@Id_Categoria char(4)
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
		select @maximo=right(Concat('0000', isnull(max(Id_Cuadrilla),0)+1),4) from dbo.Cuadrillas

		declare @Existe int
		select @Existe = count(Id_Cuadrilla) from dbo.Cuadrillas a where (a.Id_Cuadrilla=@Id_Cuadrilla)

		if @Existe>0 
		
			UPDATE dbo.Cuadrillas
		        SET Id_Categoria=@Id_Categoria
		    WHERE
		    	Id_Cuadrilla=@Id_Cuadrilla
				
		else
		
			INSERT INTO dbo.Cuadrillas
	           (Id_Cuadrilla
	           ,Id_Categoria)
	     	VALUES
	           (@maximo
	           ,@Id_Categoria)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
