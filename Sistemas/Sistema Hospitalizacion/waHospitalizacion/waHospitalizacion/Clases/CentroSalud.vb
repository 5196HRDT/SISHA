Imports System.Data.SqlClient
Public Class CentroSalud
  
    Public Function Filtrar(ByVal Des As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CentroSalud_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CentroSalud_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("CentroSalud_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdCentro As String, ByVal Descripcion As String)
        Dim daTabla As New SqlDataAdapter("CentroSalud_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCentro", SqlDbType.Int).Value = Val(IdCentro)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdCentro As String)
        Dim daTabla As New SqlDataAdapter("CentroSalud_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCentro", SqlDbType.Int).Value = Val(IdCentro)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
