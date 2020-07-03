USE [AvoHarvest]
GO
IF OBJECT_ID('CategoriasCuadrilla') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[CategoriasCuadrilla](
		[Id_Categoria] [char](4) NOT NULL,
		[Nombre_Categoria] [varchar](20)NOT NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
	(
		[Id_Categoria] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end