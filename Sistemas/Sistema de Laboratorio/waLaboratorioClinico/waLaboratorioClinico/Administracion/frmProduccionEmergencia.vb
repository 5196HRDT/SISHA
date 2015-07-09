Public Class frmProduccionEmergencia
    Dim objReporte As New Laboratorio

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click

    End Sub

    Private Sub frmProduccionEmergencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboMes.Text = DameMes(Date.Now.Month)
        txtAño.Value = Date.Now.Year
    End Sub
End Class