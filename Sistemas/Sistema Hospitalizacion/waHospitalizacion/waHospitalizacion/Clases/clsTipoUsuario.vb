﻿Imports System.Data.SqlClient
Public Class clsTipoUsuario
    Public Function Combo() As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("TipoUsuario_Combo", CN)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
