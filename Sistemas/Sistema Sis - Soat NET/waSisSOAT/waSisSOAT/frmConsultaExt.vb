Public Class frmConsultaExt
    Dim objSis As New SIS
    Dim objConsultaExter As New ConsultaExter
    Dim objEspecialidad As New Especialidad
    Dim objSubEspecialidad As New SubEspecialidad
    Dim CodSis As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lvDet.Items.Clear()
        dtpFecha.Value = Date.Now
        btnGrabar.Enabled = False
        Limpiar(Me)
        NumeroHistoria = ""
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblFecha.Text = ""
        lblHora.Text = ""
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub cboLote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLote.Text.Length > 0 Then txtNumero.Select()
    End Sub

    Private Sub cboLoteA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLoteA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLoteA.Text.Length > 0 Then txtNumeroA.Select()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then cboLoteA.Select()
    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumero.Text.Length
            txtNumero.Text = "0" & txtNumero.Text
        Next
        txtNumero.Text.Remove(txtNumero.Text.Length - 8, 8)
        'Verificar registro
        Dim dsTabla As New Data.DataSet
        dsTabla = objSis.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
        Dim FechaContrato As Date
        FechaContrato = dsTabla.Tables(0).Rows(0)("FechaVtoContrato")
        If FechaContrato < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            CodSis = dsTabla.Tables(0).Rows(0)("IdSIS")
            lblDISAHEI.Text = dsTabla.Tables(0).Rows(0)("DISAHEI")
            cboLoteA.Text = dsTabla.Tables(0).Rows(0)("LOTEDISA")
            txtNumeroA.Text = dsTabla.Tables(0).Rows(0)("NumeroDISA")
            txtNumeroA_LostFocus(sender, e)
            txtCorrelativo.Text = dsTabla.Tables(0).Rows(0)("Correlativo")
            txtCorrelativo_LostFocus(sender, e)
            lblHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
            lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaAtencion")
            If lblFecha.Text.Length > 10 Then lblFecha.Text = lblFecha.Text.Remove(10, 14)
            lblHora.Text = dsTabla.Tables(0).Rows(0)("HoraAtencion")
            lblPaciente.Text = dsTabla.Tables(0).Rows(0)("APaterno") & " " & dsTabla.Tables(0).Rows(0)("AMaterno") & " " & dsTabla.Tables(0).Rows(0)("Nombres")

            'Lista de Atenciones SIS
            lvDet.Items.Clear()
            Dim J As Integer
            Dim Fila As ListViewItem
            Dim dsConsulta As New Data.DataSet
            dsConsulta = objConsultaExter.Filtrar(CodSis)
            For J = 0 To dsConsulta.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsConsulta.Tables(0).Rows(J)("Especialidad"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("SubEspecialidad"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("Fecha"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("IdConsulta"))
            Next
        Else
            MessageBox.Show("Numero de Formato no ha sido registrado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub txtNumero_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtNumero.MaskInputRejected

    End Sub

    Private Sub txtNumeroA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumeroA.Text.Length > 0 Then txtCorrelativo.Select()
    End Sub

    Private Sub txtNumeroA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroA.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumeroA.Text.Length
            txtNumeroA.Text = "0" & txtNumeroA.Text
        Next
        txtNumeroA.Text.Remove(txtNumeroA.Text.Length - 8, 8)
    End Sub

    Private Sub frmConsultaExt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Especialidad
        Dim dsEsp As New Data.DataSet
        dsEsp = objEspecialidad.Combo("%")
        cboEspecialidad.DataSource = dsEsp.Tables(0)
        cboEspecialidad.DisplayMember = "Descripcion"
        cboEspecialidad.ValueMember = "IdDpto"
    End Sub

    Private Sub cboEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEspecialidad.SelectedIndexChanged
        If IsNumeric(cboEspecialidad.SelectedValue) Then
            Dim dsSEsp As New Data.DataSet
            dsSEsp = objSubEspecialidad.Combo(cboEspecialidad.SelectedValue)
            cboSubEspecialidad.DataSource = dsSEsp.Tables(0)
            cboSubEspecialidad.DisplayMember = "Descripcion"
            cboSubEspecialidad.ValueMember = "IdEspecialidad"
            cboSubEspecialidad.Select()
        End If
    End Sub

    Private Sub txtCorrelativo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCorrelativo.Text.Length > 0 Then cboEspecialidad.Select()
    End Sub

    Private Sub txtCorrelativo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCorrelativo.LostFocus
        Dim I As Integer
        For I = 1 To 3 - txtCorrelativo.Text.Length
            txtCorrelativo.Text = "0" & txtCorrelativo.Text
        Next
        txtCorrelativo.Text.Remove(txtCorrelativo.Text.Length - 3, 3)
    End Sub

    Private Sub txtCorrelativo_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtCorrelativo.MaskInputRejected

    End Sub

    Private Sub cboSubEspecialidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubEspecialidad.SelectedIndexChanged
        If IsNumeric(cboSubEspecialidad.SelectedValue) Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lvDet.Items.Count > 0 Then
                If MessageBox.Show("Esta seguro de Anular la Atencion de Consulta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim I As Integer
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items.Item(I).Selected Then
                            objConsultaExter.Eliminar(lvDet.Items.Item(I).SubItems(3).Text, UsuarioSistema)
                            MessageBox.Show("Consulta Externa Anulada Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit For
                        End If
                    Next
                    'Lista de Atenciones SIS
                    lvDet.Items.Clear()
                    Dim J As Integer
                    Dim Fila As ListViewItem
                    Dim dsConsulta As New Data.DataSet
                    dsConsulta = objConsultaExter.Filtrar(CodSis)
                    For J = 0 To dsConsulta.Tables(0).Rows.Count - 1
                        Fila = lvDet.Items.Add(dsConsulta.Tables(0).Rows(J)("Especialidad"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("SubEspecialidad"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("Fecha"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(J)("IdConsulta"))
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        objConsultaExter.Grabar(CodSis, cboEspecialidad.Text, cboSubEspecialidad.Text, cboSubEspecialidad.SelectedValue, dtpFecha.Value)
        btnCancelar_Click(sender, e)
    End Sub
End Class