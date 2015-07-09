Public Class frmMenuTramite

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SalirToolStripMenuItem_Disposed(sender As Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Disposed
        Application.Exit()
    End Sub

    Private Sub CertificadoArmasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CertificadoArmasToolStripMenuItem.Click
        frmCertificadoTra.Show()
    End Sub
End Class