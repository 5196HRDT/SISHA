Imports System.Data.SqlClient
Public Class Convenio
    Dim objOcurrencia As New Ocurrencia
    Dim Cn As New SqlConnection
    Dim Cm As SqlCommand

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=SA;PWD=hrdt2003"
        Cn.Open()
    End Sub

    Public Function Grabar(ByVal IdConvenio As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal Historia As String, ByVal Apaterno As String, ByVal Amaterno As String, ByVal Nombres As String, ByVal FechaNacimiento As String, ByVal Edad As String, ByVal Sexo As String, ByVal Codigo As String, ByVal FechaTermino As String, ByVal Tipo As String, ByVal TipoConvenio As String, ByVal IdTipoConvenio As String) As String
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_Grabar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Direction = ParameterDirection.Output
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@Apaterno", SqlDbType.VarChar).Value = Apaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = Amaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@FechaNacimiento", SqlDbType.SmallDateTime).Value = FechaNacimiento
        Cm.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        Cm.Parameters.Add("@FechaTermino", SqlDbType.SmallDateTime).Value = FechaTermino
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Cm.Parameters.Add("@TipoConvenio", SqlDbType.VarChar).Value = TipoConvenio
        Cm.Parameters.Add("@IdTipoConvenio", SqlDbType.Int).Value = IdTipoConvenio
        Cm.ExecuteNonQuery()
        Grabar = Cm.Parameters("@IdConvenio").Value
    End Function

    Public Sub Modificar(ByVal IdConvenio As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal Historia As String, ByVal Apaterno As String, ByVal Amaterno As String, ByVal Nombres As String, ByVal FechaNacimiento As String, ByVal Edad As String, ByVal Sexo As String, ByVal Codigo As String, ByVal FechaTermino As String, ByVal Tipo As String, ByVal TipoConvenio As String, ByVal IdTipoConvenio As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_Modificar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = IdConvenio
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@Apaterno", SqlDbType.VarChar).Value = Apaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = Amaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@FechaNacimiento", SqlDbType.SmallDateTime).Value = FechaNacimiento
        Cm.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        Cm.Parameters.Add("@FechaTermino", SqlDbType.SmallDateTime).Value = FechaTermino
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Cm.Parameters.Add("@TipoConvenio", SqlDbType.VarChar).Value = TipoConvenio
        Cm.Parameters.Add("@IdTipoConvenio", SqlDbType.Int).Value = IdTipoConvenio
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub GrabarCarta(ByVal IdConvenio As String, ByVal NroCarta As String, ByVal FechaTermino As String, ByVal Requerimiento As String, ByVal Diagnostico As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "CovenioCarta_Grabar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.Parameters.Add("@NroCarta", SqlDbType.VarChar).Value = NroCarta
        Cm.Parameters.Add("@FechaTermino", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaTermino, 10)
        Cm.Parameters.Add("@Requerimiento", SqlDbType.VarChar).Value = Requerimiento
        Cm.Parameters.Add("@Diagnostico", SqlDbType.VarChar).Value = Diagnostico
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarCarta(ByVal IdConvenio As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ConvenioCarta_Eliminar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function Verificar(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_Verificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarParsalud(ByVal Codigo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_VerificarParsalud", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarConvenio(ByVal IdConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_VerificarConvenio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarTipoConvenio(ByVal IdConvenio As String, ByVal TipoConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_VerificarTipoConvenio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.Parameters.Add("@TipoConvenio", SqlDbType.VarChar).Value = TipoConvenio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarParaFacturar(ByVal IdConvenio As String, ByVal IdTipoConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_VerificarParaFacturar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.Parameters.Add("@IdTipoConvenio", SqlDbType.Int).Value = IdTipoConvenio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCarta(ByVal IdConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("ConvenioCarta_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = IdConvenio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarProcedimientosAtendidos(ByVal IdConvenio As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Usuario As String, ByVal Equipo As String, ByVal F1 As String, ByVal F2 As String)
        Try
            Dim Cm As New SqlCommand
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "Convenio_GrabarProcedimientosAtendidos"
            Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
            Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = Usuario
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = Equipo
            If F1 = "  /  /" Then Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = F1
            If F2 = "  /  /" Then Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = F2
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("Convenio", "frmServicios", ex.Message)
        End Try
    End Sub

    Public Sub GrabarProcedimientos(ByVal IdConvenio As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal F1 As String, ByVal F2 As String)
        Try
            Dim Cm As New SqlCommand
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "Convenio_Procedimientos_Grabar"
            Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
            Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
            Cm.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = UsuRegistro
            Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
            If F1 = "  /  /" Then Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F1", SqlDbType.VarChar).Value = F1
            If F2 = "  /  /" Then Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = "" Else Cm.Parameters.Add("@F2", SqlDbType.VarChar).Value = F2
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("Convenio", "frmServicios", ex.Message)
        End Try
    End Sub

    Public Function BuscarHistorialPro(ByVal IdConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_BuscarHistorialPro", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = IdConvenio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AnularDetalle(ByVal IdDetalle As String, ByVal FechaAnulado As String, ByVal HoraAnulado As String, ByVal UsuarioAnulado As String, ByVal EquipoAnulado As String)
        Try
            Dim Cm As New SqlCommand
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "Convenio_AnularDetalle"
            Cm.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Val(IdDetalle)
            Cm.Parameters.Add("@FechaAnulado", SqlDbType.SmallDateTime).Value = FechaAnulado
            Cm.Parameters.Add("@HoraAnulado", SqlDbType.VarChar).Value = HoraAnulado
            Cm.Parameters.Add("@UsuarioAnulado", SqlDbType.VarChar).Value = UsuarioAnulado
            Cm.Parameters.Add("@EquipoAnulado", SqlDbType.VarChar).Value = EquipoAnulado
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("Convenio", "frmServicios", ex.Message)
        End Try
    End Sub

    Public Sub Finalizar(ByVal IdConvenio As String, ByVal FechaFinal As String, ByVal HoraFinal As String, ByVal UsuarioFinal As String, ByVal EquipoFinal As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_Finalizar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.Parameters.Add("@FechaFinal", SqlDbType.SmallDateTime).Value = FechaFinal
        Cm.Parameters.Add("@HoraFinal", SqlDbType.VarChar).Value = HoraFinal
        Cm.Parameters.Add("@UsuarioFinal", SqlDbType.VarChar).Value = UsuarioFinal
        Cm.Parameters.Add("@EquipoFinal", SqlDbType.VarChar).Value = EquipoFinal
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub AnularFinalizar(ByVal IdConvenio As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_AnularFinalizar"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarAnularFinal(ByVal IdConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_BuscarAnularFinal", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function AnularAtencion(ByVal IdConvenio As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_AnularAtencion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.Parameters.Add("@FechaAnu", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@HoraAnu", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@UsuarioAnu", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@EquipoAnu", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ReporteAtenciones(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_ReporteAtenciones", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function RelacionProcedimientos(ByVal IdConvenio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("Convenio_RelacionProcedimientos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Facturar(ByVal IdConvenio As String, ByVal TipoDoc As String, ByVal SerieDoc As String, ByVal NumeroDoc As String)
        Try
            Dim Cm As New SqlCommand
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "Convenio_Facturar"
            Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
            Cm.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc
            Cm.Parameters.Add("@SerieDoc", SqlDbType.VarChar).Value = SerieDoc
            Cm.Parameters.Add("@NumeroDoc", SqlDbType.Int).Value = NumeroDoc
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("Convenio", "frmServicios", ex.Message)
        End Try
    End Sub

    Public Sub Cancelar(ByVal FechaCancelado As String, ByVal HoraCancelado As String, ByVal UsuarioCancelado As String, ByVal EquipoCancelado As String, ByVal TipoDoc As String, ByVal SerieDoc As String, ByVal NumeroDoc As String)
        Try
            Dim Cm As New SqlCommand
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "Convenio_Cancelar"
            Cm.Parameters.Add("@FechaCancelado", SqlDbType.SmallDateTime).Value = FechaCancelado
            Cm.Parameters.Add("@HoraCancelado", SqlDbType.VarChar).Value = HoraCancelado
            Cm.Parameters.Add("@UsuarioCancelado", SqlDbType.VarChar).Value = UsuarioCancelado
            Cm.Parameters.Add("@EquipoCancelado", SqlDbType.VarChar).Value = EquipoCancelado
            Cm.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc
            Cm.Parameters.Add("@SerieDoc", SqlDbType.VarChar).Value = SerieDoc
            Cm.Parameters.Add("@NumeroDoc", SqlDbType.Int).Value = NumeroDoc
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("Convenio", "frmServicios", ex.Message)
        End Try
    End Sub

    Public Sub AnularFacturacion(ByVal IdConvenio As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Convenio_AnularFacturacion"
        Cm.Parameters.Add("@IdConvenio", SqlDbType.Int).Value = Val(IdConvenio)
        Cm.ExecuteNonQuery()
    End Sub
End Class
