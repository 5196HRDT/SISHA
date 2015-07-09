Public Class frmControlIngreso
    Dim objEmergencia As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta
    Dim objAlta As New clsEmergenciaIngreso_Alta
    Dim objPaciente As New clsHistoria

    'Variables Impresion
    Dim Fuente14 As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim Fuente12 As New Font("Lucida Console", 12)
    Dim Fuente8 As New Font("Lucida Console", 8)
    Dim Fuente9N As New Font("Lucida Console", 9, FontStyle.Bold)
    Dim Fuente12N As New Font("Lucida Console", 12, FontStyle.Bold)
    Dim Fuente8N As New Font("Lucida Console", 8, FontStyle.Bold)

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

    Private Sub frmControlIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged
        lvAdmision.Items.Clear()
        Dim dsVer As New DataSet
        Dim dsHistoria As New DataSet
        dsVer = objEmergencia.BuscarAtenAdmision(dtpFecha.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvAdmision.Items.Add(dsVer.Tables(0).Rows(I)("IdIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            dsHistoria = objPaciente.Buscar(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres"))
        Next
    End Sub

    Private Sub BuscarDetalle(ByVal IdIngreso As Integer)
        lvConsulta.Items.Clear()
        lvAlta.Items.Clear()
        Dim Fila As ListViewItem
        Dim dsConsulta As New DataSet
        dsConsulta = objConsulta.ConsultaBuscar(IdIngreso)
        If dsConsulta.Tables(0).Rows.Count > 0 Then
            Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(0)("Hora"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Cie1"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie1"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Cie2"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie2"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Cie3"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("DesCie3"))
        End If

        Dim dsAlta As New DataSet
        dsAlta = objAlta.BuscarAlta(IdIngreso)
        If dsAlta.Tables(0).Rows.Count > 0 Then
            Fila = lvAlta.Items.Add(dsAlta.Tables(0).Rows(0)("Hora"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("CondicionAlta"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Medico"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("TipoAlta"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Destino"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Cie1"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("DesCie1"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Cie2"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("DesCie2"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Cie3"))
            Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("DesCie3"))
        End If
    End Sub

    Private Sub lvAdmision_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvAdmision.SelectedIndexChanged
        If lvAdmision.SelectedItems.Count > 0 Then BuscarDetalle(lvAdmision.SelectedItems(0).SubItems(0).Text)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        lvH.Items.Clear()
        'Llenar Atenciones
        Dim I As Integer
        Dim J As Integer
        Dim Fila As ListViewItem
        For I = 0 To lvAdmision.Items.Count - 1
            Fila = lvH.Items.Add(lvAdmision.Items(I).SubItems(0).Text)
            Fila.SubItems.Add(lvAdmision.Items(I).SubItems(1).Text)
            Fila.SubItems.Add(lvAdmision.Items(I).SubItems(2).Text)
            Fila.SubItems.Add(lvAdmision.Items(I).SubItems(3).Text)
            Fila.SubItems.Add(lvAdmision.Items(I).SubItems(4).Text)
            Fila.SubItems.Add(lvAdmision.Items(I).SubItems(5).Text)
            Fila.SubItems.Add("ADMISION")

            BuscarDetalle(lvAdmision.Items(I).SubItems(0).Text)
            'Ingreso
            If lvConsulta.Items.Count = 0 Then
                Fila = lvH.Items.Add("")
                Fila.SubItems.Add("***NO REGISTRA INFORMACION DE INGRESO***")
                Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("TITULO")
            Else
                Fila = lvH.Items.Add("")
                Fila.SubItems.Add("***INFORMACION DE INGRESO***")
                Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("TITULO")
                For J = 0 To lvConsulta.Items.Count - 1
                    Fila = lvH.Items.Add(lvConsulta.Items(J).SubItems(0).Text)
                    Fila.SubItems.Add(lvConsulta.Items(J).SubItems(1).Text)
                    Fila.SubItems.Add(lvConsulta.Items(J).SubItems(2).Text)
                    Fila.SubItems.Add(lvConsulta.Items(J).SubItems(3).Text)
                    Fila.SubItems.Add(lvConsulta.Items(J).SubItems(4).Text)
                    Fila.SubItems.Add(lvConsulta.Items(J).SubItems(5).Text)
                    Fila.SubItems.Add("INGRESO")
                Next
            End If
            'Altas
            If lvAlta.Items.Count = 0 Then
                Fila = lvH.Items.Add("")
                Fila.SubItems.Add("***NO REGISTRA INFORMACION DE ALTA***")
                Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("TITULO")
            Else
                Fila = lvH.Items.Add("")
                Fila.SubItems.Add("***INFORMACION DE ALTA***")
                Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("TITULO")
                For J = 0 To lvAlta.Items.Count - 1
                    Fila = lvH.Items.Add(lvAlta.Items(J).SubItems(0).Text)
                    Fila.SubItems.Add(lvAlta.Items(J).SubItems(1).Text)
                    Fila.SubItems.Add(lvAlta.Items(J).SubItems(2).Text)
                    Fila.SubItems.Add(lvAlta.Items(J).SubItems(5).Text)
                    Fila.SubItems.Add(lvAlta.Items(J).SubItems(6).Text)
                    Fila.SubItems.Add(lvAlta.Items(J).SubItems(7).Text)
                    Fila.SubItems.Add("ALTA")
                Next
            End If
            Fila = lvH.Items.Add("-")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("") : Fila.SubItems.Add("")
        Next
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        NroFilasTotales = 0
        TotalFilasLV = lvH.Items.Count - 1
        NroConsultas = 0
        NroFilasHoja = 0
        NroPaginas = 1
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            .DrawString(" Hospital Regional", Fuente8, Pincel, 30, Y)
            .DrawString("Emergencia - Nro Pag: " & NroPaginas, Fuente8, Pincel, 640, Y)
            Y = Y + 15
            .DrawString("Docente de Trujillo", Fuente8, Pincel, 30, Y)
            .DrawString(Date.Now, Fuente8, Pincel, 640, Y)
            Y = Y + 30
            .DrawString("REPORTE DEL CONTROL DE ATENCIONES EN EMERGENCIA DEL " & dtpFecha.Value.ToShortDateString, Fuente12N, Pincel, 80, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 70, Y, 760, Y)
            Y = Y + 20
            .DrawString("HoraIng" & StrDup(2, " ") & "Especialidad" & StrDup(15, " ") & "Médico" & StrDup(15, " ") & "Historia" & StrDup(8, " ") & "Paciente", Fuente8N, Pincel, 40, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 30, Y, 800, Y)
            Y = Y + 5
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        Dim NroFila As Integer = 0
        Y = 20
        Filas = 10
        NroFilasHoja = 0
        Encabezado(e)
        With e.Graphics
            Do While TotalFilasLV >= 0
                If lvH.Items(NroFilasTotales).SubItems(6).Text = "ADMISION" Then
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(1).Text, Fuente8, Pincel, 40, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(2).Text, Fuente8, Pincel, 100, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(3).Text & StrDup(40, " "), 40), Fuente8, Pincel, 200, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(4).Text, Fuente8, Pincel, 450, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(5).Text & StrDup(40, " "), 40), Fuente8, Pincel, 520, Y)
                ElseIf lvH.Items(NroFilasTotales).SubItems(6).Text = "TITULO" Then
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(1).Text, Fuente8, Pincel, 40, Y)
                ElseIf lvH.Items(NroFilasTotales).SubItems(0).Text = "-" Then
                    .DrawLine(Pens.Black, 30, Y, 800, Y)
                ElseIf lvH.Items(NroFilasTotales).SubItems(6).Text = "INGRESO" Then
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(0).Text, Fuente8, Pincel, 40, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(1).Text, Fuente8, Pincel, 100, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(2).Text & StrDup(40, " "), 40), Fuente8, Pincel, 200, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(3).Text, Fuente8, Pincel, 450, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(4).Text & StrDup(40, " "), 40), Fuente8, Pincel, 520, Y)
                ElseIf lvH.Items(NroFilasTotales).SubItems(6).Text = "ALTA" Then
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(0).Text, Fuente8, Pincel, 40, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(1).Text, Fuente8, Pincel, 100, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(2).Text & StrDup(40, " "), 40), Fuente8, Pincel, 200, Y)
                    .DrawString(lvH.Items(NroFilasTotales).SubItems(3).Text, Fuente8, Pincel, 450, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvH.Items(NroFilasTotales).SubItems(4).Text & StrDup(40, " "), 40), Fuente8, Pincel, 520, Y)
                End If
                Y += 15
                TotalFilasLV -= 1
                NroFilasTotales += 1
                NroFilasHoja += 1
                If NroFilasHoja >= 66 Then Exit Do
            Loop

            If TotalFilasLV >= 0 Then
                e.HasMorePages = True
                NroFilasHoja = 0
                NroPaginas += 1
            Else
                e.HasMorePages = False
            End If
        End With
    End Sub
End Class