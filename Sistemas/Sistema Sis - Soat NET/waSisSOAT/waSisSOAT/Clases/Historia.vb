Imports System.Data.SqlClient
Public Class Historia
    Public Function BuscarNumero(ByVal Historia As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select idHistoria, Apaterno,Amaterno,Nombres,FNacimiento,Sexo,Doc_Identidad From HClinicas Where HClinica=" + Historia + "", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub CambiosSIS(ByVal HClinica As String, APaterno As String, AMaterno As String, Nombres As String, FNACIMIENTO As String, Doc_Identidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("HCLINICAS_CambiosSIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.Real).Value = HClinica
        daTabla.SelectCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.Parameters.Add("@FNACIMIENTO", SqlDbType.SmallDateTime).Value = FNACIMIENTO
        daTabla.SelectCommand.Parameters.Add("@Doc_Identidad", SqlDbType.VarChar).Value = Doc_Identidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Function BuscarNombres(ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String) As Data.DataSet
        Dim dsTabla As New Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        If APaterno <> "" And AMaterno = "" And Nombres = "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%'", Cn)
            daTabla.Fill(dsTabla)
        End If
        If APaterno <> "" And AMaterno <> "" And Nombres = "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%'", Cn)
            daTabla.Fill(dsTabla)
        End If
        If APaterno <> "" And AMaterno <> "" And Nombres <> "" Then
            Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%' And Nombres Like '" + Nombres + "%'", Cn)
            daTabla.Fill(dsTabla)
        End If
        Return dsTabla
    End Function
End Class
