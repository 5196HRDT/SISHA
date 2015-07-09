Imports System.Data.SqlClient
Public Class Especialidad
    Public Function Combo(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("BuscarDptoEspecialidadDes", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
