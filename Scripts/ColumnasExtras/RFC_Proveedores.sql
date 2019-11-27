use [AvoHarvest]
GO
IF NOT EXISTS (
        SELECT *
        FROM sys.Columns
        WHERE Name = N'RFC'
            AND Object_Id = Object_Id(N'Proveedores')
        )
BEGIN
    ALTER TABLE Proveedores ADD RFC VARCHAR(20) NULL
END
ELSE
BEGIN
    PRINT 'RFC is already added on Proveedores'
END