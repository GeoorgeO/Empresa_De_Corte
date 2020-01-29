USE [AvoHarvest]
GO
IF OBJECT_ID('Marcas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Marcas](
		[Id_Marca] [char](4) NOT NULL,
		[Nombre_Marca] [varchar](30) NULL,
	 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
	(
		[Id_Marca] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end