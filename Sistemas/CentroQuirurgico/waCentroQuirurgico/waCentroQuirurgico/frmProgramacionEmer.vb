Public Class frmProgramacionEmer
    Dim objProgramacion As New Programacion
    Dim objHistoria As New Historia
    Dim objComprobante As New ComprobanteVta
    Dim objSala As New Sala
    Dim objPersonal As New Personal
    Dim objAnestesista As New Personal
    Dim objCargo As New Cargo
    Dim objTipoAnestesia As New TipoAnestesia
    Dim objServicio As New Servicio
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objProgramacion.BuscarOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), 2, cboOrigen.Text)
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
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Anestesista"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("TipoCirugia"))
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
                If Not lblFecha.Text = "" Then
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                End If
                'lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo").ToString
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
        'Sala
        Dim dsSala As New Data.DataSet
        dsSala = objSala.Buscar("Select * From CQSala")
        cboSala.DataSource = dsSala.Tables(0)
        cboSala.DisplayMember = "Nombre"
        cboSala.ValueMember = "IdSala"

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
        dsSala = objPersonal.BuscarPersonal("Select * From CQPersonal Where IdCargo = 3 And Activo = '1'")
        cboPersonal.DataSource = dsSala.Tables(0)
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
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        dtpFecha.Select()
        Botones(False, False, True, False)
        cboOrigen.Text = "COMUN"
        cboTipoProg.Text = "EMERGENCIA"
        Oper = 1
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Hora As String
        If MessageBox.Show("Esta seguro de guardar la programacion", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtHora.Text = "" Then Hora = "" Else Hora = Microsoft.VisualBasic.Right("00" & txtHora.Text, 5)
            objProgramacion.GrabarEmergencia(CodLocal, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), Hora, txtSerie.Text, txtNumero.Text, chkExonerado.Checked.ToString, txtHistoria.Text, lblPaterno.Text, lblMaterno.Text, lblNombres.Text, lblFecha.Text, lblEdad.Text, txtOperacion.Text, cboSala.SelectedValue.ToString, cboAnestesia.SelectedValue.ToString, cboServicio.SelectedValue.ToString, cboPersonal.SelectedValue.ToString, Oper, cboOrigen.Text, cboTipoProg.Text, cboAnestesista.SelectedValue.ToString, cboTipoCirugia.Text)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtOperacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperacion.KeyDown
        If txtOperacion.Text.Length > 0 And e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub txtOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperacion.TextChanged
        If txtOperacion.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
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
                    txtOperacion.Text = lvDet.Items(I).SubItems(12).Text
                    cboServicio.Text = lvDet.Items(I).SubItems(13).Text
                    cboSala.Text = lvDet.Items(I).SubItems(14).Text
                    cboAnestesia.Text = lvDet.Items(I).SubItems(15).Text
                    cboPersonal.Text = lvDet.Items(I).SubItems(16).Text
                    cboOrigen.Text = lvDet.Items(I).SubItems(17).Text
                    cboTipoProg.Text = lvDet.Items(I).SubItems(18).Text
                    cboAnestesista.Text = lvDet.Items(I).SubItems(19).Text
                    cboTipoCirugia.Text = lvDet.Items(I).SubItems(20).Text
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

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Buscar()
    End Sub
End Class