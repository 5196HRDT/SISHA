Public Class frmFacturacion

    Dim objTipoTarifa As New TipoTarifario
    Dim objConvenio As New Convenio
    Dim objFacturacion As New FacturacionEconomia
    Dim NI As Integer
    Dim TipoImpresion As Boolean
    Dim Direccion As String
    Dim Ruc As String

    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim NroFilasHoja As Integer
    Dim NroFilasTotales As Integer
    Dim TotalFilasLV As Integer
    Dim NroLineas As Integer
    Dim NroPagina As Integer = 0


    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub frmReporteAtenciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsCombo As New Data.DataSet
        dsCombo = objTipoTarifa.ComboConvenio
        cboTipoConvenio.DataSource = dsCombo.Tables(0)
        cboTipoConvenio.DisplayMember = "Descripcion"
        cboTipoConvenio.ValueMember = "IdTipoTarifa"
        cboTipo.Text = "FACTURA"
        txtSerie.Text = "001"

        txtAño.Text = Date.Now.Year
        cboMes.Text = Microsoft.VisualBasic.Format(Date.Now, "MMMM")
        txtConcepto.Text = "ATENCION DE PACIENTES EN EL HRDT MES " & cboMes.Text & "-" & txtAño.Text
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lstLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstLista.KeyDown
        If lstLista.Items.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Quitar Nro Convenio", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lstLista.Items.RemoveAt(lstLista.SelectedIndex)
            End If
        End If
    End Sub

    Private Function Verificar() As Boolean
        Dim I As Integer
        Verificar = False
        For I = 0 To lstLista.Items.Count - 1
            If lstLista.Items(I).ToString = txtNroConvenio.Text Then
                Verificar = True
                Exit For
            End If
        Next
    End Function

    Private Sub txtNroConvenio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroConvenio.KeyDown
        If txtNroConvenio.Text <> "" And e.KeyCode = Keys.Enter Then
            If Not Verificar() Then
                Dim dsVer As New Data.DataSet
                dsVer = objConvenio.VerificarParaFacturar(txtNroConvenio.Text, cboTipoConvenio.SelectedValue.ToString)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    lstLista.Items.Add(txtNroConvenio.Text)
                Else
                    MessageBox.Show("Nro de Atencion No existe o No Esta Finalizada para su Facturacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNroConvenio.Text = ""
                    txtNroConvenio.Select()
                End If
            Else
                MessageBox.Show("Nro de Convenio ya fue Asignado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            txtNroConvenio.Text = ""
            txtNroConvenio.Select()
        End If
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If lstLista.Items.Count = 0 Then MessageBox.Show("Debe Ingresar Nro de Convenios para Mostrar Datos", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroConvenio.Select() : Exit Sub
        Dim dsLista As New Data.DataSet
        Dim I, J As Integer
        Dim Fila As ListViewItem
        Dim SubTotal As Double = 0
        Dim FilaTotal As Integer = 0
        lvTab.Items.Clear()
        lblTotal.Text = "0.00"
        For I = 0 To lstLista.Items.Count - 1
            dsLista = objConvenio.RelacionProcedimientos(lstLista.Items(I))
            If dsLista.Tables(0).Rows.Count > 0 Then
                Fila = lvTab.Items.Add(dsLista.Tables(0).Rows(0)("Codigo"))
                Fila.SubItems.Add(dsLista.Tables(0).Rows(0)("APaterno") & " " & dsLista.Tables(0).Rows(0)("AMaterno") & " " & dsLista.Tables(0).Rows(0)("Nombres"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                lvTab.Items(lvTab.Items.Count - 1).BackColor = Color.Coral
                FilaTotal = lvTab.Items.Count - 1
                For J = 0 To dsLista.Tables(0).Rows.Count - 1
                    Fila = lvTab.Items.Add("")
                    Fila.SubItems.Add(dsLista.Tables(0).Rows(J)("Descripcion"))
                    Fila.SubItems.Add(dsLista.Tables(0).Rows(J)("Cantidad"))
                    Fila.SubItems.Add(dsLista.Tables(0).Rows(J)("Precio"))
                    Fila.SubItems.Add(dsLista.Tables(0).Rows(J)("Importe"))
                    Fila.SubItems.Add("")
                    SubTotal = SubTotal + Val(dsLista.Tables(0).Rows(J)("Importe"))
                Next
                lvTab.Items(FilaTotal).SubItems(5).Text = SubTotal
                lblTotal.Text = Val(lblTotal.Text) + SubTotal
                SubTotal = 0
            End If
        Next
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Grabar Facturacion", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If lvTab.Items.Count = 0 Then MessageBox.Show("Debe mostrar informacion para facturar", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If cboTipo.Text = "" Then MessageBox.Show("Debe ingresar tipo de comprobante", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If txtSerie.Text = "" Then MessageBox.Show("Debe ingresar serie de comprobante", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If txtNumero.Text = "" Then MessageBox.Show("Debe ingresar numero de comprobante", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If txtConcepto.Text = "" Then MessageBox.Show("Debe completar datos de concepto de factura", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            'Buscar Tipo Tarifa
            Dim dsTT As New Data.DataSet
            dsTT = objTipoTarifa.BuscarId(cboTipoConvenio.SelectedValue.ToString)
            If dsTT.Tables(0).Rows.Count > 0 Then
                Direccion = dsTT.Tables(0).Rows(0)("Direccion")
                Ruc = dsTT.Tables(0).Rows(0)("Ruc")
            End If

            'Grabar Cancelacion en Convenios
            Dim K As Integer
            For K = 0 To lstLista.Items.Count - 1
                objConvenio.Facturar(lstLista.Items(K), cboTipo.Text, txtSerie.Text, txtNumero.Text)
            Next

            'Grabar Comprobante de Venta
            Dim CodFactura As String
            CodFactura = objFacturacion.Grabar(cboTipo.Text, txtSerie.Text, txtNumero.Text, Microsoft.VisualBasic.Format(dtpFDoc.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, Ruc, cboTipoConvenio.Text, Direccion, "", cboTipoConvenio.Text, "", "", Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 0, Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), "1", "CONVENIO")
            objFacturacion.DetalleGrabar(CodFactura, "1", txtConcepto.Text, lblTotal.Text, lblTotal.Text)


            If lvTab.Items.Count = 0 Then MessageBox.Show("Debe Mostrar Informacion de Convenios para Imprimir", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim I As Integer
            NroLineas = 0
            NroPagina = 1
            NI = 0
            For I = 0 To lvTab.Items.Count - 1
                If lvTab.Items(I).SubItems(0).Text <> "" Then NroLineas += 2
            Next
            NroFilasTotales = 0
            TotalFilasLV = lvTab.Items.Count - 1 + NroLineas
            ppdVistaPrevia.Document = pdcDocumento
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics

            Y = Y + 24
            .DrawString(StrDup(70, " ") & Microsoft.VisualBasic.Left(cboTipo.Text, 1) & " " & txtSerie.Text & "-" & Microsoft.VisualBasic.Right("0000000" & txtNumero.Text, 7), FuenteE, Pincel, 100, Y + 20)

            Y = Y + 24
            .DrawString(cboTipoConvenio.Text, FuenteE, Pincel, 100, Y)

            Y = Y + 24
            .DrawString(Direccion, FuenteE, Pincel, 100, Y)

            Y = Y + 24
            .DrawString(Ruc & StrDup(60, " ") & Microsoft.VisualBasic.Right("00" & dtpFDoc.Value.Day, 2) & StrDup(6, " ") & Microsoft.VisualBasic.Right("00" & dtpFDoc.Value.Month, 2) & StrDup(8, " ") & dtpFDoc.Value.Year, FuenteE, Pincel, 100, Y)
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 140
        Encabezado(e)
        Filas = 10

        Y = Y + 50

        With e.Graphics
            Y = Y + 20
            .DrawString("01" & StrDup(2, " ") & Microsoft.VisualBasic.Left(txtConcepto.Text & StrDup(64, " "), 64) & StrDup(1, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 10) & StrDup(6, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 10), FuenteE, Pincel, 64, Y)
            Y = Y + 15
            .DrawString("ADJUNTO RELACION DE PACIENTES ATENDIDOS", FuenteE, Pincel, 90, Y)

            .DrawString(ValorEnLetras(Val(lblTotal.Text), "Nuevos Soles"), FuenteE, Pincel, 60, 1025)
            .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 14)), FuenteE, Pincel, 630, 1020)
            .DrawString("0.00" & StrDup(8, " ") & "Exonerado", FuenteE, Pincel, 610, 1050)
            .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 14)), FuenteE, Pincel, 630, 1080)
        End With
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lvTab.Items.Clear()
        lblTotal.Text = "0.00"
        txtNumero.Text = ""
        lstLista.Items.Clear()
    End Sub

    Private Sub txtNroConvenio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroConvenio.TextChanged

    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If cboTipo.Text <> "" And e.KeyCode = Keys.Enter Then txtSerie.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If txtSerie.Text <> "" And e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter And txtNumero.Text <> "" Then txtConcepto.Select()
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub cboMes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMes.SelectedIndexChanged
        txtConcepto.Text = "ATENCION DE PACIENTES EN EL HRDT MES " & cboMes.Text & "-" & txtAño.Text
    End Sub

    Private Sub txtAño_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAño.TextChanged
        txtConcepto.Text = "ATENCION DE PACIENTES EN EL HRDT MES " & cboMes.Text & "-" & txtAño.Text
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtDesde_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesde.KeyDown
        If txtDesde.Text <> "" And e.KeyCode = Keys.Enter Then txtHasta.Select()
    End Sub

    Private Sub txtHasta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHasta.KeyDown
        If txtHasta.Text <> "" And txtDesde.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            For I = txtDesde.Text To txtHasta.Text
                txtNroConvenio.Text = I
                txtNroConvenio_KeyDown(sender, e)
            Next
        End If
    End Sub

    Private Sub txtHasta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHasta.TextChanged

    End Sub
End Class