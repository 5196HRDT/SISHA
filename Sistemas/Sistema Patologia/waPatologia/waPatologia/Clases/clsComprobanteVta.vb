Imports System.Data.SqlClient
Public Class clsComprobanteVta
    Public Sub MarcarDocEmerRecibido(ByVal IdComprobante As String, ByVal ServicioLab As String, ByVal EspecialidadLab As String)
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ComprobanteVta_MarcarDocEmerRecibido", Cx)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Int).Value = Val(IdComprobante)
        daTabla.SelectCommand.Parameters.Add("@ServicioLab", SqlDbType.VarChar).Value = ServicioLab
        daTabla.SelectCommand.Parameters.Add("@EspecialidadLab", SqlDbType.VarChar).Value = EspecialidadLab
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarLaboratorio(ByVal Serie As String, ByVal Numero As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ComprobanteVta_BuscarLaboratorio", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarPatDocEmergencia(ByVal Paciente As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Comprobante_BuscarPatDocEmergencia", Cx)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cx.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
