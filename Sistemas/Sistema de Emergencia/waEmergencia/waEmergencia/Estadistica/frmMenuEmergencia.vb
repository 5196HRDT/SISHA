Public Class frmMenuEmergencia

    Private Sub IngresoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IngresoToolStripMenuItem.Click
        frmIngresoEmer.Show()
    End Sub

    Private Sub frmMenuEmergencia_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuEmergencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CodigosSISSOATAFOCATToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CodigosSISSOATAFOCATToolStripMenuItem.Click
        frmCodigoSISSOAT.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        frmDuplicadoHoja.Show()
    End Sub
End Class