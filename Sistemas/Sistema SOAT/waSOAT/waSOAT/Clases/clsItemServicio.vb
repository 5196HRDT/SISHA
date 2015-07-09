Imports System.Data.SqlClient
Public Class clsItemServicio

    Public Function ObtenerItemServicio(Criterio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ObtenerItemServicio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = Criterio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(Id As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ItemServicio_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
