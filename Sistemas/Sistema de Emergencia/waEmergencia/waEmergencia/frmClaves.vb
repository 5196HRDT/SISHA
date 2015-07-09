Public Class frmClaves
    Dim objMedico As New clsMedico

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text <> txtRepetir.Text Then MessageBox.Show("La Nueva Clave y Repetir Clave deben ser IGUALES.... Intente Nuevamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Text = "" : txtRepetir.Text = "" : txtClave.Select() : Exit Sub
        If txtClave.Text = "" Then MessageBox.Show("Debe ingresar una clave", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtClave.Select() : Exit Sub
        objMedico.Medicos_CambiarClave(vIdMedico, txtClave.Text)
        MessageBox.Show("Se ha cambiado la clave correctamente, ingrese nuevamente con su clave modificada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Exit()
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtClave.Text) Then txtRepetir.Select()
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub txtRepetir_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRepetir.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtRepetir.Text) Then btnAceptar.Select()
    End Sub

    Private Sub txtRepetir_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRepetir.TextChanged

    End Sub

    Private Sub frmClaves_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class