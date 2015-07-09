Imports System.Data.SqlClient
Public Class SISHRDT
    Public Function Buscar(ByVal Lote As String, ByVal Numero As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarNroFormato", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
