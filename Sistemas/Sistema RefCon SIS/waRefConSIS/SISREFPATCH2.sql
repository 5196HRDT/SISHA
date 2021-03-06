USE [dbCaja]
GO
/****** Object:  StoredProcedure [dbo].[SISReferencia_Buscar]    Script Date: 17/05/2015 14:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SISReferencia_Buscar]
	@Paciente varchar(60)
AS
BEGIN
	SELECT     dbo.SISReferencia.IdReferencia, dbo.SISReferencia.Fecha,dbo.SISReferencia.Historia, dbo.SISReferencia.Apaterno, dbo.SISReferencia.Amaterno, dbo.SISReferencia.Nombres, 
                      dbo.SISReferencia.NroReferencia, dbo.GrupoEtareo.Descripcion AS GrupoEtareo,  dbo.SISReferencia.Sexo, 
                      dbo.CentroSaludSIS.Descripcion AS Establecimiento, dbo.SISReferencia.Cie1, dbo.SISReferencia.Des1, dbo.SISReferencia.Cie2, 
                      dbo.SISReferencia.Des2, dbo.SISReferencia.Cie3, dbo.SISReferencia.Des3, dbo.SISReferencia.Cie4, dbo.SISReferencia.Des4, 
                      dbo.SISRefServicio.Descripcion AS Servicio, dbo.SISRefPersonalRes.Descripcion AS PersonalRes, dbo.SISReferencia.FechaEgreso, 
                      dbo.SISReferencia.CieE1, dbo.SISReferencia.DesE1, dbo.SISReferencia.CieE2, dbo.SISReferencia.DesE2, dbo.SISReferencia.CieE3, 
                      dbo.SISReferencia.DesE3, dbo.SISReferencia.CieE4, dbo.SISReferencia.DesE4, dbo.SISRefCondicionAlta.Descripcion AS CondicionAlta, 
                      dbo.DPTO_ESPECIALIDAD.Descripcion AS Especialidad, dbo.ESPECIALIDAD.Descripcion AS SubEspecialidad, 
                      dbo.Medicos.Apellidos + ' ' + dbo.Medicos.Nombres AS MedicoResp, 
					  dbo.SISReferencia.Td1,dbo.SISReferencia.Td2,dbo.SISReferencia.Td3,dbo.SISReferencia.Td4,
					  dbo.SISReferencia.TdE1,dbo.SISReferencia.TdE2,dbo.SISReferencia.TdE3,dbo.SISReferencia.TdE4
	FROM         dbo.ESPECIALIDAD INNER JOIN
                      dbo.DPTO_ESPECIALIDAD ON dbo.ESPECIALIDAD.IDDPTOESPECILIDAD = dbo.DPTO_ESPECIALIDAD.IdDpto INNER JOIN
                      dbo.SISReferencia INNER JOIN
                      dbo.GrupoEtareo ON dbo.SISReferencia.IdGrupoEtareo = dbo.GrupoEtareo.IdGrupo INNER JOIN
                      dbo.CentroSaludSIS ON dbo.SISReferencia.IdEstablecimiento = dbo.CentroSaludSIS.IdCentro INNER JOIN
                      dbo.SISRefServicio ON dbo.SISReferencia.IdServicio = dbo.SISRefServicio.IdServicio INNER JOIN
                      dbo.SISRefPersonalRes ON dbo.SISReferencia.IdPersonalRes = dbo.SISRefPersonalRes.IdPersonal INNER JOIN
                      dbo.SISRefCondicionAlta ON dbo.SISReferencia.IdCondicionAlta = dbo.SISRefCondicionAlta.IdCondicion ON 
                      dbo.ESPECIALIDAD.IdEspecialidad = dbo.SISReferencia.IdServicioContra INNER JOIN
                      dbo.Medicos ON dbo.SISReferencia.MedicoResp = dbo.Medicos.IdMedico
	WHERE		dbo.SISReferencia.Apaterno + ' '  +  dbo.SISReferencia.Amaterno + ' ' +  dbo.SISReferencia.Nombres Like @Paciente + '%'
END





