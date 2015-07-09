Public Class frmFicha
    Dim objFicha As New FichaSoat
    Dim objAseguradora As New Aseguradora
    Dim objClaseVehiculo As New ClaseVehiculo
    Dim objTipoAccidente As New TipoAccidente
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim objHistoria As New Historia
    Dim objCartas As New Cartas
    Dim objEmergencia As New clsEmergencia
    Dim Oper As String
    Dim CodLocal As String
    Dim objCIE As New CIE10
    Dim nomFiltro As String

    Private Sub Filtro()
        Select Case Microsoft.VisualBasic.Left(nomFiltro, nomFiltro.Length - 1)
            Case "DESCIE"
                If txtDes.Text.Length = 0 Then Exit Sub
                lvDet.Items.Clear()
                Dim dsTabla As New DataSet
                Dim I As Integer
                Dim Fila As ListViewItem
                dsTabla = objCIE.BuscarDes(txtDes.Text)
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("cod_gen"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("desc_enf"))
                Next
        End Select
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmFicha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbConsulta.Visible = False
        'Aseguradora
        Dim dsAseguradora As New Data.DataSet
        dsAseguradora = objAseguradora.Combo
        cboAseguradora.DataSource = dsAseguradora.Tables(0)
        cboAseguradora.DisplayMember = "RazonSocial"
        cboAseguradora.ValueMember = "IdAseguradora"

        'Clase Vehiculo
        Dim dsClaseVehiculo As New Data.DataSet
        dsClaseVehiculo = objClaseVehiculo.Combo
        cboClase.DataSource = dsClaseVehiculo.Tables(0)
        cboClase.DisplayMember = "Descripcion"
        cboClase.ValueMember = "IdClase"

        'Tipo Accidente
        Dim dsTipoAccidente As New Data.DataSet
        dsTipoAccidente = objTipoAccidente.Combo
        cboTipo.DataSource = dsTipoAccidente.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipo"

        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            btnBaja.Enabled = False
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                Dim dsFicha As New Data.DataSet
                dsFicha = objFicha.BuscarFicha(txtHistoria.Text.Trim)
                If dsFicha.Tables(0).Rows.Count = 0 Then
                    lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno").ToString
                    lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno").ToString
                    lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres").ToString
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento").ToString
                    If Not lblFecha.Text = "" Then
                        If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                            lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                        Else
                            lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                        End If
                    End If
                    lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo").ToString
                    dtpFecAcc.Select()
                Else
                    If MessageBox.Show("Paciente Tiene Registrada Ficha SOAT Nro: " & dsFicha.Tables(0).Rows(0)("IdSoat") & " , Desea Generar Una Nueva Ficha", "Mensaje de Consulta", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Oper = 2
                        btnBaja.Enabled = True
                        CodLocal = dsFicha.Tables(0).Rows(0)("IdSoat")
                        lblAPaterno.Text = dsFicha.Tables(0).Rows(0)("Apaterno")
                        lblAMaterno.Text = dsFicha.Tables(0).Rows(0)("Amaterno")
                        lblNombres.Text = dsFicha.Tables(0).Rows(0)("Nombres")
                        lblFecha.Text = dsFicha.Tables(0).Rows(0)("FechaNac")
                        If Not lblFecha.Text = "" Then
                            If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                                lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                            Else
                                lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                            End If
                        End If
                        lblSexo.Text = dsFicha.Tables(0).Rows(0)("Sexo")
                        dtpFecha.Value = dsFicha.Tables(0).Rows(0)("FechaRegistro")
                        dtpFecAcc.Text = dsFicha.Tables(0).Rows(0)("FechaAccidente")
                        txtPlaca.Text = dsFicha.Tables(0).Rows(0)("Placa")
                        txtPoliza.Text = dsFicha.Tables(0).Rows(0)("Poliza")
                        txtContratante.Text = dsFicha.Tables(0).Rows(0)("Contratante")
                        cboAseguradora.Text = dsFicha.Tables(0).Rows(0)("Aseguradora")
                        cboClase.Text = dsFicha.Tables(0).Rows(0)("ClaseVehiculo")
                        cboTipo.Text = dsFicha.Tables(0).Rows(0)("TipoAccidente")
                        cboEspecialidad.Text = dsFicha.Tables(0).Rows(0)("Especialidad")
                        cboSubEspecialidad.Text = dsFicha.Tables(0).Rows(0)("SubEspecialidad")
                        txtCIE1.Text = dsFicha.Tables(0).Rows(0)("CIE1")
                        txtDes1.Text = dsFicha.Tables(0).Rows(0)("DesCIE1")
                        txtCIE2.Text = dsFicha.Tables(0).Rows(0)("CIE2")
                        txtDes2.Text = dsFicha.Tables(0).Rows(0)("DesCIE2")
                        txtCIE3.Text = dsFicha.Tables(0).Rows(0)("CIE3")
                        txtDes3.Text = dsFicha.Tables(0).Rows(0)("DesCIE3")
                        txtCIE4.Text = dsFicha.Tables(0).Rows(0)("CIE4")
                        txtDes4.Text = dsFicha.Tables(0).Rows(0)("DesCIE4")
                        txtMontoCarta.Text = dsFicha.Tables(0).Rows(0)("MontoCarta")
                        cboEstado.Text = dsFicha.Tables(0).Rows(0)("Estado")
                        txtCarta.Text = dsFicha.Tables(0).Rows(0)("Carta")
                        txtMontoFarmacia.Text = dsFicha.Tables(0).Rows(0)("MontoFarmacia")
                        txtDiagnostico.Text = dsFicha.Tables(0).Rows(0)("Diagnostico")
                        txtDocumentos.Text = dsFicha.Tables(0).Rows(0)("Documentos")
                        'Lista de Carta
                        Dim J As Integer
                        Dim dsCartas As New Data.DataSet
                        Dim Fila As ListViewItem
                        dsCartas = objCartas.Buscar(CodLocal)
                        For J = 0 To dsCartas.Tables(0).Rows.Count - 1
                            Fila = lvCartas.Items.Add(dsCartas.Tables(0).Rows(J)("NroCarta"))
                            Fila.SubItems.Add(dsCartas.Tables(0).Rows(J)("Fecha"))
                            Fila.SubItems.Add(dsCartas.Tables(0).Rows(J)("Monto"))
                        Next
                        dtpFecAcc.Select()
                    Else
                        dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
                        If dsTabla.Tables(0).Rows.Count > 0 Then
                            lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                            lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                            lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                            If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then
                                lblFecha.Text = ""
                            Else
                                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento")
                                If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                                    lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                                Else
                                    lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                                End If
                            End If
                            lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                            dtpFecAcc.Select()
                        End If
                    End If
                End If
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarH.Click
        NumeroHistoria = ""
        frmBuscarHistoria.Show()
    End Sub

    Private Sub btnBuscarH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarH.GotFocus
        If NumeroHistoria.Length > 0 Then
            txtHistoria.Text = NumeroHistoria
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then lblFecha.Text = "" Else lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento")
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                dtpFecAcc.Select()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
            NumeroHistoria = ""
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then cboSubEspecialidad.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsSEsp As New Data.DataSet
            dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
            cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
            cboSubEspecialidad.DisplayMember = "Descripcion"
            cboSubEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    '080616-005185
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.dtpFecAcc.Text = "  /  /" Then MessageBox.Show("Debe ingresar Fecha de Accidente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim CodSOAT As String
        If MessageBox.Show("Esta seguro de guardar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            If Oper = 1 Then
                CodSOAT = objFicha.Grabar(txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, Microsoft.VisualBasic.Format(CDate(lblFecha.Text), "dd/MM/yyyy"), lblSexo.Text, Microsoft.VisualBasic.Format(CDate(dtpFecha.Value), "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpFecAcc.Value, "dd/MM/yyyy"), txtPlaca.Text, txtPoliza.Text, txtContratante.Text, cboAseguradora.Text, cboClase.Text, cboTipo.Text, cboEspecialidad.Text, cboSubEspecialidad.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, cboEstado.Text, txtCarta.Text, txtMontoCarta.Text, txtMontoFarmacia.Text, txtDiagnostico.Text, UsuarioSistema, txtDocumentos.Text, cboAseguradora.SelectedValue.ToString)
                'Grabar Cartas
                Dim I As Integer
                For I = 0 To lvCartas.Items.Count - 1
                    objCartas.Grabar(CodSOAT, lvCartas.Items.Item(I).SubItems(0).Text, lvCartas.Items.Item(I).SubItems(1).Text, lvCartas.Items.Item(I).SubItems(2).Text)
                Next
                MessageBox.Show("El Número del Expediente es: " & CodSOAT, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                objCartas.Eliminar(CodLocal)
                objFicha.Modificar(CodLocal, txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, lblFecha.Text, lblSexo.Text, dtpFecha.Value, Microsoft.VisualBasic.Format(CDate(dtpFecAcc.Value), "dd/MM/yyyy"), txtPlaca.Text, txtPoliza.Text, txtContratante.Text, cboAseguradora.Text, cboClase.Text, cboTipo.Text, cboEspecialidad.Text, cboSubEspecialidad.Text, txtCIE1.Text, txtDes1.Text, txtCIE2.Text, txtDes2.Text, txtCIE3.Text, txtDes3.Text, txtCIE4.Text, txtDes4.Text, cboEstado.Text, txtCarta.Text, txtMontoCarta.Text, txtMontoFarmacia.Text, txtDiagnostico.Text, txtDocumentos.Text, cboAseguradora.SelectedValue.ToString)
                'Grabar Cartas
                Dim I As Integer
                CodSOAT = CodLocal
                For I = 0 To lvCartas.Items.Count - 1
                    objCartas.Grabar(CodLocal, lvCartas.Items.Item(I).SubItems(0).Text, lvCartas.Items.Item(I).SubItems(1).Text, lvCartas.Items.Item(I).SubItems(2).Text)
                Next
            End If

            'If cboEspecialidad.Text = "EMERGENCIA" Then
            Dim dsVerE As New DataSet
            dsVerE = objEmergencia.VerificarEmergenciaIng(txtHistoria.Text)
            If dsVerE.Tables(0).Rows.Count > 0 Then
                objEmergencia.ActualizarIngresoSOAT(dsVerE.Tables(0).Rows(0)("IdIngreso"), CodSOAT)
            End If
            'End If
        End If

        If NivelUsuario = "CAJERO" Then
            MessageBox.Show("CODIGO DE ATENCION: " & CodSOAT, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnBuscarH.Enabled = True
        txtHistoria.Select()
        cboEstado.Text = "VIVO"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Date.Now
        btnBaja.Enabled = False
        Botones(True, False, False, True)
        Limpiar(Me)
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        lblEdad.Text = ""
        NumeroHistoria = ""
        btnBuscarH.Enabled = False
        ControlesAD(Me, False)
        lvCartas.Items.Clear()
    End Sub

    Private Sub txtCIE1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE1.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes1.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtDes1.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE2.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes2.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtDes2.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE3.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes3.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtDes3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE4.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes4.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtDes4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaca.KeyDown
        If e.KeyCode = Keys.Enter And txtPlaca.Text.Length > 0 Then txtPoliza.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then Me.dtpFecAcc.Select()
    End Sub

    Private Sub dtpFecAcc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPlaca.Select()
    End Sub


    Private Sub txtPoliza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPoliza.KeyDown
        If e.KeyCode = Keys.Enter And txtPoliza.Text.Length > 0 Then txtContratante.Select()
    End Sub

    Private Sub txtContratante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContratante.KeyDown
        If e.KeyCode = Keys.Enter And txtContratante.Text.Length > 0 Then cboAseguradora.Select()
    End Sub

    Private Sub cboAseguradora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAseguradora.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboAseguradora.SelectedValue) Then cboClase.Select()
    End Sub

    Private Sub cboAseguradora_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAseguradora.SelectedIndexChanged

    End Sub

    Private Sub cboClase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboClase.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboClase.SelectedValue) Then cboTipo.Select()
    End Sub

    Private Sub cboClase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClase.SelectedIndexChanged

    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboTipo.SelectedValue) Then cboEspecialidad.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub cboSubEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubEspecialidad.SelectedValue) Then txtCIE1.Select()
    End Sub

    Private Sub cboSubEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub txtCIE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE1.TextChanged

    End Sub

    Private Sub cboEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstado.KeyDown
        If e.KeyCode = Keys.Enter And cboEstado.Text.Length > 0 Then btnGrabar.Select()
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtNroCarta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroCarta.KeyDown
        If e.KeyCode = Keys.Enter Then meFecha.Select()
    End Sub

    Private Sub txtNroCarta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCarta.KeyPress

    End Sub

    Private Sub txtNroCarta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroCarta.TextChanged

    End Sub

    Private Sub meFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles meFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtMonto.Select()
    End Sub

    Private Sub meFecha_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles meFecha.MaskInputRejected

    End Sub

    Private Sub txtMonto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.Enter And txtMonto.Text.Length > 0 Then
            Dim Fila As ListViewItem
            Fila = lvCartas.Items.Add(txtNroCarta.Text)
            Fila.SubItems.Add(meFecha.Text)
            Fila.SubItems.Add(txtMonto.Text)
            txtMontoCarta.Text = Val(txtMontoCarta.Text) + Val(txtMonto.Text)
            txtNroCarta.Text = ""
            meFecha.Text = ""
            txtMonto.Text = ""
            txtNroCarta.Select()
        End If
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub lvCartas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCartas.KeyDown
        If NivelUsuario = "CAJERO" Then MessageBox.Show("No tiene Asigando Privilegios para esta Operación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If e.KeyCode = Keys.Delete Then
            Dim I As Integer
            If MessageBox.Show("Esta seguro de Eliminar Carta de Garantia", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For I = 0 To lvCartas.Items.Count - 1
                    If lvCartas.Items.Item(I).Selected Then
                        txtMontoCarta.Text = Val(txtMontoCarta.Text) - Val(lvCartas.Items.Item(I).SubItems(2).Text)
                        lvCartas.Items.Item(I).Remove()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbConsulta.Visible = False
    End Sub

    Private Sub txtDes1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes1.TextChanged
        If txtDes1.Text.Length > 0 Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then lvDet.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        Filtro()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.I Then
            Dim I As Integer
            If lvDet.Items.Count > 0 Then
                Select Case nomFiltro
                    Case "DESCIE1"
                        For I = 0 To lvDet.Items.Count - 1
                            If lvDet.Items(I).Selected Then
                                txtCIE1.Text = lvDet.Items(I).SubItems(0).Text
                                txtDes1.Text = lvDet.Items(I).SubItems(1).Text
                                lvDet.Items.Clear()
                                txtDes.Text = ""
                                gbConsulta.Visible = False
                                txtCIE2.Select()
                                Exit For
                            End If
                        Next
                    Case "DESCIE2"
                        For I = 0 To lvDet.Items.Count - 1
                            If lvDet.Items(I).Selected Then
                                txtCIE2.Text = lvDet.Items(I).SubItems(0).Text
                                txtDes2.Text = lvDet.Items(I).SubItems(1).Text
                                lvDet.Items.Clear()
                                txtDes.Text = ""
                                gbConsulta.Visible = False
                                txtCIE3.Select()
                                Exit For
                            End If
                        Next
                    Case "DESCIE3"
                        For I = 0 To lvDet.Items.Count - 1
                            If lvDet.Items(I).Selected Then
                                txtCIE3.Text = lvDet.Items(I).SubItems(0).Text
                                txtDes3.Text = lvDet.Items(I).SubItems(1).Text
                                lvDet.Items.Clear()
                                txtDes.Text = ""
                                gbConsulta.Visible = False
                                txtCIE4.Select()
                                Exit For
                            End If
                        Next
                    Case "DESCIE4"
                        For I = 0 To lvDet.Items.Count - 1
                            If lvDet.Items(I).Selected Then
                                txtCIE4.Text = lvDet.Items(I).SubItems(0).Text
                                txtDes4.Text = lvDet.Items(I).SubItems(1).Text
                                lvDet.Items.Clear()
                                txtDes.Text = ""
                                gbConsulta.Visible = False
                                cboEstado.Select()
                                Exit For
                            End If
                        Next
                End Select
            End If
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        
    End Sub

    Private Sub txtDes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes2.TextChanged
        If txtDes2.Text.Length > 0 Then nomFiltro = "DESCIE2" : txtDes.Text = txtDes2.Text : gbConsulta.Visible = True : txtDes.Text = txtDes2.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes3.TextChanged
        If txtDes3.Text.Length > 0 Then nomFiltro = "DESCIE3" : txtDes.Text = txtDes3.Text : gbConsulta.Visible = True : txtDes.Text = txtDes3.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes4.TextChanged
        If txtDes4.Text.Length > 0 Then nomFiltro = "DESCIE4" : txtDes.Text = txtDes4.Text : gbConsulta.Visible = True : txtDes.Text = txtDes4.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub lvCartas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCartas.SelectedIndexChanged

    End Sub

    Private Sub dtpFecAcc_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPlaca.Select()
    End Sub

    Private Sub txtPre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPre.KeyPress
        btnBaja.Enabled = False
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtPre.Text.Length > 0 Then
            Dim dsFicha As New Data.DataSet
            dsFicha = objFicha.BuscarFichaNP(txtPre.Text.Trim)
            If dsFicha.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No Existe Nro de Ficha Soat", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar(Me)
                lvCartas.Items.Clear()
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblEdad.Text = ""
                dtpFecha.Value = Date.Now
                txtPre.Select()
            Else
                MessageBox.Show("Existe aperturada una ficha para este paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnBaja.Enabled = True
                lvCartas.Items.Clear()
                Oper = 2
                CodLocal = dsFicha.Tables(0).Rows(0)("IdSoat")
                txtHistoria.Text = dsFicha.Tables(0).Rows(0)("Historia")
                lblAPaterno.Text = dsFicha.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsFicha.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsFicha.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsFicha.Tables(0).Rows(0)("FechaNac")
                If Not lblFecha.Text = "" Then
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                End If
                lblSexo.Text = dsFicha.Tables(0).Rows(0)("Sexo")
                dtpFecha.Value = dsFicha.Tables(0).Rows(0)("FechaRegistro")
                dtpFecAcc.Text = dsFicha.Tables(0).Rows(0)("FechaAccidente")
                txtPlaca.Text = dsFicha.Tables(0).Rows(0)("Placa")
                txtPoliza.Text = dsFicha.Tables(0).Rows(0)("Poliza")
                txtContratante.Text = dsFicha.Tables(0).Rows(0)("Contratante")
                cboAseguradora.Text = dsFicha.Tables(0).Rows(0)("Aseguradora")
                cboClase.Text = dsFicha.Tables(0).Rows(0)("ClaseVehiculo")
                cboTipo.Text = dsFicha.Tables(0).Rows(0)("TipoAccidente")
                cboEspecialidad.Text = dsFicha.Tables(0).Rows(0)("Especialidad")
                cboSubEspecialidad.Text = dsFicha.Tables(0).Rows(0)("SubEspecialidad")
                txtCIE1.Text = dsFicha.Tables(0).Rows(0)("CIE1")
                txtDes1.Text = dsFicha.Tables(0).Rows(0)("DesCIE1")
                txtCIE2.Text = dsFicha.Tables(0).Rows(0)("CIE2")
                txtDes2.Text = dsFicha.Tables(0).Rows(0)("DesCIE2")
                txtCIE3.Text = dsFicha.Tables(0).Rows(0)("CIE3")
                txtDes3.Text = dsFicha.Tables(0).Rows(0)("DesCIE3")
                txtCIE4.Text = dsFicha.Tables(0).Rows(0)("CIE4")
                txtDes4.Text = dsFicha.Tables(0).Rows(0)("DesCIE4")
                txtMontoCarta.Text = dsFicha.Tables(0).Rows(0)("MontoCarta")
                cboEstado.Text = dsFicha.Tables(0).Rows(0)("Estado")
                txtCarta.Text = dsFicha.Tables(0).Rows(0)("Carta")
                txtMontoFarmacia.Text = dsFicha.Tables(0).Rows(0)("MontoFarmacia")
                txtDiagnostico.Text = dsFicha.Tables(0).Rows(0)("Diagnostico")
                txtDocumentos.Text = dsFicha.Tables(0).Rows(0)("Documentos")
                'Lista de Carta
                Dim J As Integer
                Dim dsCartas As New Data.DataSet
                Dim Fila As ListViewItem
                dsCartas = objCartas.Buscar(CodLocal)
                For J = 0 To dsCartas.Tables(0).Rows.Count - 1
                    Fila = lvCartas.Items.Add(dsCartas.Tables(0).Rows(J)("NroCarta"))
                    Fila.SubItems.Add(dsCartas.Tables(0).Rows(J)("Fecha"))
                    Fila.SubItems.Add(dsCartas.Tables(0).Rows(J)("Monto"))
                Next
                dtpFecAcc.Select()
            End If
        End If
    End Sub

  
    Private Sub txtPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPre.TextChanged

    End Sub

    Private Sub txtCIE2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE2.TextChanged

    End Sub

    Private Sub btnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaja.Click
        If NivelUsuario = "CAJERO" Then MessageBox.Show("No tiene Asigando Privilegios para esta Operación", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Desea dar de Baja Expediente SOAT", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Motivo As String
            Motivo = InputBox("Ingrear Motivo de Baja", "Area SOAT")
            objFicha.Anular(CodLocal, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, Motivo)
        End If
        btnCancelar_Click(sender, e)
    End Sub
End Class