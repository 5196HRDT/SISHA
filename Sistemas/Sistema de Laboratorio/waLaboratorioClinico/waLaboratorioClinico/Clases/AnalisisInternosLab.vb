Imports System.Data.SqlClient
Public Class AnalisisInternosLab

    Dim Cn As New SqlConnection

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("AnalisisInternoLab_Buscar", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Mantenimiento(ByVal IdAnalisis As String, ByVal Descripcion As String, ByVal ClasLaboratorio As String, ByVal Oper As String)
        Dim daTabla As New SqlDataAdapter("AnalisisInternosLab_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdAnalisis", SqlDbType.Int).Value = Val(IdAnalisis)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub
End Class
