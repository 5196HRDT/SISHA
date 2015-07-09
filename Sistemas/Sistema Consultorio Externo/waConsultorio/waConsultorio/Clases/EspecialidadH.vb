Imports System.Data.SqlClient
Public Class EspecialidadH
   

    Public Function Buscar(ByVal IdSubServicio As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EspecialidadHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
