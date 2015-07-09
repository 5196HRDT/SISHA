Imports System.Data.SqlClient
Public Class clsCategorizacion
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function Grabar(ByVal HClinica As String, FecRegistro As String, Usuario As String, Monto As String, MontoCat As String, Saldo As String, IdSerHos As String, TipoCat As String, Origen As String, EquipoRegistro As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CatCE_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCCE", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.Float).Value = Val(HClinica)
        daTabla.SelectCommand.Parameters.Add("@FecRegistro", SqlDbType.SmallDateTime).Value = FecRegistro
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Monto", SqlDbType.Money).Value = Monto
        daTabla.SelectCommand.Parameters.Add("@MontoCat", SqlDbType.Money).Value = MontoCat
        daTabla.SelectCommand.Parameters.Add("@Saldo", SqlDbType.Money).Value = Saldo
        daTabla.SelectCommand.Parameters.Add("@IdSerHos", SqlDbType.Int).Value = IdSerHos
        daTabla.SelectCommand.Parameters.Add("@TipoCat", SqlDbType.VarChar).Value = TipoCat
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdCCE").Value
    End Function

    Public Sub GrabarDetalle(ByVal IdCCE As String, IdServicioItem As String, Cantidad As String, Precio As String, Cancelado As String, Atendido As String, PrecioReal As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CatCE_GrabarDetalle", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCCE", SqlDbType.Float).Value = IdCCE
        daTabla.SelectCommand.Parameters.Add("@IdServicioItem", SqlDbType.Float).Value = Val(IdServicioItem)
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cancelado", SqlDbType.VarChar).Value = Cancelado
        daTabla.SelectCommand.Parameters.Add("@Atendido", SqlDbType.VarChar).Value = Atendido
        daTabla.SelectCommand.Parameters.Add("@PrecioReal", SqlDbType.Money).Value = PrecioReal
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
