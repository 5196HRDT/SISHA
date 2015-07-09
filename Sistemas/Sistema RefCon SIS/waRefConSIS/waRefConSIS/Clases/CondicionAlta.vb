Imports System.Data.SqlClient
Public Class CondicionAlta
    Public Function Combo() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISRefCondicionAlta_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
