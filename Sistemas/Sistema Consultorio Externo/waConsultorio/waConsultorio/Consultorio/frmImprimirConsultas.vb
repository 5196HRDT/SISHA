Public Class frmImprimirConsultas
    Dim objProgramacion As New Programacion
    Dim objCupo As New Cupo
    Dim objConsulta As New Consulta
    Dim objConsultaCPT As New ConsultaCPT
    Dim objInterconsulta As New InterconsultaH
    Dim objInterconsultaE As New InterconsultaE
    Dim objMedico As New Medico

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

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmImprimirConsultas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lvConsulta.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim Edad As String
        Dim EdadA, EdadM, EdadD As String
        Dim dsConsulta As New Data.DataSet

        lblMedico.Text = NomMedico
        lblEspecialidad.Text = EspecialidadMedica

        'Consultas
        dsConsulta = objCupo.Cupos_BuscarAtencionAtendida(vFechaCita, vTurnoCita, CodMedico)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("NHistoria"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Paterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Materno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))
            EdadA = 0 : Edad = "0"
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = vFechaCita
                dinicio = dsConsulta.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
                'Verificar Dias
                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If

            Fila.SubItems.Add(Edad)
            If dsConsulta.Tables(0).Rows(I)("Sexo").ToString <> "" Then Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3)) Else Fila.SubItems.Add("")
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdCupo"))
            Fila.SubItems.Add("CONSULTA")
        Next

        'Interconsultas
        dsConsulta = objInterconsulta.BuscarAtencionAtendida(vFechaCita, vTurnoCita, CodMedico)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

            EdadA = 0 : Edad = "0"
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = vFechaCita
                dinicio = dsConsulta.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
                'Verificar Dias
                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If

            Fila.SubItems.Add(Edad)
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdInterconsultaH"))
            Fila.SubItems.Add("INTERCONSULTA")
        Next

        'Interconsultas Emergencia
        dsConsulta = objInterconsultaE.BuscarAtencionAtendida(vFechaCita, vTurnoCita, CodMedico)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

            EdadA = 0 : Edad = "0"
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = vFechaCita
                dinicio = dsConsulta.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
                'Verificar Dias
                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If

            Fila.SubItems.Add(Edad)
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdInterconsultae"))
            Fila.SubItems.Add("INTERCONSULTAE")
        Next

        'Procedimientos
        dsConsulta = objConsultaCPT.BuscarAtencionAtendida(vFechaCita, vTurnoCita, CodMedico)
        For I = 0 To dsConsulta.Tables(0).Rows.Count - 1
            Fila = lvConsulta.Items.Add(dsConsulta.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("APaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("AMaterno"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("Nombres"))

            EdadA = 0 : Edad = "0"
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                dfin = vFechaCita
                dinicio = dsConsulta.Tables(0).Rows(I)("FNacimiento")
                Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
                Meses = DatePart("m", dfin) - DatePart("m", dinicio)
                Años = DateDiff("yyyy", dinicio, dfin)
                'Verificar Dias
                If Meses = 0 And Años = 0 Then
                    EdadA = 0
                    EdadM = 0
                    Dias = Math.Abs(Dias)
                    EdadD = Dias
                Else
                    If Dias < 0 Then
                        DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                        Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                        Meses = Meses - 1
                    End If
                    If Meses < 0 Then
                        Meses = 12 + Meses
                        Años = Años - 1
                    End If
                    EdadA = Años
                    EdadM = Meses
                    EdadD = Dias
                    If Val(EdadA) > 0 Then
                        Edad = EdadA & "A " & EdadM & "M"
                    Else
                        Edad = EdadM & "M " & EdadD & "D"
                    End If
                End If

                If Val(EdadA) > 0 Then
                    Edad = EdadA & "A " & EdadM & "M"
                Else
                    Edad = EdadM & "M " & EdadD & "D"
                End If
            End If

            Fila.SubItems.Add(Edad)
            Fila.SubItems.Add(Microsoft.VisualBasic.Left(dsConsulta.Tables(0).Rows(I)("Sexo"), 3))
            If dsConsulta.Tables(0).Rows(I)("FNacimiento").ToString = "" Then Fila.SubItems.Add("") Else Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("FNacimiento"))
            Fila.SubItems.Add(dsConsulta.Tables(0).Rows(I)("IdProcedimiento"))
            Fila.SubItems.Add("PROCEDIMIENTO")
        Next
    End Sub

    Private Sub lvConsulta_DoubleClick(sender As Object, e As System.EventArgs) Handles lvConsulta.DoubleClick
        vImpresion = 2
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        If vImpresion = 1 Then
            NroFilasTotales = 0
            TotalFilasLV = lvConsulta.Items.Count - 1
            NroConsultas = 0
            Y = 20
        ElseIf vImpresion = 2 Then
            NroFilasTotales = 63
            TotalFilasLV = lvConsulta.Items.Count - 1
            NroConsultas = 0
            Y = 20
        End If
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
            .DrawString("Fecha: " & vFechaCita & " Turno: " & vTurnoCita, FuenteD2, Pincel, 550, Y)
            Y = Y + 10
            .DrawLine(Pens.Black, 200, Y, 400, Y)
            Y = Y + 15
            .DrawString("Historia" & StrDup(15, " ") & "Paciente" & StrDup(32, " ") & "FechaNac" & StrDup(6, " ") & "Edad" & StrDup(8, " ") & "Sexo", FuenteD2, Pincel, 40, Y)
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
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
                            Encabezado(e, lblMedico.Text, lblEspecialidad.Text)
                        Else
                            Y = 580
                            .DrawString(StrDup(90, "-"), FuenteD1, Pincel, 5, Y)
                            Y += 20
                            Encabezado(e, lblMedico.Text, lblEspecialidad.Text)
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
                        If dsCupo.Tables(0).Rows(0)("Sintomas") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Sintomas"), vbLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(210, " "), 210), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 210 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 210) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 210 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 210) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 210 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 210) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 210 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 210) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 210 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 210) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10

                        .DrawString("EVALUACION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evaluacion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evaluacion"), vbLf, " ") Else Cadena = "**************"
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
                        Y += 10
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie1") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des1") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TipoDiagnostico")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie2") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des2") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD1")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        Cadena = Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Cie3") & StrDup(7, " "), 7) & " " & Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Des3") & StrDup(80, " "), 80) & " " & dsCupo.Tables(0).Rows(0)("TD3")
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 15
                        .DrawString("TRATAMIENTO: ", FuenteD2, Pincel, 25, Y)
                        Y += 10
                        If dsCupo.Tables(0).Rows(0)("Tratamiento") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Tratamiento"), vbLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 110 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena & StrDup(110, " "), 110), FuenteE1, Pincel, 25, Y)

                        Y += 10
                        .DrawString("EVOLUCION: ", FuenteD2, Pincel, 25, Y)
                        Y += 10
                        If dsCupo.Tables(0).Rows(0)("Evolucion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evolucion"), vbLf, " ") Else Cadena = "**************"
                        .DrawString(Microsoft.VisualBasic.Left(dsCupo.Tables(0).Rows(0)("Evolucion") & StrDup(100, " "), 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 10
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
        End If
        If vImpresion = 2 Then
            Filas = 10
            NroFilasHoja = 0
            Y = Y + 10
            With e.Graphics
                If TotalFilasLV >= 0 Then
                    If lvConsulta.SelectedItems(0).SubItems(8).Text <> "PROCEDIMIENTO" Then
                        NroConsultas += 1
                        Y = 20
                        Encabezado(e, lblMedico.Text, lblEspecialidad.Text)

                        Y += 15
                        .DrawString(Microsoft.VisualBasic.Right(StrDup(10, " ") & lvConsulta.SelectedItems(0).SubItems(0).Text, 10) & StrDup(8, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(1).Text & " " & lvConsulta.SelectedItems(0).SubItems(2).Text & " " & lvConsulta.SelectedItems(0).SubItems(3).Text & StrDup(55, " "), 55) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.SelectedItems(0).SubItems(6).Text & StrDup(10, " "), 10) & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(0).SubItems(4).Text & StrDup(15, " "), 15) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvConsulta.Items(0).SubItems(5).Text & StrDup(10, " "), 10), FuenteE1, Pincel, 25, Y)
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
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)
                        Y += 15
                        If Cadena.Length > 100 Then Cadena = Microsoft.VisualBasic.Mid(Cadena, 110) Else Cadena = ""
                        .DrawString(Microsoft.VisualBasic.Left(Cadena, 110), FuenteE1, Pincel, 25, Y)

                        Y += 10

                        .DrawString("EVALUACION: ", FuenteD2, Pincel, 25, Y)
                        Y += 15
                        If dsCupo.Tables(0).Rows(0)("Evaluacion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evaluacion"), vbLf, " ") Else Cadena = "**************"
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
                        If dsCupo.Tables(0).Rows(0)("Tratamiento") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Tratamiento"), vbLf, " ") Else Cadena = "**************"
                        Cadena = Cadena.Replace(Microsoft.VisualBasic.vbLf, " ")
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
                        If dsCupo.Tables(0).Rows(0)("Evolucion") <> "" Then Cadena = Replace(dsCupo.Tables(0).Rows(0)("Evolucion"), vbLf, " ") Else Cadena = "**************"
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

                    If lvConsulta.SelectedItems(0).SubItems(8).Text = "PROCEDIMIENTO" Then
                        NroConsultas += 1
                        Y = 20
                        Encabezado(e, lblMedico.Text, lblEspecialidad.Text)

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
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbLf, " ")
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
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbLf, " ")
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
                        'Cadena = dsCupo.Tables(0).Rows(0)("Tratamiento").ToString.Replace(Microsoft.VisualBasic.vbLf, " ")
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbLf, " ")
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
                        'Cadena = Cadena.Replace(Microsoft.VisualBasic.vbLf, " ")
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

    Private Sub btnImprimirT_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimirT.Click
        vImpresion = 1
        ppdVistaPrevia.ShowDialog()
    End Sub

    Private Sub lvConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvConsulta.SelectedIndexChanged

    End Sub
End Class