Imports System.Data.SqlClient
Public Class Ubigeo
    Public Function Departamento() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("UbigeoDepartamento_Combo", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Provincia(ByVal cod_dpto As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("UbigeoProvincia_Combo", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@cod_dpto", SqlDbType.VarChar).Value = cod_dpto
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Distrito(ByVal cod_dpto As String, cod_prov As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("UbigeoDistrito_Combo", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@cod_dpto", SqlDbType.VarChar).Value = cod_dpto
        daTabla.SelectCommand.Parameters.Add("@cod_prov", SqlDbType.VarChar).Value = cod_prov
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
