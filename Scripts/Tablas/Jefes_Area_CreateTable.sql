USE [AvoHarvest]
GO
IF OBJECT_ID('Jefes_Area') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Jefes_Area](
		[Id_Jefe_Area] [char](4) NOT NULL,
		[Nombre_Jefe_Area] [varchar](50) NULL,
	 CONSTRAINT [PK_Jefes_Area] PRIMARY KEY CLUSTERED 
	(
		[Id_Jefe_Area] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end