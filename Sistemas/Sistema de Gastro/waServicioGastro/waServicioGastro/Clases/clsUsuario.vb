﻿Imports System.Data.SqlClient
Public Class clsUsuario
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function VerificarUsuario(ByVal Iniciales As String, ByVal Clave As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Usuario Where Iniciales = '" + Iniciales + "' And Clave = '" + Clave + "'", CN)
        Dim dsTabla As New Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub CambiarUsuario(ByVal IdUsuario As String, ByVal Clave As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim Cm As New SqlCommand("Usuario_CambiarClave", CN)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Val(IdUsuario)
        Cm.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub
End Class
