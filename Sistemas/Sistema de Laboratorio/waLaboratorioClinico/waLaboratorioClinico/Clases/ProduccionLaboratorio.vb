Imports System.Data.SqlClient
Public Class ProduccionLaboratorio

    Dim Cn As New SqlConnection

    Public Sub Grabar(ByVal Fecha As String, ByVal ClasLaboratorio As String, ByVal Descripcion As String, ByVal Area As String, ByVal Especialidad As String, ByVal Origen As String, ByVal Documento As String)
        Dim daTabla As New SqlDataAdapter("ProduccionLaboratorio_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Documento
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub
End Class
