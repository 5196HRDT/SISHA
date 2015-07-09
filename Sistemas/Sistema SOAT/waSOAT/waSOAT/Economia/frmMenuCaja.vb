Public Class frmMenuCaja
    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub frmMenuCaja_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AperturaSOATToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AperturaSOATToolStripMenuItem.Click
        frmFicha.Show()
    End Sub
End Class