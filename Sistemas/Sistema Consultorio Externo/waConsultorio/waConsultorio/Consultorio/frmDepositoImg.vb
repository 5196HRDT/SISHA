Imports System.Data.SqlClient
Imports System.IO

Public Class frmDepositoImg
    Dim Cn As New SqlConnection
    Dim objDeposito As New DepositoImagen
    Dim objPaciente As New Historia
    Dim CodLocal As String
    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub frmDepositoImg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now

        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()

        dtpFecha.Value.ToShortDateString()
        btnSubir.Enabled = False
        btnAceptar.Enabled = False
    End Sub

    Private Sub ListaImagenes()
        Dim MyPhoto() As Byte
        If Cn.State = ConnectionState.Closed Then Cn.Open()

        Dim dsTabla As New Data.DataSet
        dsTabla = objDeposito.BuscarEF(txtHistoria.Text, dtpF1.Value.ToShortDateString, dtpF2.Value.ToShortDateString)
        lvImagen.Items.Clear()
        iLista.Images.Clear()
        lvImagen.View = View.LargeIcon
        lvImagen.LargeImageList = iLista

        Dim dsImagen As New DataSet
        For I = 0 To dsTabla.Tables(0).Rows.Count - 1
            dsImagen = objDeposito.BuscarImagen(dsTabla.Tables(0).Rows(I)("IdImagen"))
            MyPhoto = CType(dsImagen.Tables(0).Rows(0)("Imagen"), Byte())
            Dim ms As New MemoryStream(MyPhoto)
            iLista.Images.Add(I.ToString, Image.FromStream(ms))

            Fila = lvImagen.Items.Add(dsTabla.Tables(0).Rows(I)("Fecha"), I)
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("Titulo"))
            Fila.SubItems.Add(dsTabla.Tables(0).Rows(I)("IdImagen"))
        Next
    End Sub

    Private Sub txtHistoria_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtHistoria.Invalidated

    End Sub

    Private Sub txtHistoria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            Dim dsPac As New Data.DataSet

            dsPac = objPaciente.BuscarHistoria(txtHistoria.Text)
            If dsPac.Tables(0).Rows.Count > 0 Then
                lblPaciente.Text = dsPac.Tables(0).Rows(0)("Apaterno") & " " & dsPac.Tables(0).Rows(0)("AMaterno") & " " & dsPac.Tables(0).Rows(0)("Nombres")
                lblSexo.Text = dsPac.Tables(0).Rows(0)("Sexo")

                Dim Edad As String
                Dim Año As String
                Dim Mes As String
                Dim Dia As String

                If dsPac.Tables(0).Rows(0)("FNacimiento").ToString <> "" Then
                    If Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) > 0 Then
                        If Microsoft.VisualBasic.Month(dsPac.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Month Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                        Else
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now)) - 1 & " A " & " y " & Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M"
                        End If
                    Else
                        If Microsoft.VisualBasic.Day(dsPac.Tables(0).Rows(0)("FNAcimiento")) < Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y " & 30 - (Date.Now.Day - Microsoft.VisualBasic.Day(dsPac.Tables(0).Rows(0)("FNacimiento"))) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsPac.Tables(0).Rows(0)("FNAcimiento")) > Date.Now.Day Then
                            Edad = (Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12) - 1 & " M y " & 30 - (Microsoft.VisualBasic.Day(dsPac.Tables(0).Rows(0)("FNacimiento")) - Date.Now.Day) & " D"
                        ElseIf Microsoft.VisualBasic.Day(dsPac.Tables(0).Rows(0)("FNAcimiento")) = Date.Now.Day Then
                            Edad = Microsoft.VisualBasic.DateDiff(DateInterval.Month, dsPac.Tables(0).Rows(0)("FNacimiento"), Date.Now) Mod 12 & " M y 0 D"
                        End If
                    End If
                End If
                lblEdad.Text = Edad
                ListaImagenes()
                MessageBox.Show("Información Encontrada hasta al Fecha", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Paciente se encontro en la base de datos del HRDT", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblPaciente.Text = ""
                txtHistoria.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        btnSubir.Enabled = False
        With OpenFD
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With
        If OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PictureBox1
                .Image = Image.FromFile(OpenFD.FileName)
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
                txtTitulo.Select()
                btnSubir.Enabled = True
            End With
        End If

    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        Me.Close()
    End Sub

    Private Sub txtTitulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtDescripcion.Select()
    End Sub

    Private Sub btnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        Try
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Dim arrFilename() As String = Split(Text, "\")
            Array.Reverse(arrFilename)

            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer

            Dim cmd As New SqlCommand("Insert Into DepositoImagen(Fecha, Titulo, Descripcion, Historia, Paciente, Sexo, Edad, Imagen, Comentario)Values(@Fecha, @Titulo, @Descripcion, @Historia, @Paciente, @Sexo, @Edad, @Imagen, @Comentario)", Cn)
            With cmd
                .Parameters.Add(New SqlParameter("@Fecha", SqlDbType.SmallDateTime)).Value = dtpFecha.Value.ToShortDateString
                .Parameters.Add(New SqlParameter("@Titulo", SqlDbType.VarChar)).Value = txtTitulo.Text
                .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = txtDescripcion.Text
                .Parameters.Add(New SqlParameter("@Historia", SqlDbType.VarChar)).Value = txtHistoria.Text
                .Parameters.Add(New SqlParameter("@Paciente", SqlDbType.VarChar)).Value = lblPaciente.Text
                .Parameters.Add(New SqlParameter("@Sexo", SqlDbType.VarChar)).Value = lblSexo.Text
                .Parameters.Add(New SqlParameter("@Edad", SqlDbType.VarChar)).Value = lblEdad.Text
                .Parameters.Add(New SqlParameter("@Imagen", SqlDbType.Image)).Value = arrImage
                .Parameters.Add(New SqlParameter("@Comentario", SqlDbType.VarChar)).Value = txtComentario.Text
            End With
            MessageBox.Show("Registro Insertado Correctamente")
            cmd.ExecuteNonQuery()

            txtDescripcion.Text = ""
            txtComentario.Text = ""
            PictureBox1.Image = Nothing
            dtpFecha.Select()
        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cn.Close()
        End Try
    End Sub

    Private Sub lvImagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvImagen.KeyDown
        If e.KeyCode = Keys.Delete And lvImagen.SelectedItems.Count > 0 Then
            If MessageBox.Show("Esta seguro de Eliminar Datos de Imagen", "Mensaje de Consulta", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                objDeposito.Eliminar(lvImagen.SelectedItems(0).SubItems(2).Text)
                lvImagen.Items.RemoveAt(lvImagen.SelectedItems(0).Index)
                Limpiar(Me)
                PictureBox1.Image = Nothing
                txtHistoria_KeyDown(sender, e)
            End If
        End If
    End Sub

    Private Sub lvImagen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvImagen.SelectedIndexChanged
        btnAceptar.Enabled = False
        If lvImagen.SelectedItems.Count > 0 Then
            Dim MyPhoto() As Byte
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            Dim dsImagen As New DataSet
            dsImagen = objDeposito.BuscarImagen(lvImagen.SelectedItems(0).SubItems(2).Text)
            MyPhoto = CType(dsImagen.Tables(0).Rows(0)("Imagen"), Byte())
            Dim ms As New MemoryStream(MyPhoto)
            Me.PictureBox1.Image = Image.FromStream(ms)

            Dim dsT As New Data.DataSet
            dsT = objDeposito.BuscarId(lvImagen.SelectedItems(0).SubItems(2).Text)
            dtpFecha.Value = dsT.Tables(0).Rows(0)("Fecha")
            txtTitulo.Text = dsT.Tables(0).Rows(0)("Titulo")
            txtDescripcion.Text = dsT.Tables(0).Rows(0)("Descripcion")
            txtComentario.Text = dsT.Tables(0).Rows(0)("Comentario")
            CodLocal = dsT.Tables(0).Rows(0)("IdImagen")
            btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'objDeposito.Buscar()
    End Sub

    Private Sub dtpF1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then txtHistoria.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub txtHistoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        frmVisor.pbImagen.Image = PictureBox1.Image
        frmVisor.Show()
    End Sub
End Class