Imports System.Data.SqlClient
Public Class tempSISHRDT
    Dim Cn As New SqlConnection

    Public Sub SISHRDT_EliminarTempAtenSIS()
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim Comando As New SqlCommand("SISHRDT_EliminarTempAtenSIS", Cn)
        Comando.ExecuteNonQuery()
    End Sub

    Public Sub SISHRDT_GrabarTempAtenSIS(ByVal Formato As String, ByVal Afiliado As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal Paciente As String, ByVal FechaAtencion As String, ByVal FechaAlta As String, ByVal EsReferido As String, ByVal SubEspecialidad As String, ByVal Especialidad As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_GrabarTempAtenSIS", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Formato", SqlDbType.VarChar).Value = Formato
        daTabla.SelectCommand.Parameters.Add("@Afiliado", SqlDbType.VarChar).Value = Afiliado
        daTabla.SelectCommand.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
        daTabla.SelectCommand.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@FechaAtencion", SqlDbType.VarChar).Value = FechaAtencion
        daTabla.SelectCommand.Parameters.Add("@FechaAlta", SqlDbType.VarChar).Value = FechaAlta
        daTabla.SelectCommand.Parameters.Add("@EsReferido", SqlDbType.VarChar).Value = EsReferido
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    
    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub
End Class
