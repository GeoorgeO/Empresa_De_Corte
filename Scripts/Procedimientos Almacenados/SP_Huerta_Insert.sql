USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_Huerta_Insert')
DROP PROCEDURE SP_Huerta_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Huerta_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_Huerta	char(5),
	@Nombre_Huerta	varchar(100),
	@Registro_Huerta	varchar(20),
	@Id_Duenio	char(4),
	@Id_Estado	char(3),
	@Id_Ciudad	char(3),
	@Id_Calidad	char(3),
	@Id_Cultivo	char(2),
	@zona_Huerta	int,
	@banda_Huerta	char(1),
	@este_Huerta	numeric(18, 0),
	@norte_Huerta	numeric(18, 0),
	@asnm_Huerta	int,
	@latitud_Huerta	varchar(50),
	@longitud_Huerta	varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

    -- Insert statements for procedure here
	declare @maximo char(5)
	select @maximo=right(Concat('00000', isnull(max(Id_Huerta),0)+1),5) from dbo.Huerta

	declare @Existe int
	select @Existe = count(Id_Huerta) from dbo.Huerta a where (a.Id_Huerta=@Id_Huerta)

	if @Existe>0 
		begin
			UPDATE       Huerta
			SET                Nombre_Huerta = @Nombre_Huerta, Registro_Huerta = @Registro_Huerta, Id_Duenio = @Id_Duenio, Id_Estado = @Id_Estado, Id_Ciudad = @Id_Ciudad, Id_Calidad = @Id_Calidad, Id_Cultivo = @Id_Cultivo, 
							 zona_Huerta = @zona_Huerta, banda_Huerta = @banda_Huerta, este_Huerta = @este_Huerta, norte_Huerta = @norte_Huerta, asnm_Huerta = @asnm_Huerta, latitud_Huerta = @latitud_Huerta, 
							 longitud_Huerta = @longitud_Huerta
			WHERE        (Id_Huerta = @Id_Huerta)
		end
	else
		begin
			INSERT INTO Huerta
								 (Id_Huerta, Nombre_Huerta, Registro_Huerta, Id_Duenio, Id_Estado, Id_Ciudad, Id_Calidad, Id_Cultivo, zona_Huerta, banda_Huerta, este_Huerta, norte_Huerta, asnm_Huerta, latitud_Huerta, longitud_Huerta,Activa_Huerta)
			VALUES        (@maximo,@Nombre_Huerta,@Registro_Huerta,@Id_Duenio,@Id_Estado,@Id_Ciudad,@Id_Calidad,@Id_Cultivo,@zona_Huerta,@banda_Huerta,@este_Huerta,@norte_Huerta,@asnm_Huerta,@latitud_Huerta,@longitud_Huerta,1)
		end
	commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
