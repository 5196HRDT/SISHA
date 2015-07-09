Imports System.Data.SqlClient
Public Class Edades

    Public Function BuscarCodigo(ByVal Edad As String, ByVal Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Edades Where Edad = " + Edad + " And Tipo = '" + Tipo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

End Class
