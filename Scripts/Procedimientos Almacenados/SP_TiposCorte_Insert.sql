USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_TiposCorte_Insert')
DROP PROCEDURE SP_TiposCorte_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_TiposCorte_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_TipoCorte char(3),
	@Nombre_TipoCorte varchar(30)
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
		select @maximo=right(Concat('000', isnull(max(Id_TipoCorte),0)+1),3) from dbo.TiposCorte

		declare @Existe int
		select @Existe = count(Id_TipoCorte) from dbo.TiposCorte a where (a.Id_TipoCorte=@Id_TipoCorte)

		if @Existe>0 
		
			UPDATE dbo.TiposCorte
		        SET Nombre_TipoCorte=@Nombre_TipoCorte
		    WHERE
		    	Id_TipoCorte=@Id_TipoCorte
				
		else
		
			INSERT INTO dbo.TiposCorte
	           (Id_TipoCorte
	           ,Nombre_TipoCorte)
	     	VALUES
	           (@maximo
	           ,@Nombre_TipoCorte)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
