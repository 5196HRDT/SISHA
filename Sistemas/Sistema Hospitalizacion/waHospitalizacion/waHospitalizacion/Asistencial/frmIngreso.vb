Public Class frmIngreso
    Dim objIngreso As New Ingreso
    Dim objIngresoCIE As New IngresoCIE
    Dim objHospitalizacion As New Hospitalizacion
    Dim objEstadoCivil As New EstadoCivil
    Dim objServicio As New Servicio
    Dim objEspecialidad As New Especialidad
    Dim objCama As New CamaHosp
    Dim objMedico As New Medico
    Dim objVia As New ViaAdmision
    Dim objSubServicio As New SubServicio
    Dim objCentro As New CentroSalud
    Dim objCIE As New CIE10
    Dim objHistoria As New Historia
    Dim objUbigeo As New Ubigeo
    Dim objPapeleta As New clsPapeletaHospitalizacion
    Dim objTipoTarifa As New clsTipoTarifa
    Dim objSIS As New clsSIS
    Dim objSoat As New clsSOAT
    Dim objConvenio As New clsConvenio

    Dim CodigoIngreso As String

    Dim Oper As String
    Dim CodLocal As String
    Dim IdHospitalizacion As String
    Dim CamaAnterior As String

    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub BuscarHospitalizaciones()
        lvLista.Items.Clear()
        Dim dsHosp As New DataSet
        dsHosp = objIngreso.BuscarHospitalizaciones(txtHistoria.Text)
        For I = 0 To dsHosp.Tables(0).Rows.Count - 1
            Fila = lvLista.Items.Add(dsHosp.Tables(0).Rows(I)("IdIngreso"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("ViaAdmision"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Numero"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Enfermera"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("Referido"))
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("FechaAlta").ToString)
            Fila.SubItems.Add(dsHosp.Tables(0).Rows(I)("IdHospitalizacion"))
        Next
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsHist As New Data.DataSet
        dsHist = objIngreso.Buscar(IdHospitalizacion)
        If dsHist.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Paciente ya registra un ingreso", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Oper = 2
            CodLocal = dsHist.Tables(0).Rows(0)("IdIngreso")
            dtpFecha.Value = dsHist.Tables(0).Rows(0)("Fecha")
            txtHora.Text = dsHist.Tables(0).Rows(0)("Hora")
            cboResponsable.Text = dsHist.Tables(0).Rows(0)("Responsable")
            cboServicio.Text = dsHist.Tables(0).Rows(0)("Servicio")
            MostrarSubServicios()
            cboSubServicio.Text = dsHist.Tables(0).Rows(0)("SubServicio")
            MostrarEspecialidades()
            cboEspecialidad.Text = dsHist.Tables(0).Rows(0)("Especialidad")
            MostrarCamas()
            cboCama.Text = dsHist.Tables(0).Rows(0)("Numero")
            CamaAnterior = cboCama.Text
            cboVia.Text = dsHist.Tables(0).Rows(0)("ViaAdmision")
            cboReferido.Text = dsHist.Tables(0).Rows(0)("Referido")
            cboEnfermera.Text = dsHist.Tables(0).Rows(0)("Enfermera")
            cboTipoPaciente.Text = dsHist.Tables(0).Rows(0)("TipoPaciente").ToString
            txtSerieSIS.Text = dsHist.Tables(0).Rows(0)("SerieSIS").ToString
            txtNumeroSIS.Text = dsHist.Tables(0).Rows(0)("NumeroSIS").ToString
            txtNroPre.Text = dsHist.Tables(0).Rows(0)("NumeroPre").ToString

            Dim dsVer As New DataSet
            dsVer = objIngresoCIE.Buscar(CodLocal)
            For Me.I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("CIE"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
    End Sub

    Public Sub CalcularEdad(FechaActual As Date, FechaNacimiento As Date)
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        Años = DateDiff("yyyy", dinicio, dfin)

        If Meses = 0 And Años = 0 Then
            EdadA = 0
            EdadM = 0
            Dias = Math.Abs(Dias)
            EdadD = Dias
        Else
            'Verificar Dias
            If Dias < 0 Then
                DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                Meses = Meses - 1
            End If
            If Meses < 0 Then
                Meses = 12 + Meses
                Años = Años - 1
            End If
            EdadA = Años
            EdadM = Meses
            EdadD = Dias

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
       
        lblEdadAPac.Text = EdadA
        lblTA.Text = "A"
        lblEdadMPac.Text = EdadM
        lblTM.Text = "M"
        lblEdadDPac.Text = EdadD
        lblTD.Text = "D"

        'If Val(EdadA) > 0 Then
        '    lblEdad.Text = EdadA
        '    lblTEdad.Text = "A"
        'ElseIf Val(EdadM) > 0 Then
        '    lblEdad.Text = EdadM
        '    lblTEdad.Text = "M"
        'Else
        '    lblEdad.Text = EdadD
        '    lblTEdad.Text = "D"
        'End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        lblServicio.Text = ""
        lblSubServicio.Text = ""
        cboServicio.Text = ""
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboCama.Text = ""

        lvTabla.Items.Clear()
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        cboReferido.Enabled = False
        gbConsulta.Visible = False
        btnAnular.Enabled = False
        lvLista.Items.Clear()
    End Sub

    Private Sub frmIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbBPac.Visible = False

        'Via Admision
        Dim dsVia As New Data.DataSet
        dsVia = objVia.Combo
        cboVia.DataSource = dsVia.Tables(0)
        cboVia.DisplayMember = "Descripcion"
        cboVia.ValueMember = "IdViaAdmision"


        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"


        'Responsable
        Dim dsResponsable As New Data.DataSet
        dsResponsable = objMedico.BuscarTipoPersonal(1)
        cboResponsable.DataSource = dsResponsable.Tables(0)
        cboResponsable.DisplayMember = "Personal"
        cboResponsable.ValueMember = "IdMedico"

        'Enfermera
        Dim dsEnfermera As New Data.DataSet
        dsEnfermera = objMedico.BuscarTipoPersonal(2)
        cboEnfermera.DataSource = dsEnfermera.Tables(0)
        cboEnfermera.DisplayMember = "Personal"
        cboEnfermera.ValueMember = "IdMedico"


        'Centro Salud
        Dim dsCentro As New Data.DataSet
        dsCentro = objCentro.Combo
        cboReferido.DataSource = dsCentro.Tables(0)
        cboReferido.DisplayMember = "Descripcion"
        cboReferido.ValueMember = "IdCentro"

        'Departamento
        Dim dsDpto As New Data.DataSet
        dsDpto = objUbigeo.Departamento
        cboDepartamento.DataSource = dsDpto.Tables(0)
        cboDepartamento.DisplayMember = "desc_dpto"
        cboDepartamento.ValueMember = "cod_dpto"

        cboDepartamento_SelectedIndexChanged(sender, e)

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifa.Combo
        cboTipoPaciente.DataSource = dsTT.Tables(0)
        cboTipoPaciente.DisplayMember = "Descripcion"
        cboTipoPaciente.ValueMember = "IdTipoTarifa"

        cboServicio_SelectedIndexChanged(sender, e)
        cboSubServicio_SelectedIndexChanged(sender, e)
        cboEspecialidad_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        dtpFecha.Value = Date.Now
        cboTipoPaciente.Text = "COMUN"
        txtHora.Text = Date.Now.TimeOfDay.ToString
        txtHistoria.Select()
        cboVia_TextChanged(sender, e)
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarHospitalizaciones()

            Dim dsHospitalizacion As New Data.DataSet
            IdHospitalizacion = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblServicio.Text = dsHospitalizacion.Tables(0).Rows(0)("Piso")
                cboServicio_SelectedIndexChanged(sender, e)
                lblSubServicio.Text = dsHospitalizacion.Tables(0).Rows(0)("Servicio")
                lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                IdHospitalizacion = dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion")
                CalcularEdad(lblFecha.Text, dtpFechaNac.Value.ToShortDateString)
                'Buscar Ubigeo
                Dim dsH As New DataSet
                dsH = objHistoria.BuscarNumero(txtHistoria.Text)
                If dsH.Tables(0).Rows.Count > 0 Then
                    dtpFechaNac.Value = dsH.Tables(0).Rows(0)("FNacimiento")
                    cboSexo.Text = dsH.Tables(0).Rows(0)("Sexo")
                    cboDepartamento.Text = dsH.Tables(0).Rows(0)("Departamento")
                    cboDepartamento_SelectedIndexChanged(sender, e)
                    cboProvincia.Text = dsH.Tables(0).Rows(0)("Provincia")
                    cboProvincia_SelectedIndexChanged(sender, e)
                    cboDistrito.Text = dsH.Tables(0).Rows(0)("Distrito")
                    txtCaserio.Text = dsH.Tables(0).Rows(0)("Distrito")
                End If

                Buscar()

                dtpFecha.Select()
            Else
                MessageBox.Show("Paciente no Registra un Ingreso Pendiente de Hospitalización, Indicar a paciente Sacar Sumario de Ingreso", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                lblServicio.Text = ""
                lblSubServicio.Text = ""
                'btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCIE.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDes.Text)
            txtCIE.Text = ""
            txtDes.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Function VerificarCodigoCIE() As Boolean
        VerificarCodigoCIE = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(0).Text = txtCIE.Text Then VerificarCodigoCIE = True : Exit For
        Next
    End Function

    Private Sub txtCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            If VerificarCodigoCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarCodigo(txtCIE.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_enf")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCIE.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).Selected Then
                    lvTabla.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub cboServicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.Click
        cboServicio_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If IsNumeric(cboServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboSubServicio.Select()
    End Sub

    Private Sub MostrarSubServicios()
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        MostrarSubServicios()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Not IsNumeric(cboCama.SelectedValue) Then MessageBox.Show("Debe seleccionar un número de cama, si no existe comunicarse con Estadística 238", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboCama.Select() : Exit Sub
        If Not IsNumeric(cboResponsable.SelectedValue) Then MessageBox.Show("Debe seleccionar al Especialista que Autoriza el Ingreso, si no existe comunicarse con Estadística 238", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboResponsable.Select() : Exit Sub
        If Not IsNumeric(cboEnfermera.SelectedValue) Then MessageBox.Show("Debe seleccionar a la persona responsable del servicio que realiza el ingreso, si no existe comunicarse con Estadística 238", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboEnfermera.Select() : Exit Sub
        If cboTipoPaciente.Text = "SIS" And (txtSerieSIS.Text = "" Or txtNumeroSIS.Text = "") Then
            MessageBox.Show("Debe ingresar Serie y Numero de SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Select() : Exit Sub
        End If
        If cboTipoPaciente.Text = "SIS" And cboTipoPaciente.Text = "COMUN" And Val(txtNroPre.Text) = "0" Then
            MessageBox.Show("Debe ingresar Numero de Convenio/SOAT/AFOCAT", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroPre.Select() : Exit Sub
        End If

        'Validar Codigo SIS
        If cboTipoPaciente.Text = "SIS" Then
            Dim dsSIS As New DataSet
            Dim CodigoSIS
            dsSIS = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
            If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoPaciente.Text = "COMUN" : txtSerieSIS.Text = "" : txtNumeroSIS.Text = "" : Exit Sub
            CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")
            'Activar para control del sis
            'If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
            '    If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            'End If
            'If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
            '    MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            'End If
        End If
        'Fin de validar Codigo SIS

        'Verificar Tipo de Paciente Convenios para obtener Codigos
        Dim CodigoConvenio As String
        If cboTipoPaciente.Text <> "SIS" And cboTipoPaciente.Text <> "COMUN" And cboTipoPaciente.Text <> "SOAT/AFOCAT" Then
            Dim dsConvenio As New DataSet
            dsConvenio = objConvenio.BuscarCH(txtNroPre.Text, txtHistoria.Text)
            If dsConvenio.Tables(0).Rows.Count = 0 Then MessageBox.Show("Paciente no Registra un Ingreso en el Sistema Por Convenio. Consulta En Cuentas Corrientes", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoPaciente.Text = "COMUN" : txtNroPre.Text = "" : Exit Sub
            CodigoConvenio = dsConvenio.Tables(0).Rows(0)("IdConvenio")

            If dsConvenio.Tables(0).Rows(0)("FechaFinal").ToString <> "" Then
                If dsConvenio.Tables(0).Rows(0)("FechaFinal") < Date.Now.ToShortDateString Then
                    MessageBox.Show("Atencion de Convenio ya fue finalizada con fecha " & dsConvenio.Tables(0).Rows(0)("FechaFinal") & ". Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoPaciente.Text = "COMUN" : txtNroPre.Text = "" : Exit Sub
                End If
            End If
        End If
        'Fin Validar Convenio

        'Verificar Tipo de Paciente SOAT AFOCAT
        Dim CodigoSoat As String
        If cboTipoPaciente.Text = "SOAT/AFOCAT" Then
            Dim dsSoat As New DataSet
            dsSoat = objSoat.BuscarPH(txtNroPre.Text, txtHistoria.Text)
            If dsSoat.Tables(0).Rows.Count > 0 Then
                CodigoSoat = dsSoat.Tables(0).Rows(0)("IdSoat")

                If dsSoat.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                'CodigoSoat = txtNroPre.Text
                MessageBox.Show("Atencion SOAT/AFOCAT ya fue finalizada. Comunicarse con la Oficina de Seguros", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        End If
        'Fin Validar SOAT/AFOCAT

        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Oper = 1 Then
                CodLocal = objIngreso.GrabarP(IdHospitalizacion, dtpFecha.Value.ToShortDateString, txtHora.Text, cboVia.SelectedValue, cboReferido.Text, cboResponsable.SelectedValue, cboCama.SelectedValue, cboEnfermera.SelectedValue, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, txtCaserio.Text, cboTipoPaciente.Text, txtSerieSIS.Text, txtNumeroSIS.Text, txtNroPre.Text)
            Else
                'objCama.Liberar(cboEspecialidad.SelectedValue, CamaAnterior)
                objIngreso.ModificarP(CodLocal, IdHospitalizacion, dtpFecha.Value.ToShortDateString, txtHora.Text, cboVia.SelectedValue, cboReferido.Text, cboResponsable.SelectedValue, cboCama.SelectedValue, cboEnfermera.SelectedValue, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, txtCaserio.Text, cboTipoPaciente.Text, txtSerieSIS.Text, txtNumeroSIS.Text, txtNroPre.Text)
            End If

            'Modificar Datos de Paciente
            objHistoria.GrabarFN(txtHistoria.Text, dtpFechaNac.Value.ToShortDateString)
            objHistoria.GrabarSexo(txtHistoria.Text, cboSexo.Text)

            objIngresoCIE.Eliminar(CodLocal)
            For Me.I = 0 To lvTabla.Items.Count - 1
                objIngresoCIE.Grabar(CodLocal, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text)
            Next

            'Cambiar Estado de Cama
            'objCama.CambiarEstado(cboCama.SelectedValue, "OCUPADO")
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboVia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboVia.KeyDown
        If e.KeyCode = Keys.Enter And cboVia.Text <> "" Then cboTipoPaciente.Select()
    End Sub

    Private Sub cboVia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVia.TextChanged
        If IsNumeric(cboVia.SelectedValue) Then
            If cboVia.Text = "REFERENCIA" Then cboReferido.Enabled = True Else cboReferido.Enabled = False
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCIE.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Function VerificarCIE() As Boolean
        VerificarCIE = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(0).Text = lvDet.SelectedItems(0).SubItems(0).Text Then VerificarCIE = True : Exit For
        Next
    End Function

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If VerificarCIE() Then MessageBox.Show("Diagnóstico de CIE10 ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    txtCIE.Text = ""
                    txtDes.Text = ""
                    Dim Fila As ListViewItem
                    Fila = lvTabla.Items.Add(lvDet.Items(I).SubItems(0).Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(1).Text)
                End If
            Next
            btnRetornar_Click(sender, e)
            txtDes.Select()
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub lvLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLista.SelectedIndexChanged
        If lvLista.SelectedItems.Count > 0 Then
            Dim dsHist As New DataSet
            dsHist = objIngreso.Buscar(IdHospitalizacion)
            If dsHist.Tables(0).Rows.Count > 0 Then
                Oper = 2
                CodLocal = dsHist.Tables(0).Rows(0)("IdIngreso")
                dtpFecha.Value = dsHist.Tables(0).Rows(0)("Fecha")
                txtHora.Text = dsHist.Tables(0).Rows(0)("Hora")
                cboResponsable.Text = dsHist.Tables(0).Rows(0)("Responsable")
                cboServicio.Text = dsHist.Tables(0).Rows(0)("Servicio")
                MostrarSubServicios()
                cboSubServicio.Text = dsHist.Tables(0).Rows(0)("SubServicio")
                MostrarEspecialidades()
                cboEspecialidad.Text = dsHist.Tables(0).Rows(0)("Especialidad")
                MostrarCamas()
                cboCama.Text = dsHist.Tables(0).Rows(0)("Numero")
                CamaAnterior = cboCama.Text
                cboVia.Text = dsHist.Tables(0).Rows(0)("ViaAdmision")
                cboReferido.Text = dsHist.Tables(0).Rows(0)("Referido")
                cboEnfermera.Text = dsHist.Tables(0).Rows(0)("Enfermera")

                lvTabla.Items.Clear()
                Dim dsVer As New DataSet
                dsVer = objIngresoCIE.Buscar(CodLocal)
                For Me.I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("CIE"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Next
            End If
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If IsNumeric(cboSubServicio.SelectedValue) And e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
    End Sub

    Private Sub MostrarEspecialidades()
        cboEspecialidad.Text = ""
        cboCama.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        MostrarEspecialidades()
    End Sub

    Private Sub cboEspecialidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If IsNumeric(cboEspecialidad.SelectedValue) And e.KeyCode = Keys.Enter Then cboCama.Select()
    End Sub

    Private Sub MostrarCamas()
        cboCama.Text = ""
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsCama As New Data.DataSet
            dsCama = objCama.Asignacion(cboEspecialidad.SelectedValue)
            cboCama.DataSource = dsCama.Tables(0)
            cboCama.DisplayMember = "Numero"
            cboCama.ValueMember = "IdCama"
        End If
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        MostrarCamas()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter Then cboVia.Select()
    End Sub

    Private Sub txtHora_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHora.MaskInputRejected

    End Sub

    Private Sub cboVia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboVia.SelectedIndexChanged

    End Sub

    Private Sub cboResponsable_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboResponsable.KeyDown
        If IsNumeric(cboResponsable.SelectedValue) And e.KeyCode = Keys.Enter Then cboServicio.Select()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged

    End Sub

    Private Sub cboCama_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCama.KeyDown
        If IsNumeric(cboCama.SelectedValue) And e.KeyCode = Keys.Enter Then cboEnfermera.Select()
    End Sub

    Private Sub cboCama_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCama.SelectedIndexChanged

    End Sub

    Private Sub cboEnfermera_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEnfermera.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEnfermera.SelectedValue) Then txtCIE.Select()
    End Sub

    Private Sub cboEnfermera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEnfermera.SelectedIndexChanged

    End Sub

    Private Sub txtCIE_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCIE.TextChanged

    End Sub

    Private Sub cboDepartamento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDepartamento.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboDepartamento.SelectedValue) Then cboProvincia.Select()
    End Sub

    Private Sub cboDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) Then
            Dim dsPro As New DataSet
            dsPro = objUbigeo.Provincia(cboDepartamento.SelectedValue)
            cboProvincia.DataSource = dsPro.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
        End If
    End Sub

    Private Sub cboProvincia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboProvincia.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboProvincia.SelectedValue) Then cboDistrito.Select()
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) And IsNumeric(cboProvincia.SelectedValue) Then
            Dim dsDist As New DataSet
            dsDist = objUbigeo.Distrito(cboDepartamento.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDist.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
        End If
    End Sub

    Private Sub dtpFechaNac_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaNac.ValueChanged
        If lblFecha.Text <> "" Then CalcularEdad(lblFecha.Text, dtpFechaNac.Value.ToShortDateString)
    End Sub

    Private Sub btnRetBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetBPac.Click
        gbBPac.Visible = False
    End Sub

    Private Sub btnBPac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPac.Click
        gbBPac.Visible = True
        txtFPac.Select()
    End Sub

    Private Sub txtFPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPac.KeyDown
        If txtFPac.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtFPac.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvBPac.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub lvBPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBPac.KeyDown
        If e.KeyCode = Keys.Enter And lvBPac.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvBPac.SelectedItems(0).SubItems(0).Text
            gbBPac.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub cboTipoPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoPaciente.KeyDown
        If cboTipoPaciente.Text = "COMUN" And e.KeyCode = Keys.Enter Then cboReferido.Select() : Exit Sub
        If cboTipoPaciente.Text = "SIS" And e.KeyCode = Keys.Enter Then txtSerieSIS.Select() : Exit Sub
        If cboTipoPaciente.Text <> "" And e.KeyCode = Keys.Enter Then txtNroPre.Select()
    End Sub

    Private Sub cboTipoPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPaciente.SelectedIndexChanged

    End Sub

    Private Sub txtSerieSIS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerieSIS.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumeroSIS.Select()
    End Sub

    Private Sub txtSerieSIS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieSIS.TextChanged

    End Sub

    Private Sub txtNroPre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroPre.KeyDown
        If e.KeyCode = Keys.Enter Then txtSerieSIS.Select()
    End Sub

    Private Sub txtNroPre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroPre.LostFocus
        If Val(txtNroPre.Text) > 0 And cboTipoPaciente.Text = "SOAT/AFOCAT" Then
            Dim dsVer As New DataSet
            dsVer = objSoat.BuscarFicha(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If Val(dsVer.Tables(0).Rows(0)("IdSoat")) <> Val(txtNroPre.Text) Then
                    MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroPre.Text = ""
                    txtNroPre.Select()
                End If
            Else
                MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroPre.Text = ""
                txtNroPre.Select()
            End If
        End If
        If Val(txtNroPre.Text) > 0 And cboTipoPaciente.Text <> "SOAT/AFOCAT" Then
            Dim dsVer As New DataSet
            dsVer = objConvenio.BuscarCH(txtNroPre.Text, txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                If dsVer.Tables(0).Rows(0)("Tipo") = "CONSULTA EXTERNA" Then
                    MessageBox.Show("El Convenio fue registrador como CONSULTA EXTERNA, Verifique la información en Cuentas Corrientes", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroPre.Text = ""
                    txtNroPre.Select()
                End If
            Else
                MessageBox.Show("Debe verificar que el numero de Preliquidación esté bien registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroPre.Text = ""
                txtNroPre.Select()
            End If
        End If
    End Sub

    Private Sub txtNroPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroPre.TextChanged

    End Sub

    Private Sub txtNumeroSIS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroSIS.KeyDown
        If e.KeyCode = Keys.Enter And cboReferido.Enabled Then cboReferido.Select()
        If e.KeyCode = Keys.Enter And Not cboReferido.Enabled Then cboResponsable.Select()
    End Sub

    Private Sub txtNumeroSIS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroSIS.LostFocus
        If Val(txtNumeroSIS.Text) > 0 Then
            Dim dsVer As New DataSet
            dsVer = objSIS.ConsultarLN(txtSerieSIS.Text, txtNumeroSIS.Text, txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Debe verificar que este bien escrito la SERIE y NUMERO de lote SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtSerieSIS.Text = "" : txtNumeroSIS.Text = 0 : txtSerieSIS.Select() : Exit Sub
            End If
        End If
    End Sub

    Private Sub txtNumeroSIS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroSIS.TextChanged

    End Sub

    Private Sub cboReferido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReferido.KeyDown
        If e.KeyCode = Keys.Enter Then cboResponsable.Select()
    End Sub

    Private Sub cboReferido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReferido.SelectedIndexChanged

    End Sub

    Private Sub cboDistrito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDistrito.KeyDown
        If IsNumeric(cboDistrito.SelectedValue) And e.KeyCode = Keys.Enter Then txtCaserio.Select()
    End Sub

    Private Sub cboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.SelectedIndexChanged

    End Sub

    Private Sub txtCaserio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaserio.KeyDown
        If e.KeyCode = Keys.Enter Then cboSexo.Select()
    End Sub

    Private Sub txtCaserio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaserio.TextChanged

    End Sub

    Private Sub cboSexo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If cboSexo.Text <> "" And e.KeyCode = Keys.Enter Then dtpFecha.Select()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSexo.SelectedIndexChanged

    End Sub

    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodigo.Click
        frmCodigo.Show()
    End Sub

    Private Sub txtFPac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFPac.TextChanged

    End Sub

    Private Sub lvBPac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBPac.SelectedIndexChanged

    End Sub
End Class