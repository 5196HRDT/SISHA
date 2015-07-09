Imports System.Data.SqlClient
Public Class Medico
    Public Function BuscarNombres(ByVal Nombres As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select IdMedico, Apellidos + ' '+ Nombres As Medico From Medicos Where Apellidos + ' '+ Nombres Like '" + Nombres + "%' Order By Apellidos, Nombres", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
