Imports System.Drawing.Printing
Imports System.IO

Public Class frmCuenta
    Dim objFicha As New FichaSoat
    Dim objTarifario As New TarifarioSOAT
    Dim objDetalle As New DetalleMed
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
    Dim Finalizar As Boolean

    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim FuenteTitulo As New Font("Lucida Console", 14)
    Dim Pincel As New SolidBrush(Color.Black)

    Dim NroFilasTotales As Integer
    Dim TotalFilasLV As Integer
    Dim NroFilasHoja As Integer
    Dim NroPagina As Integer


    Dim I As Integer

    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub HistorialMed()
        Dim Fila As ListViewItem
        lvMed.Items.Clear()
        lblTotalDig.Text = "0.00"
        Dim dsHis As New Data.DataSet
        dsHis = objDetalle.MedAten(CodLocal)
        For I = 0 To dsHis.Tables(0).Rows.Count - 1
            Fila = lvMed.Items.Add(dsHis.Tables(0).Rows(I)("IdDet"))
            Fila.SubItems.Add(dsHis.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsHis.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(Math.Round(dsHis.Tables(0).Rows(I)("Importe"), 2))
            lblTotalDig.Text = Math.Round(Val(lblTotalDig.Text) + Val(dsHis.Tables(0).Rows(I)("Importe")), 2)
        Next
    End Sub

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        lblTotal.Text = "0.00"
        Finalizar = False
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPre(txtHistoria.Text)
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
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("IdDet").ToString)
                    lblTotal.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(dsDetalle.Tables(0).Rows(I)("Importe")), "#0.00")
                Next

                'Consolidado
                lvCon.Items.Clear()
                dsDetalle = objFicha.Consolidado(CodLocal)
                For I = 0 To dsDetalle.Tables(0).Rows.Count - 1
                    Fila = lvCon.Items.Add(dsDetalle.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Cant"))
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("Precio"))
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

                HistorialMed()
                Dim Faltante As Double

                lblTotalG.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(lblMontoM.Text) + Val(lblTotalDig.Text), "#0.00")
                Faltante = Val(lblTotalCartas.Text) - Val(lblTotalG.Text)
                If Faltante >= 0 Then
                    lblFaltante.Text = Microsoft.VisualBasic.Format(0, "#0.00")
                Else
                    lblFaltante.Text = Microsoft.VisualBasic.Format(Faltante, "#0.00")
                End If

                If dsTabla.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Ficha ya fue finalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnFinalizar.Enabled = False : Finalizar = True Else btnFinalizar.Enabled = True
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
        btnFinalizar.Enabled = False
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If Finalizar Then Exit Sub
        If MessageBox.Show("Esta seguro de Eliminar el Procedimiento de la Cuenta del Paciente", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If e.KeyCode = Keys.Delete And lvDet.Items.Count > 0 Then
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
        NroFilasTotales = 0
        NroFilasHoja = 0
        TotalFilasLV = lvDet.Items.Count - 1
        I = -1
        NroPagina = 0
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            NroPagina += 1
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("S O A T", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            .DrawString(Date.Now.ToShortDateString, FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE SEGUROS", FuenteE, Pincel, 80, Y)
            .DrawString(Date.Now.ToShortTimeString, FuenteE, Pincel, 680, Y)

            Y = Y + 40

            .DrawString("L I Q U I D A C I O N  Nro: " & CodLocal & StrDup(20, " ") & "Nro Pag. " & NroPagina, Fuente, Pincel, 120, Y)
            Y = Y + 10
            .DrawString("-----------------------------------", Fuente, Pincel, 100, Y)

            Y = Y + 30
            .DrawString("Paciente   :", FuenteE, Pincel, 40, Y)
            .DrawString(lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Placa  :", FuenteE, Pincel, 450, Y)
            .DrawString(lblPlaca.Text, FuenteE, Pincel, 530, Y)

            Y = Y + 20
            .DrawString("Historia   :", FuenteE, Pincel, 40, Y)
            .DrawString(txtHistoria.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Poliza :", FuenteE, Pincel, 450, Y)
            .DrawString(lblPoliza.Text, FuenteE, Pincel, 530, Y)

            Y = Y + 20
            .DrawString("Cia Seguro :", FuenteE, Pincel, 40, Y)
            .DrawString(lblAseguradora.Text, FuenteE, Pincel, 140, Y)

            .DrawString("Carta  :", FuenteE, Pincel, 450, Y)
            .DrawString(lblCarta.Text, FuenteE, Pincel, 530, Y)

            Y = Y + 20
            .DrawString("Contratante:", FuenteE, Pincel, 40, Y)
            .DrawString(lblContratante.Text, FuenteE, Pincel, 140, Y)


            Y = Y + 20
            .DrawString("Diagnostico:", FuenteE, Pincel, 40, Y)
            If lblCIE.Text.Length <= 90 Then
                .DrawString(lblCIE.Text, FuenteE, Pincel, 140, Y)
            Else
                .DrawString(Microsoft.VisualBasic.Left(lblCIE.Text, 90), FuenteE, Pincel, 140, Y)
                Y = Y + 10
                .DrawString(Microsoft.VisualBasic.Right(lblCIE.Text, lblCIE.Text.Length - 90), FuenteE, Pincel, 140, Y)
            End If

        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10

        Y = Y + 40

        If TipoImpresion Then
            With e.Graphics
                .DrawString("Codigo", FuenteE, Pincel, 40, Y)
                .DrawString("Descripcion", FuenteE, Pincel, 120, Y)
                .DrawString("Precio", FuenteE, Pincel, 600, Y)
                .DrawString("Cant", FuenteE, Pincel, 660, Y)
                .DrawString("Importe", FuenteE, Pincel, 720, Y)
                Y = Y + 10
                .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                Y = Y + 10

                Do While NroFilasTotales <= TotalFilasLV
                    I += 1
                    If TotalFilasLV < I Then Exit Do
                    .DrawString(lvDet.Items(I).SubItems(0).Text, FuenteE, Pincel, 40, Y)
                    'Cadena Detalle
                    Dim CadDet As String
                    If lvDet.Items(I).SubItems(6).Text <> "  /  /" And lvDet.Items(I).SubItems(6).Text <> "" Then
                        CadDet = (lvDet.Items(I).SubItems(1).Text & " " & lvDet.Items(I).SubItems(6).Text).Trim
                    Else
                        CadDet = (lvDet.Items(I).SubItems(1).Text).Trim
                    End If

                    If lvDet.Items(I).SubItems(7).Text <> "  /  /" And lvDet.Items(I).SubItems(7).Text <> "" Then
                        CadDet = (CadDet & " " & lvDet.Items(I).SubItems(7).Text).Trim
                    End If

                    If CadDet.Length > 60 Then
                        .DrawString(CadDet.Remove(60, CadDet.Length - 60), FuenteE, Pincel, 120, Y)
                    Else
                        .DrawString(CadDet, FuenteE, Pincel, 120, Y)
                    End If
                    .DrawString((StrDup(8 - lvDet.Items(I).SubItems(2).Text.Remove(lvDet.Items(I).SubItems(2).Text.Length - 2, 2).Length, " ") & lvDet.Items(I).SubItems(2).Text.Remove(lvDet.Items(I).SubItems(2).Text.Length - 2, 2)), FuenteE, Pincel, 580, Y)
                    If lvDet.Items(I).SubItems(3).Text.Length > 4 Then
                        .DrawString((StrDup(lvDet.Items(I).SubItems(3).Text.Length - 4, " ") & lvDet.Items(I).SubItems(3).Text), FuenteE, Pincel, 660, Y)
                    Else
                        .DrawString(StrDup(4 - lvDet.Items(I).SubItems(3).Text.Length, " ") & lvDet.Items(I).SubItems(3).Text, FuenteE, Pincel, 660, Y)
                    End If
                    .DrawString((StrDup(10 - lvDet.Items(I).SubItems(4).Text.Remove(lvDet.Items(I).SubItems(4).Text.Length - 2, 2).Length, " ") & lvDet.Items(I).SubItems(4).Text.Remove(lvDet.Items(I).SubItems(4).Text.Length - 2, 2)), FuenteE, Pincel, 700, Y)
                    Y = Y + 15


                    NroFilasHoja += 1
                    NroFilasTotales += 1
                    If NroFilasHoja >= 50 Then
                        Exit Do
                    End If

                Loop

                If NroFilasTotales >= TotalFilasLV Then
                    .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                    Y = Y + 10
                    .DrawString("TOTAL PROCEDIMIENTOS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotal.Text, 14)), FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("TOTAL MEDICAMENTOS   S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblMontoM.Text, 14)), FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("TOTAL GENERAL        S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotalG.Text, 14)), FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("TOTAL ABONADO CARTAS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotalCartas.Text, 14)), FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("PENDIENTE ABONAR     S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblFaltante.Text, 14)), FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString(StrDup(112, "="), FuenteE, Pincel, 20, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("Nota: La demora en la adquisición de material de osteosíntesis y/u ortopédico", FuenteE, Pincel, 75, Y)
                    Y = Y + 10
                    NroFilasHoja += 1
                    .DrawString("depende directamente de la ASEGURADORA", FuenteE, Pincel, 75, Y)

                    e.HasMorePages = False
             
                Else
                    e.HasMorePages = True
                    NroFilasHoja = 0
                End If
            End With
        Else
            With e.Graphics
                .DrawString("Descripcion", FuenteE, Pincel, 40, Y)
                .DrawString("Cant", FuenteE, Pincel, 500, Y)
                .DrawString("Precio", FuenteE, Pincel, 560, Y)
                .DrawString("Importe", FuenteE, Pincel, 640, Y)
                Y = Y + 10
                .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                Y = Y + 10
                For I = 0 To lvCon.Items.Count - 1
                    'Cadena Detalle
                    Dim CadDet As String

                    CadDet = (lvCon.Items(I).SubItems(0).Text).Trim

                    .DrawString(Microsoft.VisualBasic.Left(lvCon.Items(I).SubItems(0).Text & StrDup(60, " "), 60) & StrDup(8, " ") & Microsoft.VisualBasic.Right(StrDup(4, " ") & lvCon.Items(I).SubItems(1).Text, 4) & StrDup(2, " ") & Microsoft.VisualBasic.Right(StrDup(8, " ") & Microsoft.VisualBasic.Format(Val(lvCon.Items(I).SubItems(2).Text), "#0.00"), 8) & StrDup(6, " ") & Microsoft.VisualBasic.Right(StrDup(8, " ") & Microsoft.VisualBasic.Format(Val(lvCon.Items(I).SubItems(3).Text), "#0.00"), 8), FuenteE, Pincel, 40, Y)

                    'If CadDet.Length > 60 Then
                    '    .DrawString(CadDet.Remove(60, CadDet.Length - 60), FuenteE, Pincel, 40, Y)
                    'Else
                    '    .DrawString(CadDet, FuenteE, Pincel, 40, Y)
                    'End If
                    'If lvCon.Items(I).SubItems(1).Text.Length > 4 Then
                    '    .DrawString((StrDup(lvCon.Items(I).SubItems(1).Text.Length - lvCon.Items(I).SubItems(1).Text.Length, " ") & lvCon.Items(I).SubItems(1).Text), FuenteE, Pincel, 480, Y)
                    'Else
                    '    .DrawString(StrDup(4 - lvCon.Items(I).SubItems(1).Text.Length, " ") & lvCon.Items(I).SubItems(1).Text, FuenteE, Pincel, 480, Y)
                    'End If
                    '.DrawString((StrDup(10 - lvCon.Items(I).SubItems(2).Text.Remove(lvCon.Items(I).SubItems(2).Text.Length - 2, 2).Length, " ") & lvCon.Items(I).SubItems(2).Text.Remove(lvCon.Items(I).SubItems(2).Text.Length - 2, 2)), FuenteE, Pincel, 550, Y)
                    Y = Y + 15
                Next
                .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                Y = Y + 10
                .DrawString("TOTAL PROCEDIMIENTOS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotal.Text, 14)), FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString(StrDup(112, "-"), FuenteE, Pincel, 20, Y)
                Y = Y + 10
                .DrawString("TOTAL MEDICAMENTOS   S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblMontoM.Text, 14)), FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString("TOTAL GENERAL        S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotalG.Text, 14)), FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString("TOTAL ABONADO CARTAS S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblTotalCartas.Text, 14)), FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString("PENDIENTE ABONAR     S/. " & (Microsoft.VisualBasic.Right(StrDup(14, " ") & lblFaltante.Text, 14)), FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString(StrDup(112, "="), FuenteE, Pincel, 20, Y)
                Y = Y + 10
                .DrawString("Nota: La demora en la adquisición de material de osteosíntesis y/u ortopédico", FuenteE, Pincel, 75, Y)
                Y = Y + 10
                .DrawString("depende directamente de la ASEGURADORA", FuenteE, Pincel, 75, Y)
            End With
        End If
    End Sub

    Private Sub lblMontoM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMontoM.TextChanged
        If lblMontoM.Text <> "" Then
            lblTotalG.Text = Microsoft.VisualBasic.Format(Val(lblTotal.Text) + Val(lblMontoM.Text), "#0.00")
            lblFaltante.Text = Microsoft.VisualBasic.Format(Val(lblTotalG.Text) - Val(lblTotalCartas.Text), "#0.00")
        End If
    End Sub

    Private Sub frmCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbConsolidado.Visible = False
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
        'MontoProcedimiento
        objFicha.MontoPro(CodLocal, lblTotalG.Text)


        TipoImpresion = False
        ppdVistaPrevia.Document = pdcDocumento
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnRayos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRayos.Click
        Dim dsTabla As New Data.DataSet
        For I = 0 To lvDet.Items.Count - 1
            If lvDet.Items.Item(I).Selected Then
                dsTabla = objFicha.BuscarInformeRX(lvDet.Items.Item(I).SubItems(8).Text)
                If dsTabla.Tables(0).Rows.Count > 0 Then
                    FechaAtencion = dsTabla.Tables(0).Rows(0)("FechaAtencion")
                    Radiologo = dsTabla.Tables(0).Rows(0)("Personal")
                    InformeExamen = dsTabla.Tables(0).Rows(0)("Informe")


                    Dim bytBLOBData() As Byte = dsTabla.Tables(0).Rows(0)("Firma")
                    Dim stmBLOBData As New System.IO.MemoryStream(bytBLOBData)

                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage
                    pbImagen.Image = Image.FromStream(stmBLOBData)

                    ExamenInforme = lvDet.Items.Item(I).SubItems(1).Text
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
        e.Graphics.DrawString("Hospital Regional Docente de Trujillo - SOAT", FuenteE, Brushes.Black, 30, 20)
        e.Graphics.DrawString(StrDup(110, "_"), FuenteE, Brushes.Black, 30, 25)
        e.Graphics.DrawString("INFORME DE AYUDA AL DIAGNOSTICO POR IMAGENES", FuenteTitulo, Brushes.Black, 100, 40)
        e.Graphics.DrawString("------------------------------------------------------------------------------", FuenteE, Brushes.Black, 100, 60)

        e.Graphics.DrawString("Paciente     :   " & txtHistoria.Text & " - " & lblAPaterno.Text & " " & lblAMaterno.Text & " " & lblNombres.Text, FuenteE, Brushes.Black, 30, 80)
        e.Graphics.DrawString("Fecha        :   " & FechaAtencion, FuenteE, Brushes.Black, 30, 100)
        e.Graphics.DrawString("Placa        :   " & lblPlaca.Text & " " & "Poliza   :   " & lblPoliza.Text, FuenteE, Brushes.Black, 30, 120)
        e.Graphics.DrawString("Contratante  :   " & lblContratante.Text, FuenteE, Brushes.Black, 30, 140)
        e.Graphics.DrawString("Aseguradora  :   " & lblAseguradora.Text, FuenteE, Brushes.Black, 30, 160)
        e.Graphics.DrawString("Radiologo    :   " & Radiologo, FuenteE, Brushes.Black, 30, 180)
        e.Graphics.DrawString("Examen       :   " & ExamenInforme, FuenteE, Brushes.Black, 30, 200)

        e.Graphics.DrawString("INFORME", FuenteTitulo, Brushes.Black, 400, 220)
        e.Graphics.DrawString("-------", FuenteTitulo, Brushes.Black, 400, 230)


        Dim AreaImpresion_Alto, AreaImpresion_Ancho, MargenIzquierdo, MargenSuperior As Integer
        Dim UltimaFila As Integer
        With pdInformeRX.DefaultPageSettings
            'Area Neta de Impresion (se descuenta los margenes)
            AreaImpresion_Alto = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            AreaImpresion_Ancho = .PaperSize.Width - .Margins.Left - .Margins.Right
            MargenIzquierdo = .Margins.Left
            MargenSuperior = .Margins.Top + 150

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
            UltimaFila = (NroLineasRelleno * 10) + 280
        End With
        Dim p As New PointF(300, UltimaFila)
        e.Graphics.DrawImage(pbImagen.Image, p)
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

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

    Private Sub txtPre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPre.KeyPress
        lblTotal.Text = "0.00"
        Finalizar = False
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtPre.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objFicha.BuscarDatosPreNP(txtPre.Text)
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
                    Fila.SubItems.Add(dsDetalle.Tables(0).Rows(I)("IdDet").ToString)
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

                If dsTabla.Tables(0).Rows(0)("FechaFinalizado").ToString <> "" Then MessageBox.Show("Ficha ya fue finalizada", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnFinalizar.Enabled = False : Finalizar = True Else btnFinalizar.Enabled = True
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
                txtPre.Select()
                btnImprimir.Enabled = False
            End If
        End If
    End Sub

    'Private Sub Exportar()
    '    Dim report As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport()
    '    If cn.State = ConnectionState.Closed Then
    '        cn.Open()
    '    End If

    '    rvPDF.LocalReport.DataSources.Clear()
    '    rvPDF.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource(nombreReporte, dt))
    '    Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
    '    Dim streamids() As String = Nothing
    '    Dim mimeType As String = Nothing
    '    Dim encoding As String = Nothing
    '    Dim extension As String = Nothing
    '    Dim bytes() As Byte = rvPDF.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
    '    Dim s As New MemoryStream
    '    s = New MemoryStream(bytes)
    '    Dim saveTo As String = "C:/PreLiqSOAT" & CodLocal & ".pdf"
    '    If File.Exists(saveTo) Then
    '        File.Delete(saveTo)
    '    End If
    '    Dim fs As FileStream
    '    fs = New FileStream(saveTo, FileMode.CreateNew, FileAccess.Write)
    '    fs.Write(bytes, 0, bytes.Length)
    '    fs.Close()
    'End Sub



    Private Sub txtPre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPre.TextChanged

    End Sub
End Class