Public Class frmFarmaciaSIS
    Dim objIngreso As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objHistoria As New clsHistoria
    Dim objEstadoCivil As New clsEstadoCivil
    Dim objMedico As New clsMedico
    Dim objTipoTarifar As New clsTipoTarifa
    Dim objMedicamento As New clsMedicamento
    Dim objSIS As New clsSIS
    Dim objReceta As New clsRecetaMedicaSIS
    Dim objDosis As New clsDosis

    Dim StockMed As String

    Dim CodigoIngreso As String

    Private Sub Botones(Nuevo As Boolean, Grabar As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
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
        lblEdad.Text = EdadA
        lblTEdad.Text = "A"
        lblEdadM.Text = EdadM
        lblTEdadM.Text = "M"
        lblEdadD.Text = EdadD
        lblTEdadD.Text = "D"
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            dtpFechaNcto.Value = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(dtpFecha.Value, dtpFechaNcto.Value)

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString

            'Estado Civil
            dsEC = objEstadoCivil.DameDes(Val(dsHistorias.Tables(0).Rows(0)("EstadoCivil").ToString))
            If dsEC.Tables(0).Rows.Count > 0 Then
                lblEstadoCivil.Text = dsEC.Tables(0).Rows(0)("Descripcion")
            Else
                lblEstadoCivil.Text = "NINGUNO"
            End If

            lblGrado.Text = dsHistorias.Tables(0).Rows(0)("GradoInstruccion").ToString
            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            lblDomicilio.Text = dsHistorias.Tables(0).Rows(0)("Direccion").ToString
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
            dtpFechaNcto.Select()
            btnGrabar.Enabled = True
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            Dim dsVer As New DataSet
            dsVer = objIngreso.VerificarIngreso(txtHistoria.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                CodigoIngreso = dsVer.Tables(0).Rows(0)("IdIngreso")
                lblServicio.Text = dsVer.Tables(0).Rows(0)("Especialidad")
                lblInformante.Text = dsVer.Tables(0).Rows(0)("Conyuge")
                cboMedico.Text = dsVer.Tables(0).Rows(0)("Medico")
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad")
                lblTEdad.Text = dsVer.Tables(0).Rows(0)("TipoEdad")
                cboTipoAten.Text = dsVer.Tables(0).Rows(0)("TipoPaciente")
                lblSerieSIS.Text = dsVer.Tables(0).Rows(0)("SerieSIS")
                lblNumeroSIS.Text = dsVer.Tables(0).Rows(0)("NumeroSIS")
                lblPreliquidacion.Text = dsVer.Tables(0).Rows(0)("Preliquidacion")
                cboTipoAten.Text = dsVer.Tables(0).Rows(0)("TipoAtencion")
                cboMedico.Select()

                Dim dsConsulta As New DataSet
                dsConsulta = objConsulta.ConsultaBuscar(CodigoIngreso)
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    Dim Fila As ListViewItem

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie1"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie1"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD1"))

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie2"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie2"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD2"))

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie3"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie3"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD3"))

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie4"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie4"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD4"))

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie5"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie5"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD5"))

                    Fila = lvTabla.Items.Add(dsConsulta.Tables(0).Rows(0)("Cie6"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie6"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("TD6"))
                End If
            Else
                MessageBox.Show("Paciente no presenta ingreso de Emergencia. Comunicarse con Admisión de Emergencia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        gbPaciente.Visible = False
        gbFiltro.Visible = False
        btnBuscarP.Enabled = False
        dtpFecha.Value = Date.Now
        lvTabla.Items.Clear()
        dgMedicamento.Items.Clear()
        txtHora.Text = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        Botones(True, False, False, True)
        Limpiar(Me)
        ControlesAD(Me, False)
        Limpiar(Me)
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
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

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub frmFarmaciaSIS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Tipo Tarifa
        Dim dsTT As New DataSet
        dsTT = objTipoTarifar.Combo
        cboTipoAten.DataSource = dsTT.Tables(0)
        cboTipoAten.DisplayMember = "Descripcion"
        cboTipoAten.ValueMember = "IdTipoTarifa"


        'Dosis
        Dim dsDosis As New DataSet
        dsDosis = objDosis.Combo
        cboDosis.DataSource = dsDosis.Tables(0)
        cboDosis.DisplayMember = "Descripcion"
        cboDosis.ValueMember = "IdDosis"
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        dtpFecha.Value = Date.Now
        txtHora.Text = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        btnBuscarP.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub txtMedicamento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMedicamento.TextChanged
        If txtMedicamento.Text <> "" And txtMedicamento.Enabled Then gbFiltro.Visible = True : txtFiltro.Text = txtMedicamento.Text : txtFiltro.SelectionStart = Len(txtFiltro.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim Fila As ListViewItem
            Dim I As Integer
            Dim dsMed As New Data.DataSet
            dsMed = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1)
            dgFiltro.DataSource = objMedicamento.ObtenerMedicamentos(txtFiltro.Text & "%", 1).Tables(0)
            lvFiltro.Clear()
            lvFiltro.Columns.Add("Id", 0)
            lvFiltro.Columns.Add("Descripcion", 300)
            lvFiltro.Columns.Add("Precio", 60)
            lvFiltro.Columns.Add("IdTipoTarifa", 0)
            lvFiltro.Columns.Add("UND", 50)
            lvFiltro.Columns.Add("PrecioSIGV", 0)
            lvFiltro.Columns.Add("Stock", 60)
            For I = 0 To dsMed.Tables(0).Rows.Count - 1
                Fila = lvFiltro.Items.Add(dsMed.Tables(0).Rows(I)("BienServ"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("IdTipoTarifa"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Unidad"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("PrecioSIGV"))
                Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Stock"))
            Next
        End If
    End Sub

    Private Sub txtCantidadM_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidadM.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtCantidadM.Text) Then cboDosis.Select()
    End Sub

    Private Sub txtCantidadM_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidadM.TextChanged

    End Sub

    Private Sub cboDosis_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDosis.KeyDown
        If txtCantidadM.Text.Length > 0 And txtMedicamento.Text.Length > 0 And e.KeyCode = Keys.Enter And IsNumeric(cboDosis.SelectedValue) Then
            If cboTipoAten.Text = "SIS" And Val(lblNumeroSIS.Text) = 0 Then MessageBox.Show("Paciente es SIS y no se ha ingresado el Numero de Formato, verifique esta información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : lblSerieSIS.Select() : Exit Sub
            Dim Fila As New ListViewItem
            Dim Importe As String
            Fila = dgMedicamento.Items.Add(txtMedicamento.Tag)
            Fila.SubItems.Add(txtMedicamento.Text)
            Fila.SubItems.Add(lblPrecioM.Text)
            Fila.SubItems.Add(txtCantidadM.Text)
            Importe = Microsoft.VisualBasic.Format(CDbl(lblPrecioM.Text) * CDbl(txtCantidadM.Text), "#,##0.00")
            lblTotalM.Text = Microsoft.VisualBasic.Format(Val(lblTotalM.Text) + Val(Importe), "#,##0.00")
            Fila.SubItems.Add(Importe)
            Fila.SubItems.Add(cboDosis.Text)
            Fila.SubItems.Add(lblUnidad.Text)
            txtCantidadM.Text = ""
            lblPrecioM.Text = ""
            txtMedicamento.Text = ""
            lblUnidad.Text = ""
            txtMedicamento.Select()
        End If
    End Sub

    Private Sub cboDosis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDosis.SelectedIndexChanged

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If cboTipoAten.Text = "SIS" And Val(lblNumeroSIS.Text) <> 0 Then
            Dim CodigoSIS As String
            'Validar Codigo SIS
            Dim dsSIS As New DataSet
            dsSIS = objSIS.ConsultarLN(lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text)
            If dsSIS.Tables(0).Rows.Count = 0 Then MessageBox.Show("Los datos del Formato no son correctos, Verificar Numeros del Formato", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            CodigoSIS = dsSIS.Tables(0).Rows(0)("IdSis")

            If dsSIS.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then
                If dsSIS.Tables(0).Rows(0)("FechaVtoContrato") < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
            If dsSIS.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                MessageBox.Show("Hoja SIS ya fue dada de Alta, no se pudo grabar información", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            End If
        Else
            MessageBox.Show("Paciente no es SIS, Verificar Información", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Grabar Receta de Paciente
        Dim IdRecetaSIS As String
        If cboTipoAten.Text = "SIS" Then
            If dgMedicamento.Items.Count > 0 Then
                IdRecetaSIS = objReceta.SolicitudInd(cboMedico.Text, "EMERGENCIA", lblServicio.Text, cboMedico.SelectedValue, cboMedico.Text, lblSerieSIS.Text, lblNumeroSIS.Text, txtHistoria.Text, lblPaciente.Text, txtIndicacionMed.Text)
                For I = 0 To dgMedicamento.Items.Count - 1
                    objReceta.GrabarDetalle(IdRecetaSIS, dgMedicamento.Items(I).SubItems(0).Text, dgMedicamento.Items(I).SubItems(1).Text, dgMedicamento.Items(I).SubItems(2).Text, dgMedicamento.Items(I).SubItems(3).Text, dgMedicamento.Items(I).SubItems(5).Text, dgMedicamento.Items(I).SubItems(6).Text)
                Next

                'Grabar Detalle CIE
                For I = 0 To lvTabla.Items.Count - 1
                    If lvTabla.Items(I).SubItems(0).Text <> "" Then
                        objReceta.GrabarCIE(IdRecetaSIS, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text)
                    End If
                Next
            End If
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnRetornarF_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
    End Sub

    Private Sub lvFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If cboTipoAten.Text <> "SIS" And e.KeyCode = Keys.Enter Then MessageBox.Show("Solo puede digitar Medicamentos a Pacientes SIS", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboTipoAten.Text = "SIS" And e.KeyCode = Keys.Enter Then
            txtMedicamento.Enabled = False
            txtMedicamento.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
            txtMedicamento.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
            txtMedicamento.Enabled = True
            lblUnidad.Text = lvFiltro.SelectedItems(0).SubItems(4).Text
            lblPrecioM.Text = Microsoft.VisualBasic.Format(CDbl(lvFiltro.SelectedItems(0).SubItems(2).Text), "#,##0.00")
            StockMed = lvFiltro.SelectedItems(0).SubItems(6).Text
            gbFiltro.Visible = False
            txtCantidadM.Text = 1
            txtCantidadM.Select()
        End If
    End Sub

    Private Sub lvFiltro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvFiltro.SelectedIndexChanged

    End Sub
End Class