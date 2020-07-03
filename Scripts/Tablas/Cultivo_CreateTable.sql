USE [AvoHarvest]
GO
IF OBJECT_ID('Cultivo') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Cultivo](
		[Id_Cultivo] [char](2) NOT NULL,
		[Nombre_Cultivo] [varchar](30) NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_Cultivo] PRIMARY KEY CLUSTERED 
	(
		[Id_Cultivo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end