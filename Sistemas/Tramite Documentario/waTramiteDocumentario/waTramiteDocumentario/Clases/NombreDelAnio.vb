Imports System.Data.SqlClient
Public Class NombreDelAnio
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdGrupo As String, ByVal Anio As String, ByVal Detalle As String, ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("NombreDelAnio_Mantenimiento", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdAnio", SqlDbType.Int).Value = Val(IdGrupo)
        Cm.Parameters.Add("@Anio", SqlDbType.VarChar).Value = Anio
        Cm.Parameters.Add("@Detalle", SqlDbType.VarChar).Value = Detalle
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
        Dim daTabla As New SqlDataAdapter("NombreDelAnio_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Detalle", SqlDbType.VarChar).Value = Descripcion
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Nombre(ByVal Año As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("NombreDelAnio_Nombre", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
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