Public Class frmControlCuentaSIS
    Dim objSis As New SIS
    Dim CodSis As String
    Dim NroPagina As String

    Dim NroFilasTotales As Integer
    Dim PosicionFila As Integer
    Dim TotalFilasLV As Integer
    Dim NroFilasHoja As Integer
    Dim Pagina As Integer

    Dim FuenteE As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim FuenteCab As New Font("Lucida Console", 10)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim ExamenInforme As String
    Dim Radiologo As String
    Dim FechaAtencion As String
    Dim InformeExamen As String
    Dim Linea As Integer
    Dim NroFila As Integer
    Dim TotalFilas As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lvMed.Items.Clear()
        lvSer.Items.Clear()
        Limpiar(Me)
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then
            lvMed.Items.Clear()
            lvSer.Items.Clear()
            Dim dsTabla As New Data.DataSet
            dsTabla = objSis.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
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

                If dsTabla.Tables(0).Rows(0)("FechaAlta").ToString <> "" Then
                    lblFechaAlta.Text = dsTabla.Tables(0).Rows(0)("FechaAlta")
                    If lblFechaAlta.Text.Length > 10 Then lblFechaAlta.Text = lblFechaAlta.Text.Remove(10, 14)
                Else
                    lblFechaAlta.Text = ""
                End If
                If dsTabla.Tables(0).Rows(0)("HoraAlta").ToString <> "" Then
                    lblHoraAlta.Text = dsTabla.Tables(0).Rows(0)("HoraAlta")
                Else
                    lblHoraAlta.Text = ""
                End If
                lblTotalSer.Text = "0.00"
                lblTotalMed.Text = "0.00"

                Dim I As Integer
                Dim Fila As New ListViewItem

                'Medicina
                Dim dsMed As New Data.DataSet
                dsMed = objSis.BuscarMedicamentos(CodSis)
                For I = 0 To dsMed.Tables(0).Rows.Count - 1
                    Fila = lvMed.Items.Add(dsMed.Tables(0).Rows(I)("IdMedicamento"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Cantidad"))
                    Fila.SubItems.Add(dsMed.Tables(0).Rows(I)("Importe"))
                    lblTotalMed.Text = Val(lblTotalMed.Text) + Val(dsMed.Tables(0).Rows(I)("Importe"))
                Next

                'Serivicios
                Dim dsSer As New Data.DataSet
                If chkAtendido.Checked Then
                    dsSer = objSis.BuscarProcedimientosAten(CodSis)
                Else
                    dsSer = objSis.BuscarProcedimientos(CodSis)
                End If
                For I = 0 To dsSer.Tables(0).Rows.Count - 1
                    Fila = lvSer.Items.Add(dsSer.Tables(0).Rows(I)("Id"))
                    Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Cantidad"))
                    Fila.SubItems.Add(dsSer.Tables(0).Rows(I)("Importe"))
                    lblTotalSer.Text = Val(lblTotalSer.Text) + Val(dsSer.Tables(0).Rows(I)("Importe"))
                Next
                lblCuenta.Text = Val(lblTotalMed.Text) + Val(lblTotalSer.Text)
                btnImprimir.Select()
            End If
        End If
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

    Private Sub txtCorrelativo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCorrelativo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtCorrelativo.Text.Length > 0 Then btnImprimir.Select()
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



    Private Sub ResumenMedicamento()
        Dim I As Integer
        Dim Fila As New ListViewItem
        Dim dsTabla As New Data.DataSet
        lvMedR.Items.Clear()
        dsTabla = objSis.BuscarResumenMed(CodSis)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvMedR.Items.Add(dsTabla.Tables(0).Rows(I)("Cant"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Importe"))
        Next
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Resumen de Medicamentos", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ResumenMedicamento()
            ppdVistaPrevia.Document = pdcFarmacia
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub LlenarCon()
        Dim I As Integer
        Dim TFila As Integer = -1
        Dim NroFila As Integer = -1
        Dim Fila As New ListViewItem
        Dim dsTabla As New Data.DataSet
        lvCon.Items.Clear()
        'Radiografia y Ecografia
        dsTabla = objSis.BuscarProcedimientosConsolidados(CodSis)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If dsTabla.Tables(0).Rows(I)("Tipo") <> "LABORATORIO" Then
                Fila = lvCon.Items.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                TFila += 1
                NroFila += 1
            End If
        Next
        'Laboratorio
        Dim CorrelativoFila As Integer = 0
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            If dsTabla.Tables(0).Rows(I)("Tipo") = "LABORATORIO" Then
                If CorrelativoFila <= TFila Then
                    lvCon.Items.Item(CorrelativoFila).SubItems(2).Text = dsTabla.Tables(0).Rows(I)("Descripcion")
                    lvCon.Items.Item(CorrelativoFila).SubItems(3).Text = dsTabla.Tables(0).Rows(I)("Cantidad")
                    'NroFila += 1
                    CorrelativoFila += 1
                Else
                    Fila = lvCon.Items.Add("")
                    Fila.SubItems.Add("")
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cantidad"))
                End If

            End If
        Next
    End Sub

    Private Sub btnProcedimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcedimientos.Click
        If MessageBox.Show("Esta seguro de Imprimir Procedimientos", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            LlenarCon()
            ppdVistaPrevia.Document = pdcDocumento
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        e.Graphics.DrawString(lblHEI.Text & " " & cboLote.Text & "-" & txtNumero.Text, FuenteTitulo, Brushes.Black, 600, 50)
        Dim I As Integer
        Dim Y As Integer = 120
        For I = 0 To Me.lvCon.Items.Count - 1
            Y = Y + 10
            e.Graphics.DrawString(Microsoft.VisualBasic.Left(lvCon.Items.Item(I).SubItems(0).Text & StrDup(40, " "), 40) & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & lvCon.Items.Item(I).SubItems(1).Text, 9) & StrDup(3, " ") & Microsoft.VisualBasic.Left(lvCon.Items.Item(I).SubItems(2).Text & StrDup(40, " "), 40) & StrDup(5, " ") & Microsoft.VisualBasic.Right(StrDup(4, " ") & lvCon.Items.Item(I).SubItems(3).Text, 4), FuenteE, Brushes.Black, 40, Y)
        Next
    End Sub

    Private Sub btnRayos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRayos.Click
        Dim dsTabla As New Data.DataSet
        Dim I As Integer
        For I = 0 To lvSer.Items.Count - 1
            If lvSer.Items.Item(I).Selected Then
                dsTabla = objSis.BuscarInformRX(lvSer.Items.Item(I).SubItems(0).Text)
                If dsTabla.Tables(0).Rows.Count > 0 Then
                    FechaAtencion = dsTabla.Tables(0).Rows(0)("FechaAtencion")
                    Radiologo = dsTabla.Tables(0).Rows(0)("Personal")
                    InformeExamen = dsTabla.Tables(0).Rows(0)("Informe")

                    'If dsTabla.Tables(0).Rows(0)("Firma").ToString <> "" Then
                    Dim bytBLOBData() As Byte = dsTabla.Tables(0).Rows(0)("Firma")
                    Dim stmBLOBData As New System.IO.MemoryStream(bytBLOBData)

                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
                    pbImagen.Image = Image.FromStream(stmBLOBData)

                    'End If

                    ExamenInforme = lvSer.Items.Item(I).SubItems(1).Text
                    ppdVistaPrevia.Document = pdInformeRX
                    ppdVistaPrevia.ShowDialog()
                Else
                    MessageBox.Show("Informe no ha sido elaborado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub pdInformeRX_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdInformeRX.PrintPage
        e.Graphics.DrawString("Hospital Regional Docente de Trujillo", FuenteE, Brushes.Black, 30, 20)
        e.Graphics.DrawString(StrDup(110, "_"), FuenteE, Brushes.Black, 30, 25)
        e.Graphics.DrawString("INFORME DE AYUDA AL DIAGNOSTICO POR IMAGENES", FuenteTitulo, Brushes.Black, 100, 40)
        e.Graphics.DrawString("------------------------------------------------------------------------------", FuenteE, Brushes.Black, 100, 60)

        e.Graphics.DrawString("Formato  :   " & lblHEI.Text & " " & cboLote.Text & "-" & txtNumero.Text, FuenteE, Brushes.Black, 30, 80)
        e.Graphics.DrawString("Paciente :   " & lblHistoria.Text & " - " & lblPaciente.Text, FuenteE, Brushes.Black, 30, 100)
        e.Graphics.DrawString("Fecha    :   " & FechaAtencion, FuenteE, Brushes.Black, 30, 120)
        e.Graphics.DrawString("Radiologo:   " & Radiologo, FuenteE, Brushes.Black, 30, 140)
        e.Graphics.DrawString("Examen   :   " & ExamenInforme, FuenteE, Brushes.Black, 30, 160)

        e.Graphics.DrawString("INFORME", FuenteTitulo, Brushes.Black, 400, 180)
        e.Graphics.DrawString("-------", FuenteTitulo, Brushes.Black, 400, 190)


        Dim AreaImpresion_Alto, AreaImpresion_Ancho, MargenIzquierdo, MargenSuperior As Integer
        Dim UltimaFila As Integer
        With pdInformeRX.DefaultPageSettings
            'Area Neta de Impresion (se descuenta los margenes)
            AreaImpresion_Alto = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            AreaImpresion_Ancho = .PaperSize.Width - .Margins.Left - .Margins.Right
            MargenIzquierdo = .Margins.Left
            MargenSuperior = .Margins.Top + 110

            'Verificar si se ha elegido el modo horizontal
            If .Landscape Then
                Dim NroTemp As Integer
                NroTemp = AreaImpresion_Alto
                AreaImpresion_Alto = AreaImpresion_Ancho
                AreaImpresion_Ancho = NroTemp
            End If
            Dim Formato As New StringFormat(StringFormatFlags.LineLimit)
            Dim Rectangulo As New RectangleF(MargenIzquierdo, MargenSuperior, _
            AreaImpresion_Ancho, AreaImpresion_Alto)
            Dim NroLineasImpresion As Integer = CInt(AreaImpresion_Alto / FuenteE.Height)
            Dim NroLineasRelleno, NroLetrasLinea As Integer
            Dim CaracterActual As Integer

            e.Graphics.MeasureString(Mid(InformeExamen, +1), FuenteE, _
            New SizeF(AreaImpresion_Ancho, AreaImpresion_Alto), Formato, NroLetrasLinea, _
            NroLineasRelleno)
            e.Graphics.DrawString(Mid(InformeExamen, CaracterActual + 1), FuenteE, _
            Brushes.Black, Rectangulo, Formato)
            CaracterActual += NroLetrasLinea
            If CaracterActual < InformeExamen.Length Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
                CaracterActual = 0
            End If
            UltimaFila = (NroLineasRelleno * 10) + 240
        End With
        Dim p As New PointF(300, UltimaFila)
        e.Graphics.DrawImage(pbImagen.Image, p)
    End Sub

    Private Sub pdcFarmacia_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcFarmacia.BeginPrint
        NroFilasTotales = 0
        PosicionFila = 0
        TotalFilasLV = lvMedR.Items.Count - 1
        NroFilasHoja = 0
        Pagina = 1
    End Sub

    Private Sub pdcFarmacia_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcFarmacia.PrintPage
        e.Graphics.DrawString("Hospital Regional Docente de Trujillo", FuenteE, Brushes.Black, 30, 20)
        e.Graphics.DrawString(StrDup(110, "_"), FuenteE, Brushes.Black, 30, 25)
        e.Graphics.DrawString("INFORME DE MEDICAMENTOS", FuenteTitulo, Brushes.Black, 140, 40)
        e.Graphics.DrawString("-----------------------------------------------------", FuenteE, Brushes.Black, 100, 60)

        e.Graphics.DrawString("Formato  :   " & lblHEI.Text & " " & cboLote.Text & "-" & txtNumero.Text, FuenteE, Brushes.Black, 30, 80)
        e.Graphics.DrawString("Paciente :   " & lblHistoria.Text & " - " & lblPaciente.Text, FuenteE, Brushes.Black, 30, 100)
        e.Graphics.DrawString("Fecha    :   " & Date.Now, FuenteE, Brushes.Black, 30, 120)


        e.Graphics.DrawString(StrDup(1, " ") & "CANT" & StrDup(10, " ") & "MEDICAMENTO" & StrDup(36, " ") & "IMPORTE", FuenteE, Brushes.Black, 30, 140)
        e.Graphics.DrawString(StrDup(80, "-"), FuenteE, Brushes.Black, 30, 150)
        Dim I As Integer
        Dim Y As Integer = 160

        Do While TotalFilasLV >= 0
            e.Graphics.DrawString(Microsoft.VisualBasic.Right(StrDup(5, " ") & lvMedR.Items(PosicionFila).SubItems(0).Text, 5) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvMedR.Items(PosicionFila).SubItems(1).Text & StrDup(46, " "), 46) & StrDup(2, " ") & Microsoft.VisualBasic.Right(StrDup(12, " ") & Microsoft.VisualBasic.Format(Val(lvMedR.Items(PosicionFila).SubItems(2).Text), "#0.00"), 12), FuenteE, Brushes.Black, 30, Y)
            Y = Y + 10
            'Total = Total + Val(lvMedR.Items(PosicionFila).SubItems(2).Text)

            PosicionFila += 1
            TotalFilasLV -= 1
            NroFilasTotales += 1
            NroFilasHoja += 1

            If NroFilasHoja >= 90 Then Exit Do

        Loop

        If TotalFilasLV >= 0 Then
            e.Graphics.DrawLine(Pens.Black, 20, Y, 800, Y)
            e.HasMorePages = True
            NroFilasHoja = 0
            Pagina += 1
        Else
            e.HasMorePages = False
            e.Graphics.DrawString(StrDup(38, " ") & "-------------------------------", FuenteE, Brushes.Black, 30, Y)
            Y = Y + 10
            e.Graphics.DrawString(StrDup(39, " ") & "T O T A L   S/. " & Microsoft.VisualBasic.Right(StrDup(12, " ") & lblTotalMed.Text, 12), FuenteE, Brushes.Black, 30, Y)
        End If
    End Sub

    Private Sub frmControlCuentaSIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Esta seguro de Imprimir Procedimientos", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            LlenarCon()
            ppdVistaPrevia.Document = pdCostos
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub pdCostos_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdCostos.BeginPrint
        Linea = 0
        NroPagina = 1
        NroFila = 0
        TotalFilas = lvSer.Items.Count - 1
    End Sub

    Private Sub pdCostos_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdCostos.PrintPage
        Dim I As Integer
        Dim Y As Integer = 80

        e.Graphics.DrawString("Hospital Regional Docente de Trujillo                                        Unidad de Seguros", FuenteE, Brushes.Black, 20, 30)
        Y = Y + 15
        e.Graphics.DrawString("REPORTE DE PROCEDIMIENTOS - SIS", FuenteCab, Brushes.Black, 20, 80)
        Y = Y + 1
        e.Graphics.DrawLine(Pens.Black, 20, Y, 450, Y)
        Y = Y + 15

        e.Graphics.DrawString("PACIENTE: " & lblHistoria.Text & " - " & lblPaciente.Text & " " & lblHEI.Text & " " & cboLote.Text & "-" & txtNumero.Text, FuenteCab, Brushes.Black, 20, Y)
        Y = Y + 20
        e.Graphics.DrawString("FORMATO : " & lblHEI.Text & " " & cboLote.Text & "-" & txtNumero.Text, FuenteCab, Brushes.Black, 20, Y)
        Y = Y + 20
        e.Graphics.DrawString("FECHA   : " & Date.Now, FuenteCab, Brushes.Black, 20, Y)
        
        Y = Y + 20
        e.Graphics.DrawString("Procedimiento" & StrDup(32, " ") & "Precio" & StrDup(12, " ") & "Cant" & StrDup(8, " ") & "Importe", FuenteE, Brushes.Black, 40, Y)
        Y = Y + 12
        e.Graphics.DrawLine(Pens.Black, 20, Y, 700, Y)
        Y = Y + 8
        Do While Linea <= TotalFilas
            Y = Y + 10
            e.Graphics.DrawString(Microsoft.VisualBasic.Left(lvSer.Items.Item(Linea).SubItems(1).Text & StrDup(40, " "), 40) & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvSer.Items.Item(Linea).SubItems(2).Text), "###,###.00"), 9) & StrDup(3, " ") & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & lvSer.Items.Item(Linea).SubItems(3).Text, 9) & StrDup(3, " ") & StrDup(3, " ") & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lvSer.Items.Item(Linea).SubItems(4).Text), "###,###.00"), 9), FuenteE, Brushes.Black, 40, Y)
            Linea += 1
            NroFila += 1
            If NroFila = 80 Then
                Exit Do
            End If
        Loop
        If NroFila < 80 Then
            Y = Y + 12
            e.Graphics.DrawLine(Pens.Black, 20, Y, 700, Y)
            Y = Y + 5
            e.Graphics.DrawString(StrDup(63, " ") & "TOTAL S/. " & Microsoft.VisualBasic.Right(StrDup(9, " ") & Microsoft.VisualBasic.Format(Val(lblTotalSer.Text), "###,###.00"), 9), FuenteE, Brushes.Black, 40, Y)
        End If
        If NroFila >= 80 Then
            e.HasMorePages = True
            NroFila = 0
        Else
            e.HasMorePages = False
        End If


    End Sub

    Private Sub cboLote_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtNumero.Select()
        End If


    End Sub
End Class