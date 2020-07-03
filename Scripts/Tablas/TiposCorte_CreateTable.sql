USE [AvoHarvest]
GO
IF OBJECT_ID('TiposCorte') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[TiposCorte](
		[Id_TipoCorte] [char](3) NOT NULL,
		[Nombre_TipoCorte] [varchar](30) NULL,
		[Creador] [varchar](10) NULL,
		[Fecha_Creador] [datetime] NULL,
		[Modificador] [varchar](10) NULL,
		[Fecha_Modificador] [datetime] NULL,
	 CONSTRAINT [PK_TipoCorte] PRIMARY KEY CLUSTERED 
	(
		[Id_TipoCorte] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end