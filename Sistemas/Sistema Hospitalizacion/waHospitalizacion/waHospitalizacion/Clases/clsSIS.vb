Imports System.Data.SqlClient
Public Class clsSIS
    Public Function ConsultarLN(ByVal Lote As String, ByVal Numero As String, ByVal Historia As String) As Data.DataSet
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

    Public Function ConsultarHEIHistoria(ByVal Historia As String) As Data.DataSet
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From SISHRDT Where Historia= '" + Historia + "' And FechaAlta Is Null Order By FechaAtencion Desc", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GrabarProcedimientosN(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal UsuRegistro As String, ByVal EquipoRegistro As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String)
        Dim Cm As New SqlCommand
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
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

    Public Sub Procedimientos_Atender(ByVal Id As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal UsuarioAtencion As String, ByVal EquipoAtencion As String)
        Dim Cm As New SqlCommand
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SISHRDT_Procedimientos_Atender"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub EliminarEmergencia(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String)
        Dim Cm As New SqlCommand
        Do While CN.State = ConnectionState.Closed
            CN.Open()
        Loop
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Procedimientos_EliminarEmergencia"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.ExecuteNonQuery()
    End Sub
End Class
