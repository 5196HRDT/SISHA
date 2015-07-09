Imports System.Data.SqlClient
Public Class CIE10
    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From cie Where cod_gen = '" + Codigo + "'", CnHIS)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From cie Where desc_enf Like '" + Des + "%'", CnHIS)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
