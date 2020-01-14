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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Huerta_Select')
DROP PROCEDURE SP_Huerta_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Huerta_Select
	-- Add the parameters for the stored procedure here
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		SELECT        Huerta.Id_Huerta, Huerta.Nombre_Huerta, Huerta.Registro_Huerta, Huerta.Id_Duenio, Duenio.Nombre_Duenio, Huerta.Id_Estado, Estado.Nombre_Estado, Huerta.Id_Ciudad, Ciudades.Nombre_Ciudad, Huerta.Id_Calidad, 
                         Calidades.Nombre_Calidad, Huerta.Id_Cultivo, Cultivo.Nombre_Cultivo, Huerta.zona_Huerta, Huerta.banda_Huerta, Huerta.este_Huerta, Huerta.norte_Huerta, Huerta.asnm_Huerta, Huerta.latitud_Huerta, Huerta.longitud_Huerta, 
                         Huerta.Activa_Huerta
	FROM            Huerta INNER JOIN
                         Duenio ON Huerta.Id_Duenio = Duenio.Id_Duenio INNER JOIN
                         Estado ON Huerta.Id_Estado = Estado.Id_Estado INNER JOIN
                         Ciudades ON Huerta.Id_Ciudad = Ciudades.Id_Ciudad INNER JOIN
                         Calidades ON Huerta.Id_Calidad = Calidades.Id_Calidad INNER JOIN
                         Cultivo ON Huerta.Id_Cultivo = Cultivo.Id_Cultivo
	where Huerta.Activa_Huerta=@Activo

END
GO
