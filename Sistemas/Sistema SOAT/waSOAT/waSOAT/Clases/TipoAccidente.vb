Imports System.Data.SqlClient
Public Class TipoAccidente
    Dim Cn As New SqlConnection

    Public Function Filtrar(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TipoAccidente_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("TipoAccidente_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("Aseguradora_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdCentro As String, ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("TipoAccidente_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCentro", SqlDbType.Int).Value = Val(IdCentro)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdCentro As String)
        Dim daTabla As New SqlDataAdapter("TipoAccidente_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCentro", SqlDbType.Int).Value = Val(IdCentro)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub
End Class
