USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_EntradaEncabezado_Insert')
DROP PROCEDURE SP_EntradaEncabezado_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_EntradaEncabezado_Insert] 
	-- Add the parameters for the stored procedure here
	@Serie_Entrada	varchar(30),
	@Id_Proveedor	char(8),
	@Id_TipoEntrada	char(3),
	@Fecha_Entrada	datetime,
	@Numero_ArticulosEntrada int,
	@Orden_Compra varchar(10),
	@FacturaPDF varbinary(max),
	@FacturaPDFNombre varchar(80),
	@Id_Empleado char(6) NULL
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
		declare @maximo char(8)
		select @maximo=right(Concat('00000000', isnull(max(Folio_Entrada),0)+1),8) from dbo.EntradaEncabezado where Serie_Entrada=@Serie_Entrada

		INSERT INTO EntradaEncabezado
								 (Serie_Entrada, Folio_Entrada, Id_Proveedor, Id_TipoEntrada, Fecha_Entrada, Numero_ArticulosEntrada, FacturaPDF, FacturaPDFNombre, Id_Empleado,Orden_Compra)
		VALUES        (@Serie_Entrada,@maximo,@Id_Proveedor,@Id_TipoEntrada,@Fecha_Entrada,@Numero_ArticulosEntrada,@FacturaPDF, @FacturaPDFNombre,@Id_Empleado,@Orden_Compra)
		
		commit transaction T1;
		set @correcto=1
		select @maximo
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch
END
