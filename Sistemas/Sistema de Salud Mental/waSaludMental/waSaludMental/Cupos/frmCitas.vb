Public Class frmCitas
    Dim objHistoria As New clsHistoria
    Dim objMedico As New clsMedico
    Dim objCupo As New clsCupoSM

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

    Private Sub BuscarCupo()
        lvCupos.Items.Clear()
        If Not IsNumeric(cboMedico.SelectedValue) Then Exit Sub
        Dim dsCupo As New DataSet
        dsCupo = objCupo.Buscar(dtpF1.Value.ToShortDateString, cboMedico.SelectedValue)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsCupo.Tables(0).Rows.Count - 1
            Fila = lvCupos.Items.Add(dsCupo.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsCupo.Tables(0).Rows(I)("IdCupo"))
        Next
        lblCupos.Text = dsCupo.Tables(0).Rows.Count & " Cupos"
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtHistoria.Text) Then
            BuscarHistoria()
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter And txtHistoria.Text = "" Then txtPaciente.Select()
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub frmCitas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        gbPaciente.Visible = False

        Dim dsMed As New DataSet
        dsMed = objMedico.SaludMental
        cboMedico.DataSource = dsMed.Tables(0)
        cboMedico.DisplayMember = "Medico"
        cboMedico.ValueMember = "IdMedico"

        BuscarCupo()
    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then txtHistoria.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged
        BuscarCupo()
    End Sub

    Private Function Verificar() As Boolean
        Verificar = False
        Dim I As Integer
        For I = 0 To lvCupos.Items.Count - 1
            If lvCupos.Items(I).SubItems(0).Text = txtHistoria.Text Then Verificar = True : Exit For
        Next
    End Function

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If IsNumeric(cboMedico.SelectedValue) And IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            If Verificar() Then MessageBox.Show("Paciente ya fue asigando", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            objCupo.Grabar(cboMedico.SelectedValue, cboMedico.Text, dtpF1.Value.ToShortDateString, txtHistoria.Text, txtPaciente.Text)
            Limpiar(Me)
            txtHistoria.Select()
            BuscarCupo()
        End If
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

    Private Sub cboMedico_Click(sender As Object, e As System.EventArgs) Handles cboMedico.Click
        BuscarCupo()
    End Sub

    Private Sub cboMedico_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedico.SelectedIndexChanged
        BuscarCupo()
    End Sub

    Private Sub lvCupos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCupos.KeyDown
        If lvCupos.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Cupo de Paciente?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objCupo.Eliminar(lvCupos.SelectedItems(0).SubItems(2).Text)
                BuscarCupo()
            End If
        End If
    End Sub

    Private Sub lvCupos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvCupos.SelectedIndexChanged

    End Sub
End Class