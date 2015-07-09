Imports System.Data.SqlClient
Public Class Tarifario
    Dim Cn As New SqlConnection

    Public Function ObtenerServicio(ByVal Des As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerItemServicio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = Des & "%"
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Tarifario_BuscarDepSer(ByVal IdItem As String, ByVal TipoTarifario As String, ByVal TipoConsulta As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Tarifario_BuscarDepSer", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdItem", SqlDbType.Int).Value = Val(IdItem)
        daTabla.SelectCommand.Parameters.Add("@TipoTarifario", SqlDbType.Int).Value = Val(TipoTarifario)
        daTabla.SelectCommand.Parameters.Add("@TipoConsulta", SqlDbType.VarChar).Value = TipoConsulta
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GuardarServicioItem(ByVal IdSubServicio As String, ByVal IdItem As String, ByVal IdTipoTarifa As String, ByVal Precio As String, ByVal Usuario As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("GuardarServicioItem", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.Parameters.Add("@IdItem", SqlDbType.Int).Value = Val(IdItem)
        daTabla.SelectCommand.Parameters.Add("@IdTipoTarifa", SqlDbType.Int).Value = Val(IdTipoTarifa)
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Date.Now.ToString
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GuardarModTarifa(ByVal IdServicioItem As String, ByVal IdSubServicio As String, ByVal IdItem As String, ByVal IdTipoTarifa As String, ByVal Precio As String, ByVal Usuario As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("GuardarModTarifa", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdServicioItem", SqlDbType.Int).Value = Val(IdServicioItem)
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.Parameters.Add("@IdItem", SqlDbType.Int).Value = Val(IdItem)
        daTabla.SelectCommand.Parameters.Add("@IdTipoTarifa", SqlDbType.Int).Value = Val(IdTipoTarifa)
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Date.Now.ToString
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        daTabla.SelectCommand.Parameters.Add("@IdSubServicioA", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.Parameters.Add("@IdItemA", SqlDbType.Int).Value = Val(IdItem)
        daTabla.SelectCommand.Parameters.Add("@IdTipoTarifaA", SqlDbType.Int).Value = Val(IdTipoTarifa)
        daTabla.SelectCommand.Parameters.Add("@PrecioA", SqlDbType.Money).Value = Val(Precio)
        daTabla.SelectCommand.Parameters.Add("@UsuarioA", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@FechaA", SqlDbType.SmallDateTime).Value = Date.Now.ToString
        daTabla.SelectCommand.Parameters.Add("@HoraA", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub
End Class
