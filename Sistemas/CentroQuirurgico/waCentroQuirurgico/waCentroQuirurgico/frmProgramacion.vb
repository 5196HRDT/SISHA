Public Class frmProgramacion
    Dim objProgramacion As New Programacion
    Dim objHistoria As New Historia
    Dim objComprobante As New ComprobanteVta
    Dim objAnestesista As New Personal
    Dim objSala As New Sala
    Dim objPersonal As New Personal
    Dim objCargo As New Cargo
    Dim objTipoAnestesia As New TipoAnestesia
    Dim objServicio As New Servicio
    Dim objCPT As New CPT
    Dim objDetCPT As New CQDetCPT
    Dim CodLocal As String
    Dim Oper As Integer

    Private Sub Buscar()
        If cboOrigenSala.Text = "" Then Exit Sub
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProgramacion.BuscarOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), TipoProgramacion, cboOrigenSala.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Hora"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Serie"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Numero"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Exonerado"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("APaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("AMaterno"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("FechaNac"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Operacion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Sala"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Anestesia"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cirujano"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Origen"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoProgramacion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoCirugia").ToString)
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SalaOrigen"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Anestesista"))
        Next
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno").ToString
                lblMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno").ToString
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres").ToString
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento").ToString
                'Edad Paciente
                Dim EdadA As String, Edad As String, EdadM As String, EdadD As String
                If dsTabla.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    EdadA = 0 : Edad = "0"
                    If dsTabla.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                        Dim Dias As Integer, Meses As Integer, Años As Integer
                        Dim DiasMes As Integer
                        Dim dfin, dinicio As Date
                        dfin = dtpFecha.Value
                        dinicio = dsTabla.Tables(0).Rows(0)("FNacimiento")
                        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                        Años = DateDiff("yyyy", dinicio, dfin)
                        'Verificar Dias
                        If Meses = 0 And Años = 0 Then
                            EdadA = 0
                            EdadM = 0
                            Dias = Math.Abs(Dias)
                            EdadD = Dias
                        Else
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
                            If Val(EdadA) > 0 Then
                                Edad = EdadA & "A " & EdadM & "M"
                            Else
                                Edad = EdadM & "M " & EdadD & "D"
                            End If
                        End If

                        If Val(EdadA) > 0 Then
                            Edad = EdadA & "A " & EdadM & "M"
                        Else
                            Edad = EdadM & "M " & EdadD & "D"
                        End If
                    End If
                End If
                lblEdad.Text = Edad
                cboServicio.Select()
            Else
                MessageBox.Show("Existe aperturada una ficha para este paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Oper = 2
                'CodLocal = dsFicha.Tables(0).Rows(0)("IdSoat")
                'lblPaterno.Text = dsFicha.Tables(0).Rows(0)("Apaterno")
                'lblMaterno.Text = dsFicha.Tables(0).Rows(0)("Amaterno")
                'lblNombres.Text = dsFicha.Tables(0).Rows(0)("Nombres")
                'lblFecha.Text = dsFicha.Tables(0).Rows(0)("FechaNac")
                'If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                '    lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                'Else
                '    lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                'End If           
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaterno.Text = ""
                lblMaterno.Text = ""
                lblNombres.Text = ""
                lblEdad.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter And txtSerie.Text <> "" And txtNumero.Text <> "" Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objComprobante.BuscarNumero(txtSerie.Text, txtNumero.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If dsTabla.Tables(0).Rows(0)("FecAnu").ToString <> "" Then MessageBox.Show("Comprobante de Venta ha sido Anulado... Verificar con Economía", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If dsTabla.Tables(0).Rows(0)("FecDev").ToString <> "" Then MessageBox.Show("Comprobante de Venta ha sido Devuelto... Verificar con Economía", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                Dim I As Integer
                Dim Cadena As String = ""
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    If I = 0 Then
                        Cadena = dsTabla.Tables(0).Rows(I)("Descripcion")
                    Else
                        Cadena = Cadena & Chr(13) & dsTabla.Tables(0).Rows(I)("Descripcion")
                    End If
                Next
                If MessageBox.Show("Esta seguro que el concepto pagado corresponde a este servicio" & Chr(13) & Cadena, "Mensaje de Consulta Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    txtHistoria.Text = dsTabla.Tables(0).Rows(0)("NHistoria")
                    Dim dsHistoria As New Data.DataSet
                    dsHistoria = objHistoria.BuscarNumero(txtHistoria.Text)
                    If dsTabla.Tables(0).Rows.Count > 0 Then
                        lblPaterno.Text = dsHistoria.Tables(0).Rows(0)("Apaterno").ToString
                        lblMaterno.Text = dsHistoria.Tables(0).Rows(0)("Amaterno").ToString
                        lblNombres.Text = dsHistoria.Tables(0).Rows(0)("Nombres").ToString
                        lblFecha.Text = dsHistoria.Tables(0).Rows(0)("FNacimiento").ToString
                        If Not lblFecha.Text = "" Then
                            If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                                lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                            Else
                                lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                            End If
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Comprobante de Venta No Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSerie.Select()
            End If
        End If
    End Sub


    Private Sub frmProgramacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbPro.Visible = False

        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Buscar("Select * From CQServicio")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        'Tipo Anestesista
        Dim dsTipoAnestesia As New Data.DataSet
        dsTipoAnestesia = objTipoAnestesia.Buscar("Select * From CQTipoAnestesia")
        cboAnestesia.DataSource = dsTipoAnestesia.Tables(0)
        cboAnestesia.DisplayMember = "Descripcion"
        cboAnestesia.ValueMember = "IdTipoAnestesia"

        'Personal
        Dim dsPersonal As New Data.DataSet
        dsPersonal = objPersonal.BuscarPersonal("Select * From CQPersonal Where IdCargo = 3 And Activo = '1'")
        cboPersonal.DataSource = dsPersonal.Tables(0)
        cboPersonal.DisplayMember = "Nombres"
        cboPersonal.ValueMember = "IdPersonal"

        'Personal
        Dim dsAnestesista As New Data.DataSet
        dsAnestesista = objAnestesista.BuscarPersonal("Select * From CQPersonal Where IdCargo = 1 And Activo = '1'")
        cboAnestesista.DataSource = dsAnestesista.Tables(0)
        cboAnestesista.DisplayMember = "Nombres"
        cboAnestesista.ValueMember = "IdPersonal"

        btnCancelar_Click(sender, e)
        dtpFecha.Value = Date.Now
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
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        Buscar()
        lblPaterno.Text = ""
        lblMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblEdad.Text = ""
        lvPro.Items.Clear()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        dtpFecha.Select()
        Botones(False, False, True, False)
        cboOrigen.Text = "COMUN"
        If TipoProgramacion = 1 Then cboTipoProg.Text = "PROGRAMADA" Else cboTipoProg.Text = "EMERGENCIA"
        cboOrigenSala.Text = "PRINCIPAL"
        Oper = 1
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de guardar la programacion", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtHora.Text = "" Then MessageBox.Show("Debe ingresar la Hora de Operación en Formato de 24", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtHora.Select() : Exit Sub
            If cboServicio.Text = "" Then MessageBox.Show("Debe seleccionar el Servicio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboServicio.Select() : Exit Sub
            If cboAnestesia.Text = "" Then MessageBox.Show("Debe seleccionar el tipo de Anestesia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboAnestesia.Select() : Exit Sub
            If cboOrigen.Text = "" Then MessageBox.Show("Debe seleccionar el tipo de paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboOrigen.Select() : Exit Sub
            If cboTipoCirugia.Text = "" Then MessageBox.Show("Debe seleccionar el tipo de cirugia", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoCirugia.Select() : Exit Sub
            If cboTipoProg.Text = "" Then MessageBox.Show("Debe seleccionar el tipo de programacion", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTipoProg.Select() : Exit Sub
            If cboOrigenSala.Text = "" Then MessageBox.Show("Debe seleccionar el origen de las salas", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboOrigenSala.Select() : Exit Sub
            If Oper = 1 Then
                CodLocal = objProgramacion.Guardar(Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), txtHora.Text, txtSerie.Text, txtNumero.Text, chkExonerado.Checked.ToString, txtHistoria.Text, lblPaterno.Text, lblMaterno.Text, lblNombres.Text, lblFecha.Text, lblEdad.Text, lvPro.Items(0).SubItems(1).Text, cboSala.SelectedValue.ToString, cboAnestesia.SelectedValue.ToString, cboServicio.SelectedValue.ToString, cboPersonal.SelectedValue.ToString, Oper, cboOrigen.Text, cboTipoProg.Text, cboTipoCirugia.Text, cboOrigenSala.Text, lvPro.Items(0).SubItems(0).Text, cboAnestesista.SelectedValue)
            Else
                objProgramacion.Modificar(CodLocal, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), txtHora.Text, txtSerie.Text, txtNumero.Text, chkExonerado.Checked.ToString, txtHistoria.Text, lblPaterno.Text, lblMaterno.Text, lblNombres.Text, lblFecha.Text, lblEdad.Text, txtOperacion.Text, cboSala.SelectedValue.ToString, cboAnestesia.SelectedValue.ToString, cboServicio.SelectedValue.ToString, cboPersonal.SelectedValue.ToString, Oper, cboOrigen.Text, cboTipoProg.Text, cboTipoCirugia.Text, cboOrigenSala.Text, lvPro.Items(0).SubItems(0).Text, cboAnestesista.SelectedValue)
                objDetCPT.Eliminar(CodLocal)
            End If

            Dim I As Integer
            For I = 0 To lvPro.Items.Count - 1
                objDetCPT.Grabar(CodLocal, lvPro.Items(I).SubItems(0).Text, lvPro.Items(I).SubItems(1).Text)
            Next
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtOperacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperacion.KeyDown
        If txtOperacion.Text.Length > 0 And e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub txtOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperacion.TextChanged
        If txtOperacion.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
        If txtOperacion.Text <> "" And txtOperacion.Enabled Then txtFiltro.Text = txtOperacion.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbPro.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de eliminar los datos", "Mensaje de Consutla", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvDet.Items.Count - 1
                    If lvDet.Items(I).Selected Then
                        objProgramacion.Eliminar(lvDet.Items(I).SubItems(0).Text)
                    End If
                Next
            End If
        End If
        Buscar()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 0 Then
            Oper = 2
            Activar(Me, True)
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    CodLocal = lvDet.Items(I).SubItems(0).Text
                    dtpFecha.Value = lvDet.Items(I).SubItems(1).Text
                    txtHora.Text = lvDet.Items(I).SubItems(2).Text
                    txtSerie.Text = lvDet.Items(I).SubItems(3).Text
                    txtNumero.Text = lvDet.Items(I).SubItems(4).Text
                    If lvDet.Items(I).SubItems(5).Text = "F" Then chkExonerado.Checked = False Else chkExonerado.Checked = True
                    txtHistoria.Text = lvDet.Items(I).SubItems(6).Text
                    lblPaterno.Text = lvDet.Items(I).SubItems(7).Text
                    lblMaterno.Text = lvDet.Items(I).SubItems(8).Text
                    lblNombres.Text = lvDet.Items(I).SubItems(9).Text
                    lblFecha.Text = lvDet.Items(I).SubItems(10).Text
                    lblEdad.Text = lvDet.Items(I).SubItems(11).Text
                    txtOperacion.Enabled = False
                    txtOperacion.Text = lvDet.Items(I).SubItems(12).Text
                    txtOperacion.Enabled = True
                    cboServicio.Text = lvDet.Items(I).SubItems(13).Text
                    cboSala.Text = lvDet.Items(I).SubItems(14).Text
                    cboAnestesia.Text = lvDet.Items(I).SubItems(15).Text
                    cboPersonal.Text = lvDet.Items(I).SubItems(16).Text
                    cboOrigen.Text = lvDet.Items(I).SubItems(17).Text
                    cboTipoProg.Text = lvDet.Items(I).SubItems(18).Text
                    cboTipoCirugia.Text = lvDet.Items(I).SubItems(19).Text
                    cboOrigenSala.Text = lvDet.Items(I).SubItems(20).Text
                    cboAnestesista.Text = lvDet.Items(I).SubItems(21).Text
                    'Buscar Operaciones
                    Dim dsDet As New DataSet
                    lvPro.Items.Clear()
                    dsDet = objDetCPT.Buscar(CodLocal)
                    Dim J As Integer
                    Dim Fila As ListViewItem
                    For J = 0 To dsDet.Tables(0).Rows.Count - 1
                        Fila = lvPro.Items.Add(dsDet.Tables(0).Rows(J)("Codigo"))
                        Fila.SubItems.Add(dsDet.Tables(0).Rows(J)("Descripcion"))
                    Next

                    Exit For
                End If
            Next
            Botones(False, True, True, False)
        End If
    End Sub

    Private Sub txtHora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter And txtHora.Text.Length > 0 Then txtSerie.Select()
    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter And txtSerie.Text.Length > 0 Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress

    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Buscar()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        lvFiltro.Items.Clear()
        If txtFiltro.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objCPT.BuscarDes(txtFiltro.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvFiltro.Items.Add(dsVer.Tables(0).Rows(I)("Codigo"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Next
        End If
    End Sub

    Private Sub lvFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.SelectedItems.Count > 0 Then
            Dim Fila As ListViewItem
            Fila = lvPro.Items.Add(lvFiltro.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvFiltro.SelectedItems(0).SubItems(1).Text)
            txtOperacion.Text = ""
            txtOperacion.Select()
            gbPro.Visible = False
            btnGrabar.Enabled = True
        End If
    End Sub

    Private Sub lvFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFiltro.SelectedIndexChanged

    End Sub

    Private Sub cboPersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPersonal.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboPersonal.SelectedValue) Then cboSala.Select()
    End Sub

    Private Sub cboPersonal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPersonal.SelectedIndexChanged

    End Sub

    Private Sub cboTipoCirugia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoCirugia.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoCirugia.Text <> "" Then cboTipoProg.Select()
    End Sub

    Private Sub cboTipoCirugia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCirugia.SelectedIndexChanged

    End Sub

    Private Sub cboAnestesia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAnestesia.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboAnestesia.SelectedValue) Then cboOrigen.Select()
    End Sub

    Private Sub cboAnestesia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnestesia.SelectedIndexChanged

    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub cboOrigenSala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigenSala.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigenSala.Text <> "" Then cboPersonal.Select()
    End Sub

    Private Sub cboOrigenSala_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOrigenSala.KeyPress

    End Sub

    Private Sub cboOrigenSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigenSala.SelectedIndexChanged
        If cboOrigenSala.Text <> "" Then
            'Sala
            Dim dsSala As New Data.DataSet
            dsSala = objSala.BuscarOrigen(cboOrigenSala.Text)
            cboSala.DataSource = dsSala.Tables(0)
            cboSala.DisplayMember = "Descripcion"
            cboSala.ValueMember = "IdSala"
            Buscar()
        End If
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If IsNumeric(cboServicio.SelectedValue) And e.KeyCode = 13 Then cboAnestesia.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub cboOrigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then cboTipoCirugia.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub cboTipoProg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoProg.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoProg.Text <> "" Then cboOrigenSala.Select()
    End Sub

    Private Sub cboTipoProg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoProg.SelectedIndexChanged

    End Sub

    Private Sub cboSala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSala.KeyDown
        If e.KeyCode = Keys.Enter And cboSala.Text <> "" Then cboAnestesista.Select()
    End Sub

    Private Sub cboSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSala.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbPro.Visible = False
    End Sub

    Private Sub lvPro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPro.KeyDown
        If e.KeyCode = Keys.Delete And lvPro.SelectedItems.Count > 0 Then
            lvPro.Items.RemoveAt(lvPro.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvPro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPro.SelectedIndexChanged

    End Sub

    Private Sub cboAnestesista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAnestesista.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboAnestesista.SelectedValue) Then txtOperacion.Select()
    End Sub

    Private Sub cboAnestesista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAnestesista.SelectedIndexChanged

    End Sub
End Class