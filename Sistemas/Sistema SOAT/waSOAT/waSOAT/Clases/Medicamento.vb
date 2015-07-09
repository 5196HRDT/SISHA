Imports System.Data.SqlClient
Public Class Medicamento
    Public Function BuscarMedicamento(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarMedicamento", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ObtenerMedicamentos(ByVal Des As String, ByVal IdTipoTarifa As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ObtenerMedicamentos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des + "%"
        daTabla.SelectCommand.Parameters.Add("@TipoTarifa", SqlDbType.Int).Value = IdTipoTarifa
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

End Class
