Public Class frmProcedimientos
    Dim Filtro As String
    Dim objSIS As New SIS
    Dim objExamen As New Procedimientos
    Dim objMed As New Medicamentos
    Dim NroFilas As Integer
    Dim CodSis As String
    Dim TipoAtencionPaciente As String

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text.Length > 0 And e.KeyCode = Keys.Enter Then dgFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Select Case Filtro
            Case "EXAMENES"
                Dim rsExa As New Data.DataSet
                rsExa = objExamen.BuscarServicio(txtFiltro.Text & "%", 12, "D")
                dgFiltro.DataSource = rsExa.Tables(0)
                dgFiltro.Columns(0).Width = 60
                dgFiltro.Columns(1).Width = 350
                dgFiltro.Columns(2).Width = 70
        End Select
    End Sub

    Private Sub dgFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFiltro.KeyDown
        If dgFiltro.Rows.Count > 0 And e.KeyCode = Keys.I Then
            Select Case Filtro
                Case "EXAMENES"
                    If TipoAtencionPaciente = "RECIEN NACIDO" And dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value <> "GRUPO SANGUINEO Y FACTOR RH" Then
                        MessageBox.Show("Solament puede asignar el procedimiento de GRUPO SANGUINEO Y FACTOR RH", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    txtExamenes.Enabled = False
                    txtExamenes.Tag = dgFiltro.Item(0, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Text = dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = dgFiltro.Item(2, dgFiltro.CurrentRow.Index).Value
                    txtCantidadE.Tag = dgFiltro.Item(5, dgFiltro.CurrentRow.Index).Value
                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    txtCantidadE.Select()
            End Select
        End If
    End Sub

    Private Sub btnRetornarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
    End Sub

    Private Sub frmProcedimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbFiltro.Visible = False
        btnGrabar.Enabled = False
        NroFilas = 0
    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtExamenes.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtCantidadE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadE.KeyPress
        If IsNumeric(txtCantidadE.Text) And e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim Importe As String
            Dim Item As New ListViewItem

            Importe = Val(lblPrecioE.Text) * Val(txtCantidadE.Text)
            If NivelSistema = "HOSPITALIZACION" Then If Val(Importe) + Val(lblTotalE.Text) > Val(lblSaldo.Text) Then MessageBox.Show("No puede asignar mas Procedimientos por que sobrepaso el Monto Asignado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub

            Item = lvDet.Items.Add(txtExamenes.Tag)
            Item.SubItems.Add(txtExamenes.Text)
            Item.SubItems.Add(lblPrecioE.Text)
            Item.SubItems.Add(txtCantidadE.Text)

            Item.SubItems.Add(Importe)
            Item.SubItems.Add(txtCantidadE.Tag)
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        lvDet.Items.Clear()
        btnGrabar.Enabled = False
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
        lvSer.Items.Clear()
        gbFiltro.Visible = False
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).SubItems(5).Text <> "LABORATORIO" And lvDet.Items(I).SubItems(5).Text <> "RAYOS" And Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text, 12) <> "ESPIROMETRIA" And Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text, 18) <> "ELECTROCARDIOGRAMA" And Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text, 20) <> "ELECTROENCEFALOGRAMA" Then
                    objSIS.GrabarProcedimientosAtendidos(CodSis, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name)
                Else
                    objSIS.GrabarProcedimientosN(CodSis, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name)
                End If
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            Dim FechaContrato As Date
            dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
            If dsTabla.Tables(0).Rows.Count = 0 Then MessageBox.Show("Formato de Atencion no Existe!!!", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
            If dsTabla.Tables(0).Rows(0)("FechaVtoContrato").ToString <> "" Then FechaContrato = dsTabla.Tables(0).Rows(0)("FechaVtoContrato")
            If FechaContrato < Date.Now.ToShortDateString Then MessageBox.Show("Contrato de Paciente ya Vencio", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If dsTabla.Tables(0).Rows(0)("FechaAlta").ToString = "" Then
                    'If dsTabla.Tables(0).Rows(0)("Especialidad") = "RECIEN NACIDO" Then MessageBox.Show("Paciente es un RN No puede Ingrear Procedimientos.....", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnCancelar_Click(sender, e) : Exit Sub
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
                    If dsTabla.Tables(0).Rows(0)("MontoUCI").ToString <> "" Then lblAutorizado.Text = Math.Round(Val(dsTabla.Tables(0).Rows(0)("MontoUCI")), 2) Else lblAutorizado.Text = "0.00"
                    TipoAtencionPaciente = dsTabla.Tables(0).Rows(0)("Especialidad")

                    BuscarListaProcedimientos()

                    lblTotalMed.Text = Math.Round(Val(objMed.TotalMed(CodSis)), 2)
                    If NivelSistema = "HOSPITALIZACION" Then lblSaldo.Text = Math.Round(Val(lblAutorizado.Text) - (Val(lblTotalSer.Text) + Val(lblTotalMed.Text)), 2)
                    If dsTabla.Tables(0).Rows(0)("SubEspecialidad") = "UCI" Then
                        Dim PorConsumo As Double
                        PorConsumo = Math.Round((100 * (Val(lblTotalSer.Text) + Val(lblTotalMed.Text))) / Val(lblAutorizado.Text), 0)
                        If NivelSistema = "HOSPITALIZACION" Then If PorConsumo >= 80 Then MessageBox.Show("PACIENTE YA CONSUMIO SOBRE EL 80% DE SU MONTO TOTAL INFORMAR AL SIS", "Mensaje Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    btnGrabar.Enabled = True
                    txtExamenes.Select()
                Else
                    If MessageBox.Show("Hoja HIS ya Fue Dada de Alta, Desea Visualizar los Procedimientos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        btnCancelar_Click(sender, e)
                    Else
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

                        BuscarListaProcedimientos()
                        btnGrabar.Enabled = False
                        txtExamenes.Select()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BuscarListaProcedimientos()
        Dim I As Integer
        Dim Fila As New ListViewItem

        lvSer.Items.Clear()
        lblTotalSer.Text = "0.00"
        'Serivicios
        Dim dsSer As New Data.DataSet
        dsSer = objSIS.BuscarProcedimientos(CodSis)
        For I = 0 To dsSer.Tables(0).Rows.Count - 1
            Fila = lvSer.Items.Add(dsSer.Tables(0).Rows(I)("IdProcedimiento"))
            Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Importe"))
            Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Id"))
            If Not dsSer.Tables(0).Rows(I)("FechaAtencion").ToString = "" Then Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("FechaAtencion"))
            lblTotalSer.Text = Val(lblTotalSer.Text) + Val(dsSer.Tables(0).Rows(I)("Importe"))
        Next
    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumero.Text.Length
            txtNumero.Text = "0" & txtNumero.Text
        Next
        txtNumero.Text.Remove(txtNumero.Text.Length - 8, 8)
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

    Private Sub cboLoteA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLoteA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLoteA.Text.Length > 0 Then txtNumeroA.Select()
    End Sub

    Private Sub cboLote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLote.Text.Length > 0 Then txtNumero.Select()
    End Sub

    Private Sub lvSer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvSer.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de eliminar el procedimiento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvSer.Items.Count - 1
                    If lvSer.Items(I).Selected Then
                        objSIS.AnularDetalle(lvSer.Items(I).SubItems(5).Text)
                        BuscarListaProcedimientos()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtNumero_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtNumero.MaskInputRejected

    End Sub

    Private Sub dgFiltro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFiltro.CellContentClick

    End Sub
End Class