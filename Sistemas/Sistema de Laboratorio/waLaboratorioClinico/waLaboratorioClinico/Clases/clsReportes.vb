Imports System.Data.SqlClient
Public Class clsReportes
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function ReporteCEDoc(ByVal Año As String, ByVal Mes As String, ByVal Tipo As String, ByVal Oper As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Laboratorio_ReporteCEDoc", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
