Public Class frmConsultaAtencionSISPac
    Dim objHistoria As New Historia
    Dim objSis As New SIS

    Private Sub txtHistoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHistoria.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            Try
                dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
                If dsTabla.Tables(0).Rows.Count > 0 Then
                    lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                    lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                    lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                    btnBuscar_Click(sender, e)
                Else
                    MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblAPaterno.Text = ""
                    lblAMaterno.Text = ""
                    lblNombres.Text = ""
                    txtHistoria.Select()
                End If
            Catch ex As Exception
                Return
            End Try
        End If
        
    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NumeroHistoria = ""
        frmBuscarHistoria.Show()
    End Sub

    Private Sub btnBuscarH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If NumeroHistoria.Length > 0 Then
            txtHistoria.Text = NumeroHistoria
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                btnBuscar.Select()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                txtHistoria.Select()
            End If
            NumeroHistoria = ""
        End If
    End Sub

    Private Sub frmConsultaAtencionSISPac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumeroHistoria = ""
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lvDet.Items.Clear()
        If txtHistoria.TextLength <= 0 Then Exit Sub
        Dim dsTabla As New Data.DataSet
        dsTabla = objSis.ConsultaAtencionPaciente(txtHistoria.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            Dim I As Integer
            Dim Fila As New ListViewItem
            Dim Fecha As String
            For I = 0 To dsTabla.Tables(0).Rows.Count - 1
                Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("Formato"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Afiliado"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Situacion"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("PlanSIS"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Historia"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Paciente"))
                Fecha = dsTabla.Tables(0).Rows(I)("FechaAtencion").ToString.Substring(0, 10)
                Fila.SubItems.Add(Fecha)
                If dsTabla.Tables(0).Rows(I)("FechaAlta").ToString <> "" Then
                    Fecha = dsTabla.Tables(0).Rows(I)("FechaAlta").ToString.Substring(0, 10)
                    Fila.SubItems.Add(Fecha)
                Else
                    Fila.SubItems.Add("")
                End If
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("EsReferido"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("SubEspecialidad"))
                Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Especialidad"))
            Next
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

   
    Private Sub txtHistoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHistoria.KeyDown
        If e.KeyCode = Keys.F7 Then
            frmBuscarHistoria.Show()
        End If
    End Sub
End Class