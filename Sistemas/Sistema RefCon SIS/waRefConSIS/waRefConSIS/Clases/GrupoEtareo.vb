Imports System.Data.SqlClient
Public Class GrupoEtareo
    Public Function Combo(ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("GrupoEtareo_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
