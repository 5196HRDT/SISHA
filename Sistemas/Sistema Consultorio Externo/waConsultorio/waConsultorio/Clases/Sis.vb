Imports System.Data.SqlClient
Public Class Sis

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

End Class
