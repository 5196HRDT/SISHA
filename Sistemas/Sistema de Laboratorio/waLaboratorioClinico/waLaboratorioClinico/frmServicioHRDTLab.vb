Public Class frmServicioHRDTLab
    Dim objLaboratorio As New Laboratorio

    'Variables Impresion
    Dim Fuente14N As New Font("Courier New", 14, FontStyle.Bold)
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12 As New Font("Courier New", 12)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim X, Y As Integer

    Private Sub frmServicioHRDTLab_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        lvReporte.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsTabla As New DataSet

        'CONSULTA EXTERNA
        'BANCO DE SANGRE
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", "BANCO DE SANGRE")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Fila = lvReporte.Items.Add("BANCO DE SANGRE")
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
        End If

        'BIOQUIMICA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", "BIOQUIMICA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Fila = lvReporte.Items.Add("BIOQUIMICA")
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
        End If

        'HEMATOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", "HEMATOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Fila = lvReporte.Items.Add("HEMATOLOGIA")
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
        End If

        'INMUNOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", "INMUNOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Fila = lvReporte.Items.Add("INMUNOLOGIA")
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
        End If

        'MICROBIOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "CONSULTA EXTERNA", "MICROBIOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Fila = lvReporte.Items.Add("MICROBIOLOGIA")
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
        End If

        'EMERGENCIA
        'BANCO DE SANGRE
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", "BANCO DE SANGRE")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(0).SubItems(2).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'BIOQUIMICA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", "BIOQUIMICA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(1).SubItems(2).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'HEMATOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", "HEMATOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(2).SubItems(2).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'INMUNOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", "INMUNOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(3).SubItems(2).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'MICROBIOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "EMERGENCIA", "MICROBIOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(4).SubItems(2).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'HOSPITALIZACION
        'BANCO DE SANGRE
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", "BANCO DE SANGRE")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(0).SubItems(3).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'BIOQUIMICA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", "BIOQUIMICA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(1).SubItems(3).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'HEMATOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", "HEMATOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(2).SubItems(3).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'INMUNOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", "INMUNOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(3).SubItems(3).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'MICROBIOLOGIA
        dsTabla = objLaboratorio.ServicioHRDTLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, "HOSPITALIZACION", "MICROBIOLOGIA")
        If dsTabla.Tables(0).Rows.Count > 0 Then
            lvReporte.Items(4).SubItems(3).Text = Microsoft.VisualBasic.Format(Val(dsTabla.Tables(0).Rows(0)("Total")), "#0.00")
        End If

        'Totales
        Dim TA, TB, TC As Integer
        For I = 0 To lvReporte.Items.Count - 1
            TA = TA + Val(lvReporte.Items(I).SubItems(1).Text)
            TB = TB + Val(lvReporte.Items(I).SubItems(2).Text)
            TC = TC + Val(lvReporte.Items(I).SubItems(3).Text)
        Next
        Fila = lvReporte.Items.Add("TOTAL")
        Fila.SubItems.Add(Microsoft.VisualBasic.Format(TA, "#0.00"))
        Fila.SubItems.Add(Microsoft.VisualBasic.Format(TB, "#0.00"))
        Fila.SubItems.Add(Microsoft.VisualBasic.Format(TB, "#0.00"))
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim I As Integer
        Y = 30
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO" & StrDup(20, " ") & "Departamento de Laboratorio y Pagologia", Fuente12, Pincel, 60, Y)

            Y = Y + 40
            .DrawString("REPORTE DE SERVICIOS HRDT - LABORATORIO ENTRE EL" & dtpF1.Value.ToShortDateString & " Y EL " & dtpF2.Value.ToShortDateString, Fuente14N, Pincel, 150, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 130, Y, 1050, Y)

            Y = Y + 40
            .DrawString("TIPO" & StrDup(15, " ") & "CONSULTA EXTERNA" & StrDup(15, " ") & "EMERGENCIA" & StrDup(10, " ") & "HOSPITALIZACION", Fuente12N, Pincel, 100, Y)
            Y = Y + 20
            .DrawLine(Pens.Black, 90, Y, 1000, Y)
            Y = Y + 15
            For I = 0 To 4
                .DrawString(Microsoft.VisualBasic.Left(lvReporte.Items(I).SubItems(0).Text & StrDup(20, " "), 20), Fuente12N, Pincel, 100, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(I).SubItems(1).Text, 15), Fuente12N, Pincel, 300, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(I).SubItems(2).Text, 15), Fuente12N, Pincel, 550, Y)
                .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(I).SubItems(3).Text, 15), Fuente12N, Pincel, 800, Y)
                Y = Y + 20
            Next
            .DrawLine(Pens.Black, 90, Y, 1000, Y)
            .DrawString(Microsoft.VisualBasic.Left(lvReporte.Items(5).SubItems(0).Text & StrDup(20, " "), 20), Fuente12N, Pincel, 100, Y)
            .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(5).SubItems(1).Text, 15), Fuente12N, Pincel, 300, Y)
            .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(5).SubItems(2).Text, 15), Fuente12N, Pincel, 550, Y)
            .DrawString(Microsoft.VisualBasic.Right(StrDup(15, " ") & lvReporte.Items(5).SubItems(3).Text, 15), Fuente12N, Pincel, 800, Y)

        End With
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
    End Sub
End Class