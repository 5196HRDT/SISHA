Public Class frmCertificadoArmTra
    Dim objCertificado As New clsCertificado
    Dim objHistoria As New clsHistoria
    Dim objInforme As New clsInformeClinicoSM
    Dim objCie10 As New clsCie10
    Dim objMedico As New clsMedico
    Dim ObjDetalle As New clsDetInformeArmasSM

    Dim CodLocal As String
    Dim Oper As Integer
    Dim Extension As String
    Dim nomFiltro As String

    Private Sub Botones(Nuevo As Boolean, Subir As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnSubir.Enabled = Subir
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub FiltroCIE()
        Select Case Microsoft.VisualBasic.Left(nomFiltro, nomFiltro.Length - 2)
            Case "DESCIE"
                If txtDes.Text.Length = 0 Then Exit Sub
                lvDet.Items.Clear()
                Dim dsTabla As New DataSet
                Dim I As Integer
                Dim Fila As ListViewItem
                dsTabla = objCie10.Buscar(txtDes.Text, 2)
                For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Codigo"))
                    Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Descripcion"))
                Next
        End Select
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            txtPaciente.Enabled = False
            txtPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")
            txtPaciente.Enabled = True
            txtPaciente.Select()
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub BuscarHistorial()
        lvHistorial.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objInforme.BuscarHistoria(txtHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TituloInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Extension"))
        Next
    End Sub

    Private Sub BuscarCertificados()
        lvCertificado.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objCertificado.BuscarHistoria(txtHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCertificado.Items.Add(dsVer.Tables(0).Rows(I)("IdCertificado"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Personalidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("PuntajeTotal"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CategoriaInteligencia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Organicidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Inestabilidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Agrecividad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Impulsividad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Hostilidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Retraimiento"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CondicionPS"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CieQA"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesQA"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CieQB"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesQB"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CieQC"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DesQC"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Drogas"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("CondicionPQ"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Psicologo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Psiquiatra"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("DNI"))
        Next
    End Sub

    Private Sub frmCertificadoArmTra_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        gbPaciente.Visible = False
        gbConsulta.Visible = False

        'Psicologo
        Dim dsPsicologo As New DataSet
        dsPsicologo = objMedico.SaludMental
        cboPsicologo.DataSource = dsPsicologo.Tables(0)
        cboPsicologo.DisplayMember = "Medico"
        cboPsicologo.ValueMember = "IdMedico"

        'Psiquiatra
        Dim dsPsiquiatra As New DataSet
        dsPsiquiatra = objMedico.SaludMental
        cboPsiquiatra.DataSource = dsPsiquiatra.Tables(0)
        cboPsiquiatra.DisplayMember = "Medico"
        cboPsiquiatra.ValueMember = "IdMedico"
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()

            'Buscar Informes
            BuscarHistorial()

            'Buscar Certificados
            BuscarCertificados()

            Exit Sub
        End If
        If e.KeyCode = Keys.Enter And txtHistoria.Text = "" Then txtPaciente.Select()
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged
        If txtPaciente.Text <> "" And txtPaciente.Enabled Then txtFiltro.Text = txtPaciente.Text : txtFiltro.SelectionStart = txtFiltro.Text.Length : gbPaciente.Visible = True : txtFiltro.Select() Else gbPaciente.Visible = False
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If txtFiltro.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtFiltro.Text)
            lvTabla.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
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

    Private Sub txtFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltro.TextChanged

    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Enter And lvTabla.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            txtPaciente.Enabled = False
            txtPaciente.Text = lvTabla.SelectedItems(0).SubItems(1).Text & " " & lvTabla.SelectedItems(0).SubItems(2).Text & " " & lvTabla.SelectedItems(0).SubItems(3).Text
            txtPaciente.Enabled = True
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged

    End Sub

    Private Sub lvHistorial_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvHistorial.KeyDown
        If lvHistorial.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim bw As System.IO.BinaryWriter
            Extension = lvHistorial.SelectedItems(0).SubItems(5).Text
            Dim dsTabla As DataSet
            dsTabla = objInforme.BuscarId(lvHistorial.SelectedItems(0).SubItems(0).Text)
            Dim Archivo As Byte() = dsTabla.Tables(0).Rows(0)("Informe")

            Dim ExtensionNombre As String = Application.StartupPath() & "\Informe." & Extension
            Dim fs As System.IO.FileStream = New System.IO.FileStream(ExtensionNombre, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
            bw = New System.IO.BinaryWriter(fs)
            bw.Write(Archivo)
            bw.Flush()
            bw.Close()
            fs.Close()

            Dim Command As New Process
            Command.StartInfo.FileName = ExtensionNombre
            Command.StartInfo.UseShellExecute = True
            Command.StartInfo.CreateNoWindow = True
            Command.Start()
        End If
        If lvHistorial.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Formato de Salud Mental?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objInforme.Eliminar(lvHistorial.SelectedItems(0).SubItems(0).Text)
            End If
            BuscarHistorial()
        End If
    End Sub

    Private Sub lvHistorial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvHistorial.SelectedIndexChanged
        If lvHistorial.SelectedItems.Count > 0 Then
            Dim dsDet As New DataSet
            dsDet = ObjDetalle.Buscar(lvHistorial.SelectedItems(0).SubItems(0).Text)
            If dsDet.Tables(0).Rows.Count > 0 Then
                If lvHistorial.SelectedItems(0).SubItems(3).Text = "PSICOLOGICO" Then
                    cboPersonalidad.Text = dsDet.Tables(0).Rows(0)("PERSONALIDAD")
                    txtPuntaje.Text = dsDet.Tables(0).Rows(0)("PuntajeTotal")
                    cboCategoria.Text = dsDet.Tables(0).Rows(0)("CategoriaInteligencia")
                    cboOrganicidad.Text = dsDet.Tables(0).Rows(0)("Organicidad")
                    If dsDet.Tables(0).Rows(0)("Organicidad") = "SI" Then chkInestabilidad.Checked = True Else chkInestabilidad.Checked = False
                    If dsDet.Tables(0).Rows(0)("Inestabilidad") = "SI" Then chkInestabilidad.Checked = True Else chkInestabilidad.Checked = False
                    If dsDet.Tables(0).Rows(0)("Agrecividad") = "SI" Then chkAgresividad.Checked = True Else chkAgresividad.Checked = False
                    If dsDet.Tables(0).Rows(0)("Impulsividad") = "SI" Then chkImpulsividad.Checked = True Else chkImpulsividad.Checked = False
                    If dsDet.Tables(0).Rows(0)("Hostilidad") = "SI" Then chkHostilidad.Checked = True Else chkHostilidad.Checked = False
                    If dsDet.Tables(0).Rows(0)("Retraimiento") = "SI" Then chkRetraimiento.Checked = True Else chkRetraimiento.Checked = False
                    cboCondicionPS.Text = dsDet.Tables(0).Rows(0)("CondicionPS")
                    cboPsicologo.Text = dsDet.Tables(0).Rows(0)("Psicologo")
                ElseIf lvHistorial.SelectedItems(0).SubItems(3).Text = "PSIQUIATRICO" Then
                    txtCieQA.Text = dsDet.Tables(0).Rows(0)("Cie1")
                    txtDesQA.Enabled = False
                    txtDesQA.Text = dsDet.Tables(0).Rows(0)("DesCie1")
                    txtDesQA.Enabled = True
                    cboDrogas.Text = dsDet.Tables(0).Rows(0)("Multidrogas")
                    txtCieQB.Text = dsDet.Tables(0).Rows(0)("Cie2")
                    txtDesQB.Enabled = False
                    txtDesQB.Text = dsDet.Tables(0).Rows(0)("DesCie2")
                    txtDesQB.Enabled = True
                    txtCieQC.Text = dsDet.Tables(0).Rows(0)("Cie3")
                    txtDesQC.Enabled = False
                    txtDesQC.Text = dsDet.Tables(0).Rows(0)("DesCie3")
                    txtDesQC.Enabled = True
                    cboCondicionPQ.Text = dsDet.Tables(0).Rows(0)("CondicionPQ")
                    cboPsiquiatra.Text = dsDet.Tables(0).Rows(0)("Psiquiatra")
                End If
            End If
        End If
    End Sub

    Private Sub txtCiePC_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtCieQA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCieQA.KeyDown
        If e.KeyCode = Keys.Enter And txtCieQA.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCie10.Buscar(txtCieQA.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                'If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                txtDesQA.Enabled = False
                txtDesQA.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDesQA.Enabled = True
                cboDrogas.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.KeyCode And txtCieQA.Text.Length = 0 Then txtDesQA.Select()
    End Sub

    Private Sub txtCieQA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCieQA.TextChanged

    End Sub

    Private Sub txtCieQB_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCieQB.KeyDown
        If e.KeyCode = Keys.Enter And txtCieQB.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCie10.Buscar(txtCieQB.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                'If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                txtDesQB.Enabled = False
                txtDesQB.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDesQB.Enabled = True
                txtCieQC.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.KeyCode And txtCieQB.Text.Length = 0 Then txtDesQB.Select()
    End Sub

    Private Sub txtCieQB_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCieQB.TextChanged

    End Sub

    Private Sub cboCondicion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCondicionPQ.KeyDown
        If e.KeyCode = Keys.Enter And cboCondicionPQ.Text <> "" Then cboPsicologo.Select()
    End Sub

    Private Sub cboCondicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCondicionPQ.SelectedIndexChanged

    End Sub

    Private Sub txtCieQC_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCieQC.KeyDown
        If e.KeyCode = Keys.Enter And txtCieQC.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objCie10.Buscar(txtCieQC.Text, 1)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                'If txtCIE6.Text = txtCIE1.Text Or txtCIE6.Text = txtCIE2.Text Or txtCIE6.Text = txtCIE3.Text Or txtCIE6.Text = txtCIE4.Text Or txtCIE6.Text = txtCIE5.Text Then MessageBox.Show("Diagnóstico ya fue asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCIE5.Select() : Exit Sub

                txtDesQC.Enabled = False
                txtDesQC.Text = dsTabla.Tables(0).Rows(0)("Descripcion")
                txtDesQC.Enabled = True
                cboCondicionPQ.Select()
            Else
                MessageBox.Show("No existe Codigo de CIE10", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If e.KeyCode = Keys.KeyCode And txtCieQC.Text.Length = 0 Then txtDesQC.Select()
    End Sub

    Private Sub txtCieQC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCieQC.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        lvHistorial.Items.Clear()
        lvCertificado.Items.Clear()
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtHistoria.Enabled = True
        txtPaciente.Enabled = True
        txtDNI.Enabled = True
        Botones(False, True, True, False)
        txtHistoria.Select()
        Oper = 1
    End Sub

    Private Sub cboPsicologo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPsicologo.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboPsicologo.SelectedValue) Then cboPsiquiatra.Select()
    End Sub

    Private Sub txtDes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.Items.Count > 0 Then
            lvDet.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDes.TextChanged
        FiltroCIE()
    End Sub

    Private Sub lvDet_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Enter And lvDet.SelectedItems.Count > 0 Then
            Dim I As Integer
            Dim dsVer As New DataSet
            dsVer = objCie10.Buscar(lvDet.SelectedItems(0).SubItems(0).Text, 1)

            Select Case nomFiltro
                Case "DESCIEQA"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCieQB.Text Or lvDet.Items(I).SubItems(0).Text = txtCieQC.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCieQA.Text = lvDet.Items(I).SubItems(0).Text
                            txtDesQA.Text = lvDet.Items(I).SubItems(1).Text
                            'If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD3.Text = "DEFINITIVO" : txtCIE5.Select() Else cboTD3.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            cboDrogas.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIEQB"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCieQA.Text Or lvDet.Items(I).SubItems(0).Text = txtCieQC.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCieQB.Text = lvDet.Items(I).SubItems(0).Text
                            txtDesQB.Text = lvDet.Items(I).SubItems(1).Text
                            'If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD4.Text = "DEFINITIVO" : txtCIE6.Select() Else cboTD4.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            txtCieQC.Select()
                            Exit For
                        End If
                    Next
                Case "DESCIEQC"
                    For I = 0 To lvDet.Items.Count - 1
                        If lvDet.Items(I).Selected Then
                            If lvDet.Items(I).SubItems(0).Text = txtCieQA.Text Or lvDet.Items(I).SubItems(0).Text = txtCieQB.Text Then MessageBox.Show("Diagnostico ya fue Asignado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                            txtCieQC.Text = lvDet.Items(I).SubItems(0).Text
                            txtDesQC.Text = lvDet.Items(I).SubItems(1).Text
                            'If dsVer.Tables(0).Rows(0)("Definitivo") = "X" Then cboTD5.Text = "DEFINITIVO" : txtTratamiento.Select() Else cboTD5.Select()
                            lvDet.Items.Clear()
                            txtDes.Text = ""
                            gbConsulta.Visible = False
                            cboCondicionPQ.Select()
                            Exit For
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub txtDesQA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQA.TextChanged
        If txtDesQA.Text.Length > 1 And txtDesQA.Enabled Then nomFiltro = "DESCIEQA" : txtDes.Text = txtDesQA.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQA.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDesQB_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQB.TextChanged
        If txtDesQB.Text.Length > 1 And txtDesQB.Enabled Then nomFiltro = "DESCIEQB" : txtDes.Text = txtDesQB.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQB.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub


    Private Sub txtDesQC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQC.TextChanged
        If txtDesQC.Text.Length > 1 And txtDesQC.Enabled Then nomFiltro = "DESCIEQC" : txtDes.Text = txtDesQC.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQB.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub btnRetornarC_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarC.Click
        gbConsulta.Visible = False
    End Sub

    Private Sub btnSubir_Click(sender As System.Object, e As System.EventArgs) Handles btnSubir.Click
        If txtCieQA.Text = "" Then MessageBox.Show("Debe ingresar Informacion de CIE", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCieQA.Select() : Exit Sub
        If txtDNI.Text = "" Then MessageBox.Show("Debe ingresar Número de DNI de Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtDNI.Select() : Exit Sub


        If cboCondicionPQ.Text = "" Then MessageBox.Show("Debe ingresar Informacion de Condición de Certificado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboCondicionPQ.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Actualizar Nro de DNI
            objHistoria.GrabarDNI(txtHistoria.Text, txtDNI.Text)

            Dim A, B, C, D, F As String
            If chkInestabilidad.Checked Then A = "SI" Else A = "NO"
            If chkAgresividad.Checked Then B = "SI" Else B = "NO"
            If chkImpulsividad.Checked Then C = "SI" Else C = "NO"
            If chkHostilidad.Checked Then D = "SI" Else D = "NO"
            If chkRetraimiento.Checked Then F = "SI" Else F = "NO"
            objCertificado.Mantenimiento(CodLocal, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, txtHistoria.Text, txtDNI.Text, txtPaciente.Text, cboPersonalidad.Text, txtPuntaje.Text, cboCategoria.Text, cboOrganicidad.Text, A, B, C, D, F, cboCondicionPS.Text, txtCieQA.Text, txtDesQA.Text, txtCieQB.Text, txtDesQB.Text, txtCieQC.Text, txtDesQC.Text, cboDrogas.Text, cboCondicionPQ.Text, cboPsicologo.SelectedValue, cboPsicologo.Text, cboPsiquiatra.SelectedValue, cboPsiquiatra.Text, Oper)
            btnCancelar_Click(sender, e)
        End If

        
    End Sub

    Private Sub cboPsiquiatra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPsiquiatra.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(cboPsiquiatra.SelectedValue) Then btnSubir.Select()
    End Sub

    Private Sub lvCertificado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCertificado.SelectedIndexChanged
        If lvCertificado.SelectedItems.Count > 0 Then
            Oper = 2
            CodLocal = lvCertificado.SelectedItems(0).SubItems(0).Text
            cboPersonalidad.Text = lvCertificado.SelectedItems(0).SubItems(2).Text
            txtPuntaje.Text = lvCertificado.SelectedItems(0).SubItems(3).Text
            cboCategoria.Text = lvCertificado.SelectedItems(0).SubItems(4).Text
            cboOrganicidad.Text = lvCertificado.SelectedItems(0).SubItems(5).Text
            If lvCertificado.SelectedItems(0).SubItems(6).Text = "SI" Then chkInestabilidad.Checked = True Else chkInestabilidad.Checked = False
            If lvCertificado.SelectedItems(0).SubItems(7).Text = "SI" Then chkAgresividad.Checked = True Else chkAgresividad.Checked = False
            If lvCertificado.SelectedItems(0).SubItems(8).Text = "SI" Then chkImpulsividad.Checked = True Else chkImpulsividad.Checked = False
            If lvCertificado.SelectedItems(0).SubItems(9).Text = "SI" Then chkHostilidad.Checked = True Else chkHostilidad.Checked = False
            If lvCertificado.SelectedItems(0).SubItems(10).Text = "SI" Then chkRetraimiento.Checked = True Else chkRetraimiento.Checked = False
            cboCondicionPS.Text = lvCertificado.SelectedItems(0).SubItems(11).Text
            txtCieQA.Text = lvCertificado.SelectedItems(0).SubItems(12).Text
            txtDesQA.Enabled = False
            txtDesQA.Text = lvCertificado.SelectedItems(0).SubItems(13).Text
            txtDesQA.Enabled = True
            txtCieQB.Text = lvCertificado.SelectedItems(0).SubItems(14).Text
            txtDesQB.Enabled = False
            txtDesQB.Text = lvCertificado.SelectedItems(0).SubItems(15).Text
            txtDesQB.Enabled = True
            txtCieQC.Text = lvCertificado.SelectedItems(0).SubItems(16).Text
            txtDesQC.Enabled = False
            txtDesQC.Text = lvCertificado.SelectedItems(0).SubItems(17).Text
            txtDesQC.Enabled = True
            cboDrogas.Text = lvCertificado.SelectedItems(0).SubItems(18).Text
            cboCondicionPQ.Text = lvCertificado.SelectedItems(0).SubItems(19).Text
            cboPsicologo.Text = lvCertificado.SelectedItems(0).SubItems(20).Text
            cboPsiquiatra.Text = lvCertificado.SelectedItems(0).SubItems(21).Text
            txtDNI.Text = lvCertificado.SelectedItems(0).SubItems(22).Text
        End If
    End Sub
End Class