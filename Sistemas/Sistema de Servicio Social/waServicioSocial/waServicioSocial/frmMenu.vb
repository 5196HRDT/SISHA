Public Class frmMenu
    Private Sub ConsultoriosExternosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsultoriosExternosToolStripMenuItem.Click
        frmConsultorioExterno.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class