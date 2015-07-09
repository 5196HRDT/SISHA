Public Class frmMenu
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub TarifarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifarioToolStripMenuItem.Click
        frmTarifario.Show()
    End Sub

    Private Sub AtencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionesToolStripMenuItem.Click
        frmRelacionPaciente.Show()
    End Sub

    Private Sub FacturacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturacionToolStripMenuItem1.Click
        frmReporteFacturacion.Show()
    End Sub

    Private Sub DevolucionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem1.Click
        frmReporteDevolucion.Show()
    End Sub

    Private Sub AtencionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionToolStripMenuItem1.Click
        frmFacturacion.Show()
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem.Click
        frmDevolucion.Show()
    End Sub

    Private Sub AperturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaToolStripMenuItem.Click
        frmApertura.Show()
    End Sub

    Private Sub IngresoProcedimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoProcedimientosToolStripMenuItem.Click
        frmServicios.Show()
    End Sub

    Private Sub LiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLiquidacion.Show()
    End Sub

    Private Sub AnularAtencionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularAtencionToolStripMenuItem.Click
        frmAnularAtencion.Show()
    End Sub

    Private Sub AnularCierreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularCierreToolStripMenuItem.Click
        frmAnularCierreAten.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmReporteAtenciones.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmAnularFactura.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmFacturaAnulada.Show()
    End Sub
End Class