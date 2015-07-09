Imports System.Data.SqlClient
Public Class Mortalidad
    Public Sub Mantenimiento(ByVal IdIngreso As String, ByVal IdEspecialidad As String, ByVal IdResponsable As String, Fecha As String, Causa As String, Cie As String, Descripcion As String, Necropsia As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("MortalidadHosp_Mantenimiento", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = IdEspecialidad
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = IdResponsable
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Causa", SqlDbType.VarChar).Value = Causa
        daTabla.SelectCommand.Parameters.Add("@CIE", SqlDbType.VarChar).Value = Cie
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Necropsia", SqlDbType.VarChar).Value = Necropsia
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("MortalidadHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        If CN.State = ConnectionState.Closed Then CN.Open()
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Eliminar(ByVal IdIngreso As String)
        Dim daTabla As New SqlDataAdapter("MortalidadHosp_Eliminar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
