Public Class frmMenu

    Private Sub ReferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferenciaToolStripMenuItem.Click
        frmReferencia.Show()
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CausasMasFrecuentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CausasMasFrecuentesToolStripMenuItem.Click
        frmCausas.Show()
    End Sub

    Private Sub ConsolidadoMensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidadoMensualToolStripMenuItem.Click
        frmConsolidadoMenR.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmCausasC.Show()
    End Sub

    Private Sub ConsolidadoAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidadoAnualToolStripMenuItem.Click
        frmConsolidadoCR.Show()
    End Sub

    Private Sub ConsolidadoMensualContraReferenciaIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolidadoMensualContraReferenciaIToolStripMenuItem.Click
        frmConsolidadoCR1.Show()
    End Sub

    Private Sub ReferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferenciasToolStripMenuItem.Click

    End Sub
End Class