Imports System.Data.SqlClient
Public Class Pecosa
    Public Sub Grabar(ByVal Fecha As String, ByVal Numero As String, ByVal Solicitante As String, ByVal Tipo As String)
        Dim daTabla As New SqlDataAdapter("PecosaAlmFar_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarDetalle(ByVal IdPecosaAlmFar As String, ByVal BienServ As String, ByVal Descripcion As String, ByVal Unidad As String, ByVal Cantidad As String)
        Dim daTabla As New SqlDataAdapter("PecosaAlmFar_GrabarDetalle", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPecosaAlmFar", SqlDbType.Int).Value = IdPecosaAlmFar
        daTabla.SelectCommand.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Unidad
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
