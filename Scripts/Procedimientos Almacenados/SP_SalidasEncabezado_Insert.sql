USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_SalidasEncabezado_Insert')
DROP PROCEDURE SP_SalidasEncabezado_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_SalidasEncabezado_Insert] 
	-- Add the parameters for the stored procedure here
	@Serie_Salida varchar(30),
	@Folio_Salida char(8),
	@Id_JefeCuadrilla char(8),
	@Id_TipoSalida char(3), 
	@Fecha_Salida datetime,
	@Numero_Articulossalida int
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
		select @maximo=right(Concat('00000000', isnull(max(Folio_Salida),0)+1),8) from dbo.SalidasEncabezado where Serie_Salida=@Serie_Salida

		INSERT INTO SalidasEncabezado
								 (Serie_Salida, Folio_Salida, Id_JefeCuadrilla,Id_TipoSalida, Fecha_Salida, Numero_Articulossalida)
		VALUES        (@Serie_Salida,@maximo,@Id_JefeCuadrilla,@Id_TipoSalida,@Fecha_Salida,@Numero_Articulossalida)
		
		commit transaction T1;
		set @correcto=1
		select @maximo
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch
END
