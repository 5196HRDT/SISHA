Imports System.Data.SqlClient
Public Class Historia
    Public Function BuscarNumero(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From HClinicas Where HClinica=" + Historia + "", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarNombres(ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String) As Data.DataSet
        Dim dsTabla As New Data.DataSet
        If APaterno <> "" And AMaterno = "" And Nombres = "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%'", CN)
            daTabla.Fill(dsTabla)
        End If
        If APaterno <> "" And AMaterno <> "" And Nombres = "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%'", CN)
            daTabla.Fill(dsTabla)
        End If
        If APaterno <> "" And AMaterno <> "" And Nombres <> "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%' And Nombres Like '" + Nombres + "%'", CN)
            daTabla.Fill(dsTabla)
        End If
        Return dsTabla
    End Function
End Class
