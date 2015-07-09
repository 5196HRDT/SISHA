Imports System.Data.SqlClient
Public Class clsTipoMuestraOrgano
    Public Sub Mantenimiento(ByVal IdTipoMuestra As String, ByVal Descripcion As String, ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("TipoMuestraOrgano_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTipoMuestra", SqlDbType.Int).Value = Val(IdTipoMuestra)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Oper As String, ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("TipoMuestraOrgano_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
