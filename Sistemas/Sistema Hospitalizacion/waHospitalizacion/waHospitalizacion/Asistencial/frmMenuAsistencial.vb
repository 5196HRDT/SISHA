Public Class frmMenuAsistencial

    Private Sub frmMenuAsistencial_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmMenuAsistencial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngreso.Click
        frmIngreso.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmTransferenciaServicio.Show()
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmEgreso.Show()
    End Sub

    Private Sub btnProcEnf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcEnf.Click
        frmProceMed.Show()
    End Sub
End Class