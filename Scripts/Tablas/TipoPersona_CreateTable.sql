USE [AvoHarvest]
GO
IF OBJECT_ID('TipoPersona') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[TipoPersona](
		[Id_TipoPersona] [char](4) NOT NULL,
		[TipoPersona] [varchar](50) NULL,
	 CONSTRAINT [PK_TipoPersona] PRIMARY KEY CLUSTERED 
	(
		[Id_TipoPersona] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end