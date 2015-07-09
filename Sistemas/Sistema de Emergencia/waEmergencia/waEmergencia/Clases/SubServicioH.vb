Imports System.Data.SqlClient
Public Class SubServicioH
    Dim Cn As New SqlConnection

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub

    Public Function Combo(ByVal Piso As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerSerHosPiso", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Piso", SqlDbType.Int).Value = Piso
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GuardarSerHos(IdSerHos As String, IdPiso As String, ByVal Des As String, Bandera As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("GuardarSerHos", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSerHos", SqlDbType.Int).Value = Val(IdSerHos)
        daTabla.SelectCommand.Parameters.Add("@IdPiso", SqlDbType.Int).Value = Val(IdPiso)
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Anular(IdSerHos As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("ServicioHospitalizacion_Anular", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSerHos", SqlDbType.Int).Value = Val(IdSerHos)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
    End Sub
End Class
