Imports System.Data.SqlClient
Public Class clsConsulta
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function ExamenesPendientesPago(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ExamenesPendientesPago", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub CategorizarPrecio(ByVal IdConsultaExa As String, Precio As String, Importe As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_CategorizarPrecio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarExamenesPR(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String, Tipo As String, SubTipo As String, TipoPaciente As String, NroPReliquidacion As String, SerieSis As String, NumeroSis As String, Historia As String, Paciente As String, ServicioCE As String, PrecioReal As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExamenesPR", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@IdExamen", SqlDbType.VarChar).Value = IdExamen
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@NroPReliquidacion", SqlDbType.Int).Value = Val(NroPReliquidacion)
        daTabla.SelectCommand.Parameters.Add("@SerieSis", SqlDbType.VarChar).Value = SerieSis
        daTabla.SelectCommand.Parameters.Add("@NumeroSis", SqlDbType.Int).Value = Val(NumeroSis)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente.Trim
        daTabla.SelectCommand.Parameters.Add("@ServicioCE", SqlDbType.VarChar).Value = ServicioCE
        daTabla.SelectCommand.Parameters.Add("@PrecioReal", SqlDbType.VarChar).Value = PrecioReal

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
