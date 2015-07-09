Public Class frmMenu

    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub FichaSOATToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichaSOATToolStripMenuItem1.Click
        frmFicha.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmTarifario.Show()
    End Sub

    Private Sub PreliquidaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreliquidaciónToolStripMenuItem.Click
        frmPreliquidacion.Show()
    End Sub

    Private Sub CuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaToolStripMenuItem.Click
        frmCuenta.Show()
    End Sub

    Private Sub FinalizarAtencionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmClasificador.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmFichaEpi.show()
    End Sub

    Private Sub PacientesXAseguradoraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacientesXAseguradoraToolStripMenuItem.Click
        frmRepPacAseg.Show()
    End Sub

    Private Sub DevolucionExpedienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionExpedienteToolStripMenuItem.Click
        frmDevolucion.Show()
    End Sub

    Private Sub CancelarDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCancelarDoc.Show()
    End Sub

    Private Sub FacturarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmFacturarDoc.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        frmAseguradora.Show()
    End Sub

    Private Sub AnularFinalizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularFinalizacionToolStripMenuItem.Click
        frmAnularFinalizacion.Show()
    End Sub

    Private Sub AtencionPacienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtencionPacienteToolStripMenuItem.Click
        frmRepAtencionPac.Show()
    End Sub

    Private Sub EstadoDeExpedientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDeExpedientesToolStripMenuItem.Click
        frmRepEstadoExp.Show()
    End Sub

    Private Sub BancoSangreHospitalizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BancoSangreHospitalizacionToolStripMenuItem.Click
        frmBancoSangre.Show()
    End Sub
End Class
