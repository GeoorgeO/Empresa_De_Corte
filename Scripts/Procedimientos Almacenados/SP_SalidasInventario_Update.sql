USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_SalidasInventario_Update')
DROP PROCEDURE SP_SalidasInventario_Update
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_SalidasInventario_Update] 
	-- Add the parameters for the stored procedure here
	@Serie_Salida	varchar(30),
	@Folio_Salida	char(8),
	@Id_Producto	char(8),
	@Cantidad_SalidasDetalles int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @StockActual int
		declare @StockFinal int
		-- Insert statements for procedure here
		SELECT  @StockActual= Stock
		FROM            Productos
		WHERE        (Id_Producto = @Id_Producto)

		set @StockFinal=@StockActual-@Cantidad_SalidasDetalles

		UPDATE       Productos
		SET                Stock = @StockFinal
		WHERE        (Id_Producto = @Id_Producto)

		UPDATE       SalidasDetalles
		SET                AplicadoInventario = 1
		WHERE        (Serie_Salida = @Serie_Salida) AND (Folio_Salida = @Folio_Salida) AND (Id_Producto = @Id_Producto)
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch
END
