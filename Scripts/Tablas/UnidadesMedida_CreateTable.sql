USE [AvoHarvest]
GO
IF OBJECT_ID('UnidadesMedida') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[UnidadesMedida](
		[Id_UnidadMedida] [char](3) NOT NULL,
		[Nombre_UnidadMedida] [varchar](150) NULL,
		[Abrevia_UnidadMedida] [varchar](5) NULL,
	 CONSTRAINT [PK_UnidadesMedida] PRIMARY KEY CLUSTERED 
	(
		[Id_UnidadMedida] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end