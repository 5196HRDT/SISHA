Imports System.Data.SqlClient
Public Class clsMedico
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub Medicos_CambiarClave(ByVal IdMedico As String, ByVal Clave As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medicos_CAmbiarClave", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Function Medico_ControlAcceso(ByVal Usuario As String, ByVal Clave As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_ControlAcceso", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Medico_BuscarId(ByVal IdMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Medico_BuscarNombres(ByVal Medico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_BuscarNombres", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarEspecialidad(ByVal Especialidad As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Medico_BuscarEspecialidad", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
