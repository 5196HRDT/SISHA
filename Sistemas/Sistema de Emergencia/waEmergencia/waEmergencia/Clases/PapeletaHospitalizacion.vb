Imports System.Data.SqlClient
Public Class PapeletaHospitalizacion
    Dim Cn As New SqlConnection

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub

    Public Function Grabar(ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal IdMedico As String, ByVal Medico As String, ByVal Origen As String, ByVal ServicioSol As String, Historia As String, Paciente As String, FechaNac As String, Edad As String, Sexo As String, ByVal FechaProHosp As String, ByVal Motivo As String, ByVal Observaciones As String, ByVal Servicio As String, SubServicio As String, Especialidad As String, TipoMovimiento As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacion_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPapeleta", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@ServicioSol", SqlDbType.VarChar).Value = ServicioSol
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@FechaNac", SqlDbType.SmallDateTime).Value = FechaNac
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@FechaProHosp", SqlDbType.SmallDateTime).Value = FechaProHosp
        daTabla.SelectCommand.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Motivo
        daTabla.SelectCommand.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@SubServicio", SqlDbType.VarChar).Value = SubServicio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar).Value = TipoMovimiento

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdPapeleta").Value
    End Function

    Public Function VerificarPendiente(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacion_VerificarPendiente", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
