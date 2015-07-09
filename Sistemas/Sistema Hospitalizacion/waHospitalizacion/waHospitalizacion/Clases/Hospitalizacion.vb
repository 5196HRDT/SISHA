Imports System.Data.SqlClient
Public Class Hospitalizacion

    Public Sub AltaServicio(ByVal IdHospitalizacion As String, ByVal FechaAltaServicio As String, ByVal HoraAltaServicio As String, ByVal UsuarioAltaServicio As String, ByVal EquipoAltaServicio As String, ByVal FecSalida As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("Hospitalizacion_AltaServicio", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.Parameters.Add("@FechaAltaServicio", SqlDbType.SmallDateTime).Value = FechaAltaServicio
        daTabla.SelectCommand.Parameters.Add("@HoraAltaServicio", SqlDbType.VarChar).Value = HoraAltaServicio
        daTabla.SelectCommand.Parameters.Add("@UsuarioAltaServicio", SqlDbType.VarChar).Value = UsuarioAltaServicio
        daTabla.SelectCommand.Parameters.Add("@EquipoAltaServicio", SqlDbType.VarChar).Value = EquipoAltaServicio
        daTabla.SelectCommand.Parameters.Add("@FecSalida", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(FechaAltaServicio, 10)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function VerificarHospitalizacion(ByVal HClinica As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Hospitalizacion_VerificarHospitalizacion", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = Val(HClinica)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarIngrePacientes(ByVal F1 As String, ByVal F2 As String, ByVal Servicio As String, ByVal SubServicio As String, ByVal Especialidad As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Hospitalizacion_BuscarIngrePacientes", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@SubServicio", SqlDbType.VarChar).Value = SubServicio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarEgresoPacientes(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Hospitalizacion_BuscarEgresoPacientes", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarTransferencias(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Hospitalizacion_BuscarTransferencias", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function


    Public Function Grabar(HClinica As String, FecIngreso As String, IdCuenta As String, IdSerhos As String, NroCama As String, IdTipo As String, Tipo As String, HoraHosp As String, Medico As String, ViaIngreso As String, EstablecimientoRefiere As String, NotCasoUrgencia As String, DomicilioUrgencia As String, Ocupacion As String, Nacionalidad As String, Departamento As String, Provincia As String, Distrito As String, Centro As String, NomCony As String, Seguro As String, DNIAcomp As String) As String

    End Function
End Class
