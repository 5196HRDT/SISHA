Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports  Microsoft.VisualBasic
Public Class frmReferencia
    Dim objHistoria As New Historia
    Dim objReferencia As New Referencia
    Dim objCentro As New CentroSalud
    Dim objCondicionAlta As New CondicionAlta
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim objMedico As New Medico
    Dim objGrupo As New GrupoEtareo
    Dim objServicio As New Servicio
    Dim objPersonal As New PersonalRes
    Dim objCIE As New CIE10
    Dim objSISHRDT As New SISHRDT
    Dim Oper As String
    Dim CodLocal As String
    Dim nomFiltro As String

    Private Sub Buscar()
        If txtPaciente.Text.Length < 2 Then Exit Sub
        Dim dsTabla As New Data.DataSet
        dsTabla = objReferencia.Buscar(txtPaciente.Text)
        Dim I As Integer
        lvLista.Items.Clear()
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvLista.Items.Add(dsTabla.Tables(0).Rows(I)("IdReferencia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Apaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Amaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("NroReferencia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("GrupoEtareo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Establecimiento"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIE1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIE2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Des2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIE3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIE4"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Des4"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("PersonalRes"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FechaEgreso"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIEE1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("DesE1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIEE2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("DesE2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIEE3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("DesE3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CIEE4"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("DesE4"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("CondicionAlta"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubEspecialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("MedicoResp"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Td1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Td2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Td3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Td4"))
            Dim X As String = dsTabla.Tables(0).Rows(I)("TdE1").ToString()
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TdE1"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TdE2"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TdE3"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TdE4"))
        Next
    End Sub

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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        Limpiar(Me)
        txtHistoria.Text = ""
        lblPaciente.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblSexo.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        NumeroHistoria = ""
        txtCIE1.Text = ""
        txtDes1.Text = ""
        txtCIE2.Text = ""
        txtDes2.Text = ""
        txtCIE3.Text = ""
        txtDes3.Text = ""
        txtCIE4.Text = ""
        txtDes4.Text = ""
        txtNroReferencia.Text = ""
        txtCIER1.Text = ""
        txtDesR1.Text = ""
        txtCIER2.Text = ""
        txtDesR2.Text = ""
        txtCIER3.Text = ""
        txtDesR3.Text = ""
        txtCIER4.Text = ""
        txtDesR4.Text = ""
        btnBuscarH.Enabled = False
        gbConsulta.Visible = False
        ControlesAD(Me, False)
        Buscar()
        txtPaciente.Enabled = True
        cboTd1.Enabled = False
        cboTd2.Enabled = False
        cboTd3.Enabled = False
        cboTd4.Enabled = False
        cboTdE1.Enabled = False
        cboTdE2.Enabled = False
        cboTdE3.Enabled = False
        cboTdE4.Enabled = False

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        cboMes.SelectedIndex = Date.Now.Month - 1
        cboAño.SelectedItem = Date.Now.Year.ToString()
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        Oper = 1
        btnBuscarH.Enabled = True
        txtLote.Select()
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
                lblPaciente.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then lblFecha.Text = "" Else lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento")
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                txtNroReferencia.Select()
                Me.grupoEtareo()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
            NumeroHistoria = ""
        End If
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim paciente As String = ""


            Dim dsTabla As New Data.DataSet
            dsTabla = objReferencia.ConsultaHC(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If MessageBox.Show("Paciente tiene Registrada Activo Nro " & dsTabla.Tables(0).Rows(0)("IdReferencia") & " " & dsTabla.Tables(0).Rows(0)("Historia") & "-" & dsTabla.Tables(0).Rows(0)("NroReferencia") & Chr(13) & "Paciente " & dsTabla.Tables(0).Rows(0)("Apaterno") & " " & dsTabla.Tables(0).Rows(0)("Amaterno") & " " & dsTabla.Tables(0).Rows(0)("Nombres"), "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then btnCancelar_Click(sender, e) : Exit Sub
            End If
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                paciente += dsTabla.Tables(0).Rows(0)("Apaterno")
                paciente += " " + dsTabla.Tables(0).Rows(0)("Amaterno")
                paciente += " " + dsTabla.Tables(0).Rows(0)("Nombres")
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblPaciente.Text = paciente
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento").ToString
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                Me.grupoEtareo()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub
    Private Sub grupoEtareo()
        Dim fNacimiento As Date
        fNacimiento = Convert.ToDateTime(lblFecha.Text)
       

    End Sub

    Private Sub frmReferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lblPaciente.Width = 350
        gbConsulta.Left = 12
        gbConsulta.Top = 92
        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"

        'Condicion Alta
        Dim dsCondicion As New Data.DataSet
        dsCondicion = objCondicionAlta.Combo
        cboCondicionAlta.DataSource = dsCondicion.Tables(0)
        cboCondicionAlta.DisplayMember = "Descripcion"
        cboCondicionAlta.ValueMember = "IdCondicion"

        'Grupo Etareo
        Dim dsGrupo As New Data.DataSet
        dsGrupo = objGrupo.Combo("SIS")
        cboGrupoEtareo.DataSource = dsGrupo.Tables(0)
        cboGrupoEtareo.DisplayMember = "Descripcion"
        cboGrupoEtareo.ValueMember = "IdGrupo"

        'Medico Res
        Dim dsMedico As New Data.DataSet
        dsMedico = objMedico.BuscarNombres("")
        cboMedicoRes.DataSource = dsMedico.Tables(0)
        cboMedicoRes.DisplayMember = "Medico"
        cboMedicoRes.ValueMember = "IdMedico"

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"
        'ESP. SERVICIO'
        Dim dsSEsp As New Data.DataSet
        dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
        cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
        cboSubEspecialidad.DisplayMember = "Descripcion"
        cboSubEspecialidad.ValueMember = "IdEspecialidad"
        'Personal Res
        Dim dsPersonal As New Data.DataSet
        dsPersonal = objPersonal.Combo
        cboPersonalRes.DataSource = dsPersonal.Tables(0)
        cboPersonalRes.DisplayMember = "Descripcion"
        cboPersonalRes.ValueMember = "IdPersonal"

        'Centro Salud
        Dim dsCentro As New Data.DataSet
        dsCentro = objCentro.Combo
        cboEstablecimiento.DataSource = dsCentro.Tables(0)
        cboEstablecimiento.DisplayMember = "Descripcion"
        cboEstablecimiento.ValueMember = "IdCentro"

        cboAño.Text = Date.Now.Year
        cboMes.Text = "ENERO"
        cboPersonalRes.SelectedIndex = 1
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter Then cboSubEspecialidad.Select()
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

    Private Sub txtNroReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroReferencia.KeyDown
        If e.KeyCode = Keys.Enter And txtNroReferencia.Text <> "" Then cboGrupoEtareo.Select()
    End Sub

    Private Sub cboGrupoEtareo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGrupoEtareo.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboGrupoEtareo.SelectedValue) Then cboServicio.Select()
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then cboPersonalRes.Select()
    End Sub

    Private Sub cboPersonalRes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPersonalRes.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboPersonalRes.SelectedValue) Then cboEstablecimiento.Select()
    End Sub

    Private Sub txtCIE1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE1.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE1.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes1.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE2.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCIER1.Text = txtCIE1.Text
            txtDesR1.Text = txtDes1.Text
            cboTd1.SelectedIndex = 0
            cboTd1.Enabled = True
            cboTdE1.SelectedIndex = 0
            cboTdE1.Enabled = True
        End If
    End Sub

    Private Sub txtCIE2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE2.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE2.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE2.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes2.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCIER2.Text = txtCIE2.Text
            txtDesR2.Text = txtDes2.Text
            cboTd3.SelectedIndex = 0
            cboTd3.Enabled = True
        Else
            If e.KeyCode = Keys.Enter Then dtpFechaE.Select()
        End If
    End Sub

    Private Sub txtCIE3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE3.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE3.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE3.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes3.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCIER3.Text = txtCIE3.Text
            txtDesR3.Text = txtDes3.Text
            cboTd3.SelectedIndex = 0
            cboTd3.Enabled = True
            cboTdE3.SelectedIndex = 0
            cboTdE3.Enabled = True
        Else
            If e.KeyCode = Keys.Enter Then dtpFechaE.Select()
        End If
    End Sub

    Private Sub txtCIE4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE4.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE4.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE4.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes4.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : dtpFechaE.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCIER4.Text = txtCIE4.Text
            txtDesR4.Text = txtDes4.Text
            cboTd4.SelectedIndex = 0
            cboTd4.Enabled = True
            cboTdE4.SelectedIndex = 0
            cboTdE4.Enabled = True

        Else
            If e.KeyCode = Keys.Enter Then dtpFechaE.Select()
        End If
    End Sub

    Private Sub txtCIER1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIER1.KeyDown
        If e.KeyCode = Keys.Enter And txtCIER1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIER1.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDesR1.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIER2.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTdE1.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtCIER2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIER2.KeyDown
        If e.KeyCode = Keys.Enter And txtCIER2.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIER2.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDesR2.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIER3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTdE2.SelectedIndex = 0
        Else
            If e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
        End If
    End Sub

    Private Sub txtCIER3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIER3.KeyDown
        If e.KeyCode = Keys.Enter And txtCIER3.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIER3.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDesR3.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIER4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTdE3.SelectedIndex = 0
        Else
            If e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
        End If
    End Sub

    Private Sub txtCIER4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIER4.KeyDown
        If e.KeyCode = Keys.Enter And txtCIER4.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIER4.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDesR4.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIER4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTdE4.SelectedIndex = 0
        Else
            If e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
        End If
    End Sub

    Private Sub dtpFechaE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaE.KeyDown
        If e.KeyCode = Keys.Enter Then cboCondicionAlta.Select()
    End Sub

  

    Private Sub cboSubEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSubEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubEspecialidad.SelectedValue) Then cboMedicoRes.Select()
    End Sub

    Private Sub cboMedicoRes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedicoRes.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedicoRes.SelectedValue) Then btnGrabar.Enabled = True : btnGrabar.Select()
    End Sub

    Private Sub cboCondicionAlta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCondicionAlta.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboCondicionAlta.SelectedValue) Then cboEspecialidad.Select()
    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim hora As String = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        If cboMedicoRes.Text = "" Then MessageBox.Show("Faltan datos de médico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If txtCIE1.Text.Equals("") Or txtCIER1.Equals("") Then MessageBox.Show("Faltan diagnostico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If lblPaciente.Text.Equals("") Then MessageBox.Show("Falta datos paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If txtLote.Text.Equals("") Or txtNumero.Equals("") Then MessageBox.Show("Numero de formato obligatorio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Try
            If MessageBox.Show("Esta seguro de grabar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objReferencia.Mantenimiento(CodLocal,
                                            dtpFecha.Value,
                                            hora,
                                            UsuarioSistema,
                                            My.Computer.Name,
                                            txtHistoria.Text,
                                            lblAPaterno.Text,
                                            lblAMaterno.Text, lblNombres.Text,
                                            txtNroReferencia.Text,
                                            cboGrupoEtareo.SelectedValue.ToString,
                                            lblSexo.Text,
                                            cboEstablecimiento.SelectedValue.ToString,
                                            txtCIE1.Text, txtDes1.Text, cboTd1.Text,
                                            txtCIE2.Text, txtDes2.Text, cboTd2.Text,
                                            txtCIE3.Text, txtDes3.Text, cboTd3.Text,
                                            txtCIE4.Text, txtDes4.Text, cboTd4.Text,
                                            cboServicio.SelectedValue.ToString,
                                            cboPersonalRes.SelectedValue.ToString,
                                            dtpFechaE.Value,
                                            txtCIER1.Text, txtDesR1.Text, cboTdE1.Text,
                                            txtCIER2.Text, txtDesR2.Text, cboTdE2.Text,
                                            txtCIER3.Text, txtDesR3.Text, cboTdE3.Text,
                                            txtCIER4.Text, txtDes4.Text, cboTdE4.Text,
                                            cboCondicionAlta.SelectedValue.ToString,
                                            cboSubEspecialidad.SelectedValue.ToString,
                                            cboMedicoRes.SelectedValue.ToString, Oper, cboMes.Text, cboAño.Text,
                                            cboGesPuer.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboEstablecimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEstablecimiento.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEstablecimiento.SelectedValue) Then txtCIE1.Select()
    End Sub

    Private Sub txtDes1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes1.KeyDown
        If txtDes1.Text.Length > 0 Then nomFiltro = "DESCIE1" : txtDes.Text = txtDes1.Text : gbConsulta.Visible = True : txtDes.Text = txtDes1.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then lvDet.Select()
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        Filtro()
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbConsulta.Visible = False
        txtDes.Text = ""
        lvDet.Items.Clear()
    End Sub

    Private Sub txtDes2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes2.KeyDown
        If txtDes2.Text.Length > 0 Then nomFiltro = "DESCIE2" : txtDes.Text = txtDes2.Text : gbConsulta.Visible = True : txtDes.Text = txtDes2.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes3.KeyDown
        If txtDes3.Text.Length > 0 Then nomFiltro = "DESCIE3" : txtDes.Text = txtDes3.Text : gbConsulta.Visible = True : txtDes.Text = txtDes3.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDes4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes4.KeyDown
        If txtDes4.Text.Length > 0 Then nomFiltro = "DESCIE4" : txtDes.Text = txtDes4.Text : gbConsulta.Visible = True : txtDes.Text = txtDes4.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
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
                                Dim dsTabla As New Data.DataSet
                                dsTabla = objCIE.BuscarCodigo(txtCIE1.Text)
                                If dsTabla.Tables(0).Rows.Count > 0 Then txtDes1.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                                txtCIER1.Text = txtCIE1.Text
                                txtDesR1.Text = txtDes1.Text
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
                                Dim dsTabla As New Data.DataSet
                                dsTabla = objCIE.BuscarCodigo(txtCIE2.Text)
                                If dsTabla.Tables(0).Rows.Count > 0 Then txtDes2.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                                txtCIER2.Text = txtCIE2.Text
                                txtDesR2.Text = txtDes2.Text
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
                                Dim dsTabla As New Data.DataSet
                                dsTabla = objCIE.BuscarCodigo(txtCIE3.Text)
                                If dsTabla.Tables(0).Rows.Count > 0 Then txtDes3.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : txtCIE4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                                txtCIER3.Text = txtCIE3.Text
                                txtDesR3.Text = txtDes3.Text
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
                                Dim dsTabla As New Data.DataSet
                                dsTabla = objCIE.BuscarCodigo(txtCIE4.Text)
                                If dsTabla.Tables(0).Rows.Count > 0 Then txtDes4.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : dtpFechaE.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                                txtCIER4.Text = txtCIE4.Text
                                txtDesR4.Text = txtDes4.Text
                                lvDet.Items.Clear()
                                txtDes.Text = ""
                                gbConsulta.Visible = False
                                dtpFechaE.Select()
                                Exit For
                            End If
                        Next
                End Select
            End If
        End If
    End Sub

    Private Sub txtCIE1_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIE1.LostFocus
        If (txtCIE1.Text.Trim <> "") Then
            cboTd1.Enabled = True
        Else
            cboTd1.Enabled = False
            cboTd1.Text = ""
        End If
    End Sub

   

    Private Sub txtCIE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE1.TextChanged
        If txtCIE1.Text = "" Then txtDes1.Text = ""
    End Sub

    Private Sub txtCIE2_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIE2.LostFocus
        If (txtCIE2.Text.Trim <> "") Then
            cboTd2.Enabled = True
        Else
            cboTd2.Enabled = False
            cboTd2.Text = ""
        End If
    End Sub

    Private Sub txtCIE2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE2.TextChanged
        If txtCIE2.Text = "" Then txtDes2.Text = ""
    End Sub

    Private Sub txtCIE3_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIE3.LostFocus
        If (txtCIE3.Text.Trim <> "") Then
            cboTd3.Enabled = True
        Else
            cboTd3.Enabled = False
            cboTd3.Text = ""
        End If
    End Sub

    Private Sub txtCIE3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE3.TextChanged
        If txtCIE3.Text = "" Then txtDes3.Text = ""
    End Sub

    Private Sub txtCIE4_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIE4.LostFocus
        If (txtCIE4.Text.Trim <> "") Then
            cboTd4.Enabled = True
        Else
            cboTd4.Enabled = False
            cboTd4.Text = ""
        End If
    End Sub

    Private Sub txtCIE4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE4.TextChanged
        If txtCIE4.Text = "" Then txtDes4.Text = ""
    End Sub


    Private Sub lvLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvLista.KeyDown
        If e.KeyCode = Keys.Delete And lvLista.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvLista.Items.Count - 1
                If lvLista.Items(I).Selected Then
                    If MessageBox.Show("Esta seguro de eliminar el registro", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        objReferencia.Mantenimiento(CodLocal,
                                                    Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"),
                                                    Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2),
                                                    UsuarioSistema, My.Computer.Name, txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text,
                                                    txtNroReferencia.Text, cboGrupoEtareo.SelectedValue.ToString, lblSexo.Text, cboEstablecimiento.SelectedValue.ToString,
                                                    txtCIE1.Text, txtDes1.Text, cboTd1.Text,
                                                    txtCIE2.Text, txtDes2.Text, cboTd2.Text,
                                                    txtCIE3.Text, txtDes3.Text, cboTd3.Text,
                                                    txtCIE4.Text, txtDes4.Text, cboTd4.Text,
                                                    cboServicio.SelectedValue.ToString, cboPersonalRes.SelectedValue.ToString, Microsoft.VisualBasic.Format(dtpFechaE.Value, "dd/MM/yyyy"),
                                                    txtCIER1.Text, txtDesR1.Text, cboTdE1.Text,
                                                    txtCIER2.Text, txtDesR2.Text, cboTdE2.Text,
                                                    txtCIER3.Text, txtDesR3.Text, cboTdE3.Text,
                                                    txtCIER4.Text, txtDesR4.Text, cboTdE4.Text,
                                                    cboCondicionAlta.SelectedValue.ToString, cboSubEspecialidad.SelectedValue.ToString, cboMedicoRes.SelectedValue.ToString, 3, cboMes.Text, cboAño.Text, cboGesPuer.Text)
                        btnCancelar_Click(sender, e)
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub lvLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLista.SelectedIndexChanged
        If lvLista.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvLista.Items.Count - 1
                If lvLista.Items(I).Selected Then
                    Oper = 2
                    CodLocal = lvLista.Items(I).SubItems(0).Text
                    dtpFecha.Value = lvLista.Items(I).SubItems(1).Text
                    txtHistoria.Text = lvLista.Items(I).SubItems(2).Text
                    lblAPaterno.Text = lvLista.Items(I).SubItems(3).Text
                    lblAMaterno.Text = lvLista.Items(I).SubItems(4).Text
                    lblNombres.Text = lvLista.Items(I).SubItems(5).Text
                    lblPaciente.Text = lblAPaterno.Text + " " + lblAMaterno.Text + " " + lblNombres.Text
                    txtNroReferencia.Text = lvLista.Items(I).SubItems(6).Text
                    cboGrupoEtareo.Text = lvLista.Items(I).SubItems(7).Text
                    lblSexo.Text = lvLista.Items(I).SubItems(8).Text
                    cboEstablecimiento.Text = lvLista.Items(I).SubItems(9).Text
                    txtCIE1.Text = lvLista.Items(I).SubItems(10).Text
                    txtDes1.Text = lvLista.Items(I).SubItems(11).Text


                    txtCIE2.Text = lvLista.Items(I).SubItems(12).Text
                    txtDes2.Text = lvLista.Items(I).SubItems(13).Text
                    
                    txtCIE3.Text = lvLista.Items(I).SubItems(14).Text
                    txtDes3.Text = lvLista.Items(I).SubItems(15).Text
                    
                    txtCIE4.Text = lvLista.Items(I).SubItems(16).Text
                    txtDes4.Text = lvLista.Items(I).SubItems(17).Text
                    

                    cboServicio.Text = lvLista.Items(I).SubItems(18).Text
                    cboPersonalRes.Text = lvLista.Items(I).SubItems(19).Text
                    dtpFechaE.Text = lvLista.Items(I).SubItems(20).Text
                    txtCIER1.Text = lvLista.Items(I).SubItems(21).Text
                    txtDesR1.Text = lvLista.Items(I).SubItems(22).Text
                    txtCIER2.Text = lvLista.Items(I).SubItems(23).Text
                    txtDesR2.Text = lvLista.Items(I).SubItems(24).Text
                    txtCIER3.Text = lvLista.Items(I).SubItems(25).Text
                    txtDesR3.Text = lvLista.Items(I).SubItems(26).Text
                    txtCIER4.Text = lvLista.Items(I).SubItems(27).Text
                    txtDesR4.Text = lvLista.Items(I).SubItems(28).Text
                    cboCondicionAlta.Text = lvLista.Items(I).SubItems(29).Text
                    cboEspecialidad.Text = lvLista.Items(I).SubItems(30).Text
                    cboSubEspecialidad.Text = lvLista.Items(I).SubItems(31).Text
                    cboMedicoRes.Text = lvLista.Items(I).SubItems(32).Text

                    cboTd1.Text = lvLista.Items(I).SubItems(33).Text
                    cboTd2.Text = lvLista.Items(I).SubItems(34).Text
                    cboTd3.Text = lvLista.Items(I).SubItems(35).Text
                    cboTd4.Text = lvLista.Items(I).SubItems(36).Text
                    cboTdE1.Text = lvLista.Items(I).SubItems(37).Text
                    cboTdE2.Text = lvLista.Items(I).SubItems(38).Text
                    cboTdE3.Text = lvLista.Items(I).SubItems(39).Text
                    cboTdE4.Text = lvLista.Items(I).SubItems(40).Text


                    btnBuscarH.Enabled = True
                    ControlesAD(Me, True)
                    Botones(False, True, True, False)
                End If
            Next
        End If
    End Sub

    Private Sub txtCIER1_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIER1.LostFocus
        If (txtCIER1.Text.Trim <> "") Then
            cboTdE1.Enabled = True
        Else
            cboTdE1.Enabled = False
            cboTdE1.Text = ""
        End If
    End Sub

    Private Sub txtCIER1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIER1.TextChanged
        If txtCIER1.Text = "" Then txtDesR1.Text = ""
    End Sub

    Private Sub txtCIER2_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIER2.LostFocus
        If (txtCIER2.Text.Trim <> "") Then
            cboTdE2.Enabled = True
        Else
            cboTdE2.Enabled = False
            cboTdE2.Text = ""
        End If
    End Sub

    Private Sub txtCIER2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIER2.TextChanged
        If txtCIER2.Text = "" Then txtDesR2.Text = ""
    End Sub

    Private Sub txtCIER3_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIER3.LostFocus
        If (txtCIER3.Text.Trim <> "") Then
            cboTdE3.Enabled = True
        Else
            cboTdE3.Enabled = False
            cboTdE3.Text = ""
        End If
    End Sub

    Private Sub txtCIER3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIER3.TextChanged
        If txtCIER3.Text = "" Then txtDesR3.Text = ""
    End Sub

    Private Sub txtCIER4_LostFocus(sender As Object, e As System.EventArgs) Handles txtCIER4.LostFocus
        If (txtCIER4.Text.Trim <> "") Then
            cboTdE4.Enabled = True
        Else
            cboTdE4.Enabled = False
            cboTdE4.Text = ""
        End If
    End Sub

    Private Sub txtCIER4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIER4.TextChanged
        If txtCIER4.Text = "" Then txtDesR4.Text = ""
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged
        If txtPaciente.Text.Length > 2 Then Buscar()
    End Sub

    Private Sub txtLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLote.KeyDown
        If e.KeyCode = Keys.Enter And txtLote.Text <> "" Then txtNumero.Select()
    End Sub


    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter And IsNumeric(txtNumero.Text) Then
                Dim dsVer As New DataSet
                dsVer = objSISHRDT.Buscar(txtLote.Text, txtNumero.Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    txtHistoria.Text = dsVer.Tables(0).Rows(0)("Historia")

                    'Informacion de Pacientes
                    Dim dsTabla As New Data.DataSet
                    dsTabla = objReferencia.ConsultaHC(txtHistoria.Text)
                    If dsTabla.Tables(0).Rows.Count > 0 Then
                        If MessageBox.Show("Paciente tiene Registrada Activo Nro " & dsTabla.Tables(0).Rows(0)("IdReferencia") & " " & dsTabla.Tables(0).Rows(0)("Historia") & "-" & dsTabla.Tables(0).Rows(0)("NroReferencia") & Chr(13) & "Paciente " & dsTabla.Tables(0).Rows(0)("Apaterno") & " " & dsTabla.Tables(0).Rows(0)("Amaterno") & " " & dsTabla.Tables(0).Rows(0)("Nombres"), "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then btnCancelar_Click(sender, e) : Exit Sub
                    End If
                    dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
                    If dsTabla.Tables(0).Rows.Count > 0 Then
                        lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                        lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                        lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                        lblPaciente.Text = lblAPaterno.Text + " " + lblAMaterno.Text + " " + lblNombres.Text
                        lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento").ToString
                        lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                        Me.grupoEtareo()
                    Else
                        MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblPaciente.Text = ""
                        lblAMaterno.Text = ""
                        lblNombres.Text = ""
                        lblFecha.Text = ""
                        lblSexo.Text = ""
                        txtHistoria.Select()
                    End If
                    cboServicio.Text = dsVer.Tables(0).Rows(0)("Atencion")
                    txtNroReferencia.Text = dsVer.Tables(0).Rows(0)("NroReferencia")
                    cboEstablecimiento.Text = dsVer.Tables(0).Rows(0)("ESReferido")
                    cboEspecialidad.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                    cboSubEspecialidad.Text = dsVer.Tables(0).Rows(0)("SubEspecialidad")
                    cboMedicoRes.Text = dsVer.Tables(0).Rows(0)("Responsable").ToString
                    cboGesPuer.Text = dsVer.Tables(0).Rows(0)("GesPuer")
                Else
                    MessageBox.Show("Nro de Formato SIS no EXISTE", "Mensaje de Informacióm", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnCancelar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Datos no corresponde a ficha impresa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

 
    Private Sub cboServicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.LostFocus
        If cboServicio.Text = "CONSULTA EXTERNA" Then
            cboCondicionAlta.SelectedIndex = 1
        End If
    End Sub

    Private Sub cboGrupoEtareo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupoEtareo.SelectedIndexChanged
        If cboServicio.Text = "CONSULTA EXTERNA" Then
            cboCondicionAlta.SelectedIndex = 1
        End If
    End Sub
End Class
