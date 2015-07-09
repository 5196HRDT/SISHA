Imports System.Data.SqlClient
Public Class TempRefSIS

    Public Sub Grabar(ByVal CIE As String)
        Dim daTabla As New SqlDataAdapter("TempRefSIS_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@CIE", SqlDbType.VarChar).Value = CIE
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar()
        Dim daTabla As New SqlDataAdapter("TempRefSIS_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar() As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Select * From TempRefSIS Order By CIE", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

End Class
