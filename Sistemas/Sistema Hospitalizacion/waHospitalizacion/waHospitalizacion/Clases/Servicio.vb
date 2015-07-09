Imports System.Data.SqlClient
Public Class Servicio
    Public Function Combo(ByVal Des As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerPiso", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Guardar(IdPiso As String, ByVal Des As String, Bandera As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("GuardarPiso", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPiso", SqlDbType.Int).Value = Val(IdPiso)
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Anular(IdPiso As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("Piso_Anular", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPiso", SqlDbType.Int).Value = Val(IdPiso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
    End Sub
End Class
