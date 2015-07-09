Imports System.Data.SqlClient
Public Class Cupo
    Public Sub ImpresionSIS(ByVal IdCupo As String, ByVal FechaImpresionSIS As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Cupo_ImpresionSIS", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        daTabla.SelectCommand.Parameters.Add("@FechaImpresionSIS", SqlDbType.SmallDateTime).Value = FechaImpresionSIS
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ReporteCuposSISFecha(ByVal FechaCita As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Cupo_ReporteCuposSISFechaHora", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
