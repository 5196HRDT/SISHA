Public Class frmApertura
    Dim objConvenio As New Convenio
    Dim objHistoria As New Historia
    Dim objTipoTarifa As New TipoTarifario
    Dim objEmergencia As New Emergencia
    Dim Equipo As String
    Dim CodLocal As String
    Dim Oper As String

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarH.Click
        NumeroHistoria = ""
        frmBuscarHistoria.Show()
    End Sub

    Private Sub frmApertura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        Dim dsCombo As New Data.DataSet
        dsCombo = objTipoTarifa.ComboConvenio
        cboTipoConvenio.DataSource = dsCombo.Tables(0)
        cboTipoConvenio.DisplayMember = "Descripcion"
        cboTipoConvenio.ValueMember = "IdTipoTarifa"

        Equipo = My.Computer.Name
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtpFecha.Value = Date.Now
        Botones(True, False, False, True)
        Limpiar(Me)
        lblAPaterno.Text = ""
        lblAMaterno.Text = ""
        lblNombres.Text = ""
        lblFecha.Text = ""
        lblSexo.Text = ""
        NumeroHistoria = ""
        btnBuscarH.Enabled = False
        btnAgregar.Enabled = False
        btnQuitar.Enabled = False
        ControlesAD(Me, False)
        lvCarta.Items.Clear()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnBuscarH.Enabled = True
        Oper = "1"
        txtHistoria.Select()
    End Sub

    Private Sub btnBuscarH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarH.GotFocus
        If NumeroHistoria.Length > 0 Then
            txtHistoria.Text = NumeroHistoria
            NumeroHistoria = ""
            Dim dsTabla As New Data.DataSet
            dsTabla = objHistoria.BuscarNumero(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FNacimiento")).ToString = "" Then
                    'MessageBox.Show("Paciente no tiene asignado fecha de nacimiento, comunicar a estadistica al Anexo 268", "Mensaje de Informacion, se asignara una fecha temporal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    lblFecha.Text = "01/01/2000"
                    lblEdad.Text = ""
                Else
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FNacimiento")
                    lblEdad.Text = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTabla.Tables(0).Rows(0)("FNacimiento"), Date.Now)
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")

                Dim dsVer As New Data.DataSet
                dsVer = objConvenio.Verificar(txtHistoria.Text)
                If dsVer.Tables(0).Rows.Count > 0 Then
                    Oper = 2

                    MessageBox.Show("Paciente tiene aperturado Convenio de " & dsVer.Tables(0).Rows(0)("TipoConvenio") & "  Nro: " & dsVer.Tables(0).Rows(0)("IdConvenio") & " el " & dsVer.Tables(0).Rows(0)("FechaRegistro"), "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    CodLocal = dsVer.Tables(0).Rows(0)("IdConvenio")
                    cboTipo.Text = dsVer.Tables(0).Rows(0)("Tipo")
                    txtCodigo.Text = dsVer.Tables(0).Rows(0)("Codigo")
                    cboTipoConvenio.Text = dsVer.Tables(0).Rows(0)("TipoConvenio")
                    btnAgregar.Enabled = True
                    btnQuitar.Enabled = False
                    'Cartas
                    Dim dsCarta As New Data.DataSet
                    Dim I As Integer
                    lvCarta.Items.Clear()
                    dsCarta = objConvenio.BuscarCarta(CodLocal)
                    Dim Fila As ListViewItem
                    For I = 0 To dsCarta.Tables(0).Rows.Count - 1
                        Fila = lvCarta.Items.Add(dsCarta.Tables(0).Rows(I)("IdCarta"))
                        Fila.SubItems.Add(dsCarta.Tables(0).Rows(I)("NroCarta"))
                        Fila.SubItems.Add(dsCarta.Tables(0).Rows(I)("FechaTermino"))
                        Fila.SubItems.Add(dsCarta.Tables(0).Rows(I)("Requerimiento"))
                        Fila.SubItems.Add(dsCarta.Tables(0).Rows(I)("Diagnostico"))
                        btnQuitar.Enabled = True
                    Next
                End If
                cboTipo.Select()
            Else
                MessageBox.Show("No Existe Historia Registrada", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                txtHistoria.Select()
            End If
            NumeroHistoria = ""
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtCarta.Text <> "" Then
            Dim Fila As ListViewItem
            Fila = lvCarta.Items.Add("")
            Fila.SubItems.Add(txtCarta.Text)
            Fila.SubItems.Add(dtpFTermino.Value)
            Fila.SubItems.Add(txtRequerimiento.Text)
            Fila.SubItems.Add(txtDiagnostico.Text)
            txtCarta.Text = ""
            txtRequerimiento.Text = ""
            txtDiagnostico.Text = ""
            dtpFTermino.Value = Date.Now
            btnQuitar.Enabled = True
            txtCarta.Select()
        Else
            MessageBox.Show("Debe ingresar Nro de Carta", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCarta.Select()
        End If
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If lvCarta.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar carta", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim I As Integer
                For I = 0 To lvCarta.Items.Count - 1
                    If lvCarta.Items(I).Selected Then lvCarta.Items.RemoveAt(I) : Exit For
                Next

                If lvCarta.Items.Count = 0 Then btnQuitar.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then cboTipoConvenio.Select()
    End Sub

    Private Sub txtCarta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarta.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFTermino.Select()
        End If
    End Sub

    Private Sub txtCarta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCarta.TextChanged
        If txtCarta.Text <> "" Then btnAgregar.Enabled = True Else btnAgregar.Enabled = False
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de grabar Apertura", "Mensaje de Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If cboTipoConvenio.Text = "PARSALUD" Then
                Dim dsVerCP As New DataSet
                dsVerCP = objConvenio.VerificarParsalud(txtCodigo.Text)
                If dsVerCP.Tables(0).Rows.Count > 0 Then MessageBox.Show("Codigo de PARSALUD ya fue Asignado al Paciente " & dsVerCP.Tables(0).Rows(0)("Apaterno") & " " & dsVerCP.Tables(0).Rows(0)("Amaterno") & " " & dsVerCP.Tables(0).Rows(0)("Nombres"), "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCodigo.Select() : Exit Sub
            End If

            If cboTipoConvenio.Text = "" Then MessageBox.Show("Debe Ingrear Tipo de Convenio", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Dim CodConvenio As String
            If Oper = 1 Then
                CodConvenio = objConvenio.Grabar(CodLocal, Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, Me.lblFecha.Text, lblEdad.Text, lblSexo.Text, txtCodigo.Text, Microsoft.VisualBasic.Format(dtpFTermino.Value, "dd/MM/yyyy"), cboTipo.Text, cboTipoConvenio.Text, cboTipoConvenio.SelectedValue.ToString)
            Else
                CodConvenio = CodLocal
                objConvenio.Modificar(CodLocal, Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), UsuarioSistema, txtHistoria.Text, lblAPaterno.Text, lblAMaterno.Text, lblNombres.Text, Me.lblFecha.Text, lblEdad.Text, lblSexo.Text, txtCodigo.Text, Microsoft.VisualBasic.Format(dtpFTermino.Value, "dd/MM/yyyy"), cboTipo.Text, cboTipoConvenio.Text, cboTipoConvenio.SelectedValue.ToString)
            End If
            objConvenio.EliminarCarta(CodConvenio)
            Dim I As Integer
            For I = 0 To lvCarta.Items.Count - 1
                objConvenio.GrabarCarta(CodConvenio, lvCarta.Items(I).SubItems(1).Text, lvCarta.Items(I).SubItems(2).Text, lvCarta.Items(I).SubItems(3).Text, lvCarta.Items(I).SubItems(4).Text)
            Next

            'Verificar Emergencia
            If cboTipo.Text = "EMERGENCIA" Then
                Dim dsVerE As New DataSet
                dsVerE = objEmergencia.VerificarEmergenciaIng(txtHistoria.Text)
                If dsVerE.Tables(0).Rows.Count > 0 Then
                    objEmergencia.ActualizarIngresoConvenio(dsVerE.Tables(0).Rows(0)("IdIngreso"), CodConvenio, cboTipoConvenio.Text)
                End If
            End If
            MessageBox.Show("Se ha creado el Registro de Convenio Nro: " & CodConvenio, "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If txtHistoria.Text <> "" And e.KeyCode = Keys.Enter Then
            NumeroHistoria = txtHistoria.Text
            btnBuscarH_GotFocus(sender, e)
        End If
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtCodigo.Select()
    End Sub

    Private Sub cboTipoConvenio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoConvenio.KeyDown
        If e.KeyCode = Keys.Enter And cboTipoConvenio.Text <> "" Then txtCarta.Select()
    End Sub

    Private Sub dtpFTermino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFTermino.KeyDown
        If e.KeyCode = Keys.Enter Then Me.txtRequerimiento.Select()
    End Sub

    Private Sub txtRequerimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequerimiento.KeyDown
        If e.KeyCode = Keys.Enter Then txtDiagnostico.Select()
    End Sub

    Private Sub txtDiagnostico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiagnostico.KeyDown
        If e.KeyCode = Keys.Enter And btnAgregar.Enabled Then btnAgregar.Select() Else btnGrabar.Select()
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub
End Class