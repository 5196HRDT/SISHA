Public Class frmSalidaSIS
    Dim objSIS As New SIS
    Dim objServicio As New ServicioRealizado
    Dim objMedico As New Medico
    Dim objCIE As New CIE10
    Dim objCentro As New CentroSalud
    Dim CodLocal As String
    Dim Equipo As String

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
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        Limpiar(Me)
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        NumeroHistoria = ""
        ControlesAD(Me, False)
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub frmSalidaSIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        btnCancelar_Click(sender, e)
        Equipo = My.Computer.Name

        'Centro Salud
        Dim dsCentro As New Data.DataSet
        dsCentro = objCentro.Combo
        cboReferencia.DataSource = dsCentro.Tables(0)
        cboReferencia.DisplayMember = "Descripcion"
        cboReferencia.ValueMember = "IdCentro"

        'ServicioRealizado
        cboServicio.DataSource = objServicio.BuscarCombo("").Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        'Medico
        cboResponsable.DataSource = objMedico.BuscarNombres("").Tables(0)
        cboResponsable.DisplayMember = "Medico"
        cboResponsable.ValueMember = "IdMedico"

        cboResponsable.SelectedIndex = -1
        'cboResponsable.Text = ""
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboLote.Select()
    End Sub

    Private Sub txtCIE1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE1.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes1.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : cboTipoDI1.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE2.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes2.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : cboTipoDI2.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE3.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes3.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : cboTipoDI3.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE4.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes4.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : cboTipoDI4.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIE5.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIE1.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCIE.BuscarCodigo(txtCIE5.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then txtDes5.Text = dsTabla.Tables(0).Rows(0)("desc_enf") : cboTipoDI5.Select() Else MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCIE5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIE5.TextChanged

    End Sub

    Private Sub cboTipoDI1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDI1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDI1.Text.Length > 0 Then txtCIE2.Select()
    End Sub

    Private Sub cboTipoDI2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDI2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDI2.Text.Length > 0 Then txtCIE3.Select()
    End Sub

    Private Sub cboTipoDI3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDI3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDI3.Text.Length > 0 Then txtCIE4.Select()
    End Sub

    Private Sub cboTipoDI4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDI4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDI4.Text.Length > 0 Then txtCIE5.Select()
    End Sub

    Private Sub cboTipoDI5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDI5.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDI5.Text.Length > 0 Then txtCIEE1.Select()
    End Sub

    Private Sub txtCIEE1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIEE1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCIEE1.Text.Length > 0 Then cboTipoDE1.Select()
    End Sub

    Private Sub txtCIEE1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIEE1.TextChanged

    End Sub

    Private Sub cboCIEE2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIEE2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboTipoDE2.Select()
    End Sub

    Private Sub cboCIEE2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIEE2.TextChanged

    End Sub

    Private Sub txtCIEE4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIEE4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboTipoDE4.Select()
    End Sub

    Private Sub txtCIEE4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIEE4.TextChanged

    End Sub

    Private Sub cboTipoDE1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDE1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboTipoDE1.Text.Length > 0 Then txtCIEE2.Select()
    End Sub

    Private Sub cboTipoDE1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDE1.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDE2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDE2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then txtCIEE3.Select()
    End Sub

    Private Sub cboTipoDE2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDE2.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDE3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDE3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then txtCIEE4.Select()
    End Sub

    Private Sub cboTipoDE3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDE3.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDE4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDE4.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then txtCIEE5.Select()
    End Sub

    Private Sub cboTipoDE4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDE4.SelectedIndexChanged

    End Sub

    Private Sub cboTipoDE5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDE5.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboResponsable.Select()
    End Sub

    Private Sub cboTipoDE5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDE5.SelectedIndexChanged

    End Sub

    Private Sub txtCIEE3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIEE3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboTipoDE3.Select()
    End Sub

    Private Sub txtCIEE3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCIEE3.TextChanged

    End Sub

    Private Sub txtCIEE5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCIEE5.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then cboTipoDE5.Select()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If dsTabla.Tables(0).Rows(0)("IdResponsable").ToString <> "" Then
                    MsgBox("Hoja HIS ya Fue Dada de Alta, Procedera a Modificar los Datos", MsgBoxStyle.Information, "Mensaje de Información")
                    cboServicio.Text = dsTabla.Tables(0).Rows(0)("Servicio")
                    cboDestino.Text = dsTabla.Tables(0).Rows(0)("Destino")
                    dtpFecha.Value = dsTabla.Tables(0).Rows(0)("FechaAlta")
                    txtHora.Text = dsTabla.Tables(0).Rows(0)("FechaAlta")
                    cboReferencia.Text = dsTabla.Tables(0).Rows(0)("EsContraRef")
                    'Diagnosticos
                    txtCIE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagIng1")
                    txtDes1.Text = dsTabla.Tables(0).Rows(0)("DesDiagIng1")
                    cboTipoDI1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagIng1")
                    txtCIE2.Text = dsTabla.Tables(0).Rows(0)("CodDiagIng2")
                    txtDes2.Text = dsTabla.Tables(0).Rows(0)("DesDiagIng2")
                    cboTipoDI2.Text = dsTabla.Tables(0).Rows(0)("TipoDiagIng2")
                    txtCIE3.Text = dsTabla.Tables(0).Rows(0)("CodDiagIng3")
                    txtDes3.Text = dsTabla.Tables(0).Rows(0)("DesDiagIng3")
                    cboTipoDI3.Text = dsTabla.Tables(0).Rows(0)("TipoDiagIng3")
                    txtCIE4.Text = dsTabla.Tables(0).Rows(0)("CodDiagIng4")
                    txtDes4.Text = dsTabla.Tables(0).Rows(0)("DesDiagIng4")
                    cboTipoDI4.Text = dsTabla.Tables(0).Rows(0)("TipoDiagIng4")
                    txtCIE5.Text = dsTabla.Tables(0).Rows(0)("CodDiagIng5")
                    txtDes5.Text = dsTabla.Tables(0).Rows(0)("DesDiagIng5")
                    cboTipoDI5.Text = dsTabla.Tables(0).Rows(0)("TipoDiagIng5")
                    txtCIEE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagEgr1")
                    cboTipoDE1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagEgr1")
                    txtCIEE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagEgr2")
                    cboTipoDE1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagEgr2")
                    txtCIEE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagEgr3")
                    cboTipoDE1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagEgr3")
                    txtCIEE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagEgr4")
                    cboTipoDE1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagEgr4")
                    txtCIEE1.Text = dsTabla.Tables(0).Rows(0)("CodDiagEgr5")
                    cboTipoDE1.Text = dsTabla.Tables(0).Rows(0)("TipoDiagEgr5")
                    cboResponsable.Text = dsTabla.Tables(0).Rows(0)("Responsable")
                End If
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSIS")
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
                cboServicio.Select()
            End If
        End If
    End Sub

    Private Sub txtNumero_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyUp

    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumero.Text.Length
            txtNumero.Text = "0" & txtNumero.Text
        Next
        txtNumero.Text.Remove(txtNumero.Text.Length - 8, 8)
    End Sub

    Private Sub cboLoteA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLoteA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLoteA.Text.Length > 0 Then txtNumeroA.Select()
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

    Private Sub txtCorrelativo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCorrelativo.Text.Length > 0 Then cboServicio.Select()
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

    Private Sub cboLote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLote.Text.Length > 0 Then txtNumero.Select()
    End Sub

    Private Sub cboServicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboServicio.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboServicio.Text.Length > 0 Then cboDestino.Select()
    End Sub

    Private Sub cboDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestino.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboDestino.Text.Length > 0 Then cboResponsable.Select()

    End Sub

    Private Sub txtReferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then dtpFecha.Select()
    End Sub

    Private Sub txtHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHora.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then txtCIE1.Select()
    End Sub

    Private Sub cboResponsable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboResponsable.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then btnGrabar.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            ' ''If cboDestino.Text.Length < 0 Or cboServicio.SelectedIndex < 0 Or cboLoteA.Text.Length < 0 Or cboLoteA.SelectedIndex < 0 Or txtNumero.TextLength < 0 Or txtNumeroA.TextLength < 0 Or cboResponsable.SelectedIndex < 0 Then MessageBox.Show("Faltan datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If MessageBox.Show("Esta seguro de guardar los datos", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objSIS.GrabarSalida(CodLocal, cboServicio.Text, cboDestino.Text, dtpFecha.Value.ToString.Substring(0, 10), txtHora.Text, Equipo, txtCIE1.Text, txtDes1.Text, cboTipoDI1.Text, txtCIE2.Text, txtDes2.Text, cboTipoDI2.Text, txtCIE3.Text, txtDes3.Text, cboTipoDI3.Text, txtCIE4.Text, txtDes4.Text, cboTipoDI4.Text, txtCIE5.Text, txtDes5.Text, cboTipoDI5.Text, txtCIEE1.Text, cboTipoDE1.Text, txtCIEE2.Text, cboTipoDE2.Text, txtCIEE3.Text, cboTipoDE3.Text, txtCIEE4.Text, cboTipoDE4.Text, txtCIEE5.Text, cboTipoDE5.Text, cboResponsable.SelectedValue, cboReferencia.Text, cboResponsable.Text)
            End If
            cboResponsable.SelectedIndex = -1
            cboResponsable.Text = ""
            btnCancelar_Click(sender, e)

        Catch ex As Exception
            Return
        End Try
        
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDestino.SelectedIndexChanged
        If cboDestino.Text <> "CONTRAREFERIDO" Then cboReferencia.Text = ""
    End Sub

    Private Sub cboReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then dtpFecha.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then txtHora.Select()
    End Sub


End Class