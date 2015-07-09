Public Class frmConsultaRepro
    Dim objProgPer As New ProgPer
    Dim objProgramacion As New Programacion

    'Variables Impresion
    Dim Fuente As New Font("Courier New", 14, FontStyle.Bold)
    Dim FuenteE As New Font("Courier New", 10)
    Dim FuenteEnc As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub frmConsultaRepro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If cboOrigenSala.Text = "" Then Exit Sub
        lstAnestesiologo.Items.Clear()
        lstCirculante.Items.Clear()
        'ProgPer
        Dim I As Integer
        Dim dsProgPer As New Data.DataSet
        dsProgPer = objProgPer.BuscarReporteOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), "ANESTESIOLOGO", cboOrigenSala.Text)
        For I = 0 To dsProgPer.Tables(0).Rows.Count - 1
            lstAnestesiologo.Items.Add(Microsoft.VisualBasic.Left(dsProgPer.Tables(0).Rows(I)("Sala") & ": " & StrDup(5, " "), 5) & "Dr. " & dsProgPer.Tables(0).Rows(I)("Nombres"))
        Next

        dsProgPer.Tables.Clear()
        dsProgPer = objProgPer.BuscarReporteOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), "CIRCULANTE", cboOrigenSala.Text)
        For I = 0 To dsProgPer.Tables(0).Rows.Count - 1
            lstCirculante.Items.Add(Microsoft.VisualBasic.Left(dsProgPer.Tables(0).Rows(I)("Sala") & ": " & StrDup(5, " "), 5) & dsProgPer.Tables(0).Rows(I)("Nombres"))
        Next

        dsProgPer.Tables.Clear()
        dsProgPer = objProgPer.BuscarReporteOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), "INST.", cboOrigenSala.Text)
        For I = 0 To dsProgPer.Tables(0).Rows.Count - 1
            lstCirculante.Items.Add("INST." & dsProgPer.Tables(0).Rows(I)("Nombres"))
        Next

        dsProgPer.Tables.Clear()
        dsProgPer = objProgPer.BuscarReporteOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), "URPA", cboOrigenSala.Text)
        For I = 0 To dsProgPer.Tables(0).Rows.Count - 1
            lstCirculante.Items.Add("URPA" & dsProgPer.Tables(0).Rows(I)("Nombres"))
        Next

        'Operaciones
        lvDet.Items.Clear()
        Dim dsOperacion As New Data.DataSet
        Dim Fila As ListViewItem
        dsOperacion = objProgramacion.BuscarReporteOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), cboOrigenSala.Text)
        For I = 0 To dsOperacion.Tables(0).Rows.Count - 1
            If dsOperacion.Tables(0).Rows(I)("Cambio").ToString <> "" Then
                Fila = lvDet.Items.Add(dsOperacion.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Edad"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Serv"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Operacion"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Hora"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Sala"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Anest"))
                Fila.SubItems.Add("Dr " & dsOperacion.Tables(0).Rows(I)("Cirujano"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Origen"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("Cambio"))
            End If
        Next
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim Filas As Integer = 0
        Dim I As Integer
        Y = 20
        Filas = 10
        e.Graphics.DrawString("Hospital Regional Docente de Trujillo" & StrDup(70, " ") & "Servicio de Anestesiología y Centro Quirúrgico", FuenteEnc, Pincel, 4, Y)
        Y = Y + 20
        With e.Graphics
            .DrawString("REPROGRAMACIN DE OPERACIONES", Fuente, Pincel, 350, Y)
            Y = Y + 20
            .DrawString("DIA    :   " & Microsoft.VisualBasic.Left(dtpFecha.Value, 10), Fuente, Pincel, 410, Y)
            Y = Y + 20

            .DrawString("ANESTESIOLOGOS" & StrDup(50, " ") & "CIRCULANTES", Fuente, Pincel, 50, Y)
            Y = Y + 20
            For I = 0 To lstAnestesiologo.Items.Count - 1
                If lstCirculante.Items.Count - 1 >= I Then
                    .DrawString(Microsoft.VisualBasic.Left(lstAnestesiologo.Items(I).ToString & StrDup(30, " "), 30) & StrDup(40, " ") & lstCirculante.Items(I).ToString, FuenteE, Pincel, 50, Y)
                Else
                    .DrawString(lstAnestesiologo.Items(I).ToString, FuenteE, Pincel, 50, Y)
                End If
                Y = Y + 20
            Next

            If lstCirculante.Items.Count > lstAnestesiologo.Items.Count Then
                If lstCirculante.Items.Count - lstAnestesiologo.Items.Count = 1 Then
                    .DrawString(StrDup(70, " ") & lstCirculante.Items(lstCirculante.Items.Count - 1).ToString, FuenteE, Pincel, 50, Y)
                ElseIf lstCirculante.Items.Count - lstAnestesiologo.Items.Count = 2 Then
                    .DrawString(StrDup(70, " ") & lstCirculante.Items(lstCirculante.Items.Count - 2).ToString, FuenteE, Pincel, 50, Y)
                    Y = Y + 20
                    .DrawString(StrDup(70, " ") & lstCirculante.Items(lstCirculante.Items.Count - 1).ToString, FuenteE, Pincel, 50, Y)
                End If
            End If

            Y = Y + 20
            .DrawString("HC" & StrDup(4, " ") & "NOMBRES DEL PACIENTE" & StrDup(4, " ") & "TIP " & "EDAD" & StrDup(2, " ") & "SERV" & StrDup(10, " ") & "OPERACION" & StrDup(14, " ") & "HORA" & StrDup(1, " ") & "SALA" & StrDup(1, " ") & "ANEST" & StrDup(6, " ") & "CIRUJANO", FuenteE, Pincel, 40, Y)
            Y = Y + 18
            .DrawLine(Pens.Black, 0, Y, 1050, Y)
            Y = Y + 10
            Dim HoraOper As String
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).SubItems(5).Text = "" Then HoraOper = StrDup(5, " ") Else HoraOper = Microsoft.VisualBasic.Right("00" & lvDet.Items(I).SubItems(5).Text, 5)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(7, "0") & lvDet.Items(I).SubItems(0).Text, 7) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text & StrDup(24, " "), 24) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(9).Text, 3) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(2).Text, 3) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(3).Text & StrDup(6, " "), 6) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(4).Text & StrDup(30, " "), 30) & StrDup(1, " ") & HoraOper & StrDup(3, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(6).Text & StrDup(2, " "), 2) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(7).Text & StrDup(5, " "), 5) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(8).Text & StrDup(20, " "), 20), FuenteE, Pincel, 4, Y)
                Y = Y + 18
                .DrawString("MOTIVO REPROGRAMACION: " & lvDet.Items(I).SubItems(10).Text, FuenteE, Pincel, 4, Y)
                Y = Y + 18
            Next

            Y = Y + 70

            .DrawString(StrDup(10, " ") & StrDup(24, "-") & StrDup(24, " ") & StrDup(24, "-"), FuenteE, Pincel, 70, Y)
            Y = Y + 10
            .DrawString(StrDup(15, " ") & "FIRMA MEDICO" & StrDup(36, " ") & "FIRMA ENFERMERA", FuenteE, Pincel, 70, Y)

        End With
    End Sub
End Class