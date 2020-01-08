USE [AvoHarvest]
GO
IF OBJECT_ID('Areas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Areas](
		[Id_Area] [char](4) NOT NULL,
		[Nombre_Area] [varchar](30) NULL,
	 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
	(
		[Id_Area] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end