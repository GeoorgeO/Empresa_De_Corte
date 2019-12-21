use [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteInsert]    Script Date: 25/08/2018 12:39:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ReservaProductoSalidaauto_Delete')
DROP PROCEDURE SP_ReservaProductoSalidaauto_Delete
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_ReservaProductoSalidaauto_Delete] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T2;
	begin try
		
		delete from ReservaProductoSalida where EquipoReservo not in (SELECT 
		   sp.hostname
		FROM sys.databases sd
		LEFT JOIN sys.sysprocesses sp ON sd.database_id = sp.dbid
		WHERE database_id NOT BETWEEN 1 AND 4
		AND LOGINAME IS NOT NULL)

		commit transaction T2;
		set @correcto=1
	end try
	begin catch
		rollback transaction T2;
		set @correcto=0
	end catch

	select @correcto resultado
END
