Public Class frmServicios
    Dim objHistoria As New Historia
    Dim objConvenio As New Convenio
    Dim objTipoTarifa As New TipoTarifario
    Dim objExamen As New Procedimientos
    Dim objConsultaExterna As New clsConsultaExterna
    Dim IdDetalle As String
    Dim CodConvenio As String
    Dim NroFila As Integer
    Dim NroFilas As String
    Dim Filtro As String
    Dim Oper As String
    Dim CodLocal As String

    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim Pincel As New SolidBrush(Color.Black)


    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim TotalFilas As Integer
    Dim FilasHoja As Integer
    Dim NroPag As Integer
    Dim X, Y As Integer


    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text.Length > 0 And e.KeyCode = Keys.Enter Then dgFiltro.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Select Case Filtro
            Case "EXAMENES"
                Dim rsExa As New Data.DataSet
                rsExa = objExamen.BuscarTarifarioConDes(cboTipoConvenio.SelectedValue.ToString, txtFiltro.Text)
                dgFiltro.DataSource = rsExa.Tables(0)
                dgFiltro.Columns(0).Width = 60
                dgFiltro.Columns(1).Width = 350
                dgFiltro.Columns(2).Width = 70
        End Select
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarH.Click
        NumeroHistoria = ""
        frmBuscarHistoria.Show()
    End Sub

    Private Sub txtExamenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExamenes.KeyDown

    End Sub

    Private Sub txtExamenes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExamenes.TextChanged
        If txtExamenes.Text <> "" And txtExamenes.Enabled Then Filtro = "EXAMENES" : gbFiltro.Visible = True : txtFiltro.Text = txtExamenes.Text : txtFiltro.SelectionStart = Len(txtExamenes.Text) : txtFiltro.Select()
    End Sub

    Private Sub txtCantidadE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadE.KeyPress
        If IsNumeric(txtCantidadE.Text) And e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Dim Importe As String
            Dim Item As New ListViewItem
            Item = lvDet.Items.Add(txtExamenes.Tag)
            Item.SubItems.Add(txtExamenes.Text)
            Item.SubItems.Add(lblPrecioE.Text)
            Item.SubItems.Add(txtCantidadE.Text)
            Importe = Val(lblPrecioE.Text) * Val(txtCantidadE.Text)
            Item.SubItems.Add(Importe)
            Item.SubItems.Add(txtCantidadE.Tag)
            lblTotalE.Text = Val(lblTotalE.Text) + Val(Importe)
            If meFecha1.Text = "__/__/____" Then Item.SubItems.Add("") Else Item.SubItems.Add(meFecha1.Text)
            If meFecha2.Text = "__/__/____" Then Item.SubItems.Add("") Else Item.SubItems.Add(meFecha2.Text)
            Item.SubItems.Add(lblSubTipo.Text)
            txtExamenes.Text = ""
            lblPrecioE.Text = ""
            txtCantidadE.Text = ""
            'meFecha1.Text = "__/__/____"
            meFecha2.Text = "__/__/____"
            NroFilas += NroFilas
            btnGrabar.Enabled = True
            txtExamenes.Select()
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        lvDet.Items.Clear()
        btnGrabar.Enabled = False
        lvSer.Items.Clear()
        txtHistoria.Enabled = False
        lvDet.Items.Clear()
        Botones(True, False, False, True)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            Dim SubTipo As String
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).SubItems(5).Text = "LABORATORIO" Or lvDet.Items(I).SubItems(5).Text = "DIAGNOSTICO DE IMAGENES" Then
                    objConvenio.GrabarProcedimientos(CodLocal, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, My.Computer.Name, lvDet.Items(I).SubItems(6).Text, lvDet.Items(I).SubItems(7).Text)
                Else
                    objConvenio.GrabarProcedimientosAtendidos(CodLocal, lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name, lvDet.Items(I).SubItems(6).Text, lvDet.Items(I).SubItems(7).Text)
                End If
                If lvDet.Items.Item(I).SubItems(8).Text <> "ORINA" Then SubTipo = lvDet.Items.Item(I).SubItems(8).Text Else SubTipo = "MICROBIOLOGIA"
                If cboTipo.Text = "CONSULTA EXTERNA" Then objConsultaExterna.GrabarExaOrigen(0, lvDet.Items.Item(I).SubItems(0).Text, lvDet.Items.Item(I).SubItems(1).Text, lvDet.Items.Item(I).SubItems(2).Text, lvDet.Items.Item(I).SubItems(3).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lvDet.Items.Item(I).SubItems(5).Text, SubTipo, cboTipoConvenio.Text, CodLocal, "", "", txtHistoria.Text, lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, "CONVENIO", "")
            Next
        End If

        ppdVistaPrevia.Document = pdRecibo
        ppdVistaPrevia.ShowDialog()

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnBuscarH.Enabled = True
        btnBuscarH.Select()
        Oper = "1"
        txtHistoria.Enabled = True
        txtHistoria.Select()
    End Sub

    Private Sub HistorialPro()
        lvSer.Items.Clear()
        Dim dsHistorial As New Data.DataSet
        dsHistorial = objConvenio.BuscarHistorialPro(CodLocal)
        lblTotalSer.Text = "0.00"
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsHistorial.Tables(0).Rows.Count - 1
            Fila = lvSer.Items.Add(dsHistorial.Tables(0).Rows(I)("IdProcedimiento"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("Importe"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("Id"))
            If dsHistorial.Tables(0).Rows(I)("FechaAtencion").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("FechaAtencion"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("F1"))
            Fila.SubItems.Add(dsHistorial.Tables(0).Rows(I)("F2"))
            lblTotalSer.Text = Val(lblTotalSer.Text) + Val(dsHistorial.Tables(0).Rows(I)("Importe"))
        Next
    End Sub

    Private Sub BuscarDatos()
        NumeroHistoria = txtHistoria.Text
        If Val(NumeroHistoria) > 0 Then
            txtHistoria.Text = NumeroHistoria
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then
                    lblFecha.Text = ""
                    lblEdad.Text = ""
                Else
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento")
                    lblEdad.Text = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTabla.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")

                Dim dsVer As New Data.DataSet
                dsVer = objConvenio.Verificar(txtHistoria.Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    Oper = 2
                    CodLocal = dsVer.Tables(0).Rows(0)("IdConvenio")
                    cboTipo.Text = dsVer.Tables(0).Rows(0)("Tipo")
                    txtCodigo.Text = dsVer.Tables(0).Rows(0)("Codigo")
                    cboTipoConvenio.Text = dsVer.Tables(0).Rows(0)("TipoConvenio")

                    'Buscar Historia de Procedimientos
                    HistorialPro()
                Else
                    MessageBox.Show("Atención de Convenio no Existe o ya fue dada de Alta", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Me.txtExamenes.Select()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
        End If
        NumeroHistoria = ""
    End Sub

    Private Sub frmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        gbFiltro.Visible = False
        btnGrabar.Enabled = False
        btnBuscarH.Enabled = False
        NroFilas = 0

        Dim dsCombo As New Data.DataSet
        dsCombo = objTipoTarifa.ComboConvenio
        cboTipoConvenio.DataSource = dsCombo.Tables(0)
        cboTipoConvenio.DisplayMember = "Descripcion"
        cboTipoConvenio.ValueMember = "IdTipoTarifa"

        cboTipo.Enabled = False
        cboTipoConvenio.Enabled = False
        txtCodigo.Enabled = False
        txtHistoria.Enabled = False
    End Sub

    Private Sub btnRetornarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarF.Click
        gbFiltro.Visible = False
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

    Private Sub dgFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFiltro.KeyDown
        'If dgFiltro.Rows.Count > 0 And e.KeyCode = Keys.I Then
        If dgFiltro.Rows.Count > 0 And e.KeyCode = Keys.Enter Then
            Select Case Filtro
                Case "EXAMENES"
                    txtExamenes.Enabled = False
                    txtExamenes.Tag = dgFiltro.Item(0, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Text = dgFiltro.Item(1, dgFiltro.CurrentRow.Index).Value
                    txtExamenes.Enabled = True
                    lblPrecioE.Text = dgFiltro.Item(2, dgFiltro.CurrentRow.Index).Value
                    txtCantidadE.Tag = dgFiltro.Item(3, dgFiltro.CurrentRow.Index).Value
                    lblSubTipo.Text = dgFiltro.Item(4, dgFiltro.CurrentRow.Index).Value

                    gbFiltro.Visible = False
                    txtCantidadE.Text = 1
                    If NivelUsuario = "CONVENIOC" Then meFecha1.Text = Date.Now.ToShortDateString
                    meFecha1.Select()
            End Select
        End If
    End Sub

    Private Sub lvSer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvSer.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Anular el procedimiento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objConvenio.AnularDetalle(IdDetalle, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, My.Computer.Name)
                HistorialPro()
            End If
            MessageBox.Show("Servicio Anulado Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        If MessageBox.Show("Esta seguro de Dar Alta para Facturacion de Atencion de Convenio", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objConvenio.Finalizar(CodLocal, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, My.Computer.Name)
            MessageBox.Show("Atencion de Convenio ya fue Finalizado, para su Facturacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub lvSer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSer.SelectedIndexChanged
        If lvSer.SelectedItems.Count > 0 Then
            IdDetalle = lvSer.SelectedItems(0).SubItems(5).Text
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ppdVistaPrevia.Document = pdcDocumento
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("CONVENIOS", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString(Date.Now.ToShortDateString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE ECONOMIA", FuenteE, Pincel, 80, Y)
            .DrawString(Date.Now.ToShortTimeString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("Pag:" & NroPag, FuenteE, Pincel, 680, Y)

            Y = Y + 40

            .DrawString("L I Q U I D A C I O N  Nro: " & CodLocal, Fuente, Pincel, 120, Y)
            Y = Y + 10
            .DrawString("-----------------------------------", Fuente, Pincel, 100, Y)

            Y = Y + 30
            .DrawString("Paciente   :", FuenteE, Pincel, 40, Y)
            .DrawString(lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Historia  :", FuenteE, Pincel, 450, Y)
            .DrawString(txtHistoria.Text, FuenteE, Pincel, 530, Y)

            Y = Y + 20
            .DrawString("Convenio   :", FuenteE, Pincel, 40, Y)
            .DrawString(cboTipoConvenio.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Tipo Aten  :", FuenteE, Pincel, 450, Y)
            .DrawString(cboTipo.Text, FuenteE, Pincel, 530, Y)

        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvSer.Items.Count - 1
        NroFila = 0
        FilasHoja = 0
        NroPag = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        NroPag += 1
        Encabezado(e)
        Filas = 10

        Y = Y + 40

        With e.Graphics
            .DrawString("Codigo", FuenteE, Pincel, 40, Y)
            .DrawString("Descripcion", FuenteE, Pincel, 120, Y)
            .DrawString("Precio", FuenteE, Pincel, 600, Y)
            .DrawString("Cant", FuenteE, Pincel, 660, Y)
            .DrawString("Importe", FuenteE, Pincel, 720, Y)
            Y = Y + 10
            .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
            Y = Y + 10
            Dim I As Integer
            Do While TotalFilas > 0
                .DrawString(lvSer.Items(NroFila).SubItems(0).Text, FuenteE, Pincel, 40, Y)
                'Cadena Detalle
                Dim CadDet As String
                If lvSer.Items(NroFila).SubItems(6).Text <> "  /  /" And lvSer.Items(NroFila).SubItems(6).Text <> "" Then
                    CadDet = (lvSer.Items(NroFila).SubItems(1).Text & " " & lvSer.Items(NroFila).SubItems(6).Text).Trim
                Else
                    CadDet = (lvSer.Items(NroFila).SubItems(1).Text).Trim
                End If

                If lvSer.Items(NroFila).SubItems(7).Text <> "  /  /" And lvSer.Items(NroFila).SubItems(7).Text <> "" Then
                    CadDet = (CadDet & " " & lvSer.Items(NroFila).SubItems(7).Text).Trim
                End If

                If CadDet.Length > 60 Then
                    .DrawString(CadDet.Remove(60, CadDet.Length - 60), FuenteE, Pincel, 120, Y)
                Else
                    .DrawString(CadDet, FuenteE, Pincel, 120, Y)
                End If
                .DrawString((StrDup(8 - lvSer.Items(NroFila).SubItems(2).Text.Remove(lvSer.Items(NroFila).SubItems(2).Text.Length - 2, 2).Length, " ") & lvSer.Items(NroFila).SubItems(2).Text.Remove(lvSer.Items(NroFila).SubItems(2).Text.Length - 2, 2)), FuenteE, Pincel, 580, Y)
                If lvSer.Items(NroFila).SubItems(3).Text.Length > 4 Then
                    .DrawString((StrDup(lvSer.Items(NroFila).SubItems(3).Text.Length - 4, " ") & lvSer.Items(NroFila).SubItems(3).Text), FuenteE, Pincel, 660, Y)
                Else
                    .DrawString(StrDup(4 - lvSer.Items(NroFila).SubItems(3).Text.Length, " ") & lvSer.Items(NroFila).SubItems(3).Text, FuenteE, Pincel, 660, Y)
                End If
                .DrawString((StrDup(10 - lvSer.Items(NroFila).SubItems(4).Text.Remove(lvSer.Items(NroFila).SubItems(4).Text.Length - 2, 2).Length, " ") & lvSer.Items(NroFila).SubItems(4).Text.Remove(lvSer.Items(NroFila).SubItems(4).Text.Length - 2, 2)), FuenteE, Pincel, 700, Y)
                Y = Y + 15
                NroFila += 1
                FilasHoja += 1
                TotalFilas -= 1
                If FilasHoja > 50 Then Exit Do
            Loop

            If TotalFilas > 0 Then
                FilasHoja = 0
                e.HasMorePages = True
            Else
                e.HasMorePages = False
                .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                Y = Y + 10
                .DrawString("TOTAL DE SERVICIOS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotalSer.Text), "#0.00"), 14)), FuenteE, Pincel, 508, Y)
                Y = Y + 10
            End If
        End With

    End Sub

    Private Sub meFecha1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles meFecha1.KeyDown
        If e.KeyCode = Keys.Enter Then Me.meFecha2.Select()
    End Sub

    Private Sub meFecha2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles meFecha2.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtCantidadE.Select()
    End Sub

    Private Sub dgFiltro_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFiltro.CellContentClick

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtExamenes.Select()
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then btnMostrar.Select()
    End Sub

    Private Sub EncabezadoR(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("CONVENIOS", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString(Date.Now.ToShortDateString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE ECONOMIA", FuenteE, Pincel, 80, Y)
            .DrawString(Date.Now.ToShortTimeString, FuenteE, Pincel, 680, Y)

            Y = Y + 40

            .DrawString("ATENCION DE PROCEDIMIENTOS", Fuente, Pincel, 120, Y)
            Y = Y + 10
            .DrawString("-----------------------------------", Fuente, Pincel, 100, Y)

            Y = Y + 30
            .DrawString("Paciente   :", FuenteE, Pincel, 40, Y)
            .DrawString(lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Historia  :", FuenteE, Pincel, 450, Y)
            .DrawString(txtHistoria.Text, FuenteE, Pincel, 530, Y)

            Y = Y + 20
            .DrawString("Convenio   :", FuenteE, Pincel, 40, Y)
            .DrawString(cboTipoConvenio.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Tipo Aten  :", FuenteE, Pincel, 450, Y)
            .DrawString(cboTipo.Text, FuenteE, Pincel, 530, Y)

        End With
    End Sub

    Private Sub pdRecibo_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdRecibo.BeginPrint
        TotalFilas = lvSer.Items.Count - 1
        NroFila = 0
        FilasHoja = 0
    End Sub

    Private Sub pdRecibo_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdRecibo.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        EncabezadoR(e)
        Filas = 10

        Y = Y + 40

        With e.Graphics
            .DrawString("Codigo", FuenteE, Pincel, 40, Y)
            .DrawString("Descripcion", FuenteE, Pincel, 120, Y)
            .DrawString("Precio", FuenteE, Pincel, 600, Y)
            .DrawString("Cant", FuenteE, Pincel, 660, Y)
            .DrawString("Importe", FuenteE, Pincel, 720, Y)
            Y = Y + 10
            .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
            Y = Y + 10
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                .DrawString(lvDet.Items(I).SubItems(0).Text, FuenteE, Pincel, 40, Y)
                .DrawString(lvDet.Items(I).SubItems(1).Text, FuenteE, Pincel, 120, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvDet.Items(I).SubItems(2).Text), "#.00"), 9), FuenteE, Pincel, 600, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(6, " ") & lvDet.Items(I).SubItems(3).Text, 6), FuenteE, Pincel, 660, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvDet.Items(I).SubItems(4).Text), "#.00"), 9), FuenteE, Pincel, 720, Y)
                Y = Y + 15
            Next
            .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
            Y = Y + 10
            .DrawString("TOTAL DE PROCEDIMIENTOS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotalE.Text), "#0.00"), 14)), FuenteE, Pincel, 508, Y)
            Y = Y + 10
        End With
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        BuscarDatos()
    End Sub

    Private Sub txtCantidadE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadE.TextChanged

    End Sub
End Class