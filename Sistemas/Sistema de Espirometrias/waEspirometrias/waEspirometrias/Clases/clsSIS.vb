Imports System.Data.SqlClient
Public Class clsSIS
    Public Function BuscarEspirometria(ByVal Paciente As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarEspirometria", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AtencionProcedimientoSis(ByVal Id As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal UsuarioAtencion As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SISHRDT_AtencionProcedimientoSis"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        Cm.ExecuteNonQuery()
    End Sub
End Class
