Public Class frmNumeroRegistro
    Dim objNumeroRegistro As New clsNumeroRegistro
    Dim Oper As Integer
    Dim CodLocal As String

    Private Sub Buscar()
        Dim dsTabla As New DataSet
        dsTabla = objNumeroRegistro.Buscar(cboAño.Text)
        If dsTabla.Tables(0).Rows.Count > 0 Then
            txtCorrelativo.Text = dsTabla.Tables(0).Rows(0)("Numero")
            Oper = 2
            CodLocal = dsTabla.Tables(0).Rows(0)("IdNumero")
        Else
            MessageBox.Show("No existe Numeración para este año, Cuando Grabe se Procedera a crear con el Número 1", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCorrelativo.Text = 1
            Oper = 1
            CodLocal = ""
        End If
    End Sub

    Private Sub frmNumeroRegistro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboAño.Text = Date.Now.Year
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Guardar la Información", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objNumeroRegistro.Mantenimiento(codlocal, txtCorrelativo.Text, cboAño.Text, Oper)
        End If
        Me.Close()
    End Sub

    Private Sub cboAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAño.SelectedIndexChanged
        Buscar()
    End Sub
End Class