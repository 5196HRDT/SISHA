Imports System.Data.SqlClient
Public Class clsDetalleHospitalizacion
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function BuscarTomaMuestra(ByVal F1 As String, ByVal F2 As String, ByVal Filtro As String, ByVal Tipo As String, ByVal SubTipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_BuscarTomaMuestra", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarSolicitud(ByVal F1 As String, ByVal F2 As String, ByVal Filtro As String, ByVal Tipo As String, ByVal SubTipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_BuscarSolicitud", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarExaResultado(ByVal Tipo As String, ByVal Filtro As String, ByVal F1 As String, ByVal F2 As String, ByVal SubTipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_BuscarTomaMuestra", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub TomaMuestra(ByVal IdDetalle As String, ByVal FechaTomaMuestra As String, ByVal HoraTomaMuestra As String, ByVal UsuarioTomaMuestra As String, ByVal EquipoTomaMuestra As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_TomaMuestra", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdDetalle
        daTabla.SelectCommand.Parameters.Add("@FechaTomaMuestra", SqlDbType.SmallDateTime).Value = FechaTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@HoraTomaMuestra", SqlDbType.VarChar).Value = HoraTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@UsuarioTomaMuestra", SqlDbType.VarChar).Value = UsuarioTomaMuestra
        daTabla.SelectCommand.Parameters.Add("@EquipoTomaMuestra", SqlDbType.VarChar).Value = EquipoTomaMuestra
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Sub GrabarResultados(ByVal IdDetalle As String, ByVal Resultado As String, ByVal FechaResultado As String, ByVal HoraResultado As String, ByVal UsuarioResultado As String, ByVal EquipoResultado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_GrabarResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdDetalle
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.Parameters.Add("@FechaResultado", SqlDbType.SmallDateTime).Value = FechaResultado
        daTabla.SelectCommand.Parameters.Add("@HoraResultado", SqlDbType.VarChar).Value = HoraResultado
        daTabla.SelectCommand.Parameters.Add("@UsuarioResultado", SqlDbType.VarChar).Value = UsuarioResultado
        daTabla.SelectCommand.Parameters.Add("@EquipoResultado", SqlDbType.VarChar).Value = EquipoResultado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarListaResultados(ByVal Historia As String, ByVal Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_BuscarListaResultados", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AnularResultado(ByVal IdDetalle As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_AnularResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdDetalle
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub

    Public Sub ModificarResultado(ByVal IdDetalle As String, ByVal Resultado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_ModificarResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Val(IdDetalle)
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
    End Sub
End Class
