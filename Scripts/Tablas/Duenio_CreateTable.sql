USE [AvoHarvest]
GO
IF OBJECT_ID('Duenio') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Duenio](
		[Id_Duenio] [char](4) NOT NULL,
		[Nombre_Duenio] [varchar](100) NULL,
	 CONSTRAINT [PK_Duenio] PRIMARY KEY CLUSTERED 
	(
		[Id_Duenio] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end