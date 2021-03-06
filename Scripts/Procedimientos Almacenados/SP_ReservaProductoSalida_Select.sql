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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_ReservaProductoSalida_Select')
DROP PROCEDURE SP_ReservaProductoSalida_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_ReservaProductoSalida_Select
	-- Add the parameters for the stored procedure here
	@Id_Producto char(8)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select isnull(isnull(avg(Stock),0) - isnull(sum(Cantidad),0),0) as Disponible
		from Productos as P
		left join ReservaProductoSalida as R on R.Id_Producto=P.Id_Producto
		where P.Id_Producto=@Id_Producto
		group by P.Id_Producto
END
GO
