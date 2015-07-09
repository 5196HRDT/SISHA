Public Class frmDigMedUCI
    Dim Filtro As String
    Dim objSis As New SIS
    Dim objMedicina As New Medicamentos
    Dim objProcedimiento As New Procedimientos
    Dim CodSis As String
    Dim NroFilas As Integer

    Dim StockAct As String

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text.Length > 0 And e.KeyCode = Keys.Enter Then dgFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Select Case Filtro
            Case "MEDICINA"
                Dim rsExa As New Data.DataSet
                rsExa = objMedicina.ObtenerMedicamentosSISUCI(txtFiltro.Text & "%", 1)
                dgFiltro.DataSource = rsExa.Tables(0)
                dgFiltro.Columns(0).Width = 60
                dgFiltro.Columns(1).Width = 350
                dgFiltro.Columns(2).Width = 70
        End Select
    End Sub

    Private Sub dgFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFiltro.KeyDown
        If dgFiltro.Rows.Count > 0 And e.KeyCode = Keys.I Then
            Select Case Filtro
                Case "MEDICINA"
                    'If lblRN.Text = "NO" Then
                    '    If Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 6) = "FITOME" Or Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 7) = "TETRACI" Or Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 22) = "JERINGA DESCARTABLE 1CC" Then
                    '        MessageBox.Show("Paciente no puede recibir estos medicamentos por que son de uso de Recien Nacidos", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        Exit Sub
                    '    End If
                    'ElseIf lblRN.Text = "SI" Then
                    '    If Not (Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 6) = "FITOME" Or Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 7) = "TETRACI" Or Microsoft.VisualBasic.Left(dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value, 22) = "JERINGA DESCARTABLE 1CC") Then
                    '        MessageBox.Show("Paciente solo puede recibir FITO, TETRA y JERINGA de 1CC que son de uso de Recien Nacidos", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        Exit Sub
                    '    End If
                    'End If
                    txtExamenes.Enabled = False
                    txtExamenes.Tag = dgFiltro.Item(0, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Text = dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value & " " & dgFiltro.Item(2, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = dgFiltro.Item(3, dgFiltro.CurrentRow.Index).Value
                    StockAct = dgFiltro.Item(6, dgFiltro.CurrentRow.Index).Value
                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    txtCantidadE.Select()
            End Select
        End If
    End Sub

    Private Sub btnRetornarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
    End Sub

    Private Sub frmMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbFiltro.Visible = False
        btnGrabar.Enabled = False
        NroFilas = 0
    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then Filtro = "MEDICINA" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtExamenes.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtCantidadE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadE.KeyPress
        If IsNumeric(txtCantidadE.Text) And e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim Importe As String
            Dim Item As New ListViewItem

            Importe = Val(lblPrecioE.Text) * Val(txtCantidadE.Text)
            If Val(Importe) + Val(lblTotalE.Text) > Val(lblSaldo.Text) Then MessageBox.Show("No puede asignar mas Medicina por que sobrepaso el Monto Asignado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub

            If Val(StockAct) < Val(txtCantidadE.Text) Then MessageBox.Show("No puede solitar una cantidad mayor al Stock Actual", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCantidadE.Text = StockAct : Exit Sub

            Item = lvDet.Items.Add(txtExamenes.Tag)
            Item.SubItems.Add(txtExamenes.Text)
            Item.SubItems.Add(lblPrecioE.Text)
            Item.SubItems.Add(txtCantidadE.Text)

            Item.SubItems.Add(Importe)
            lblTotalE.Text = Val(lblTotalE.Text) + Val(Importe)
            txtExamenes.Text = ""
            lblPrecioE.Text = ""
            txtCantidadE.Text = ""
            NroFilas += NroFilas
            btnGrabar.Enabled = True
            txtExamenes.Select()
        End If
    End Sub

    Private Sub lvDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvDet.KeyPress
        If e.KeyChar.ToString.ToUpper = Convert.ToChar(Keys.Q).ToString.ToUpper Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    lblTotalE.Text = Val(lblTotalE.Text) - Val(lvDet.Items(I).SubItems(4).Text)
                    lvDet.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If dsTabla.Tables(0).Rows(0)("IdResponsable").ToString = "" Then
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
                    lblRN.Text = "NO"
                    If dsTabla.Tables(0).Rows(0)("Peso") <> "" Then lblRN.Text = "SI"
                    If dsTabla.Tables(0).Rows(0)("MontoUCI").ToString <> "" Then lblAutorizado.Text = Math.Round(dsTabla.Tables(0).Rows(0)("MontoUCI"), 2) Else lblAutorizado.Text = "0.00"

                    BuscarListaMedicamentos()

                    lblTotalPro.Text = Math.Round(Val(objProcedimiento.TotalProc(CodSis)), 2)
                    lblSaldo.Text = Math.Round(Val(lblAutorizado.Text) - (Val(lblTotalPro.Text) + Val(lblTotalMed.Text)), 2)
                    Dim PorConsumo As Double
                    PorConsumo = Math.Round((100 * (Val(lblTotalPro.Text) + Val(lblTotalMed.Text))) / Val(lblAutorizado.Text), 0)
                    If PorConsumo >= 80 Then MessageBox.Show("PACIENTE YA CONSUMIO SOBRE EL 80% DE SU MONTO TOTAL INFORMAR AL SIS", "Mensaje Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)



                    txtExamenes.Select()
                Else
                    MsgBox("Hoja HIS ya Fue Dada de Alta", MsgBoxStyle.Information, "Mensaje de Información")
                    btnCancelar_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub BuscarListaMedicamentos()
        Dim I As Integer
        Dim Fila As New ListViewItem

        lvMed.Items.Clear()
        lblTotalMed.Text = "0.00"
        'Medicina
        Dim dsMed As New Data.DataSet
        dsMed = objSis.BuscarMedicamentos(CodSis)
        For I = 0 To dsMed.Tables(0).Rows.Count - 1
            Fila = lvMed.Items.Add(dsMed.Tables(0).Rows(I)("IdMedicamento"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Importe"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Hora"))
            If dsMed.Tables(0).Rows(I)("Usuario").ToString <> "" Then Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Usuario")) Else Fila.SubItems.Add("")
            If dsMed.Tables(0).Rows(I)("FechaAten").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("FechaAten"))
            lblTotalMed.Text = Val(lblTotalMed.Text) + Val(dsMed.Tables(0).Rows(I)("Importe"))
        Next
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
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCorrelativo.Text.Length > 0 Then txtExamenes.Select()
    End Sub

    Private Sub txtCorrelativo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCorrelativo.LostFocus
        Dim I As Integer
        For I = 1 To 3 - txtCorrelativo.Text.Length
            txtCorrelativo.Text = "0" & txtCorrelativo.Text
        Next
        txtCorrelativo.Text.Remove(txtCorrelativo.Text.Length - 3, 3)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                objMedicina.SisHRDT_Medicamentos_Grabar(CodSis, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), My.Computer.Name, UsuarioSistema)
                objMedicina.ActStockBienServ(lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(3).Text)
                objMedicina.ActStockBienServDev(lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(3).Text)
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        lvDet.Items.Clear()
        btnGrabar.Enabled = False
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub lvMed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvMed.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de eliminar el procedimiento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvMed.Items.Count - 1
                    If lvMed.Items(I).Selected Then
                        objMedicina.EliminarDetalle(lvMed.Items(I).SubItems(5).Text)
                        BuscarListaMedicamentos()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub cboLote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLote.KeyDown
        If IsNumeric(cboLote.Text) And e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub
End Class