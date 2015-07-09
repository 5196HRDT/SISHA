Public Class frmMovimientosHosp
    Dim objHospitalizacion As New Hospitalizacion
    Dim objServicio As New Servicio
    Dim objSubServicio As New SubServicio
    Dim objEspecialidad As New Especialidad

    Private Sub frmMovimientosHosp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Servicio
        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Combo("%")
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdPiso"
    End Sub

    Private Sub cboServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServicio.TextChanged
        cboSubServicio.Text = ""
        cboEspecialidad.Text = ""
        If IsNumeric(cboServicio.SelectedValue) Then
            Dim dsSubServicio As New Data.DataSet
            dsSubServicio = objSubServicio.Combo(cboServicio.SelectedValue.ToString)
            cboSubServicio.DataSource = dsSubServicio.Tables(0)
            cboSubServicio.DisplayMember = "Descripcion"
            cboSubServicio.ValueMember = "IdSerHos"
        End If
    End Sub

    Private Sub cboSubServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubServicio.TextChanged
        cboEspecialidad.Text = ""
        If IsNumeric(cboSubServicio.SelectedValue) Then
            Dim dsEspecialidad As New Data.DataSet
            dsEspecialidad = objEspecialidad.Buscar(cboSubServicio.SelectedValue)
            cboEspecialidad.DataSource = dsEspecialidad.Tables(0)
            cboEspecialidad.DisplayMember = "Descripcion"
            cboEspecialidad.ValueMember = "IdEspecialidad"
        End If
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Dim dsVer As New DataSet
        Dim dsAlta As New DataSet
        Dim dsTransferencia As New DataSet
        Dim I As Integer
        Dim J As Integer
        Dim Fila As ListViewItem
        lvTabla.Items.Clear()
        dsVer = objHospitalizacion.BuscarIngrePacientes(dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString, cboServicio.Text, cboSubServicio.Text, cboEspecialidad.Text)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add("INGRESO")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("HClinica"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FecIngreso"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Servicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubServicio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdIngreso"))

            'Buscar Transferencia
            dsTransferencia = objHospitalizacion.BuscarTransferencias(dsVer.Tables(0).Rows(I)("IdIngreso"))
            For J = 0 To dsTransferencia.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add("TRASFERENCIA")
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("HClinica"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Apaterno"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Amaterno"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Nombres"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Fecha"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Servicio"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("SubServicio"))
                Fila.SubItems.Add(dsTransferencia.Tables(0).Rows(J)("Especialidad"))
                Fila.SubItems.Add("")
            Next


            'Buscar Alta de Paciente
            dsAlta = objHospitalizacion.BuscarEgresoPacientes(dsVer.Tables(0).Rows(I)("IdIngreso"))
            If dsAlta.Tables(0).Rows.Count > 0 Then
                Fila = lvTabla.Items.Add("ALTA")
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("HClinica"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Apaterno"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Amaterno"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Nombres"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Fecha"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Servicio"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("SubServicio"))
                Fila.SubItems.Add(dsAlta.Tables(0).Rows(0)("Especialidad"))
                Fila.SubItems.Add("")
            End If
        Next
    End Sub
End Class