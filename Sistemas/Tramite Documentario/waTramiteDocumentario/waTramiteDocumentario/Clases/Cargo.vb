Imports System.Data.SqlClient
Public Class Cargo
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdCargo As String, ByVal Descripcion As String, IdNivelCargo As String, ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("Cargo_Mantenimiento", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdCargo", SqlDbType.Int).Value = Val(IdCargo)
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@IdNivelCargo", SqlDbType.Int).Value = Val(IdNivelCargo)
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Cargo_Buscar", Cn)
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

    Public Function Combo() As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Cargo_Combo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
