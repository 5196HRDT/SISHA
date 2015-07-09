Imports System.Data.SqlClient
Public Class Servicio
    Public Function Buscar(ByVal Consulta As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter(Consulta, CN)
        daTabla.Fill(Buscar)
    End Function
End Class
