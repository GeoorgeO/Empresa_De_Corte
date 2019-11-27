USE [AvoHarvest]
GO
/****** Object:  StoredProcedure [dbo].[SP_BSC_ClienteGeneral]    Script Date: 25/08/2018 12:40:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SP_PrecapturaODC_Insert')
DROP PROCEDURE SP_PrecapturaODC_Insert
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_PrecapturaODC_Insert] 
	-- Add the parameters for the stored procedure here
	@Id_PrecapturaODC bigint,
	@JefeCuadrilla varchar(100),
	@Id_Huerta char(5),
	@Transportista varchar(50),
	@Placas varchar(15),
	@Candado varchar(15),
	@ODC varchar(10),
	@Id_TipoCorte char(3),
	@PSobreBanda bit,
	@Precio numeric(18,2) ,
	@Empaque varchar](50) ,
	@JefeArea varchar(80) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @correcto bit

	begin transaction T1;
	begin try

		declare @maximo bigint
		select @maximo=isnull(max(Id_PrecapturaODC),0)+1 from dbo.PrecapturaODC

		declare @Existe int
		select @Existe = count(Id_PrecapturaODC) from dbo.PrecapturaODC a where (a.Id_PrecapturaODC=@Id_PrecapturaODC)

		if @Existe>0 
		
			UPDATE dbo.PrecapturaODC
		        SET JefeCuadrilla=@JefeCuadrilla,
				Id_Huerta=@Id_Huerta,
				Transportista=@Transportista,
				Placas=@Placas,
				Candado=@Candado,
				ODC=@ODC,
				Id_TipoCorte=@Id_TipoCorte,
				PSobreBanda=@PSobreBanda,
				Precio=@Precio,
				Empaque=@Empaque,
				JefeArea=@JefeArea
		    WHERE
		    	Id_PrecapturaODC=@Id_PrecapturaODC
				
		else
		
			INSERT INTO dbo.PrecapturaODC
	           (Id_PrecapturaODC
	           ,JefeCuadrilla
			   ,Id_Huerta
			   ,Transportista
			   ,Placas
			   ,Candado
			   ,ODC
			   ,Id_TipoCorte
			   ,PSobreBanda
			   ,Precio
			   ,Empaque
			   ,JefeArea)
	     	VALUES
	           (@maximo
	           ,@JefeCuadrilla
			   ,@Id_Huerta
			   ,@Transportista
			   ,@Placas
			   ,@Candado
			   ,@ODC
			   ,@Id_TipoCorte
			   ,@PSobreBanda
			   ,@Precio
			   ,@Empaque
			   ,@JefeArea)
		
		commit transaction T1;
		set @correcto=1
	end try
	begin catch
		rollback transaction T1;
		set @correcto=0
	end catch

	select @correcto resultado
END
