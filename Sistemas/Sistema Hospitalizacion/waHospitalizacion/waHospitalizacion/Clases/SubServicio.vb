Imports System.Data.SqlClient
Public Class SubServicio
    Public Function Combo(ByVal Piso As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerSerHosPiso", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Piso", SqlDbType.Int).Value = Piso
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GuardarSerHos(IdSerHos As String, IdPiso As String, ByVal Des As String, Bandera As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("GuardarSerHos", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSerHos", SqlDbType.Int).Value = Val(IdSerHos)
        daTabla.SelectCommand.Parameters.Add("@IdPiso", SqlDbType.Int).Value = Val(IdPiso)
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Anular(IdSerHos As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("ServicioHospitalizacion_Anular", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSerHos", SqlDbType.Int).Value = Val(IdSerHos)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
    End Sub
End Class
