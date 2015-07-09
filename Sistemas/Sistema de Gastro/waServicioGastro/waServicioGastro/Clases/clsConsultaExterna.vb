Imports System.Data.SqlClient
Public Class clsConsultaExterna
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function BuscarExaSubTipo(F1 As String, F2 As String, SubTipo As String, Paciente As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarExaSubTipo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDetId(IdConsultaExa As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarDetId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function


    Public Sub MuestraTomada(IdConsultaExa As String, FechaTomaMuestra As String, HoraTomaMuestra As String, UsuarioTomaMuestra As String, EquipoTomaMuestra As String)
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

    Public Sub GrabarResultados(IdConsultaExa As String, Resultado As String, FechaResultado As String, HoraResultado As String, UsuarioResultado As String, EquipoResultado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.Parameters.Add("@FechaResultado", SqlDbType.SmallDateTime).Value = FechaResultado
        daTabla.SelectCommand.Parameters.Add("@HoraResultado", SqlDbType.VarChar).Value = HoraResultado
        daTabla.SelectCommand.Parameters.Add("@UsuarioResultado", SqlDbType.VarChar).Value = UsuarioResultado
        daTabla.SelectCommand.Parameters.Add("@EquipoResultado", SqlDbType.VarChar).Value = EquipoResultado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
