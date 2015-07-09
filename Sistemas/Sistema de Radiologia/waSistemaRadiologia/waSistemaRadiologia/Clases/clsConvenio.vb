Imports System.Data.SqlClient
Public Class clsConvenio
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function BuscarDIAtencion(ByVal Paciente As String, ByVal Origen As String, ByVal Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Convenio_BuscarDIAtencion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AtencionCon(ByVal Id As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal UsuarioAtencion As String, ByVal EquipoAtencion As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_AtencionCon"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.ExecuteNonQuery()
    End Sub
End Class
