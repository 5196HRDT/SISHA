Public Class frmBolsaColectoraSangre
    Dim objSis As New SIS

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim dsVer As New DataSet
        dsVer = objSis.CantBolsaColectora(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        If dsVer.Tables(0).Rows.Count > 0 Then
            lblTotal.Text = dsVer.Tables(0).Rows(0)("Total")
        Else
            lblTotal.Text = "0"
        End If
    End Sub
End Class