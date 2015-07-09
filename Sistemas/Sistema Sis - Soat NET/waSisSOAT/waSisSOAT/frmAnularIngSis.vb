Public Class frmAnularIngSis
    Dim objSIS As New SIS
    Dim CodSis As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumero.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objSIS.ConsultarHEI(lblHEI.Text, cboLote.Text, txtNumero.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                If dsTabla.Tables(0).Rows(0)("IdResponsable").ToString = "" Then
                    CodSis = dsTabla.Tables(0).Rows(0)("IdSIS")
                    lblDISAHEI.Text = dsTabla.Tables(0).Rows(0)("DISAHEI")
                    cboLoteA.Text = dsTabla.Tables(0).Rows(0)("LOTEDISA")
                    txtNumeroA.Text = dsTabla.Tables(0).Rows(0)("NumeroDISA")
                    txtNumeroA_LostFocus(sender, e)
                    txtCorrelativo.Text = dsTabla.Tables(0).Rows(0)("Correlativo")
                    txtCorrelativo_LostFocus(sender, e)
                    lblHistoria.Text = dsTabla.Tables(0).Rows(0)("Historia")
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaAtencion")
                    If lblFecha.Text.Length > 10 Then lblFecha.Text = lblFecha.Text.Remove(10, 14)
                    lblHora.Text = dsTabla.Tables(0).Rows(0)("HoraAtencion")
                    lblPaciente.Text = dsTabla.Tables(0).Rows(0)("APaterno") & " " & dsTabla.Tables(0).Rows(0)("AMaterno") & " " & dsTabla.Tables(0).Rows(0)("Nombres")
                    btnAnular.Enabled = True
                    btnAnular.Select()
                Else
                    MsgBox("Hoja HIS ya Fue Dada de Alta", MsgBoxStyle.Information, "Mensaje de Información")
                    btnCancelar_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumero.Text.Length
            txtNumero.Text = "0" & txtNumero.Text
        Next
        txtNumero.Text.Remove(txtNumero.Text.Length - 8, 8)
    End Sub

    Private Sub cboLoteA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLoteA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And cboLoteA.Text.Length > 0 Then txtNumeroA.Select()
    End Sub

    Private Sub txtNumeroA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) And txtNumeroA.Text.Length > 0 Then txtCorrelativo.Select()
    End Sub

    Private Sub txtNumeroA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroA.LostFocus
        Dim I As Integer
        For I = 1 To 8 - txtNumeroA.Text.Length
            txtNumeroA.Text = "0" & txtNumeroA.Text
        Next
        txtNumeroA.Text.Remove(txtNumeroA.Text.Length - 8, 8)
    End Sub

    Private Sub txtCorrelativo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCorrelativo.LostFocus
        Dim I As Integer
        For I = 1 To 3 - txtCorrelativo.Text.Length
            txtCorrelativo.Text = "0" & txtCorrelativo.Text
        Next
        txtCorrelativo.Text.Remove(txtCorrelativo.Text.Length - 3, 3)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        btnAnular.Enabled = False
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub frmAnularIngSis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
        lblHEI.Text = "LIB"
        lblDISAHEI.Text = "LIB"
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If MessageBox.Show("Esta seguro de Anular Formato de Atencion SIS", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objSIS.AnularSIS(CodSis)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboLote_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboLote.KeyDown
        If e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub
End Class