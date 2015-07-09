Imports System.Data.SqlClient
Public Class Rayos
    Public Function BuscarCodigo(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From CitaRayosXImg Where Historia = '" + Historia + "' Order By Fecha Desc", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

End Class
