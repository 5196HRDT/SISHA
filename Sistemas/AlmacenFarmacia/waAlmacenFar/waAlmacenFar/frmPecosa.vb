Public Class frmPecosa
    Dim objParametro As New Parametro
    Dim objMedicamento As New Medicamento
    Dim objPecosa As New Pecosa
    Dim Oper As String

    'Variables Impresion
    Dim Fuente As New Font("Courier New", 14, FontStyle.Bold)
    Dim FuenteE As New Font("Courier New", 12)
    Dim Pincel As New SolidBrush(Color.Black)
    Dim AltoTexto As Integer
    Dim PosicionFila As Integer
    Dim X, Y As Integer

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPecosa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)

        'Llenar Combo
        Dim dsTabla As New Data.DataSet
        dsTabla = objMedicamento.BuscarPecosa
        cboMedicamento.DataSource = dsTabla.Tables(0)
        cboMedicamento.DisplayMember = "Descripcion"
        cboMedicamento.ValueMember = "BienServ"

        dtpFecha.Value = Date.Now
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Activar(Me, True)
        lblNumero.Text = objParametro.DameValor("CORRELATIVO PECOSA FARMACIA")
        txtSolicitante.Select()
        Botones(False, False, True, False)
        cboTipo.Text = "SISMED"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)
        Activar(Me, False)
        Botones(True, False, False, True)
        lvDet.Items.Clear()
    End Sub

    Private Sub txtSolicitante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitante.KeyDown
        If e.KeyCode = Keys.Enter And txtSolicitante.Text.Length > 0 Then cboTipo.Select()
    End Sub

    Private Sub cboTipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipo.KeyDown
        If e.KeyCode = Keys.Enter And cboTipo.Text <> "" Then cboMedicamento.Select()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

    End Sub

    Private Sub cboMedicamento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMedicamento.KeyDown
        If e.KeyCode = Keys.Enter Then

            txtCantidad.Select()
        End If
    End Sub

    Private Sub cboMedicamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedicamento.SelectedIndexChanged
        If cboMedicamento.SelectedValue.ToString <> "System.Data.DataRowView" Then
            lblUnidad.Text = ""
            Dim dsTabla As New Data.DataSet
            dsTabla = objMedicamento.BuscarMedPec(cboMedicamento.SelectedValue)
            If dsTabla.Tables(0).Rows.Count > 0 Then lblUnidad.Text = dsTabla.Tables(0).Rows(0)("Unidad")
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter And IsNumeric(txtCantidad.Text) Then
            Dim Fila As ListViewItem
            Fila = lvDet.Items.Add(lvDet.Items.Count + 1)
            Fila.SubItems.Add(cboMedicamento.Text)
            Fila.SubItems.Add(lblUnidad.Text)
            Fila.SubItems.Add(txtCantidad.Text)
            Fila.SubItems.Add(cboMedicamento.SelectedValue)
            lblUnidad.Text = ""
            txtCantidad.Text = ""
            cboMedicamento.Select()
            btnGrabar.Enabled = True
        End If
    End Sub

    Private Sub lvDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDet.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim I As Integer
            For I = 0 To lvDet.Items.Count - 1
                If lvDet.Items(I).Selected Then
                    If MessageBox.Show("Esta seguro de Eliminar Medicamento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        lvDet.Items(I).Remove()
                        If lvDet.Items.Count = 0 Then btnGrabar.Enabled = False
                        Exit For
                    End If
                End If
            Next
            For I = 0 To lvDet.Items.Count - 1
                lvDet.Items(I).SubItems(0).Text = I + 1
            Next
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        'If MessageBox.Show("Esta Seguro de Grabar los Datos de Pecosa", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    objPecosa.Grabar(dtpFecha.Value, lblNumero.Text, txtSolicitante.Text, cboTipo.Text)
        '    Dim I As Integer
        '    For I = 0 To lvDet.Items.Count - 1
        '        objPecosa.GrabarDetalle(lblNumero.Text, lvDet.Items(I).SubItems(4).Text, lvDet.Items(I).SubItems(1).Text, lvDet.Items(I).SubItems(2).Text, lvDet.Items(I).SubItems(3).Text)
        '    Next
        'End If
        ppdVistaPrevia.ShowDialog()
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub pdcDocumento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdcDocumento.PrintPage
        AltoTexto = e.Graphics.MeasureString("A", Fuente).Height
        Dim I As Integer
        Dim Filas As Integer = 0
        Y = 20
        Filas = 10

        Y = Y + 10
        With e.Graphics
            .DrawString("HOSPITAL REGIONAL DOCENTE DE TRUJILLO", FuenteE, Pincel, 60, Y)

            Y = Y + 20
            .DrawString("PEDIDO PROVISIONAL DE MEDICAMENTOS", Fuente, Pincel, 180, Y)
            Y = Y + 20
            .DrawString("DEL ALMACEN ESPECIALIZADO", Fuente, Pincel, 240, Y)
            Y = Y + 40
            .DrawString("Solicitante: " & txtSolicitante.Text & StrDup(10, " ") & "Fecha de Emisión: " & Microsoft.VisualBasic.Left(dtpFecha.Value, 10), FuenteE, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Tipo       : " & cboTipo.Text, FuenteE, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Origen     : " & "Almacén Especializado de Medicamentos", FuenteE, Pincel, 40, Y)
            Y = Y + 20
            .DrawString("Destino    : " & "Dispensación", FuenteE, Pincel, 40, Y)
            Y = Y + 30
            .DrawString(StrDup(3, " ") & "Nro" & StrDup(11, " ") & "DESCRIPCION" & StrDup(28, " ") & "FORMA" & StrDup(4, " ") & "CANTIDAD", FuenteE, Pincel, 14, Y)
            Y = Y + 20
            For I = 0 To lvDet.Items.Count - 1
                .DrawString(StrDup(4, " ") & Microsoft.VisualBasic.Right("00" & (I + 1).ToString, 2) & StrDup(4, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(1).Text & StrDup(45, " "), 45) & StrDup(2, " ") & Microsoft.VisualBasic.Left(lvDet.Items(I).SubItems(2).Text & StrDup(5, " "), 5) & StrDup(2, " ") & Microsoft.VisualBasic.Right(StrDup(8, " ") & lvDet.Items(I).SubItems(3).Text, 8), FuenteE, Pincel, 10, Y)
                Y = Y + 20
            Next
            Y = Y + 50

            .DrawString(StrDup(8, " ") & "__________________________" & StrDup(6, " ") & "_______________________", FuenteE, Pincel, 40, Y)
            Y = Y + 20
            .DrawString(StrDup(12, " ") & "FIRMA Y SELLO DEL" & StrDup(14, " ") & "RECIBI CONFORME", FuenteE, Pincel, 40, Y)
            Y = Y + 20
            .DrawString(StrDup(10, " ") & "RESPONSABLE DE ALMACEN", FuenteE, Pincel, 40, Y)
        End With
    End Sub
End Class
