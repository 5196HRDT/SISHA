Public Class frmTomaMuestra
    Dim objConsulta As New clsConsulta
    Dim objInterconsultaE As New clsInterconsulta
    Dim objComprobante As New clsComprobanteVta
    Dim objSis As New clsSIS
    Dim objMedico As New clsMedico
    Dim objHistoria As New clsHistoria

    Dim NumeroHistoria As String
    Dim SubTipo As String

    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10)
    Dim Fuente8 As New Font("Courier New", 8)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim TotalFilas As Integer
    Dim NroFila As Integer
    Dim FilasHoja As Integer
    Dim Y As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter And txtPaciente.Text <> "" Then dtpF1.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub frmTomaMuestra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        gbRecep.Visible = False

        btnImprimir.Enabled = False

        'Medico
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"
    End Sub

    Private Sub dtpF2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then btnBuscar.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub dtpF1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Function Verificar(ByVal IdProcedimiento As String) As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvTabla.Items.Count - 1
            If lvTabla.Items(I).SubItems(14).Text = IdProcedimiento Then Verificar = True : Exit For
        Next
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim I As Integer
        Dim Fila As ListViewItem
        Dim dsVer As New DataSet
        Dim dsConsulta As New DataSet
        lvTabla.Items.Clear()
        btnImprimir.Enabled = False
        'Buscar Requerimiento de Consulta Externa
        dsVer = objConsulta.BuscarExaMuestraPato(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, txtPaciente.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ServicioCE"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
            'Agregar Diagnosticos
            If dsVer.Tables(0).Rows(I)("IdCupo") > 0 Then
                dsConsulta = objConsulta.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                Else
                    dsConsulta = objInterconsultaE.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des1"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des2"))
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Des3"))
                    Else
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("")
                        Fila.SubItems.Add("")
                    End If
                End If
            Else
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
            End If
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubTipo"))
            Fila.SubItems.Add("CE")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdExamen"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add(0)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion"))

            'Agregar Responsable
            If dsVer.Tables(0).Rows(I)("IdCupo") > 0 Then
                dsConsulta = objConsulta.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                If dsConsulta.Tables(0).Rows.Count > 0 Then
                    Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Responsable"))
                Else
                    dsConsulta = objInterconsultaE.Buscar(dsVer.Tables(0).Rows(I)("IdCupo"))
                    If dsConsulta.Tables(0).Rows.Count > 0 Then
                        Fila.SubItems.Add(dsConsulta.Tables(0).Rows(0)("Responsable"))
                    Else
                        Fila.SubItems.Add("")
                    End If
                End If
            Else
                Fila.SubItems.Add("")
            End If

            Application.DoEvents()
        Next

        'Lista de Procedimientos Caja de Emergencia
        dsVer = objComprobante.BuscarPatDocEmergencia(txtPaciente.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            If Not Verificar(dsVer.Tables(0).Rows(I)("IdServicioItem")) Then
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdComprobante"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubServicio").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NHistoria"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add("COMUN")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hora"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Fila.SubItems.Add("CAJA EMERGENCIA")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdServicioItem"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(0)
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                Fila.SubItems.Add("")
            End If
            Application.DoEvents()
        Next

        'Lista de Procedimientos del SIS
        dsVer = objSis.BuscarPatAtencionCE(txtPaciente.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            If Not Verificar(dsVer.Tables(0).Rows(I)("IdProcedimiento")) Then
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Id"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspecialidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                Fila.SubItems.Add("SIS")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                Fila.SubItems.Add(Format(CDbl(dsVer.Tables(0).Rows(I)("Cantidad")), "#.00"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
                Fila.SubItems.Add("SIS")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdProcedimiento"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lote"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Numero"))
                Fila.SubItems.Add("")
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Precio"))
                Fila.SubItems.Add("")
            End If
            Application.DoEvents()
        Next

        MessageBox.Show("Datos encontrado hasta el momento", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        gbRecep.Visible = False
    End Sub

    Private Sub cmdAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAtender.Click
        If lvTabla.SelectedItems.Count > 0 Then
            txtIndicacion.Text = ""
            gbRecep.Visible = True
            lblHistoria.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            lblTipo.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            txtIndicacion.Text = lvTabla.SelectedItems(0).SubItems(17).Text
            dtpFecha.Select()
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboMedico.Select()
    End Sub

    Private Sub cboMedico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedico.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboMedico.SelectedValue) Then txtIndicacion.Select()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Está seguro de recepcionar las muestras de patología?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If txtIndicacion.Text = "" Then MessageBox.Show("Debe ingresar las indicaciones del Médico Solicitante", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

           
            If lvTabla.SelectedItems(0).SubItems(13).Text = "CE" Then
                objConsulta.MuestraTomada(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name)
                objConsulta.ActualizarIndicacion(lvTabla.SelectedItems(0).SubItems(0).Text, txtIndicacion.Text, cboMedico.Text)
            ElseIf lvTabla.SelectedItems(0).SubItems(13).Text = "SIS" Then
                objSis.AtencionProcedimientoSis(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema)
                objConsulta.GrabarExaSISCEMed(0, lvTabla.SelectedItems(0).SubItems(14).Text, lvTabla.SelectedItems(0).SubItems(5).Text, lvTabla.SelectedItems(0).SubItems(18).Text, lvTabla.SelectedItems(0).SubItems(6).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.SelectedItems(0).SubItems(12).Text, "SIS", 0, lvTabla.SelectedItems(0).SubItems(15).Text, lvTabla.SelectedItems(0).SubItems(16).Text, lvTabla.SelectedItems(0).SubItems(2).Text, lvTabla.SelectedItems(0).SubItems(3).Text, lvTabla.SelectedItems(0).SubItems(1).Text, txtIndicacion.Text, cboMedico.Text)
            ElseIf lvTabla.SelectedItems(0).SubItems(13).Text = "CAJA EMERGENCIA" Then
                objConsulta.GrabarExaSISCEMed(0, lvTabla.SelectedItems(0).SubItems(14).Text, lvTabla.SelectedItems(0).SubItems(5).Text, lvTabla.SelectedItems(0).SubItems(18).Text, lvTabla.SelectedItems(0).SubItems(6).Text, 0, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.SelectedItems(0).SubItems(12).Text, "COMUN", 0, lvTabla.SelectedItems(0).SubItems(15).Text, lvTabla.SelectedItems(0).SubItems(16).Text, lvTabla.SelectedItems(0).SubItems(2).Text, lvTabla.SelectedItems(0).SubItems(3).Text, lvTabla.SelectedItems(0).SubItems(1).Text, txtIndicacion.Text, cboMedico.Text)
                objComprobante.MarcarDocEmerRecibido(lvTabla.SelectedItems(0).SubItems(0).Text, "RAYOS", lvTabla.SelectedItems(0).SubItems(12).Text)
            End If

            btnRetornar_Click(sender, e)
            txtPaciente.Text = ""
            btnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub btnListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListado.Click
        lvTabla.Items.Clear()
        Dim dsListado As New DataSet
        dsListado = objConsulta.ListaProcPatologia(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsListado.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsListado.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("ServicioCE"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Cantidad"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("HoraRegistro"))
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add("")
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("SubTipo"))
            Fila.SubItems.Add("CONSULTA EXTERNA")
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("IdExamen"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("SerieSIS"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("NumeroSIS"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Indicacion"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Precio"))
            Fila.SubItems.Add(dsListado.Tables(0).Rows(I)("Solicitante"))
            Application.DoEvents()
        Next
        If lvTabla.Items.Count > 0 Then btnImprimir.Enabled = True Else btnImprimir.Enabled = False
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        ppdDocumento.ShowDialog()
    End Sub

    Private Sub pdDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdDocumento.BeginPrint
        Y = 10
        TotalFilas = lvTabla.Items.Count - 1
        NroFila = 0
        FilasHoja = 0
    End Sub

    Private Sub Cabecera(ByVal Historia As String, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        With e.Graphics
            Dim dsHistoria As New DataSet
            Dim Edad As String
            dsHistoria = objHistoria.Buscar(Historia)
            If dsHistoria.Tables(0).Rows.Count > 0 Then
                .DrawString(Date.Now.ToShortDateString & " - " & Date.Now.ToShortTimeString, Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Nro Historia: " & Historia, Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Paciente    : ", Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString(dsHistoria.Tables(0).Rows(0)("Apaterno") & " " & dsHistoria.Tables(0).Rows(0)("Amaterno") & " " & dsHistoria.Tables(0).Rows(0)("Nombres"), Fuente10, Pincel, 20, Y)
                Y = Y + 15
                'Calcular Edad
                If dsHistoria.Tables(0).Rows(0)("FNACIMIENTO").ToString <> "" Then
                    Dim Dias As Integer, Meses As Integer, Años As Integer
                    Dim DiasMes As Integer
                    Dim dfin, dinicio As Date
                    Dim EdadA, EdadM, EdadD As String
                    dfin = Date.Now.ToShortDateString
                    dinicio = dsHistoria.Tables(0).Rows(0)("FNACIMIENTO")
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
                    Edad = EdadA & " A " & EdadM & " M " & EdadD & " D "
                Else
                    Edad = ""
                End If
                .DrawString("Edad : " & Edad & StrDup(1, " ") & "Sexo:" & Microsoft.VisualBasic.Left(dsHistoria.Tables(0).Rows(0)("Sexo").ToString, 2), Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Area : " & SubTipo, Fuente10, Pincel, 20, Y)
                Y = Y + 15
            End If
        End With
    End Sub

    Private Sub pdDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        With e.Graphics
            Do While TotalFilas >= 0
                If NroFila = 0 Then
                    NumeroHistoria = lvTabla.Items(NroFila).SubItems(2).Text
                    SubTipo = lvTabla.Items(NroFila).SubItems(12).Text
                    Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                    .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                    Y = Y + 15
                    .DrawString("Indicación: " & lvTabla.Items(NroFila).SubItems(17).Text, Fuente8, Pincel, 20, Y)
                Else
                    If NumeroHistoria <> lvTabla.Items(NroFila).SubItems(2).Text Then
                        NumeroHistoria = lvTabla.Items(NroFila).SubItems(2).Text
                        Y = Y + 15
                        .DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                        Y = Y + 25
                        Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                        .DrawString("Servicio  : " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                        Y = Y + 15
                        .DrawString("Indicación: " & lvTabla.Items(NroFila).SubItems(17).Text, Fuente8, Pincel, 20, Y)
                    Else
                        If SubTipo <> lvTabla.Items(NroFila).SubItems(12).Text Then
                            SubTipo = lvTabla.Items(NroFila).SubItems(12).Text
                            Y = Y + 15
                            .DrawString(StrDup(20, "="), Fuente12N, Pincel, 20, Y)
                            Y = Y + 25
                            Cabecera(lvTabla.Items(NroFila).SubItems(2).Text, e)
                            .DrawString("Servicio: " & lvTabla.Items(NroFila).SubItems(1).Text, Fuente10, Pincel, 20, Y)
                            Y = Y + 15
                            .DrawString("Indicación: " & lvTabla.Items(NroFila).SubItems(17).Text, Fuente8, Pincel, 20, Y)
                        End If
                    End If
                End If
                Y = Y + 15
                .DrawString(Microsoft.VisualBasic.Right(StrDup(2, " ") & lvTabla.Items(NroFila).SubItems(6).Text, 2) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvTabla.Items(NroFila).SubItems(5).Text & StrDup(25, " "), 25), Fuente8, Pincel, 20, Y)

                NroFila += 1
                TotalFilas -= 1

                If FilasHoja >= 50 Then Exit Do
            Loop
            If TotalFilas > 0 Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        End With
    End Sub
End Class