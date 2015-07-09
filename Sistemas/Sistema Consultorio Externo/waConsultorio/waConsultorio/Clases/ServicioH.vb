Imports System.Data.SqlClient
Public Class ServicioH
    Public Function Combo(ByVal Des As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerPiso", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
