Public Class frmDevolucionSIS
    Dim objReceta As New clsRecetaMedicaSIS
    Dim objDetalle As New clsRecetaMedicaSISDet
    Dim objBienServicio As New clsBienServicio

    Dim objSIS As New clsSIS

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then cboOrigen.Select()
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        Dim dsSIS As New DataSet
        dsVer = objReceta.BuscarDevolucion(txtPaciente.Text, cboOrigen.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdReceta"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaRegistro"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Medico"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SerieSIS"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NumeroSIS"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HoraRegistro"))
            'Buscar SIS
            dsSIS = objSIS.BuscarNroFormato(dsVer.Tables(0).Rows(I)("SerieSIS"), dsVer.Tables(0).Rows(I)("NumeroSIS"))
            If dsSIS.Tables(0).Rows.Count > 0 Then
                Fila.SubItems.Add(dsSIS.Tables(0).Rows(I)("IdSiS"))
            Else
                Fila.SubItems.Add(0)
            End If
        Next
    End Sub

    Private Sub cboOrigen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboOrigen.KeyDown
        If e.KeyCode = Keys.Enter And cboOrigen.Text <> "" Then btnMostrar.Select()
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged

    End Sub

    Private Sub frmDevolucionSIS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboOrigen.Text = "CONSULTA EXTERNA"
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lvDet.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            Dim dsDet As New DataSet
            dsDet = objDetalle.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
            If dsDet.Tables(0).Rows.Count > 0 Then
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsDet.Tables(0).Rows.Count - 1
                    Fila = lvDet.Items.Add(dsDet.Tables(0).Rows(I)("IdDetalle"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("CantAten"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Unidad"))
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("Descripcion"))
                    Fila.SubItems.Add("0")
                    Fila.SubItems.Add(dsDet.Tables(0).Rows(I)("IdMedicamento"))
                Next
            End If
        End If
    End Sub

    Private Sub lvDet_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If lvDet.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Dim Cantidad As String
            Cantidad = InputBox("Ingresar Cantidad a Devolver", "Datos de Devolución")
            If IsNumeric(Cantidad) Then
                If Val(Cantidad) > Val(lvDet.SelectedItems(0).SubItems(1).Text) Then MessageBox.Show("Cantidad a Devolver no puede ser mayor a la Atendida", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                lvDet.SelectedItems(0).SubItems(4).Text = Cantidad
            Else
                MessageBox.Show("Cantidad no es un valor numérico", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        lvDet.Items.Clear()
    End Sub

    Private Sub btnAtencion_Click(sender As System.Object, e As System.EventArgs) Handles btnAtencion.Click
        Dim Importe As String
        If lvDet.Items.Count = 0 Then MessageBox.Show("No existen Medicamentos para realizar atención de Farmacia, Seleccione un Paciente", "Mensaje de Información", MessageBoxButtons.OK) : Exit Sub
        If MessageBox.Show("Esta seguro de realizar atención de Farmacia?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                objDetalle.AtencionFarmacia(lvDet.Items(I).SubItems(0).Text, lvDet.Items(I).SubItems(6).Text)
                Importe = Val(lvDet.Items(I).SubItems(4).Text) * Val(lvDet.Items(I).SubItems(6).Text)
                objSIS.GrabarMedFechaHora(lvTabla.SelectedItems(0).SubItems(8).Text, lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(3).Text, lvDet.Items(I).SubItems(4).Text, lvDet.Items(I).SubItems(6).Text, Importe, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5))
                objBienServicio.ActStockBienServ(lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(6).Text)
                'objMedicamento.ActStockBienServ(lvDet.Items(I).SubItems(7).Text, lvDet.Items(I).SubItems(6).Text)
            Next
            objReceta.Atendido(lvTabla.SelectedItems(0).SubItems(0).Text, Date.Now.ToShortDateString, Date.Now.ToShortTimeString, UsuarioSistema, My.Computer.Name)

            'ppdDocumento.ShowDialog()

            btnCancelar_Click(sender, e)
            btnMostrar_Click(sender, e)
        End If
    End Sub
End Class