USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Jefes_Area_Insert')
DROP PROCEDURE SP_Jefes_Area_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Jefes_Area_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Jefe_Area char(4),
	@Nombre_Jefe_Area varchar(30)
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
		select @maximo=right(Concat('0000', isnull(max(Id_Jefe_Area),0)+1),4) from dbo.Jefes_Area

		declare @Existe int
		select @Existe = count(Id_Jefe_Area) from dbo.Jefes_Area a where (a.Id_Jefe_Area=@Id_Jefe_Area)

		if @Existe>0 
		
			UPDATE dbo.Jefes_Area
		        SET Nombre_Jefe_Area=@Nombre_Jefe_Area
		    WHERE
		    	Id_Jefe_Area=@Id_Jefe_Area
				
		else
		
			INSERT INTO dbo.Jefes_Area
	           (Id_Jefe_Area
	           ,Nombre_Jefe_Area)
	     	VALUES
	           (@maximo
	           ,@Nombre_Jefe_Area)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
