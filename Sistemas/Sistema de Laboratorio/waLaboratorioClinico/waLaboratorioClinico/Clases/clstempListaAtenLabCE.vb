Imports System.Data.SqlClient
Public Class clstempListaAtenLabCE
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub Grabar(ByVal IdEmerSer As String, ByVal Especialidad As String, ByVal Historia As String, ByVal Paciente As String, ByVal TipoAtencion As String, ByVal Descripcion As String, ByVal Cantidad As String, ByVal Equipo As String, ByVal ClasLaboratorio As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempListaAtenLabCE_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = Val(IdEmerSer)
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@TipoAtencion", SqlDbType.VarChar).Value = TipoAtencion
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        If FechaRegistro <> "" Then daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro Else daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        If HoraRegistro <> "" Then daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro Else daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal Equipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempListaAtenLabCE_Eliminar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Equipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("tempListaAtenLabCE_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
