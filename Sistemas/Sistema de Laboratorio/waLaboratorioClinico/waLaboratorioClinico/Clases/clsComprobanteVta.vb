Imports System.Data.SqlClient
Public Class clsComprobanteVta
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub MarcarDocEmerRecibido(ByVal IdComprobante As String, ByVal ServicioLab As String, ByVal EspecialidadLab As String)
        Dim daTabla As New SqlDataAdapter("ComprobanteVta_MarcarDocEmerRecibido", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Int).Value = Val(IdComprobante)
        daTabla.SelectCommand.Parameters.Add("@ServicioLab", SqlDbType.VarChar).Value = ServicioLab
        daTabla.SelectCommand.Parameters.Add("@EspecialidadLab", SqlDbType.VarChar).Value = EspecialidadLab
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarLaboratorio(ByVal Serie As String, Numero As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ComprobanteVta_BuscarLaboratorio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarLabDocEmergencia(ByVal Paciente As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Comprobante_BuscarLabDocEmergencia", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarRayCertificado(ByVal Paciente As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Comprobante_BuscarRayCertificado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarNumero(ByVal Serie As String, ByVal Numero As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ComprobanteVta_BuscarNumero", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDetCompVta(ByVal IdComprobante As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("BuscarDetCompVta", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdComprobante", SqlDbType.Real).Value = IdComprobante
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
