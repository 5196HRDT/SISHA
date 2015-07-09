Public Class frmResultadosEmergencia
    Dim objDetalleSer As New clsEmergenciaSer
    Dim objHistoria As New clsHistoria
    Dim objControlAnulacion As New clsControlAnulacionResLab
    Dim objItem As New clsItem
    Dim objItemServicio As New clsItemServicio
    Dim objServioItem As New clsServicioItem


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

    Private Sub Formatos()
        Select Case lblProcedimiento.Text
            Case "HEMOGRAMA", "PERFIL PERIFERICO HEMATOLOGICO"
                txtResultado.Text = "HB:  gr/dl HTO:  % LUC.:  xmm3 AB:    SG:    EO:    B:    M:    L:    VSG:    GS.RH:    PLAQ.  xmm3  OBJ DE LAM:"
            Case "ORINA COMPLETA"
                txtResultado.Text = "DENSIDAD:    PH:     CARB.:    PROTEINAS:     SALES B.:     SEDIMENTACION:    C.EPITELIALES:     LEUCOCITOS:    HEMATIES:    CRISTALES:"
            Case Else
                txtResultado.Text = ""
        End Select
    End Sub

    Private Sub frmResultadosEmergencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now
        btnGrabar.Enabled = False
        gbPaciente.Visible = False
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        lblPacienteH.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
        lblFechaNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
        lblSexo.Text = dsHistorias.Tables(0).Rows(0)("Sexo")
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim dsVer As New DataSet
        dsVer = objDetalleSer.BuscarListaParaResultado(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        lvTabla.Items.Clear()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion").ToString)
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lblServicio.Text = ""
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblTipo.Text = ""
        txtResultado.Text = ""
        lblProcedimiento.Text = ""
        btnGrabar.Enabled = False
        lvTabla.Select()
    End Sub

    Private Sub txtResultado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtResultado.TextChanged
        If txtResultado.Text <> "" And lblHistoria.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then txtResultado.Select()
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            objDetalleSer.EliminarServicio(lvTabla.SelectedItems(0).SubItems(0).Text)
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            lblServicio.Tag = lvTabla.SelectedItems(0).SubItems(0).Text
            lblServicio.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            lblPaciente.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            lblTipo.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            lblProcedimiento.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            Formatos()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Resultado", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Codigo As String
            Codigo = txtHistoria.Text  'InputBox("Ingresar Codigo de Muestra", "Datos de Resultados")
            'If Codigo = "" Then MessageBox.Show("Dede Ingresar un Valor en el Codigo del Resultado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            objDetalleSer.GrabarResultado(lblServicio.Tag, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), My.Computer.Name, UsuarioSistema, txtResultado.Text)
            lvTabla.Items.RemoveAt(lvTabla.SelectedItems(0).Index)

            btnCancelar_Click(sender, e)
            lvTabla.Select()
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()
            lvHistorial.Items.Clear()
            Dim dsVer As New DataSet
            Dim dsItem As New DataSet

            dsVer = objDetalleSer.BuscarListaResultados(txtHistoria.Text)
            Dim I As Integer
            Dim FIla As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                If dsVer.Tables(0).Rows(I)("TipoAtencion") <> "SOAT/AFOCAT" Then
                    dsItem = objItem.ValidarParametrosExamen(dsVer.Tables(0).Rows(I)("IdServicio"))
                    If dsItem.Tables(0).Rows.Count > 0 Then
                        If dsItem.Tables(0).Rows(0)("Reservado") = "NO" Then
                            FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                            FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
                        Else
                            MessageBox.Show("Paciente posee examenes reservados que deben ser consulados en la jefatura de laboratorio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                        FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
                    End If

                    'Buscar Valor Referencia
                    If dsVer.Tables(0).Rows(I)("TipoAtencion") <> "SOAT" Then
                        Dim dsPar As New DataSet
                        dsPar = objServioItem.BuscarId(dsVer.Tables(0).Rows(I)("IdServicio"))
                        If dsVer.Tables(0).Rows.Count > 0 Then
                            dsPar = objItemServicio.BuscarIdItem(dsPar.Tables(0).Rows(0)("IdItem"))
                            If dsPar.Tables(0).Rows.Count > 0 Then
                                If dsPar.Tables(0).Rows(0)("Parametros").ToString <> "" Then
                                    FIla.SubItems.Add(dsPar.Tables(0).Rows(0)("Parametros").ToString)
                                Else
                                    FIla.SubItems.Add("NINGUNO")
                                End If
                            Else
                                FIla.SubItems.Add("NINGUNO")
                            End If
                            Else
                                FIla.SubItems.Add("NINGUNO")
                            End If
                    Else
                        FIla.SubItems.Add("NINGUNO")
                    End If

                Else
                    FIla = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("Resultado"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaTomaMuestra"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaResultado"))
                    FIla.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraResultado"))
                End If
            Next
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
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

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If lvHistorial.SelectedItems.Count = 0 Then MessageBox.Show("Debe Seleccionar uno o varios Examenes a Imprimir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        pdcDocumento.DefaultPageSettings.Landscape = True
        ppdVistaPrevia.ShowDialog()
        pdcDocumento.DefaultPageSettings.Landscape = False
    End Sub

    Private Sub pdcDocumento_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdcDocumento.BeginPrint
        TotalFilas = lvHistorial.SelectedItems.Count - 1
        NroPag = 1
        NroFila = 0
    End Sub

    Private Sub pdcDocumento_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        Dim Filas As Integer = 0
        Dim Aux As String
       
        Y = 20
        Filas = 10
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
            .DrawString("Paciente : " & lblPacienteH.Text, Fuente12N, Pincel, 20, Y)
            Y = Y + 30

            .DrawString("Fecha Muestra" & StrDup(4, " ") & "Procedimiento" & StrDup(38, " ") & "Resultado" & StrDup(70, " ") & "Fec/Hor Res", Fuente8, Pincel, 20, Y)
            Y = Y + 15
            .DrawLine(Pens.Black, 20, Y, 1120, Y)
            Y = Y + 15
            Do While TotalFilas >= 0
                If lvHistorial.SelectedItems(NroFila).Selected Then
                    .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(7).Text & StrDup(10, " "), 10), Fuente8, Pincel, 20, Y)
                    .DrawString(Microsoft.VisualBasic.Left(lvHistorial.SelectedItems(NroFila).SubItems(5).Text & StrDup(30, "-"), 30), Fuente8, Pincel, 120, Y)
                    .DrawString(lvHistorial.SelectedItems(NroFila).SubItems(8).Text & " " & lvHistorial.SelectedItems(NroFila).SubItems(9).Text, Fuente8, Pincel, 1000, Y)

                    'Resultados
                    Aux = Replace(lvHistorial.SelectedItems(NroFila).SubItems(6).Text, vbLf, " ") & ". VALORES NORMALES: " & Replace(lvHistorial.SelectedItems(NroFila).SubItems(10).Text, vbLf, " ")
                    If Aux.Length <= 70 Then
                        .DrawString(Microsoft.VisualBasic.Left(Aux & StrDup(70, "-"), 70), Fuente10, Pincel, 350, Y)
                        Y = Y + 15
                    Else
                        .DrawString(Microsoft.VisualBasic.Left(Aux, 70), Fuente8, Pincel, 340, Y)
                        Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 70)
                        Y = Y + 15
                        Do While Aux.Length > 70
                            .DrawString(Microsoft.VisualBasic.Left(Aux, 70), Fuente8, Pincel, 340, Y)
                            Aux = Microsoft.VisualBasic.Right(Aux, Aux.Length - 70)
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
    End Sub

    Private Sub lvHistorial_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvHistorial.KeyDown
        If lvHistorial.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Anular Resultado de Laboratorio?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Motivo As String = InputBox("Ingresar Motivo Justificado para Posterior Auditoria", "Anulación de Resultado")
                If Motivo.Length < 5 Then MessageBox.Show("El motivo debe estar plenamente Justificado, Intente Nuevamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                objControlAnulacion.Grabar(Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lvHistorial.SelectedItems(0).SubItems(0).Text, "EMERGENCIA", Motivo)
                objDetalleSer.AnularResultado(lvHistorial.SelectedItems(0).SubItems(0).Text)
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged

    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter And txtFiltro.Text <> "" Then
            Dim dsVer As New DataSet
            dsVer = objDetalleSer.BuscarListaParaResultadoNom(txtFiltro.Text)
            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdEmerSer"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoAtencion").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion").ToString)
            Next
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub
End Class