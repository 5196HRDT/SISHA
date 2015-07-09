Public Class frmProduccionCE
    Dim objMes As New clsMes
    Dim objReporte As New clsReportes
    Dim objServicio As New Servicio
    Dim Oper As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmProduccionCE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsMes As New DataSet
        dsMes = objMes.Combo
        cboMes.DataSource = dsMes.Tables(0)
        cboMes.DisplayMember = "Descripcion"
        cboMes.ValueMember = "IdMes"

        Dim dsServicio As New Data.DataSet
        dsServicio = objServicio.Buscar("", 1)
        cboServicio.DataSource = dsServicio.Tables(0)
        cboServicio.DisplayMember = "Descripcion"
        cboServicio.ValueMember = "IdServicio"

        txtAño.Value = Date.Now.Year
        cboMes.Text = DameMes(Date.Now.Month)
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        lvTabla.Items.Clear()
        Dim dsVer As New DataSet
        dsVer = objReporte.ReporteCEDoc(txtAño.Value, cboMes.SelectedValue, cboServicio.Text, Oper)
        Dim I As Integer
        Dim Fila As ListViewItem
        For I = 0 To dsVer.Tables(0).Rows.Count - 1
            Fila = lvTabla.Items.Add(dsVer.Tables(0).Rows(I)("ClasLaboratorio"))
            Fila.SubItems.Add(dsVer.Tables(0).Rows(I)("Descripcion"))
            Fila.SubItems.Add(Microsoft.VisualBasic.Format(CDbl(dsVer.Tables(0).Rows(I)("Total")), "#,##0.00"))
        Next
    End Sub

    Private Sub chkTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodo.CheckedChanged
        If chkTodo.Checked Then cboServicio.Enabled = False : Oper = 1 Else chkTodo.Enabled = True : Oper = 2
    End Sub
End Class