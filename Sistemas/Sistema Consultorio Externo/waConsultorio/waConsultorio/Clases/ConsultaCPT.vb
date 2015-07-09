Imports System.Data.SqlClient
Public Class ConsultaCPT

    Public Sub Grabar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdProcedimiento As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProcedimento", SqlDbType.Int).Value = Val(IdProcedimiento)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarAtencion(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_BuscarAtencion", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarAtencionAtendida(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_BuscarAtencionAtendida", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function GenerarHIS(ByVal IdMedico As String, ByVal Especialidad As String, ByVal Fecha As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_GenerarHIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function GenerarHISTurno(ByVal IdMedico As String, ByVal Especialidad As String, ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_GenerarHISTurno", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub EliminarAtencion(ByVal IdProcedimiento As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ConsultaCPT_EliminarAtencion", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = IdProcedimiento
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

End Class
