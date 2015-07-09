Public Class MenuUCI
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaToolStripMenuItem.Click
        frmControlCuentaSIS.Show()
    End Sub

    Private Sub ProcedimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedimientosToolStripMenuItem.Click
        frmProcedimientos.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If Microsoft.VisualBasic.Left(UsuarioSistema, 4) <> "UCIE" Then frmDigMedUCI.Show() Else MessageBox.Show("Usuario no tiene privilegios para realizar esta operacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class