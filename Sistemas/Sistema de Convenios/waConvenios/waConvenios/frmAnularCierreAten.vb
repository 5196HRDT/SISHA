Public Class frmAnularCierreAten
    Dim ObjHistoria As New Historia
    Dim objConvenio As New Convenio
    Dim CodLocal As String

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmAnularCierreAten_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnAnular.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnAnular.Enabled = False
        Limpiar(Me)
    End Sub

   
    Private Sub btnBuscarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarH.Click
        btnAnular.Enabled = False
        If txtHistoria.Text.Length > 0 Then
            Dim dsTabla As New Data.DataSet
            dsTabla = objConvenio.BuscarAnularFinal(txtHistoria.Text)
            If dsTabla.Tables(0).Rows.Count > 0 Then
                lblAPaterno.Text = dsTabla.Tables(0).Rows(0)("Apaterno")
                lblAMaterno.Text = dsTabla.Tables(0).Rows(0)("Amaterno")
                lblNombres.Text = dsTabla.Tables(0).Rows(0)("Nombres")
                If (dsTabla.Tables(0).Rows(0)("FechaNacimiento")).ToString = "" Then
                    lblFecha.Text = ""
                    lblEdad.Text = ""
                Else
                    lblFecha.Text = dsTabla.Tables(0).Rows(0)("FechaNacimiento")
                    lblEdad.Text = Microsoft.VisualBasic.DateDiff(DateInterval.Year, dsTabla.Tables(0).Rows(0)("FechaNacimiento"), Date.Now)
                End If
                lblSexo.Text = dsTabla.Tables(0).Rows(0)("Sexo")
                CodLocal = dsTabla.Tables(0).Rows(0)("IdConvenio")
                cboTipo.Text = dsTabla.Tables(0).Rows(0)("Tipo")
                txtCodigo.Text = dsTabla.Tables(0).Rows(0)("Codigo")
                cboTipoConvenio.Text = dsTabla.Tables(0).Rows(0)("TipoConvenio")
                btnAnular.Enabled = True
            Else
                MessageBox.Show("Convenio No Existe o no esta Finalizado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblAPaterno.Text = ""
                lblAMaterno.Text = ""
                lblNombres.Text = ""
                lblFecha.Text = ""
                lblSexo.Text = ""
                lblEdad.Text = ""
                cboTipo.Text = ""
                txtCodigo.Text = ""
                cboTipoConvenio.Text = ""
                txtHistoria.Select()
            End If
        End If
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        If MessageBox.Show("Esta seguro de recuperar Atencion de Convenio", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            objConvenio.AnularFinalizar(CodLocal)
            MessageBox.Show("Se recupero Atencion de Convenio Satisfactoriamente", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        btnCancelar_Click(sender, e)
    End Sub
End Class