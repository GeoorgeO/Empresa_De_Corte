USE [EmpresaCorte]
GO
IF OBJECT_ID('Tipo_Domicilio') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Tipo_Domicilio](
		[Id_TipoDomicilio] [char](4) NOT NULL,
		[Nombre_TipoDomicilio] [varchar](50) NULL,
	 CONSTRAINT [PK_Tipo_Domicilio] PRIMARY KEY CLUSTERED 
	(
		[Id_TipoDomicilio] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end