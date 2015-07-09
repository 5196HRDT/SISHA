Public Class frmMenuCentral

    Private Sub ListadoDeMuestrasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListadoDeMuestrasToolStripMenuItem.Click
        frmMuestras.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub frmMenuCentral_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuCentral_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ResultadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResultadosToolStripMenuItem.Click
        frmResultadoCentral.Show()
    End Sub

    Private Sub ActualizarDatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarDatosToolStripMenuItem.Click
        frmActualizarDatosCE.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmTamizajeSIS.Show()
    End Sub
End Class