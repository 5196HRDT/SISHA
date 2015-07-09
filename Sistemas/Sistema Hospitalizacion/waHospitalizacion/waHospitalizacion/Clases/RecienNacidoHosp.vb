Imports System.Data.SqlClient
Public Class RecienNacidoHosp
    Public Sub Mantenimiento(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Orden As String, ByVal Condicion As String, ByVal Sexo As String, ByVal Peso As String, ByVal Talla As String, ByVal Semanas As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("RecienNacidoHosp_Mantenimiento", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Orden", SqlDbType.VarChar).Value = Orden
        daTabla.SelectCommand.Parameters.Add("@Condicion", SqlDbType.VarChar).Value = Condicion
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Semanas", SqlDbType.Int).Value = Val(Semanas)
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Val(Oper)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("RecienNacidoHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        If CN.State = ConnectionState.Closed Then CN.Open()
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
