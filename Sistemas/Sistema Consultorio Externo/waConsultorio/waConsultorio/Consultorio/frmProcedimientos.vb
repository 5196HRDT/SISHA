Public Class frmProcedimientos
    Dim objConsultaCPT As New ConsultaCPT
    Dim objConsulta As New Consulta
    Dim objPaciente As New Historia
    Dim objCPT As New CPT

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmProcedimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbConsulta.Visible = False
        btnGrabar.Enabled = False
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsPac As New Data.DataSet
            btnGrabar.Enabled = False

            dsPac = objPaciente.BuscarHistoria(txtHistoria.Text)
            If dsPac.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsPac.Tables(0).Rows(0)("Apaterno") & " " & dsPac.Tables(0).Rows(0)("AMaterno") & " " & dsPac.Tables(0).Rows(0)("Nombres")
                btnGrabar.Enabled = True
                txtCIE.Select()
            Else
                MessageBox.Show("Paciente se encontro en la base de datos del HRDT", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                txtHistoria.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        NHistoria = txtHistoria.Text
        NomPaciente = lblPaciente.Text
        Dim dsC As New Data.DataSet
        Dim A, B, C, A1, B1, C1 As String

        A = "" : B = "" : C = "" : A1 = "" : B1 = "" : C1 = ""
        If lvTabla.Items.Count = 0 Then MessageBox.Show("Debe ingresar al menos un Codigo CPT para grabar la informacion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If lvTabla.Items.Count >= 1 Then
            A = lvTabla.Items(0).SubItems(0).Text
            A1 = lvTabla.Items(0).SubItems(1).Text
        End If
        If lvTabla.Items.Count >= 2 Then
            B = lvTabla.Items(1).SubItems(0).Text
            B1 = lvTabla.Items(1).SubItems(1).Text
        End If
        If lvTabla.Items.Count >= 3 Then
            C = lvTabla.Items(2).SubItems(0).Text
            C1 = lvTabla.Items(2).SubItems(1).Text
        End If

        dsC = objConsulta.BuscarHistoria(txtHistoria.Text)
        If dsC.Tables(0).Rows.Count > 0 Then
            If vTipoAtencion = "" Then
                objConsultaCPT.Grabar(vFecha, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtHistoria.Text, lblPaciente.Text, A, A1, B, B1, C, C1, "", "", dsC.Tables(0).Rows(0)("Departamento"), dsC.Tables(0).Rows(0)("Provincia"), dsC.Tables(0).Rows(0)("Distrito"), dsC.Tables(0).Rows(0)("Ubigeo"), "CONTINUADOR", "CONTINUADOR", vEspecialidad, vMedico, "D", "D", "D", "D", vIdMedico, vTurno, vEspecialidad)
            Else
                objConsultaCPT.Modificar(CodCupo, vFecha, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtHistoria.Text, lblPaciente.Text, A, A1, B, B1, C, C1, "", "", dsC.Tables(0).Rows(0)("Departamento"), dsC.Tables(0).Rows(0)("Provincia"), dsC.Tables(0).Rows(0)("Distrito"), dsC.Tables(0).Rows(0)("Ubigeo"), "CONTINUADOR", "CONTINUADOR", vEspecialidad, vMedico, "D", "D", "D", "D", vIdMedico, vTurno, vEspecialidad)
            End If
        Else
            'MessageBox.Show("Paciente no Regitra Ninguna Previa al Procedimiento", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If vTipoAtencion = "" Then
                objConsultaCPT.Grabar(vFecha, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtHistoria.Text, lblPaciente.Text, A, A1, B, B1, C, C1, "", "", "LA LIBERTA", "TRUJILLO", "TRUJILLO", "130101", "CONTINUADOR", "CONTINUADOR", vEspecialidad, vMedico, "D", "D", "D", "D", vIdMedico, vTurno, vEspecialidad)
            Else
                objConsultaCPT.Modificar(CodCupo, vFecha, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), txtHistoria.Text, lblPaciente.Text, A, A1, B, B1, C, C1, "", "", "LA LIBERTAD", "TRUJILLO", "TRUJILLO", dsC.Tables(0).Rows(0)("Ubigeo"), "CONTINUADOR", "CONTINUADOR", vEspecialidad, vMedico, "D", "D", "D", "D", vIdMedico, vTurno, vEspecialidad)
            End If
        End If
        Me.Close()
    End Sub

    Private Sub txtCIE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCIE.KeyDown
        If e.KeyCode = Keys.Enter And txtCIE.Text = "" Then txtDes.Select()
        If e.KeyCode = Keys.Enter And txtCIE.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            lvDet.Items.Clear()
            dsCIE = objCPT.BuscarCodigo(txtCIE.Text)
            If dsCIE.Tables(0).Rows.Count > 0 Then
                txtDes.Enabled = False
                txtDes.Text = dsCIE.Tables(0).Rows(I)("desc_cpt")
                txtDes.Enabled = True
                txtDes.Select()
            Else
                txtDes.Text = ""
                txtCIE.Select()
                MessageBox.Show("Codigo de CPT no existe", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtDes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDes.KeyDown
        If txtCIE.Text <> "" And txtDes.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvTabla.Items.Add(txtCIE.Text)
            Fila.SubItems.Add(txtDes.Text)
            txtCIE.Text = ""
            txtDes.Text = ""
            txtCIE.Select()
        End If
    End Sub

    Private Sub txtDes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDes.TextChanged
        If txtDes.Text <> "" And txtDes.Enabled Then txtFiltro.Text = txtDes.Text : txtFiltro.SelectionStart = txtFiltro.TextLength : gbConsulta.Visible = True : txtFiltro.Select()
    End Sub

    Private Sub txtFiltro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then lvDet.Select()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        If txtFiltro.Text <> "" Then
            Dim dsCIE As New Data.DataSet
            Dim I As Integer
            Dim Fila As ListViewItem
            lvDet.Items.Clear()
            dsCIE = objCPT.BuscarDes(txtFiltro.Text)
            For I = 0 To dsCIE.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsCIE.Tables(0).Rows(I)("cod_cpt"))
                Fila.SubItems.Add(dsCIE.Tables(0).Rows(I)("desc_cpt"))
            Next
        End If
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        gbConsulta.Visible = False
        lvDet.Items.Clear()
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.Items.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    txtCIE.Text = ""
                    txtDes.Text = ""
                    Dim Fila As ListViewItem
                    Fila = lvTabla.Items.Add(lvDet.Items(I).SubItems(0).Text)
                    Fila.SubItems.Add(lvDet.Items(I).SubItems(1).Text)
                End If
            Next
            btnRetornar_Click(sender, e)
        End If
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Delete And lvTabla.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvTabla.Items.Count - 1
                If lvTabla.Items(I).Selected Then
                    lvTabla.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub
End Class