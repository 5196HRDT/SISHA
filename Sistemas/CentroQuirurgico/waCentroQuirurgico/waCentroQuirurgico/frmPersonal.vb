Public Class frmPersonal
    Dim objCargo As New Cargo
    Dim objPersonal As New Personal
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Buscar()
        lvDet.Items.Clear()
        Dim dsTabla As New Data.DataSet
        dsTabla = objPersonal.Buscar()
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            Fila = lvDet.Items.Add(dsTabla.Tables(0).Rows(I)("IdPersonal"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Cargo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Activo"))
        Next
    End Sub

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub frmPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cargo
        Dim dsCargo As New Data.DataSet
        dsCargo = objCargo.Buscar("Select * From CQCargo")
        cboCargo.DataSource = dsCargo.Tables(0)
        cboCargo.DisplayMember = "Descripcion"
        cboCargo.ValueMember = "IdCargo"

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        Buscar()
        lvDet.Enabled = True
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lvDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDet.SelectedIndexChanged
        If lvDet.Items.Count > 0 Then
            Oper = 2
            Botones(False, True, True, False)
            Activar(Me, True)
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    CodLocal = lvDet.Items(I).SubItems(0).Text
                    txtNombres.Text = lvDet.Items(I).SubItems(1).Text
                    cboCargo.Text = lvDet.Items(I).SubItems(2).Text
                    If lvDet.Items(I).SubItems(3).Text = 1 Then chkActivo.Checked = True Else chkActivo.Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Activo As String
        If chkActivo.Checked Then Activo = 1 Else Activo = 0
        objPersonal.Grabar(CodLocal, txtNombres.Text, cboCargo.SelectedValue.ToString, Activo, Oper)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        Botones(False, False, True, False)
        Activar(Me, True)
        txtNombres.Select()
        chkActivo.Checked = True
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged
        If txtNombres.Text <> "" Then btnGrabar.Enabled = True Else btnGrabar.Enabled = False
    End Sub
End Class