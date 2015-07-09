Imports System.Data.SqlClient
Module Conexion
    Public Cn As New SqlConnection
    Public CnHIS As New SqlConnection

    Public Sub Main()
        Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
        Cn.Open()

        CnHIS.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=HIS;UID=sa;PWD=hrdt2003"
        CnHIS.Open()
        frmAcceso.Show()
    End Sub
End Module
