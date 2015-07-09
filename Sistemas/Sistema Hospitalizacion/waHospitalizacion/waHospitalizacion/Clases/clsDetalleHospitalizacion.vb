Imports System.Data.SqlClient
Public Class clsDetalleHospitalizacion
    Public Sub Grabar(ByVal IdHospitalizacion As String, ByVal IdServicioItem As String, ByVal Cantidad As String, ByVal Precio As String, ByVal PrecioReal As String, ByVal Area As String, ByVal FechaRegAten As String, ByVal HoraRegAten As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal Descripcion As String, ByVal Importe As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPreliquidacion As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal Historia As String, ByVal Paciente As String, ByVal Indicacion As String, ByVal Solicitante As String, ByVal Piso As String, ByVal Servicio As String, ByVal Especialidad As String)
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = IdHospitalizacion
        daTabla.SelectCommand.Parameters.Add("@IdServicioItem", SqlDbType.Int).Value = IdServicioItem
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@PrecioReal", SqlDbType.Money).Value = PrecioReal
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@FechaRegAten", SqlDbType.SmallDateTime).Value = FechaRegAten
        daTabla.SelectCommand.Parameters.Add("@HoraRegAten", SqlDbType.VarChar).Value = HoraRegAten
        daTabla.SelectCommand.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@NroPreliquidacion", SqlDbType.Int).Value = Val(NroPreliquidacion)
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        daTabla.SelectCommand.Parameters.Add("@Piso", SqlDbType.VarChar).Value = Piso
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarCancelado(ByVal IdHospitalizacion As String, ByVal IdServicioItem As String, ByVal Cantidad As String, ByVal Precio As String, ByVal PrecioReal As String, ByVal Area As String, ByVal FechaRegAten As String, ByVal HoraRegAten As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal Descripcion As String, ByVal Importe As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPreliquidacion As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal Historia As String, ByVal Paciente As String, ByVal Indicacion As String, ByVal Solicitante As String, ByVal Piso As String, ByVal Servicio As String, ByVal Especialidad As String)
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_GrabarCancelado", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = IdHospitalizacion
        daTabla.SelectCommand.Parameters.Add("@IdServicioItem", SqlDbType.Int).Value = IdServicioItem
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@PrecioReal", SqlDbType.Money).Value = PrecioReal
        daTabla.SelectCommand.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area
        daTabla.SelectCommand.Parameters.Add("@FechaRegAten", SqlDbType.SmallDateTime).Value = FechaRegAten
        daTabla.SelectCommand.Parameters.Add("@HoraRegAten", SqlDbType.VarChar).Value = HoraRegAten
        daTabla.SelectCommand.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@NroPreliquidacion", SqlDbType.Int).Value = Val(NroPreliquidacion)
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        daTabla.SelectCommand.Parameters.Add("@Piso", SqlDbType.VarChar).Value = Piso
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Anular(ByVal IdDetalle As String, ByVal UsuAnulado As String, ByVal FecAnulado As String, ByVal HoraAnulado As String, ByVal EquipoAnulado As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_Anular", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Val(IdDetalle)
        daTabla.SelectCommand.Parameters.Add("@FecAnulado", SqlDbType.SmallDateTime).Value = FecAnulado
        daTabla.SelectCommand.Parameters.Add("@HoraAnulado", SqlDbType.VarChar).Value = HoraAnulado
        daTabla.SelectCommand.Parameters.Add("@UsuAnulado", SqlDbType.VarChar).Value = UsuAnulado
        daTabla.SelectCommand.Parameters.Add("@EquipoAnulado", SqlDbType.VarChar).Value = EquipoAnulado
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdHospitalizaccion As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizaccion)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GrabarPendiente(ByVal IdDetalle As String, ByVal UsuPendiente As String, ByVal FecPendiente As String, ByVal EquiPendiente As String, ByVal HorPendiente As String)
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("DetalleHospitalizacion_GrabarPendiente", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Val(IdDetalle)
        daTabla.SelectCommand.Parameters.Add("@FecPendiente", SqlDbType.SmallDateTime).Value = FecPendiente
        daTabla.SelectCommand.Parameters.Add("@HorPendiente", SqlDbType.VarChar).Value = HorPendiente
        daTabla.SelectCommand.Parameters.Add("@UsuPendiente", SqlDbType.VarChar).Value = UsuPendiente
        daTabla.SelectCommand.Parameters.Add("@EquiPendiente", SqlDbType.VarChar).Value = EquiPendiente
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
