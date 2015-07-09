Imports System.Data.SqlClient
Public Class Archivador
    Public Sub Mantenedor(ByVal IdArchivador As String, ByVal IdAsignacionCargo As String, ByVal Descripcion As String, ByVal Periodo As String, ByVal Activo As String,
                          ByVal Oper As String)
        Dim oDataAdapter As New SqlDataAdapter("Archivador_Mantenimiento", Cn)
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@IdArchivador", SqlDbType.Int).Value = Val(IdArchivador)
        oDataAdapter.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = Val(IdAsignacionCargo)
        oDataAdapter.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        oDataAdapter.SelectCommand.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = Periodo
        oDataAdapter.SelectCommand.Parameters.Add("@Activo", SqlDbType.Char).Value = Activo
        oDataAdapter.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        oDataAdapter.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Dim oDataAdapter As New SqlDataAdapter("Archivador_Buscar", Cn)
        Dim oDataSet As New Data.DataSet
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        oDataAdapter.SelectCommand.ExecuteNonQuery()
        oDataAdapter.Fill(oDataSet)
        Return oDataSet
    End Function

    Public Function Combo(ByVal IdAsignacionCargo As String) As Data.DataSet
        Dim oDataAdapter As New SqlDataAdapter("Archivador_Mostrar", Cn)
        Dim oDataSet As New Data.DataSet
        oDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        oDataAdapter.SelectCommand.Parameters.Add("@IdAsignacionCargo", SqlDbType.Int).Value = IdAsignacionCargo
        oDataAdapter.SelectCommand.ExecuteNonQuery()
        oDataAdapter.Fill(oDataSet)
        Return oDataSet
    End Function
End Class
