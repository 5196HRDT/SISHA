Imports System.Data.SqlClient
Public Class ViaAdmision
    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ViaAdmision_Combo", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
