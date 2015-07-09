Imports System.Data.SqlClient
Public Class Especialidad
    Public Sub Mantenimiento(IdEspecialidad As String, ByVal IdSubServicio As String, Descripcion As String, Bandera As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EspecialidadHosp_Mantenimiento", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdSubServicio As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EspecialidadHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
