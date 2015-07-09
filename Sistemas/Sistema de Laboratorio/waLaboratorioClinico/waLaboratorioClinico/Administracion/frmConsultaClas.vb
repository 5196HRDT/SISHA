Public Class frmConsultaClas
    Dim objItem As New ItemServicio

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim dsVer As New Data.DataSet
        Dim I As Integer
        Dim Fila As ListViewItem

        lvTab.Items.Clear()
        dsVer = objItem.BuscarLabClas(cboClas.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTab.Items.Add(dsVer.Tables(0).Rows(I)("Actividad"))
            Fila.SubItems.Add("Tarifario")
        Next
    End Sub
End Class