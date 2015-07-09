Imports System.IO
Public Class frmRadiologiaEco
    Dim objRayos As New clsRayos
    Dim objHistoria As New clsHistoria

    Dim Fecha As String
    Dim Informe As String

    Public Shared Function DameImagen(ByVal bytes() As Byte) As Image
        If bytes Is Nothing Then Return Nothing

        Dim ms As New MemoryStream(bytes)
        Dim bm As Bitmap = Nothing
        Try
            bm = New Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function

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
            lblDpto.Text = dsHistorias.Tables(0).Rows(0)("Departamento").ToString
            lblProvincia.Text = dsHistorias.Tables(0).Rows(0)("Provincia").ToString
            lblDistrito.Text = dsHistorias.Tables(0).Rows(0)("Distrito").ToString
        Else
            MessageBox.Show("Nro de Historia Clínica no Existe", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtHistoria.Text = ""
            txtHistoria.Select()
        End If
    End Sub

    Private Sub txtHistoria_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHistoria.KeyDown
        If IsNumeric(txtHistoria.Text) And e.KeyCode = Keys.Enter Then
            BuscarHistoria()
            If txtHistoria.Text = "" Then Exit Sub
            'Imagenes
            lvImg.Clear()
            Dim dsImg As New Data.DataSet
            dsImg = objRayos.BuscarCodigo(txtHistoria.Text)
            Dim K As Integer
            For K = 0 To dsImg.Tables(0).Rows.Count - 1
                If dsImg.Tables(0).Rows(K)("Imagen").ToString <> "" Then imgLista.Images.Add(K.ToString, DameImagen(dsImg.Tables(0).Rows(K)("Imagen")))
            Next
            lvImg.LargeImageList = imgLista

            For K = 0 To dsImg.Tables(0).Rows.Count - 1
                lvImg.Items.Add(Microsoft.VisualBasic.Left(dsImg.Tables(0).Rows(K)("Fecha"), 10) & "-" & dsImg.Tables(0).Rows(K)("Titulo"), K)
            Next
        End If
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

    Private Sub frmRadiologiaEco_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        gbPaciente.Visible = False

        Me.Text = "RADIOLOGIA - Dr(a) " & NomMedico
    End Sub

    Private Sub btnRetornarP_Click(sender As System.Object, e As System.EventArgs) Handles btnRetornarP.Click
        gbPaciente.Visible = False
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

    Private Sub txtHistoria_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHistoria.TextChanged

    End Sub

    Private Sub lvImg_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvImg.SelectedIndexChanged
        pbImg.Image = Nothing
        Dim Pos As Integer
        If lvImg.Items.Count > 0 Then
            Dim I As Integer
            For I = 0 To lvImg.Items.Count - 1
                If lvImg.Items(I).Selected Then
                    'pbImg.Image = lvImg.FocusedItem.ImageList.Images.Item(I)
                    Pos = I
                    Exit For
                End If
            Next
        End If
        Dim dsImg As New Data.DataSet
        dsImg = objRayos.BuscarCodigo(txtHistoria.Text)
        If dsImg.Tables(0).Rows(Pos)("Imagen").ToString <> "" Then pbImg.Image = DameImagen(dsImg.Tables(0).Rows(Pos)("Imagen"))
        Fecha = Microsoft.VisualBasic.Left(dsImg.Tables(0).Rows(Pos)("Fecha"), 10)
        Informe = dsImg.Tables(0).Rows(Pos)("Descripcion")
        txtInforme.Text = dsImg.Tables(0).Rows(Pos)("Descripcion")
    End Sub
End Class