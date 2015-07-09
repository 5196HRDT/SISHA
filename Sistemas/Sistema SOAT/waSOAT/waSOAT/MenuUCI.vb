Public Class MenuUCI

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaToolStripMenuItem.Click
        frmCuenta.Show()
    End Sub

    Private Sub ProcedimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedimientosToolStripMenuItem.Click
        frmPreliquidacion.Show()
    End Sub
End Class