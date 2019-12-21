USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ReservaProductoSalida_Insert')
DROP PROCEDURE SP_ReservaProductoSalida_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_ReservaProductoSalida_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Producto char(8),
	@Cantidad numeric(18,0),
	@EquipoReservo varchar(80)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

			INSERT INTO dbo.ReservaProductoSalida
	           (Id_Producto
	           ,Cantidad
			   ,EquipoReservo
			   ,HoraReservado)
	     	VALUES
	           (@Id_Producto
	           ,@Cantidad
			   ,@EquipoReservo
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
