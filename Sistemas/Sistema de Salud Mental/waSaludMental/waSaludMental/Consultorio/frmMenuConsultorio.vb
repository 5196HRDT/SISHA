Public Class frmMenuConsultorio

    Private Sub frmMenuConsultorio_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuConsultorio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub FormatoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FormatoToolStripMenuItem.Click
        frmFormato.Show()
    End Sub

    Private Sub InformeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InformeToolStripMenuItem.Click
        frmInforme.Show()
    End Sub

    Private Sub UsoDeArmasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UsoDeArmasToolStripMenuItem.Click
        frmCertificadoArmTra.Show()
    End Sub
End Class