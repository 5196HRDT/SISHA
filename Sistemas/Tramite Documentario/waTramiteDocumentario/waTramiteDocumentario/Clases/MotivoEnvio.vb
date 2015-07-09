Imports System.Data.SqlClient
Public Class MotivoEnvio
    Dim Cm As SqlCommand

    Public Sub Grabar(ByVal IdMotivoEnvio As String, ByVal IdHojaEnvio As String, ByVal IdMotivoPase As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("MotivoEnvio_Grabar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdMotivoEnvio", SqlDbType.Int).Value = Val(IdMotivoEnvio)
        Cm.Parameters.Add("@IdHojaEnvio", SqlDbType.Int).Value = Val(IdHojaEnvio)
        Cm.Parameters.Add("@IdMotivoPase", SqlDbType.Int).Value = Val(IdMotivoPase)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
