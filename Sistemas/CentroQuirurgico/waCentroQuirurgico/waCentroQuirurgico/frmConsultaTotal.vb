Imports Microsoft.Office.Interop
Public Class frmConsultaTotal
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
    Private DT As DataTable

    Private Sub frmConsultaTotal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "TODO"
        cboOrigenSala.SelectedIndex = 0
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If dtpf2.Value < dtpFecha.Value Then MessageBox.Show("VERIFICAR FECHAS!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        If chkHabilitar.Checked = True Then
            dtpFecha.Value = dtpf2.Value
        End If

        If cboTipo.Text = "" Then cboTipo.Text = "TODO"
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
        dsOperacion = objProgramacion.BuscarReporteWebOrigen(Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), cboOrigenSala.Text, Microsoft.VisualBasic.Format(dtpf2.Value, "dd/MM/yyyy"))
        DT = dsOperacion.Tables(0)
        For I = 0 To dsOperacion.Tables(0).Rows.Count - 1
            If cboTipo.Text = "TODO" Then
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
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoProgramacion"))
                Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoCirugia"))
            ElseIf cboTipo.Text = "PROGRAMADAS" Then
                If dsOperacion.Tables(0).Rows(I)("TipoProgramacion") = "PROGRAMADA" Then
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
                    Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoProgramacion"))
                    Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoCirugia"))
                End If
            ElseIf cboTipo.Text = "EMERGENCIA" Then
                If dsOperacion.Tables(0).Rows(I)("TipoProgramacion") = "EMERGENCIA" Then
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
                    Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoProgramacion"))
                    Fila.SubItems.Add(dsOperacion.Tables(0).Rows(I)("TipoCirugia"))
                End If
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
            If cboTipo.Text = "TODO" Then
                .DrawString("ROL DE OPERACIONES PROGRAMADAS Y EMERGENCIA", Fuente, Pincel, 350, Y)
            ElseIf cboTipo.Text = "PROGRAMADAS" Then
                .DrawString("ROL DE OPERACIONES PROGRAMADAS", Fuente, Pincel, 350, Y)
            ElseIf cboTipo.Text = "EMERGENCIA" Then
                .DrawString("ROL DE OPERACIONES DE EMERGENCIA", Fuente, Pincel, 350, Y)
            End If
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
                .DrawString(Microsoft.VisualBasic.Right(StrDup(7, "0") & lvDet.Items(I).SubItems(0).Text, 7) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text & StrDup(24, " "), 24) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(9).Text, 3) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(2).Text, 3) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(3).Text & StrDup(6, " "), 6) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(4).Text & StrDup(30, " "), 30) & StrDup(1, " ") & HoraOper & StrDup(3, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(6).Text & StrDup(2, " "), 2) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(7).Text & StrDup(5, " "), 5) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(8).Text & StrDup(20, " "), 20) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(10).Text, 3), FuenteE, Pincel, 4, Y)
                Y = Y + 18
            Next

            Y = Y + 70

            .DrawString(StrDup(10, " ") & StrDup(24, "-") & StrDup(24, " ") & StrDup(24, "-"), FuenteE, Pincel, 70, Y)
            Y = Y + 10
            .DrawString(StrDup(15, " ") & "FIRMA MEDICO" & StrDup(36, " ") & "FIRMA ENFERMERA", FuenteE, Pincel, 70, Y)

        End With
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown, dtpf2.KeyDown
        If e.KeyCode = Keys.Enter Then cboTipo.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged, dtpf2.ValueChanged

    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then cboOrigenSala.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub cboOrigenSala_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOrigenSala.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigenSala.Text <> "" Then btnBuscar.Select()
    End Sub

    Private Sub cboOrigenSala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigenSala.SelectedIndexChanged

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If DT Is Nothing Then MessageBox.Show("NO DATA!!!", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            exHoja.Name = "REPORTE"
            With exHoja
                .Visible = Excel.XlSheetVisibility.xlSheetVisible
                .Activate()
                .Range("A1:L1").Merge()
                .Range("A1:L1").Value = "HOSPITAL REGIONAL DOCENTE DE TRUJILLO"
                .Range("A1:L1").Font.Bold = True
                .Range("A1:L1").Font.Size = 16
                .Range("A2:L2").Merge()
                .Range("A2:L2").Value = "REPORTE OPERACIONES TOTALES  DEL " & dtpFecha.Value.ToString()
                .Range("A2:L2").Font.Bold = True
                .Range("A2:L2").Font.Size = 12
            End With

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DT.Columns.Count
            Dim NRow As Integer = DT.Rows.Count
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(4, i) = DT.Columns(i - 1).ColumnName.ToString
                'exHoja.Cells.AutoFormat(vFormato)
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 5, Col + 1) = DT.Rows(Fila).Item(Col).ToString()

                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exApp.Quit()
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            
                MessageBox.Show(ex.Message, "REPORTE", MessageBoxButtons.OK, MessageBoxIcon.Error)



        End Try




    End Sub

    Private Sub chkHabilitar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHabilitar.CheckedChanged
        If (chkHabilitar.Checked = True) Then
            dtpf2.Enabled = False
        Else
            dtpf2.Enabled = True
        End If
    End Sub
End Class