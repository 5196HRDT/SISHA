Public Class frmRepPacCoSe
    Dim objProduccion As New Laboratorio
    Dim TipoReporte As String
    'Variables Impresion
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteE As New Font("Lucida Console", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim X, Y As Integer

    Private Sub frmRepPacCoSe_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim dsVer As New Data.DataSet
        lblCantE.Text = "0.00"

        Dim I As Integer
        Dim Fila As ListViewItem

        'EMERGENCIA
        dsVer = objProduccion.ProdSerComun(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA")
        lvE.Items.Clear()

        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvE.Items.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Total")), "#0.00"))
            lblCantE.Text = Val(lblCantE.Text) + Val(dsVer.Tables(0).Rows(I)("Total"))
        Next

        'HOSPITALIZACION
        dsVer = objProduccion.ProdSerComun(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION")
        lvH.Items.Clear()
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvH.Items.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Total"))
            lblCantH.Text = Val(lblCantH.Text) + Val(dsVer.Tables(0).Rows(I)("Total"))
        Next

        'CONSULTA EXTERNA
        dsVer = objProduccion.ProdSerComun(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA")
        lvC.Items.Clear()
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvC.Items.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsVer.Tables(0).Rows(I)("Total")), "#0.00"))
            lblCantC.Text = Val(lblCantC.Text) + Val(dsVer.Tables(0).Rows(I)("Total"))
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("H R D T", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            Y = Y + 10
            .DrawString("SERVICIO DE LABORATORIO", FuenteE, Pincel, 80, Y)

            Y = Y + 40
            Select Case TipoReporte
                Case "EMERGENCIA"
                    .DrawString("REPORTE DE PRODUCCION EN EMERGENCIA ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 20, Y)
                Case "HOSPITALIZACION"
                    .DrawString("REPORTE DE PRODUCCION EN HOSPITALIZ ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 20, Y)
                Case "CONSULTA"
                    .DrawString("REPORTE DE PRODUCCION EN CONS. EXT. ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 20, Y)
            End Select
            Y = Y + 10
            .DrawString("------------------------------------------------------------------------------------", Fuente, Pincel, 10, Y)
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroPaginas = 1
        NroFilasTotales = 0
        Select Case TipoReporte
            Case "EMERGENCIA"
                TotalFilasLV = lvE.Items.Count - 1
            Case "HOSPITALIZACION"
                TotalFilasLV = lvH.Items.Count - 1
            Case "CONSULTA"
                TotalFilasLV = lvC.Items.Count - 1
        End Select
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Encabezado(e)
        Filas = 10
        NroFilasHoja = 0
        Y = Y + 40
        With e.Graphics
            .DrawString("Descripcion", FuenteE, Pincel, 30, Y)
            .DrawString("Cant", FuenteE, Pincel, 440, Y)
            Y = Y + 10
            .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
            Y = Y + 10
            Do While NroFilasTotales <= TotalFilasLV
                Select Case TipoReporte
                    Case "EMERGENCIA"
                        .DrawString(Microsoft.VisualBasic.Left(lvE.Items(NroFilasTotales).SubItems(0).Text & StrDup(60, " "), 60), FuenteE, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & lvE.Items(NroFilasTotales).SubItems(1).Text, 7), FuenteE, Pincel, 420, Y)
                    Case "HOSPITALIZACION"
                        .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(0).Text & StrDup(60, " "), 60), FuenteE, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & lvH.Items(NroFilasTotales).SubItems(1).Text, 7), FuenteE, Pincel, 420, Y)
                    Case "CONSULTA"
                        .DrawString(Microsoft.VisualBasic.Left(lvC.Items(NroFilasTotales).SubItems(0).Text & StrDup(60, " "), 60), FuenteE, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & lvC.Items(NroFilasTotales).SubItems(1).Text, 7), FuenteE, Pincel, 420, Y)
                End Select

                Y = Y + 10
                NroFilasHoja += 1
                If NroFilasHoja >= 80 Then
                    Exit Do
                End If
                NroFilasTotales += 1
            Loop
            If NroFilasHoja >= 80 Then
                e.HasMorePages = True
                NroFilasHoja = 0
            Else
                e.HasMorePages = False
                .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
                Y = Y + 10
                Select Case TipoReporte
                    Case "EMERGENCIA"
                        .DrawString("TOTALES ==> " & lblCantE.Text & StrDup(4, " "), FuenteE, Pincel, 354, Y)
                    Case "HOSPITALIZACION"
                        .DrawString("TOTALES ==> " & lblCantH.Text & StrDup(4, " "), FuenteE, Pincel, 354, Y)
                    Case "CONSULTA"
                        .DrawString("TOTALES ==> " & lblCantC.Text & StrDup(4, " "), FuenteE, Pincel, 354, Y)
                End Select
            End If
        End With
    End Sub

    Private Sub btnImprimirE_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirE.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TipoReporte = "EMERGENCIA"
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimirH_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirH.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TipoReporte = "HOSPITALIZACION"
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimirC_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirC.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TipoReporte = "CONSULTA"
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub
End Class