Imports System.Data.SqlClient
Public Class clsEncefalograma
    Public Sub Grabar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal FechaInforme As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sexo As String, ByVal Edad As String, ByVal Solicitado As String, ByVal Informe As String, ByVal Informe1 As String, ByVal TipoDoc As String, ByVal Serie As String, ByVal Numero As String, ByVal TipoPaciente As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Electroencefalograma_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@FechaInforme", SqlDbType.SmallDateTime).Value = FechaInforme
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Solicitado", SqlDbType.VarChar).Value = Solicitado
        daTabla.SelectCommand.Parameters.Add("@Informe", SqlDbType.VarChar).Value = Informe
        daTabla.SelectCommand.Parameters.Add("@Informe1", SqlDbType.VarChar).Value = Informe1
        daTabla.SelectCommand.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdElectro As String, ByVal Solicitado As String, ByVal Informe As String, ByVal Informe1 As String, ByVal TipoDoc As String, ByVal Serie As String, ByVal Numero As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Electroencefalograma_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdElectro", SqlDbType.Int).Value = IdElectro
        daTabla.SelectCommand.Parameters.Add("@Solicitado", SqlDbType.VarChar).Value = Solicitado
        daTabla.SelectCommand.Parameters.Add("@Informe", SqlDbType.VarChar).Value = Informe
        daTabla.SelectCommand.Parameters.Add("@Informe1", SqlDbType.VarChar).Value = Informe1
        daTabla.SelectCommand.Parameters.Add("@TipoDoc", SqlDbType.VarChar).Value = TipoDoc
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarHistoria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Electroencefalograma_BuscarHistoria", Cn)
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

    Public Function BuscarId(ByVal IdElectro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Electroencefalograma_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdElectro", SqlDbType.Int).Value = Val(IdElectro)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
