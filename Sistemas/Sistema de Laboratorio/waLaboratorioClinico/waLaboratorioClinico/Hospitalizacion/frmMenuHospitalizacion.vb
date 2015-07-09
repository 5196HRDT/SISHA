Public Class frmMenuHospitalizacion

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ResultadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultadosToolStripMenuItem.Click
        frmResultadoHosp.Show()
    End Sub

    Private Sub SolicitudDeExámenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeExámenesToolStripMenuItem.Click
        frmSolicitud.Show()
    End Sub
End Class