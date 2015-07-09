Imports System.Data.SqlClient
Public Class Personal
    Public Function Buscar() As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQPersonal_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarPersonal(ByVal Consulta As String) As Data.DataSet
        BuscarPersonal = New Data.DataSet
        Dim daTabla As New SqlDataAdapter(Consulta, CN)
        daTabla.Fill(BuscarPersonal)
    End Function

    Public Sub Grabar(ByVal IdPersonal As String, ByVal Nombres As String, ByVal IdCargo As String, ByVal Activo As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("CQPersonal_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdPersonal", SqlDbType.Int).Value = Val(IdPersonal)
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.Parameters.Add("@IdCargo", SqlDbType.Int).Value = Val(IdCargo)
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
