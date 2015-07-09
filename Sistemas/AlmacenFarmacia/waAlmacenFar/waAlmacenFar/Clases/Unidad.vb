Imports System.Data.SqlClient
Public Class Unidad
    Public Sub Grabar(ByVal IdUnidad As String, ByVal Descripcion As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("UnidadMedida_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdUnidad", SqlDbType.Int).Value = Val(IdUnidad)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter("UnidadMedida_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
