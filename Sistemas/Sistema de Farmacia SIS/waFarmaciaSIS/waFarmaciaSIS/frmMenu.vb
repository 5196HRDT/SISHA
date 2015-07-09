Public Class frmMenu

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AtencionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AtencionToolStripMenuItem.Click
        frmAtencion.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmDevolucionSIS.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmDuplicadoAtencion.Show()
    End Sub

    Private Sub NuevosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevosToolStripMenuItem.Click
        frmProducto.Show()
    End Sub
End Class