Public Class frmMenuMedico

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AnamnesisToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnamnesisToolStripMenuItem.Click
        frmAnamnesis.Show()
    End Sub

    Private Sub InterconsultasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InterconsultasToolStripMenuItem.Click
        frmInterconsulta.Show()
    End Sub

    Private Sub NotaDeEvoluciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotaDeEvoluciónToolStripMenuItem.Click
        frmNotaEvolucion.Show()
    End Sub

    Private Sub HojaTerapeuticaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HojaTerapeuticaToolStripMenuItem.Click
        frmHojaTerapeutica.Show()
    End Sub

    Private Sub AltaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AltaToolStripMenuItem.Click
        frmAlta.Show()
    End Sub

    Private Sub HistoriaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HistoriaToolStripMenuItem.Click
        frmConsultaExterna.Show()
    End Sub

    Private Sub RadiologiaYEcografiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RadiologiaYEcografiaToolStripMenuItem.Click
        frmRadiologiaEco.Show()
    End Sub

    Private Sub PatologiaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PatologiaToolStripMenuItem.Click
        frmPatologia.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem6.Click
        frmLaboratorio.Show()
    End Sub

    Private Sub ImagenesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImagenesToolStripMenuItem.Click
        frmImagenes.Show()
    End Sub

    Private Sub frmMenuMedico_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuMedico_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "MENU - Dr(a) " & NomMedico
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        frmHistoriaEmergencia.Show()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem9.Click
        frmDuplicadoAlta.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click

    End Sub

    Private Sub CodigoSISSOATAFOCATToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CodigoSISSOATAFOCATToolStripMenuItem.Click
        frmCodigoSISSOAT.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmPapeletaHospitalizacion.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem11.Click
        frmFarmaciaSIS.Show()
    End Sub
End Class