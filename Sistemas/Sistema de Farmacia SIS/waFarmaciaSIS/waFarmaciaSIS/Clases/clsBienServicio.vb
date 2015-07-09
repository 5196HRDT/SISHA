Imports System.Data.SqlClient
Public Class clsBienServicio
    Dim CX As New SqlConnection("Data Source=ServidorSQL;Initial Catalog=NewGesthion;UID=SA;PWD=hrdt2003")

    Public Sub ActStockBienServ(BienServ As String, Cantidad As String)
        Do While CX.State = ConnectionState.Closed
            CX.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ActStockBienServ", CX)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        Do While CX.State = ConnectionState.Closed
            CX.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
