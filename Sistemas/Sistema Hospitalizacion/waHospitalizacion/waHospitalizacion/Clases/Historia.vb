Imports System.Data.SqlClient
Public Class Historia
    Public Function BuscarNumero(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From HClinicas Where HClinica=" + Historia + "", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarNombres(ByVal Nombres As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("HCLINICAS_BuscarNombres", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarFN(ByVal HClinica As String, ByVal FNacimiento As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("HCLINICAS_GrabarFN", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = HClinica
        daTabla.SelectCommand.Parameters.Add("@FNacimiento", SqlDbType.SmallDateTime).Value = FNacimiento
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Sub GrabarSexo(ByVal HClinica As String, ByVal Sexo As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("HCLINICAS_GrabarSexo", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = HClinica
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    'Public Function BuscarNombres(ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String) As Data.DataSet
    '    Dim dsTabla As New Data.DataSet
    '    If APaterno <> "" And AMaterno = "" And Nombres = "" Then
    '        Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%'", CN)
    '        daTabla.Fill(dsTabla)
    '    End If
    '    If APaterno <> "" And AMaterno <> "" And Nombres = "" Then
    '        Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%'", CN)
    '        daTabla.Fill(dsTabla)
    '    End If
    '    If APaterno <> "" And AMaterno <> "" And Nombres <> "" Then
    '        Dim daTabla As New SqlDataAdapter("Select HClinica, APaterno, AMaterno, Nombres, Sexo, FNacimiento, NomPadre, NomMadre From HClinicas Where APaterno Like '" + APaterno + "%' And AMaterno Like '" + AMaterno + "%' And Nombres Like '" + Nombres + "%'", CN)
    '        daTabla.Fill(dsTabla)
    '    End If
    '    Return dsTabla
    'End Function

    Public Function Buscar(ByVal NHistoria As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("BuscarHistoria", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NHistoria", SqlDbType.VarChar).Value = Val(NHistoria)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function


End Class
