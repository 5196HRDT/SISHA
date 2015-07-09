Public Class frmInforme
    Dim objInforme As New clsInformeEKG
    Dim objEKGCie As New clsInformeEKGCie
    Dim objHistoria As New clsHistoria
    Dim objCie As New clsCie10
    Dim objMedico As New clsMedico
    Dim objConsulta As New clsConsulta
    Dim objSIS As New clsSIS
    Dim objTipoPaciente As New clsTipoPacienteHIS

    Dim CodLocal As String
    Dim Oper As Integer

    Dim Filtro As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPacienteH.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            lblFechaNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString
            lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
            If dsHistorias.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                Dim EdadA, EdadM, EdadD As String
                dfin = Date.Now.ToShortDateString
                dinicio = dsHistorias.Tables(0).Rows(0)("FNACIMIENTO")
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

                    EdadD = Microsoft.VisualBasic.Day(dinicio)
                    If Val(EdadD) > Date.Now.Day Then
                        EdadD = Val(EdadD) - Date.Now.Day
                    ElseIf Val(EdadD) < Date.Now.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = Date.Now.Day - EdadD
                        EdadD = DameDiasMes(Date.Now.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If
                lblEdad.Text = EdadA & " A " & EdadM & " M " & EdadD & " D "
            Else
                lblEdad.Text = ""
            End If
        Else
            MessageBox.Show("Paciente no se encuentra registrado en el Sistema", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        dtpFecha.Value = Date.Now
        gbPaciente.Visible = False
        gbConsulta.Visible = False

        'Medico Tratante
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboSolicitado.DataSource = dsMedico.Tables(0)
        cboSolicitado.DisplayMember = "NMedico"
        cboSolicitado.ValueMember = "IdMedico"

        'Medico Cardiolgo
        Dim dsMedicoC As New DataSet
        dsMedicoC = objMedico.BuscarEspecialidad("CARDIOLOGIA")
        cboCardiologo.DataSource = dsMedicoC.Tables(0)
        cboCardiologo.DisplayMember = "NMedico"
        cboCardiologo.ValueMember = "IdMedico"

        'Tipo Paciente
        Dim dsTipoPaciente As New DataSet
        dsTipoPaciente = objTipoPaciente.Combo
        cboTipo.DataSource = dsTipoPaciente.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipo"
    End Sub

    Private Sub BuscarHistorial()
        Dim dsVer As New DataSet
        dsVer = objInforme.Buscar(txtHistoria.Text)
        Dim I As Integer
        Dim FIla As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            FIla = lvH.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaToma"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Origen"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoDiagnostico"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Conclusiones"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("MedicoTratante"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Examen"))
            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
        Next
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()

            BuscarHistorial()
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnBuscarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnRetornarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter And txtPaciente.Text.Length > 0 Then
            Dim dsHC As New DataSet
            dsHC = objHistoria.BuscarNombres(txtPaciente.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsHC.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsHC.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Fnacimiento").ToString)
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
        txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
        gbPaciente.Visible = False
        txtHistoria_KeyDown(sender, e)
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub txtCie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCie.KeyDown
        If e.KeyCode = Keys.Enter And txtCie.Text = "" Then txtDescripcion.Select() : Exit Sub
        If txtCie.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New Data.DataSet
            dsCIE = objCie.BuscarCodigo(txtCie.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDescripcion.Enabled = False
                txtDescripcion.Text = dsCIE.Tables(0).Rows(0)("desc_enf")
                txtDescripcion.Enabled = True
                txtDescripcion.Select()
            Else
                txtDescripcion.Text = ""
                txtCie.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If txtDescripcion.Text <> "" And txtCie.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtCie.Text)
            Fila.SubItems.Add(txtDescripcion.Text)
            txtDescripcion.Text = ""
            txtCie.Text = ""
            txtCie.Select()
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then txtFiltro.Text = txtDescripcion.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select() : Filtro = "CF"
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
            dsCIE = objCie.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
            Next
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If lvDet.SelectedItems.Count > 0 Then
                txtCie.Text = lvDet.SelectedItems(0).SubItems(0).Text
                txtDescripcion.Text = lvDet.SelectedItems(0).SubItems(1).Text
                txtDescripcion.Select()
            End If
            btnRetornar_Click(sender, e)
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.SelectedItems.Count > 0 Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        lvTabla.Items.Clear()
        lvH.Items.Clear()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        cboTipo.Text = "COMUN"
        dtpFecha.Value = Date.Now
        txtPac.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboOrigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then txtHistoria.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub cboSolicitado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSolicitado.KeyDown
        If e.KeyCode = Keys.Enter And cboSolicitado.Text <> "" Then cboExamen.Select()
    End Sub

    Private Sub cboSolicitado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSolicitado.SelectedIndexChanged

    End Sub

    Private Sub cboExamen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboExamen.KeyDown
        If e.KeyCode = Keys.Enter And cboExamen.Text <> "" Then cboTipoDx.Select()
    End Sub

    Private Sub cboExamen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamen.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDx.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoDx.Text <> "" Then txtCie.Select()
    End Sub

    Private Sub cboTipoDx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDx.SelectedIndexChanged

    End Sub

    Private Sub cboCardiologo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCardiologo.KeyDown
        If IsNumeric(cboCardiologo.SelectedValue) And e.KeyCode = Keys.Enter Then btnGrabar.Select()
    End Sub

    Private Sub cboCardiologo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCardiologo.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Informe?", "Mensaje de Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Oper = 1 Then
                CodLocal = objInforme.Grabar(0, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name, dtpFecha.Value.ToShortDateString, cboOrigen.Text, txtHistoria.Text, lblPacienteH.Text, lblSexo.Text, lblEdad.Text, cboExamen.Text, cboTipoDx.Text, txtConclusiones.Text, cboCardiologo.SelectedValue, cboCardiologo.Text, cboSolicitado.Text, cboTipo.Text)
            ElseIf Oper = 2 Then
                objInforme.Modificar(CodLocal, dtpFecha.Value.ToShortDateString, cboOrigen.Text, txtHistoria.Text, lblPacienteH.Text, lblSexo.Text, lblEdad.Text, cboExamen.Text, cboTipoDx.Text, txtConclusiones.Text, cboCardiologo.SelectedValue, cboCardiologo.Text, cboSolicitado.Text, cboTipo.Text)
            End If

            objEKGCie.Eliminar(CodLocal)
            For I = 0 To lvTabla.Items.Count - 1
                objEKGCie.Grabar(CodLocal, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text)
            Next

            'ppdDocumento.ShowDialog()

            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvH.SelectedIndexChanged
        If lvH.SelectedItems.Count > 0 Then
            ControlesAD(Me, True)
            Botones(False, True, True, False)
            Oper = 2
            CodLocal = lvH.SelectedItems(0).SubItems(0).Text
            dtpFecha.Value = lvH.SelectedItems(0).SubItems(1).Text
            cboOrigen.Text = lvH.SelectedItems(0).SubItems(2).Text
            txtHistoria.Text = lvH.SelectedItems(0).SubItems(3).Text
            lblPacienteH.Text = lvH.SelectedItems(0).SubItems(4).Text
            lblSexo.Text = lvH.SelectedItems(0).SubItems(5).Text
            lblEdad.Text = lvH.SelectedItems(0).SubItems(6).Text
            cboTipoDx.Text = lvH.SelectedItems(0).SubItems(7).Text
            txtConclusiones.Text = lvH.SelectedItems(0).SubItems(8).Text
            cboCardiologo.Text = lvH.SelectedItems(0).SubItems(9).Text
            cboSolicitado.Text = lvH.SelectedItems(0).SubItems(10).Text
            cboExamen.Text = lvH.SelectedItems(0).SubItems(11).Text
            cboTipo.Text = lvH.SelectedItems(0).SubItems(12).Text

            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsCie As New DataSet
            dsCie = objEKGCie.Buscar(CodLocal)
            For I = 0 To dsCie.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsCie.Tables(0).Rows(I)("Cie"))
                Fila.SubItems.Add(dsCie.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
    End Sub

    Private Function Verificar(ByVal Procedimiento As String) As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(4).Text = Procedimiento Then Verificar = True : Exit For
        Next
    End Function

    Private Sub txtPac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPac.KeyDown
        lvReq.Items.Clear()
        If e.KeyCode = Keys.Enter And txtPac.Text <> "" Then
            Dim dsVer As New DataSet

            'Buscar Consulta Externa
            dsVer = objConsulta.BuscarElectrocardiograma(txtPac.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim Solicitante As String = ""

            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvReq.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion"))
                If dsVer.Tables(0).Rows(I)("UsuarioRegistro").ToString.Length > 5 Then Solicitante = dsVer.Tables(0).Rows(I)("UsuarioRegistro") Else Solicitante = dsVer.Tables(0).Rows(I)("Solicitante")
                Fila.SubItems.Add(Solicitante)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                Fila.SubItems.Add("CONSULTA EXTERNA")
            Next

            'Buscar SIS
            dsVer = objSIS.BuscarElectrocardiograma(txtPac.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If Not Verificar(dsVer.Tables(0).Rows(I)("Descripcion")) Then
                    Fila = lvReq.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(UsuarioSistema)
                    Fila.SubItems.Add("SIS")
                    Fila.SubItems.Add("SIS")
                End If
            Next
        End If
    End Sub

    Private Sub lvReq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvReq.SelectedIndexChanged
        cboTipo.Text = ""
        cboExamen.Text = ""
        cboTipoDx.Text = ""
        cboSolicitado.Text = ""
        cboOrigen.Text = ""
        lvH.Items.Clear()
        If lvReq.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvReq.SelectedItems(0).SubItems(1).Text
            cboTipo.Text = lvReq.SelectedItems(0).SubItems(3).Text
            cboExamen.Text = lvReq.SelectedItems(0).SubItems(4).Text
            cboTipoDx.Text = lvReq.SelectedItems(0).SubItems(5).Text
            cboSolicitado.Text = lvReq.SelectedItems(0).SubItems(6).Text
            cboOrigen.Text = lvReq.SelectedItems(0).SubItems(8).Text
            BuscarHistoria()
            BuscarHistorial()
        End If
    End Sub

    Private Sub txtPac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPac.TextChanged

    End Sub
End Class