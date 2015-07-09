Imports System.Data.SqlClient
Public Class clsSIS
    Public Function ConsultarLN(ByVal Lote As String, ByVal Numero As String, ByVal Historia As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultarLN", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarProcedimientosN(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String)
        Dim Cm As New SqlCommand
        If Cx.State = ConnectionState.Closed Then Cx.Open()
        Cm.Connection = Cx
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_GrabarN"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(UsuRegistro, 10)
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarEmergencia(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String)
        Dim Cm As New SqlCommand
        If Cx.State = ConnectionState.Closed Then Cx.Open()
        Cm.Connection = Cx
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_EliminarEmergencia"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.ExecuteNonQuery()
    End Sub

    Public Function ListaServiciosSIS(ByVal IdSIS As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_ListaServiciosSIS", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSIS", SqlDbType.Int).Value = IdSIS
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AtencionProcedimientoSis(ByVal Id As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal UsuarioAtencion As String)
        Dim Cm As New SqlCommand
        If Cx.State = ConnectionState.Closed Then Cx.Open()
        Cm.Connection = Cx
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SISHRDT_AtencionProcedimientoSis"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarPatAtencionCE(ByVal Paciente As String) As DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarPatAtencionCE", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
