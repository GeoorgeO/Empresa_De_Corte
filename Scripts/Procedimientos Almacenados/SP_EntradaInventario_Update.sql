USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_EntradaInventario_Update')
DROP PROCEDURE SP_EntradaInventario_Update
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_EntradaInventario_Update] 
	-- Add the parameters for the stored procedure here
	@Serie_Entrada	varchar(30),
	@Folio_Entrada	char(8),
	@Id_Producto	char(8),
	@Cantidad_EntradaDetalles int
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

		set @StockFinal=@StockActual+@Cantidad_EntradaDetalles

		UPDATE       Productos
		SET                Stock = @StockFinal
		WHERE        (Id_Producto = @Id_Producto)

		UPDATE       EntradaDetalles
		SET                AplicadoInventario = 1
		WHERE        (Serie_Entrada = @Serie_Entrada) AND (Folio_Entrada = @Folio_Entrada) AND (Id_Producto = @Id_Producto)
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch
END
