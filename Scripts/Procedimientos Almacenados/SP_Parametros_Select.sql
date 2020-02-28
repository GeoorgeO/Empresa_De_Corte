USE AvoHarvest
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
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Parametros_Select')
DROP PROCEDURE SP_Parametros_Select
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Parametros_Select
	-- Add the parameters for the stored procedure here
	@Id_Tipo char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select Id_Parametro,
			Pago_x_Dia_Mission ,
			Pago_x_Dia  ,
			N_Cortadores_Mission  ,
			N_Cortadores ,
			Tope_Pago_Mission ,
			Tope_Pago ,
			Lim_Inf_Cort ,
			Lim_Sup_Cort ,
			Pago_x_caja ,
			Pago_x_caja_Inf ,
			Pago_x_caja_Sup ,
			Kg_x_Dia_Inf_1 ,
			Kg_x_Dia_Sup_1 ,
			Pago_Inf_1 ,
			Pago_Sup_1 ,
			Pago_Inf_1_Mission ,
			Pago_Sup_1_Mission ,
			Kg_x_Dia_Inf_2 ,
			Kg_x_Dia_Sup_2 ,
			Pago_Inf_2 ,
			Pago_Sup_2 ,
			Pago_Inf_2_Mission ,
			Pago_Sup_2_Mission ,
			Kg_x_Dia_Inf_3 ,
			Kg_x_Dia_Sup_3 ,
			Pago_Inf_3 ,
			Pago_Sup_3 ,
			Pago_Inf_3_Mission ,
			Pago_Sup_3_Mission ,
			Id_Tipo
		from Parametros
		where Id_Tipo=@Id_Tipo
END
GO
