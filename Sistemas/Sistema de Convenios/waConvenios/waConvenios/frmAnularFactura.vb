Public Class frmAnularFactura
    Dim objFactura As New FacturacionEconomia

    Private Sub frmFacturaAnulada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFDoc.Value = Date.Now
        Limpiar(Me)
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If cboTipo.Text <> "" And e.KeyCode = Keys.Enter Then txtSerie.Select()
    End Sub

    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If txtSerie.Text <> "" And e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboTipo.Text <> "" And txtSerie.Text <> "" And txtNumero.Text <> "" Then
            If MessageBox.Show("Esta seguro de Anular Comprobante de Venta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objFactura.AnularComprobante(cboTipo.Text, txtSerie.Text, txtNumero.Text, Microsoft.VisualBasic.Format(dtpFDoc.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema)
            End If
            btnCancelar_Click(sender, e)
        Else
            MessageBox.Show("Debe ingresar los datos completos de Comprobante de Venta", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTipo.Select()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.LostFocus
        Dim dsVer As New Data.DataSet
        dsVer = objFactura.Verificar(cboTipo.Text, txtSerie.Text, txtNumero.Text)
        If dsVer.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("Comprobante de Venta NO EXISTE, Verifique Numeracion", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumero.Select()
        End If
    End Sub
End Class