Public Class frmDocumentoExt
    Dim objDocumento As New Documento
    Dim objAño As New NombreDelAnio
    Dim objTipoDoc As New TipoDocumento
    Dim objTrabajador As New Trabajador
    Dim objMotivoPase As New MotivoDelPAse
    Dim objCC As New ConCopia
    Dim objMotivoEnvio As New MotivoEnvio

    Dim I As Integer
    Dim NumeroDocumento As String
    Dim CodigoNumeracion As String
    Dim IdServiArea As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub NombreAño()
        Dim dsAño As New Data.DataSet
        dsAño = objAño.Nombre(dtpFecha.Value.Year)
        If dsAño.Tables(0).Rows.Count > 0 Then
            lblAño.Text = dsAño.Tables(0).Rows(0)("Detalle")
        Else
            lblAño.Text = ""
            MessageBox.Show("Nombre de Año no ha sido definido", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function VerificarPase() As Boolean
        VerificarPase = False
        For I = 0 To lvMotivo.Items.Count - 1
            If Val(lvMotivo.Items(I).SubItems(1).Text) = cboMotivoPase.SelectedValue Then
                VerificarPase = True
                MessageBox.Show("Motivo de pase ya fue asignado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            End If
        Next
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy")
        Botones(True, False, False, True)
        ControlesAD(Me, False)
        lvCC.Items.Clear()
        lvMotivo.Items.Clear()
        Limpiar(Me)
    End Sub

    Private Sub frmDocumentoExt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Tipo Documento
        Dim dsTipoDoc As New Data.DataSet
        dsTipoDoc = objTipoDoc.Buscar("")
        cboTipoDoc.DataSource = dsTipoDoc.Tables(0)
        cboTipoDoc.DisplayMember = "Descripcion"
        cboTipoDoc.ValueMember = "IdTipoDocumento"

        'Trabajador
        Dim dsTrabajador As New Data.DataSet
        dsTrabajador = objTrabajador.Combo("")
        cboTrabajador.DataSource = dsTrabajador.Tables(0)
        cboTrabajador.DisplayMember = "Nombres"
        cboTrabajador.ValueMember = "IdTrabajador"

        'Motivo de Pase
        Dim dsMotivo As New Data.DataSet
        dsMotivo = objMotivoPase.Combo
        cboMotivoPase.DataSource = dsMotivo.Tables(0)
        cboMotivoPase.DisplayMember = "Descripcion"
        cboMotivoPase.ValueMember = "IdMotivo"

    End Sub

    Private Sub cboTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTrabajador.KeyDown
        If IsNumeric(cboTrabajador.SelectedValue) And e.KeyCode = Keys.Enter Then txtAsunto.Select()
    End Sub

    Private Sub cboTrabajador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTrabajador.SelectedIndexChanged
        If IsNumeric(cboTrabajador.SelectedValue) Then
            Dim dsTrab As New Data.DataSet
            dsTrab = objTrabajador.BuscarID(cboTrabajador.SelectedValue.ToString)
            If dsTrab.Tables(0).Rows.Count > 0 Then
                Select Case dsTrab.Tables(0).Rows(0)("Cargo")
                    Case "JEFATURA"
                        If dsTrab.Tables(0).Rows(0)("ServArea") <> "DIRECCION EJECUTIVA" Then
                            lblA.Text = "JEFE(A)" & " DEL " & dsTrab.Tables(0).Rows(0)("ServArea") & " DEL HRDT"
                        Else
                            lblA.Text = "DIRECTOR EJECUTIVO DEL HRDT"
                        End If
                    Case Else
                        lblA.Text = dsTrab.Tables(0).Rows(0)("Cargo") & " DEL " & dsTrab.Tables(0).Rows(0)("ServArea") & " DEL HRDT"
                End Select
                IdServiArea = dsTrab.Tables(0).Rows(0)("IdServiArea")
            End If
        End If
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboTipoDoc.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        NombreAño()
    End Sub

    Private Sub txtAsunto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAsunto.KeyDown
        If txtAsunto.Text <> "" And e.KeyCode = Keys.Enter Then txtReferencia.Select()
    End Sub

    Private Sub txtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then txtCC.Select()
    End Sub

    'Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    '    If MessageBox.Show("Esta seguro de grabar documento externo", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Dim CodDocumento As String
    '        CodDocumento = objDocumento.Grabar(0, dtpFecha.Value.Year.ToString, cboTipoDoc.SelectedValue.ToString, NumeroDocumento, Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"),
    '                                           txtNumero.Text, txtD1.Text, txtD2.Text, cboTrabajador.Text, lblA.Text, txtAsunto.Text, txtReferencia.Text, "EXTERNO", IdServiArea,
    '                                           cboTrabajador.SelectedValue.ToString, "", CodigoServiArea)

    '        'Grabar Documento
    '        Dim Ruta As String
    '        Ruta = Microsoft.VisualBasic.Left(Application.ExecutablePath, Application.ExecutablePath.Length - 25) & "Documentos\" & cboTipoDoc.Text & " " & NumeroDocumento & dtpFecha.Value.Year.ToString & ".rtf"

    '        'Con Copia
    '        For I = 0 To lvCC.Items.Count - 1
    '            objCC.Mantenimiento(CodDocumento, lvCC.Items(I).SubItems(0).Text, lvCC.Items(I).SubItems(0).Text)
    '        Next

    '        'Motivo Envio
    '        For I = 0 To lvMotivo.Items.Count - 1
    '            objMotivoEnvio.Mantenimiento(CodDocumento, lvMotivo.Items(I).SubItems(1).Text)
    '        Next
    '        btnCancelar_Click(sender, e)
    '    End If
    'End Sub

    Private Sub lvCC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCC.KeyDown
        If lvCC.Items.Count > 0 Then
            For I = 0 To lvCC.Items.Count - 1
                If lvCC.Items(I).Selected Then
                    lvCC.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cboMotivoPase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMotivoPase.KeyDown
        If IsNumeric(cboMotivoPase.SelectedValue) And e.KeyCode = Keys.Enter Then
            If Not VerificarPase() Then
                Dim Fila As ListViewItem
                Fila = lvMotivo.Items.Add(cboMotivoPase.Text)
                Fila.SubItems.Add(cboMotivoPase.SelectedValue.ToString)
            End If
        End If
    End Sub

    Private Sub cboTipoDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDoc.KeyDown
        If IsNumeric(cboTipoDoc.SelectedValue) And e.KeyCode = Keys.Enter Then txtNumero.Select()
    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If txtNumero.Text <> "" And e.KeyCode = Keys.Enter Then txtD1.Select()
    End Sub

    Private Sub txtD1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtD1.KeyDown
        If txtD1.Text <> "" And e.KeyCode = Keys.Enter Then txtD2.Select()
    End Sub

    Private Sub txtD2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtD2.KeyDown
        If txtD2.Text <> "" And e.KeyCode = Keys.Enter Then cboTrabajador.Select()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        cboTipoDoc.Select()
    End Sub

    Private Sub txtCC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCC.KeyDown
        If txtCC.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Fila = lvCC.Items.Add(txtCC.Text)
            txtCC.Text = ""
            txtCC.Select()
        End If
    End Sub

    Private Sub lvMotivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvMotivo.KeyDown
        If lvMotivo.Items.Count > 0 Then
            For I = 0 To lvMotivo.Items.Count - 1
                If lvMotivo.Items(I).Selected Then
                    lvMotivo.Items.RemoveAt(I)
                    Exit For
                End If
            Next
        End If
    End Sub
End Class