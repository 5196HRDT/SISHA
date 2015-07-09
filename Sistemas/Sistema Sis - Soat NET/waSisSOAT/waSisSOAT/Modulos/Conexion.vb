Imports System.Data.SqlClient
Module Conexion
    Public Cn As New SqlConnection
    Public CnHIS As New SqlConnection

    Public Sub Main()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"

        CnHIS.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=HIS;UID=sa;password=hrdt2003"
        frmAcceso.Show()
    End Sub
End Module
