Public Class frmAnularFinalizacion
    Dim objFicha As New FichaSoat
    Dim CodLocal As String
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosFac(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                    lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                Else
                    lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")

                If dsTabla.Tables(0).Rows(0)("Ruc").ToString.Length <> 11 Then MessageBox.Show("Formato de Ruc no es el Correcto", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                lblCIE.Text = dsTabla.Tables(0).Rows(0)("Diagnostico")
                lblCarta.Text = dsTabla.Tables(0).Rows(0)("Carta")
                btnFinalizar.Enabled = True
                btnFinalizar.Select()
            Else
                MessageBox.Show("No Esta finalizada la FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                lblCIEX.Text = ""
                txtHistoria.Text = ""
                lblCarta.Text = ""
                Limpiar(Me)
                btnFinalizar.Enabled = False
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If MessageBox.Show("Esta seguro de Anular Finalizacion?", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objFicha.AnularFinalizacion(txtHistoria.Text)
        End If
        Limpiar(Me)
        btnFinalizar.Enabled = False
        txtHistoria.Select()
    End Sub

    Private Sub frmAnularFinalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnFinalizar.Enabled = False
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub
End Class