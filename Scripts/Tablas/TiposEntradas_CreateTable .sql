USE [AvoHarvest]
GO
IF OBJECT_ID('TiposEntradas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[TiposEntradas](
		[Id_TipoEntrada] [char](3) NOT NULL,
		[Nombre_TipoEntrada] [varchar](30) NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_TipoEntrada] PRIMARY KEY CLUSTERED 
	(
		[Id_TipoEntrada] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end