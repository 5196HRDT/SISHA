Public Class frmTamizajeSIS
    Dim objSIS As New clsSIS
    Dim objConsulta As New clsConsultaExterna
    Dim objHistoria As New clsHistoria
    Dim objGrupoSanguineo As New clsGrupoSanguineo
    Dim objTipoPacienteHIS As New clsTipoPacienteHIS


    'Variables Impresion
    Dim Fuente20N As New Font("Courier New", 20, FontStyle.Bold)
    Dim Fuente12N As New Font("Courier New", 12, FontStyle.Bold)
    Dim Fuente10 As New Font("Courier New", 10, FontStyle.Bold)
    Dim Fuente8 As New Font("Courier New", 8, FontStyle.Bold)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim Y As Integer
    Dim X As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        lvSIS.Items.Clear()
        If e.KeyCode = Keys.Enter And txtPaciente.Text <> "" Then
            Dim dsVer As New DataSet
            Dim Prenatal As String = "NO"
            dsVer = objSIS.BuscarNombresFormato(txtPaciente.Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                Dim I As Integer
                Dim Fila As ListViewItem
                For I = 0 To dsVer.Tables(0).Rows.Count - 1
                    Fila = lvSIS.Items.Add(dsVer.Tables(0).Rows(I)("HEI"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Lote"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Numero"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
                    If dsVer.Tables(0).Rows(I)("Peso") <> "" Then Prenatal = "SI" Else Prenatal = "NO"
                    Fila.SubItems.Add(Prenatal)
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Especialidad"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("SubEspecialidad"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdSIS"))
                    Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FechaVtoContrato").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged
        If txtPaciente.Text = "" Then lblPaciente.Text = "" : cboTipo.Text = ""
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        lvSIS.Items.Clear()
        lvTabla.Items.Clear()
        lvPostulante.Items.Clear()
        ControlesAD(Me, False)
        Botones(True, False, False, True)

    End Sub

    Private Sub frmTamizajeSIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Grupo Sanguineo
        Dim dsGrupo As New DataSet
        dsGrupo = objGrupoSanguineo.Combo
        cboGrupo.DataSource = dsGrupo.Tables(0)
        cboGrupo.DisplayMember = "Descripcion"
        cboGrupo.ValueMember = "IdGrupoSanguineo"

        'Tipo Paciente HIS
        Dim dsTipoPaciente As New DataSet
        dsTipoPaciente = objTipoPacienteHIS.Combo
        cboTipo.DataSource = dsTipoPaciente.Tables(0)
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.ValueMember = "IdTipo"
    End Sub

    Private Sub Cargar()
        lvTabla.Items.Clear()
        Dim Cant As String
        Cant = InputBox("Ingresar Cantidad de Pruebas", "Datos de Tamizaje")
        If Not IsNumeric(Cant) Then MessageBox.Show("Ingresar un valor válido", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        Dim Fila As ListViewItem
        Dim Importe As Double

        Fila = lvTabla.Items.Add("4970")
        Fila.SubItems.Add("GRUPO SANGUINEO Y FACTOR RH")
        Fila.SubItems.Add("6.00")
        Fila.SubItems.Add(Cant)
        Importe = 6 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("HEMATOLOGIA")

        Fila = lvTabla.Items.Add("4971")
        Fila.SubItems.Add("HEMATOCRITO (INCLUYE AGUJA)")
        Fila.SubItems.Add("1.15")
        Fila.SubItems.Add(Cant)
        Importe = 1.15 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("HEMATOLOGIA")

        Fila = lvTabla.Items.Add("4983")
        Fila.SubItems.Add("PRUEBA CRUZADA")
        Fila.SubItems.Add("3.93")
        Fila.SubItems.Add(Cant)
        Importe = 3.93 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("BANCO DE SANGRE")

        Fila = lvTabla.Items.Add("5283")
        Fila.SubItems.Add("ANTICORE TOTAL")
        Fila.SubItems.Add("17.22")
        Fila.SubItems.Add(Cant)
        Importe = 17.22 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("BANCO DE SANGRE")

        Fila = lvTabla.Items.Add("5066")
        Fila.SubItems.Add("ANTIGENO DE SUPERFICIE PARA HEPATITIS B")
        Fila.SubItems.Add("11.00")
        Fila.SubItems.Add(Cant)
        Importe = 11.0 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("BANCO DE SANGRE")

        Fila = lvTabla.Items.Add("4962")
        Fila.SubItems.Add("CHAGAS")
        Fila.SubItems.Add("18.00")
        Fila.SubItems.Add(Cant)
        Importe = 18.0 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("INMUNOLOGIA")

        Fila = lvTabla.Items.Add("4975")
        Fila.SubItems.Add("HEPATITIS C (ANTICUERPO)")
        Fila.SubItems.Add("24.36")
        Fila.SubItems.Add(Cant)
        Importe = 24.36 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("BANCO DE SANGRE")

        Fila = lvTabla.Items.Add("4977")
        Fila.SubItems.Add("HIV POR ELISA")
        Fila.SubItems.Add("17.22")
        Fila.SubItems.Add(Cant)
        Importe = 17.22 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("BANCO DE SANGRE")


        Fila = lvTabla.Items.Add("4978")
        Fila.SubItems.Add("HTVL1")
        Fila.SubItems.Add("8.00")
        Fila.SubItems.Add(Cant)
        Importe = 8.0 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("INMUNOLOGIA")

        Fila = lvTabla.Items.Add("4984")
        Fila.SubItems.Add("RPR")
        Fila.SubItems.Add("3.00")
        Fila.SubItems.Add(Cant)
        Importe = 3.0 * Cant
        Fila.SubItems.Add(Format(Importe, "#0.00"))
        Fila.SubItems.Add("INMUNOLOGIA")

        txtPaciente.Select()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        cboOrigen.Text = "HOSPITALIZACION"
        Cargar()

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboGrupo.Text = "" Then MessageBox.Show("Debe ingresar el Grupo Sanguineo del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboGrupo.Select() : Exit Sub
        If lblPostulante.Text = "" Then MessageBox.Show("Debe seleccionar al Postulante", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPostulante.Select() : Exit Sub
        If cboOrigen.Text = "" Then MessageBox.Show("Debe seleccionar el Origen del Paciente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboOrigen.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Grabar Información de Tamizaje?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim I As Integer
            'If MessageBox.Show("Se procedera a registrar los datos del postulante para el ingreso de sus resultado de un paciente NO SIS. Desea Continuar?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            For I = 0 To lvTabla.Items.Count - 1
                If lblPaciente.Text <> "" Then
                    objSIS.GrabarProcedimientosAtendidos(lvSIS.SelectedItems(0).SubItems(8).Text, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, UsuarioSistema, My.Computer.Name)
                    objConsulta.GrabarExaSISOrigen(0, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.Items(I).SubItems(5).Text, "POSTULANTE-SIS", 0, lvSIS.SelectedItems(0).SubItems(1).Text, lvSIS.SelectedItems(0).SubItems(2).Text, lvPostulante.SelectedItems(0).SubItems(0).Text, lvPostulante.SelectedItems(0).SubItems(1).Text, lvSIS.SelectedItems(0).SubItems(7).Text, "", cboOrigen.Text)
                Else
                    objConsulta.GrabarExaSISOrigen(0, lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, lvTabla.Items(I).SubItems(2).Text, lvTabla.Items(I).SubItems(3).Text, lvTabla.Items(I).SubItems(4).Text, Date.Now.ToShortDateString, Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5), UsuarioSistema, My.Computer.Name, "LABORATORIO", lvTabla.Items(I).SubItems(5).Text, "POSTULANTE", 0, "", 0, lvPostulante.SelectedItems(0).SubItems(0).Text, lvPostulante.SelectedItems(0).SubItems(1).Text, "POSTULANTE", "", cboOrigen.Text)
                End If
            Next
            ppdDocumento.ShowDialog()
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub txtPostulante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPostulante.KeyDown
        lvPostulante.Items.Clear()
        If txtPostulante.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim I As Integer
            Dim Fila As ListViewItem
            Dim dsHistoria As New DataSet

            dsHistoria = objHistoria.BuscarPaciente(txtPostulante.Text)
            For I = 0 To dsHistoria.Tables(0).Rows.Count - 1
                Fila = lvPostulante.Items.Add(dsHistoria.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Apaterno").ToString & " " & dsHistoria.Tables(0).Rows(I)("Amaterno").ToString & " " & dsHistoria.Tables(0).Rows(I)("Nombres").ToString)
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Doc_Identidad").ToString)
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Direccion").ToString)
            Next
        End If
    End Sub

    Private Sub txtPostulante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostulante.TextChanged
        If txtPostulante.Text = "" Then lblPostulante.Text = ""
    End Sub

    Private Sub lvSIS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSIS.SelectedIndexChanged
        If lvSIS.SelectedItems.Count > 0 Then
            lblPaciente.Text = lvSIS.SelectedItems(0).SubItems(4).Text
            cboTipo.Text = "SIS"
        Else
            lblPaciente.Text = ""
        End If
    End Sub

    Private Sub lvPostulante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPostulante.SelectedIndexChanged
        If lvPostulante.SelectedItems.Count > 0 Then
            lblPostulante.Text = lvPostulante.SelectedItems(0).SubItems(1).Text
        Else
            lblPostulante.Text = ""
        End If
    End Sub

    Private Sub Cabecera(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        With e.Graphics
            .DrawString("CENTRO DE HEMOTERAPIA TIPO II", Fuente10, Pincel, 20, Y)
            Y = Y + 15
            .DrawString(" Registro 13-1301-197 HRDT", Fuente10, Pincel, 20, Y)
            Y = Y + 25
            .DrawString("Postulante: ", Fuente10, Pincel, 20, Y)
            Y = Y + 15
            .DrawString(lblPostulante.Text, Fuente10, Pincel, 20, Y)
            Y = Y + 15
            .DrawString("Historia: " & lvPostulante.SelectedItems(0).SubItems(0).Text & " Tipo: " & cboTipo.Text, Fuente10, Pincel, 20, Y)
            Y = Y + 15
            If lblPaciente.Text <> "" Then
                .DrawString("Paciente SIS: ", Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString(lblPaciente.Text, Fuente10, Pincel, 20, Y)
                Y = Y + 15
                .DrawString("Formato: " & lvSIS.SelectedItems(0).SubItems(1).Text & "-" & lvSIS.SelectedItems(0).SubItems(2).Text, Fuente10, Pincel, 20, Y)
                Y = Y + 15
            End If
            .DrawString("Gs Y FRH: " & cboGrupo.Text, Fuente10, Pincel, 20, Y)
            Y = Y + 15
            .DrawString("Origen: " & cboOrigen.Text, Fuente10, Pincel, 20, Y)
            Y = Y + 15
            .DrawString("Fecha: " & Date.Now, Fuente10, Pincel, 20, Y)
            Y = Y + 15

        End With
    End Sub

    Private Sub pdDocumento_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles pdDocumento.BeginPrint
        Y = 0
    End Sub

    Private Sub pdDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdDocumento.PrintPage
        Y = 40
        With e.Graphics
            Cabecera(e)

            e.HasMorePages = False
        End With
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class