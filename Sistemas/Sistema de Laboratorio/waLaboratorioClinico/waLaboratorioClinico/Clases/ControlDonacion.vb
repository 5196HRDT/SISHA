Imports System.Data.SqlClient
Public Class ControlDonacion
    Dim Cn As New SqlConnection

    Public Sub Grabar(ByVal DNI As String, ByVal Fecha As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ControlDonacion_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdControl As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ControlDonacion_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdControl", SqlDbType.Int).Value = Val(IdControl)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal DNI As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ControlDonacion_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub
End Class
