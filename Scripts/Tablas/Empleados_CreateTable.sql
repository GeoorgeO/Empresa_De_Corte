USE [AvoHarvest]
GO
IF OBJECT_ID('Empleados') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Empleados](
		[Id_Empleado] [char](6) NOT NULL,
		[Nombre_Empleado] [varchar](100) NOT NULL,
		[Fecha_Nacimiento] [datetime] NOT NULL,
		[NSS] [varchar](15) NULL,
		[Fecha_Alta_Seg_Social] [datetime] NULL,
		[Fecha_Baja_Seg_Social] [datetime] NULL,
		[Cuenta][varchar](150) NULL,
		[Tarjeta][varchar](150) NULL,
		[Fecha_Alta_Seg_Vida][datetime] NULL,
		[Fecha_Baja_Seg_Vida][datetime] NULL,
		[Id_Puesto][char](3) NULL,
		[Id_Cuadrilla][char](5) NULL,
		[Activo][bit] NOT NULL
	 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
	(
		[Id_Empleado] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	end