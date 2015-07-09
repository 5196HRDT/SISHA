Imports System.Data.SqlClient
Public Class Medicamentos
    Dim Cn As New SqlConnection
    Dim Cm As SqlCommand

    Public Sub Mantenimiento(ByVal IdTarifario As String, ByVal Ap_CodApo As String, ByVal Apo_Nombre As String, ByVal Apo_CodSGrupo As String, ByVal Apo_Costo As String, ByVal Activo As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "MedicamentoSis_Mantenimiento"
        Cm.Parameters.Add("@IdTarifario", SqlDbType.Int).Value = IdTarifario
        Cm.Parameters.Add("@Ap_CodApo", SqlDbType.Int).Value = Ap_CodApo
        Cm.Parameters.Add("@Apo_Nombre", SqlDbType.VarChar).Value = Apo_Nombre
        Cm.Parameters.Add("@Apo_CodSGrupo", SqlDbType.Int).Value = Apo_CodSGrupo
        Cm.Parameters.Add("@Apo_Costo", SqlDbType.Money).Value = Apo_Costo
        Cm.Parameters.Add("@Activo", SqlDbType.Char).Value = Activo
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarMedicina(ByVal Des As String, ByVal TipoTarifa As String, ByVal Tipo As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("MedicamentoSis_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ObtenerMedicamentosSISUCI(ByVal Des As String, ByVal TipoTarifa As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerMedicamentosSISUCI", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.Parameters.Add("@TipoTarifa", SqlDbType.VarChar).Value = TipoTarifa
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ObtenerMedicamentosSIS(ByVal Des As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("ObtenerMedicamentosSIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Des", SqlDbType.VarChar).Value = Des
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function FiltroSISUCI(ByVal Descripcion As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Medicamento_FiltroSISUCI", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Buscar(ByVal Descripcion As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Medicamento_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub New()
        Cn.ConnectionString = "Data Source=ServidorSQL;Initial Catalog=dbCaja;UID=sa;password=hrdt2003"
        Cn.Open()
    End Sub

    Public Sub EliminarDetalle(ByVal Id As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Medicamentos_Eliminar"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub AsignarQuitarSISUCI(ByVal IdMedicamento As String, ByVal Oper As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "Medicamento_AsignarQuitarSISUCI"
        Cm.Parameters.Add("@IdMedicamento", SqlDbType.Int).Value = Val(IdMedicamento)
        Cm.Parameters.Add("@Oper", SqlDbType.Int).Value = Val(Oper)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub SisHRDT_Medicamentos_Grabar(ByVal IdSIS As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Fecha As String, ByVal Hora As String, ByVal Equipo As String, ByVal Usuario As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Medicamentos_Grabar"
        Cm.Parameters.Add("@IdSIS", SqlDbType.Int).Value = Val(IdSIS)
        Cm.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub ActStockBienServ(ByVal IdSIS As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal Fecha As String, ByVal Hora As String, ByVal Equipo As String, ByVal Usuario As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Medicamentos_Grabar"
        Cm.Parameters.Add("@IdSIS", SqlDbType.Int).Value = Val(IdSIS)
        Cm.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Int).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub ActStockBienServ(ByVal BienServ As String, ByVal Cantidad As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ActStockBienServ"
        Cm.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub ActStockBienServDev(ByVal BienServ As String, ByVal Cantidad As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ActStockBienServDev"
        Cm.Parameters.Add("@BienServ", SqlDbType.VarChar).Value = BienServ
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function TotalMed(ByVal IdSis As String) As String
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_TotalMed", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        daTabla.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@Total").Value.ToString
    End Function
End Class
