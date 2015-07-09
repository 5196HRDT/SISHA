Imports System.Data.SqlClient
Public Class IngresoHospitalizacionResumen
    Public Sub Grabar(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal Anamnesis As String, ByVal ExamenClinico As String, ByVal ExamenesAuxiliares As String, ByVal Evolucion As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionResumen_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Anamnesis", SqlDbType.VarChar).Value = Anamnesis
        daTabla.SelectCommand.Parameters.Add("@ExamenClinico", SqlDbType.VarChar).Value = ExamenClinico
        daTabla.SelectCommand.Parameters.Add("@ExamenesAuxiliares", SqlDbType.VarChar).Value = ExamenesAuxiliares
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdIngreso As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionResumen_Eliminar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionResumen_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
