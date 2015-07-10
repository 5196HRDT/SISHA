Imports System.Data.SqlClient

'UsuarioAccesoLog'
Public Class Usuario
    Public Function VerificarUsuario(ByVal Iniciales As String, ByVal Clave As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("UsuarioValidarpa", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@inciales", SqlDbType.VarChar).Value = Iniciales
        daTabla.SelectCommand.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub TracerLogin(ByVal UsuarioSistema As String, ByVal Equipo As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim cm As New SqlCommand("UsuarioAccesoLog", Cn)
        cm.CommandType = CommandType.StoredProcedure
        cm.Parameters.Add("@UsuarioSistema", SqlDbType.VarChar).Value = UsuarioSistema
        cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        cm.ExecuteNonQuery()
    End Sub


    Public Sub CambiarUsuario(ByVal IdUsuario As String, ByVal Clave As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim Cm As New SqlCommand("Usuario_CambiarClave", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Cm.ExecuteNonQuery()
    End Sub
End Class
