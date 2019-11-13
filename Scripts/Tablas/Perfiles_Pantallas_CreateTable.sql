USE [AvoHarvest]
GO
IF OBJECT_ID('Perfiles_Pantallas') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Perfiles_Pantallas](
		[Id_Perfil] [char](3) NOT NULL,
		[Id_Pantalla] [char](3) NOT NULL,
	
	) ON [PRIMARY]

	end