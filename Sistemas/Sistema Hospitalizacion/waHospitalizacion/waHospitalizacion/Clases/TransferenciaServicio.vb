Imports System.Data.SqlClient
Public Class TransferenciaServicio
    Public Sub Mantenimiento(ByVal IdTransferencia As String, ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal IdResponsable As String, IdMedico As String, ByVal IdCama As String, ByVal IdEnfermera As String, ByVal Motivo As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("TransferenciaInt_Mantenimiento", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTransferencia", SqlDbType.Int).Value = Val(IdTransferencia)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Motivo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub MantenimientoP(ByVal IdTransferencia As String, ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal IdResponsable As String, ByVal IdMedico As String, ByVal IdCama As String, ByVal IdEnfermera As String, ByVal Motivo As String, ByVal Tipo As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("TransferenciaInt_MantenimientoP", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTransferencia", SqlDbType.Int).Value = Val(IdTransferencia)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Motivo
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TransferenciaInt_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Anular(ByVal IdTransferencia As String, ByVal FechaAnu As String, ByVal HoraAnu As String, ByVal UsuarioAnu As String, ByVal EquipoAnu As String)
        Dim daTabla As New SqlDataAdapter("TransferenciaInt_Anular", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTransferencia", SqlDbType.Int).Value = Val(IdTransferencia)
        daTabla.SelectCommand.Parameters.Add("@FechaAnu", SqlDbType.SmallDateTime).Value = FechaAnu
        daTabla.SelectCommand.Parameters.Add("@HoraAnu", SqlDbType.VarChar).Value = HoraAnu
        daTabla.SelectCommand.Parameters.Add("@UsuarioAnu", SqlDbType.VarChar).Value = UsuarioAnu
        daTabla.SelectCommand.Parameters.Add("@EquipoAnu", SqlDbType.VarChar).Value = EquipoAnu
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
