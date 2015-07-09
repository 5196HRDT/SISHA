Imports System.Data.SqlClient
Public Class tempLabPro
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub Grabar(ByVal ClasLaboratorio As String, ByVal Area As String, ByVal Especialidad As String, ByVal Descripcion As String, ByVal Total As String)
        Dim daTabla As New SqlDataAdapter("tempLabPro_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Total", SqlDbType.Int).Value = Val(Total)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal ClasLaboratorio As String, ByVal Area As String, ByVal Especialidad As String, ByVal Descripcion As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("tempLabPro_Buscar", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Eliminar()
        Dim daTabla As New SqlDataAdapter("tempLabPro_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
