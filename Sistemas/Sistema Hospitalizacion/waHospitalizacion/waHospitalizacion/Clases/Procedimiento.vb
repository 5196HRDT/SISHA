Imports System.Data.SqlClient
Public Class Procedimiento
    Public Sub Mantenimiento(ByVal IdIngreso As String, IdEspecialidad As String, IdResponsable As String, ByVal Codigo As String, ByVal Descripcion As String, ByVal Oper As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProcedimientosHosp_Mantenimiento", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = IdEspecialidad
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = IdResponsable
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ProcedimientosHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
