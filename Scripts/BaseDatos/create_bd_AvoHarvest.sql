USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'AvoHarvest'))
BEGIN
	create Database AvoHarvest
END