Imports System.Data.SqlClient
Public Class Usuario
    Public Function VerificarUsuario(ByVal Iniciales As String, ByVal Clave As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From Usuario Where Iniciales = '" + Iniciales + "' And Clave = '" + Clave + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub CambiarUsuario(ByVal IdUsuario As String, ByVal Clave As String)
        Dim Cm As New SqlCommand("Usuario_CambiarClave", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub Grabar(ByVal FecRegistro As String, ByVal Iniciales As String, ByVal Clave As String, ByVal Nombres As String, ByVal Nivel As String, ByVal Activo As String, ByVal Inicial As String)
        Dim Cm As New SqlCommand("Usuario_Grabar", CN)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@FecRegistro", SqlDbType.SmallDateTime).Value = FecRegistro
        Cm.Parameters.Add("@Iniciales", SqlDbType.VarChar).Value = Iniciales
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Nivel
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Inicial", SqlDbType.VarChar).Value = Inicial
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdUsuario As String, ByVal Iniciales As String, ByVal Clave As String, ByVal Nombres As String, ByVal Nivel As String, ByVal Activo As String, ByVal Inicial As String)
        Dim Cm As New SqlCommand("Usuario_Modificar", CN)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario
        Cm.Parameters.Add("@Iniciales", SqlDbType.VarChar).Value = Iniciales
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Nivel
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Inicial", SqlDbType.VarChar).Value = Inicial
        Cm.ExecuteNonQuery()
    End Sub

    Public Function Filtro(ByVal Nombres As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("Usuario_Filtro", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
