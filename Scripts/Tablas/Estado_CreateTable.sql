USE [AvoHarvest]
GO
IF OBJECT_ID('Estado') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Estado](
		[Id_Estado] [char](3) NOT NULL,
		[Nombre_Estado] [varchar](20) NULL,
		[Id_Pais] [varchar](20) NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
	(
		[Id_Estado] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end