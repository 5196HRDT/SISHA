Public Class frmMenuAtencion

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ListadoDeMuestrasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListadoDeMuestrasToolStripMenuItem.Click
        frmListaAtencionEmergencia.Show()
    End Sub

    Private Sub ResultadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResultadosToolStripMenuItem.Click
        frmResultadosEmergencia.Show()
    End Sub

    Private Sub frmMenuAtencion_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuAtencion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class