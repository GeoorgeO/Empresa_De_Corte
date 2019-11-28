USE [AvoHarvest]
GO
IF OBJECT_ID('CategoriasCuadrilla') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[CategoriasCuadrilla](
		[Id_Categoria] [char](3) NOT NULL,
		[Nombre_Categoria] [varchar](20)NOT NULL,
	 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
	(
		[Id_Categoria] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end