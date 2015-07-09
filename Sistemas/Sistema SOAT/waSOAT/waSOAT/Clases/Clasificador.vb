Imports System.Data.SqlClient
Public Class Clasificador
    Public Function BuscarFiltro(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Clasificador_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Clasificador_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal Orden As String, ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Clasificador_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Orden", SqlDbType.Int).Value = Val(Orden)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdClasificador As String, ByVal Orden As String, ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Clasificador_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdClasificador", SqlDbType.Int).Value = Val(IdClasificador)
        daTabla.SelectCommand.Parameters.Add("@Orden", SqlDbType.VarChar).Value = Val(Orden)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdClasificador As String)
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Clasificador_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdClasificador", SqlDbType.Int).Value = Val(IdClasificador)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
