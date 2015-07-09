Public Class frmListaAtencionEmergencia
    Dim objDetalleSer As New clsEmergenciaSer
    Dim objTemporal As New clstempListaAtenLabEmer
    Dim objEmergencia As New clsEmergenciaIngreso
    Dim objConsulta As New clsEmergenciaIngreso_Consulta

    Dim Microbiologia As Boolean
    Dim Bioquimica As Boolean
    Dim Orina As Boolean
    Dim Inmunologia As Boolean
    Dim Heces As Boolean
    Dim Hematologia As Boolean
    Dim BancoSangre As Boolean

    Dim CadMicrobiologia As String = ""
    Dim CadBioquimica As String = ""
    Dim CadOrina As String = ""
    Dim CadInmunologia As String = ""
    Dim CadHeces As String = ""
    Dim CadHematologia As String = ""
    Dim CadBancoSangre As String = ""
    Dim CantP As Integer = 0

    Dim Historia As String = ""
    Dim Paciente As String = ""
    Dim Tipo As String = ""
    Dim LadoS As Boolean = False

    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente8 As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Dim TotalFilas As Integer
    Dim NroPag As Integer
    Dim NroFila As Integer

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmListaAtencionEmergencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        gbVer.Visible = False
    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim dsVer As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        objTemporal.Eliminar(My.Computer.Name)

        'Atenciones Canceladas
        dsVer = objDetalleSer.BuscarListaLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente").ToString, dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("ClasLaboratorio"), dsVer.Tables(0).Rows(I)("FechaRegistro").ToString, dsVer.Tables(0).Rows(I)("HoraRegistro").ToString)
        Next

        'Atenciones SOAT/AFOCAT
        dsVer = objDetalleSer.BuscarListaLabSOAT(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente"), dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("SubTipo"), dsVer.Tables(0).Rows(I)("FechaRegistro"), dsVer.Tables(0).Rows(I)("HoraRegistro"))
        Next

        'Atenciones Pendientes de Pago
        dsVer = objDetalleSer.BuscarListaLabPendiente(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente").ToString, dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("ClasLaboratorio"), dsVer.Tables(0).Rows(I)("FechaRegistro").ToString, dsVer.Tables(0).Rows(I)("HoraRegistro").ToString)
        Next

        'Mostrar Listado de Examenes
        dsVer = objTemporal.Buscar(My.Computer.Name)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
        Next
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvTabla.Items.Count - 1
        NroPag = 1
        NroFila = 0
        LadoS = False

        'Dim I As Integer
        'CantP = 0
        'For I = 0 To lvTabla.Items.Count - 1
        '    If I = 0 Then
        '        Microbiologia = False : Bioquimica = False : Orina = False : Inmunologia = False : Heces = False : Hematologia = False
        '        CadMicrobiologia = "" : CadBioquimica = "" : CadOrina = "" : CadInmunologia = "" : CadHeces = "" : CadHematologia = ""
        '        Historia = lvTabla.Items(I).SubItems(2).Text
        '        Paciente = lvTabla.Items(I).SubItems(3).Text
        '        Tipo = lvTabla.Items(I).SubItems(4).Text
        '    Else
        '        If Historia <> lvTabla.Items(I).SubItems(2).Text Then
        '            'ppdVistaPrevia.ShowDialog()
        '            CadMicrobiologia = "" : CadBioquimica = "" : CadOrina = "" : CadInmunologia = "" : CadHeces = "" : CadHematologia = ""
        '            Microbiologia = False : Bioquimica = False : Orina = False : Inmunologia = False : Heces = False : Hematologia = False
        '            Historia = lvTabla.Items(I).SubItems(2).Text
        '            Paciente = lvTabla.Items(I).SubItems(3).Text
        '            Tipo = lvTabla.Items(I).SubItems(4).Text
        '            CantP = 0
        '        End If
        '    End If

        '    Select Case lvTabla.Items(I).SubItems(7).Text
        '        Case "MICROBIOLOGIA CULTIVO"
        '            Microbiologia = True
        '            If CadMicrobiologia = "" Then
        '                CadMicrobiologia = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadMicrobiologia = CadMicrobiologia & vbNewLine & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '        Case "BIOQUIMICA"
        '            Bioquimica = True
        '            If CadBioquimica = "" Then
        '                CadBioquimica = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadBioquimica = CadBioquimica & vbNewLine & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '        Case "ORINA"
        '            Orina = True
        '            If CadOrina = "" Then
        '                CadOrina = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadOrina = CadOrina & ", " & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '        Case "INMUNOLOGIA"
        '            Inmunologia = True
        '            If CadInmunologia = "" Then
        '                CadInmunologia = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadInmunologia = CadInmunologia & vbNewLine & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '        Case "HECES"
        '            Heces = True
        '            If CadHeces = "" Then
        '                CadHeces = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadHeces = CadHeces & ", " & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '        Case "HEMATOLOGIA"
        '            Hematologia = True
        '            If CadHematologia = "" Then
        '                CadHematologia = lvTabla.Items(I).SubItems(5).Text
        '            Else
        '                CadHematologia = CadHematologia & vbNewLine & lvTabla.Items(I).SubItems(5).Text
        '            End If
        '    End Select
        'Next
    End Sub

    Private Sub Cabecera(e As System.Drawing.Printing.PrintPageEventArgs, Tipo As String)
        Dim dsEmergencia As New DataSet
        Dim dsConsulta As New DataSet
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL" & StrDup(40, " ") & "DEPARTAMENTO DE LABORATORIO", Fuente10, Pincel, 40, Y)
            Y = Y + 15
            .DrawString("DOCENTE - TRUJILLO", Fuente10, Pincel, 40, Y)
            .DrawString("Pag. " & NroPag & " " & UsuarioSistema, Fuente8, Pincel, 700, Y)
            Y = Y + 20
            .DrawString("Fec: " & Date.Now.ToShortDateString, Fuente8, Pincel, 700, Y)
            Y = Y + 20
            .DrawString("LABORATORIO CLINICO EMERGENCIA - " & Tipo, Fuente12N, Pincel, 140, Y)
            .DrawString("Hor: " & Date.Now.ToShortTimeString, Fuente8, Pincel, 700, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 140, Y, 630, Y)
            Y = Y + 10

            'Buscar Datos de Emergencia
            dsEmergencia = objEmergencia.VerificarLab(Historia)
            dsConsulta = objConsulta.ConsultaBuscar(dsEmergencia.Tables(0).Rows(0)("IdIngreso"))

            .DrawString("Paciente   :   ", Fuente10, Pincel, 20, Y)
            .DrawString(Microsoft.VisualBasic.Left(Paciente & StrDup(40, "*"), 40), Fuente12N, Pincel, 120, Y)
            .DrawString("Historia : ", Fuente10, Pincel, 560, Y)
            .DrawString(Historia, Fuente20N, Pincel, 670, Y)
            Y = Y + 15
            .DrawString("Edad       :   ", Fuente10, Pincel, 20, Y)
            .DrawString(dsEmergencia.Tables(0).Rows(0)("Edad") & dsEmergencia.Tables(0).Rows(0)("TipoEdad"), Fuente12N, Pincel, 120, Y)
            .DrawString("Sexo : ", Fuente10, Pincel, 300, Y)
            .DrawString(dsEmergencia.Tables(0).Rows(0)("Sexo").ToString, Fuente12N, Pincel, 360, Y)
            .DrawString("Tipo  : ", Fuente10, Pincel, 400, Y)
            .DrawString(Microsoft.VisualBasic.Left(dsEmergencia.Tables(0).Rows(0)("TipoAtencion") & StrDup(20, " "), 20), Fuente12N, Pincel, 460, Y)
            Y = Y + 15
            .DrawString("Servicio   :   ", Fuente10, Pincel, 20, Y)
            .DrawString(dsEmergencia.Tables(0).Rows(0)("Especialidad"), Fuente12N, Pincel, 120, Y)
            .DrawString("Cama : ", Fuente10, Pincel, 300, Y)
            If dsConsulta.Tables(0).Rows.Count > 0 Then
                .DrawString(dsConsulta.Tables(0).Rows(0)("Cama").ToString, Fuente12N, Pincel, 360, Y)
            Else
                .DrawString("", Fuente12N, Pincel, 360, Y)
            End If
            .DrawString("Medico: ", Fuente10, Pincel, 400, Y)
            .DrawString(dsEmergencia.Tables(0).Rows(0)("Medico"), Fuente12N, Pincel, 460, Y)
            Y = Y + 15
            .DrawString("Diagnostico: ", Fuente10, Pincel, 20, Y)
            If dsConsulta.Tables(0).Rows.Count > 0 Then
                .DrawString(dsConsulta.Tables(0).Rows(0)("CIE1") & ", " & dsConsulta.Tables(0).Rows(0)("CIE2") & ", " & dsConsulta.Tables(0).Rows(0)("CIE3") & ", " & dsConsulta.Tables(0).Rows(0)("CIE4") & ", " & dsConsulta.Tables(0).Rows(0)("CIE5") & ", " & dsConsulta.Tables(0).Rows(0)("CIE6"), Fuente12N, Pincel, 120, Y)
            Else
                .DrawString("", Fuente12N, Pincel, 120, Y)
            End If
            Y = Y + 10
            .DrawString(StrDup(90, "="), Fuente10, Pincel, 20, Y)
            Y = Y + 20
        End With
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        Filas = 10
        With e.Graphics
            Do While TotalFilas >= 0
                If NroFila = 0 Then
                    Microbiologia = False : Bioquimica = False : Orina = False : Inmunologia = False : Heces = False : Hematologia = False : BancoSangre = False
                    CadMicrobiologia = "" : CadBioquimica = "" : CadOrina = "" : CadInmunologia = "" : CadHeces = "" : CadHematologia = "" : CadBancoSangre = ""
                    Historia = lvTabla.Items(NroFila).SubItems(2).Text
                    Paciente = lvTabla.Items(NroFila).SubItems(3).Text
                    Tipo = lvTabla.Items(NroFila).SubItems(4).Text
                Else
                    If Historia <> lvTabla.Items(NroFila).SubItems(2).Text Then

                       

                        If Microbiologia Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "MICROBIOLOGIA")
                            Y = Y + 10
                            .DrawString(CadMicrobiologia, Fuente10, Pincel, 40, Y)

                            Microbiologia = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If Bioquimica Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "BIOQUIMICA")
                            Y = Y + 10
                            .DrawString(CadBioquimica, Fuente10, Pincel, 40, Y)

                            Bioquimica = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If Orina Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "ORINA")
                            Y = Y + 10
                            .DrawString(CadOrina, Fuente10, Pincel, 40, Y)

                            Orina = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If Inmunologia Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "INMUNOLOGIA")
                            Y = Y + 10
                            .DrawString(CadInmunologia, Fuente10, Pincel, 40, Y)

                            Inmunologia = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If Heces Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "HECES")
                            Y = Y + 10
                            .DrawString(CadHeces, Fuente10, Pincel, 40, Y)

                            Heces = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If Hematologia Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "HEMATOLOGIA")
                            Y = Y + 10
                            .DrawString(CadHematologia, Fuente10, Pincel, 40, Y)

                            Hematologia = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        If BancoSangre Then
                            Y = 20
                            If LadoS Then Y = 580
                            Cabecera(e, "BANCO DE SANGRE")
                            Y = Y + 10
                            .DrawString(CadBancoSangre, Fuente10, Pincel, 40, Y)

                            BancoSangre = False
                            If LadoS Then
                                e.HasMorePages = True
                                NroPag += 1
                                LadoS = False
                                Exit Sub
                            Else
                                LadoS = True
                            End If
                        End If

                        Historia = lvTabla.Items(NroFila).SubItems(2).Text
                        Paciente = lvTabla.Items(NroFila).SubItems(3).Text
                        Tipo = lvTabla.Items(NroFila).SubItems(4).Text

                        CadMicrobiologia = "" : CadBioquimica = "" : CadOrina = "" : CadInmunologia = "" : CadHeces = "" : CadHematologia = "" : CadBancoSangre = ""
                        Microbiologia = False : Bioquimica = False : Orina = False : Inmunologia = False : Heces = False : Hematologia = False : BancoSangre = False

                    End If
                End If

                Select Case lvTabla.Items(NroFila).SubItems(7).Text
                    Case "MICROBIOLOGIA"
                        Microbiologia = True
                        If CadMicrobiologia = "" Then
                            CadMicrobiologia = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadMicrobiologia = CadMicrobiologia & vbNewLine & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "BIOQUIMICA"
                        Bioquimica = True
                        If CadBioquimica = "" Then
                            CadBioquimica = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadBioquimica = CadBioquimica & vbNewLine & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "ORINA"
                        Orina = True
                        If CadOrina = "" Then
                            CadOrina = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadOrina = CadOrina & ", " & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "INMUNOLOGIA"
                        Inmunologia = True
                        If CadInmunologia = "" Then
                            CadInmunologia = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadInmunologia = CadInmunologia & vbNewLine & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "HECES"
                        Heces = True
                        If CadHeces = "" Then
                            CadHeces = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadHeces = CadHeces & ", " & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "HEMATOLOGIA"
                        Hematologia = True
                        If CadHematologia = "" Then
                            CadHematologia = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadHematologia = CadHematologia & vbNewLine & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                    Case "BANCO DE SANGRE"
                        BancoSangre = True
                        If CadBancoSangre = "" Then
                            CadBancoSangre = lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        Else
                            CadBancoSangre = CadBancoSangre & vbNewLine & lvTabla.Items(NroFila).SubItems(5).Text & " " & lvTabla.Items(NroFila).SubItems(8).Text & "|" & lvTabla.Items(NroFila).SubItems(9).Text
                        End If
                End Select
                TotalFilas = TotalFilas - 1
                NroFila = NroFila + 1
            Loop
            If Microbiologia Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "MICROBIOLOGIA")
                Y = Y + 10
                .DrawString(CadMicrobiologia, Fuente10, Pincel, 40, Y)

                Microbiologia = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If Bioquimica Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "BIOQUIMICA")
                Y = Y + 10
                .DrawString(CadBioquimica, Fuente10, Pincel, 40, Y)

                Bioquimica = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If Orina Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "ORINA")
                Y = Y + 10
                .DrawString(CadOrina, Fuente10, Pincel, 40, Y)

                Orina = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If Inmunologia Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "INMUNOLOGIA")
                Y = Y + 10
                .DrawString(CadInmunologia, Fuente10, Pincel, 40, Y)

                Inmunologia = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If Heces Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "HECES")
                Y = Y + 10
                .DrawString(CadHeces, Fuente10, Pincel, 40, Y)

                Heces = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If Hematologia Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "HEMATOLOGIA")
                Y = Y + 10
                .DrawString(CadHematologia, Fuente10, Pincel, 40, Y)

                Hematologia = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If BancoSangre Then
                Y = 20
                If LadoS Then Y = 580
                Cabecera(e, "BANCO DE SANGRE")
                Y = Y + 10
                .DrawString(CadBancoSangre, Fuente10, Pincel, 40, Y)

                BancoSangre = False
                If LadoS Then
                    e.HasMorePages = True
                    NroPag += 1
                    LadoS = False
                    Exit Sub
                Else
                    LadoS = True
                End If
            End If

            If TotalFilas < 0 Then e.HasMorePages = False
        End With
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim I As Integer
        ppdVistaPrevia.ShowDialog()
        If MessageBox.Show("Desea Marcar como Muestras ya Listadas?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            For I = 0 To lvTabla.Items.Count - 1
                objDetalleSer.ConfirmarListado(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString)
            Next
            btnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Desea Omitir de la Lista Temporalmente el Proceso de Muestra de Pacientes?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            End If
        End If
    End Sub

    'Dim Filas As Integer = 0
    'Dim Aux As String
    '    Filas = 10
    '    With e.Graphics
    ''Hematologia = False
    '        If Microbiologia Then
    '            Y = 20
    '            Cabecera(e, "MICROBIOLOGIA")
    '            .DrawString("ASPECTO    : _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("GRAM       : _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CULTIVO    : _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("M.S.       : _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("R.         : _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PROCEDENCIA: _______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            If CadMicrobiologia.Length <= 90 Then
    '                .DrawString(CadMicrobiologia, Fuente10, Pincel, 40, Y)
    '            Else
    ''Aux = 
    '                .DrawString(CadMicrobiologia, Fuente10, Pincel, 40, Y)
    '            End If
    '            LadoS = True
    '            Microbiologia = False
    '        End If

    '        If Bioquimica Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "BIOQUIMICA")
    '            .DrawString("GUI     :_____" & "BILIRR.T. :_____" & "F.ALC.    :_____" & "COLEST :___", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("UREA    :_____" & "BILIRR.D. :_____" & "F.ACT.T.  :_____" & "LIP.T  :___", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CREA    :_____" & "BILIRR.Y  :_____" & "AC.PROS.  :_____" & "TRIGL. :___", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("A.URICO :_____" & "PROT.T.   :_____" & "L.H.      :_____" & "HOL.COL:___", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CALCIO  :_____" & "ALB.      :_____" & "LL.       :_____" & "LDB.COL:___", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("FOSFORO :_____" & "GLOB.     :_____" & "HIERRO    :_____", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("SODIO   :_____" & "OPT       :_____" & "AMILASA   :_____", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("GOT.    :_________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            If CadBioquimica.Length > 90 Then
    '                .DrawString(CadBioquimica, Fuente10, Pincel, 40, Y)
    '            Else

    '            End If

    '            Bioquimica = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '            Else
    '                LadoS = True
    '            End If
    '        End If

    '        If Orina Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "ORINA")
    '            .DrawString("DENSIDAD  :__________________" & "SEDIMENTACION  :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("P.H.      :__________________" & "C.EPITELIALES  :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CARB.     :__________________" & "LEUCOCITOS     :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PROTEINAS :__________________" & "HEMATIES       :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("SALES B.  :__________________" & "CRISTALES      :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("UROBILINA :__________________" & "CILINDROS      :___________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            .DrawString(CadOrina, Fuente10, Pincel, 40, Y)

    '            Orina = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '            Else
    '                LadoS = True
    '            End If
    '        End If

    '        If Inmunologia Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "INMUNOLOGIA")
    '            .DrawString("V.D.R.L          :___________________" & "BRUCELLA       :_________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("AGLUTINACIONES   : H_________________" & "PARATIFICO    A:_________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("                   O_________________" & "              B:_________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("LATEX            :___________________" & "PROTEINA C. REACTIVA :___________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("ANTIESTREPTOCINA :_________________________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("ANTIGENO B. SUPERFICIE :______________" & "HIV            :________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PREGNOSTICON     :____________________" & "ANTC. ANTINUCL.:________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("TOXOPLASMA       :_______________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Procedencia :____________________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            .DrawString(CadInmunologia, Fuente10, Pincel, 40, Y)

    '            Inmunologia = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '                Exit Sub
    '            Else
    '                LadoS = True
    '            End If
    '        End If

    '        If Heces Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "HECES")
    '            .DrawString("EXAMEN MACROSCOPICO                        " & "EXAMEN MICROSCOPICO", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("COLOR               : _____________________" & "EXAMEN DIRECTO:_______________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CONSISTENCIA        : _____________________" & "_______________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PRESENCIA DE MOCO   : _____________________" & "SEDIMENTACION DE BAEMANN :_____________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PRESENCIA DE SANGRE : _____________________" & "_______________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("RESTOS VEGETALES    : _____________________" & "COLORACION DE KINYOUN :________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            .DrawString(CadHeces, Fuente10, Pincel, 40, Y)

    '            Heces = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '                Exit Sub
    '            Else
    '                LadoS = True
    '            End If
    '        End If


    '        If Hematologia Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "HEMATOLOGIA")
    '            .DrawString("HB  :______" & "HTO  :____" & "RET  :_____" & "I.R.  :_____", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("LUC.:______" & "AB.  :____" & "SG   :_____" & "EO :____" & "B  :____" & "M :___" & "L  :____", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("VSG.:___________" & "GS.yRH :_____" & "PLAQ. :________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("OBJ. DE LAM :_____________________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("__________________________________________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            .DrawString(CadHematologia, Fuente10, Pincel, 40, Y)

    '            Hematologia = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '                Exit Sub
    '            Else
    '                LadoS = True
    '            End If
    '        End If

    '        If Parasitos Then
    '            Y = 20
    '            If LadoS Then Y = 500
    '            Cabecera(e, "HECES")
    '            .DrawString("EXAMEN MACROSCOPICO                        " & "EXAMEN MICROSCOPICO", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("COLOR               : _____________________" & "EXAMEN DIRECTO:_______________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("CONSISTENCIA        : _____________________" & "_______________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PRESENCIA DE MOCO   : _____________________" & "SEDIMENTACION DE BAEMANN :_____________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("PRESENCIA DE SANGRE : _____________________" & "_______________________________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("RESTOS VEGETALES    : _____________________" & "COLORACION DE KINYOUN :________________", Fuente12N, Pincel, 40, Y)
    '            Y = Y + 20
    '            .DrawString("Exámenes Solicitados:", Fuente10, Pincel, 40, Y)
    '            Y = Y + 15
    '            .DrawString(CadHeces, Fuente10, Pincel, 40, Y)
    '            CantP = CantP - 1
    '            If CantP = 0 Then Parasitos = False : e.HasMorePages = False
    '            If LadoS Then
    '                e.HasMorePages = True
    '                NroPag += 1
    '                LadoS = False
    '                Exit Sub
    '            Else
    '                LadoS = True
    '            End If
    '        Else
    '            e.HasMorePages = False
    '        End If
    '    End With

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        gbVer.Visible = False
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub Tiempo_Tick(sender As System.Object, e As System.EventArgs) Handles Tiempo.Tick
        If gbVer.Visible = False Then
            Dim dsVer As New DataSet
            Dim I As Integer
            objTemporal.Eliminar(My.Computer.Name)

            'Atenciones Canceladas
            dsVer = objDetalleSer.BuscarListaLab(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente").ToString, dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("ClasLaboratorio"), dsVer.Tables(0).Rows(I)("FechaRegistro").ToString, dsVer.Tables(0).Rows(I)("HoraRegistro").ToString)
            Next

            'Atenciones SOAT/AFOCAT
            dsVer = objDetalleSer.BuscarListaLabSOAT(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente").ToString, dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("SubTipo"), dsVer.Tables(0).Rows(I)("FechaRegistro"), dsVer.Tables(0).Rows(I)("HoraRegistro"))
            Next

            'Atenciones Pendientes de Pago
            dsVer = objDetalleSer.BuscarListaLabPendiente(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                objTemporal.GrabarFecha(dsVer.Tables(0).Rows(I)("IdEmerSer"), dsVer.Tables(0).Rows(I)("Especialidad"), dsVer.Tables(0).Rows(I)("Historia"), dsVer.Tables(0).Rows(I)("Paciente").ToString, dsVer.Tables(0).Rows(I)("TipoAtencion"), dsVer.Tables(0).Rows(I)("Descripcion"), dsVer.Tables(0).Rows(I)("Cantidad"), My.Computer.Name, dsVer.Tables(0).Rows(I)("ClasLaboratorio"), dsVer.Tables(0).Rows(I)("FechaRegistro").ToString, dsVer.Tables(0).Rows(I)("HoraRegistro").ToString)
            Next
            'Mostrar Listado de Examenes
            dsVer = objTemporal.Buscar(My.Computer.Name)
            If dsVer.Tables(0).Rows.Count <> lvTabla.Items.Count Then gbVer.Visible = True : lblFecha.Text = Date.Now.ToShortDateString & " " & Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class