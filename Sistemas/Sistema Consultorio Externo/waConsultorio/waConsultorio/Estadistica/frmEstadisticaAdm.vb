Public Class frmEstadisticaAdm

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmUsuarios.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmCIEMantenimiento.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmMedico.Show()
    End Sub

    Private Sub GenerarHISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarHISToolStripMenuItem.Click
        frmHIS.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmLoteHIS.Show()
    End Sub

    Private Sub NovafisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovafisToolStripMenuItem.Click
        frmNovafis.Show()
    End Sub

    Private Sub RegistroHISToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistroHISToolStripMenuItem.Click
        frmControlEst.Show()
    End Sub

    Private Sub frmEstadisticaAdm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmReporteAtencionConsultorios.Show()
    End Sub

    Private Sub ProcetsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcetsToolStripMenuItem.Click
        frmConsultaProcets.Show()
    End Sub
End Class