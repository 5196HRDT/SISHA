Public Class frmPapeletaHospitalizacion
    Dim objPapeleta As New PapeletaHospitalizacion
    Dim objPapeletaCIE As New PapeletaHospitalizacionCIE
    Dim objServicio As New ServicioH
    Dim objSubServicio As New SubServicioH
    Dim objEspecialidad As New EspecialidadH
    Dim objCie As New CIE10HE
    Dim objHistoria As New Historia

    Dim Filtro As String

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
        If Val(EdadA) > 0 Then
            lblEdad.Text = EdadA & " A"
        ElseIf Val(EdadM) > 0 Then
            lblEdad.Text = EdadM & " M"
        Else
            lblEdad.Text = EdadD & " D"
        End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            lblFNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(Date.Now.ToShortDateString, lblFNac.Text)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmPapeletaHospitalizacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"

        cboServicio_SelectedIndexChanged(sender, e)
        cboSubServicio_SelectedIndexChanged(sender, e)

        'Datos de Medico
        lblMedico.Text = NomMedico
        lblEspecialidad.Text = vEspecialidad
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        gbConsulta.Visible = False
        gbPaciente.Visible = False
        lvTabla.Items.Clear()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        dtpFecha.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHistoria.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub cboServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboServicio.SelectedValue) Then cboSubServicio.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboServicio.SelectedIndexChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboSubServicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSubServicio.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboSubServicio.SelectedValue) Then cboEspecialidad.Select()
    End Sub

    Private Sub cboSubServicio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubServicio.SelectedIndexChanged
        cboEspecialidad.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub cboEspecialidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboEspecialidad.SelectedValue) Then txtCie.Select()
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged

    End Sub

    Private Sub txtCie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCie.KeyDown
        If e.KeyCode = Keys.Enter And txtCie.Text = "" Then txtDescripcion.Select() : Exit Sub
        If txtCie.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New Data.DataSet
            dsCIE = objCie.BuscarCodigo(txtCie.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDescripcion.Enabled = False
                txtDescripcion.Text = dsCIE.Tables(0).Rows(0)("desc_enf")
                txtDescripcion.Enabled = True
                cboTipoDiagnostico.Select()
            Else
                txtDescripcion.Text = ""
                txtCie.Select()
                MessageBox.Show("Codigo de CIE 10 no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCie.TextChanged
        If txtCie.Text = "" Then txtDescripcion.Text = ""
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then txtFiltro.Text = txtDescripcion.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select() : Filtro = "CF"
    End Sub

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub lvDet_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            If lvDet.SelectedItems.Count > 0 Then
                txtCie.Text = lvDet.SelectedItems(0).SubItems(0).Text
                txtDescripcion.Text = lvDet.SelectedItems(0).SubItems(1).Text
                btnRetornar_Click(sender, e)
                cboTipoDiagnostico.Select()
            End If
            btnRetornar_Click(sender, e)
        End If
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged
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

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Solicitar Hospitalización de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim IdPapeleta As String
            IdPapeleta = objPapeleta.Grabar(Date.Now.ToShortDateString, Date.Now.ToShortTimeString, lblMedico.Text, My.Computer.Name, vIdMedico, lblMedico.Text, "CONSULTA EXTERNA", lblEspecialidad.Text, txtHistoria.Text, lblPaciente.Text, lblFNac.Text, lblEdad.Text, lblSexo.Text, dtpFecha.Value.ToShortDateString, txtMotivo.Text, txtObservaciones.Text, cboServicio.Text, cboSubServicio.Text, cboEspecialidad.Text, "INGRESO")
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                objPapeletaCIE.Grabar(IdPapeleta, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(2).Text)
            Next

            MessageBox.Show("Papeleta Generada Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub
            txtMotivo.Select()
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
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

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDiagnostico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDiagnostico.KeyDown
        If e.KeyCode = Keys.Enter And txtCie.Text <> "" And txtDescripcion.Text <> "" And cboTipoDiagnostico.Text <> "" Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtCie.Text)
            Fila.SubItems.Add(txtDescripcion.Text)
            Fila.SubItems.Add(cboTipoDiagnostico.Text)
            txtDescripcion.Text = ""
            txtCie.Text = ""
            cboTipoDiagnostico.Text = ""
            txtCie.Select()
        End If
    End Sub

    Private Sub cboTipoDiagnostico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoDiagnostico.SelectedIndexChanged

    End Sub
End Class