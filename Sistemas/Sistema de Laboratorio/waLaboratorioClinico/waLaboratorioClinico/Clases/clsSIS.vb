Imports System.Data.SqlClient
Public Class clsSIS
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function ConsultarLN(Lote As String, Numero As String, Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultarLN", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarProcedimientosN(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, UsuRegistro As String, EquipoRegistro As String, FechaRegistro As String, HoraRegistro As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_GrabarN"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(UsuRegistro, 10)
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarEmergencia(ByVal IdSis As String, ByVal IdProcedimiento As String, FechaRegistro As String, HoraRegistro As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_EliminarEmergencia"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.ExecuteNonQuery()
    End Sub

    Public Function ListaServiciosSIS(IdSIS As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_ListaServiciosSIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSIS", SqlDbType.Int).Value = IdSIS
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AtencionProcedimientoSis(ByVal Id As String, ByVal FechaAtencion As String, HoraAtencion As String, UsuarioAtencion As String)
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


    Public Sub AtencionProcedimientoSisEq(ByVal Id As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal UsuarioAtencion As String, ByVal EquipoAtencion As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SISHRDT_AtencionProcedimientoSisEq"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarLabAtencionCE(ByVal Paciente As String, ByVal Area As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarLabAtencionCE", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarNombres(ByVal Nombres As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarNombres", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarNombresFormato(ByVal Nombres As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarNombresFormato", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarProcedimientosAtendidos(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal UsuarioAtencion As String, ByVal EquipoAtencion As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_Procedimientos_GrabarAtendidos"
            Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
            Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
            Cm.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
End Class
