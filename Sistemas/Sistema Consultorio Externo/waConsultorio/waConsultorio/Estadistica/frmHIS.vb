Public Class frmHIS
    Dim objProgramacion As New Programacion
    Dim objCupo As New Cupo
    Dim objConsulta As New Consulta
    Dim objConsultaCPT As New ConsultaCPT
    Dim objInterconsulta As New InterconsultaH
    Dim objInterconsultaE As New InterconsultaE
    Dim objMedico As New Medico
    Dim DNI As String

    'Variables Impresion
    Dim FuenteE3 As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteE2 As New Font("TIMES NEW ROMAN", 16, FontStyle.Bold)
    Dim FuenteD1 As New Font("Lucida Console", 12)
    Dim FuenteE1 As New Font("Lucida Console", 8)
    Dim FuenteD2 As New Font("Lucida Console", 9, FontStyle.Bold)

    Dim FuenteM As New Font("Lucida Console", 14, FontStyle.Bold)
    Dim FuenteTit As New Font("TIMES NEW ROMAN", 20, FontStyle.Bold)
    Dim Fuente As New Font("Lucida Console", 12)
    Dim FuenteA As New Font("Lucida Console", 12, FontStyle.Bold)
    Dim FuenteTex As New Font("Lucida Console", 8)
    Dim FuenteP As New Font("Lucida Console", 9, FontStyle.Bold)

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


    Private Sub frmHIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now.ToShortDateString
        cboTurno.Text = "MAÑANA"

        btnImprimirHIS.Enabled = False
        btnHIS2.Enabled = False
        btnHIS3.Enabled = False
        btnHIS4.Enabled = False
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        btnImprimirHIS.Enabled = False
        btnHIS2.Enabled = False
        btnHIS3.Enabled = False
        btnHIS4.Enabled = False

        lvMedico.Items.Clear()
        Dim dsTabla As New Data.DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        dsTabla = objProgramacion.BuscarListaMed(dtpFecha.Value.ToShortDateString, cboTurno.Text)
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvMedico.Items.Add(dsTabla.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdProgramacion"))
        Next
    End Sub

    Private Sub lvMedico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMedico.SelectedIndexChanged
        lvConsulta.Items.Clear()
        lvDet.Items.Clear()

        btnImprimirHIS.Enabled = False
        btnHIS2.Enabled = False
        btnHIS3.Enabled = False
        btnHIS4.Enabled = False

        If lvMedico.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim Edad As String
            Dim dsConsulta As New Data.DataSet

            'Consultas
            dsConsulta = objCupo.Cupos_BuscarAtencionAtendida(dtpFecha.Value.ToShortDateString, cboTurno.Text, lvMedico.SelectedItems(0).SubItems(0).Text)
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Paterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Materno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))
                Dim Año As Integer
                Edad = "0"
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        Año = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        If Año > 1 Then
                            If Microsoft.VisualBasic.Month(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                                Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            Else
                                Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                            End If
                        Else
                            If Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                                Edad = 12 - Month(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento"))) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                                Edad = "11" & " M y " & 30 - (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)) & " D"
                            ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                                Edad = "1 A y 0 D"
                            End If
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If

                Fila.SubItems.Add(Edad)
                If dsConsulta.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3)) Else Fila.SubItems.Add("")
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
                Fila.SubItems.Add("CONSULTA")
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("HoraInicioAtencion"))
            Next

            'Interconsultas
            dsConsulta = objInterconsulta.BuscarAtencionAtendida(dtpFecha.Value.ToShortDateString, cboTurno.Text, lvMedico.SelectedItems(0).SubItems(0).Text)
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

                Edad = "0"
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        If Microsoft.VisualBasic.Month(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        Else
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If

                Fila.SubItems.Add(Edad)
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdInterconsultaH"))
                Fila.SubItems.Add("INTERCONSULTA")
                Fila.SubItems.Add("")
            Next

            'Interconsultas Emergencia
            dsConsulta = objInterconsultaE.BuscarAtencionAtendida(dtpFecha.Value.ToShortDateString, cboTurno.Text, lvMedico.SelectedItems(0).SubItems(0).Text)
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

                Edad = "0"
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        If Microsoft.VisualBasic.Month(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        Else
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If

                Fila.SubItems.Add(Edad)
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdInterconsultae"))
                Fila.SubItems.Add("INTERCONSULTAE")
                Fila.SubItems.Add("")
            Next

            'Procedimientos
            dsConsulta = objConsultaCPT.BuscarAtencionAtendida(dtpFecha.Value.ToShortDateString, cboTurno.Text, lvMedico.SelectedItems(0).SubItems(0).Text)
            For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
                Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

                Edad = "0"
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                        If Microsoft.VisualBasic.Month(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        Else
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsConsulta.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsConsulta.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If

                Fila.SubItems.Add(Edad)
                Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
                If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
                Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdProcedimiento"))
                Fila.SubItems.Add("PROCEDIMIENTO")
                Fila.SubItems.Add("")
            Next

        End If

        If lvConsulta.Items.Count >= 1 Then btnImprimirHIS.Enabled = True
        If lvConsulta.Items.Count > 12 Then btnHIS2.Enabled = True
        If lvConsulta.Items.Count > 25 Then btnHIS3.Enabled = True
        If lvConsulta.Items.Count > 37 Then btnHIS4.Enabled = True
    End Sub

    Private Sub btnImprimirT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirT.Click
        vImpresion = 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub Encabezado(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs, ByVal Medico As String, ByVal Especialidad As String)
        With Imp.Graphics
            .DrawString(" Hospital Regional", FuenteE1, Pincel, 30, Y)
            .DrawString(Microsoft.VisualBasic.Left("Dr(a) " & Medico & StrDup(32, " "), 32), FuenteE2, Pincel, 350, Y)
            Y = Y + 20
            .DrawString("Docente de Trujillo", FuenteE1, Pincel, 30, Y)
            .DrawString(Microsoft.VisualBasic.Left(Especialidad & StrDup(32, " "), 32), FuenteE2, Pincel, 350, Y)
            Y = Y + 30
            .DrawString("CONSULTA EXTERNA", FuenteE3, Pincel, 200, Y)
            Y = Y + 10
            .DrawString("Fecha: " & dtpFecha.Value.ToShortDateString & "-" & lvConsulta.SelectedItems(0).SubItems(9).Text & " Turno: " & Microsoft.VisualBasic.Left(cboTurno.Text, 2), FuenteD2, Pincel, 500, Y)
            Y = Y + 10
            .DrawLine(Pens.Black, 200, Y, 400, Y)
            Y = Y + 15
            .DrawString("Historia" & StrDup(15, " ") & "Paciente" & StrDup(32, " ") & "FechaNac" & StrDup(6, " ") & "Edad" & StrDup(8, " ") & "Sexo", FuenteD2, Pincel, 40, Y)
        End With
    End Sub

    Private Sub EncabezadoHIS(ByVal Imp As System.Drawing.Printing.PrintPageEventArgs)
        With Imp.Graphics
            Y = 20
            .DrawString("MINISTERIO DE SALUD", FuenteTit, Pincel, 250, Y)
            Y = Y + 20
            .DrawString("OITE GERESA/LL", FuenteTit, Pincel, 300, Y)
            Y = Y + 40
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString("Hospital ( X ) , Instituto (   ) , C.S. (   ) , P.S. (   )     TURNO       Nº DNi del Trabajador  Nº LOTE:", FuenteTex, Pincel, 40, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString(Microsoft.VisualBasic.Left("HOSPITAL REGIONAL DOCENTE DE TRUJILLO" & StrDup(38, " "), 38) & StrDup(2, " ") & Microsoft.VisualBasic.Left(cboTurno.Text & StrDup(10, " "), 10) & StrDup(2, " ") & Microsoft.VisualBasic.Left(DNI & StrDup(8, " "), 8), FuenteA, Pincel, 40, Y)
            .DrawString("Nº Pagina:", FuenteTex, Pincel, 700, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 15
            .DrawString("Registro Diario de Atencion y Otras Actvidades", Fuente, Pincel, 40, Y)
            .DrawString("NOMBRES DEL RESPONSABLE DE ATENCION", FuenteTex, Pincel, 545, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 5
            .DrawString("F E C H A      Codigo RENAES       Unidad Productora de Servicios (UPS) " & "Fecha y Hora Imp: " & Date.Now.ToShortDateString & "-" & Date.Now.ToShortTimeString, FuenteTex, Pincel, 40, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 540, Y)
            Y = Y + 10
            .DrawString(StrDup(2, " ") & Microsoft.VisualBasic.Right("00" & Month(dtpFecha.Value), 2) & "-" & Year(dtpFecha.Value) & StrDup(14, " ") & Microsoft.VisualBasic.Left(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text & StrDup(22, " "), 22) & StrDup(1, " ") & Microsoft.VisualBasic.Left(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text & StrDup(25, " "), 25), FuenteA, Pincel, 10, Y)
            Y = Y + 40
            .DrawLine(Pens.Black, 10, Y, 820, Y)
            Y = Y + 10
            .DrawString("  Dia HISTORIA  FINA PETN DIS/CEN EDAD SEX ESTA SERV  DIAGNOSTICO/MOTIVO CONSULTA/ACT SALUD     T.DX  LAB CIE/CPT", FuenteTex, Pincel, 10, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 10, Y, 840, Y)
            Y = Y + 5
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        If vImpresion = 1 Then
            NroFilasTotales = 0
            TotalFilasLV = lvConsulta.Items.Count - 1
            NroConsultas = 0
            Y = 20
        ElseIf vImpresion = 2 Then
            NroFilasTotales = 0
            TotalFilasLV = lvDet.Items.Count - 1
            NroConsultas = 0
            Y = 20
        ElseIf vImpresion = 3 Then
            NroFilasTotales = 36
            TotalFilasLV = lvDet.Items.Count - 1
            NroConsultas = 0
            Y = 20
        ElseIf vImpresion = 4 Then
            NroFilasTotales = 63
            TotalFilasLV = lvDet.Items.Count - 1
            NroConsultas = 0
            Y = 20
        ElseIf vImpresion = 5 Then
            NroFilasTotales = 63
            TotalFilasLV = lvConsulta.Items.Count - 1
            NroConsultas = 0
            Y = 20
        End If
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", FuenteD1).Height
        Dim Filas As Integer = 0
        Dim NroFila As Integer = 0

        If vImpresion = 1 Then
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            With e.Graphics
                Do While TotalFilasLV >= 0
                    If lvConsulta.Items(NroFilasTotales).SubItems(8).Text <> "PROCEDIMIENTO" Then
                        NroConsultas += 1
                        If NroConsultas = 1 Then
                            Y = 20
                            Encabezado(e, lvMedico.SelectedItems(0).SubItems(1).Text, lvMedico.SelectedItems(0).SubItems(2).Text)
                        Else
                            Y = 580
                            .DrawString(StrDup(90, "-"), FuenteD1, Pincel, 5, Y)
                            Y += 20
                            Encabezado(e, lvMedico.SelectedItems(0).SubItems(1).Text, lvMedico.SelectedItems(0).SubItems(2).Text)
                            NroConsultas = 0
                        End If
                        Y += 15
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvConsulta.Items(NroFilasTotales).SubItems(0).Text, 10) & StrDup(8, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(NroFilasTotales).SubItems(1).Text & " " & lvConsulta.Items(NroFilasTotales).SubItems(2).Text & " " & lvConsulta.Items(NroFilasTotales).SubItems(3).Text & StrDup(55, " "), 55) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(NroFilasTotales).SubItems(6).Text & StrDup(10, " "), 10) & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(NroFilasTotales).SubItems(4).Text & StrDup(15, " "), 15) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(NroFilasTotales).SubItems(5).Text & StrDup(10, " "), 10), FuenteE1, Pincel, 25, Y)
                        Y += 15

                        Dim dsCupo As New Data.DataSet
                        Dim Cadena As String
                        If lvConsulta.Items(NroFilasTotales).SubItems(8).Text = "CONSULTA" Then
                            dsCupo = objConsulta.Buscar(lvConsulta.Items(NroFilasTotales).SubItems(7).Text)
                        ElseIf lvConsulta.Items(NroFilasTotales).SubItems(8).Text = "INTERCONSULTA" Then
                            dsCupo = objInterconsulta.Buscar(lvConsulta.Items(NroFilasTotales).SubItems(7).Text)
                        ElseIf lvConsulta.Items(NroFilasTotales).SubItems(8).Text = "INTERCONSULTAE" Then
                            dsCupo = objInterconsultaE.Buscar(lvConsulta.Items(NroFilasTotales).SubItems(7).Text)
                        End If
                        .DrawString(Microsoft.VisualBasic.Left("Talla: " & dsCupo.Tables(0).Rows(0)("Talla") & " cm" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Peso: " & dsCupo.Tables(0).Rows(0)("Peso") & " gr" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Pulso: " & dsCupo.Tables(0).Rows(0)("Pulso") & " xMin" & StrDup(18, " "), 18) & Microsoft.VisualBasic.Left("Presion: " & dsCupo.Tables(0).Rows(0)("Presion") & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Temp: " & dsCupo.Tables(0).Rows(0)("Temp") & " ºC" & StrDup(18, " "), 18), FuenteE1, Pincel, 30, Y)
                        Y += 20
                        .DrawString("SINTOMAS Y SIGNOS: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Sintomas") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Sintomas"), vbCrLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(210, " "), 210), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10

                        .DrawString("EVALUACION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evaluacion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evaluacion"), vbCrLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10

                        .DrawString("DIAGNOSTICOS: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie1") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des1") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD1")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie2") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des2") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD2")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie3") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des3") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD3")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 20
                        .DrawString("TRATAMIENTO: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Tratamiento") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Tratamiento"), vbCrLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 110 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)

                        Y += 10
                        .DrawString("EVOLUCION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evolucion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evolucion"), vbCrLf, " ") Else Cadena = "*************"
                        .DrawString(Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Evolucion") & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 5
                        .DrawString("----------------------------------" & StrDup(40, " ") & Date.Now, FuenteE1, Pincel, 100, Y)
                        Y += 15
                        .DrawString("Dr(a). " & dsCupo.Tables(0).Rows(0)("Responsable"), FuenteE1, Pincel, 100, Y)
                    End If
                    TotalFilasLV -= 1
                    NroFilasTotales += 1
                    If NroConsultas = 0 Then Exit Do
                Loop

                If TotalFilasLV >= 0 Then
                    e.HasMorePages = True
                    NroFilasHoja = 0
                Else
                    e.HasMorePages = False
                End If
            End With
        ElseIf vImpresion = 2 Then
            Y = 20
            EncabezadoHIS(e)
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            With e.Graphics
                Do While NroFilasTotales <= TotalFilasLV

                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        NroFila += 1
                        .DrawString(Microsoft.VisualBasic.Right("00" & NroFila, 2) & ")", FuenteTex, Pincel, 5, Y)
                    End If
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteTex, Pincel, 30, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(1).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 60, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(14).Text, FuenteTex, Pincel, 120, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(15).Text, FuenteTex, Pincel, 150, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(2).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 170, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(4).Text & StrDup(4, " "), 4), FuenteTex, Pincel, 240, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteTex, Pincel, 290, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteTex, Pincel, 320, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteTex, Pincel, 350, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(8).Text & StrDup(42, " "), 42), FuenteTex, Pincel, 380, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteTex, Pincel, 680, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(11).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 740, Y)
                    Y = Y + 12
                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        .DrawLine(Pens.Black, 10, Y, 840, Y)
                        Y = Y + 10
                    Else
                        .DrawLine(Pens.Black, 380, Y, 840, Y)
                        Y = Y + 10
                    End If

                    NroFilasHoja += 1
                    If NroFilasHoja = 70 Then
                        Exit Do
                    End If
                    NroFilasTotales += 1
                    If NroFilasTotales = 36 Then Exit Do
                Loop

                If NroFilasTotales < 36 Then
                    If NroFilasTotales > TotalFilasLV Then
                        e.HasMorePages = False
                    Else
                        e.HasMorePages = True
                        NroFilasHoja = 0
                    End If
                Else
                    e.HasMorePages = False
                End If
            End With
        ElseIf vImpresion = 3 Then
            Y = 20
            EncabezadoHIS(e)
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            With e.Graphics
                Do While NroFilasTotales <= TotalFilasLV
                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        NroFila += 1
                        .DrawString(Microsoft.VisualBasic.Right("00" & NroFila + 12, 2) & ")", FuenteTex, Pincel, 5, Y)
                    End If
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteTex, Pincel, 30, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(1).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 60, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(14).Text, FuenteTex, Pincel, 120, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(15).Text, FuenteTex, Pincel, 150, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(2).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 170, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(4).Text & StrDup(4, " "), 4), FuenteTex, Pincel, 240, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteTex, Pincel, 290, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteTex, Pincel, 320, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteTex, Pincel, 350, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(8).Text & StrDup(42, " "), 42), FuenteTex, Pincel, 380, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteTex, Pincel, 680, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(11).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 740, Y)
                    Y = Y + 12
                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        .DrawLine(Pens.Black, 10, Y, 840, Y)
                        Y = Y + 10
                    Else
                        .DrawLine(Pens.Black, 380, Y, 840, Y)
                        Y = Y + 10
                    End If

                    NroFilasHoja += 1
                    If NroFilasHoja >= 70 Then
                        Exit Do
                    End If
                    NroFilasTotales += 1
                    If NroFilasTotales = 75 Then Exit Do
                Loop

                If NroFilasTotales <= 75 Then
                    If NroFilasTotales > TotalFilasLV Then
                        e.HasMorePages = False
                    Else
                        e.HasMorePages = True
                        NroFilasHoja = 0
                    End If
                Else
                    e.HasMorePages = False
                End If
            End With
        ElseIf vImpresion = 4 Then
            Y = 20
            EncabezadoHIS(e)
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            With e.Graphics
                Do While NroFilasTotales <= TotalFilasLV
                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        NroFila += 1
                        .DrawString(Microsoft.VisualBasic.Right("00" & NroFila + 25, 2) & ")", FuenteTex, Pincel, 5, Y)
                    End If
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(0).Text, FuenteTex, Pincel, 30, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(1).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 60, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(14).Text, FuenteTex, Pincel, 120, Y)
                    .DrawString(StrDup(1, " ") & lvDet.Items(NroFilasTotales).SubItems(15).Text, FuenteTex, Pincel, 150, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(2).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 170, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(4).Text & StrDup(4, " "), 4), FuenteTex, Pincel, 240, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(5).Text, FuenteTex, Pincel, 290, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(6).Text, FuenteTex, Pincel, 320, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(7).Text, FuenteTex, Pincel, 350, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(8).Text & StrDup(42, " "), 42), FuenteTex, Pincel, 380, Y)
                    .DrawString(lvDet.Items(NroFilasTotales).SubItems(9).Text, FuenteTex, Pincel, 680, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvDet.Items(NroFilasTotales).SubItems(11).Text & StrDup(10, " "), 10), FuenteTex, Pincel, 740, Y)
                    Y = Y + 12
                    If lvDet.Items(NroFilasTotales).SubItems(0).Text <> "" Then
                        .DrawLine(Pens.Black, 10, Y, 840, Y)
                        Y = Y + 10
                    Else
                        .DrawLine(Pens.Black, 380, Y, 840, Y)
                        Y = Y + 10
                    End If

                    NroFilasHoja += 1
                    If NroFilasHoja = 70 Then
                        Exit Do
                    End If
                    NroFilasTotales += 1
                    If NroFilasTotales = 111 Then Exit Do
                Loop

                If NroFilasTotales <= 111 Then
                    If NroFilasTotales > TotalFilasLV Then
                        e.HasMorePages = False
                    Else
                        e.HasMorePages = True
                        NroFilasHoja = 0
                    End If
                Else
                    e.HasMorePages = False
                End If
            End With
        End If
        If vImpresion = 5 Then
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            Dim TextoAux As String
            Dim TextoImp As String
            Dim PosAnt As Integer
            With e.Graphics
                If TotalFilasLV >= 0 Then
                    If lvConsulta.SelectedItems(0).SubItems(8).Text <> "PROCEDIMIENTO" Then
                        NroConsultas += 1
                        Y = 20
                        Encabezado(e, lvMedico.SelectedItems(0).SubItems(1).Text, lvMedico.SelectedItems(0).SubItems(2).Text)

                        Y += 15
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvConsulta.SelectedItems(0).SubItems(0).Text, 10) & StrDup(8, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(1).Text & " " & lvConsulta.SelectedItems(0).SubItems(2).Text & " " & lvConsulta.SelectedItems(0).SubItems(3).Text & StrDup(55, " "), 55) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(6).Text & StrDup(10, " "), 10) & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(4).Text & StrDup(15, " "), 15) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(5).Text & StrDup(10, " "), 10), FuenteE1, Pincel, 25, Y)
                        Y += 15

                        Dim dsCupo As New Data.DataSet
                        Dim Cadena As String
                        If lvConsulta.SelectedItems(0).SubItems(8).Text = "CONSULTA" Then
                            dsCupo = objConsulta.Buscar(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        ElseIf lvConsulta.SelectedItems(0).SubItems(8).Text = "INTERCONSULTA" Then
                            dsCupo = objInterconsulta.Buscar(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        ElseIf lvConsulta.SelectedItems(0).SubItems(8).Text = "INTERCONSULTAE" Then
                            dsCupo = objInterconsultaE.Buscar(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        End If
                        .DrawString(Microsoft.VisualBasic.Left("Talla: " & dsCupo.Tables(0).Rows(0)("Talla") & " cm" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Peso: " & dsCupo.Tables(0).Rows(0)("Peso") & " gr" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Pulso: " & dsCupo.Tables(0).Rows(0)("Pulso") & " xMin" & StrDup(18, " "), 18) & Microsoft.VisualBasic.Left("Presion: " & dsCupo.Tables(0).Rows(0)("Presion") & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Temp: " & dsCupo.Tables(0).Rows(0)("Temp") & " ºC" & StrDup(18, " "), 18), FuenteE1, Pincel, 30, Y)
                        Y += 20
                        .DrawString("SINTOMAS Y SIGNOS: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Sintomas") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Sintomas"), vbLf, " ") Else Cadena = "**************"
                        
                        TextoAux = Cadena
                        Do While TextoAux.Length > 100
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, 100)
                            PosAnt = TextoImp.Length
                            Do While TextoImp(PosAnt - 1) <> " "
                                PosAnt = PosAnt - 1
                            Loop
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                            .DrawString(TextoImp, FuenteE1, Pincel, 25, Y)
                            TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
                            Y = Y + 15
                        Loop
                        .DrawString(TextoAux, FuenteE1, Pincel, 25, Y)
                        Y += 20

                        .DrawString("EVALUACION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evaluacion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evaluacion"), vbLf, " ") Else Cadena = "**************"
                        TextoAux = Cadena
                        Do While TextoAux.Length > 100
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, 100)
                            PosAnt = TextoImp.Length
                            Do While TextoImp(PosAnt - 1) <> " "
                                PosAnt = PosAnt - 1
                            Loop
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                            .DrawString(TextoImp, FuenteE1, Pincel, 25, Y)
                            TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
                            Y = Y + 15
                        Loop
                        .DrawString(TextoAux, FuenteE1, Pincel, 25, Y)
                        Y += 20


                        .DrawString("DIAGNOSTICOS: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie1") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des1") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TipoDiagnostico")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie2") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des2") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD1")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie3") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des3") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD3")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 20
                        .DrawString("TRATAMIENTO: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Tratamiento") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Tratamiento"), vbCrLf, " ") Else Cadena = "**************"

                        TextoAux = Cadena
                        Do While TextoAux.Length > 100
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, 100)
                            PosAnt = TextoImp.Length
                            Do While TextoImp(PosAnt - 1) <> " "
                                PosAnt = PosAnt - 1
                            Loop
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                            .DrawString(TextoImp, FuenteE1, Pincel, 25, Y)
                            TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
                            Y = Y + 15
                        Loop
                        .DrawString(TextoAux, FuenteE1, Pincel, 25, Y)
                        Y += 20



                        Y += 10
                        .DrawString("EVOLUCION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evolucion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evolucion"), vbLf, " ") Else Cadena = "**************"

                        TextoAux = Cadena
                        Do While TextoAux.Length > 100
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, 100)
                            PosAnt = TextoImp.Length
                            Do While TextoImp(PosAnt - 1) <> " "
                                PosAnt = PosAnt - 1
                            Loop
                            TextoImp = Microsoft.VisualBasic.Left(TextoAux, PosAnt)
                            .DrawString(TextoImp, FuenteE1, Pincel, 25, Y)
                            TextoAux = Microsoft.VisualBasic.Right(TextoAux, TextoAux.Length - PosAnt)
                            Y = Y + 15
                        Loop
                        .DrawString(TextoAux, FuenteE1, Pincel, 25, Y)
                        Y += 40

                        Y += 5
                        .DrawString("----------------------------------" & StrDup(40, " ") & Date.Now, FuenteE1, Pincel, 100, Y)
                        Y += 15
                        .DrawString("Dr(a). " & dsCupo.Tables(0).Rows(0)("Responsable"), FuenteE1, Pincel, 100, Y)
                    End If

                    If lvConsulta.SelectedItems(0).SubItems(8).Text = "PROCEDIMIENTO" Then
                        NroConsultas += 1
                        Y = 20
                        Encabezado(e, lvMedico.SelectedItems(0).SubItems(1).Text, lvMedico.SelectedItems(0).SubItems(2).Text)

                        Y += 15
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvConsulta.SelectedItems(0).SubItems(0).Text, 10) & StrDup(8, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(1).Text & " " & lvConsulta.SelectedItems(0).SubItems(2).Text & " " & lvConsulta.SelectedItems(0).SubItems(3).Text & StrDup(55, " "), 55) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(6).Text & StrDup(10, " "), 10) & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(0).SubItems(4).Text & StrDup(15, " "), 15) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(0).SubItems(5).Text & StrDup(10, " "), 10), FuenteE1, Pincel, 25, Y)
                        Y += 15

                        Dim dsCupo As New Data.DataSet
                        Dim Cadena As String
                        If lvConsulta.SelectedItems(0).SubItems(8).Text = "PROCEDIMIENTO" Then
                            dsCupo = objConsulta.BuscarCPT(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        ElseIf lvConsulta.SelectedItems(0).SubItems(8).Text = "INTERCONSULTA" Then
                            dsCupo = objInterconsulta.Buscar(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        ElseIf lvConsulta.SelectedItems(0).SubItems(8).Text = "INTERCONSULTAE" Then
                            dsCupo = objInterconsultaE.Buscar(lvConsulta.SelectedItems(0).SubItems(7).Text)
                        End If
                        '.DrawString(Microsoft.VisualBasic.Left("Talla: " & dsCupo.Tables(0).Rows(0)("Talla") & " cm" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Peso: " & dsCupo.Tables(0).Rows(0)("Peso") & " gr" & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Pulso: " & dsCupo.Tables(0).Rows(0)("Pulso") & " xMin" & StrDup(18, " "), 18) & Microsoft.VisualBasic.Left("Presion: " & dsCupo.Tables(0).Rows(0)("Presion") & StrDup(18, " "), 18) & " " & Microsoft.VisualBasic.Left("Temp: " & dsCupo.Tables(0).Rows(0)("Temp") & " ºC" & StrDup(18, " "), 18), FuenteE1, Pincel, 30, Y)
                        'Y += 20
                        '.DrawString("SINTOMAS Y SIGNOS: ", FuenteD2, Pincel, 25, Y)
                        'Y += 15
                        'Cadena = dsCupo.Tables(0).Rows(0)("Sintomas")
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbCrLf, " ")
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10

                        .DrawString("EVALUACION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        'Cadena = dsCupo.Tables(0).Rows(0)("Evaluacion")
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbCrLf, " ")
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        ''Y += 15
                        ''If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        ''.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        ''Y += 15
                        ''If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        ''.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10
                        .DrawString("DIAGNOSTICOS: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie1") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des1") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD1")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie2") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des2") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD2")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie3") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des3") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD3")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 20
                        .DrawString("TRATAMIENTO: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        'Cadena = dsCupo.Tables(0).Rows(0)("Tratamiento").ToString.Replace(Microsoft.VisualBasic.vbCrLf, " ")
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbCrLf, " ")
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 110 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)

                        'Y += 10
                        .DrawString("EVOLUCION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        'Cadena = dsCupo.Tables(0).Rows(0)("Evolucion")
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbCrLf, " ")
                        '.DrawString(Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Evolucion") & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        'Y += 15
                        'If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        '.DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 5
                        .DrawString("----------------------------------" & StrDup(40, " ") & Date.Now, FuenteE1, Pincel, 100, Y)
                        Y += 15
                        .DrawString("Dr(a). " & dsCupo.Tables(0).Rows(0)("Responsable"), FuenteE1, Pincel, 100, Y)
                    End If
                End If

                e.HasMorePages = False
            End With
        End If
    End Sub

    Private Sub btnImprimirHIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirHIS.Click
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem

        If lvMedico.SelectedItems.Count = 0 Then Exit Sub


        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Edad As String = ""
        Dim Años As String = ""
        Dim Meses As String = ""
        Dim Dias As String = ""

        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(lvMedico.SelectedItems(0).SubItems(0).Text)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(0)("DNI").ToString

        'Consultas Medicas
        dsTab = objConsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            
            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next


        'Consultas Interconsultas
        dsTab = objInterconsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'Interconsultas Emergencia
        dsTab = objInterconsultaE.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Años > 0 Then
                Edad = Años & " A"
            ElseIf Meses > 0 Then
                Edad = Meses & " M"
            ElseIf Dias > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next


        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next


        TotalFilasLV = lvDet.Items.Count - 1

        vImpresion = 2
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnHIS2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHIS2.Click
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem

        Dim Edad As String = ""
        Dim Años As String = ""
        Dim Meses As String = ""
        Dim Dias As String = ""

        If lvMedico.SelectedItems.Count = 0 Then Exit Sub

        Dim dsMedico As New Data.DataSet
        dsMedico = objMedico.Medico_BuscarId(lvMedico.SelectedItems(0).SubItems(0).Text)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(0)("DNI").ToString

        dsTab = objConsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        Dim I As Integer
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            'DNI Medico
            DNI = ""

            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente
            
            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If



            Fila.SubItems.Add(Edad)


            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'Consultas Interconsultas
        dsTab = objInterconsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'Interconsultas Emergencia
        dsTab = objInterconsultaE.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add("")
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento")) Else Fila.SubItems.Add("")
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString <> "" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        TotalFilasLV = lvDet.Items.Count - 1

        vImpresion = 3
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        btnMostrar_Click(sender, e)
    End Sub

    Private Sub cboTurno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTurno.Click
        cboTurno_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTurno.SelectedIndexChanged
        btnMostrar_Click(sender, e)
    End Sub

    Private Sub btnHIS3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHIS3.Click
        lvDet.Items.Clear()
        Dim dsTab As New Data.DataSet
        Dim Fila As ListViewItem

        If lvMedico.SelectedItems.Count = 0 Then Exit Sub


        Dim I As Integer
        Dim dsMedico As New Data.DataSet
        Dim Edad As String = ""
        Dim Años As String = ""
        Dim Meses As String = ""
        Dim Dias As String = ""

        'DNI Medico
        DNI = ""
        dsMedico = objMedico.Medico_BuscarId(lvMedico.SelectedItems(0).SubItems(0).Text)
        If dsMedico.Tables(0).Rows.Count > 0 Then DNI = dsMedico.Tables(0).Rows(0)("DNI").ToString

        'Consulta Medica
        dsTab = objConsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(1).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1

            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If



            Fila.SubItems.Add(Edad)


            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("¨Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'Consultas Interconsultas
        dsTab = objInterconsulta.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add("")
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'Interconsultas Emergencia
        dsTab = objInterconsultaE.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Val(Años) > 0 Then
                Edad = Años & " A"
            ElseIf Val(Meses) > 0 Then
                Edad = Meses & " M"
            ElseIf Val(Dias) > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            If dsTab.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1)) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab1").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add("")
            'If dsTab.Tables(0).Rows(I)("LNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab2").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            If dsTab.Tables(0).Rows(I)("Des3") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Lab3").ToString)
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Años > 0 Then
                Edad = Años & " A"
            ElseIf Meses > 0 Then
                Edad = Meses & " M"
            ElseIf Dias > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add("")
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        'PROCEDIMIENTOS
        dsTab = objConsultaCPT.GenerarHIS(lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(0).Text, lvMedico.Items(lvMedico.SelectedItems(0).Index).SubItems(2).Text, dtpFecha.Value.ToShortDateString)
        For I = 0 To dsTab.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(Microsoft.VisualBasic.Right("00" & dtpFecha.Value.Day, 2))

            'DNI Paciente
            If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "" Then
                If dsTab.Tables(0).Rows(I)("Doc_Identidad").ToString <> "0" Then Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Doc_Identidad")) Else Fila.SubItems.Add("")
            Else
                Fila.SubItems.Add("")
            End If
            'Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))

            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Ubigeo"))

            'Edad Paciente

            If dsTab.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) > 0 Then
                    If Microsoft.VisualBasic.Month(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Month Then
                        Años = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    Else
                        Años = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M"
                    End If
                Else
                    If Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) < Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")))
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento"))) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) > Date.Now.Day Then
                        Meses = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1
                        Dias = 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day)
                        Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNacimiento")) - Date.Now.Day) & " D"
                    ElseIf Microsoft.VisualBasic.Day(dsTab.Tables(0).Rows(I)("FNAcimiento")) = Date.Now.Day Then
                        Meses = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12
                        Dias = 0
                        Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsTab.Tables(0).Rows(I)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                    End If
                End If
            End If
            If Años > 0 Then
                Edad = Años & " A"
            ElseIf Meses > 0 Then
                Edad = Meses & " M"
            ElseIf Dias > 0 Then
                Edad = Dias & " D"
            End If

            Fila.SubItems.Add(Edad)

            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("Sexo"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngEstablecimiento"), 1))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("IngServicio"), 1))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des1"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TipoDiagnostico"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie1"))

            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("LNacimiento"))
            Dim TCupo As String = dsTab.Tables(0).Rows(I)("TipoCupo")
            If TCupo = "CONVENIO" Then
                TCupo = "10"
            ElseIf TCupo = "PROGRAMA" Then
                TCupo = "10"
            ElseIf TCupo = "SIS" Then
                TCupo = "02"
            ElseIf TCupo = "CREDITO" Then
                TCupo = "10"
            ElseIf TCupo = "SOAT" Then
                TCupo = "04"
            Else
                TCupo = "01"
            End If
            Fila.SubItems.Add(TCupo)

            Fila.SubItems.Add("1")

            'Segundo Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie2") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Historia"))
            If dsTab.Tables(0).Rows(I)("Procedencia").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Procedencia"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des2"))
            If dsTab.Tables(0).Rows(I)("Des2") = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD1"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie2"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If

            'Tercer Diagnostico
            'If dsTab.Tables(0).Rows(I)("Cie3") <> "" Then
            Fila = lvDet.Items.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Des3"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsTab.Tables(0).Rows(I)("TD2"), 1))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cie3"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            'End If
        Next

        TotalFilasLV = lvDet.Items.Count - 1

        vImpresion = 4
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub btnHIS4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHIS4.Click

    End Sub

    Private Sub lvConsulta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConsulta.DoubleClick
        vImpresion = 5
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub lvConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvConsulta.SelectedIndexChanged

    End Sub

    Private Sub ppdVistaPrevia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ppdVistaPrevia.Load

    End Sub
End Class