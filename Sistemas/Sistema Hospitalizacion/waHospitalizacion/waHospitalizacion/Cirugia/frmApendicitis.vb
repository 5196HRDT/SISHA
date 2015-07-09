Public Class frmApendicitis

    Private Sub Anamnesis_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDolorColicoVisceral.KeyPress, cboLocalizacionColico.KeyPress, txtTiempoInicioColico.KeyPress, cboTiempoInicioColico.KeyPress, cboDolorPermanenteSomatico.KeyPress, cboDolorPermanenteSomatico.KeyPress, cboLocalizacionSomatico.KeyPress, txtInicioDolorSomatico.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    ' Private Sub cboDolorPermanenteSomatico_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDolorPermanenteSomatico.KeyPress, cboDolorPermanenteSomatico.KeyPress, cboLocalizacionSomatico.KeyPress, txtInicioDolorSomatico.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '       e.Handled = True
    '      SendKeys.Send("{TAB}")
    ' End If
    'End Sub

    Private Sub cboHiporexia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHiporexia.KeyPress, cboNauseas.KeyPress, cboNauseas.KeyPress, txtNVomitos.KeyPress, cboFiebre.KeyPress, txtTiempoFiebre.KeyPress, txtIniciaFiebre.KeyPress, cboVomitos.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmApendicitis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class