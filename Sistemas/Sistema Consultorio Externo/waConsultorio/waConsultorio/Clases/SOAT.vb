﻿Imports System.Data.SqlClient
Public Class SOAT

   Public Function BuscarPH(IdSoat As String, Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SoatHRDT_BuscarPH", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDes(Descripcion As String, Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("TarifarioSOAT_BuscarDes", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarDetalle(ByVal IdSoat As String, ByVal IdTarifario As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Fecha As String, ByVal Clasificador As String, ByVal Fecha1 As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Detalle_Grabar"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = IdTarifario
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        Cm.Parameters.Add("@Cantidad", SqlDbType.Real).Value = Cantidad
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        Cm.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha
        Cm.Parameters.Add("@Clasificador", SqlDbType.VarChar).Value = Clasificador
        Cm.Parameters.Add("@Fecha1", SqlDbType.VarChar).Value = Fecha1
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro

        Cm.ExecuteNonQuery()
    End Sub

   
End Class
