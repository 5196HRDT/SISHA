Imports System.Data.SqlClient
Public Class Parametro
    Public Function DameValor(ByVal Nombre As String) As String
        Dim daTabla As New SqlDataAdapter("Select * From Parametro Where Descripcion = '" + Nombre + "'", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        DameValor = dsTabla.Tables(0).Rows(0)("Valor")
    End Function
End Class
