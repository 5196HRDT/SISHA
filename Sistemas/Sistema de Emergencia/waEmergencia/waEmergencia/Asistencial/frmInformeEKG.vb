Imports ThoughtWorks.QRCode
Imports ThoughtWorks.QRCode.Codec
Imports ThoughtWorks.QRCode.Codec.Data
Public Class frmInformeEKG
    Dim objInforme As New clsInformeEKG
    Dim objEKGCie As New clsInformeEKGCie
    Dim objHistoria As New clsHistoria
    Dim objCie As New clsCIE10HE
    Dim objMedico As New clsMedico

    Private colorFondoQR As Integer = Color.FromArgb(255, 255, 255, 255).ToArgb
    Private colorQR As Integer = Color.FromArgb(255, 0, 0, 0).ToArgb

    Dim CodLocal As String
    Dim Oper As Integer

    Dim Filtro As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub


    Private Sub frmInformeEKG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False
        btnCancelar_Click(sender, e)
        gbQR.Visible = False
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPacienteH.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            lblFechaNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento").ToString
            lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
            If dsHistorias.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                Dim Dias As Integer, Meses As Integer, Años As Integer
                Dim DiasMes As Integer
                Dim dfin, dinicio As Date
                Dim EdadA, EdadM, EdadD As String
                dfin = Date.Now.ToShortDateString
                dinicio = dsHistorias.Tables(0).Rows(0)("FNACIMIENTO")
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

                    EdadD = Microsoft.VisualBasic.Day(dinicio)
                    If Val(EdadD) > Date.Now.Day Then
                        EdadD = Val(EdadD) - Date.Now.Day
                    ElseIf Val(EdadD) < Date.Now.Day Then
                        If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                        EdadD = Date.Now.Day - EdadD
                        EdadD = DameDiasMes(Date.Now.Month) - EdadD
                    Else
                        EdadD = 0
                    End If
                End If
                lblEdad.Text = EdadA & " A " & EdadM & " M " & EdadD & " D "
            Else
                lblEdad.Text = ""
            End If
        Else
            MessageBox.Show("Paciente no se encuentra registrado en el Sistema", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()
            Dim dsVer As New DataSet

            dsVer = objInforme.Buscar(txtHistoria.Text)
            Dim I As Integer
            Dim FIla As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                FIla = lvH.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaToma"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Origen"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoDiagnostico"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Conclusiones"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("MedicoTratante"))
                FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Examen"))
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

    Private Sub btnRetornarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter And txtPaciente.Text.Length > 0 Then
            Dim dsHC As New DataSet
            dsHC = objHistoria.BuscarNombres(txtPaciente.Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsHC.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsHC.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Fnacimiento").ToString)
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("Sexo"))
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsHC.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
        txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
        gbPaciente.Visible = False
        txtHistoria_KeyDown(sender, e)
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub lvH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvH.SelectedIndexChanged
        If lvH.SelectedItems.Count > 0 Then
            ControlesAD(Me, True)
            Botones(False, True, False)
            Oper = 2
            CodLocal = lvH.SelectedItems(0).SubItems(0).Text
            lblFecha.Text = lvH.SelectedItems(0).SubItems(1).Text
            lblOrigen.Text = lvH.SelectedItems(0).SubItems(2).Text
            txtHistoria.Text = lvH.SelectedItems(0).SubItems(3).Text
            lblPacienteH.Text = lvH.SelectedItems(0).SubItems(4).Text
            lblSexo.Text = lvH.SelectedItems(0).SubItems(5).Text
            lblEdad.Text = lvH.SelectedItems(0).SubItems(6).Text
            lblTipoDx.Text = lvH.SelectedItems(0).SubItems(7).Text
            txtConclusiones.Text = lvH.SelectedItems(0).SubItems(8).Text
            lblCardiologo.Text = lvH.SelectedItems(0).SubItems(9).Text
            lblSolicitado.Text = lvH.SelectedItems(0).SubItems(10).Text
            lblExamen.Text = lvH.SelectedItems(0).SubItems(11).Text

            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsCie As New DataSet
            dsCie = objEKGCie.Buscar(CodLocal)
            For I = 0 To dsCie.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsCie.Tables(0).Rows(I)("Cie"))
                Fila.SubItems.Add(dsCie.Tables(0).Rows(I)("Descripcion"))
            Next
            btnQR.Enabled = True
        Else
            btnQR.Enabled = False
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, False)
        Oper = 1
        txtHistoria.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, True)
        lvTabla.Items.Clear()
        lvH.Items.Clear()
        btnQR.Enabled = False
    End Sub

    Private Sub btnQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQR.Click
        imgQR.Image = Nothing
        If txtConclusiones.Text <> "" Then
            Dim Texto As String = ""
            Texto = "LABORATORIO EMERGENCIA - " & Date.Now & vbLf
            Texto = Texto & "Historia: " & txtHistoria.Text & vbLf
            Texto = Texto & "Paciente: " & lblPacienteH.Text & vbLf
            Texto = Texto & "Edad    : " & lblEdad.Text & StrDup(2, " ") & "Sexo: " & lblSexo.Text & vbLf
            Texto = Texto & "Origen  : " & lblOrigen.Text & vbLf
            Texto = Texto & "Tipo Dx : " & lblTipoDx.Text & vbLf
            Texto = Texto & "Exámen  : " & lblExamen.Text & vbLf
            Texto = Texto & "Solicitado: " & lblSolicitado.Text & vbLf
            Texto = Texto & "CONCLUSION: " & txtConclusiones.Text & vbLf
            Texto = Texto & "Cardiólogo: " & lblCardiologo.Text

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
End Class