Public Class frmHIS
    Dim objInformeEKG As New clsInformeEKG
    Dim objMedico As New clsMedico
    Dim objInterconsultaE As New clsInterconsultaE
    Dim objUbigeo As New clsUbigeo
    Dim objHistoria As New clsHistoria

    Private Sub frmHIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now

        'Medico Tratante
        Dim dsMedico As New DataSet
        dsMedico = objMedico.Medico_BuscarNombres("")
        cboMedico.DataSource = dsMedico.Tables(0)
        cboMedico.DisplayMember = "NMedico"
        cboMedico.ValueMember = "IdMedico"

        'Departamento
        Dim dsDpto As New Data.DataSet
        dsDpto = objUbigeo.Departamento
        cboDepartamento.DataSource = dsDpto.Tables(0)
        cboDepartamento.DisplayMember = "desc_dpto"
        cboDepartamento.ValueMember = "cod_dpto"
        cboDepartamento.Text = "LA LIBERTAD"
        cboDepartamento_SelectedIndexChanged(sender, e)

        cboMedico.Text = "CASOS FERNANDEZ ANA CRISTINA"
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        Dim I As Integer
        Dim Fila As ListViewItem
        dsVer = objInformeEKG.HIS(dtpFecha.Value.ToShortDateString)
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("Historia"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Paciente"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("FNacimiento").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Sexo"))
            If dsVer.Tables(0).Rows(I)("Departamento").ToString <> "" Then
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Departamento").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Provincia").ToString)
                Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Distrito").ToString)
            Else
                Fila.SubItems.Add("LA LIBERTAD")
                Fila.SubItems.Add("TRUJILLO")
                Fila.SubItems.Add("TRUJILLO")
            End If
            Fila.SubItems.Add("93000")
            Fila.SubItems.Add("Electrocardiograma")
            If dsVer.Tables(0).Rows(I)("TipoPaciente") <> "" Then Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("TipoPaciente")) Else Fila.SubItems.Add("COMUN")
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Doc_Identidad").ToString)
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("IdInforme"))
        Next
    End Sub

    Private Sub btnHIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHIS.Click
        If MessageBox.Show("Esta seguro de Generar HIS?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim CodCupo As String
            For I = 0 To lvTabla.Items.Count - 1
                CodCupo = objInterconsultaE.GrabarCodigo(dtpFecha.Value.ToShortDateString, Microsoft.VisualBasic.Left(dtpFecha.Value.ToShortTimeString, 5), lvTabla.Items(I).SubItems(0).Text, lvTabla.Items(I).SubItems(1).Text, "", "", "", "", "", "", "", "", "", lvTabla.Items(I).SubItems(7).Text, lvTabla.Items(I).SubItems(8).Text, "", "", "", "", "", "", "", cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text, cboDepartamento.SelectedValue & cboProvincia.SelectedValue & cboDistrito.SelectedValue, "NUEVO", "NUEVO", "ELECTROCARDIOGRAMA", cboMedico.Text, "DEFINITIVO", "", "", "", "", cboMedico.SelectedValue, "MAÑANA", "ELECTROCARDIOGRAMA", "", "", "", "", "", "", "", "", "", "", "", "", lvTabla.Items(I).SubItems(9).Text)
            Next
            MessageBox.Show("Proceso Generado Satisfactoriamente", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lvTabla.Items.Clear()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Esta seguro de Modificar Datos?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objInformeEKG.ModificarHIS(lvTabla.SelectedItems(0).SubItems(11).Text, txtEdad.Text & "A " & txtEdadM.Text & "M " & txtEdadD.Text & "D", cboTipo.Text)
            lvTabla.SelectedItems(0).SubItems(9).Text = cboTipo.Text
            objHistoria.GrabarUbigeo(lblHistoria.Text, cboDepartamento.Text, cboProvincia.Text, cboDistrito.Text)
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblHistoria.Text = ""
        dtpFecNac.Value = Date.Now
        cboSexo.Text = ""
        txtEdad.Text = ""
        cboTEdad.Text = ""
        txtEdadM.Text = ""
        cboTipoEM.Text = ""
        txtEdadD.Text = ""
        cboTipoED.Text = ""
        txtDNI.Text = ""
        cboDepartamento.Text = ""
        cboProvincia.Text = ""
        cboDistrito.Text = ""
        cboTipo.Text = ""
        btnAceptar.Enabled = False
    End Sub

    Private Sub CalcularEdad(ByVal FechaNac As Date)
        Dim EdadA As String
        Dim EdadM As String
        Dim EdadD As String
        EdadA = 0
        Dim Dias As Integer, Meses As Integer, Años As Integer
        Dim DiasMes As Integer
        Dim dfin, dinicio As Date
        dfin = dtpFecha.Value
        dinicio = FechaNac
        Dias = Microsoft.VisualBasic.DateAndTime.Day(dfin) - Microsoft.VisualBasic.DateAndTime.Day(dinicio)
        Meses = DatePart("m", dfin) - DatePart("m", dinicio)
        Años = DateDiff("yyyy", dinicio, dfin)
        'Verificar Dias
        If Meses = 0 And Años = 0 Then
            EdadA = 0
            EdadM = 0
            Dias = Math.Abs(Dias)
            EdadD = Dias
        Else
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
        End If
        txtEdad.Text = EdadA
        cboTEdad.Text = "A"
        txtEdadM.Text = EdadM
        cboTipoEM.Text = "M"
        txtEdadD.Text = EdadD
        cboTipoED.Text = "D"
    End Sub

    Private Sub lvTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTabla.SelectedIndexChanged
        If lvTabla.SelectedItems.Count > 0 Then
            lblHistoria.Text = lvTabla.SelectedItems(0).SubItems(0).Text
            dtpFecNac.Value = lvTabla.SelectedItems(0).SubItems(2).Text
            cboSexo.Text = lvTabla.SelectedItems(0).SubItems(3).Text

            CalcularEdad(lvTabla.SelectedItems(0).SubItems(2).Text)

            txtDNI.Text = lvTabla.SelectedItems(0).SubItems(10).Text
            cboDepartamento.Text = lvTabla.SelectedItems(0).SubItems(4).Text
            cboProvincia.Text = lvTabla.SelectedItems(0).SubItems(5).Text
            cboDistrito.Text = lvTabla.SelectedItems(0).SubItems(6).Text
            cboTipo.Text = lvTabla.SelectedItems(0).SubItems(9).Text
            btnAceptar.Enabled = True
        Else
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub cboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.SelectedIndexChanged
        If IsNumeric(cboDepartamento.SelectedValue) Then
            Dim dsProv As New Data.DataSet
            dsProv = objUbigeo.Provincia(cboDepartamento.SelectedValue)
            cboProvincia.DataSource = dsProv.Tables(0)
            cboProvincia.DisplayMember = "desc_prov"
            cboProvincia.ValueMember = "cod_prov"
            If cboDepartamento.Text = "LA LIBERTAD" Then cboProvincia.Text = "TRUJILLO" Else cboProvincia.Text = ""
        End If
    End Sub

    Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
        If IsNumeric(cboProvincia.SelectedValue) Then
            Dim dsDist As New Data.DataSet
            dsDist = objUbigeo.Distrito(cboDepartamento.SelectedValue, cboProvincia.SelectedValue)
            cboDistrito.DataSource = dsDist.Tables(0)
            cboDistrito.DisplayMember = "desc_dist"
            cboDistrito.ValueMember = "cod_dist"
            If cboProvincia.Text = "TRUJILLO" Then cboDistrito.Text = "TRUJILLO" Else cboDistrito.Text = ""
        End If
    End Sub
End Class