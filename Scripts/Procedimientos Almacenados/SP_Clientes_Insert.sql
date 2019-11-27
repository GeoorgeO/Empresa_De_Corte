USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Clientes_Insert')
DROP PROCEDURE SP_Clientes_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Clientes_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Cliente char(8),
	@Nombre_Cliente varchar(150),
	@Telefono1 varchar(15),
	@Telefono2 varchar(15),
	@Email varchar(50),
	@Contacto varchar(100),
	@RFC varchar(20)
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
		select @maximo=right(Concat('00000000', isnull(max(Id_Cliente),0)+1),8) from dbo.Clientes

		declare @Existe int
		select @Existe = count(Id_Cliente) from dbo.Clientes a where (a.Id_Cliente=@Id_Cliente)

		if @Existe>0 
		
			UPDATE dbo.Clientes
		        SET Nombre_Cliente=@Nombre_Cliente,
				Telefono1=@Telefono1,
				Telefono2=@Telefono2,
				Email=@Email,
				Contacto=@Contacto,
				RFC=@RFC
		    WHERE
		    	Id_Proveedor=@Id_Proveedor
				
		else
		
			INSERT INTO dbo.Clientes
	           (Id_Cliente
	           ,Nombre_Cliente
			   ,Telefono1
			   ,Telefono2
			   ,Email
			   ,Contacto
			   ,RFC)
	     	VALUES
	           (@maximo
	           ,@Nombre_Cliente
			   ,@Telefono1
			   ,@Telefono2
			   ,@Email
			   ,@Contacto
			   ,@RFC)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
