Imports System.Data.SqlClient
Public Class FichaSoat
    Public Function Grabar(ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Sexo As String, ByVal FechaRegistro As String, ByVal FechaAccidente As String, ByVal Placa As String, ByVal Poliza As String, ByVal Contratante As String, ByVal Aseguradora As String, ByVal ClaseVehiculo As String, ByVal TipoAccidente As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Cie1 As String, ByVal DesCie1 As String, ByVal Cie2 As String, ByVal DesCie2 As String, ByVal Cie3 As String, ByVal DesCie3 As String, ByVal Cie4 As String, ByVal DesCie4 As String, ByVal Estado As String, ByVal Carta As String, ByVal MontoCarta As String, ByVal MontoFarmacia As String, ByVal Diagnostico As String, ByVal UsuarioSistema As String, ByVal Documentos As String, ByVal IdAseguradora As String) As String
        Dim Cm As New SqlCommand
        'Dim FRegistro As Date
        'Dim FAccidente As Date
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Grabar"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Direction = ParameterDirection.Output
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@FechaNac", SqlDbType.VarChar).Value = FechaNac
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@FechaAccidente", SqlDbType.SmallDateTime).Value = FechaAccidente
        Cm.Parameters.Add("@Placa", SqlDbType.VarChar).Value = Placa
        Cm.Parameters.Add("@Poliza", SqlDbType.VarChar).Value = Poliza
        Cm.Parameters.Add("@Contratante", SqlDbType.VarChar).Value = Contratante
        Cm.Parameters.Add("@Aseguradora", SqlDbType.VarChar).Value = Aseguradora
        Cm.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = ClaseVehiculo
        Cm.Parameters.Add("@TipoAccidente", SqlDbType.VarChar).Value = TipoAccidente
        Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Cm.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        Cm.Parameters.Add("@DesCie1", SqlDbType.VarChar).Value = DesCie1
        Cm.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        Cm.Parameters.Add("@DesCie2", SqlDbType.VarChar).Value = DesCie2
        Cm.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        Cm.Parameters.Add("@DesCie3", SqlDbType.VarChar).Value = DesCie3
        Cm.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        Cm.Parameters.Add("@DesCie4", SqlDbType.VarChar).Value = DesCie4
        Cm.Parameters.Add("@Carta", SqlDbType.VarChar).Value = Carta
        Cm.Parameters.Add("@MontoCarta", SqlDbType.Money).Value = Val(MontoCarta)
        Cm.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        Cm.Parameters.Add("@MontoFarmacia", SqlDbType.Money).Value = Val(MontoFarmacia)
        Cm.Parameters.Add("@Diagnostico", SqlDbType.VarChar).Value = Diagnostico
        Cm.Parameters.Add("@UsuarioSistema", SqlDbType.VarChar).Value = UsuarioSistema
        Cm.Parameters.Add("@Documentos", SqlDbType.VarChar).Value = Documentos
        Cm.Parameters.Add("@IdAseguradora", SqlDbType.Int).Value = IdAseguradora
        Cm.ExecuteNonQuery()
        Grabar = Cm.Parameters.Item("@IdSoat").Value
    End Function

    Public Sub Modificar(ByVal IdSoat As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Sexo As String, ByVal FechaRegistro As String, ByVal FechaAccidente As String, ByVal Placa As String, ByVal Poliza As String, ByVal Contratante As String, ByVal Aseguradora As String, ByVal ClaseVehiculo As String, ByVal TipoAccidente As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Cie1 As String, ByVal DesCie1 As String, ByVal Cie2 As String, ByVal DesCie2 As String, ByVal Cie3 As String, ByVal DesCie3 As String, ByVal Cie4 As String, ByVal DesCie4 As String, ByVal Estado As String, ByVal Carta As String, ByVal MontoCarta As String, ByVal MontoFarmacia As String, ByVal Diagnostico As String, ByVal Documentos As String, ByVal IdAseguradora As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Modificar"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@FechaNac", SqlDbType.VarChar).Value = Convert.ToDateTime(FechaNac).ToShortDateString
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        If FechaRegistro.Length > 10 Then Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaRegistro, 10) Else Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@FechaAccidente", SqlDbType.SmallDateTime).Value = FechaAccidente
        Cm.Parameters.Add("@Placa", SqlDbType.VarChar).Value = Placa
        Cm.Parameters.Add("@Poliza", SqlDbType.VarChar).Value = Poliza
        Cm.Parameters.Add("@Contratante", SqlDbType.VarChar).Value = Contratante
        Cm.Parameters.Add("@Aseguradora", SqlDbType.VarChar).Value = Aseguradora
        Cm.Parameters.Add("@ClaseVehiculo", SqlDbType.VarChar).Value = ClaseVehiculo
        Cm.Parameters.Add("@TipoAccidente", SqlDbType.VarChar).Value = TipoAccidente
        Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Cm.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        Cm.Parameters.Add("@DesCie1", SqlDbType.VarChar).Value = DesCie1
        Cm.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        Cm.Parameters.Add("@DesCie2", SqlDbType.VarChar).Value = DesCie2
        Cm.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        Cm.Parameters.Add("@DesCie3", SqlDbType.VarChar).Value = DesCie3
        Cm.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        Cm.Parameters.Add("@DesCie4", SqlDbType.VarChar).Value = DesCie4
        Cm.Parameters.Add("@Carta", SqlDbType.VarChar).Value = Carta
        Cm.Parameters.Add("@MontoCarta", SqlDbType.Money).Value = Val(MontoCarta)
        Cm.Parameters.Add("@Estado", SqlDbType.VarChar).Value = Estado
        Cm.Parameters.Add("@MontoFarmacia", SqlDbType.Money).Value = Val(MontoFarmacia)
        Cm.Parameters.Add("@Diagnostico", SqlDbType.VarChar).Value = Diagnostico
        Cm.Parameters.Add("@Documentos", SqlDbType.VarChar).Value = Documentos
        Cm.Parameters.Add("@IdAseguradora", SqlDbType.Int).Value = IdAseguradora
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarDatosPre(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarDatosPre", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Val(Historia)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDatosPreNP(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarDatosPreNP", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.VarChar).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarNroPre(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarNroPre", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.VarChar).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarDetalle(ByVal IdSoat As String, ByVal IdTarifario As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Fecha As String, ByVal Clasificador As String, ByVal Fecha1 As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Detalle_Grabar"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = IdTarifario
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        Cm.Parameters.Add("@Cantidad", SqlDbType.Real).Value = Cantidad
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        Cm.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha
        Cm.Parameters.Add("@Clasificador", SqlDbType.VarChar).Value = Clasificador
        Cm.Parameters.Add("@Fecha1", SqlDbType.VarChar).Value = Fecha1
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        Cm.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro

        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarFicha(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarFicha", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.Int).Value = Historia
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarFichaNP(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarFichaNP", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDetalle(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Detalle_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Consolidado(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_Consolidado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub EliminarDetalle(ByVal IdDet As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_EliminarDet"
        Cm.Parameters.Add("@IdDet", SqlDbType.Int).Value = IdDet
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub Finalizar(ByVal IdSoat As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Finalizar"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaFinalizado", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        Cm.Parameters.Add("@HoraFinalizado", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarInformeRX(ByVal IdDet As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarInformeRX", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdDet", SqlDbType.Int).Value = IdDet
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ReporteAseguradora(ByVal F1 As String, ByVal F2 As String, ByVal Aseguradora As String, ByVal Especialidad As String, ByVal Tipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_ReporteAseguradora", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Aseguradora", SqlDbType.VarChar).Value = Aseguradora
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub MontoPro(ByVal IdSoat As String, ByVal MontoProcedimiento As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_MontoPro"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@MontoProcedimiento", SqlDbType.Money).Value = MontoProcedimiento
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarDatosDev(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarDatosDev", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.VarChar).Value = Val(IdSoat)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarDevolucion(ByVal IdSoat As String, ByVal UsuarioDevolucion As String, ByVal MotivoDevolucion As String, ByVal AccionDevolucion As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_GrabarDevolucion"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaDevolucion", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(Date.Now, 10)
        Cm.Parameters.Add("@UsuarioDevolucion", SqlDbType.VarChar).Value = UsuarioDevolucion
        Cm.Parameters.Add("@HoraDevolucion", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Cm.Parameters.Add("@MotivoDevolucion", SqlDbType.VarChar).Value = MotivoDevolucion
        Cm.Parameters.Add("@AccionDevolucion", SqlDbType.VarChar).Value = AccionDevolucion
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub CancelarDocumento(ByVal IdSoat As String, ByVal FechaCancelado As String, ByVal UsuarioCancelado As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_CancelarDocumento"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaCancelado", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaCancelado, 10)
        Cm.Parameters.Add("@UsuarioCancelado", SqlDbType.VarChar).Value = UsuarioCancelado
        Cm.Parameters.Add("@HoraCancelado", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub CancelarDocumentoF(ByVal IdSoat As String, ByVal FechaCancelado As String, ByVal UsuarioCancelado As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_CancelarDocumentoF"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaCancelado", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaCancelado, 10)
        Cm.Parameters.Add("@UsuarioCancelado", SqlDbType.VarChar).Value = UsuarioCancelado
        Cm.Parameters.Add("@HoraCancelado", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarDatosFac(ByVal IdSoat As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_BuscarDatosFac", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSoat", SqlDbType.Int).Value = Val(IdSoat)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub FacturarDocumento(ByVal IdSoat As String, ByVal FechaFacturado As String, ByVal TipoDoc As String, ByVal SerieDoc As String, ByVal NumeroDoc As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_FacturarDocumento"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaFacturado", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaFacturado, 10)
        Cm.Parameters.Add("@HoraFacturado", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Cm.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc
        Cm.Parameters.Add("@Serie", SqlDbType.VarChar).Value = SerieDoc
        Cm.Parameters.Add("@Numero", SqlDbType.VarChar).Value = NumeroDoc
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub FacturarDocumentoF(ByVal IdSoat As String, ByVal FechaFacturadoF As String, ByVal TipoDocF As String, ByVal SerieDocF As String, ByVal NumeroDocF As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_FacturarDocumentoF"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaFacturado", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaFacturadoF, 10)
        Cm.Parameters.Add("@HoraFacturado", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2)
        Cm.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDocF
        Cm.Parameters.Add("@Serie", SqlDbType.VarChar).Value = SerieDocF
        Cm.Parameters.Add("@Numero", SqlDbType.VarChar).Value = NumeroDocF
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub AnularFinalizacion(ByVal IdSoat As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_AnularFinalizacion"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.ExecuteNonQuery()
    End Sub

    Public Function AtencionPac(ByVal Paciente As String, ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SOATHRDT_AtencionPac", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Anular(ByVal IdSoat As String, ByVal FechaAnulado As String, ByVal HoraAnulado As String, ByVal UsuarioAnulado As String, ByVal EquipoAnulado As String, ByVal MotivoAnulado As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SOATHRDT_Anular"
        Cm.Parameters.Add("@IdSoat", SqlDbType.Int).Value = IdSoat
        Cm.Parameters.Add("@FechaAnulado", SqlDbType.SmallDateTime).Value = FechaAnulado
        Cm.Parameters.Add("@UsuarioAnulado", SqlDbType.VarChar).Value = UsuarioAnulado
        Cm.Parameters.Add("@HoraAnulado", SqlDbType.VarChar).Value = HoraAnulado
        Cm.Parameters.Add("@EquipoAnulado", SqlDbType.VarChar).Value = EquipoAnulado
        Cm.Parameters.Add("@MotivoAnulado", SqlDbType.VarChar).Value = MotivoAnulado
        Cm.ExecuteNonQuery()
    End Sub
End Class
