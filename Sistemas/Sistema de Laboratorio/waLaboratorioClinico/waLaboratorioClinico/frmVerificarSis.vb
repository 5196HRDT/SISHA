Public Class frmVerificarSis
    Dim objSIS As New SIS
    Dim objProduccion As New ProduccionLaboratorio

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        lvTab.Items.Clear()
        lblTotal.Text = 0
        If e.KeyCode = Keys.Enter Then
            Dim dsTab As New Data.DataSet
            dsTab = objSIS.Laboratorio(cboLote.Text, txtNumero.Text)
            If dsTab.Tables(0).Rows.Count > 0 Then
                dtpFecha.Value = dsTab.Tables(0).Rows(0)("FechaAtencion")
                lblHistoria.Text = dsTab.Tables(0).Rows(0)("Historia")
                lblHistoria.Tag = dsTab.Tables(0).Rows(0)("IdSIS")
                lblPaciente.Text = dsTab.Tables(0).Rows(0)("Apaterno") & " " & dsTab.Tables(0).Rows(0)("Amaterno") & " " & dsTab.Tables(0).Rows(0)("Nombres")


                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsTab.Tables(0).Rows.Count - 1
                    Fila = lvTab.Items.Add(dsTab.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTab.Tables(0).Rows(I)("Precio")), "#0.00"))
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cantidad"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTab.Tables(0).Rows(I)("Importe")), "#0.00"))
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("ClasLaboratorio"))
                    lblTotal.Text = Val(lblTotal.Text) + Val(dsTab.Tables(0).Rows(I)("Importe"))
                Next
                cboArea.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub cboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLote.KeyDown
        If e.KeyCode = Keys.Enter And cboLote.Text <> "" Then txtNumero.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lvTab.Items.Clear()
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        txtNumero.Select()
        lblTotal.Text = "0.00"
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objSIS.GrabarArea(lblHistoria.Tag, cboArea.Text)
            Dim I As Integer
            Dim Fecha As String = Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy")
            For I = 0 To lvTab.Items.Count - 1
                objProduccion.Grabar(Fecha, lvTab.Items(I).SubItems(4).Text, lvTab.Items(I).SubItems(0).Text, "SIS", cboArea.Text, "SIS", cboLote.Text & "-" & Microsoft.VisualBasic.Right("0000000" & txtNumero.Text, 7))
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub frmVerificarSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class