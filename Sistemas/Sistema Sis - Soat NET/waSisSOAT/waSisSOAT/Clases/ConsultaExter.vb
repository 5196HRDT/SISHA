Imports System.Data.SqlClient
Public Class ConsultaExter
    Dim Cn As New SqlConnection

    Public Function Filtrar(ByVal IdSIS As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_ConsultaExter_Filtrar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSIS)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Grabar(ByVal IdSIS As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal IdSubEspecialidad As String, ByVal Fecha As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_ConsultaExter_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSIS)
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@IdSubEspecialidad", SqlDbType.Int).Value = Val(IdSubEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdCentro As String, ByVal Descripcion As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("CentroSalud_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCentro", SqlDbType.Int).Value = Val(IdCentro)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdConsulta As String, ByVal Usuario As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_ConsultaExter_Anular", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = Val(IdConsulta)
        daTabla.SelectCommand.Parameters.Add("@FechaAnulado", SqlDbType.SmallDateTime).Value = Date.Now
        daTabla.SelectCommand.Parameters.Add("@HoraAnulado", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        daTabla.SelectCommand.Parameters.Add("@UsuarioAnulado", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub
End Class
