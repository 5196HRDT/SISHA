Imports ThoughtWorks.QRCode
Imports ThoughtWorks.QRCode.Codec
Imports ThoughtWorks.QRCode.Codec.Data
Public Class frmPatologia
    Dim objHistoria As New clsHistoria
    Dim objPatologia As New clsPatologia

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

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        Dim Fila As ListViewItem
        Dim I As Integer
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub

            'Historia de Patologia
            Dim dsPatologia As New DataSet
            dsPatologia = objPatologia.BuscarHistoria(txtHistoria.Text)
            lvListaI.Items.Clear()
            For I = 0 To dsPatologia.Tables(0).Rows.Count - 1
                Fila = lvListaI.Items.Add(dsPatologia.Tables(0).Rows(I)("IdInforme"))
                Fila.SubItems.Add(dsPatologia.Tables(0).Rows(I)("FEntrega"))
                Fila.SubItems.Add(dsPatologia.Tables(0).Rows(I)("Nombre"))
            Next
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnBuscarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub frmPatologia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False
        gbQR.Visible = False
        Me.Text = "PATOLOGIA - Dr(a) " & NomMedico
    End Sub

    Private Sub btnRetornarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
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

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub lvListaI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvListaI.SelectedIndexChanged
        If lvListaI.SelectedItems.Count > 0 Then
            Dim dsP As New DataSet
            dsP = objPatologia.ConsultaId(lvListaI.SelectedItems(0).SubItems(0).Text)
            lblFechaEntrga.Text = dsP.Tables(0).Rows(0)("FEntrega")
            lblTipo.Text = dsP.Tables(0).Rows(0)("TipoPaciente")
            lblProcedencia.Text = dsP.Tables(0).Rows(0)("Procedencia")
            lblServicio.Text = dsP.Tables(0).Rows(0)("Servicio")
            lblMedico.Text = dsP.Tables(0).Rows(0)("Medico")
            lblDiagnostico.Text = dsP.Tables(0).Rows(0)("Diagnostico")
            lblNombre.Text = dsP.Tables(0).Rows(0)("Nombre")
            lblOrgano.Text = dsP.Tables(0).Rows(0)("Organo")
            lblTipoMuestra.Text = dsP.Tables(0).Rows(0)("Muestra")
            txtCuerpo.Rtf = dsP.Tables(0).Rows(0)("Cuerpo")
            txtCuerpo.Tag = dsP.Tables(0).Rows(0)("Cuerpo1")
        Else
            lblFechaEntrga.Text = ""
            lblTipo.Text = ""
            lblProcedencia.Text = ""
            lblServicio.Text = ""
            lblMedico.Text = ""
            lblDiagnostico.Text = ""
            lblNombre.Text = ""
            lblOrgano.Text = ""
            lblTipoMuestra.Text = ""
            txtCuerpo.Rtf = ""
            txtCuerpo.Tag = ""
        End If
    End Sub

    Private Sub btnQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQR.Click
        imgQR.Image = Nothing
        If lvListaI.SelectedItems.Count > 0 Then
            Dim Texto As String = ""
            Texto = "PATOLOGIA - HRDT - " & Date.Now & vbLf
            Texto = Texto & "Historia: " & txtHistoria.Text & vbLf
            Texto = Texto & "Paciente: " & lblPaciente.Text & vbLf
            Texto = Texto & "Edad    : " & lblEdad.Text & " Sexo: " & lblSexo.Text & vbLf
            Texto = Texto & "Fecha   : " & lblFechaEntrga.Text & vbLf
            Texto = Texto & "Servicio: " & lblServicio.Text & vbLf
            Texto = Texto & "Examen  : " & lblNombre.Text & vbLf
            Texto = Texto & "Organo  : " & lblOrgano.Text & vbLf
            Texto = Texto & "Muestra : " & lblTipoMuestra.Text & vbLf
            Texto = Texto & "INFORME : " & vbLf
            Texto = Texto & txtCuerpo.Tag & vbLf

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
            MessageBox.Show("Debe Seleccionar un exámen para generar el código QR", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRetornarQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarQR.Click
        gbQR.Visible = False
    End Sub
End Class