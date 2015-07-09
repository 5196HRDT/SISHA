Imports System.Data.SqlClient
Public Class CIE10
    Public Function Buscar(ByVal Valor As String, ByVal Oper As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Valor
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Mantenimiento(ByVal Codigo As String, ByVal Descripcion As String, ByVal Clase2 As String, ByVal Clase1 As String, ByVal Sexo As String, ByVal MinEdad As String, ByVal MinTipo As String, ByVal MaxEdad As String, ByVal MaxTipo As String, ByVal Estado As String, ByVal Definitivo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Clase2", SqlDbType.VarChar).Value = Clase2
        daTabla.SelectCommand.Parameters.Add("@Clase1", SqlDbType.VarChar).Value = Clase1
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@MinEdad", SqlDbType.VarChar).Value = MinEdad
        daTabla.SelectCommand.Parameters.Add("@MinTipo", SqlDbType.VarChar).Value = MinTipo
        daTabla.SelectCommand.Parameters.Add("@MaxEdad", SqlDbType.VarChar).Value = MaxEdad
        daTabla.SelectCommand.Parameters.Add("@MaxTipo", SqlDbType.VarChar).Value = MaxTipo
        daTabla.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        daTabla.SelectCommand.Parameters.Add("@Definitivo", SqlDbType.VarChar).Value = Definitivo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
