USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Empleados_Insert')
DROP PROCEDURE SP_Empleados_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Empleados_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Empleado char(6),
	@Nombre_Empleado varchar(100),
	@Fecha_Nacimiento datetime,
	@NSS varchar(15),
	@Fecha_Alta_Seg_Social varchar(15),
	@Fecha_Baja_Seg_Social varchar(15),
	@Cuenta varchar(150),
	@Tarjeta varchar(150),
	@Fecha_Alta_Seg_Vida varchar(15),
	@Fecha_Baja_Seg_Vida varchar(15),
	@Id_Puesto char(3),
	@Id_Cuadrilla char(5),
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo char(6)
		select @maximo=right(Concat('000000', isnull(max(Id_Empleado),0)+1),6) from dbo.Empleados

		declare @Existe int
		select @Existe = count(Id_Empleado) from dbo.Empleados a where (a.Id_Empleado=@Id_Empleado)


		if len(@Fecha_Alta_Seg_Social)=0 
			set @Fecha_Alta_Seg_Social=NULL
		if len(@Fecha_Baja_Seg_Social)=0 
			set @Fecha_Baja_Seg_Social=NULL
		if len(@Fecha_Alta_Seg_Vida)=0 
			set @Fecha_Alta_Seg_Vida=NULL
		if len(@Fecha_Baja_Seg_Vida)=0 
			set @Fecha_Baja_Seg_Vida=NULL 

		if @Existe>0 
		
			UPDATE dbo.Empleados
		        SET Nombre_Empleado=@Nombre_Empleado,
				Fecha_Nacimiento=@Fecha_Nacimiento,
				NSS=@NSS,
				Fecha_Alta_Seg_Social=@Fecha_Alta_Seg_Social,
				Fecha_Baja_Seg_Social=@Fecha_Baja_Seg_Social,
				Cuenta=@Cuenta,
				Tarjeta=@Tarjeta,
				Fecha_Alta_Seg_Vida=@Fecha_Alta_Seg_Vida,
				Fecha_Baja_Seg_Vida=@Fecha_Baja_Seg_Vida,
				Id_Puesto=@Id_Puesto,
				Id_Cuadrilla=@Id_Cuadrilla,
				Activo=@Activo
		    WHERE
		    	Id_Empleado=@Id_Empleado
				
		else
			INSERT INTO dbo.Empleados
	           (Id_Empleado
	           ,Nombre_Empleado
			   ,Fecha_Nacimiento
			   ,NSS
			   ,Fecha_Alta_Seg_Social
			   ,Fecha_Baja_Seg_Social
			   ,Cuenta
			   ,Tarjeta
			   ,Fecha_Alta_Seg_Vida
			   ,Fecha_Baja_Seg_Vida
			   ,Id_Puesto
			   ,Id_Cuadrilla
			   ,Activo)
	     	VALUES
	           (@maximo
	           ,@Nombre_Empleado
			   ,@Fecha_Nacimiento
			   ,@NSS
			   ,@Fecha_Alta_Seg_Social
			   ,@Fecha_Baja_Seg_Social
			   ,@Cuenta
			   ,@Tarjeta
			   ,@Fecha_Alta_Seg_Vida
			   ,@Fecha_Baja_Seg_Vida
			   ,@Id_Puesto
			   ,@Id_Cuadrilla
			   ,@Activo)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
