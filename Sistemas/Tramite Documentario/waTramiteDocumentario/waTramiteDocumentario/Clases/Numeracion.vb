Imports System.Data.SqlClient
Public Class Numeracion
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdNumeracion As String, ByVal IdTipoDocumento As String, ByVal IdAsignacionCargo As String, ByVal Año As String, ByVal Numero As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("Numeracion_Mantenimiento", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdNumeracion", SqlDbType.Int).Value = Val(IdNumeracion)
        Cm.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = Val(IdTipoDocumento)
        Cm.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        Cm.Parameters.Add("@Año", SqlDbType.Int).Value = Val(Año)
        Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        Cm.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function Correlativo(ByVal IdAsignacionCargo As String, ByVal IdTipoDocumento As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Numeracion_Correlativo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        daTabla.SelectCommand.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = Val(IdTipoDocumento)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Verificar(ByVal Año As String, ByVal IdAsignacionCargo As String, ByVal IdTipoDocumento As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Numeracion_Verificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        daTabla.SelectCommand.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = Val(IdTipoDocumento)
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Val(Año)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Buscar(ByVal Trabajador As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim daTabla As New SqlDataAdapter("Numeracion_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Trabajador", SqlDbType.VarChar).Value = Trabajador
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Actualizar(ByVal IdNumeracion As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("Numeracion_Actualizar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdNumeracion", SqlDbType.Int).Value = Val(IdNumeracion)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
