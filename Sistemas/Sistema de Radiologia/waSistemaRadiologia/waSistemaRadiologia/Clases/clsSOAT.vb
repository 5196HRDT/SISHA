Imports System.Data.SqlClient
Public Class clsSOAT
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub AtencionProc(ByVal IdDet As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal UsuarioAtencion As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SoatHRDT_AtencionProc"
        Cm.Parameters.Add("@IdDet", SqlDbType.Int).Value = IdDet
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion

        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarExaRad(ByVal Paciente As String, ByVal Especialidad As String, ByVal SubTipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarExaRad", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
