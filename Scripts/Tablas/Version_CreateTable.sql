USE [AvoHarvest]
GO
IF OBJECT_ID('Version') IS NOT NULL
	begin
		select 0
	end
ELSE
	begin
		
	CREATE TABLE [dbo].[Version](
		[version] [varchar](15) NULL,
		[fecha_modificacion] [datetime] NULL
	) ON [PRIMARY]

	end