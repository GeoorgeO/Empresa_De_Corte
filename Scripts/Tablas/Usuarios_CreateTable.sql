USE [AvoHarvest]
GO
IF OBJECT_ID('Usuarios') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Usuarios](
		[Id_Usuario] [varchar](10) NOT NULL,
		[Nombre_Usuario] [varchar](50) NULL,
		[Contrasena] [varchar](20) NULL,
		[Id_Perfil] [char](3) NOT NULL,
	 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
	(
		[Id_Usuario] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end