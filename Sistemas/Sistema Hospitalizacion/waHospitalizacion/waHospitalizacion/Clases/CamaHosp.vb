Imports System.Data.SqlClient
Public Class CamaHosp
    Public Sub Mantenimiento(IdCama As String, ByVal IdEspecialidad As String, Numero As String, Descripcion As String, Estado As String, Oper As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("CamaHosp_Mantenimiento", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub CambiarEstado(IdCama As String, ByVal Estado As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("CamaHosp_CambiarEstado", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Liberar(IdEspecialidad As String, ByVal Numero As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("CamaHosp_Liberar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdSubServicio As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("CamaHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Asignacion(ByVal IdEspecialidad As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("CamaHosp_Asignacion", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
