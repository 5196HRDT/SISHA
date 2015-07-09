Imports System.Data.SqlClient
Public Class clsConsulta
    Public Function BuscarEspirometrias(ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarEspirometrias", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub MuestraTomada(ByVal IdConsultaExa As String, ByVal FechaTomaMuestra As String, ByVal HoraTomaMuestra As String, ByVal UsuarioTomaMuestra As String, ByVal EquipoTomaMuestra As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_MuestraTomada", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@FechaTomaMuestra", SqlDbType.SmallDateTime).Value = FechaTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@HoraTomaMuestra", SqlDbType.VarChar).Value = HoraTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@UsuarioTomaMuestra", SqlDbType.VarChar).Value = UsuarioTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@EquipoTomaMuestra", SqlDbType.VarChar).Value = EquipoTomaMuestra
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub AnularMuestraTomada(ByVal IdConsultaExa As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_AnularTomaMuestra", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
