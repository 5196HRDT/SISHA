Imports System.IO
Public Class frmConsulta
    Dim objHistoria As New clsHistoria
    Dim objDeposito As New clsDepositoImagen

    Private Sub txtPaciente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        lvTabla.Items.Clear()
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsHistoria As New DataSet
            If IsNumeric(txtPaciente.Text) Then
                dsHistoria = objHistoria.Buscar(txtPaciente.Text)
            Else
                dsHistoria = objHistoria.BuscarPaciente(txtPaciente.Text)
            End If
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsHistoria.Tables(0).Rows.Count - 1
                Fila = lvTabla.Items.Add(dsHistoria.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsHistoria.Tables(0).Rows(I)("Apaterno") & " " & dsHistoria.Tables(0).Rows(I)("Amaterno") & " " & dsHistoria.Tables(0).Rows(I)("Nombres"))
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        lvEsp.Items.Clear()
        If lvTabla.SelectedItems.Count > 0 Then
            Dim dsEsp As New DataSet
            dsEsp = objDeposito.BuscarEspirometria(lvTabla.SelectedItems(0).SubItems(0).Text)
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsEsp.Tables(0).Rows.Count - 1
                Fila = lvEsp.Items.Add(dsEsp.Tables(0).Rows(I)("IdImagen"))
                Fila.SubItems.Add(dsEsp.Tables(0).Rows(I)("Fecha"))
                Fila.SubItems.Add(dsEsp.Tables(0).Rows(I)("Titulo"))
            Next
        End If
    End Sub

    Private Sub lvEsp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEsp.DoubleClick
        If lvEsp.SelectedItems.Count > 0 Then
            Dim dsVer As New DataSet
            dsVer = objDeposito.BuscarId(lvEsp.SelectedItems(0).SubItems(0).Text)
            If dsVer.Tables(0).Rows.Count > 0 Then
                Dim bw As System.IO.BinaryWriter
                Dim myread As SqlClient.SqlDataReader
                Try
                    myread = objDeposito.BuscarImagenReader(lvEsp.SelectedItems(0).SubItems(0).Text)
                    myread.Read()

                    If myread.HasRows Then
                        Dim filedata(myread.GetBytes(0, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                        myread.GetBytes(0, 0, filedata, 0, filedata.Length)
                        Dim myext As String = "pdf"
                        'Select Case myread(4)
                        '    Case "PDF"
                        '        myext = "pdf"
                        '    Case "WORD 2000-2003"
                        '        myext = "doc"
                        '    Case "WORD 2007-"
                        '        myext = "docx"
                        '    Case "JPG"
                        '        myext = "jpg"
                        '    Case "AVI"
                        '        myext = "avi"
                        '    Case Else
                        '        myext = "PDF"
                        'End Select
                        Dim ExtensionNombre As String = Application.StartupPath() & "\mydocumento." & myext
                        Dim fs As System.IO.FileStream = New System.IO.FileStream(ExtensionNombre, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        bw = New System.IO.BinaryWriter(fs)
                        bw.Write(filedata)
                        bw.Flush()
                        bw.Close()
                        fs.Close()
                        myread.Close()

                        'Abrir Documento
                        Dim Command As New Process
                        Command.StartInfo.FileName = ExtensionNombre
                        Command.StartInfo.UseShellExecute = True '''importantisimo esta propiedad permite buscar en el path del windows el programa asociado para ejecutar el archivo segun su tipo
                        'Para redirigir la salida de este proceso esta propiedad debe ser false
                        Command.StartInfo.CreateNoWindow = True
                        Command.Start()
                    End If
                Catch Exp As Exception
                    MessageBox.Show(Exp.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    myread.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub lvEsp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvEsp.KeyDown
        If lvEsp.SelectedItems.Count > 0 And e.KeyCode = Keys.Delete Then
            objDeposito.Eliminar(lvEsp.SelectedItems(0).SubItems(0).Text)
            lvEsp.Items.RemoveAt(lvEsp.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvEsp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEsp.SelectedIndexChanged

    End Sub
End Class