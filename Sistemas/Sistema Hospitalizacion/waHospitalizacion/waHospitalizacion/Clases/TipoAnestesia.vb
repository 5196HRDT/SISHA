Imports System.Data.SqlClient
Public Class TipoAnestesia
    Public Function Buscar(ByVal Consulta As String) As Data.DataSet
        Buscar = New Data.DataSet
        Dim daTabla As New SqlDataAdapter(Consulta, CN)
        daTabla.Fill(Buscar)
    End Function
End Class