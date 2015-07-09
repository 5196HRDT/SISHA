Imports System.Data.OleDb
Public Class AfiliadoNulo
    Dim cnNulo As New OleDbConnection

    Public Function BuscarAnulado(ByVal Contrato As String) As Data.DataSet
        Try
            BuscarAnulado = New Data.DataSet
            Dim dsTabla As New OleDbDataAdapter("Select * From CAfiliados Where NroContratoAfi = '" + Contrato + "'", cnNulo)
            dsTabla.Fill(BuscarAnulado)
        Catch ex As Exception

        End Try
        
    End Function

    Public Sub New()
        Try
            If cnNulo.State = ConnectionState.Closed Then cnNulo.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Unidad Seguros\AfiliadosAnulados.mdb"
            cnNulo.Open()
        Catch ex As Exception

        End Try
    End Sub
End Class
