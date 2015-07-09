Imports MySql.Data.MySqlClient
Public Class Navigate
    Dim Cx As New MySqlConnection

    Public Sub ejecutar(ByVal sql1 As String, ByVal msbien As String, ByVal msmal As String)
        Dim comandos As New MySqlCommand
        Try
            comandos.Connection = Cx
            comandos.CommandText = sql1
            comandos.ExecuteNonQuery()
            'MessageBox.Show(msbien)
        Catch ex As MySqlException
            'MessageBox.Show(ex.Message)
            'MessageBox.Show(sql1)
        End Try
    End Sub

    Public Function Buscar(ByVal sql1 As String) As Data.DataSet
        Do While Cx.State = ConnectionState.Closed
            Cx.Open()
        Loop
        Dim daTabla As New MySqlDataAdapter(sql1, Cx)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub New()
        Cx.ConnectionString = "server=localhost;User Id=root;Persist Security Info=True;database=Novafis_2015;pwd=root"
        If Cx.State = ConnectionState.Closed Then
            Try
                Cx.Open()
            Catch ex As Exception
                'MessageBox.Show ("No se encuentra regitrada la basse de datos NOVAFIS", "Mensaje de iNFORMA"
            End Try
        End If
    End Sub
End Class
