Imports System.Data.SqlClient
Public Class clsCIE10
    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        If Cx.State = ConnectionState.Closed Then Cx.Open()
        Dim daTabla As New SqlDataAdapter("Select * From CIE10HE Where cod_gen = '" + Codigo + "' Order By cod_gen", Cx)
        Dim dsTabla As New Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From CIE10HE Where desc_enf Like '" + Des + "%' Order By desc_enf", Cx)
        Dim dsTabla As New Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
