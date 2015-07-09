Public Class frmMenuCuenta

    Private Sub CuentaEmergenciaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CuentaEmergenciaToolStripMenuItem.Click
        frmCuentaPaciente.Show()
    End Sub

    Private Sub frmMenuCuenta_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuCuenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class