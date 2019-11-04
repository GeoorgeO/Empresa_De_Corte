USE [EmpresaCorte]
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Domicilio_Select')
DROP PROCEDURE SP_Domicilio_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Domicilio_Select
	-- Add the parameters for the stored procedure here
	@Id_Empleado char(8),
	@id_TipoPersona char(4)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select D.Id_Domicilio
	      ,D.Calle
		  ,D.NoInterior
		  ,D.NoExterior
		  ,D.Colonia
		  ,D.Codigo_Postal
		  ,D.Id_Estado
		  ,E.Nombre_Estado
		  ,D.Id_TipoDomicilio
		  ,TD.Nombre_TipoDomicilio
		  ,D.Id_Persona
		  ,D.id_TipoPersona
		  ,TP.TipoPersona
		from Domicilios as D
		left join Estado as E on D.Id_Estado=E.Id_Estado
		left join Tipo_Domicilio as TD on D.Id_TipoDomicilio=TD.Id_TipoDomicilio
		left join TipoPersona as TP on D.id_TipoPersona=TP.id_TipoPersona
		where TP.Id_TipoPersona=@id_TipoPersona
		and D.Id_Persona=@Id_Empleado
		
		
		
		
		
		

END
GO
