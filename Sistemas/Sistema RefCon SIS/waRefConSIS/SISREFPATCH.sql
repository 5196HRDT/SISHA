USE [dbCaja]
GO
/****** Object:  StoredProcedure [dbo].[SISReferencia_Mantenimiento]    Script Date: 16/05/2015 20:04:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SISReferencia_Mantenimiento]
	@IdReferencia Int,
	@Fecha smalldatetime,
	@Hora varchar(5),
	@Usuario varchar(15),
	@Equipo varchar(30),
	@Historia varchar(15),
	@Apaterno varchar(50),
	@Amaterno varchar(50),
	@Nombres varchar(50),
	@NroReferencia varchar(50),
	@IdGrupoEtareo int,
	@Sexo varchar(10),
	@IdEstablecimiento Int,
	@Cie1 varchar(20),	@Des1 varchar(500), @Td1 varchar(15),
	@Cie2 varchar(20),	@Des2 varchar(500), @Td2 varchar(15),
	@Cie3 varchar(20),	@Des3 varchar(500), @Td3 varchar(15),
	@Cie4 varchar(20),	@Des4 varchar(500), @Td4 varchar(15),
	@IdServicio int,
	@IdPersonalRes int,
	@FechaEgreso smalldatetime,
	@CieE1 varchar(15),	@DesE1 varchar(500), @TdE1 varchar(15),
	@CieE2 varchar(15),	@DesE2 varchar(500), @TdE2 varchar(15),
	@CieE3 varchar(15),	@DesE3 varchar(500), @TdE3 varchar(15),
	@CieE4 varchar(15),	@DesE4 varchar(500), @TdE4 varchar(15),
	@IdCondicionAlta int,
	@IdServicioContra Int,
	@MedicoResp varchar(50),
	@Mes varchar(50),
	@Año int,
	@GesPuer varchar(50),
	@Oper char(1)
AS
BEGIN
	If @Oper='1'
		Begin
			Insert Into SISReferencia
			(Fecha, Hora, Usuario, Equipo, Historia, Apaterno, Amaterno,
			Nombres, NroReferencia, IdGrupoEtareo, Sexo, IdEstablecimiento,
			Cie1, Des1,Td1, Cie2, Des2,Td2, Cie3, Des3,Td3, Cie4, Des4,Td4, IdServicio,
			IdPersonalRes, FechaEgreso, CieE1, DesE1,TdE1, CieE2, DesE2,TdE2,
			CieE3, DesE3,TdE3, CieE4, DesE4,TdE4, IdCondicionAlta, IdServicioContra, MedicoResp, Mes, Año, GesPuer)
			Values
			(@Fecha, @Hora, @Usuario, @Equipo, @Historia, @Apaterno, @Amaterno,
			@Nombres, @NroReferencia, @IdGrupoEtareo, @Sexo, @IdEstablecimiento,
			@Cie1, @Des1,@Td1, @Cie2, @Des2,@Td2, @Cie3, @Des3,@Td3, @Cie4, @Des4,@Td4, @IdServicio,
			@IdPersonalRes, @FechaEgreso, @CieE1, @DesE1,@TdE1, @CieE2, @DesE2,@TdE2,
			@CieE3, @DesE3,@TdE3, @CieE4, @DesE4,@TdE4, @IdCondicionAlta, @IdServicioContra, @MedicoResp, @Mes, @Año, @GesPuer)
		End
	IF @Oper='2'
		Begin
			Update SISReferencia Set			
			Fecha=@Fecha, Hora=@Hora, Usuario=@Usuario, Equipo=@Equipo, Historia=@Historia, Apaterno=@Apaterno, Amaterno=@Amaterno,
			Nombres=@Nombres, NroReferencia=@NroReferencia, IdGrupoEtareo=@IdGrupoEtareo, Sexo=@Sexo, IdEstablecimiento=@IdEstablecimiento,
			Cie1=@Cie1, Des1=@Des1,Td1=@Td1, Cie2=@Cie2, Des2=@Des2,Td2=@Td2, Cie3=@Cie3, Des3=@Des3,Td3=@Td3, Cie4=@Cie4, Des4=@Des4, Td4=@TdE4,
			IdServicio=@IdServicio,
			IdPersonalRes=@IdPersonalRes, FechaEgreso=@FechaEgreso, 
			CieE1=@CieE1, DesE1=@DesE1,TdE1=@TdE1, CieE2=@CieE2, DesE2=@DesE2,TdE2=@TdE2,
			CieE3=@CieE3, DesE3=@DesE3,TdE3=@TdE3, CieE4=@CieE4, DesE4=@DesE4, Tde4=@TdE4, IdCondicionAlta=@IdCondicionAlta, IdServicioContra=@IdServicioContra, MedicoResp=@MedicoResp,
			Mes=@Mes, Año=@Año, GesPuer=@GesPuer
			WHERE 
			IdReferencia = @IdReferencia
		End
	IF @Oper='3'
		Begin
			Delete From SISReferencia
			WHERE IdReferencia = @IdReferencia
		End
END

