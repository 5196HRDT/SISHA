Imports System.Data.SqlClient
Public Class ConCopia
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdDocumento As String, ByVal IdTrabajador As String, ByVal Cargo As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("ConCopia_Grabar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        Cm.Parameters.Add("@IdTrabajador", SqlDbType.Int).Value = Val(IdTrabajador)
        Cm.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Cargo
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
