Imports System.Data.SqlClient
Public Class Adjunto
    Dim Cm As SqlCommand

    Public Sub Grabar(ByVal IdDocumento As String, ByVal IdTipoDocAdj As String, ByVal Nombre As String, ByVal Descripcion As String, ByVal Documento As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim fs As New System.IO.FileStream(Documento, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length)) {}
        fs.Read(data, 0, Convert.ToInt32(fs.Length))
        fs.Close()

        Dim daTabla As New SqlDataAdapter("Adjunto_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        daTabla.SelectCommand.Parameters.Add("@IdTipoDocAdj", SqlDbType.Int).Value = Val(IdTipoDocAdj)
        daTabla.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Documento", SqlDbType.Image).Value = data
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Mostrar(ByVal IdDocumento As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Adjunto_Mostrar", Cn)
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

    Public Function Escribir(ByVal IdDocumento As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Adjunto_Escribir", Cn)
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

    Public Sub Eliminar(ByVal IdDocumento As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Adjunto_Eliminar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
