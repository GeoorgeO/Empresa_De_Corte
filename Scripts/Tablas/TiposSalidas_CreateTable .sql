USE [AvoHarvest]
GO
IF OBJECT_ID('TiposSalidas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[TiposSalidas](
		[Id_TipoSalida] [char](3) NOT NULL,
		[Nombre_TipoSalida] [varchar](30) NULL,
	 CONSTRAINT [PK_TipoSalida] PRIMARY KEY CLUSTERED 
	(
		[Id_TipoSalida] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end