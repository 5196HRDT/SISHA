Public Class frmAtencionExa
    Dim objInforme As New clsInformeGastro
    Dim objInformeCIE As New clsInformeGastroCIE
    Dim objConsulta As New clsConsultaExterna
    Dim objHistoria As New clsHistoriaClinica
    Dim objMedico As New clsMedico
    Dim objCIE10 As New clsCIE

    Dim Origen As String

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objConsulta.BuscarExaSubTipo(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "GASTROENTEROLOGIA", txtPaciente.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("UsuarioRegistro"))
        Next
    End Sub

    Private Sub frmAtencionExa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Buscar()
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
        lblEdadA.Text = EdadA
        lblTEdadA.Text = "A"
        lblEdadM.Text = EdadM
        lblTEdadM.Text = "M"
        'lblEdadD.Text = EdadD
        'lblTEdadD.Text = "D"
    End Sub


    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            Origen = "CONSULTA EXTERNA"
            lblHistoria.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            lblExamen.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            txtIndicaciones.Text = lvTabla.SelectedItems(0).SubItems(8).Text
            lblMedico.Text = lvTabla.SelectedItems(0).SubItems(9).Text

            Dim dsHistoria As New DataSet
            Dim FNacimiento As Date
            dsHistoria = objHistoria.Buscar(lblHistoria.Text)

            'Calcular Edad
            If dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                FNacimiento = dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString
            Else
                FNacimiento = InputBox("Ingrear Fecha de Nacimiento de Paciente", "Información de Paciente")
            End If
            CalcularEdad(dtpF1.Value.ToShortDateString, FNacimiento)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo"), 1)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Botones(True, False, False, True)
        ControlesAD(Me, False)
        Limpiar(Me)
        lvTabla.Items.Clear()
        lvTablaE.Items.Clear()
        lvTablaH.Items.Clear()
        lblExamen.Text = ""
        lblMedico.Text = ""
        txtIndicaciones.Text = ""
        cboMedico.Text = ""
        txtInforme.Text = ""
        lvCIE.Items.Clear()
        btnBuscar.Enabled = False
        gbCIE.Visible = False
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        btnBuscar.Enabled = True
        dtpF1.Select()
        Botones(False, True, True, False)
    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then txtPaciente.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub cboMedico_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then txtInforme.Select()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" And txtDescripcion.Text <> "" Then
            Dim Fila As ListViewItem
            Fila = lvCIE.Items.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDescripcion.Text)
            txtDescripcion.Text = ""
            txtCIE.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text <> "" And txtDescripcion.Enabled Then txtFiltro.Text = txtDescripcion.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbCIE.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsCIE As New DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvFiltro.Items.Clear()
            dsCIE = objCIE10.BuscarFiltro(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvFiltro.Items.Add(dsCIE.Tables(0).Rows(I)("cod_gen"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_enf"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Definitivo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MinTipo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxEdad"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("MaxTipo"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("Emergencia"))
            Next
            If lvFiltro.Items.Count > 0 Then lvFiltro.Select()
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lvFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If lvFiltro.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            txtCIE.Text = lvFiltro.SelectedItems(0).SubItems(0).Text
            txtDescripcion.Enabled = False
            txtDescripcion.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
            txtDescripcion.Enabled = True
            txtDescripcion.Select()
            gbCIE.Visible = False
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvFiltro.SelectedIndexChanged

    End Sub

    Private Sub lvCIE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCIE.KeyDown
        If lvCIE.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            lvCIE.Items.RemoveAt(lvCIE.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvCIE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCIE.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        gbCIE.Visible = False
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtInforme.Text = "" Then MessageBox.Show("Debe ingresar Informe de Procedimiento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtInforme.Select() : Exit Sub
        If Not IsNumeric(cboMedico.SelectedValue) Then MessageBox.Show("Debe Seleccionar Médico Responsable del Informe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboMedico.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Guardar el Informe?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Fecha As String = Date.Now.ToShortDateString
            Dim Hora As String = Date.Now.ToShortTimeString
            Dim IdInforme As String

            Dim rsVer As New DataSet
            If Origen = "CONSULTA EXTERNA" Then
                rsVer = objConsulta.BuscarDetId(lblHistoria.Tag)
            End If

            IdInforme = objInforme.Grabar(Fecha, Hora, UsuarioSistema, My.Computer.Name, Fecha, Hora, Origen, rsVer.Tables(0).Rows(0)("ServicioCE"), rsVer.Tables(0).Rows(0)("TipoPaciente"), lblHistoria.Text, lblPaciente.Text, lblEdadA.Text, lblEdadM.Text, lblSexo.Text, rsVer.Tables(0).Rows(0)("SerieSIS"), rsVer.Tables(0).Rows(0)("NumeroSIS"), rsVer.Tables(0).Rows(0)("NroPreliquidacion"), lblExamen.Text, lblMedico.Text, txtIndicaciones.Text, txtInforme.Text, cboMedico.SelectedValue, cboMedico.Text)

            'Toma Muestra
            objConsulta.MuestraTomada(lblHistoria.Tag, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
            'Registro Resultado
            objConsulta.GrabarResultados(lblHistoria.Tag, txtInforme.Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)

            'Grabar detalle de CIE
            Dim I As Integer
            For I = 0 To lvCIE.Items.Count - 1
                objInformeCIE.Grabar(IdInforme, lvCIE.Items(I).SubItems(0).Text, lvCIE.Items(I).SubItems(1).Text)
            Next
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtCIE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDescripcion.Select() : Exit Sub
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCIE10.BuscarCodigo(txtCIE.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                txtDescripcion.Enabled = False
                txtDescripcion.Text = dsVer.Tables(0).Rows(0)("desc_enf")
                txtDescripcion.Enabled = True
                txtDescripcion.Select()
            Else
                MessageBox.Show("Codigo de CIE10 no existe. Informar a la Oficina de Estadistica e Informática", "Mensaje de Información")
                txtCIE.Text = ""
                txtDescripcion.Text = ""
                txtCIE.Select()
            End If
        End If
    End Sub

    Private Sub lvTablaH_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTablaH.SelectedIndexChanged

    End Sub
End Class
