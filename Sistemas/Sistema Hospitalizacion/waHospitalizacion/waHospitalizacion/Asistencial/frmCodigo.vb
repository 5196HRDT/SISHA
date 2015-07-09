Public Class frmCodigo
    Dim objSIS As New clsSIS
    Dim objSoat As New clsSOAT
    Dim objConvenio As New clsConvenio

    Private Sub frmCodigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSIS.Click
        Dim dsVer As New DataSet
        dsVer = objSIS.ConsultarHEIHistoria(txtHistoria.Text)
        If dsVer.Tables(0).Rows.Count > 0 Then
            If dsVer.Tables(0).Rows(0)("Especialidad") = "HOSPITALIZACION" Or dsVer.Tables(0).Rows(0)("Especialidad") = "EMERGENCIA" Then
                MessageBox.Show("Formato Nro: " & dsVer.Tables(0).Rows(0)("Lote") & "-" & dsVer.Tables(0).Rows(0)("Numero") & ". Aperturado el día " & dsVer.Tables(0).Rows(0)("FechaAtencion"), "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Paciente No posee Formato Aperturado para Hospitalizacion", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Paciente no posee formato SIS Aperturado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSOAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSOAT.Click
        Dim dsVer As New DataSet
        dsVer = objSoat.BuscarFicha(txtHistoria.Text)
        If dsVer.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Formato Nro SIS-SOAT: " & dsVer.Tables(0).Rows(0)("IdSoat") & ". Aperturado el día " & dsVer.Tables(0).Rows(0)("FechaRegistro"), "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Paciente no posee formato de SOAT Aperturado", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnConvenio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvenio.Click
        Dim dsConvenio As New DataSet
        dsConvenio = objConvenio.BuscarxHistoria(txtHistoria.Text)
        If dsConvenio.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Paciente tiene Apertura de Convenio con " & dsConvenio.Tables(0).Rows(0)("TipoConvenio") & " Nro " & dsConvenio.Tables(0).Rows(0)("IdConvenio") & ", con tipo de atención " & dsConvenio.Tables(0).Rows(0)("Tipo"), "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Paciente no posee formato de Convenio", "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class