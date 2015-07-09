Imports System.Data.SqlClient
Public Class clsEmergenciaSer
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function BuscarListaLab(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaLab", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarListaLabSOAT(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaLabSOAT", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarListaLabPendiente(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaLabPendiente", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarListaParaResultado(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaParaResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarListaParaResultadoNom(ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaParaResultadoNom", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarListaResultados(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarListaResultados", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub ConfirmarListado(ByVal IdEmerSer As String, FechaTomaMuestra As String)
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_ConfirmarListado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = IdEmerSer
        daTabla.SelectCommand.Parameters.Add("@FechaTomaMuestra", SqlDbType.SmallDateTime).Value = FechaTomaMuestra
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarResultado(ByVal IdEmerSer As String, ByVal FechaResultado As String, ByVal HoraResultado As String, ByVal EquipoResultado As String, ByVal UsuarioResultado As String, ByVal Resultado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = IdEmerSer
        daTabla.SelectCommand.Parameters.Add("@FechaResultado", SqlDbType.SmallDateTime).Value = FechaResultado
        daTabla.SelectCommand.Parameters.Add("@HoraResultado", SqlDbType.VarChar).Value = HoraResultado
        daTabla.SelectCommand.Parameters.Add("@UsuarioResultado", SqlDbType.VarChar).Value = UsuarioResultado
        daTabla.SelectCommand.Parameters.Add("@EquipoResultado", SqlDbType.VarChar).Value = EquipoResultado
        daTabla.SelectCommand.Parameters.Add("@Resultado", SqlDbType.VarChar).Value = Resultado
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarConvenio(ByVal IdIngreso As String, ByVal IdServicio As String, Descripcion As String, Precio As String, Cantidad As String, Cancelado As String, FecCan As String, HorCan As String, UsuCan As String, EquipoAtencion As String, IdPersonal As String, Personal As String, Tipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarConvenio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = CDbl(Precio)
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = CDbl(Cantidad)
        daTabla.SelectCommand.Parameters.Add("@Cancelado", SqlDbType.VarChar).Value = Cancelado
        daTabla.SelectCommand.Parameters.Add("@FecCan", SqlDbType.SmallDateTime).Value = FecCan
        daTabla.SelectCommand.Parameters.Add("@HorCan", SqlDbType.VarChar).Value = HorCan
        daTabla.SelectCommand.Parameters.Add("@UsuCan", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(UsuCan, 10)
        daTabla.SelectCommand.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        daTabla.SelectCommand.Parameters.Add("@IdPersonal", SqlDbType.Int).Value = IdPersonal
        daTabla.SelectCommand.Parameters.Add("@Personal", SqlDbType.VarChar).Value = Personal
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarContado(ByVal IdIngreso As String, ByVal IdServicio As String, Descripcion As String, Precio As String, Cantidad As String, Tipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarContado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub AnularResultado(ByVal IdEmerSer As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_AnularResultado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = IdEmerSer
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub EliminarServicio(ByVal IdEmerSer As String)
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_EliminarServicio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = IdEmerSer
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ReporteLab1(ByVal Mes As String, ByVal Año As String, ByVal Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_ReporteLab1", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ReporteLab2(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_ReporteLab2", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ReporteTipoPac(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_ReporteTipoPac", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
