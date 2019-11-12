USE [AvoHarvest]
GO
IF OBJECT_ID('Pantallas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Pantallas](
		[Id_Pantalla] [char](3) NOT NULL,
		[Nombre_Pantalla] [varchar](30) NULL,
	 CONSTRAINT [PK_Pantalla] PRIMARY KEY CLUSTERED 
	(
		[Id_Pantalla] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end