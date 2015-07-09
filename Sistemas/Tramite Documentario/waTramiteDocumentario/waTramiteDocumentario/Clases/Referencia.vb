Imports System.Data.SqlClient
Public Class Referencia
    Dim Cm As SqlCommand

    Public Sub Grabar(ByVal IdDocumento As String, ByVal IdDocRef As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Referencia_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        daTabla.SelectCommand.Parameters.Add("@IdDocRef", SqlDbType.Int).Value = Val(IdDocRef)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Sub Eliminar(ByVal IdDocumento As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Referencia_Eliminar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDocumento", SqlDbType.Int).Value = Val(IdDocumento)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
