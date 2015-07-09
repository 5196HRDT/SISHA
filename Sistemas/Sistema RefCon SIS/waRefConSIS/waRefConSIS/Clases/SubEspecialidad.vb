Imports System.Data.SqlClient
Public Class SubEspecialidad
    Public Function Combo(ByVal Dpto As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("BuscarDptoEspecialidadDpto", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Dpto", SqlDbType.Int).Value = Dpto
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
