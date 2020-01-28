USE [AvoHarvest]
GO
IF OBJECT_ID('EntradaEncabezado') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[EntradaEncabezado](
		[Serie_Entrada] [varchar](30) NOT NULL,
		[Folio_Entrada] [char](8) NOT NULL,
		[Id_Proveedor] [char](8) NULL,
		[Id_TipoEntrada] [char](3) NULL,
		[Fecha_Entrada] [datetime] NULL,
		[Numero_ArticulosEntrada] [int] NULL,
		[Orden_Compra] [varchar](10) NULL,
		[FacturaPDF] [varbinary](max) NULL,
		[FacturaPDFNombre] [varchar](80) NULL
	 CONSTRAINT [PK_EntradaEncabezado] PRIMARY KEY CLUSTERED 
	(
		[Serie_Entrada] ASC,
		[Folio_Entrada] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end