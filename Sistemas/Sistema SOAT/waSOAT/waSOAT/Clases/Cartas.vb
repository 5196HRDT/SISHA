Imports System.Data.SqlClient
Public Class Cartas


    Public Function Buscar(ByVal IdSOAT As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Cartas_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSOAT", SqlDbType.Int).Value = Val(IdSOAT)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal IdSOAT As String, ByVal NroCarta As String, ByVal Fecha As String, ByVal Monto As String)
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Cartas_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSOAT", SqlDbType.Int).Value = Val(IdSOAT)
        daTabla.SelectCommand.Parameters.Add("@NroCarta", SqlDbType.VarChar).Value = NroCarta
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = Monto
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdSOAT As String)
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Cartas_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSOAT", SqlDbType.Int).Value = Val(IdSOAT)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
