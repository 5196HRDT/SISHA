﻿Imports System.Data.SqlClient
Public Class Emergencia
    Public Function VerificarEmergenciaIng(ByVal HClinica As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("VerificarEmergenciaIng", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = HClinica
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub ActualizarIngresoConvenio(ByVal IdIngreso As String, ByVal Preliquidacion As String, Tipo As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "EmergenciaIngreso_ActualizarIngresoConvenio"
        Cm.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        Cm.Parameters.Add("@Preliquidacion", SqlDbType.Int).Value = Preliquidacion
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Cm.ExecuteNonQuery()
    End Sub
End Class
