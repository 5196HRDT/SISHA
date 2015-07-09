Imports System.Data.SqlClient
Public Class CIE
    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From cie Where cod_gen = '" + Codigo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From cie Where desc_enf Like '" + Des + "%'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
