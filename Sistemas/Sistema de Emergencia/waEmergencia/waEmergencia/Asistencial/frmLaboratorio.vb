Imports ThoughtWorks.QRCode
Imports ThoughtWorks.QRCode.Codec
Imports ThoughtWorks.QRCode.Codec.Data

Public Class frmLaboratorio
    Dim objHistoria As New clsHistoria
    Dim objDetalleSer As New clsDetalleLaboratorioEmer
    Dim objItemServicio As New clsItemServicio
    Dim objServicioItem As New clsServicioItem

    'Variables Impresion
    Dim Fuente14N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente8 As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer
    Dim Impresion As Integer

    Dim TotalFilas As Integer
    Dim NroPag As Integer
    Dim NroFila As Integer

    Private colorFondoQR As Integer = Color.FromArgb(255, 255, 255, 255).ToArgb
    Private colorQR As Integer = Color.FromArgb(255, 0, 0, 0).ToArgb

    Public Sub CalcularEdad(ByVal FechaActual As Date, ByVal FechaNacimiento As Date)
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
        If Val(EdadA) > 0 Then
            lblEdad.Text = EdadA & " A"
        ElseIf Val(EdadM) > 0 Then
            lblEdad.Text = EdadM & " M"
        Else
            lblEdad.Text = EdadD & " D"
        End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            lblFNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(Date.Now.ToShortDateString, lblFNac.Text)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        lvHistorial.Items.Clear()
        lvCE.Items.Clear()
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub

            Dim dsVer As New DataSet
            'Resultado de Emergencia
            dsVer = objDetalleSer.BuscarListaResultados(txtHistoria.Text)
            Dim I As Integer
            Dim FIla As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
                If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then FIla.SubItems.Add("RECOGER RESULTADO EN CERITS") Else FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))

                'Buscar Valor Referencia
                If dsVer.Tables(0).Rows(I)("TipoAtencion") <> "SOAT" Then
                    Dim dsPar As New DataSet
                    dsPar = objServicioItem.BuscarId(dsVer.Tables(0).Rows(I)("IdServicio"))
                    If dsVer.Tables(0).Rows.Count > 0 Then
                        dsPar = objItemServicio.ValidarParametrosExamen(dsPar.Tables(0).Rows(0)("IdItem"))
                        If dsPar.Tables(0).Rows.Count > 0 Then
                            FIla.SubItems.Add(dsPar.Tables(0).Rows(0)("Parametros").ToString)
                        Else
                            FIla.SubItems.Add("")
                        End If
                    Else
                        FIla.SubItems.Add("")
                    End If
                Else
                    FIla.SubItems.Add("")
                End If
            Next

            'Resultados de Consulta Externa
            'Historial de Laboratorio Consulta Externa
            dsVer = objDetalleSer.BuscarListaResultadosCE(txtHistoria.Text)
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                FIla = lvCE.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                If dsVer.Tables(0).Rows(I)("Descripcion") = "HIV POR ELISA" Then FIla.SubItems.Add("RECOGER RESULTADO EN CERITS") Else FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
            Next
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmLaboratorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False
        gbQR.Visible = False
        gbLabCE.Visible = False
        gbLabConsulta.Visible = False
        Me.Text = "RESULTADO DE LABORATORIO - Dr(a) " & NomMedico
    End Sub

    Private Sub btnRetornarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub btnBuscarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Impresion = 1
        If lvHistorial.SelectedItems.Count = 0 Then MessageBox.Show("Debe Seleccionar uno o varios Examenes a Imprimir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
        pdcDocumento.DefaultPageSettings.Landscape = False
    End Sub

    Private Sub pdcDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        If Impresion = 1 Then
            TotalFilas = lvHistorial.SelectedItems.Count - 1
        ElseIf Impresion = 2 Then
            TotalFilas = lvCE.SelectedItems.Count - 1
        End If
        NroPag = 1
        NroFila = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        Dim Aux As String

        Y = 20
        Filas = 10
        If Impresion = 1 Then
            With e.Graphics
                .DrawString("HOSPITAL REGIONAL" & StrDup(80, " ") & "DEPARTAMENTO DE LABORATORIO", Fuente10, Pincel, 40, Y)
                Y = Y + 15
                .DrawString("DOCENTE - TRUJILLO", Fuente10, Pincel, 60, Y)
                .DrawString("Pag. " & NroPag & " " & UsuarioSistema, Fuente8, Pincel, 872, Y)
                Y = Y + 20
                .DrawString("Fec: " & Date.Now.ToShortDateString, Fuente8, Pincel, 872, Y)
                Y = Y + 20
                .DrawString("RESULTADOS DE LABORATORIO CLINICO - EMERGENCIA", Fuente12N, Pincel, 200, Y)
                .DrawString("Hor: " & Date.Now.ToShortTimeString, Fuente8, Pincel, 872, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 190, Y, 690, Y)
                Y = Y + 10
                .DrawString("Historia : " & Microsoft.VisualBasic.Left(txtHistoria.Text & StrDup(12, " "), 12), Fuente12N, Pincel, 20, Y)
                .DrawString("Servicio : " & Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(0).SubItems(1).Text & StrDup(12, " "), 12), Fuente12N, Pincel, 260, Y)
                .DrawString("Tipo : " & Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(0).SubItems(4).Text & StrDup(20, " "), 20), Fuente12N, Pincel, 520, Y)
                Y = Y + 15
                .DrawString("Paciente : " & lblPaciente.Text, Fuente12N, Pincel, 20, Y)
                Y = Y + 30

                .DrawString("Fecha Muestra" & StrDup(4, " ") & "Procedimiento" & StrDup(28, " ") & "Resultado" & StrDup(38, " ") & "Parametros" & StrDup(32, " ") & "Fec/Hor Res", Fuente8, Pincel, 20, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 20, Y, 1120, Y)
                Y = Y + 15
                Do While TotalFilas >= 0
                    If lvHistorial.SelectedItems(NroFila).Selected Then
                        .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(7).Text & StrDup(10, " "), 10), Fuente8, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(5).Text & StrDup(30, "-"), 30), Fuente8, Pincel, 120, Y)
                        .DrawString(lvHistorial.SelectedItems(NroFila).SubItems(8).Text & " " & lvHistorial.SelectedItems(NroFila).SubItems(9).Text, Fuente8, Pincel, 1000, Y)

                        'Resultados
                        Aux = Replace(lvHistorial.SelectedItems(NroFila).SubItems(6).Text, vbLf, " ")
                        If Aux.Length <= 40 Then
                            .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(40, "-"), 40), Fuente10, Pincel, 350, Y)
                            Y = Y + 15
                        Else
                            .DrawString(Microsoft.VisualBasic.Left(Aux, 50), Fuente8, Pincel, 340, Y)
                            Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 40)
                            Y = Y + 15
                            Do While Aux.Length > 50
                                .DrawString(Microsoft.VisualBasic.Left(Aux, 50), Fuente8, Pincel, 340, Y)
                                Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 40)
                                Y = Y + 15
                            Loop
                            .DrawString(Aux, Fuente8, Pincel, 340, Y)
                            Y = Y + 15
                        End If
                        NroFila += 1
                        If NroFila = 66 Then Exit Do
                    End If
                    TotalFilas -= 1
                Loop
                If TotalFilas > 0 Then
                    e.HasMorePages = True
                    NroPag += 1
                    NroFila = 0
                Else
                    e.HasMorePages = False
                    Y = Y + 10
                    .DrawLine(Pens.Black, 20, Y, 1120, Y)
                    Y = Y + 4
                    .DrawLine(Pens.Black, 20, Y, 840, Y)
                    Y = Y + 4
                    .DrawString("Fuente: Sistema Informático del HRDT", Fuente8, Pincel, 40, Y)
                End If
            End With
        ElseIf Impresion = 2 Then
            With e.Graphics
                .DrawString("HOSPITAL REGIONAL" & StrDup(80, " ") & "DEPARTAMENTO DE LABORATORIO", Fuente10, Pincel, 40, Y)
                Y = Y + 15
                .DrawString("DOCENTE - TRUJILLO", Fuente10, Pincel, 60, Y)
                .DrawString("Pag. " & NroPag & " " & UsuarioSistema, Fuente8, Pincel, 872, Y)
                Y = Y + 20
                .DrawString("Fec: " & Date.Now.ToShortDateString, Fuente8, Pincel, 872, Y)
                Y = Y + 20
                .DrawString("RESULTADOS DE LABORATORIO CLINICO - CONSULTA EXTERNA", Fuente12N, Pincel, 200, Y)
                .DrawString("Hor: " & Date.Now.ToShortTimeString, Fuente8, Pincel, 872, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 190, Y, 750, Y)
                Y = Y + 10
                .DrawString("Historia : " & Microsoft.VisualBasic.Left(txtHistoria.Text & StrDup(12, " "), 12), Fuente12N, Pincel, 20, Y)
                .DrawString("Servicio : " & Microsoft.VisualBasic.Left(lvCE.SelectedItems(0).SubItems(1).Text & StrDup(12, " "), 12), Fuente12N, Pincel, 260, Y)
                .DrawString("Tipo : " & Microsoft.VisualBasic.Left(lvCE.SelectedItems(0).SubItems(4).Text & StrDup(20, " "), 20), Fuente12N, Pincel, 540, Y)
                Y = Y + 15
                .DrawString("Paciente : " & lblPaciente.Text, Fuente12N, Pincel, 20, Y)
                Y = Y + 30

                .DrawString("Fecha Muestra" & StrDup(4, " ") & "Procedimiento" & StrDup(28, " ") & "Resultado" & StrDup(38, " ") & "Parametros" & StrDup(32, " ") & "Fec/Hor Res", Fuente8, Pincel, 20, Y)
                Y = Y + 15
                .DrawLine(Pens.Black, 20, Y, 1120, Y)
                Y = Y + 15
                Do While TotalFilas >= 0
                    If lvCE.SelectedItems(NroFila).Selected Then
                        .DrawString(Microsoft.VisualBasic.Left(lvCE.SelectedItems(NroFila).SubItems(7).Text & StrDup(10, " "), 10), Fuente8, Pincel, 20, Y)
                        .DrawString(Microsoft.VisualBasic.Left(lvCE.SelectedItems(NroFila).SubItems(5).Text & StrDup(30, "-"), 30), Fuente8, Pincel, 120, Y)
                        .DrawString(lvCE.SelectedItems(NroFila).SubItems(8).Text & " " & lvCE.SelectedItems(NroFila).SubItems(9).Text, Fuente8, Pincel, 1000, Y)

                        'Resultados
                        Aux = Replace(lvCE.SelectedItems(NroFila).SubItems(6).Text, vbLf, " ")
                        If Aux.Length <= 40 Then
                            .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(40, "-"), 40), Fuente10, Pincel, 350, Y)
                            Y = Y + 15
                        Else
                            .DrawString(Microsoft.VisualBasic.Left(Aux, 50), Fuente8, Pincel, 340, Y)
                            Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 50)
                            Y = Y + 15
                            Do While Aux.Length > 50
                                .DrawString(Microsoft.VisualBasic.Left(Aux, 50), Fuente8, Pincel, 340, Y)
                                Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 50)
                                Y = Y + 15
                            Loop
                            .DrawString(Aux, Fuente8, Pincel, 340, Y)
                            Y = Y + 15
                        End If
                        NroFila += 1
                        If NroFila = 66 Then Exit Do
                    End If
                    TotalFilas -= 1
                Loop
                If TotalFilas > 0 Then
                    e.HasMorePages = True
                    NroPag += 1
                    NroFila = 0
                Else
                    e.HasMorePages = False
                    Y = Y + 10
                    .DrawLine(Pens.Black, 20, Y, 1120, Y)
                    Y = Y + 4
                    .DrawLine(Pens.Black, 20, Y, 1120, Y)
                    Y = Y + 4
                    .DrawString("Fuente: Sistema Informático del HRDT", Fuente8, Pincel, 40, Y)
                End If
            End With
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnImprimirCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirCE.Click
        Impresion = 2
        If lvCE.SelectedItems.Count = 0 Then MessageBox.Show("Debe Seleccionar uno o varios Examenes a Imprimir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
        pdcDocumento.DefaultPageSettings.Landscape = False
    End Sub

    Private Sub btnQR1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQR1.Click
        imgQR.Image = Nothing
        If lvHistorial.SelectedItems.Count > 0 Then
            Dim Texto As String = ""
            Texto = "LABORATORIO EMERGENCIA - " & Date.Now & vbLf
            Texto = Texto & "Historia: " & txtHistoria.Text & vbLf
            Texto = Texto & "Paciente: " & lblPaciente.Text & vbLf
            Texto = Texto & "Tipo    : " & lvHistorial.SelectedItems(0).SubItems(4).Text & vbLf
            Texto = Texto & "Servicio: " & lvHistorial.SelectedItems(0).SubItems(1).Text & vbLf
            'Texto = Texto & "=======================================================" & vbLf
            For I = 0 To lvHistorial.SelectedItems.Count - 1
                Texto = Texto & "Examen   : " & lvHistorial.SelectedItems(I).SubItems(5).Text & vbLf
                Texto = Texto & "Resultado: " & lvHistorial.SelectedItems(I).SubItems(6).Text & vbLf
                'Texto = Texto & "Muestra  : " & lvCE.SelectedItems(I).SubItems(7).Text & vbLf
                'Texto = Texto & "----------------------------------------------------" & lvCE.SelectedItems(0).SubItems(1).Text & vbLf
            Next
            'Texto = Texto & "======================================================="

            Dim generarCodigoQR As QRCodeEncoder = New QRCodeEncoder
            generarCodigoQR.QRCodeEncodeMode =
                Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            generarCodigoQR.QRCodeScale = Int32.Parse(4)

            generarCodigoQR.QRCodeErrorCorrect =
                        Codec.QRCodeEncoder.ERROR_CORRECTION.Q

            'La versión "0" calcula automáticamente el tamaño
            generarCodigoQR.QRCodeVersion = 0


            generarCodigoQR.QRCodeBackgroundColor =
               System.Drawing.Color.FromArgb(colorFondoQR)
            generarCodigoQR.QRCodeForegroundColor =
                System.Drawing.Color.FromArgb(colorQR)

            Try
                'Con UTF-8 podremos añadir caracteres como ñ, tildes, etc.
                imgQR.Image = generarCodigoQR.Encode(Texto,
                                    System.Text.Encoding.UTF8)
                'imgQR.Image = generarCodigoQR.Encode(Texto)
                gbQR.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                imgQR.Image = Nothing
            End Try
        Else
            MessageBox.Show("Debe Seleccionar uno o mas exámenes para generar el código QR", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnQR2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQR2.Click
        imgQR.Image = Nothing
        If lvCE.SelectedItems.Count > 0 Then
            Dim Texto As String = ""
            Texto = "LABORATORIO CONSULTA EXTERNA - " & Date.Now & vbLf
            Texto = Texto & "Historia: " & txtHistoria.Text & vbLf
            Texto = Texto & "Paciente: " & lblPaciente.Text & vbLf
            Texto = Texto & "Tipo    : " & lvCE.SelectedItems(0).SubItems(4).Text & vbLf
            Texto = Texto & "Servicio: " & lvCE.SelectedItems(0).SubItems(1).Text & vbLf
            'Texto = Texto & "=======================================================" & vbLf
            For I = 0 To lvCE.SelectedItems.Count - 1
                Texto = Texto & "Examen   : " & lvCE.SelectedItems(I).SubItems(5).Text & vbLf
                Texto = Texto & "Resultado: " & lvCE.SelectedItems(I).SubItems(6).Text & vbLf
                'Texto = Texto & "Muestra  : " & lvCE.SelectedItems(I).SubItems(7).Text & vbLf
                'Texto = Texto & "----------------------------------------------------" & lvCE.SelectedItems(0).SubItems(1).Text & vbLf
            Next
            'Texto = Texto & "======================================================="

            Dim generarCodigoQR As QRCodeEncoder = New QRCodeEncoder
            generarCodigoQR.QRCodeEncodeMode =
                Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            generarCodigoQR.QRCodeScale = Int32.Parse(4)

            generarCodigoQR.QRCodeErrorCorrect =
                        Codec.QRCodeEncoder.ERROR_CORRECTION.Q

            'La versión "0" calcula automáticamente el tamaño
            generarCodigoQR.QRCodeVersion = 0


            generarCodigoQR.QRCodeBackgroundColor =
               System.Drawing.Color.FromArgb(colorFondoQR)
            generarCodigoQR.QRCodeForegroundColor =
                System.Drawing.Color.FromArgb(colorQR)

            Try
                'Con UTF-8 podremos añadir caracteres como ñ, tildes, etc.
                imgQR.Image = generarCodigoQR.Encode(Texto,
                                    System.Text.Encoding.UTF8)
                'imgQR.Image = generarCodigoQR.Encode(Texto)
                gbQR.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                imgQR.Image = Nothing
            End Try
        Else
            MessageBox.Show("Debe Seleccionar uno o mas exámenes para generar el código QR", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRetornarQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarQR.Click
        gbQR.Visible = False
    End Sub

    Private Sub lvHistorial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvHistorial.KeyDown
        If lvHistorial.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            lblPro1.Text = lvHistorial.SelectedItems(0).SubItems(5).Text
            txtRes1.Text = lvHistorial.SelectedItems(0).SubItems(6).Text
            gbLabCE.Visible = True
        End If
    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar01.Click
        txtRes1.Text = ""
        gbLabCE.Visible = False
    End Sub

    Private Sub lvCE_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCE.DoubleClick
        If lvCE.SelectedItems.Count > 0 Then
            lblPro2.Text = lvCE.SelectedItems(0).SubItems(5).Text
            txtRes2.Text = lvCE.SelectedItems(0).SubItems(6).Text
            gbLabConsulta.Visible = True
        End If
    End Sub

    Private Sub lvCE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCE.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar02.Click
        txtRes2.Text = ""
        gbLabConsulta.Visible = False
    End Sub
End Class