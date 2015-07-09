Public Class frmSolicitud
    Dim objHospitalizacion As New clsHospitalizacion
    Dim objIngresoHosp As New clsIngresoHospitalizacion
    Dim objHistoria As New clsHistoria
    Dim objDetHosp As New clsDetalleHospitalizacion
    Dim objIngresoCIE As New clsIngresoCIE

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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsVer As New DataSet

        'Buscar Examenes en Piso
        dsVer = objDetHosp.BuscarSolicitud(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, txtFiltro.Text, "LABORATORIO", "")
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdDetalle"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegAten"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegAten"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecCan").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HorCan").ToString)
        Next

        MessageBox.Show("Resultado de Búsqueda a la Fecha", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim I As Integer
        ppdVistaPrevia.ShowDialog()
        If MessageBox.Show("Desea Marcar como Muestras ya Listadas?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            For I = 0 To lvTabla.Items.Count - 1
                objDetHosp.TomaMuestra(lvTabla.Items(I).SubItems(0).Text, Date.Now.ToShortDateString, Format(Date.Now, "HH:MM"), UsuarioSistema, My.Computer.Name)
            Next
            btnBuscar_Click(sender, e)
        End If
    End Sub

    Public Function CalcularEdad(ByVal FechaActual As Date, ByVal FechaNacimiento As Date) As String
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        Años = DateDiff("yyyy", dinicio, dfin)

        If Meses = 0 And Años = 0 Then
            EdadA = 0
            EdadM = 0
            Dias = Math.Abs(Dias)
            EdadD = Dias
        Else
            'Verificar Dias
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

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
        CalcularEdad = EdadA & "A " & EdadM & "M " & EdadD & "D"
    End Function

    Private Sub Cabecera(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Tipo As String)
        Dim dsHospitalizacion As New DataSet
        Dim dsIngreso As New DataSet
        Dim dsHistoria As New DataSet
        Dim dsIngresoCIE As New DataSet
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL" & StrDup(40, " ") & "DEPARTAMENTO DE LABORATORIO", Fuente10, Pincel, 40, Y)
            Y = Y + 15
            .DrawString("DOCENTE - TRUJILLO", Fuente10, Pincel, 40, Y)
            .DrawString("Pag. " & NroPag & " " & UsuarioSistema, Fuente8, Pincel, 700, Y)
            Y = Y + 20
            .DrawString("Fec: " & Date.Now.ToShortDateString, Fuente8, Pincel, 700, Y)
            Y = Y + 20
            .DrawString("LABORATORIO CLINICO HOSPITALIZACION - " & Tipo, Fuente12N, Pincel, 130, Y)
            .DrawString("Hor: " & Date.Now.ToShortTimeString, Fuente8, Pincel, 700, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 120, Y, 650, Y)
            Y = Y + 10

            'Buscar Datos de Emergencia
            dsHistoria = objHistoria.Buscar(Historia)
            dsHospitalizacion = objHospitalizacion.VerificarHospitalizacion(Historia)
            dsIngreso = objIngresoHosp.Buscar(dsHospitalizacion.Tables(0).Rows(0)("IdHospitalizacion"))
            dsIngresoCIE = objIngresoCIE.Buscar(dsIngreso.Tables(0).Rows(0)("IdIngreso"))

            .DrawString("Paciente    :   ", Fuente10, Pincel, 20, Y)
            .DrawString(Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres") & StrDup(40, "*"), 40), Fuente12N, Pincel, 130, Y)
            .DrawString("Historia : ", Fuente10, Pincel, 560, Y)
            .DrawString(Historia, Fuente20N, Pincel, 670, Y)
            Y = Y + 15

            .DrawString("Edad        :   ", Fuente10, Pincel, 20, Y)
            .DrawString(CalcularEdad(Date.Now, dsHistoria.Tables(0).Rows(0)("FNacimiento")), Fuente12N, Pincel, 130, Y)
            .DrawString("Sexo : ", Fuente10, Pincel, 240, Y)
            .DrawString(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, Fuente12N, Pincel, 300, Y)
            .DrawString("Tipo  : ", Fuente10, Pincel, 400, Y)
            .DrawString(Microsoft.VisualBasic.Left(dsIngreso.Tables(0).Rows(0)("TipoPaciente") & StrDup(20, " "), 20), Fuente12N, Pincel, 460, Y)
            Y = Y + 15
            .DrawString("Especialidad:   ", Fuente10, Pincel, 20, Y)
            .DrawString(dsIngreso.Tables(0).Rows(0)("Especialidad"), Fuente12N, Pincel, 130, Y)
            .DrawString("Cama  : ", Fuente10, Pincel, 400, Y)
            .DrawString(dsIngreso.Tables(0).Rows(0)("Numero").ToString, Fuente12N, Pincel, 460, Y)
            Y = Y + 15
            .DrawString("Medico: ", Fuente10, Pincel, 20, Y)
            .DrawString(dsIngreso.Tables(0).Rows(0)("Responsable"), Fuente12N, Pincel, 130, Y)
            .DrawString("Diagnostico: ", Fuente10, Pincel, 400, Y)
            If dsIngresoCIE.Tables(0).Rows.Count > 0 Then
                Dim K As Integer
                Dim DesCIE As String = ""
                For K = 0 To dsIngresoCIE.Tables(0).Rows.Count - 1
                    If K = 0 Then
                        DesCIE = dsIngresoCIE.Tables(0).Rows(K)("CIE")
                    Else
                        DesCIE = DesCIE & ", " & dsIngresoCIE.Tables(0).Rows(K)("CIE")
                    End If
                Next
                .DrawString(DesCIE, Fuente12N, Pincel, 510, Y)
            Else
                .DrawString("*****", Fuente12N, Pincel, 510, Y)
            End If
            Y = Y + 10
            .DrawString(StrDup(90, "="), Fuente10, Pincel, 20, Y)
            Y = Y + 20
        End With
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvTabla.Items.Count - 1
        NroPag = 1
        NroFila = 0
        LadoS = False
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
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

    Private Sub dtpF1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then txtFiltro.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Desea Omitir de la Lista Temporalmente el Proceso de Muestra de Pacientes?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
            End If
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub
End Class