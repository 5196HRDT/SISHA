Imports System.Data.SqlClient
Public Class clsUsuario
    Public Function VerificarUsuario(ByVal Iniciales As String, ByVal Clave As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Usuario Where Iniciales = '" + Iniciales + "' And Clave = '" + Clave + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub CambiarUsuario(ByVal IdUsuario As String, ByVal Clave As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("Usuario_CambiarClave", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub
End Class
