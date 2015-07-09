Imports System.Data.SqlClient
Public Class EspecialidadH
    Dim Cn As New SqlConnection

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub

    Public Sub Mantenimiento(IdEspecialidad As String, ByVal IdSubServicio As String, Descripcion As String, Bandera As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EspecialidadHosp_Mantenimiento", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEspecialidad", SqlDbType.Int).Value = Val(IdEspecialidad)
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Bandera", SqlDbType.Char).Value = Bandera
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdSubServicio As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("EspecialidadHosp_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSubServicio", SqlDbType.Int).Value = Val(IdSubServicio)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
