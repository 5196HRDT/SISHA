Imports System.Data.SqlClient
Public Class ServicioRealizado
    Public Function BuscarCombo(ByVal Descripcion As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select IdServicio, Codigo + ' ' + Descripcion As Descripcion From ServicioRealizado Where Descripcion Like '" + Descripcion + "%'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
