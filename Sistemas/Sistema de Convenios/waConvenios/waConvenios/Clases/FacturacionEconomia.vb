Imports System.Data.SqlClient
Public Class FacturacionEconomia
    Public Function Grabar(ByVal Tipo As String, ByVal Serie As String, ByVal Numero As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal Ruc As String, ByVal RazonSocial As String, ByVal Direccion As String, ByVal Historia As String, ByVal Paciente As String, ByVal Placa As String, ByVal Poliza As String, ByVal SubTotal As String, ByVal IGV As String, ByVal Total As String, ByVal Exonerado As String, ByVal Origen As String) As String
        Dim daTabla As New SqlDataAdapter("FacturacionEconomia_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdFactura", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = Ruc
        daTabla.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial
        daTabla.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Val(Historia)
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Placa", SqlDbType.VarChar).Value = Placa
        daTabla.SelectCommand.Parameters.Add("@Poliza", SqlDbType.VarChar).Value = Poliza
        daTabla.SelectCommand.Parameters.Add("@SubTotal", SqlDbType.Money).Value = Val(SubTotal)
        daTabla.SelectCommand.Parameters.Add("@IGV", SqlDbType.Money).Value = Val(IGV)
        daTabla.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Value = Val(Total)
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdFactura").Value
    End Function

    Public Sub DetalleGrabar(ByVal IdFactura As String, ByVal Cantidad As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Importe As String)
        Dim daTabla As New SqlDataAdapter("DetalleFacturaEconomia_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Real).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Verificar(ByVal Tipo As String, ByVal Serie As String, ByVal Numero As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("FacturaEconomia_Verificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub GrabarAnulado(ByVal Tipo As String, ByVal Serie As String, ByVal Numero As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String)
        Dim daTabla As New SqlDataAdapter("FacturacionEconomia_GrabarAnulado", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub AnularComprobante(ByVal Tipo As String, ByVal Serie As String, ByVal Numero As String, ByVal FechaAnulado As String, ByVal HoraAnulado As String, ByVal UsuarioAnulado As String)
        Dim daTabla As New SqlDataAdapter("FacturacionEconomia_AnularComprobante", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@FechaAnulado", SqlDbType.SmallDateTime).Value = FechaAnulado
        daTabla.SelectCommand.Parameters.Add("@HoraAnulado", SqlDbType.VarChar).Value = HoraAnulado
        daTabla.SelectCommand.Parameters.Add("@UsuarioAnulado", SqlDbType.VarChar).Value = UsuarioAnulado
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Cancelar(ByVal IdFactura As String, ByVal FechaCancelado As String, ByVal HoraCancelado As String, ByVal UsuarioCancelado As String, NroCheque As String)
        Dim daTabla As New SqlDataAdapter("FacturaEconomia_Cancelar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdFactura", SqlDbType.Int).Value = IdFactura
        daTabla.SelectCommand.Parameters.Add("@FechaCancelado", SqlDbType.SmallDateTime).Value = FechaCancelado
        daTabla.SelectCommand.Parameters.Add("@HoraCancelado", SqlDbType.VarChar).Value = HoraCancelado
        daTabla.SelectCommand.Parameters.Add("@UsuarioCancelado", SqlDbType.VarChar).Value = UsuarioCancelado
        daTabla.SelectCommand.Parameters.Add("@NroCheque", SqlDbType.VarChar).Value = NroCheque
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function ReporteFacturacion(ByVal F1 As String, ByVal F2 As String, ByVal RazonSocial As String, Tipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("FacturacionEconomia_ReporteFacturacion", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Todo", SqlDbType.Int).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
