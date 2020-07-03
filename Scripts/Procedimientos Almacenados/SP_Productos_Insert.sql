USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Productos_Insert')
DROP PROCEDURE SP_Productos_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Productos_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Producto char(8),
	@Nombre_Producto varchar(150),
	@Id_UnidadMedida char(3),
	@Inventariable bit,
	@Stock_Min numeric(18,0),
	@Stock_Max numeric(18,0),
	@Anaquel varchar(5),
	@Pasillo varchar(5),
	@Repisa varchar(5),
	@Id_ProductoTipo char(2),
	@Id_Marca char(4),
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
		select @maximo=right(Concat('00000000', isnull(max(Id_Producto),0)+1),8) from dbo.Productos

		declare @Existe int
		select @Existe = count(Id_Producto) from dbo.Productos a where (a.Id_Producto=@Id_Producto)

		if @Existe>0 
		
			UPDATE dbo.Productos
		        SET Nombre_Producto=@Nombre_Producto,
				Id_UnidadMedida=@Id_UnidadMedida,
				Inventariable=@Inventariable,
				Stock_Min=@Stock_Min,
				Stock_Max=@Stock_Max,
				Anaquel=@Anaquel,
				Pasillo=@Pasillo,
				Repisa=@Repisa,
				Id_ProductoTipo=@Id_ProductoTipo,
				Id_Marca=@Id_Marca,
				Modificador=@Usuario,
				Fecha_Modificador=getdate()
		    WHERE
		    	Id_Producto=@Id_Producto
				
		else
		
			INSERT INTO dbo.Productos
	           (Id_Producto
	           ,Nombre_Producto
			   ,Id_UnidadMedida
			   ,Inventariable
			   ,Stock_Min
			   ,Stock_Max
			   ,Anaquel
			   ,Pasillo
			   ,Repisa
			   ,Activo
			   ,Stock
			   ,Id_ProductoTipo
			   ,Id_Marca
			   ,Creador
			   ,Fecha_Creador)
	     	VALUES
	           (@maximo
	           ,@Nombre_Producto
			   ,@Id_UnidadMedida
			   ,@Inventariable
			   ,@Stock_Min
			   ,@Stock_Max
			   ,@Anaquel
			   ,@Pasillo
			   ,@Repisa
			   ,1
			   ,0
			   ,@Id_ProductoTipo
			   ,@Id_Marca
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
