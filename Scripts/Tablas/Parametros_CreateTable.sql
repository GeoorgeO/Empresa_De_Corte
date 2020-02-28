USE [AvoHarvest]
GO
IF OBJECT_ID('Parametros') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Parametros](
		[Id_Parametro] [char](3) NOT NULL,
		[Pago_x_Dia_Mission] [numeric](10,2) NULL,
		[Pago_x_Dia]  [numeric](10,2) NULL,
		[N_Cortadores_Mission]  [numeric](10,2) NULL,
		[N_Cortadores] [numeric](10,2) NULL,
		[Tope_Pago_Mission] [numeric](10,2) NULL,
		[Tope_Pago] [numeric](10,2) NULL,
		[Lim_Inf_Cort] [numeric](10,2) NULL,
		[Lim_Sup_Cort] [numeric](10,2) NULL,
		[Pago_x_caja] [numeric](10,2) NULL,
		[Pago_x_caja_Inf] [numeric](10,2) NULL,
		[Pago_x_caja_Sup] [numeric](10,2) NULL,
		[Kg_x_Dia_Inf_1] [numeric](10,2) NULL,
		[Kg_x_Dia_Sup_1] [numeric](10,2) NULL,
		[Pago_Inf_1] [numeric](10,2) NULL,
		[Pago_Sup_1] [numeric](10,2) NULL,
		[Pago_Inf_1_Mission] [numeric](10,2) NULL,
		[Pago_Sup_1_Mission] [numeric](10,2) NULL,
		[Kg_x_Dia_Inf_2] [numeric](10,2) NULL,
		[Kg_x_Dia_Sup_2] [numeric](10,2) NULL,
		[Pago_Inf_2] [numeric](10,2) NULL,
		[Pago_Sup_2] [numeric](10,2) NULL,
		[Pago_Inf_2_Mission] [numeric](10,2) NULL,
		[Pago_Sup_2_Mission] [numeric](10,2) NULL,
		[Kg_x_Dia_Inf_3] [numeric](10,2) NULL,
		[Kg_x_Dia_Sup_3] [numeric](10,2) NULL,
		[Pago_Inf_3] [numeric](10,2) NULL,
		[Pago_Sup_3] [numeric](10,2) NULL,
		[Pago_Inf_3_Mission] [numeric](10,2) NULL,
		[Pago_Sup_3_Mission] [numeric](10,2) NULL,
		[Id_Tipo][char](1) NOT NULL
	 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
	(
		[Id_Parametro] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end