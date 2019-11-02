USE [EmpresaCorte]
GO
IF OBJECT_ID('Proveedores') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Proveedores](
		[Id_Proveedor] [char](8) NOT NULL,
		[Nombre_Proveedor] [varchar](150) NULL,
		[Telefono1] [varchar](15) NULL,
		[Telefono2] [varchar](15) NULL,
		[Email] [varchar](50) NULL,
		[Contacto] [varchar](100) NULL,
	 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
	(
		[Id_Proveedor] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end