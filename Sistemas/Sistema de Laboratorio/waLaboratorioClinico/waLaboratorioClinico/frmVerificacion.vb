Public Class frmVerificacion
    Dim objLaboratorio As New Laboratorio
    Dim objProduccion As New ProduccionLaboratorio

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        lvTab.Items.Clear()
        lblTotal.Text = 0
        If e.KeyCode = Keys.Enter Then
            Dim dsTab As New Data.DataSet
            dsTab = objLaboratorio.Verificacion(cboTipo.Text, txtSerie.Text, Val(txtNumero.Text))
            If dsTab.Tables(0).Rows.Count > 0 Then
                lblFecha.Text = dsTab.Tables(0).Rows(0)("Fecha")
                lblHistoria.Text = dsTab.Tables(0).Rows(0)("Historia")
                lblHistoria.Tag = dsTab.Tables(0).Rows(0)("IdComprobante")
                lblPaciente.Text = dsTab.Tables(0).Rows(0)("Paciente")

                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsTab.Tables(0).Rows.Count - 1
                    Fila = lvTab.Items.Add(dsTab.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTab.Tables(0).Rows(I)("Precio")), "#0.00"))
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("Cantidad"))
                    Fila.SubItems.Add(Microsoft.VisualBasic.Format(Val(dsTab.Tables(0).Rows(I)("Importe")), "#0.00"))
                    Fila.SubItems.Add(dsTab.Tables(0).Rows(I)("ClasLaboratorio"))
                    lblTotal.Text = Val(lblTotal.Text) + Val(dsTab.Tables(0).Rows(I)("Importe"))
                Next
                cboArea.Select()
            Else
                MessageBox.Show("No es un comprobante con Servicios de Laboratorio Clinico", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Select()
            End If

        End If
    End Sub

    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub frmVerificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Text = "BOLETA"
    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerie.LostFocus
        If txtSerie.Text <> "" Then txtSerie.Text = Microsoft.VisualBasic.Right("000" & txtSerie.Text, 3)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboArea.KeyDown
        If cboArea.Text <> "" And e.KeyCode = Keys.Enter Then cboEspecialidad.Select()
    End Sub

    Private Sub cboArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboArea.SelectedIndexChanged
        cboEspecialidad.Items.Clear()
        If cboArea.Text <> "SIS" Then
            cboEspecialidad.Items.Add("CIRUGIA")
            cboEspecialidad.Items.Add("GINECOLOGIA")
            cboEspecialidad.Items.Add("MEDICINA")
            cboEspecialidad.Items.Add("OBSTETRICIA")
            cboEspecialidad.Items.Add("PEDIATRIA")

            If cboArea.Text = "HOSPITALIZACION" Then
                cboEspecialidad.Items.Add("UCI")
            End If
        Else
            cboEspecialidad.Items.Add("CONSULTA EXTERNA")
            cboEspecialidad.Items.Add("EMERGENCIA")
            cboEspecialidad.Items.Add("HOSPITALIZACION")
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lvTab.Items.Clear()
        lblFecha.Text = ""
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        txtNumero.Text = ""
        txtSerie.Select()
        lblTotal.Text = "0.00"
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtSerie.Select()
    End Sub

    Private Sub cboEspecialidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEspecialidad.KeyDown
        If e.KeyCode = Keys.Enter And cboEspecialidad.Text <> "" Then btnGrabar.Select()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar los Datos", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objLaboratorio.GrabarAreaEsp(lblHistoria.Tag, cboArea.Text, cboEspecialidad.Text)
            Dim I As Integer
            For I = 0 To lvTab.Items.Count - 1
                objProduccion.Grabar(lblFecha.Text, lvTab.Items(I).SubItems(4).Text, lvTab.Items(I).SubItems(0).Text, cboArea.Text, cboEspecialidad.Text, "Comprobantes", Microsoft.VisualBasic.Left(cboTipo.Text, 1) & " " & txtSerie.Text & "-" & Microsoft.VisualBasic.Right("0000000" & txtNumero.Text, 7))
            Next
        End If
        btnCancelar_Click(sender, e)
    End Sub
End Class