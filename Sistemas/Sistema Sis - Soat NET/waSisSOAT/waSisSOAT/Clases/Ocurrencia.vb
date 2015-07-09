Imports System.Data.SqlClient
Public Class Ocurrencia
    Dim CnO As New SqlConnection
    Public Sub Grabar(ByVal Aplicacion As String, ByVal Interfaz As String, ByVal Mensaje As String)
        If CnO.State = ConnectionState.Closed Then CnO.Open()
        Dim daTabla As New SqlDataAdapter("Ocurrencia_Grabar", CnO)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy")
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        daTabla.SelectCommand.Parameters.Add("@Aplicacion", SqlDbType.VarChar).Value = Aplicacion
        daTabla.SelectCommand.Parameters.Add("@Interfaz", SqlDbType.VarChar).Value = Interfaz
        daTabla.SelectCommand.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = Mensaje
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub New()
        CnO.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        CnO.Open()
    End Sub
End Class
