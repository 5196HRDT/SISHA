Public Class frmMenuMedico

    Private Sub frmMenuMedico_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        frmEgreso.Show()
    End Sub

    Private Sub btnProcedimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcedimientos.Click
        frmProceMed.Show()
    End Sub

    Private Sub btnEpicrisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEpicrisis.Click
        frmEpicrisis.Show()
    End Sub

    Private Sub btnMedSIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedSIS.Click
        frmRecetaSis.Show()
    End Sub
End Class