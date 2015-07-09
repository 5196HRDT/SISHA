Public Class frmEstadistica

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmConsultaExt.Show()
    End Sub

    Private Sub NovafisToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NovafisToolStripMenuItem.Click
        frmNovafis.Show()
    End Sub

    Private Sub RegistroHISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroHISToolStripMenuItem.Click
        frmConRegistroHIS.Show()
    End Sub

    Private Sub ConsultasToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ConsultasToolStripMenuItem1.Click
        frmHIS.Show()
    End Sub

    Private Sub frmEstadistica_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmEstadistica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReporteAtencionConsultoriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteAtencionConsultoriosToolStripMenuItem.Click
        frmReporteAtencionConsultorios.Show()
    End Sub

    Private Sub ProcetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcetsToolStripMenuItem.Click
        frmConsultaProcets.Show()
    End Sub
End Class