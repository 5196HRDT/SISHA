Public Class frmMenuCupos

    Private Sub frmMenuCupos_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuCupos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CitasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CitasToolStripMenuItem.Click
        frmCitas.Show()
    End Sub
End Class