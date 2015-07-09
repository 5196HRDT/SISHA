Imports System.Data.SqlClient
Public Class SubDepartamento
    Dim Cn As New SqlConnection

    Public Function Combo(ByVal CodSer As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerSubServicio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@CodSer", SqlDbType.Int).Value = Val(CodSer)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub
End Class
