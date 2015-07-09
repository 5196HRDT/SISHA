Public Class frmSolicitudExa
    Dim objCupoImagenes As New clsCupoImagenes
    Dim objConsulta As New clsConsultaExterna
    Dim objMedico As New clsMedico
    Dim objSIS As New clsSIS
    Dim objSoat As New clsSOAT
    Dim objConvenio As New clsConvenio
    Dim objInterconsultaE As New clsInterconsulta
    Dim objComprobante As New clsComprobante

    Private Sub BuscarCupos()
        If cboTurno.Text = "" Then Exit Sub
        'Buscar
        lvCita.Items.Clear()
        Dim dsVer As New DataSet
        Dim Fila As ListViewItem
        Dim I As Integer
        dsVer = objCupoImagenes.Buscar(dtpFecha.Value.ToShortDateString, cboTurno.Text, cboTipo.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCita.Items.Add(dsVer.Tables(0).Rows(I)("IdCupo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
        Next
    End Sub

    Private Function Verificar(ByVal Historia As String, ByVal IdProcedimiento As String) As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(10).Text = IdProcedimiento And lvTabla.Items(I).SubItems(3).Text = Historia Then Verificar = True : Exit For
        Next
    End Function

    Private Sub Buscar()
        If txtPaciente.Text = "" Then MessageBox.Show("Debe ingresar información de Paciente a Buscar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPaciente.Select() : Exit Sub
        btnBuscar.Enabled = False
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        Dim dsConsulta As New DataSet

        Dim Tipo As String
        If cboTipo.Text = "ECOGRAFIA" Then Tipo = 2 Else Tipo = 1
        Dim I As Integer
        Dim Fila As ListViewItem

        If cboOrigen.Text = "CONSULTA EXTERNA" Then
            'Buscar de Consultorios
            dsVer = objConsulta.BuscarExaAtencionRayos(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "RAYOS", "", txtPaciente.Text, Tipo)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(Format(Val(dsVer.Tables(0).Rows(I)("Cantidad")), "#0.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion"))
                'Buscar Medico
                If Val(dsVer.Tables(0).Rows(I)("IdCupo")) > 0 Then
                    dsConsulta = objConsulta.BuscarCupo(dsVer.Tables(0).Rows(0)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Responsable"))
                    Else
                        dsConsulta = objInterconsultaE.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                        If dsConsulta.Tables(0).Rows.Count > 0 Then Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Responsable")) Else Fila.SubItems.Add("")
                    End If
                Else
                    Fila.SubItems.Add("")
                End If
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdExamen"))

                'Agregar Diagnosticos
                If dsVer.Tables(0).Rows(I)("IdCupo") > 0 Then
                    dsConsulta = objConsulta.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                    Else
                        dsConsulta = objInterconsultaE.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                        If dsConsulta.Tables(0).Rows.Count > 0 Then
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                        Else
                            Fila.SubItems.Add("")
                            Fila.SubItems.Add("")
                            Fila.SubItems.Add("")
                        End If
                    End If
                Else
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                End If

                'Lote SIS
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                'Precio
                Fila.SubItems.Add("")
                'Origen
                Fila.SubItems.Add("CONSULTA")
                Application.DoEvents()
            Next


            'Buscar de Comprobantes
            dsVer = objComprobante.BuscarRayDocEmergencia(txtPaciente.Text, cboTipo.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("NHistoria").ToString, dsVer.Tables(0).Rows(I)("IdServicioItem")) Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdComprobante"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubServicio"))
                    Fila.SubItems.Add("COMUN")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#0.00"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    'Lote SIS
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    'Precio
                    Fila.SubItems.Add(0)
                    'Origen
                    Fila.SubItems.Add("COMPROBANTE")
                End If
                Application.DoEvents()
            Next


        End If

        'Buscar SIS
        dsVer = objSIS.BuscarImgAtencion(txtPaciente.Text, cboTipo.Text, cboOrigen.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            If Not Verificar(dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("IdProcedimiento")) Then
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspecialidad"))
                Fila.SubItems.Add("SIS")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdProcedimiento"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                'Lote SIS
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lote"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Numero"))
                'Precio
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                'Origen
                Fila.SubItems.Add("SIS")
                Application.DoEvents()
            End If
        Next

        'Buscar Convenios
        dsVer = objConvenio.BuscarDIAtencion(txtPaciente.Text, cboOrigen.Text, cboTipo.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            If Not Verificar(dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("IdProcedimiento")) Then
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoConvenio"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdProcedimiento"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                'Lote SIS
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdConvenio"))
                'Precio
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                'Origen
                Fila.SubItems.Add("CONVENIO")
                Application.DoEvents()
            End If
        Next

        'Buscar SOAT/AFOCAT
        dsVer = objSoat.BuscarExaRad(txtPaciente.Text, cboOrigen.Text, cboTipo.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            'If Not Verificar(dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("IdTarifario")) Then
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdDet"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspecialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdTarifario"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'Lote SIS
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdSoat"))
            'Precio
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
            'Origen
            Fila.SubItems.Add("SOAT")
            Application.DoEvents()
            'End If
        Next

        'Buscar Certificado Medico
        If cboOrigen.Text = "CONSULTA EXTERNA" And cboTipo.Text = "RADIOGRAFIA" Then
            dsVer = objComprobante.BuscarRayCertificado(txtPaciente.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("NHistoria").ToString, dsVer.Tables(0).Rows(I)("IdServicioItem")) Then
                    Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdComprobante"))
                    Fila.SubItems.Add("TRAMITE DOCUMENTARIO")
                    Fila.SubItems.Add("CERTIFICADO")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                    Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#0.00"))
                    Fila.SubItems.Add("RADIOGRAFIA")
                    Fila.SubItems.Add("RADIOGRAFIA DE TORAX F (1)")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("1742")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    'Lote SIS
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add("")
                    'Precio
                    Fila.SubItems.Add(0)
                    'Origen
                    Fila.SubItems.Add("CERTIFICADO")
                End If
                Application.DoEvents()
            Next
        End If
        btnBuscar.Enabled = True
        MessageBox.Show("Datos encontrado hasta el momento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dtpF1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub btnRecepcionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecepcionar.Click
        If lvTabla.Items.Count > 0 Then
            gbCita.Visible = True
            lblTipo.Text = lvTabla.Items(0).SubItems(2).Text
            lblHistoria.Text = lvTabla.Items(0).SubItems(3).Text
            lblPaciente.Text = lvTabla.Items(0).SubItems(4).Text
            lblCie1.Text = lvTabla.Items(0).SubItems(11).Text
            lblCie2.Text = lvTabla.Items(0).SubItems(12).Text
            lblCie3.Text = lvTabla.Items(0).SubItems(13).Text
            cboTurno.Text = ""
            txtHora.Text = ""
            dtpFecha.Value = Date.Now
            dtpFecha.Select()

            Dim Indicaciones As String
            For I = 0 To lvTabla.Items.Count - 1
                If I = 0 Then
                    Indicaciones = lvTabla.Items(I).SubItems(8).Text
                Else
                    If lvTabla.Items(I).SubItems(8).Text <> "" Then Indicaciones = Indicaciones & ", " & lvTabla.Items(I).SubItems(8).Text
                End If
            Next
            txtIndicacion.Text = Indicaciones

            lvCita.Items.Clear()
            BuscarCupos()
            'If MessageBox.Show("Se ha recepcionado Orden de Atención de Paciente?", "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            '    objConsulta.MuestraTomada(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), "", My.Computer.Name)
            'End If
            'Buscar()
        End If
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtPaciente.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub cboOrigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then cboTipo.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub frmSolicitudExa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub frmSolicitudExa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboOrigen.Text = "CONSULTA EXTERNA"
        cboTipo.Text = "ECOGRAFIA"
        gbCita.Visible = False

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboTurno.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        BuscarCupos()
    End Sub

    Private Sub cboTurno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTurno.KeyDown
        If e.KeyCode = Keys.Enter And cboTurno.Text <> "" Then txtHora.Select()
    End Sub

    Private Sub cboTurno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTurno.LostFocus
        Select Case cboTurno.Text
            Case "MAÑANA"
                txtHora.Text = "07:00"
            Case "TARDE"
                txtHora.Text = "13:00"
            Case "NOCHE"
                txtHora.Text = "19:00"
        End Select
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged
        BuscarCupos()
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbCita.Visible = False
    End Sub

    Private Sub txtHora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text <> "" Then cboMedico.Select()
    End Sub

    Private Sub txtHora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHora.TextChanged

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de asignar Cita?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtIndicacion.Text = "" Then MessageBox.Show("Debe ingresar las indicaciones del Médico Solicitante", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim IdCupo As String
            IdCupo = objCupoImagenes.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vUsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, txtHora.Text, cboTurno.Text, cboTipo.Text, cboOrigen.Text, lvTabla.Items(0).SubItems(1).Text, lblTipo.Text, lblHistoria.Text, lblPaciente.Text, txtIndicacion.Text, cboMedico.Text, lblCie1.Text, lblCie2.Text, lblCie3.Text)

            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).SubItems(2).Text = "COMUN" Then
                    objConsulta.FijarCupoRayos(lvTabla.Items(I).SubItems(0).Text, IdCupo)
                    objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vUsuarioSistema, My.Computer.Name)
                End If
                If lvTabla.Items(I).SubItems(2).Text = "SIS" Then
                    objSIS.AtencionProcedimientoSisEq(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name)
                    If lvTabla.Items(I).SubItems(17).Text = "SIS" Then
                        objConsulta.GrabarExaSISCEMedRX(0, lvTabla.Items(I).SubItems(10).Text, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(16).Text, lvTabla.Items(I).SubItems(5).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name, "RAYOS", cboTipo.Text, "SIS", 0, lvTabla.Items(I).SubItems(14).Text, lvTabla.Items(I).SubItems(15).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, lvTabla.Items(I).SubItems(1).Text, txtIndicacion.Text, cboMedico.Text, IdCupo, cboOrigen.Text)
                    ElseIf lvTabla.Items(I).SubItems(17).Text = "COMUN" Then
                        objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vUsuarioSistema, My.Computer.Name)
                    End If
                End If
                If lvTabla.Items(I).SubItems(2).Text = "CONVENIO" Then
                    objConvenio.AtencionCon(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name)
                    If lvTabla.Items(I).SubItems(17).Text = "CONVENIO" Then
                        objConsulta.GrabarExaSISCEMedRX(0, lvTabla.Items(I).SubItems(10).Text, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(16).Text, lvTabla.Items(I).SubItems(5).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name, "RAYOS", cboTipo.Text, "CONVENIO", lvTabla.Items(I).SubItems(15).Text, lvTabla.Items(I).SubItems(14).Text, 0, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, lvTabla.Items(I).SubItems(1).Text, txtIndicacion.Text, cboMedico.Text, IdCupo, cboOrigen.Text)
                    ElseIf lvTabla.Items(I).SubItems(17).Text = "COMUN" Then
                        objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vUsuarioSistema, My.Computer.Name)
                    End If
                End If
                If lvTabla.Items(I).SubItems(2).Text = "SOAT/AFOCAT" Then
                    objSoat.AtencionProc(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), My.Computer.Name, vUsuarioSistema)
                    If lvTabla.Items(I).SubItems(17).Text = "CONVENIO" Then
                        objConsulta.GrabarExaSISCEMedRX(0, lvTabla.Items(I).SubItems(10).Text, lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(16).Text, lvTabla.Items(I).SubItems(5).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), vUsuarioSistema, My.Computer.Name, "RAYOS", cboTipo.Text, "SOAT/AFOCAT", lvTabla.Items(I).SubItems(15).Text, lvTabla.Items(I).SubItems(14).Text, 0, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, lvTabla.Items(I).SubItems(1).Text, txtIndicacion.Text, cboMedico.Text, IdCupo, cboOrigen.Text)
                    ElseIf lvTabla.Items(I).SubItems(17).Text = "COMUN" Then
                        objConsulta.MuestraTomada(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, vUsuarioSistema, My.Computer.Name)
                    End If
                End If
            Next

            btnRetornar_Click(sender, e)
            txtPaciente.Text = ""
            lvTabla.Items.Clear()
        End If
    End Sub

    Private Sub cboMedico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If IsNumeric(cboMedico.SelectedValue) And e.KeyCode = Keys.Enter Then txtIndicacion.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub gbCita_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbCita.Enter

    End Sub
End Class
