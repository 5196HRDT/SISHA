Public Class frmFichaEpi
    Dim objHistoria As New Historia
    Dim objFicha As New FichaSoat
    Dim CodLocal As String
    Dim Oper As String

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                Dim dsFicha As New Data.DataSet
                dsFicha = objFicha.BuscarFicha(txtHistoria.Text.Trim)
                If dsFicha.Tables(0).Rows.Count = 0 Then
                    lblPaciente.Text = dsTabla.Tables(0).Rows(0)("Apaterno").ToString & " " & dsTabla.Tables(0).Rows(0)("Amaterno").ToString & " " & dsTabla.Tables(0).Rows(0)("Nombres").ToString
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento").ToString
                    MessageBox.Show("No Existe aperturada una ficha para este paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar(Me)
                Else
                    MessageBox.Show("Existe aperturada una ficha para este paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Oper = 2
                    CodLocal = dsFicha.Tables(0).Rows(0)("IdSoat")
                    lblPaciente.Text = dsTabla.Tables(0).Rows(0)("Apaterno").ToString & " " & dsTabla.Tables(0).Rows(0)("Amaterno").ToString & " " & dsTabla.Tables(0).Rows(0)("Nombres").ToString
                    lblFecha.Text = dsFicha.Tables(0).Rows(0)("FechaNac")
                    lblDireccion.Text = dsTabla.Tables(0).Rows(0)("Direccion")
                    lblDNI.Text = dsTabla.Tables(0).Rows(0)("Doc_Identidad")
                    lblLugarNac.Text = dsTabla.Tables(0).Rows(0)("LNacimiento")
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                    lblSexo.Text = dsFicha.Tables(0).Rows(0)("Sexo")
                    dtpFecha.Value = dsFicha.Tables(0).Rows(0)("FechaRegistro")
                    dtpFecAcc.Text = dsFicha.Tables(0).Rows(0)("FechaAccidente")
                    txtPlaca.Text = dsFicha.Tables(0).Rows(0)("Placa")
                    txtPoliza.Text = dsFicha.Tables(0).Rows(0)("Poliza")
                    'txtContratante.Text = dsFicha.Tables(0).Rows(0)("Contratante")
                    'cboAseguradora.Text = dsFicha.Tables(0).Rows(0)("Aseguradora")
                    'cboClase.Text = dsFicha.Tables(0).Rows(0)("ClaseVehiculo")
                    'cboTipo.Text = dsFicha.Tables(0).Rows(0)("TipoAccidente")
                    'cboEspecialidad.Text = dsFicha.Tables(0).Rows(0)("Especialidad")
                    'cboSubEspecialidad.Text = dsFicha.Tables(0).Rows(0)("SubEspecialidad")
                    'txtCIE1.Text = dsFicha.Tables(0).Rows(0)("CIE1")
                    'txtDes1.Text = dsFicha.Tables(0).Rows(0)("DesCIE1")
                    'txtCIE2.Text = dsFicha.Tables(0).Rows(0)("CIE2")
                    'txtDes2.Text = dsFicha.Tables(0).Rows(0)("DesCIE2")
                    'txtCIE3.Text = dsFicha.Tables(0).Rows(0)("CIE3")
                    'txtDes3.Text = dsFicha.Tables(0).Rows(0)("DesCIE3")
                    'txtCIE4.Text = dsFicha.Tables(0).Rows(0)("CIE4")
                    'txtDes4.Text = dsFicha.Tables(0).Rows(0)("DesCIE4")
                    'cboEstado.Text = dsFicha.Tables(0).Rows(0)("Estado")
                    'txtCarta.Text = dsFicha.Tables(0).Rows(0)("Carta")
                    'txtMontoFarmacia.Text = dsFicha.Tables(0).Rows(0)("MontoFarmacia")
                    'txtDiagnostico.Text = dsFicha.Tables(0).Rows(0)("Diagnostico")
                    dtpFecAcc.Select()
                End If
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmFichaEpi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboCondicionAlta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondicionAlta.SelectedIndexChanged
        If cboCondicionAlta.Text <> "REFERIDO" Then txtReferencia.Enabled = True Else txtReferencia.Enabled = False
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los datos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        End If
    End Sub
End Class