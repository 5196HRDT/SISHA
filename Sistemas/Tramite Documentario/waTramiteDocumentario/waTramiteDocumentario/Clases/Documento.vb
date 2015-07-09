Imports System.Data.SqlClient
Public Class Documento
    Dim Cm As SqlCommand

    Public Function Grabar(ByVal IdDocumento As String, ByVal IdTipoDoc As String, ByVal Año As String, ByVal Numero As String, ByVal Fecha As String,
                           ByVal NumeroDoc As String, ByVal Asunto As String, ByVal Referencia As String, ByVal Tipo As String, ByVal Cuerpo As String,
                           ByVal NumeroRegistro As String, ByVal NumeroExpediente As String, ByVal CantidadFolios As String) As String
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("Documento_Grabar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdDocumento", SqlDbType.Int).Direction = ParameterDirection.Output
        Cm.Parameters.Add("@IdTipoDoc", SqlDbType.Int).Value = Val(IdTipoDoc)
        Cm.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        Cm.Parameters.Add("@FechaDoc", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@NumeroDoc", SqlDbType.VarChar).Value = NumeroDoc
        Cm.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = Asunto
        Cm.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Referencia
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Cm.Parameters.Add("@Cuerpo", SqlDbType.VarChar).Value = Cuerpo
        Cm.Parameters.Add("@NumeroRegistro", SqlDbType.VarChar).Value = NumeroRegistro
        Cm.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar).Value = NumeroExpediente
        Cm.Parameters.Add("@CantidadFolios", SqlDbType.VarChar).Value = CantidadFolios
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
        Grabar = Cm.Parameters("@IdDocumento").Value
    End Function

    Public Sub Subir(ByVal IdDocumento As String, ByVal Documento As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim fs As New System.IO.FileStream(Documento, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length)) {}
        fs.Read(data, 0, Convert.ToInt32(fs.Length))
        fs.Close()

        Dim Cm As New SqlCommand("Documento_Subir", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        Cm.Parameters.Add("@Documento", SqlDbType.Image).Value = data
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function PendienteLectura(ByVal IdServAreaDestino As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Documento_PendienteLectura", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdServAreaDestino", SqlDbType.Int).Value = Val(IdServAreaDestino)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarReferencia(ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Documento_BuscarReferencia", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdDocumento As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Documento_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Leido(ByVal IdHojaEnvio As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("Documento_Leido", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdHojaEnvio", SqlDbType.Int).Value = Val(IdHojaEnvio)
        Cm.Parameters.Add("@FechaLectura", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@HoraLectura", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@UsuarioLectura", SqlDbType.VarChar).Value = Usuario
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarEnviado(ByVal IdAsignacionCargo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Documentos_Enviados", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarRecibidos(ByVal IdAsignacionCargo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Documentos_Recibidos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function DocPendientePorTrabajador(ByVal IdTrabajador As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Documento_PendienteTotalXTrabajador", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdTrabajador", SqlDbType.Int).Value = Val(IdTrabajador)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
