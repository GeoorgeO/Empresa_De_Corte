USE [AvoHarvest]
GO
IF OBJECT_ID('PrecapturaODC') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin 
		
	CREATE TABLE [dbo].[PrecapturaODC](
		[Id_PrecapturaODC] [bigint] NOT NULL,
		[Id_JefeCuadrilla] [char](5) NULL,
		[Id_Huerta] [char](5) NULL,
		[Transportista] [varchar](50) NULL,
		[Placas] [varchar](15) NULL,
		[Candado] [varchar](15) NULL,
		[ODC] [varchar](10) NULL,
		[Id_TipoCorte] [char](3) NULL,
		[PSobreBanda][bit] NOT NULL,
		[Precio][numeric](18,2) NOT NULL,
		[Empaque][varchar](50) NULL,
		[JefeArea][varchar](80) NULL,
	 CONSTRAINT [PK_PrecapturaODC] PRIMARY KEY CLUSTERED 
	(
		[Id_PrecapturaODC] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end