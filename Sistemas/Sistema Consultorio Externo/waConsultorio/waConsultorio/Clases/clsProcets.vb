Imports System.Data.SqlClient
Public Class clsProcets
    Public Function Mostrar(ByVal Fecha1 As String, ByVal Fecha2 As String, ByVal Tipo As Integer) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Procets_Reporte", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha1", SqlDbType.SmallDateTime).Value = Fecha1
        daTabla.SelectCommand.Parameters.Add("@Fecha2", SqlDbType.SmallDateTime).Value = Fecha2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
