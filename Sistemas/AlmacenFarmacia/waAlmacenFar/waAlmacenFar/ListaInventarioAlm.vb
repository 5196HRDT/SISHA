Public Class ListaInventarioAlm
    Dim objMedicamento As New Medicamento
    Dim TotalFilas As Integer
    Dim NroPag As Integer
    Dim NroFila As Integer
    Dim I As Integer

    'Variables Impresion
    Dim Fuente As New Font("Courier New", 14, FontStyle.Bold)
    Dim FuenteE As New Font("Courier New", 10)
    Dim FuenteEnc As New Font("Courier New", 10, FontStyle.Bold)
    Dim FuenteP As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim dsTabla As New Data.DataSet
        dsTabla = objMedicamento.Buscar("")
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("StockActualA"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Unidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
        Next
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ppdVistaPrevia.ShowDialog()
    End Sub
    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvDet.Items.Count - 1
        NroPag = 1
        NroFila = 0
        I = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Y = 20
        Filas = 10
        e.Graphics.DrawString("Hospital Regional Docente de Trujillo" & StrDup(60, " ") & "Almacen de Farmacia", FuenteP, Pincel, 4, Y)
        Y = Y + 20
        With e.Graphics
            .DrawString("LISTA PARA TOMA DE INVENTARIO - ALMACEN FARMACIA", Fuente, Pincel, 140, Y)
            Y = Y + 40
            .DrawString("Fecha      :   " & Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy") & StrDup(50, " ") & "Nro Pag: " & NroPag.ToString, FuenteEnc, Pincel, 50, Y)
            Y = Y + 20
            .DrawString("Personal   :   _______________________________________________", FuenteEnc, Pincel, 50, Y)
            Y = Y + 40

            .DrawString("Cant" & StrDup(6, " ") & "Und" & StrDup(6, " ") & "Descripcion" & StrDup(36, " ") & "CantFis" & StrDup(6, " ") & "Und", FuenteE, Pincel, 40, Y)
            Y = Y + 18
            .DrawLine(Pens.Black, 0, Y, 900, Y)
            Y = Y + 10
            Do While TotalFilas >= 0
                .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvDet.Items(I).SubItems(0).Text, 10) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text & StrDup(5, " "), 5) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(2).Text & StrDup(50, " "), 50) & "________" & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text & StrDup(5, " "), 5), FuenteE, Pincel, 20, Y)
                Y = Y + 18

                NroFila += 1
                TotalFilas -= 1
                I += 1
                If NroFila >= 46 Then Exit Do
            Loop
            If TotalFilas > 0 Then
                e.HasMorePages = True
                NroPag += 1
                NroFila = 0
            Else
                e.HasMorePages = False
                .DrawLine(Pens.Black, 0, Y, 900, Y)
                Y = Y + 10
            End If
        End With
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ListaInventarioAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class