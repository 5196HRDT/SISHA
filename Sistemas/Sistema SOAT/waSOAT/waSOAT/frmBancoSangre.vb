Public Class frmBancoSangre
    Dim objHistoria As New Historia
    Dim objEmergencia As New clsEmergencia
    Dim objHospitalizacion As New clsHospitalizacion
    Dim objBancoSangre As New clsBancoSangre

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmBancoSangre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        cboOrigen.Text = "HOSPITALIZACION"
        Limpiar(Me)
        lblPaciente.Text = ""
        lblDepartamento.Text = ""
        lblServicio.Text = ""
        lblMedico.Text = ""
        lblPrestamoP.Text = "0"
        lblPrestamoS.Text = "0"
        lblPrestamoQ.Text = "0"
        lblDevolucionP.Text = "0"
        lblDevolucionS.Text = "0"
        lblDevolucionQ.Text = "0"
        lblSaldoP.Text = "0"
        lblSaldoS.Text = "0"
        lblSaldoQ.Text = "0"
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsIngreso As New DataSet

            If cboOrigen.Text = "EMERGENCIA" Then dsIngreso = objEmergencia.VerificarEmergenciaIng(txtHistoria.Text)
            If cboOrigen.Text = "HOSPITALIZACION" Then dsIngreso = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)

            If dsIngreso.Tables(0).Rows.Count > 0 Then
                Dim dsH As New DataSet
                dsH = objHistoria.BuscarNumero(txtHistoria.Text)
                If dsH.Tables(0).Rows.Count > 0 Then
                    lblPaciente.Text = dsH.Tables(0).Rows(0)("Apaterno") & " " & dsH.Tables(0).Rows(0)("Amaterno") & " " & dsH.Tables(0).Rows(0)("Nombres")
                Else
                    MessageBox.Show("Número de Historia Clínica no existen", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnCancelar_Click(sender, e)
                End If


                Dim dsBS As New DataSet
                If cboOrigen.Text = "HOSPITALIZACION" Then
                    dsBS = objBancoSangre.ControlSangreH(dsIngreso.Tables(0).Rows(0)("IdHospitalizacion"))
                    lblDepartamento.Text = dsIngreso.Tables(0).Rows(0)("Piso")
                    lblServicio.Text = dsIngreso.Tables(0).Rows(0)("Servicio")
                    lblMedico.Text = dsIngreso.Tables(0).Rows(0)("Medico")

                    If dsBS.Tables(0).Rows.Count > 0 Then
                        lblPrestamoS.Text = dsBS.Tables(0).Rows(0)("CantidadDevolver")
                        lblDevolucionS.Text = dsBS.Tables(0).Rows(0)("CantidadDevuelta")
                        lblPrestamoP.Text = dsBS.Tables(0).Rows(0)("PlasmaDevolver")
                        lblDevolucionP.Text = dsBS.Tables(0).Rows(0)("PlasmaDevuelta")
                        lblPrestamoQ.Text = dsBS.Tables(0).Rows(0)("PlaquetaDevolver")
                        lblDevolucionQ.Text = dsBS.Tables(0).Rows(0)("PlaquetaDevuelta")
                    End If
                    lblSaldoS.Text = Val(lblPrestamoS.Text) - Val(lblDevolucionS.Text)
                    lblSaldoP.Text = Val(lblPrestamoP.Text) - Val(lblDevolucionP.Text)
                    lblSaldoQ.Text = Val(lblPrestamoQ.Text) - Val(lblDevolucionQ.Text)
                    'lblObservaciones.Text = dsBS.Tables(0).Rows(0)("Observaciones").ToString
                Else
                    dsBS = objBancoSangre.ControlSangreH(dsIngreso.Tables(0).Rows(0)("IdIngreso"))
                    lblDepartamento.Text = dsIngreso.Tables(0).Rows(0)("Especialidad")
                    lblServicio.Text = ""
                    lblMedico.Text = dsIngreso.Tables(0).Rows(0)("Medico")

                    If dsBS.Tables(0).Rows.Count > 0 Then
                        lblPrestamoS.Text = dsBS.Tables(0).Rows(0)("CantidadDevolver")
                        lblDevolucionS.Text = dsBS.Tables(0).Rows(0)("CantidadDevuelta")
                        lblPrestamoP.Text = dsBS.Tables(0).Rows(0)("PlasmaDevolver")
                        lblDevolucionP.Text = dsBS.Tables(0).Rows(0)("PlasmaDevuelta")
                        lblPrestamoQ.Text = dsBS.Tables(0).Rows(0)("PlaquetaDevolver")
                        lblDevolucionQ.Text = dsBS.Tables(0).Rows(0)("PlaquetaDevuelta")
                    End If
                    lblSaldoS.Text = Val(lblPrestamoS.Text) - Val(lblDevolucionS.Text)
                    lblSaldoP.Text = Val(lblPrestamoP.Text) - Val(lblDevolucionP.Text)
                    lblSaldoQ.Text = Val(lblPrestamoQ.Text) - Val(lblDevolucionQ.Text)
                    lblObservaciones.Text = ""
                End If

                'Buscar Deduda de Sangre


            Else
                MessageBox.Show("Paciente no presenta registro de ingreso en " & cboOrigen.Text, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub
End Class