USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Proveedores_Insert')
DROP PROCEDURE SP_Proveedores_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Proveedores_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Proveedor char(8),
	@Nombre_Proveedor varchar(150),
	@Telefono1 varchar(15),
	@Telefono2 varchar(15),
	@Email varchar(50),
	@Contacto varchar(100),
	@RFC varchar(20),
	@Usuario varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(8)
		select @maximo=right(Concat('00000000', isnull(max(Id_Proveedor),0)+1),8) from dbo.Proveedores

		declare @Existe int
		select @Existe = count(Id_Proveedor) from dbo.Proveedores a where (a.Id_Proveedor=@Id_Proveedor)

		if @Existe>0 
		
			UPDATE dbo.Proveedores
		        SET Nombre_Proveedor=@Nombre_Proveedor,
				Telefono1=@Telefono1,
				Telefono2=@Telefono2,
				Email=@Email,
				Contacto=@Contacto,
				RFC=@RFC,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Proveedor=@Id_Proveedor
				
		else
		
			INSERT INTO dbo.Proveedores
	           (Id_Proveedor
	           ,Nombre_Proveedor
			   ,Telefono1
			   ,Telefono2
			   ,Email
			   ,Contacto
			   ,RFC
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Proveedor
			   ,@Telefono1
			   ,@Telefono2
			   ,@Email
			   ,@Contacto
			   ,@RFC
			   ,@Usuario
			   ,getdate())
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
