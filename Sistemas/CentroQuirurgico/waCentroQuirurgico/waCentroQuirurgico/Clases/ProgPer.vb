Imports System.Data.SqlClient
Public Class ProgPer
    Public Function Buscar(ByVal Fecha As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgPer_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarOrigen(ByVal Fecha As String, ByVal Origen As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgPer_BuscarOrigen", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Grabar(ByVal IdProgPer As String, ByVal FechaRegistro As String, ByVal Fecha As String, ByVal IdCargo As String, ByVal IdPersonal As String, ByVal IdSala As String, ByVal Oper As String, ByVal Origen As String)
        Dim daTabla As New SqlDataAdapter("CQProgPer_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgPer", SqlDbType.Int).Value = Val(IdProgPer)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@IdCargo", SqlDbType.VarChar).Value = IdCargo
        daTabla.SelectCommand.Parameters.Add("@IdPersonal", SqlDbType.VarChar).Value = IdPersonal
        daTabla.SelectCommand.Parameters.Add("@IdSala", SqlDbType.VarChar).Value = IdSala
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarReporteOrigen(ByVal Fecha As String, ByVal Tipo As String, ByVal Origen As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgPer_BuscarReporteOrigen", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarReporteWeb(ByVal Fecha As String, ByVal Tipo As String) As Data.DataSet
        BuscarReporteWeb = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgramacion_BuscarReporteWeb", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
