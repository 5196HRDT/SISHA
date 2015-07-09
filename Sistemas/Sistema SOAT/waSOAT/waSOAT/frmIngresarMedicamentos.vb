Public Class frmIngresarMedicamentos
    Dim objDetalle As New DetalleMed
    Dim objFicha As New FichaSoat
    Dim objMedicamento As New Medicamento

    Dim I As Integer
    Dim Fila As ListViewItem

    Dim CodLocal As String
    Dim StockActual As String

    Private Sub HistorialMed()
        lvHistorial.Items.Clear()
        Dim dsHis As New Data.DataSet
        dsHis = objDetalle.MedAten(CodLocal)
        For I = 0 To dsHis.Tables(0).Rows.Count - 1
            Fila = lvHistorial.Items.Add(dsHis.Tables(0).Rows(I)("IdDet"))
            Fila.SubItems.Add(dsHis.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsHis.Tables(0).Rows(I)("Cantidad"))
        Next
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPre(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                    lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                Else
                    lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")

                If Val(dsTabla.Tables(0).Rows(0)("MontoCarta")) = 0 Then
                    MessageBox.Show("Monto de Carta es S/.0.00 No procede Atencion", "Informacion de SOAT", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnCancelar_Click(sender, e)
                    Exit Sub
                Else
                    lblMontoMed.Text = Math.Round(Val(dsTabla.Tables(0).Rows(0)("MontoCarta")) / 2, 2)
                End If

                HistorialMed()
                lblTotal.Text = "0.00"
                txtCant.Text = 1
                txtCant.Select()
            Else
                MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblPoliza.Text = ""
                lblPlaca.Text = ""
                lblEdad.Text = ""
                lblContratante.Text = ""
                lblAseguradora.Text = ""
                lblCIE.Text = ""
                txtHistoria.Text = ""
                txtHistoria.Select()
                btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress

    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtPre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPre.KeyDown
        If e.KeyCode = Keys.Enter And txtPre.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPreNP(txtPre.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
                txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
                lblFechaRegistro.Text = Microsoft.VisualBasic.Left(dsTabla.Tables(0).Rows(0)("FechaRegistro"), 10)
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNac")
                If lblFecha.Text <> "" Then
                    If Year(Date.Now) - Year(lblFecha.Text) >= 1 Then
                        lblEdad.Text = Year(Date.Now) - Year(lblFecha.Text) & " Año(s)"
                    Else
                        lblEdad.Text = Month(Date.Now) - Month(lblFecha.Text) & " Mese(s)"
                    End If
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                lblPlaca.Text = dsTabla.Tables(0).Rows(0)("Placa")
                lblPoliza.Text = dsTabla.Tables(0).Rows(0)("Poliza")
                lblContratante.Text = dsTabla.Tables(0).Rows(0)("Contratante")
                lblAseguradora.Text = dsTabla.Tables(0).Rows(0)("Aseguradora")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("CIE1")

                HistorialMed()
                lblTotal.Text = "0.00"
                txtCant.Text = 1
                txtCant.Select()
            Else
                MessageBox.Show("No Existe FICHA DE SOAT Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblPoliza.Text = ""
                lblPlaca.Text = ""
                lblEdad.Text = ""
                lblContratante.Text = ""
                lblAseguradora.Text = ""
                lblCIE.Text = ""
                txtHistoria.Text = ""
                txtPre.Select()
                btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        lblPoliza.Text = ""
        lblPlaca.Text = ""
        lblContratante.Text = ""
        lblAseguradora.Text = ""
        lblFecha.Text = ""
        lblCIE.Text = ""
        lvDet.Items.Clear()
        txtHistoria.Text = ""
        btnGrabar.Enabled = False
    End Sub

    Private Sub frmIngresarMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtCant_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCant.KeyDown
        If IsNumeric(txtCant.Text) And e.KeyCode = Keys.Enter Then txtDes.Select()
    End Sub

    Private Sub Total()
        lblTotal.Text = "0.00"
        For I = 0 To lvDet.Items.Count - 1
            lblTotal.Text = Math.Round(Val(lblTotal.Text) + lvDet.Items(I).SubItems(4).Text, 2)
        Next
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtDes.Tag) Then
            If Val(StockActual) < Val(txtCant.Text) Then MessageBox.Show("El Stock Actual es Menor al Solicitado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCant.Select() : Exit Sub

            Fila = lvDet.Items.Add(txtDes.Tag)
            Fila.SubItems.Add(txtDes.Text)
            Fila.SubItems.Add(lblPrecio.Text)
            Fila.SubItems.Add(txtCant.Text)
            Fila.SubItems.Add(lblImporte.Text)
            Total()
            txtDes.Tag = ""
            txtDes.Text = ""
            lblPrecio.Text = ""
            lblImporte.Text = ""
            txtCant.Text = 1
            txtCant.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtDes.Text.Length : txtDes.SelectionLength = txtDes.Text.Length : gbFiltro.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And lvFiltro.Items.Count > 0 Then lvFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            lvFiltro.Items.Clear()
            Dim dsFiltro As New Data.DataSet
            dsFiltro = objMedicamento.ObtenerMedicamentos(txtFiltro.Text, 1)
            For I = 0 To dsFiltro.Tables(0).Rows.Count - 1
                Fila = lvFiltro.Items.Add(dsFiltro.Tables(0).Rows(I)("IdListaPrecio"))
                Fila.SubItems.Add(dsFiltro.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsFiltro.Tables(0).Rows(I)("PrecioSIGV"))
                Fila.SubItems.Add(dsFiltro.Tables(0).Rows(I)("Stock"))
            Next
        End If
    End Sub

    Private Sub lvFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvFiltro.KeyDown
        If lvFiltro.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            txtDes.Tag = lvFiltro.SelectedItems(0).SubItems(0).Text
            txtDes.Enabled = False
            txtDes.Text = lvFiltro.SelectedItems(0).SubItems(1).Text
            txtDes.Enabled = True
            lblPrecio.Text = lvFiltro.SelectedItems(0).SubItems(2).Text
            lblImporte.Text = Val(lblPrecio.Text) * Val(txtCant.Text)

            StockActual = lvFiltro.SelectedItems(0).SubItems(3).Text
            txtDes.Select()
            btnGrabar.Enabled = True
            gbFiltro.Visible = False
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete And lvDet.Items.Count > 0 Then
            If MessageBox.Show("Esta Seguro de Quitar Medicamento", "Mensaje de Consutal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lvDet.Items.RemoveAt(lvDet.SelectedIndices(0).ToString)
                Total()
                If lvDet.Items.Count = 0 Then btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        For I = 0 To lvDet.Items.Count - 1
            objDetalle.Grabar_Med(CodLocal, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text)
        Next

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub lvHistorial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvHistorial.KeyDown
        If e.KeyCode = Keys.Delete And lvHistorial.Items.Count > 0 Then
            If MessageBox.Show("Esta seguro de Anular Medicamento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objDetalle.MedAnular(lvHistorial.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, My.Computer.Name)
            End If
            HistorialMed()
        End If
    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged

    End Sub
End Class