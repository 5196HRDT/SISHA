Public Class frmElectro
    Dim objHistoria As New clsHistoria
    Dim objElectro As New clsEncefalograma

    Private Sub BuscarHistoria(ByVal Historia As String)
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(Historia)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblHistoria.Text = dsHistorias.Tables(0).Rows(0)("HClinica")
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
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

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        lvTabla.Items.Clear()
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsHistoria As New DataSet
            If IsNumeric(txtPaciente.Text) Then
                dsHistoria = objHistoria.Buscar(txtPaciente.Text)
            Else
                dsHistoria = objHistoria.BuscarPaciente(txtPaciente.Text)
            End If
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsHistoria.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsHistoria.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Apaterno") & " " & dsHistoria.Tables(0).Rows(I)("Amaterno") & " " & dsHistoria.Tables(0).Rows(I)("Nombres"))
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lvHistorial.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            BuscarHistoria(lvTabla.SelectedItems(0).SubItems(0).Text)

            'Buscar Historial de Electroencefalogramas
            Dim dsVer As New DataSet
            dsVer = objElectro.BuscarHistoria(lvTabla.SelectedItems(0).SubItems(0).Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdElectro"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaInforme"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Solicitado"))
            Next
        End If
    End Sub

    Private Sub frmElectro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged
        If lvHistorial.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objElectro.BuscarId(lvHistorial.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                lblHistoria.Text = dsVer.Tables(0).Rows(0)("Historia")
                lblPaciente.Text = dsVer.Tables(0).Rows(0)("Paciente")
                lblEdad.Text = dsVer.Tables(0).Rows(0)("Edad")
                lblSexo.Text = dsVer.Tables(0).Rows(0)("Sexo")
                cboMedico.Text = dsVer.Tables(0).Rows(0)("Solicitado")
                cboTipo.Text = dsVer.Tables(0).Rows(0)("TipoDoc")
                txtSerie.Text = dsVer.Tables(0).Rows(0)("Serie")
                txtNumero.Text = dsVer.Tables(0).Rows(0)("Numero")
                txtInforme.Rtf = dsVer.Tables(0).Rows(0)("Informe")
                cboTipoPaciente.Text = dsVer.Tables(0).Rows(0)("TipoPaciente")
            End If
        End If
    End Sub
End Class