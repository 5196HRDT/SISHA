Imports System.Data.SqlClient
Public Class Hospitalizacion

    Public Function VerificarHospitalizacion(ByVal NHistoria As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("VerificarHospitalizacion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = NHistoria
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDetAtencionSer(ByVal HClinica As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("BuscarDetAtencionSer", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = HClinica
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
