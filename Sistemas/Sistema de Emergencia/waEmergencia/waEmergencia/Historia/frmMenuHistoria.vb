Public Class frmMenuHistoria

    Private Sub ImagenesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub PatologiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub RadiologiaYEcografiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub ToolStripMenuItem6_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub HistoriaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        frmHistoriaEmergencia.Show()
    End Sub

    Private Sub HistoriaToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles HistoriaToolStripMenuItem.Click
        frmConsultaExterna.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmLaboratorio.Show()
    End Sub

    Private Sub RadiologiaYEcografiaToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles RadiologiaYEcografiaToolStripMenuItem.Click
        frmRadiologiaEco.Show()
    End Sub

    Private Sub PatologiaToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles PatologiaToolStripMenuItem.Click
        frmPatologia.Show()
    End Sub

    Private Sub ImagenesToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles ImagenesToolStripMenuItem.Click
        frmImagenes.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        frmInformeEKG.Show()
    End Sub

    Private Sub ConsultaExternaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaExternaToolStripMenuItem.Click
        frmProcedimientoCE.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmElectro.Show()
    End Sub
End Class