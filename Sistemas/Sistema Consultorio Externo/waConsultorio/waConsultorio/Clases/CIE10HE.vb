Imports System.Data.SqlClient
Public Class CIE10HE
    Public Sub Mantenimiento(ByVal IdCIE10 As String, ByVal desc_enf As String, ByVal cod_gen As String, ByVal Definitivo As String, ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10HE_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCIE10", SqlDbType.Int).Value = IdCIE10
        daTabla.SelectCommand.Parameters.Add("@desc_enf", SqlDbType.VarChar).Value = desc_enf
        daTabla.SelectCommand.Parameters.Add("@cod_gen", SqlDbType.VarChar).Value = cod_gen
        daTabla.SelectCommand.Parameters.Add("@Definitivo", SqlDbType.VarChar).Value = Definitivo
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From CIE10HE Where cod_gen = '" + Codigo + "' Order By cod_gen", Cn)
        Dim dsTabla As New Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From CIE10HE Where desc_enf Like '" + Des + "%' Order By desc_enf", Cn)
        Dim dsTabla As New Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarFiltro(ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10HE_BuscarFiltro", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
