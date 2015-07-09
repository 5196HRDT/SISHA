Public Class frmActualizarDatosCE
    Dim objComprobante As New clsComprobanteVta

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter And txtSerie.Text <> "" Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerie.LostFocus
        txtSerie.Text = Microsoft.VisualBasic.Right("000" & txtSerie.Text, 3)
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter And txtNumero.Text <> "" And txtSerie.Text <> "" Then
            lvDoc.Items.Clear()
            Dim dsVer As New DataSet
            Dim dsDet As New DataSet
            Dim IdComprobante As Integer
            dsVer = objComprobante.BuscarNumero(txtSerie.Text, txtNumero.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                IdComprobante = dsVer.Tables(0).Rows(0)("IdComprobante")
                dsDet = objComprobante.BuscarDetCompVta(IdComprobante)
                If dsDet.Tables(0).Rows.Count > 0 Then
                    Dim I As Integer
                    Dim Fila As ListViewItem
                    For I = 0 To dsDet.Tables(0).Rows.Count - 1
                        Fila = lvDoc.Items.Add(dsDet.Tables(0).Rows(I)("IdSerItem"))
                        Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Cantidad"))
                        Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                    Next
                End If
            Else
                MessageBox.Show("Comprobante no existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lvDoc.Items.Clear()
                txtSerie.Text = ""
                txtNumero.Text = ""
                txtSerie.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub
End Class