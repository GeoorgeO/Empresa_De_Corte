USE [AvoHarvest]
GO
IF OBJECT_ID('Cuadrillas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Cuadrillas](
		[Id_Cuadrilla] [char](3) NOT NULL,
		[Id_Categoria] [char](4) NULL,
	 CONSTRAINT [PK_Cuadrilla] PRIMARY KEY CLUSTERED 
	(
		[Id_Cuadrilla] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end