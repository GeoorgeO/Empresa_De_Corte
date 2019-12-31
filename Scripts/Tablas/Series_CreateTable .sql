USE [AvoHarvest]
GO
IF OBJECT_ID('Series') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Series](
		[Id_Serie] [char](3) NOT NULL,
		[Nombre_Serie] [varchar](30) NULL,
	 CONSTRAINT [PK_Serie] PRIMARY KEY CLUSTERED 
	(
		[Id_Serie] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end