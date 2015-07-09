Imports System.Data.SqlClient
Public Class FichaSOAT
    Dim Cn As New SqlConnection

    Public Function BuscarDatosPreNP(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarDatosPreNP", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.VarChar).Value = IdSoat
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
