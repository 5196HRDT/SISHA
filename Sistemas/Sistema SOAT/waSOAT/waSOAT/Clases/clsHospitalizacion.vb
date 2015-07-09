Imports System.Data.SqlClient
Public Class clsHospitalizacion

    Public Function VerificarHospitalizacion(ByVal NHistoria As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("VerificarHospitalizacion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.VarChar).Value = NHistoria
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function


End Class
