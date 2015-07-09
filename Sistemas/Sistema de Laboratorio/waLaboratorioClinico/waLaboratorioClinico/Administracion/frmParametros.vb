Public Class frmParametros
    Dim objItem As New ItemServicio
    Dim objServicio As New Servicio

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsItem As New Data.DataSet
        dsItem = objItem.ProcedimientosClas("LABORATORIO", txtFiltro.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsItem.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsItem.Tables(0).Rows(I)("Id"))
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("ClasLaboratorio"))
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("Actividad"))
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("Emergencia").ToString)
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("UnicaVez").ToString)
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("Reservado"))
            If dsItem.Tables(0).Rows(I)("Parametros").ToString <> "" Then Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("Parametros")) Else Fila.SubItems.Add("")
            If dsItem.Tables(0).Rows(I)("Preparacion").ToString <> "" Then Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("Preparacion")) Else Fila.SubItems.Add("")
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("SIS").ToString)
            Fila.SubItems.Add(dsItem.Tables(0).Rows(I)("SOAT"))
            If dsItem.Tables(0).Rows(I)("Activo") = 1 Then Fila.SubItems.Add("SI") Else Fila.SubItems.Add("NO")
        Next
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Buscar("", 1)
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        Buscar()

        btnGrabar.Enabled = False
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Buscar()
    End Sub

    Private Sub lvTabla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If e.KeyCode = Keys.Enter And lvTabla.SelectedItems.Count > 0 Then cboServicio.Select()
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            lblId.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            cboServicio.Text = lvTabla.SelectedItems(0).SubItems(1).Text
            lblDescripcion.Text = lvTabla.SelectedItems(0).SubItems(2).Text
            cboEmergencia.Text = lvTabla.SelectedItems(0).SubItems(3).Text
            cboUnica.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            cboReservado.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            txtParametros.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            txtPreparacion.Text = lvTabla.SelectedItems(0).SubItems(7).Text
            cboSIS.Text = lvTabla.SelectedItems(0).SubItems(8).Text
            cboSOAT.Text = lvTabla.SelectedItems(0).SubItems(9).Text
            cboActivo.Text = lvTabla.SelectedItems(0).SubItems(10).Text
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub cboServicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboServicio.KeyDown
        If e.KeyCode = Keys.Enter And cboServicio.Text <> "" Then cboEmergencia.Select()
    End Sub

    Private Sub cboServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicio.SelectedIndexChanged

    End Sub

    Private Sub cboEmergencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboEmergencia.KeyDown
        If e.KeyCode = Keys.Enter And cboEmergencia.Text <> "" Then cboUnica.Select()
    End Sub

    Private Sub cboEmergencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmergencia.SelectedIndexChanged

    End Sub

    Private Sub cboUnica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUnica.KeyDown
        If e.KeyCode = Keys.Enter And cboUnica.Text <> "" Then cboReservado.Select()
    End Sub

    Private Sub cboUnica_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnica.SelectedIndexChanged

    End Sub

    Private Sub cboActivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboActivo.KeyDown
        If e.KeyCode = Keys.Enter And cboActivo.Text <> "" Then txtParametros.Select()
    End Sub

    Private Sub cboReservado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReservado.KeyDown
        If e.KeyCode = Keys.Enter And cboReservado.Text <> "" Then cboSIS.Select()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblId.Text = ""
        cboServicio.Text = ""
        lblDescripcion.Text = ""
        cboEmergencia.Text = ""
        cboUnica.Text = ""
        cboReservado.Text = ""
        cboActivo.Text = ""
        cboSIS.Text = ""
        cboSOAT.Text = ""
        txtParametros.Text = ""
        txtPreparacion.Text = ""
        btnGrabar.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim Activo As String
        If cboActivo.Text = "SI" Then Activo = 1 Else Activo = 0
        objItem.ActualizarParametros(lblId.Text, cboServicio.Text, cboReservado.Text, cboEmergencia.Text, cboUnica.Text, txtParametros.Text, txtPreparacion.Text, cboSIS.Text, cboSOAT.Text, Activo)

        lvTabla.SelectedItems(0).SubItems(1).Text = cboServicio.Text
        lvTabla.SelectedItems(0).SubItems(3).Text = cboEmergencia.Text
        lvTabla.SelectedItems(0).SubItems(4).Text = cboUnica.Text
        lvTabla.SelectedItems(0).SubItems(5).Text = cboReservado.Text
        lvTabla.SelectedItems(0).SubItems(6).Text = txtParametros.Text
        lvTabla.SelectedItems(0).SubItems(7).Text = txtPreparacion.Text
        lvTabla.SelectedItems(0).SubItems(8).Text = cboSIS.Text
        lvTabla.SelectedItems(0).SubItems(9).Text = cboSOAT.Text
        lvTabla.SelectedItems(0).SubItems(10).Text = cboActivo.Text

        btnCancelar_Click(sender, e)
    End Sub

    Private Sub cboReservado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReservado.SelectedIndexChanged

    End Sub

    Private Sub cboSIS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSIS.KeyDown
        If e.KeyCode = Keys.Enter And cboSIS.Text <> "" Then cboSOAT.Select()
    End Sub

    Private Sub cboSIS_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSIS.SelectedIndexChanged

    End Sub

    Private Sub cboSOAT_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSOAT.KeyDown
        If e.KeyCode = Keys.Enter And cboSOAT.Text <> "" Then cboActivo.Select()
    End Sub

    Private Sub cboSOAT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSOAT.SelectedIndexChanged

    End Sub
End Class