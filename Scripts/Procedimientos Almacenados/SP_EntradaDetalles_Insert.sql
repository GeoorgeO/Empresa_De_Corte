USE [AvoHarvest]
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_EntradaDetalles_Insert')
DROP PROCEDURE SP_EntradaDetalles_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_EntradaDetalles_Insert
	-- Add the parameters for the stored procedure here
	@Serie_Entrada	varchar(30),
	@Folio_Entrada	char(8),
	@Registro_EntradaDetalles	int,
	@Id_Producto	char(8),
	@Nombre_Producto	varchar(150),
	@Nombre_UnidadMedida	varchar(150),
	@Cantidad_EntradaDetalles	int,
	@Precio_EntradaDetalles	money,
	@Total_EntradaDetalles	money,
	@Observaciones_EntradaDetalles	varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try
    -- Insert statements for procedure here
		INSERT INTO EntradaDetalles
							 (Serie_Entrada, Folio_Entrada, Registro_EntradaDetalles, Id_Producto, Nombre_Producto, Nombre_UnidadMedida, Cantidad_EntradaDetalles, Precio_EntradaDetalles, Total_EntradaDetalles, Observaciones_EntradaDetalles, 
							 AplicadoInventario)
		VALUES        (@Serie_Entrada,@Folio_Entrada,@Registro_EntradaDetalles,@Id_Producto,@Nombre_Producto,@Nombre_UnidadMedida,@Cantidad_EntradaDetalles,@Precio_EntradaDetalles,@Total_EntradaDetalles,@Observaciones_EntradaDetalles,0)
	
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

END
GO
