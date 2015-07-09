Imports System.Data.SqlClient
Public Class Cargo
    Public Sub Grabar(ByVal IdCargo As String, ByVal Descripcion As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("CQCargo_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCargo", SqlDbType.Int).Value = Val(IdCargo)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Consulta As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter(Consulta, CN)
        daTabla.Fill(Buscar)
    End Function
End Class
