USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Domicilio_Insert')
DROP PROCEDURE SP_Domicilio_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Domicilio_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Domicilio char(6),
	@Calle varchar(100),
	@NoInterior varchar(10),
	@NoExterior varchar(10),
	@Colonia varchar(50),
	@Codigo_Postal char(5),
	@Id_Ciudad char(3),
	@Id_TipoDomicilio char(4),
	@Id_Persona char(8),
	@id_TipoPersona char(4)
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
		select @maximo=right(Concat('000000', isnull(max(Id_Domicilio),0)+1),6) from dbo.Domicilios

		declare @Existe int
		select @Existe = count(Id_Domicilio) from dbo.Domicilios a where (a.Id_Domicilio=@Id_Domicilio)

		if @Existe>0 
		
			UPDATE dbo.Domicilios
		        SET Calle=@Calle,
				NoInterior=@NoInterior,
				NoExterior=@NoExterior,
				Colonia=@Colonia,
				Codigo_Postal=@Codigo_Postal,
				Id_Ciudad=@Id_Ciudad,
				Id_TipoDomicilio=@Id_TipoDomicilio,
				Id_Persona=@Id_Persona,
				id_TipoPersona=@id_TipoPersona
		    WHERE
		    	Id_Domicilio=@Id_Domicilio
				
		else
		
			INSERT INTO dbo.Domicilios
	           (Id_Domicilio
	           ,Calle
			   ,NoInterior
			   ,NoExterior
			   ,Colonia
			   ,Codigo_Postal
			   ,Id_Ciudad
			   ,Id_TipoDomicilio
			   ,Id_Persona
			   ,id_TipoPersona)
	     	VALUES
	           (@maximo
	           ,@Calle
			   ,@NoInterior
			   ,@NoExterior
			   ,@Colonia
			   ,@Codigo_Postal
			   ,@Id_Ciudad
			   ,@Id_TipoDomicilio
			   ,@Id_Persona
			   ,@id_TipoPersona)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
