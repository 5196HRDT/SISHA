Imports System.Data.SqlClient

Public Class ServicioItem
    Dim Cn As New SqlConnection
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdServicioItem As String, ByVal IdSubServicio As String, ByVal IdItem As String, ByVal IdTipoTarifa As String, ByVal Precio As String, ByVal Activo As String, ByVal Usuario As String, ByVal Fecha As String, ByVal Hora As String, ByVal Oper As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ServicioItem_Grabar"
        Cm.Parameters.Add("@IdServicioItem", SqlDbType.Int).Value = Val(IdServicioItem)
        Cm.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        Cm.Parameters.Add("@IdItem", SqlDbType.VarChar).Value = IdItem
        Cm.Parameters.Add("@IdTipoTarifa", SqlDbType.Int).Value = Val(IdTipoTarifa)
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub
End Class
