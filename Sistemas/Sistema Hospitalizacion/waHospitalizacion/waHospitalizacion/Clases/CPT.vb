Imports System.Data.SqlClient
Public Class CPT
    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From CPT Where Codigo = '" + Codigo + "'", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From CPT Where Descripcion Like '" + Des + "%' Or Codigo Like '" + Des + "%'", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
