USE [AvoHarvest]
GO
IF OBJECT_ID('Ciudades') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Ciudades](
		[Id_Ciudad] [char](3) NOT NULL,
		[Nombre_Ciudad] [varchar](30) NULL,
		[Id_Estado] [char](3) NULL,
	 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
	(
		[Id_Ciudad] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end