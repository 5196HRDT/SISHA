Imports System.Data.SqlClient
Public Class clsUsuario
    Public Function VerificarUsuario(ByVal Iniciales As String, ByVal Clave As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Usuario Where Iniciales = '" + Iniciales + "' And Clave = '" + Clave + "'", CN)
        Dim dsTabla As New Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub CambiarUsuario(ByVal IdUsuario As String, ByVal Clave As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim Cm As New SqlCommand("Usuario_CambiarClave", CN)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub
End Class
