USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'EmpresaCorte'))
BEGIN
	create Database EmpresaCorte
END