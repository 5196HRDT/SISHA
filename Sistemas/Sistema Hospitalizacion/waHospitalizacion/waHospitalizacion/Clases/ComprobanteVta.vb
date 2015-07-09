Imports System.Data.SqlClient
Public Class ComprobanteVta
    Public Function BuscarNumero(ByVal Serie As String, ByVal Numero As String) As Data.DataSet
        BuscarNumero = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQBuscarComprobanteVta", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
