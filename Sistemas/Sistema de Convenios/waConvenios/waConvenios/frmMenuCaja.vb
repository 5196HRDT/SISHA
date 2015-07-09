Public Class frmMenuCaja

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AperturaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AperturaToolStripMenuItem.Click
        frmApertura.Show()
    End Sub
End Class