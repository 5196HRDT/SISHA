Imports System.Data.SqlClient
Public Class Servicio
    Dim Cn As New SqlConnection

    Public Sub Mantenimiento(ByVal IdServicio As String, ByVal Descripcion As String, ByVal Activo As String, ByVal Oper As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("LaboratorioServicio_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Val(Oper)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Criterio As String, ByVal Oper As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("LaboratorioServicio_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = Criterio
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
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
