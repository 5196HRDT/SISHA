Imports System.Data.SqlClient
Public Class Aseguradora
    Dim Cn As New SqlConnection

    Public Function Filtrar(ByVal RazonSocial As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Aseguradora_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Aseguradora_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Mantenimiento(ByVal IdAseguradora As Integer, ByVal Ruc As String, ByVal RazonSocial As String, ByVal Direccion As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("Aseguradora_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAseguradora", SqlDbType.Int).Value = Val(IdAseguradora)
        daTabla.SelectCommand.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = Ruc
        daTabla.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial
        daTabla.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub
End Class
