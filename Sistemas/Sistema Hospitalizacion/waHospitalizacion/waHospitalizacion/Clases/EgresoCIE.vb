Imports System.Data.SqlClient
Public Class EgresoCIE
    Public Sub Grabar(ByVal IdEgreso As String, ByVal CIE As String, ByVal Descripcion As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacionCIE_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdEgreso)
        daTabla.SelectCommand.Parameters.Add("@CIE", SqlDbType.VarChar).Value = CIE
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdEgreso As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacionCIE_Eliminar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdEgreso)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdEgreso As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EgresoHospitalizacionCIE_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdEgreso)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
