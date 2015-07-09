Public Class frmFormato
    Dim objFormato As New clsElectroencefaFor

    Dim Oper As Integer
    Dim CodLocal As Integer = 0

    Private Sub Botones(ByVal Nuevo As Boolean, ByVal Grabar As Boolean, ByVal Cancelar As Boolean, ByVal Cerrar As Boolean)
        btnNuevo.Enabled = Nuevo
        btnGrabar.Enabled = Grabar
        btnCancelar.Enabled = Cancelar
        btnCerrar.Enabled = Cerrar
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmFormato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        txtInforme.Enabled = False
        txtInforme.Text = ""
        ControlesAD(Me, False)
        Botones(True, False, False, True)
        Limpiar(Me)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Botones(False, True, True, False)
        ControlesAD(Me, True)
        txtInforme.Enabled = True

        Dim dsVer As New DataSet
        dsVer = objFormato.Buscar
        If dsVer.Tables(0).Rows.Count > 0 Then
            Oper = 2
            CodLocal = dsVer.Tables(0).Rows(0)("IdInforme")
            txtInforme.RtfText = dsVer.Tables(0).Rows(0)("Formato")
            txtCorrelativo.Text = dsVer.Tables(0).Rows(0)("Correlativo")
        Else
            CodLocal = 0
            Oper = 1
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("Esta seguro de Grabar Información?", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objFormato.Mantenimiento(CodLocal, txtInforme.RtfText, txtCorrelativo.Text, Oper)
            btnCancelar_Click(sender, e)
        End If
    End Sub
End Class