Imports System.Data.SqlClient
Public Class clsHistoria
    Public Function Buscar(ByVal NHistoria As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("BuscarHistoria", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NHistoria", SqlDbType.VarChar).Value = NHistoria
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
