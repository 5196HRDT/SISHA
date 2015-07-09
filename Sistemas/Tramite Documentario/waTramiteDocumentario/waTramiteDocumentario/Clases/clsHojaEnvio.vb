Imports System.Data.SqlClient
Public Class clsHojaEnvio

    Public Sub Grabar(ByVal IdHojaEnvio As String, ByVal IdDocumento As String, ByVal IdServAreaOrigen As String,
                      ByVal IdServAreaDestino As String, ByVal TipoEnvio As String, ByVal FechaEnvio As String, ByVal HoraEnvio As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim oDataAdapter As New SqlDataAdapter("HojaEnvio_Grabar", Cn)
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@IdHojaEnvio", SqlDbType.Int).Value = Val(IdHojaEnvio)
        oDataAdapter.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        oDataAdapter.SelectCommand.Parameters.Add("@IdServAreaOrigen", SqlDbType.Int).Value = Val(IdServAreaOrigen)
        oDataAdapter.SelectCommand.Parameters.Add("@IdServAreaDestino", SqlDbType.Int).Value = Val(IdServAreaDestino)
        oDataAdapter.SelectCommand.Parameters.Add("@TipoEnvio", SqlDbType.VarChar).Value = TipoEnvio
        oDataAdapter.SelectCommand.Parameters.Add("@FechaEnvio", SqlDbType.SmallDateTime).Value = FechaEnvio
        oDataAdapter.SelectCommand.Parameters.Add("@HoraEnvio", SqlDbType.VarChar).Value = HoraEnvio
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        oDataAdapter.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
