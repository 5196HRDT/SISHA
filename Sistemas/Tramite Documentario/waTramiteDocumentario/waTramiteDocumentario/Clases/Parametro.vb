Imports System.Data.SqlClient
Public Class Parametro
    Dim Cm As SqlCommand

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Parametro_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
