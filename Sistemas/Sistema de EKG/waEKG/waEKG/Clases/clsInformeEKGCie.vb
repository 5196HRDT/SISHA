﻿Imports System.Data.SqlClient
Public Class clsInformeEKGCie
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub Grabar(ByVal IdInforme As String, ByVal Cie As String, ByVal Descripcion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKGCie_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = Val(IdInforme)
        daTabla.SelectCommand.Parameters.Add("@Cie", SqlDbType.VarChar).Value = Cie
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdInforme As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKGCie_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.VarChar).Value = Val(IdInforme)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdInforme As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKGCie_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.VarChar).Value = Val(IdInforme)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

End Class
