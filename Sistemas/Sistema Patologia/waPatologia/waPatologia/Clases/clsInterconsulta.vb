Imports System.Data.SqlClient
Public Class clsInterconsulta
    Public Function Buscar(ByVal IdInterconsultaE As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaE_Buscar", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInterconsultaE", SqlDbType.Int).Value = Val(IdInterconsultaE)
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
