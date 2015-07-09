Imports System.Data.SqlClient
Public Class SubEspecialidad
    Dim Cn As New SqlConnection

    Public Function Combo(ByVal Dpto As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("BuscarDptoEspecialidadDpto", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Dpto", SqlDbType.Int).Value = Dpto
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub
End Class
