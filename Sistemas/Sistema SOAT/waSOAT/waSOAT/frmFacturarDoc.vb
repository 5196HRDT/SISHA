Public Class frmFacturarDoc
    Dim objFicha As New FichaSoat
    Dim objTarifario As New TarifarioSOAT
    Dim objFacturacion As New FacturacionEconomia
    Dim CodLocal As String
    Dim objCartas As New Cartas
    Dim NumeroFila As String
    Dim ColeccionCIE As String
    Dim TipoImpresion As Boolean
    Dim FechaAtencion As String
    Dim Radiologo As String
    Dim InformeExamen As String
    Dim ExamenInforme As String
    Dim Preliquidacion As String
    Dim RucCS As String
    Dim DirCS As String

    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8, FontStyle.Bold)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim Pincel As New SolidBrush(Color.Black)


    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        lblTotal.Text = "0.00"
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosFac(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
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
                RucCS = dsTabla.Tables(0).Rows(0)("Ruc")
                DirCS = dsTabla.Tables(0).Rows(0)("Direccion")
                txtDireccion.Text = DirCS

                If dsTabla.Tables(0).Rows(0)("Ruc").ToString.Length <> 11 Then MessageBox.Show("Formato de Ruc no es el Correcto", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                'lblCIEX.Text = dsTabla.Tables(0).Rows(0)("CIE1") & " " & dsTabla.Tables(0).Rows(0)("DesCIE1")
                ColeccionCIE = dsTabla.Tables(0).Rows(0)("CIE1")
                If dsTabla.Tables(0).Rows(0)("CIE2") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE2") & " " & dsTabla.Tables(0).Rows(0)("DesCIE2") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE2")
                If dsTabla.Tables(0).Rows(0)("CIE3") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE3") & " " & dsTabla.Tables(0).Rows(0)("DesCIE3") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE3")
                If dsTabla.Tables(0).Rows(0)("CIE4") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE4") & " " & dsTabla.Tables(0).Rows(0)("DesCIE4") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE4")
                'lblCIEX.Text = dsTabla.Tables(0).Rows(0)("Diagnostico")
                lblCIE.Text = dsTabla.Tables(0).Rows(0)("Diagnostico")
                lblCarta.Text = dsTabla.Tables(0).Rows(0)("Carta")
                lblMontoM.Text = Microsoft.VisualBasic.Format(dsTabla.Tables(0).Rows(0)("MontoFarmacia"), "#0.00")
                lblTotal.Text = "0.00"
                lblTotalCartas.Text = Microsoft.VisualBasic.Format(dsTabla.Tables(0).Rows(0)("MontoCarta"), "#0.00")
                btnImprimir.Enabled = True
                Dim I As Integer
                Dim Fila As New ListViewItem
                Dim dsDetalle As New Data.DataSet
                Dim varDes As String
                Dim varFecha As String
                Dim varFecha1 As String
                dsDetalle = objFicha.BuscarDetalle(CodLocal)
                lvDet.Items.Clear()
                For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsDetalle.Tables(0).Rows(I)("Codigo"))
                    varDes = dsDetalle.Tables(0).Rows(I)("Descripcion")
                    varFecha = dsDetalle.Tables(0).Rows(I)("Fecha").ToString
                    varFecha1 = dsDetalle.Tables(0).Rows(I)("Fecha1").ToString
                    If varFecha.Length = 10 And varFecha1.Length <> 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(53, " "), 53) & " " & varFecha
                    ElseIf varFecha.Length = 10 And varFecha1.Length = 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(39, " "), 39) & " " & varFecha & " al " & varFecha1
                    ElseIf varFecha.Length <> 10 And varFecha1.Length <> 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(64, " "), 64)
                    End If

                    Fila.SubItems.Add(varDes)
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("IdDet"))
                    varFecha = dsDetalle.Tables(0).Rows(I)("Fecha").ToString
                    If varFecha.Length <> 10 Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha").ToString)
                    varFecha = dsDetalle.Tables(0).Rows(I)("Fecha1").ToString
                    If varFecha.Length <> 10 Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha1").ToString)
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("IdDet").ToString)
                    lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Math.Round(Val(dsDetalle.Tables(0).Rows(I)("Importe")), 2), "#0.00")
                Next

                'Consolidado
                Dim PUni As String = 0
                lblPro.Text = "0.00"
                lvCon.Items.Clear()
                dsDetalle = objFicha.Consolidado(CodLocal)
                For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                    Fila = lvCon.Items.Add(Microsoft.VisualBasic.Right("000" & dsDetalle.Tables(0).Rows(I)("Cant").ToString, 3))
                    varDes = dsDetalle.Tables(0).Rows(I)("Descripcion")
                    varFecha = dsDetalle.Tables(0).Rows(I)("Fecha").ToString
                    varFecha1 = dsDetalle.Tables(0).Rows(I)("Fecha1").ToString
                    If varFecha.Length = 10 And varFecha1.Length <> 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(53, " "), 53) & " " & varFecha
                    ElseIf varFecha.Length = 10 And varFecha1.Length = 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(39, " "), 39) & " " & varFecha & " al " & varFecha1
                    ElseIf varFecha.Length <> 10 And varFecha1.Length <> 10 Then
                        varDes = Microsoft.VisualBasic.Left(varDes & StrDup(64, " "), 64)
                    End If
                    Fila.SubItems.Add(varDes)
                    PUni = Microsoft.VisualBasic.Format(Math.Round(Val(dsDetalle.Tables(0).Rows(I)("Imp")) / Val(dsDetalle.Tables(0).Rows(I)("Cant")), 2), "#0.00")
                    Fila.SubItems.Add(PUni)
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsDetalle.Tables(0).Rows(I)("Imp")), "#0.00"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha1"))
                    lblPro.Text = Val(lblPro.Text) + Math.Round(Val(dsDetalle.Tables(0).Rows(I)("Imp")), 2)

                Next

                'Lista de Carta
                Dim J As Integer
                Dim dsCartas As New Data.DataSet
                dsCartas = objCartas.Buscar(CodLocal)
                For J = 0 To dsCartas.Tables(0).Rows.Count - 1
                    If J = 0 Then
                        lblCarta.Text = dsCartas.Tables(0).Rows(J)("NroCarta")
                    Else
                        lblCarta.Text = lblCarta.Text & "," & dsCartas.Tables(0).Rows(J)("NroCarta")
                    End If
                Next
                lblTotalG.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(lblMontoM.Text), "#0.00")
                lblFaltante.Text = Microsoft.VisualBasic.Format((Val(lblTotalG.Text)) - Val(lblTotalCartas.Text), "#0.00")
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
                lblCIEX.Text = ""
                txtHistoria.Text = ""
                lblCarta.Text = ""
                txtHistoria.Select()
                lblMontoM.Text = ""
                lblPro.Text = ""
                lblTotalG.Text = ""
                lblTotalCartas.Text = ""
                lblFaltante.Text = ""


            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
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
        lblCIEX.Text = ""
        lvDet.Items.Clear()
        lblTotal.Text = "0.00"
        txtHistoria.Text = ""
        lblCarta.Text = ""
        btnImprimir.Enabled = False
        txtHistoria.Select()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If MessageBox.Show("Esta seguro de Eliminar el Procedimiento de la Cuenta del Paciente", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If e.KeyCode = Keys.Delete And lvDet.Items.Count > 0 Then
                Dim I As Integer
                For I = 0 To lvDet.Items.Count - 1
                    If lvDet.Items.Item(I).Selected Then
                        lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) - Val(lvDet.Items.Item(I).SubItems(4).Text), "#0.00")
                        objFicha.EliminarDetalle(lvDet.Items(I).SubItems(5).Text)
                        lvDet.Items.RemoveAt(I)
                        Exit For
                    End If
                Next
                If lvDet.Items.Count = 0 Then btnImprimir.Enabled = False
            End If
        End If
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'MontoProcedimiento
        objFicha.MontoPro(CodLocal, lblTotalG.Text)


        Dim ConfiguracionImpresora As String
        If pdImpresion.ShowDialog = Windows.Forms.DialogResult.OK Then
            ConfiguracionImpresora = pdImpresion.PrinterSettings.ToString
        End If
        TipoImpresion = True
        ppdVistaPrevia.Document = pdcDocumento
        ppdVistaPrevia.ShowDialog()

      
    End Sub


    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NumeroFila = 0
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics

            Y = Y + 24
            .DrawString(StrDup(70, " ") & Microsoft.VisualBasic.Left(cboTipo.Text, 1) & " " & txtSerie.Text & "-" & Microsoft.VisualBasic.Right("0000000" & txtNumero.Text, 7), FuenteE, Pincel, 100, Y + 20)

            Y = Y + 24
            .DrawString(lblAseguradora.Text, FuenteE, Pincel, 100, Y)

            Y = Y + 24
            .DrawString(txtDireccion.Text, FuenteE, Pincel, 100, Y)

            Y = Y + 24
            .DrawString(RucCS & StrDup(60, " ") & Microsoft.VisualBasic.Right("00" & dtpFDoc.Value.Day, 2) & StrDup(6, " ") & Microsoft.VisualBasic.Right("00" & dtpFDoc.Value.Month, 2) & StrDup(8, " ") & dtpFDoc.Value.Year, FuenteE, Pincel, 100, Y)
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
            Dim I As Integer
            If TipoImpresion Then
                For I = 0 To lvCon.Items.Count - 1
                    .DrawString(lvCon.Items(I).SubItems(0).Text & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvCon.Items(I).SubItems(1).Text & StrDup(64, " "), 64) & StrDup(1, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvCon.Items(I).SubItems(2).Text), "#0.00"), 10) & StrDup(6, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lvCon.Items(I).SubItems(3).Text), "#0.00"), 10), FuenteE, Pincel, 64, Y)
                    Y = Y + 15
                Next
            Else
                .DrawString("01" & StrDup(2, " ") & Microsoft.VisualBasic.Left("ATENCION EN MEDICAMENTOS E INSUMOS" & StrDup(64, " "), 64) & StrDup(1, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"), 10) & StrDup(6, " ") & Microsoft.VisualBasic.Right(StrDup(10, " ") & Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"), 10), FuenteE, Pincel, 64, Y)
                Y = Y + 15
            End If
            
            .DrawString(StrDup(96, "="), FuenteE, Pincel, 90, Y)
            Y = Y + 15
            .DrawString("Paciente   :" & lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, FuenteE, Pincel, 90, Y)
            Y = Y + 10
            .DrawString("Placa      :" & lblPlaca.Text & StrDup(4, " ") & "Poliza: " & lblPoliza.Text, FuenteE, Pincel, 90, Y)
            Y = Y + 10
            .DrawString("Pre Liq    :" & txtHistoria.Text, FuenteE, Pincel, 90, Y)


            If TipoImpresion Then
                .DrawString(ValorEnLetras(Val(lblPro.Text), "Nuevos Soles"), FuenteE, Pincel, 60, 1025)
                .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblPro.Text), "#0.00"), 14)), FuenteE, Pincel, 630, 1020)
                .DrawString("0.00" & StrDup(8, " ") & "Exonerado", FuenteE, Pincel, 610, 1050)
                .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblPro.Text), "#0.00"), 14)), FuenteE, Pincel, 630, 1080)
            Else
                Dim SubTotal As String
                Dim IGV As String
                SubTotal = Math.Round(Val(lblMontoM.Text) / (1.18), 2)
                IGV = Val(lblMontoM.Text) - Val(SubTotal)
                .DrawString(ValorEnLetras(Val(lblMontoM.Text), "Nuevos Soles"), FuenteE, Pincel, 60, 1020)
                .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(SubTotal), "#0.00"), 14)), FuenteE, Pincel, 630, 1020)
                .DrawString("18" & StrDup(12, " ") & Microsoft.VisualBasic.Format(Val(IGV), "#0.00"), FuenteE, Pincel, 616, 1050)
                .DrawString("S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"), 14)), FuenteE, Pincel, 630, 1080)
            End If

        End With
    End Sub

    Private Sub lblMontoM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMontoM.TextChanged
        If lblMontoM.Text <> "" Then
            lblTotalG.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(lblMontoM.Text), "#0.00")
            lblFaltante.Text = Microsoft.VisualBasic.Format(Val(lblTotalG.Text) - Val(lblTotalCartas.Text), "#0.00")
        End If
    End Sub

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If MessageBox.Show("Esta seguro de Finalizar Atencion de Paciente SOAT", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objFicha.Finalizar(CodLocal)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbConsolidado.Visible = False
        chkConsolidado.Checked = False
    End Sub

    Private Sub chkConsolidado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolidado.CheckedChanged
        If chkConsolidado.Checked Then gbConsolidado.Visible = True Else gbConsolidado.Visible = False
    End Sub

    Private Sub btnGenerarReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarReporte.Click
        Dim CodFactura As String
        Dim I As Integer
        If txtNumero.Text.Length = 0 Then MessageBox.Show("Debe Ingresar Numero de Comprobante de Venta", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If Val(lblPro.Text) > 0 Then
            If MessageBox.Show("Esta seguro de Facturar Servicios de Preliquidacion", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                'MontoProcedimiento
                objFicha.MontoPro(CodLocal, lblTotalG.Text)

                objFicha.FacturarDocumento(CodLocal, dtpFDoc.Value.ToString, cboTipo.Text, txtSerie.Text, txtNumero.Text)


                CodFactura = objFacturacion.Grabar(cboTipo.Text, txtSerie.Text, txtNumero.Text, Microsoft.VisualBasic.Format(dtpFDoc.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, RucCS, lblAseguradora.Text, DirCS, txtHistoria.Text, lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, lblPlaca.Text, lblPoliza.Text, Microsoft.VisualBasic.Format(Val(lblPro.Text), "#0.00"), 0, Microsoft.VisualBasic.Format(Val(lblPro.Text), "#0.00"), "1", "SOAT")
                For I = 0 To lvDet.Items.Count - 1
                    objFacturacion.DetalleGrabar(CodFactura, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(4).Text)
                Next

                TipoImpresion = True
                ppdVistaPrevia.Document = pdcDocumento
                ppdVistaPrevia.ShowDialog()
            End If
        End If

        If Val(lblMontoM.Text) > 0 Then
            If MessageBox.Show("Esta seguro de Facturar Medicina de Preliquidacion", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                txtSerie.Text = Microsoft.VisualBasic.InputBox("Confirmar Serie Documento", "Datos de Facturacion", "030")
                txtNumero.Text = Microsoft.VisualBasic.InputBox("Confirmar Numero Documento", "Datos de Facturacion", Val(txtNumero.Text) + 1)
                objFicha.FacturarDocumentoF(CodLocal, dtpFDoc.Value.ToString, cboTipo.Text, txtSerie.Text, txtNumero.Text)

                Dim SubTotal As String
                Dim IGV As String
                SubTotal = Math.Round(Val(lblMontoM.Text) / (1.18), 2)
                IGV = Val(lblMontoM.Text) - Val(SubTotal)
                CodFactura = objFacturacion.Grabar(cboTipo.Text, txtSerie.Text, txtNumero.Text, Microsoft.VisualBasic.Format(dtpFDoc.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, RucCS, lblAseguradora.Text, DirCS, txtHistoria.Text, lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, lblPlaca.Text, lblPoliza.Text, Microsoft.VisualBasic.Format(Val(SubTotal), "#0.00"), Microsoft.VisualBasic.Format(Val(IGV), "#0.00"), Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"), "0", "SOAT")

                objFacturacion.DetalleGrabar(CodFactura, "01", "ATENCION EN MEDICAMENTOS E INSUMOS", Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"), Microsoft.VisualBasic.Format(Val(lblMontoM.Text), "#0.00"))

                TipoImpresion = False
                ppdVistaPrevia.Document = pdcDocumento
                ppdVistaPrevia.ShowDialog()

                txtNumero.Text = Val(txtNumero.Text) + 1
            End If
        End If
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
        lblCIEX.Text = ""
        txtHistoria.Text = ""
        lblCarta.Text = ""
        txtHistoria.Select()
        lblMontoM.Text = ""
        lblPro.Text = ""
        lblTotalG.Text = ""
        lblTotalCartas.Text = ""
        lblFaltante.Text = ""
    End Sub

    Private Sub btnPreliquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreliquidacion.Click
        Preliquidacion = InputBox("Ingresar Nro de Preliquidaciòn", "Datos de Preliquidaciòn")
        If Not IsNumeric(Preliquidacion) Then MessageBox.Show("Debe ingresar un valor numèrico", "Mensaje de Informaciòn", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        lblTotal.Text = "0.00"

        Dim dsTabla As New Data.DataSet
        dsTabla = objFicha.BuscarNroPre(Preliquidacion)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            CodLocal = dsTabla.Tables(0).Rows(0)("IdSoat")
            txtHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
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
            'lblCIEX.Text = dsTabla.Tables(0).Rows(0)("CIE1") & " " & dsTabla.Tables(0).Rows(0)("DesCIE1")
            ColeccionCIE = dsTabla.Tables(0).Rows(0)("CIE1")
            If dsTabla.Tables(0).Rows(0)("CIE2") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE2") & " " & dsTabla.Tables(0).Rows(0)("DesCIE2") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE2")
            If dsTabla.Tables(0).Rows(0)("CIE3") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE3") & " " & dsTabla.Tables(0).Rows(0)("DesCIE3") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE3")
            If dsTabla.Tables(0).Rows(0)("CIE4") <> "" Then lblCIEX.Text = lblCIEX.Text & Convert.ToChar(Keys.Enter) & dsTabla.Tables(0).Rows(0)("CIE4") & " " & dsTabla.Tables(0).Rows(0)("DesCIE4") : ColeccionCIE = ColeccionCIE & ", " & dsTabla.Tables(0).Rows(0)("CIE4")
            'lblCIEX.Text = dsTabla.Tables(0).Rows(0)("Diagnostico")
            lblCIE.Text = dsTabla.Tables(0).Rows(0)("Diagnostico")
            lblCarta.Text = dsTabla.Tables(0).Rows(0)("Carta")
            lblMontoM.Text = Microsoft.VisualBasic.Format(dsTabla.Tables(0).Rows(0)("MontoFarmacia"), "#0.00")
            lblTotal.Text = "0.00"
            lblTotalCartas.Text = Microsoft.VisualBasic.Format(dsTabla.Tables(0).Rows(0)("MontoCarta"), "#0.00")
            btnImprimir.Enabled = True
            Dim I As Integer
            Dim Fila As New ListViewItem
            Dim dsDetalle As New Data.DataSet
            dsDetalle = objFicha.BuscarDetalle(CodLocal)
            lvDet.Items.Clear()
            For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsDetalle.Tables(0).Rows(I)("Codigo"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cantidad"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Importe"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("IdDet"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha").ToString)
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Fecha1").ToString)
                lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe")), "#0.00")
            Next

            'Consolidado
            dsDetalle = objFicha.Consolidado(CodLocal)
            For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                Fila = lvCon.Items.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cant"))
                Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Imp"))
            Next

            'Lista de Carta
            Dim J As Integer
            Dim dsCartas As New Data.DataSet
            dsCartas = objCartas.Buscar(CodLocal)
            For J = 0 To dsCartas.Tables(0).Rows.Count - 1
                If J = 0 Then
                    lblCarta.Text = dsCartas.Tables(0).Rows(J)("NroCarta")
                Else
                    lblCarta.Text = lblCarta.Text & "," & dsCartas.Tables(0).Rows(J)("NroCarta")
                End If
            Next


            lblTotalG.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(lblMontoM.Text), "#0.00")
            lblFaltante.Text = Microsoft.VisualBasic.Format((Val(lblTotalG.Text)) - Val(lblTotalCartas.Text), "#0.00")
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
            lblCIEX.Text = ""
            txtHistoria.Text = ""
            lblCarta.Text = ""
            txtHistoria.Select()
            btnImprimir.Enabled = False
        End If
    End Sub

    Private Sub frmFacturarDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSerie.Text = "001"
        txtNumero.Text = ""
        cboTipo.Text = "FACTURA"
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter And txtNumero.Text <> "" Then btnGenerarReporte.Select()
    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        If txtNumero.Text.Length = 0 Then Exit Sub
        Dim dsVer As New Data.DataSet
        dsVer = objFacturacion.Verificar(cboTipo.Text, txtSerie.Text, txtNumero.Text)
        If dsVer.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Comprobante de Venta ya fue registrado, Verifique Numeracion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumero.Select()
        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter And txtSerie.Text <> "" Then txtNumero.Select()
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtSerie.Select()
    End Sub

    Private Sub cboTipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.LostFocus

    End Sub
End Class