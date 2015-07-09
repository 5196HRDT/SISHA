Imports System.IO
Imports System.Data.SqlClient
Public Class frmFormato
    Dim objFormato As New clsFormato
    Dim Oper As Integer
    Dim CodLocal As String

    Dim Nombre As String
    Dim Extension As String

    Dim fdlg As New OpenFileDialog
    Dim fs As System.IO.FileStream
    Dim mcorr_documento As Int32
    Dim bw As System.IO.BinaryWriter

    Private Sub Botones(Nuevo As Boolean, Subir As Boolean, Cancelar As Boolean, Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnSubir.Enabled = Subir
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub Buscar()
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objFormato.Buscar("")
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Tipo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Titulo"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Extension"))
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnSubir_Click(sender As System.Object, e As System.EventArgs) Handles btnSubir.Click
        If txtRuta.Text = "" Then MessageBox.Show("Debe seleccionar un archivo para subir", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If MessageBox.Show("Esta seguro de Subir Formato de Informe?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Myfile As System.IO.FileStream
            Myfile = System.IO.File.OpenRead(txtRuta.Text)
            Dim Arr(Myfile.Length) As Byte
            Myfile.Read(Arr, 0, Myfile.Length)

            objFormato.Mantenimiento(CodLocal, cboTipo.Text, txtTitulo.Text, "", Arr, Extension, Oper)
        End If
        Buscar()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Buscar()
    End Sub

    Private Sub frmFormato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnAbrir_Click(sender As System.Object, e As System.EventArgs) Handles btnAbrir.Click
        If oAbrir.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Nombre = System.IO.Path.GetFileName(oAbrir.FileName)
            Extension = System.IO.Path.GetExtension(oAbrir.FileName).Replace(".", "")
            txtRuta.Text = oAbrir.FileName
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Oper = 1
        ControlesAD(Me, True)
        Botones(False, True, True, False)
        cboTipo.Select()
    End Sub

    Private Sub lvTabla_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvTabla.KeyDown
        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Esta seguro de Eliminar Formato de Salud Mental?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objFormato.Eliminar(lvTabla.SelectedItems(0).SubItems(0).Text)
            End If
            Buscar()
        End If

        If lvTabla.SelectedItems.Count > 0 And e.KeyCode = Keys.Enter Then
            Extension = lvTabla.SelectedItems(0).SubItems(3).Text
            Dim dsTabla As DataSet
            dsTabla = objFormato.BuscarId(lvTabla.SelectedItems(0).SubItems(0).Text)
            Dim Archivo As Byte() = dsTabla.Tables(0).Rows(0)("Documento")

            Dim ExtensionNombre As String = Application.StartupPath() & "\Informe." & Extension
            Dim fs As System.IO.FileStream = New System.IO.FileStream(ExtensionNombre, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
            bw = New System.IO.BinaryWriter(fs)
            bw.Write(Archivo)
            bw.Flush()
            bw.Close()
            fs.Close()

            Dim Command As New Process
            Command.StartInfo.FileName = ExtensionNombre
            Command.StartInfo.UseShellExecute = True
            Command.StartInfo.CreateNoWindow = True
            Command.Start()
        End If
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        
    End Sub

    Private Sub cboTipo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then txtTitulo.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub txtTitulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTitulo.KeyDown
        If e.KeyCode = Keys.Enter And txtTitulo.Text <> "" Then btnAbrir.Select()
    End Sub

    Private Sub txtTitulo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTitulo.TextChanged

    End Sub
End Class