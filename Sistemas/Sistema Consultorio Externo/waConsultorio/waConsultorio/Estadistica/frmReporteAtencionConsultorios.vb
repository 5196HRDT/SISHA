Imports System.Drawing.Printing

Public Class frmReporteAtencionConsultorios
    Dim objCupo As New Cupo

    'Variables Impresion
    Dim Fuente14N As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim Fuente12N As New Font("Lucida Console", 12, FontStyle.Bold)
    Dim Fuente12 As New Font("Lucida Console", 12)
    Dim Fuente8 As New Font("Lucida Console", 8)
    Dim Fuente9N As New Font("Lucida Console", 9, FontStyle.Bold)

    Dim TotalMedicos As Integer
    Dim K As Integer

    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim NroFilasTotales As Integer
    Dim NroPaginas As Integer
    Dim NroFilasHoja As Integer
    Dim TotalFilasLV As Integer
    Dim NroConsultas As Integer
    Dim X, Y As Integer
    Dim vImpresion As Integer
    Dim NroFila As Integer

    Private Sub ListaPacientes(ByVal IdProgramacion As String)
        Dim dsVer As New DataSet
        lvDetalle.Items.Clear()
        dsVer = objCupo.BuscarListaPacientes(IdProgramacion)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvDetalle.Items.Add(dsVer.Tables(0).Rows(I)("Cupo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoCupo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cupo"))
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmReporteAtencionConsultorios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        cboTurno.Text = "MAÑANA"
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        lvDetalle.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsCupo As New DataSet

        dsCupo = objCupo.BuscarProgramacionDiaria(dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsCupo.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsCupo.Tables(0).Rows(I)("IdProgramacion"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("SubEspecialidad"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("NomMedico").ToString)
        Next
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            ListaPacientes(lvTabla.SelectedItems(0).SubItems(0).Text)
        End If
    End Sub

    Private Sub ppdVistaPrevia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ppdVistaPrevia.Load

    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            Y = 20
            .DrawString("MINISTERIO DE SALUD", Fuente8, Pincel, 10, Y)
            .DrawString("CONSULTA EXTERNA", Fuente8, Pincel, 300, Y)
            Y = Y + 15
            .DrawString("H.R.D.T.", Fuente8, Pincel, 10, Y)
            Y = Y + 25
            .DrawString("PROGRAMACION DE CONSULTA EXTERNA", Fuente12N, Pincel, 100, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 100, Y, 460, Y)
            Y = Y + 15
            .DrawString("Fecha    : " & dtpFecha.Value.ToShortDateString, Fuente12, Pincel, 20, Y)
            .DrawString("Turno : " & cboTurno.Text, Fuente12, Pincel, 280, Y)
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroFilasTotales = 0
        TotalFilasLV = lvDetalle.Items.Count - 1
        NroConsultas = 0
        NroFila = 0
        Y = 20
        Dim Papel As New PaperSize("Custom Paper Size", 550, 730)
        ppHoja.PageSettings.PaperSize = Papel
        TotalMedicos = lvTabla.Items.Count - 1
        K = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        If vImpresion = 1 Then
            Y = 20
            Encabezado(e)
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 20

            With e.Graphics
                .DrawString("Servicio : " & lvTabla.SelectedItems(0).SubItems(1).Text, Fuente12, Pincel, 20, Y)
                Y = Y + 20
                .DrawString("Médico   : " & lvTabla.SelectedItems(0).SubItems(2).Text, Fuente12, Pincel, 20, Y)
                Y = Y + 20
                .DrawString("Nº" & StrDup(4, " ") & "HORA" & StrDup(2, " ") & "HISTORIA" & StrDup(10, " ") & "PACIENTE", Fuente9N, Pincel, 5, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 1, Y, 520, Y)
                Y = Y + 15
                Do While NroFilasTotales <= TotalFilasLV

                    .DrawString(lvDetalle.Items(NroFilasTotales).SubItems(0).Text, Fuente12N, Pincel, 5, Y)
                    .DrawString(lvDetalle.Items(NroFilasTotales).SubItems(1).Text, Fuente12N, Pincel, 40, Y)
                    .DrawString(lvDetalle.Items(NroFilasTotales).SubItems(2).Text, Fuente12N, Pincel, 100, Y)
                    If lvDetalle.Items(NroFilasTotales).SubItems(3).Text.Length > 32 Then .DrawString(Microsoft.VisualBasic.Left(lvDetalle.Items(NroFilasTotales).SubItems(3).Text, 32), Fuente12N, Pincel, 190, Y) Else .DrawString(lvDetalle.Items(NroFilasTotales).SubItems(3).Text, Fuente12N, Pincel, 190, Y)
                    Y = Y + 20
                    NroFilasHoja += 1
                    NroFilasTotales += 1
                    If NroFilasHoja >= 36 Then Exit Do
                Loop

                If NroFilasTotales >= TotalFilasLV Then
                    Y = Y + 5
                    .DrawLine(Pens.Black, 1, Y, 520, Y)
                    Y = Y + 5
                    .DrawString("Fecha Impresión " & Date.Now, Fuente8, Pincel, 5, Y)
                    e.HasMorePages = False
                Else

                    e.HasMorePages = True
                    NroFilasHoja = 0
                End If
            End With
        ElseIf vImpresion = 2 Then
            Dim J As Integer
            Do While K < TotalMedicos
                With e.Graphics
                    Y = 20
                    Encabezado(e)
                    Y = Y + 20
                    ListaPacientes(lvTabla.Items(K).SubItems(0).Text)
                    .DrawString("Servicio : " & lvTabla.Items(K).SubItems(1).Text, Fuente12, Pincel, 20, Y)
                    Y = Y + 20
                    .DrawString("Médico   : " & lvTabla.Items(K).SubItems(2).Text, Fuente12, Pincel, 20, Y)
                    Y = Y + 20
                    .DrawString("Nº" & StrDup(2, " ") & "HORA" & StrDup(2, " ") & "HISTORIA" & StrDup(10, " ") & "PACIENTE", Fuente8, Pincel, 5, Y)
                    Y = Y + 15
                    .DrawLine(Pens.Black, 1, Y, 520, Y)
                    Y = Y + 15
                    For J = 0 To lvDetalle.Items.Count - 1
                        .DrawString(lvDetalle.Items(J).SubItems(0).Text, Fuente9N, Pincel, 5, Y)
                        .DrawString(lvDetalle.Items(J).SubItems(1).Text, Fuente9N, Pincel, 30, Y)
                        .DrawString(lvDetalle.Items(J).SubItems(2).Text, Fuente9N, Pincel, 80, Y)
                        .DrawString(lvDetalle.Items(J).SubItems(3).Text, Fuente9N, Pincel, 140, Y)
                        Y = Y + 15
                    Next
                    Y = Y + 5
                    .DrawLine(Pens.Black, 1, Y, 520, Y)
                    Y = Y + 5
                    .DrawString("Fecha Impresión " & Date.Now, Fuente8, Pincel, 5, Y)
                    K += 1
                    If K > TotalMedicos Then
                        e.HasMorePages = False
                    Else
                        e.HasMorePages = True
                    End If
                End With
            Loop
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvTabla.SelectedItems.Count = 0 Then MessageBox.Show("Debe seleccionar un Medico para imprimir sus Atenciones", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        vImpresion = 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnImprimirTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirTodo.Click
        If lvTabla.Items.Count = 0 Then MessageBox.Show("No existe lista de Medicos  a Imprimir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        vImpresion = 2
        ppdVistaPrevia.ShowDialog()
    End Sub
End Class