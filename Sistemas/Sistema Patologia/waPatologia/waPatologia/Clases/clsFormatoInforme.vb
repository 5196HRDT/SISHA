Imports System.Data.SqlClient
Public Class clsFormatoInforme
    Public Sub Mantenimiento(ByVal IdFormato As String, ByVal Nombre As String, ByVal IdOrgano As String, ByVal IdTipoMuestra As String, ByVal Cuerpo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("FormatoInforme_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdFormato", SqlDbType.Int).Value = Val(IdFormato)
        daTabla.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
        daTabla.SelectCommand.Parameters.Add("@IdOrgano", SqlDbType.Int).Value = Val(IdOrgano)
        daTabla.SelectCommand.Parameters.Add("@IdTipoMuestra", SqlDbType.Int).Value = Val(IdTipoMuestra)
        daTabla.SelectCommand.Parameters.Add("@Cuerpo", SqlDbType.VarChar).Value = Cuerpo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Nombre As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("FormatoInforme_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdFormato As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("FormatoInforme_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdFormato", SqlDbType.VarChar).Value = IdFormato
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
