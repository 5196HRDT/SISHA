Public Class MenuEconomia

    Private Sub FacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturarToolStripMenuItem.Click
        frmFacturarDoc.Show()
    End Sub

    Private Sub CancelarFacturacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarFacturacionToolStripMenuItem.Click
        frmCancelarDoc.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmAnularFactura.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmFacturaAnulada.Show()
    End Sub

    Private Sub PendientePagoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PendientePagoToolStripMenuItem.Click
        frmReportePenPago.Show()
    End Sub
End Class