Public Class frmLoteHIS
    Dim objLote As New LoteHIS

   
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmLoteHIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsLote As New DataSet
        txtLote.Text = ""
        txtNumeroLote.Text = ""
        txtNumeroPagina.Text = ""
        dsLote = objLote.Buscar
        If dsLote.Tables(0).Rows.Count > 0 Then
            txtLote.Text = dsLote.Tables(0).Rows(0)("Lote")
            txtNumeroLote.Text = dsLote.Tables(0).Rows(0)("Numero")
            txtNumeroPagina.Text = dsLote.Tables(0).Rows(0)("Pagina")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Registra Numero de Lote", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objLote.Actualizar(txtLote.Text, txtNumeroLote.Text, txtNumeroPagina.Text)
            MessageBox.Show("Datos guardados satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
End Class