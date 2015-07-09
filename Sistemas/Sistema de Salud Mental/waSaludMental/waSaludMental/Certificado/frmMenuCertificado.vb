Public Class frmMenuCertificado

    Private Sub CertificadoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CertificadoToolStripMenuItem.Click
        frmCertificadoArmTra.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub frmMenuCertificado_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuCertificado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class