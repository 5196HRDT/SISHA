Public Class frmMenuCta

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AperturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaToolStripMenuItem.Click
        frmApertura.Show()
    End Sub

    Private Sub IngresoProcedimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoProcedimientosToolStripMenuItem.Click
        frmServicios.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmReporteAtenciones.Show()
    End Sub

    Private Sub AnularAtencionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularAtencionToolStripMenuItem.Click
        frmAnularAtencion.Show()
    End Sub

    Private Sub AtencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionesToolStripMenuItem.Click
        frmRelacionPaciente.Show()
    End Sub

    Private Sub AnularCierreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnularCierreToolStripMenuItem.Click
        frmAnularCierreAten.Show()
    End Sub
End Class