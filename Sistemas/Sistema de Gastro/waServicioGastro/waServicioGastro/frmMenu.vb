Public Class frmMenu

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub InformeGastroToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InformeGastroToolStripMenuItem.Click
        frmAtencionExa.Show()
    End Sub

    Private Sub InformeGastroToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles InformeGastroToolStripMenuItem1.Click
        frmConsulta.Show()
    End Sub
End Class