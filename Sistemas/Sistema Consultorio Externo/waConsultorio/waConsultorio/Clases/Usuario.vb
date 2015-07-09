Imports System.Data.SqlClient
Public Class Usuario

    Public Sub GuardarUsuario(ByVal Id As String, ByVal FReg As String, ByVal Iniciales As String, ByVal Nombres As String, ByVal Clave As String, ByVal Nivel As String, ByVal Inicial As String, ByVal Activo As String, ByVal Bandera As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("GuardarUsuario", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FReg", SqlDbType.SmallDateTime).Value = FReg
        Cm.Parameters.Add("@Iniciales", SqlDbType.VarChar).Value = Iniciales
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Cm.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Nivel
        Cm.Parameters.Add("@Inicial", SqlDbType.VarChar).Value = Inicial
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Bandera", SqlDbType.VarChar).Value = Bandera
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarConsultorio(ByVal Nombres As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Usuario_BuscarConsultorio", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

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
