Imports System.Data.SqlClient
Public Class Servicio
    Public Sub Mantenimiento(ByVal IdServicio As String, ByVal Descripcion As String, ByVal Abreviatura As String, ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Servicio_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Abreviatura", SqlDbType.VarChar).Value = Abreviatura
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Oper As String, ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Servicio_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
