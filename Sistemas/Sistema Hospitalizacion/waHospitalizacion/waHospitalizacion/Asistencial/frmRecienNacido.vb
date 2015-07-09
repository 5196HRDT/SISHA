Public Class frmRecienNacido
    Dim objRN As New RecienNacidoHosp
    Dim objHospitalizacion As New Hospitalizacion
    Dim objIngreso As New Ingreso
    Dim IdIngreso As String

    Dim Oper As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsHist As New Data.DataSet
        lvRN.Items.Clear()
        dsHist = objRN.Buscar(IdIngreso)
        If dsHist.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Datos Mortalidad ya fueron registrados", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            For I = 0 To dsHist.Tables(0).Rows.Count - 1
                Fila = lvRN.Items.Add(dsHist.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Hora"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Condicion"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Peso"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Talla"))
                Fila.SubItems.Add(dsHist.Tables(0).Rows(I)("Semanas"))
            Next
            Oper = 2
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dsHospitalizacion As New Data.DataSet
            IdIngreso = ""
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(txtHistoria.Text)
            If dsHospitalizacion.Tables(0).Rows.Count > 0 Then
                'Verificar Ingreso Hospitalizacion
                Dim dsIngreso As New Data.DataSet
                dsIngreso = objIngreso.Buscar(dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion"))
                If dsIngreso.Tables(0).Rows.Count > 0 Then
                    IdIngreso = dsIngreso.Tables(0).Rows(0)("IdIngreso")
                Else
                    MessageBox.Show("Debe registrar ingreso de paciente ha hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                lblPaciente.Text = dsHospitalizacion.Tables(0).Rows(0)("Apaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Amaterno") & " " & dsHospitalizacion.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsHospitalizacion.Tables(0).Rows(0)("FecIngreso")
                dtpFechaNac.Select()
                Buscar()
            Else
                MessageBox.Show("Paciente No Esta Registrado En Hospitalizacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblFecha.Text = ""
                lblPaciente.Text = ""
                IdIngreso = ""
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lblPaciente.Text = ""
        lblFecha.Text = ""
        Botones(True, False, False, True)
        Limpiar(Me)
        Activar(Me, False)
        lvRN.Items.Clear()
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If IdIngreso = "" Then MessageBox.Show("Debe Seleccionar un paciente hospitalizado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            objRN.Mantenimiento(IdIngreso, lvRN.Items(I).SubItems(0).Text, lvRN.Items(I).SubItems(1).Text, "", lvRN.Items(I).SubItems(2).Text, lvRN.Items(I).SubItems(3).Text, lvRN.Items(I).SubItems(4).Text, lvRN.Items(I).SubItems(5).Text, lvRN.Items(I).SubItems(6).Text, 3)
            For I = 0 To lvRN.Items.Count - 1
                objRN.Mantenimiento(IdIngreso, lvRN.Items(I).SubItems(0).Text, lvRN.Items(I).SubItems(1).Text, "", lvRN.Items(I).SubItems(2).Text, lvRN.Items(I).SubItems(3).Text, lvRN.Items(I).SubItems(4).Text, lvRN.Items(I).SubItems(5).Text, lvRN.Items(I).SubItems(6).Text, 1)
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        Botones(False, True, True, False)
        Oper = 1
        txtHistoria.Select()
        cboCondicion.Text = "VIVO"
        cboSexo.Text = "FEMENINO"
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dtpFechaNac_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaNac.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub

    Private Sub dtpFechaNac_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaNac.ValueChanged

    End Sub

    Private Sub txtHora_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHora.KeyDown
        If e.KeyCode = Keys.Enter Then cboCondicion.Select()
    End Sub

    Private Sub txtHora_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHora.MaskInputRejected

    End Sub

    Private Sub cboCondicion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCondicion.KeyDown
        If e.KeyCode = Keys.Enter And cboCondicion.Text <> "" Then cboSexo.Select()
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCondicion.SelectedIndexChanged

    End Sub

    Private Sub cboSexo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSexo.KeyDown
        If e.KeyCode = Keys.Enter And cboSexo.Text <> "" Then txtPeso.Select()
    End Sub

    Private Sub cboSexo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSexo.SelectedIndexChanged

    End Sub

    Private Sub txtPeso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPeso.KeyDown
        If e.KeyCode = Keys.Enter And txtPeso.Text <> "" Then txtTalla.Select()
    End Sub

    Private Sub txtPeso_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPeso.TextChanged

    End Sub

    Private Sub txtTalla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTalla.KeyDown
        
    End Sub

    Private Sub txtTalla_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTalla.TextChanged

    End Sub

    Private Sub frmRecienNacido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvRN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvRN.KeyDown
        If e.KeyCode = Keys.Delete And lvRN.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Retirar Información de Recién Nacido?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lvRN.Items.RemoveAt(lvRN.SelectedItems(0).Index)
                MessageBox.Show("Para confirmar los cambios presione el botón Grabar", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtSemanas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSemanas.KeyDown
        If e.KeyCode = Keys.Enter And txtTalla.Text <> "" And cboCondicion.Text <> "" And cboSexo.Text <> "" And txtPeso.Text <> "" And txtSemanas.Text <> "" Then
            Dim Fila As ListViewItem
            Fila = lvRN.Items.Add(dtpFechaNac.Value.ToShortDateString)
            Fila.SubItems.Add(txtHora.Text)
            Fila.SubItems.Add(cboCondicion.Text)
            Fila.SubItems.Add(cboSexo.Text)
            Fila.SubItems.Add(txtPeso.Text)
            Fila.SubItems.Add(txtTalla.Text)
            Fila.SubItems.Add(txtSemanas.Text)
            txtHora.Text = "__:__"
            cboCondicion.Text = "VIVO"
            cboSexo.Text = "FEMENINO"
            txtPeso.Text = ""
            txtTalla.Text = ""
            txtSemanas.Text = ""
            dtpFechaNac.Select()
        End If
    End Sub

    Private Sub txtSemanas_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSemanas.TextChanged

    End Sub
End Class