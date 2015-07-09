Public Class frmReporteAtenciones
    Dim objTipoTarifa As New TipoTarifario
    Dim objConvenio As New Convenio
    Dim NI As Integer
    Dim Reporte As Boolean

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

        txtAño.Text = Date.Now.Year
        cboMes.Text = Microsoft.VisualBasic.Format(Date.Now, "MMMM")
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

    Private Sub txtNroConvenio_HideSelectionChanged(sender As Object, e As System.EventArgs) Handles txtNroConvenio.HideSelectionChanged

    End Sub

    Private Sub txtNroConvenio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroConvenio.KeyDown
        If txtNroConvenio.Text <> "" And e.KeyCode = Keys.Enter Then
            If Not Verificar() Then
                Dim dsVer As New Data.DataSet
                dsVer = objConvenio.VerificarTipoConvenio(txtNroConvenio.Text, cboTipoConvenio.Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    lstLista.Items.Add(txtNroConvenio.Text)
                Else
                    MessageBox.Show("Nro de Atencion no Corresponde a Convenio", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Fila.SubItems.Add(lstLista.Items(I))
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

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("CONVENIOS", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString(Date.Now.ToShortDateString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE ECONOMIA CUENTA CORRIENTE", FuenteE, Pincel, 20, Y)
            .DrawString(Date.Now.ToShortTimeString, FuenteE, Pincel, 680, Y)

            Y = Y + 40

            .DrawString("RELACION DE PACIENTES ANTENDIDOS ", Fuente, Pincel, 220, Y)
            Y = Y + 10
            .DrawString("-----------------------------------", Fuente, Pincel, 200, Y)
            Y = Y + 20
            .DrawString(cboTipoConvenio.Text & " Mes de " & cboMes.Text & " " & txtAño.Text, Fuente, Pincel, 220, Y)
            Y = Y + 20
            '.DrawString("Mes de " & cboMes.Text & " " & txtAño.Text, Fuente, Pincel, 280, Y)

            Y = Y + 20
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroPagina = 1
        NI = 0
        NroFilasTotales = 0
        TotalFilasLV = Me.lvTab.Items.Count - 1
        'If Reporte Then TotalFilasLV = NroLineas Else TotalFilasLV = Me.lvTab.Items.Count - 1
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10

        Y = Y + 40
        NroFilasHoja = 0

        If Reporte Then
            With e.Graphics
                .DrawString("Nro", FuenteE, Pincel, 40, Y)
                .DrawString("APELLIDOS Y NOMBRES", FuenteE, Pincel, 120, Y)
                .DrawString("Cant", FuenteE, Pincel, 400, Y)
                .DrawString("Precio", FuenteE, Pincel, 460, Y)
                .DrawString("Sub Total", FuenteE, Pincel, 520, Y)
                .DrawString("IMPORTE", FuenteE, Pincel, 600, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 30, Y, 715, Y)
                Y = Y + 10

                Do While NroFilasTotales <= TotalFilasLV
                    If lvTab.Items.Count > NI Then
                        If lvTab.Items(NI).SubItems(5).Text <> "" Then
                            Y = Y + 10
                            .DrawString(StrDup(100, "-"), FuenteE, Pincel, 20, Y)

                            NroFilasHoja += 1
                            If NroFilasHoja >= 55 Then
                                Exit Do
                            End If
                            NroFilasTotales += 1

                            Y = Y + 10
                            .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(0).Text & StrDup(8, " "), 8), FuenteE, Pincel, 40, Y)
                            .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(6).Text & StrDup(8, " "), 8), FuenteE, Pincel, 100, Y)
                            .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(1).Text & StrDup(60, " "), 60), FuenteE, Pincel, 160, Y)
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvTab.Items(NI).SubItems(2).Text, 5), FuenteE, Pincel, 390, Y)
                            If lvTab.Items(NI).SubItems(3).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(3).Text), "#0.00"), 10), FuenteE, Pincel, 430, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 430, Y)
                            If lvTab.Items(NI).SubItems(4).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(4).Text), "#0.00"), 10), FuenteE, Pincel, 500, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 500, Y)
                            If lvTab.Items(NI).SubItems(5).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(5).Text), "#0.00"), 10), FuenteE, Pincel, 580, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 580, Y)
                            NI += 1
                            NroFilasHoja += 1
                            If NroFilasHoja >= 55 Then
                                Exit Do
                            End If
                            'NroFilasTotales += 1
                            Y = Y + 15
                            .DrawString(StrDup(89, "-"), FuenteE, Pincel, 100, Y)
                            NroFilasHoja += 1
                            If NroFilasHoja >= 55 Then
                                Exit Do
                            End If
                            'NroFilasTotales += 1
                        Else
                            .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(0).Text & StrDup(8, " "), 8), FuenteE, Pincel, 40, Y)
                            .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(1).Text & StrDup(60, " "), 60), FuenteE, Pincel, 100, Y)
                            .DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvTab.Items(NI).SubItems(2).Text, 5), FuenteE, Pincel, 390, Y)
                            If lvTab.Items(NI).SubItems(3).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(3).Text), "#0.00"), 10), FuenteE, Pincel, 430, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 430, Y)
                            If lvTab.Items(NI).SubItems(4).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(4).Text), "#0.00"), 10), FuenteE, Pincel, 500, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 500, Y)
                            If lvTab.Items(NI).SubItems(5).Text <> "" Then .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(5).Text), "#0.00"), 10), FuenteE, Pincel, 580, Y) Else .DrawString(StrDup(10, " "), FuenteE, Pincel, 580, Y)
                            NI += 1
                            NroFilasHoja += 1
                            If NroFilasHoja >= 55 Then
                                Exit Do
                            End If
                            NroFilasTotales += 1
                        End If
                        Y = Y + 15
                    Else
                        Exit Do
                    End If
                Loop
                If NroFilasHoja >= 55 Then
                    Y = Y + 40
                    .DrawString("Pag " & NroPagina, FuenteE, Pincel, 580, Y)
                    NroPagina += 1
                    e.HasMorePages = True
                    NroFilasHoja = 0
                Else
                    .DrawString(StrDup(112, "="), FuenteE, Pincel, 20, Y)
                    Y = Y + 10
                    .DrawString("TOTAL S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 14)), FuenteE, Pincel, 480, Y)
                    Y = Y + 40
                    .DrawString("Pag " & NroPagina, FuenteE, Pincel, 580, Y)
                    e.HasMorePages = False
                End If
            End With
        Else
            With e.Graphics
                .DrawString("Nro", FuenteE, Pincel, 40, Y)
                .DrawString("APELLIDOS Y NOMBRES", FuenteE, Pincel, 120, Y)
                .DrawString("IMPORTE", FuenteE, Pincel, 430, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 30, Y, 715, Y)
                Y = Y + 10
                Do While NroFilasTotales <= TotalFilasLV
                    If NI > TotalFilasLV Then Exit Do
                    If lvTab.Items(NI).SubItems(5).Text <> "" Then
                        Y = Y + 10
                        .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(0).Text & StrDup(8, " "), 8), FuenteE, Pincel, 40, Y)
                        .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(6).Text & StrDup(60, " "), 60), FuenteE, Pincel, 100, Y)
                        .DrawString(Microsoft.VisualBasic.Left(lvTab.Items(NI).SubItems(1).Text & StrDup(60, " "), 60), FuenteE, Pincel, 150, Y)
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvTab.Items(NI).SubItems(5).Text), "#0.00"), 10), FuenteE, Pincel, 420, Y)
                        NroFilasHoja += 1
                        If NroFilasHoja >= 60 Then
                            NI += 1
                            Exit Do
                        End If
                        Y = Y + 15
                        .DrawString(StrDup(89, "-"), FuenteE, Pincel, 100, Y)
                        NroFilasHoja += 1
                        If NroFilasHoja >= 60 Then
                            NI += 1
                            Exit Do
                        End If
                    End If
                    NI += 1
                    NroFilasTotales += 1
                Loop
                If NroFilasHoja >= 60 Then
                    Y = Y + 40
                    .DrawString("Pag " & NroPagina, FuenteE, Pincel, 580, Y)
                    NroPagina += 1
                    e.HasMorePages = True
                    NroFilasHoja = 0
                Else
                    .DrawString(StrDup(89, "="), FuenteE, Pincel, 20, Y)
                    Y = Y + 10
                    .DrawString("TOTAL S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblTotal.Text), "#0.00"), 14)), FuenteE, Pincel, 288, Y)
                    Y = Y + 40
                    .DrawString("Pag " & NroPagina, FuenteE, Pincel, 580, Y)
                    e.HasMorePages = False
                End If
            End With
        End If
    End Sub

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If lvTab.Items.Count = 0 Then MessageBox.Show("Debe Mostrar Informacion de Convenios", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Esta seguro de Finalizar el Listado de Atenciones", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lstLista.Items.Count - 1
                objConvenio.Finalizar(lstLista.Items(I), Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"), Microsoft.VisualBasic.Timer, UsuarioSistema, Me.CompanyName)
            Next
        End If
        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lvTab.Items.Clear()
        lstLista.Items.Clear()
        lblTotal.Text = "0.00"
    End Sub

    Private Sub btnImprimirRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirRes.Click
        If lvTab.Items.Count = 0 Then MessageBox.Show("Debe Mostrar Informacion de Convenios para Imprimir", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim I As Integer
        Reporte = False
        NroLineas = 0
        For I = 0 To lvTab.Items.Count - 1
            If lvTab.Items(I).SubItems(5).Text <> "" Then NroLineas += 1
        Next
        ppdVistaPrevia.Document = pdcDocumento
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvTab.Items.Count = 0 Then MessageBox.Show("Debe Mostrar Informacion de Convenios para Imprimir", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim I As Integer
        Reporte = True
        NroLineas = 0
        For I = 0 To lvTab.Items.Count - 1
            If lvTab.Items(I).SubItems(0).Text <> "" Then NroLineas += 3 Else NroLineas += 1
        Next
        ppdVistaPrevia.Document = pdcDocumento
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub cboMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMes.KeyDown
        If e.KeyCode = Keys.Enter And cboMes.Text <> "" Then txtAño.Select()
    End Sub

    Private Sub txtAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAño.KeyDown
        If e.KeyCode = Keys.Enter And txtAño.Text <> "" Then cboTipoConvenio.Select()
    End Sub

    Private Sub cboTipoConvenio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoConvenio.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoConvenio.Text <> "" Then txtNroConvenio.Select()
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

    Private Sub txtDesde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesde.TextChanged

    End Sub

    Private Sub txtHasta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHasta.TextChanged

    End Sub

    Private Sub txtNroConvenio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroConvenio.TextChanged

    End Sub
End Class