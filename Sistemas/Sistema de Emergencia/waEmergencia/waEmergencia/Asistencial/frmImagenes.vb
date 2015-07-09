Imports System.Data.SqlClient
Imports System.IO

Public Class frmImagenes
    Dim Cn As New SqlConnection
    Dim objDeposito As New DepositoImagen
    Dim objHistoria As New clsHistoria
    Dim CodLocal As String
    Dim I As Integer
    Dim Fila As ListViewItem

    Private Sub frmImagenes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpF1.Value = Date.Now
        dtpF2.Value = Date.Now

        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()

        dtpFecha.Value.ToShortDateString()
        btnSubir.Enabled = False
        btnCancelar.Enabled = False
        gbPaciente.Visible = False

        Me.Text = "DEPOSITO DE IMAGENES - Dr(a) " & NomMedico
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

    Public Sub CalcularEdad(FechaActual As Date, FechaNacimiento As Date)
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        Dim EdadA, EdadM, EdadD As String
        dfin = FechaActual
        dinicio = FechaNacimiento
        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        Años = DateDiff("yyyy", dinicio, dfin)

        If Meses = 0 And Años = 0 Then
            EdadA = 0
            EdadM = 0
            Dias = Math.Abs(Dias)
            EdadD = Dias
        Else
            'Verificar Dias
            If Dias < 0 Then
                DiasMes = Microsoft.VisualBasic.DateAndTime.Day(DateSerial(Year(dinicio), Month(dinicio) + 1, 0))
                Dias = (DiasMes - Microsoft.VisualBasic.DateAndTime.Day(dinicio)) + Microsoft.VisualBasic.DateAndTime.Day(dfin)
                Meses = Meses - 1
            End If
            If Meses < 0 Then
                Meses = 12 + Meses
                Años = Años - 1
            End If
            EdadA = Años
            EdadM = Meses
            EdadD = Dias

            EdadD = Microsoft.VisualBasic.Day(FechaNacimiento)
            If Val(EdadD) > FechaActual.Day Then
                EdadD = Val(EdadD) - FechaActual.Day
            ElseIf Val(EdadD) < FechaActual.Day Then
                If Val(EdadM) > 0 Then EdadM = Val(EdadM) - 1
                EdadD = FechaActual.Day - EdadD
                EdadD = DameDiasMes(FechaActual.Month) - EdadD
            Else
                EdadD = 0
            End If
        End If
        If Val(EdadA) > 0 Then
            lblEdad.Text = EdadA & " A"
        ElseIf Val(EdadM) > 0 Then
            lblEdad.Text = EdadM & " M"
        Else
            lblEdad.Text = EdadD & " D"
        End If
    End Sub

    Private Sub BuscarHistoria()
        Dim dsEC As New DataSet
        Dim dsHistorias As New DataSet
        dsHistorias = objHistoria.Buscar(txtHistoria.Text)
        If dsHistorias.Tables(0).Rows.Count > 0 Then
            lblPaciente.Text = dsHistorias.Tables(0).Rows(0)("Apaterno") & " " & dsHistorias.Tables(0).Rows(0)("Amaterno") & " " & dsHistorias.Tables(0).Rows(0)("Nombres")

            'Calcular Edad
            lblFNac.Text = dsHistorias.Tables(0).Rows(0)("FNacimiento")
            CalcularEdad(Date.Now.ToShortDateString, lblFNac.Text)

            lblSexo.Text = Microsoft.VisualBasic.Left(dsHistorias.Tables(0).Rows(0)("Sexo"), 1)
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            ListaImagenes()
            MessageBox.Show("Información Encontrada hasta al Fecha", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub btnExaminar_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar.Click
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

    Private Sub btnRetornar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornar.Click
        Me.Close()
    End Sub

    Private Sub txtTitulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTitulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtDescripcion.Select()
    End Sub

    Private Sub txtTitulo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTitulo.TextChanged

    End Sub

    Private Sub btnSubir_Click(sender As System.Object, e As System.EventArgs) Handles btnSubir.Click
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
            txtTitulo.Text = ""
            txtDescripcion.Text = ""
            txtComentario.Text = ""
            PictureBox1.Image = Nothing
            dtpFecha.Select()
            ListaImagenes()
        Catch sqlExc As SqlException
            MessageBox.Show(sqlExc.ToString, "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cn.Close()
        End Try
    End Sub

    Private Sub lvImagen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvImagen.KeyDown
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

    Private Sub lvImagen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvImagen.SelectedIndexChanged
        btnCancelar.Enabled = False
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
            btnCancelar.Enabled = True
        End If
    End Sub

    Private Sub dtpF1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF1.KeyDown
        If e.KeyCode = Keys.Enter Then dtpF2.Select()
    End Sub

    Private Sub dtpF1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF1.ValueChanged

    End Sub

    Private Sub dtpF2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpF2.KeyDown
        If e.KeyCode = Keys.Enter Then txtHistoria.Select()
    End Sub

    Private Sub dtpF2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpF2.ValueChanged

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles PictureBox1.DoubleClick
        frmVisor.pbImagen.Image = PictureBox1.Image
        frmVisor.Show()
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
    End Sub

    Private Sub btnBuscarP_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarP.Click
        gbPaciente.Visible = True
        lvPaciente.Items.Clear()
        txtPaciente.Text = ""
        txtPaciente.Select()
    End Sub

    Private Sub txtPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaciente.KeyDown
        If txtPaciente.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim dsVer As New DataSet
            dsVer = objHistoria.BuscarNombres(txtPaciente.Text)
            lvPaciente.Items.Clear()
            Dim I As Integer
            Dim Fila As ListViewItem
            For I = 0 To dsVer.Tables(0).Rows.Count - 1
                Fila = lvPaciente.Items.Add(dsVer.Tables(0).Rows(I)("HClinica"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Apaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Amaterno"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Nombres"))
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomPadre").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("NomMadre").ToString)
            Next
        End If
    End Sub

    Private Sub txtPaciente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPaciente.TextChanged

    End Sub

    Private Sub lvPaciente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvPaciente.KeyDown
        If e.KeyCode = Keys.Enter And lvPaciente.SelectedItems.Count > 0 Then
            txtHistoria.Text = lvPaciente.SelectedItems(0).SubItems(0).Text
            txtPaciente.Text = lvPaciente.SelectedItems(0).SubItems(1).Text & " " & lvPaciente.SelectedItems(0).SubItems(2).Text & " " & lvPaciente.SelectedItems(0).SubItems(3).Text
            gbPaciente.Visible = False
            txtHistoria_KeyDown(sender, e)
        End If
    End Sub

    Private Sub lvPaciente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPaciente.SelectedIndexChanged

    End Sub

    Private Sub s_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        ListaImagenes()
        MessageBox.Show("Información Encontrada hasta al Fecha", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        txtTitulo.Text = ""
        txtDescripcion.Text = ""
        txtComentario.Text = ""
        btnSubir.Enabled = False
        PictureBox1.Image = Nothing
        dtpFecha.Value = Date.Now
    End Sub
End Class