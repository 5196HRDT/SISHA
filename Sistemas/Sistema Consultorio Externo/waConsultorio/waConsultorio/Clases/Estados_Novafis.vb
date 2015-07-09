Imports System.Data.SqlClient
Public Class Estados_Novafis

    Public Function Buscar(ByVal CIE As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Estados_Novafis Where CIE = '" + CIE + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

   
End Class
