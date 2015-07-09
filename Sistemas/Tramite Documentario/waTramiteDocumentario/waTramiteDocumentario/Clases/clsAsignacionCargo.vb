Imports System.Data.SqlClient
Public Class clsAsignacionCargo
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdAsignacionCargo As String, ByVal IdTrabajador As String, ByVal IdServiArea As String, ByVal IdCargo As String,
                             ByVal Activo As String, ByVal Oper As String)
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim Cm As New SqlCommand("AsignacionCargo_Mantenimiento", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        Cm.Parameters.Add("@IdTrabajador", SqlDbType.Int).Value = Val(IdTrabajador)
        Cm.Parameters.Add("@IdServiArea", SqlDbType.Int).Value = Val(IdServiArea)
        Cm.Parameters.Add("@IdCargo", SqlDbType.Int).Value = Val(IdCargo)
        Cm.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        Cm.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarPorNombre(ByVal Nombre As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim oDataAdapter As New SqlDataAdapter("AsignacionCargo_BuscarPorNombre", Cn)
        Dim oDataSet As New Data.DataSet
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombre
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        oDataAdapter.SelectCommand.ExecuteNonQuery()
        oDataAdapter.Fill(oDataSet)
        Return oDataSet
    End Function

    Public Function CargoPorTrabajador(ByVal IdTrabajador As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        Dim oDataAdapter As New SqlDataAdapter("AsignacionCargo_MostrarCargoPorTrabajador", Cn)
        Dim oDataSet As New Data.DataSet
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@IdTrabajador", SqlDbType.Int).Value = IdTrabajador
        Do While Cn.State = ConnectionState.Closed
            AbrirConexion()
        Loop
        oDataAdapter.SelectCommand.ExecuteNonQuery()
        oDataAdapter.Fill(oDataSet)
        Return oDataSet
    End Function

    'Public Sub New()
    '    Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=TramiteDocumentario;UID=SA;PWD=hrdt2003"
    '    Cn.Open()
    'End Sub
End Class
