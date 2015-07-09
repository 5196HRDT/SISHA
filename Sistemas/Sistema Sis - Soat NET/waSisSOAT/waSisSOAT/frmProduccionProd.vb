Public Class frmProduccionProd
    Dim objProduccion As New SIS
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dsVer As New Data.DataSet
        lblCant.Text = "0.00"
        lblImp.Text = "0.00"
        dsVer = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "", "", "", "", 8)
        'dsVer = objProduccion.Produccion(Microsoft.VisualBasic.Format(dtpF1.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Format(dtpF2.Value, "dd/MM/yyyy"), "RAYOS", "", "", "", 14)
        lvG.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvG.Items.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cant"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Imp"))
            lblCant.Text = Val(lblCant.Text) + Val(dsVer.Tables(0).Rows(I)("Cant"))
            lblImp.Text = Val(lblImp.Text) + Val(dsVer.Tables(0).Rows(I)("Imp"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Esta seguro de Imprimir Reporte Diario", "Mensaje de COnsulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ppdVistaPrevia.ShowDialog()
        End If
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString("DIRECCION DE SALUD LA LIBERTAD", FuenteE, Pincel, 40, Y)
            .DrawString("S  I  S", FuenteE, Pincel, 680, Y)
            Y = Y + 10
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 10, Y)
            Y = Y + 10
            .DrawString("UNIDAD DE SEGUROS", FuenteE, Pincel, 80, Y)

            Y = Y + 40

            .DrawString("REPORTE PRODUCCION DE PROCEDIMIENTOS SIS ENTRE EL " & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente, Pincel, 30, Y)
            Y = Y + 10
            .DrawString("------------------------------------------------------------------------------", Fuente, Pincel, 20, Y)
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroFilasTotales = 0
        TotalFilasLV = lvG.Items.Count - 1
        NroPaginas = 1
    End Sub

    Private Sub pdcDocumento_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
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
            .DrawString("Importe", FuenteE, Pincel, 520, Y)
            Y = Y + 10
            .DrawString(StrDup(116, "-"), FuenteE, Pincel, 0, Y)
            Y = Y + 10
            Do While NroFilasTotales <= TotalFilasLV
                .DrawString(Microsoft.VisualBasic.Left(lvG.Items(NroFilasTotales).SubItems(0).Text & StrDup(60, " "), 60), FuenteE, Pincel, 20, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(8, " ") & lvG.Items(NroFilasTotales).SubItems(1).Text, 7), FuenteE, Pincel, 420, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(12, " ") & lvG.Items(NroFilasTotales).SubItems(2).Text, 12), FuenteE, Pincel, 500, Y)
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
                .DrawString("TOTALES ==> " & lblCant.Text & StrDup(4, " ") & "S/ " & Microsoft.VisualBasic.Format(Val(lblImp.Text), "#,#0.#00"), FuenteE, Pincel, 354, Y)
            End If
        End With
    End Sub

    Private Sub frmProduccionProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class