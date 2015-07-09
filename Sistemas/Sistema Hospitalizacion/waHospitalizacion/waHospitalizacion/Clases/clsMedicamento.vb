Imports System.Data.SqlClient
Public Class clsMedicamento
    Public Function ObtenerMedicamentos(ByVal Des As String, ByVal TipoTarifa As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ObtenerMedicamentos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@TipoTarifa", SqlDbType.VarChar).Value = TipoTarifa
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
