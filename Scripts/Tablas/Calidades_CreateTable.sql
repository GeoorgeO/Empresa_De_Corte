USE [AvoHarvest]
GO
IF OBJECT_ID('Calidades') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Calidades](
		[Id_Calidad] [char](3) NOT NULL,
		[Nombre_Calidad] [varchar](30) NULL,
	 CONSTRAINT [PK_Calidad] PRIMARY KEY CLUSTERED 
	(
		[Id_Calidad] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end