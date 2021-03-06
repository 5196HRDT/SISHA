﻿Imports System.Data.SqlClient
Public Class clsServicioItem
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function BuscarEmergencia(Descripcion As String, Grupo As String, TipoTarifa As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ServicioItem_BuscarEmergencia", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.Parameters.Add("@TipoTarifa", SqlDbType.VarChar).Value = TipoTarifa
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdServicioItem As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("ServicioItem_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdServicioItem", SqlDbType.Int).Value = IdServicioItem
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
