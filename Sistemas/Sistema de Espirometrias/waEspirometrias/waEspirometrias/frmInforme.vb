Imports System.IO
Public Class frmInforme
    Dim objDeposito As New clsDepositoImagen
    Dim objCupo As New clsCupoEspirometria

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Subir As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnSubir.Enabled = Subir
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If cboTCita.Text = "" Then MessageBox.Show("Debe asignar un Turno", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : cboTCita.Select() : Exit Sub
        lvCita.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objCupo.Buscar(dtpFCita.Value.ToShortDateString, cboTCita.Text)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvCita.Items.Add(dsVer.Tables(0).Rows(I)("IdCita"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Edad"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdConsultaExa"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Indicacion").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("MedicoSol"))
        Next
    End Sub

    Private Sub lvCita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCita.SelectedIndexChanged
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblEdad.Text = ""
        lblSexo.Text = ""
        lblExamen.Text = ""
        lblTipoPaciente.Text = ""
        txtIndicacion.Text = ""
        lblSolicitado.Text = ""
        If lvCita.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvCita.SelectedItems(0).SubItems(5).Text
            lblPaciente.Text = lvCita.SelectedItems(0).SubItems(1).Text
            lblEdad.Text = lvCita.SelectedItems(0).SubItems(2).Text
            lblSexo.Text = lvCita.SelectedItems(0).SubItems(3).Text
            lblExamen.Text = lvCita.SelectedItems(0).SubItems(6).Text
            lblTipoPaciente.Text = lvCita.SelectedItems(0).SubItems(7).Text
            txtIndicacion.Text = lvCita.SelectedItems(0).SubItems(8).Text
            lblSolicitado.Text = lvCita.SelectedItems(0).SubItems(9).Text
            btnAbrir.Enabled = True
        Else
            btnAbrir.Enabled = False
        End If
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        With OpenFD
            .InitialDirectory = ""
            .Filter = "Archivos PDF|*.pdf"
            .FilterIndex = 2
        End With
        If OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            lblRuta.Tag = OpenFD.SafeFileName
            lblRuta.Text = OpenFD.FileName
        Else
            lblRuta.Text = ""
        End If
    End Sub

    Private Sub frmInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTCita.Text = "MAÑANA"
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub dtpFCita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFCita.KeyDown
        If e.KeyCode = Keys.Enter Then cboTCita.Select()
    End Sub

    Private Sub dtpFCita_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFCita.ValueChanged

    End Sub

    Private Sub cboTCita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTCita.KeyDown
        If e.KeyCode = Keys.Enter And cboTCita.Text <> "" Then btnMostrar.Select()
    End Sub

    Private Sub cboTCita_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTCita.SelectedIndexChanged

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Limpiar(Me)
        lblHistoria.Text = ""
        lblPaciente.Text = ""
        lblEdad.Text = ""
        lblSexo.Text = ""
        lblExamen.Text = ""
        lblTipoPaciente.Text = ""
        lblRuta.Text = ""
        lblSolicitado.Text = ""
        txtIndicacion.Text = ""
        btnAbrir.Enabled = False
        btnMostrar.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        btnMostrar.Enabled = True
        dtpFCita.Select()
    End Sub

    Private Sub btnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        If lblPaciente.Text = "" Then MessageBox.Show("Debe seleccionar un paciente citado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnSubir.Select() : Exit Sub
        If lblRuta.Text = "" Then MessageBox.Show("Debe seleccionar archivo a subir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : btnSubir.Select() : Exit Sub
        If MessageBox.Show("Esta seguro de Subir Archivo?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Archivo As FileStream
            Dim NomArchivo As String
            Dim TamArchivo As String

            NomArchivo = OpenFD.FileName
            TamArchivo = FileLen(NomArchivo)
            Archivo = New FileStream(NomArchivo, FileMode.Open, FileAccess.Read)
            Dim Imagen(TamArchivo) As Byte
            Archivo.Read(imagen, 0, TamArchivo)
            Archivo.Close()


            objDeposito.Grabar(Date.Now.ToShortDateString, lblExamen.Text, txtIndicacion.Text, lblHistoria.Text, lblPaciente.Text, lblSexo.Text, lblEdad.Text, Imagen, "", "PDF")
            btnCancelar_Click(sender, e)
        End If
    End Sub
End Class