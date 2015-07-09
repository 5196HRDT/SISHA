Imports System.IO
Public Class frmInforme
    Dim objInforme As New clsInformeClinicoSM
    Dim objDetalle As New clsDetInformeArmasSM
    Dim objCupo As New clsCupoSM
    Dim objFormato As New clsFormato
    Dim objCie10 As New clsCie10
    Dim ObjMedico As New clsMedico

    Dim Extension As String
    Dim nomFiltro As String

    Dim Oper As Integer
    Dim CodLocal As String
    Dim Especialidad As String

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

    Private Sub Botones(Nuevo As Boolean, Subir As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnSubir.Enabled = Subir
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub BuscarHistorial()
        lvHistorial.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objInforme.BuscarHistoria(lblHistoria.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvHistorial.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Fecha"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Responsable"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TituloInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Extension"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdCupo"))
        Next
    End Sub

    Private Sub BuscarFormatos()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objFormato.Buscar("")
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Titulo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Extension"))
        Next
    End Sub

    Private Sub BuscarCupo()
        lvCupos.Items.Clear()
        If Not IsNumeric(vIdMedico) Then Exit Sub
        Dim dsCupo As New DataSet
        dsCupo = objCupo.Buscar(dtpF1.Value.ToShortDateString, vIdMedico)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsCupo.Tables(0).Rows.Count - 1
            Fila = lvCupos.Items.Add(dsCupo.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("IdCupo"))
        Next
        lblCupos.Text = dsCupo.Tables(0).Rows.Count & " Cupos"
    End Sub

    Private Sub frmInforme_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        dtpF1.Value = Date.Now
        BuscarCupo()
        BuscarFormatos()
        lvTabla.Enabled = False
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

        'Buscar Especialidad
        Dim dsVerMed As New DataSet
        dsVerMed = ObjMedico.Medico_BuscarId(vIdMedico)
        If dsVerMed.Tables(0).Rows.Count > 0 Then
            Especialidad = dsVerMed.Tables(0).Rows(0)("SubServicio")
        End If
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim Extension As String
            Dim bw As System.IO.BinaryWriter
            Extension = lvTabla.SelectedItems(0).SubItems(3).Text
            Dim dsTabla As DataSet
            dsTabla = objFormato.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
            Dim Archivo As Byte() = dsTabla.Tables(0).Rows(0)("Documento")

            Dim ExtensionNombre As String = Application.StartupPath() & "\" & lblTipo.Text & lblHistoria.Text & dtpF1.Value.Day & dtpF1.Value.Month & dtpF1.Value.Year & "." & Extension
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
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            If lvTabla.SelectedItems(0).SubItems(1).Text = "PSICOLOGICO" And Especialidad <> "PSICOLOGIA" Then MessageBox.Show("Usted tiene la especialidad de " & Especialidad & ". Solo debe elegir documentos de su Especialidad", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If lvTabla.SelectedItems(0).SubItems(1).Text = "PSIQUIATRICO" And Especialidad <> "PSIQUIATRIA" Then MessageBox.Show("Usted tiene la especialidad de " & Especialidad & ". Solo debe elegir documentos de su Especialidad", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            lblTipo.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            lblTitulo.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            Exit Sub
        End If
        lblTipo.Text = ""
        lblTitulo.Text = ""
    End Sub

    Private Sub lvCupos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCupos.SelectedIndexChanged
        If lvCupos.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvCupos.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvCupos.SelectedItems(0).SubItems(1).Text
            BuscarHistorial()
            lvTabla.Enabled = True
        Else
            Limpiar(Me)
            lblHistoria.Text = ""
            txtPaciente.Text = ""
            lvTabla.Enabled = False
            cboPersonalidad.Text = ""
            txtPuntaje.Text = ""
            cboCategoria.Text = ""
            cboOrganicidad.Text = ""
            cboCondicionPS.Text = ""
            chkAgresividad.Checked = False
            chkHostilidad.Checked = False
            chkImpulsividad.Checked = False
            chkInestabilidad.Checked = False
            chkRetraimiento.Checked = False
            txtCieQA.Text = ""
            txtDesQA.Text = ""
            cboDrogas.Text = ""
            txtCieQB.Text = ""
            txtDesQB.Text = ""
            txtCieQC.Text = ""
            txtDesQC.Text = ""
            cboCondicionPQ.Text = ""
        End If
    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter And lvTabla.Items.Count > 0 Then lvTabla.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged
        BuscarCupo()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        gbPQ.Enabled = False
        gbPS.Enabled = False
        cboPersonalidad.Text = ""
        btnAbrir.Enabled = False
        txtPuntaje.Text = ""
        cboCategoria.Text = ""
        cboOrganicidad.Text = ""
        cboCondicionPS.Text = ""
        chkAgresividad.Checked = False
        chkHostilidad.Checked = False
        chkImpulsividad.Checked = False
        chkInestabilidad.Checked = False
        chkRetraimiento.Checked = False
        txtCieQA.Text = ""
        txtDesQA.Text = ""
        cboDrogas.Text = ""
        txtCieQB.Text = ""
        txtDesQB.Text = ""
        txtCieQC.Text = ""
        txtDesQC.Text = ""
        cboCondicionPQ.Text = ""
    End Sub

    Private Sub btnSubir_Click(sender As System.Object, e As System.EventArgs) Handles btnSubir.Click
        If lblTipo.Text = "PSICOLOGICO" And Especialidad <> "PSICOLOGIA" Then
            MessageBox.Show("Usted no puede Grabar Informes que no son de su Especialidad", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        End If
        If lblTipo.Text = "PSIQUIATRICO" And Especialidad <> "PSIQUIATRIA" Then
            MessageBox.Show("Usted no puede Grabar Informes que no son de su Especialidad", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        End If

        If txtRuta.Text = "" Then MessageBox.Show("Debe seleccionar un archivo para subir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If lblTipo.Text = "" Then MessageBox.Show("Debe seleccionar un tipo de la Lista de Informes", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Esta seguro de Subir Informe Cínico de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Myfile As System.IO.FileStream
            Myfile = System.IO.File.OpenRead(txtRuta.Text)
            Dim Arr(Myfile.Length) As Byte
            Myfile.Read(Arr, 0, Myfile.Length)
            Dim IdInforme As Integer
            If Oper = 1 Then
                IdInforme = objInforme.Grabar(Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lblHistoria.Text, txtPaciente.Text, lblTipo.Text, lblTitulo.Text, Arr, Extension, vIdMedico, NomMedico, lvCupos.SelectedItems(0).SubItems(2).Text)
                CodLocal = IdInforme
            ElseIf Oper = 2 Then
                objInforme.Modificar(CodLocal, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, lblHistoria.Text, txtPaciente.Text, lblTipo.Text, lblTitulo.Text, Arr, Extension, vIdMedico, NomMedico, lvCupos.SelectedItems(0).SubItems(2).Text)
            End If
            'Grabar Detalle
            Dim A, B, C, D, F As String
            If chkInestabilidad.Checked Then A = "SI" Else A = "NO"
            If chkAgresividad.Checked Then B = "SI" Else B = "NO"
            If chkImpulsividad.Checked Then C = "SI" Else C = "NO"
            If chkHostilidad.Checked Then D = "SI" Else D = "NO"
            If chkRetraimiento.Checked Then F = "SI" Else F = "NO"
            objDetalle.Grabar(CodLocal, cboPersonalidad.Text, txtPuntaje.Text, cboCategoria.Text, cboOrganicidad.Text, A, B, C, D, F, cboCondicionPS.Text, txtCieQA.Text, txtDesQA.Text, cboDrogas.Text, txtCieQB.Text, txtDesQB.Text, txtCieQC.Text, txtDesQC.Text, cboCondicionPQ.Text, cboPsicologo.Text, cboPsiquiatra.Text)
            MessageBox.Show("Datos Guardados Satisfactorimanete", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        dtpF1.Select()
        gbPQ.Enabled = True
        gbPS.Enabled = True
        btnAbrir.Enabled = True
        Oper = 1
    End Sub

    Private Sub btnAbrir_Click(sender As System.Object, e As System.EventArgs) Handles btnAbrir.Click
        If oAbrir.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Extension = System.IO.Path.GetExtension(oAbrir.FileName).Replace(".", "")
            txtRuta.Text = oAbrir.FileName
        End If
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
        cboPersonalidad.Text = ""
        txtPuntaje.Text = ""
        cboCategoria.Text = ""
        cboOrganicidad.Text = ""
        cboCondicionPS.Text = ""
        chkAgresividad.Checked = False
        chkHostilidad.Checked = False
        chkImpulsividad.Checked = False
        chkInestabilidad.Checked = False
        chkRetraimiento.Checked = False
        txtCieQA.Text = ""
        txtDesQA.Text = ""
        cboDrogas.Text = ""
        txtCieQB.Text = ""
        txtDesQB.Text = ""
        txtCieQC.Text = ""
        txtDesQC.Text = ""
        cboCondicionPQ.Text = ""
        Oper = 2
        If lvHistorial.SelectedItems.Count > 0 Then
            CodLocal = lvHistorial.SelectedItems(0).SubItems(0).Text
            lblTipo.Text = lvHistorial.SelectedItems(0).SubItems(3).Text
            lblTitulo.Text = lvHistorial.SelectedItems(0).SubItems(4).Text
            If lvHistorial.SelectedItems(0).SubItems(3).Text = "PSICOLOGICO" And Especialidad <> "PSICOLOGIA" Then
                gbPS.Enabled = False
                gbPQ.Enabled = True
                Oper = 1
            End If
            If lvHistorial.SelectedItems(0).SubItems(3).Text = "PSIQUIATRICO" And Especialidad <> "PSIQUIATRIA" Then
                gbPS.Enabled = True
                gbPQ.Enabled = False
                Oper = 1
            End If
            'Buscar Detalle
            Dim dsDet As New DataSet
            dsDet = objDetalle.Buscar(lvHistorial.SelectedItems(0).SubItems(0).Text)
            If dsDet.Tables(0).Rows.Count > 0 Then
                cboPersonalidad.Text = dsDet.Tables(0).Rows(0)("Personalidad")
                txtPuntaje.Text = dsDet.Tables(0).Rows(0)("PuntajeTotal")
                cboCategoria.Text = dsDet.Tables(0).Rows(0)("CategoriaInteligencia")
                cboOrganicidad.Text = dsDet.Tables(0).Rows(0)("Organicidad")
                If dsDet.Tables(0).Rows(0)("Inestabilidad") = "SI" Then chkInestabilidad.Checked = True Else chkInestabilidad.Checked = False
                If dsDet.Tables(0).Rows(0)("Agrecividad") = "SI" Then chkAgresividad.Checked = True Else chkAgresividad.Checked = False
                If dsDet.Tables(0).Rows(0)("Impulsividad") = "SI" Then chkImpulsividad.Checked = True Else chkImpulsividad.Checked = False
                If dsDet.Tables(0).Rows(0)("Hostilidad") = "SI" Then chkHostilidad.Checked = True Else chkHostilidad.Checked = False
                If dsDet.Tables(0).Rows(0)("Retraimiento") = "SI" Then chkRetraimiento.Checked = True Else chkRetraimiento.Checked = False
                cboCondicionPS.Text = dsDet.Tables(0).Rows(0)("CondicionPS")
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
                cboPsicologo.Text = dsDet.Tables(0).Rows(0)("Psicologo")
                cboPsiquiatra.Text = dsDet.Tables(0).Rows(0)("Psiquiatra")
            End If
        End If
        
    End Sub

    Private Sub cboPersonalidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPersonalidad.KeyDown
        If e.KeyCode = Keys.Enter And cboPersonalidad.Text <> "" Then txtPuntaje.Select()
    End Sub

    Private Sub cboPersonalidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPersonalidad.SelectedIndexChanged

    End Sub

    Private Sub txtPuntaje_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPuntaje.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtPuntaje.Text) Then cboCategoria.Select()
    End Sub

    Private Sub txtPuntaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPuntaje.TextChanged

    End Sub

    Private Sub cboCategoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCategoria.KeyDown
        If e.KeyCode = Keys.Enter And cboCategoria.Text <> "" Then cboOrganicidad.Select()
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged

    End Sub

    Private Sub cboOrganicidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboOrganicidad.KeyDown
        If e.KeyCode = Keys.Enter And cboOrganicidad.Text <> "" Then cboCondicionPS.Select()
    End Sub

    Private Sub cboOrganicidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrganicidad.SelectedIndexChanged

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

    Private Sub txtDesQA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQA.TextChanged
        If txtDesQA.Text.Length > 1 And txtDesQA.Enabled Then nomFiltro = "DESCIEQA" : txtDes.Text = txtDesQA.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQA.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDesQB_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQB.TextChanged
        If txtDesQB.Text.Length > 1 And txtDesQB.Enabled Then nomFiltro = "DESCIEQB" : txtDes.Text = txtDesQB.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQB.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
    End Sub

    Private Sub txtDesQC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDesQC.TextChanged
        If txtDesQC.Text.Length > 1 And txtDesQC.Enabled Then nomFiltro = "DESCIEQC" : txtDes.Text = txtDesQC.Text : gbConsulta.Visible = True : txtDes.Text = txtDesQC.Text : txtDes.SelectionStart = txtDes.Text.Length : txtDes.Select()
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

    Private Sub lvDet_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvDet.SelectedIndexChanged

    End Sub

    Private Sub btnRetornarC_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarC.Click
        gbConsulta.Visible = False
    End Sub
End Class