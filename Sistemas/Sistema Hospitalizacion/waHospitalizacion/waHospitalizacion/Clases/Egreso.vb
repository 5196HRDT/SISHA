Imports System.Data.SqlClient
Public Class Egreso
    Public Sub Mantenimiento(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal IdResponsable As String, ByVal IdEspecialidad As String, ByVal IdEnfermera As String, IdTipoAlta As String, ByVal IdCondicionAlta As String, ByVal Referido As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacion_Mantenimiento", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@IdTipoAlta", SqlDbType.Int).Value = Val(IdTipoAlta)
        daTabla.SelectCommand.Parameters.Add("@IdCondicionAlta", SqlDbType.Int).Value = Val(IdCondicionAlta)
        daTabla.SelectCommand.Parameters.Add("@Referido", SqlDbType.VarChar).Value = Referido
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub LiberarAlta(ByVal IdIngreso As String)
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacion_LiberarAlta", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacion_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function RepEstadistica(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacion_RepEstadistica", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Consolidado(ByVal F1 As String, F2 As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacion_Consolidado", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
