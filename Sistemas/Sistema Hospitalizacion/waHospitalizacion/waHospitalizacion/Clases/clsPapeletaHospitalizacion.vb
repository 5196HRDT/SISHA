Imports System.Data.SqlClient
Public Class clsPapeletaHospitalizacion
    Public Function Grabar(ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal IdMedico As String, ByVal Medico As String, ByVal Origen As String, ByVal ServicioSol As String, ByVal Historia As String, ByVal Paciente As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Sexo As String, ByVal FechaProHosp As String, ByVal Motivo As String, ByVal Observaciones As String, ByVal Servicio As String, ByVal SubServicio As String, ByVal Especialidad As String, ByVal TipoMovimiento As String) As String
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

    Public Function GrabarTransferencia(ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal IdMedico As String, ByVal Medico As String, ByVal Origen As String, ByVal ServicioSol As String, ByVal Historia As String, ByVal Paciente As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Sexo As String, ByVal FechaProHosp As String, ByVal Motivo As String, ByVal Observaciones As String, ByVal Servicio As String, ByVal SubServicio As String, ByVal Especialidad As String, ByVal TipoMovimiento As String, ByVal TipoPaciente As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal NumeroPre As String) As String
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacion_GrabarTransferencia", CN)
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
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@NumeroPre", SqlDbType.Int).Value = Val(NumeroPre)

        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        GrabarTransferencia = daTabla.SelectCommand.Parameters("@IdPapeleta").Value
    End Function

    Public Function BuscarInternamiento(ByVal Especialidad As String, ByVal Tipo As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalización_BuscarInternamiento", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar).Value = Tipo
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Internamiento(ByVal IdPapeleta As String, ByVal FechaIngreso As String, ByVal HoraIngreso As String, ByVal UsuarioIngreso As String, ByVal EquipoIngreso As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacion_Internamiento", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPapeleta", SqlDbType.Int).Value = Val(IdPapeleta)
        daTabla.SelectCommand.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = FechaIngreso
        daTabla.SelectCommand.Parameters.Add("@HoraIngreso", SqlDbType.VarChar).Value = HoraIngreso
        daTabla.SelectCommand.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = UsuarioIngreso
        daTabla.SelectCommand.Parameters.Add("@EquipoIngreso", SqlDbType.VarChar).Value = EquipoIngreso
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarInternado(ByVal Especialidad As String, ByVal Paciente As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalización_BuscarInternado", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function VerificarSolicitud(ByVal Especialidad As String, ByVal Historia As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("PapeletaHospitalizacion_VerificarSolicitud", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
