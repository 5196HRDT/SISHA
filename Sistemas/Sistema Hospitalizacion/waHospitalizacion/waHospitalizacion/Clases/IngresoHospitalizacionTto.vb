Imports System.Data.SqlClient
Public Class IngresoHospitalizacionTto
    Public Sub Grabar(ByVal IdIngreso As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal Nombre As String, ByVal Dosis As String, ByVal Via As String, ByVal Frecuencia As String, ByVal Dias As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionTto_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre
        daTabla.SelectCommand.Parameters.Add("@Dosis", SqlDbType.VarChar).Value = Dosis
        daTabla.SelectCommand.Parameters.Add("@Via", SqlDbType.VarChar).Value = Via
        daTabla.SelectCommand.Parameters.Add("@Frecuencia", SqlDbType.VarChar).Value = Frecuencia
        daTabla.SelectCommand.Parameters.Add("@Dias", SqlDbType.VarChar).Value = Dias
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdIngreso As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionTto_Eliminar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdIngreso As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacionTto_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
