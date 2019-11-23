USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteInsert]    Script Date: 25/08/2018 12:39:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Empleados_Delete')
DROP PROCEDURE SP_Empleados_Delete
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Empleados_Delete] 
	-- Add the parameters for the stored procedure here
	@Id_Empleado char(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T2;
	begin try
		
		declare @Activo bit
		select @Activo=Activo from dbo.Empleados where Id_Empleado=@Id_Empleado
		
		if @Activo=1
			update dbo.Empleados set Activo=0 where Id_Empleado=@Id_Empleado
		else
			update dbo.Empleados set Activo=1 where Id_Empleado=@Id_Empleado
			
		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
