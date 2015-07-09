Public Class frmLaboratorioSOAT
    Dim objFicha As New FichaSOAT
    Dim CodLocal As String

    Private Sub txtPre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtPre.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPreNP(txtPre.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
                lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If lblFecha.Text <> "" Then
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")
            Else
                MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblPoliza.Text = ""
                lblPlaca.Text = ""
                lblEdad.Text = ""
                lblContratante.Text = ""
                lblAseguradora.Text = ""
                lblCIE.Text = ""
                txtHistoria.Text = ""
                txtPre.Select()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmLaboratorioSOAT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnGrabar.Enabled = False
        btnImprimir.Enabled = False
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click

    End Sub
End Class