Imports System.Data.SqlClient
Public Class Parametros
   
    Public Function DameValor(ByVal Descripcion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Parametro Where Descripcion = '" + Descripcion + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

   
End Class
