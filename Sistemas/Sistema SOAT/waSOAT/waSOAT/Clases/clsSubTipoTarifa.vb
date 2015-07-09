Imports System.Data.SqlClient
Public Class clsSubTipoTarifa
    Public Function Combo(IdTipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SubTipoTarifa_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTipo", SqlDbType.Int).Value = IdTipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
