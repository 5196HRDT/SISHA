Imports System.Data.SqlClient
Public Class clsInformeEKG
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function Grabar(ByVal IdInforme As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String, ByVal Equipo As String, ByVal FechaToma As String, ByVal Origen As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sexo As String, ByVal Edad As String, ByVal Examen As String, ByVal TipoDiagnostico As String, ByVal Conclusiones As String, ByVal IdMedico As String, ByVal Medico As String, ByVal MedicoTratante As String, ByVal TipoPaciente As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKG_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@FechaToma", SqlDbType.SmallDateTime).Value = FechaToma
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Examen", SqlDbType.VarChar).Value = Examen
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Conclusiones", SqlDbType.VarChar).Value = Conclusiones
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@MedicoTratante", SqlDbType.VarChar).Value = MedicoTratante
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdInforme").Value
    End Function

    Public Sub Modificar(ByVal IdInforme As String, ByVal FechaToma As String, ByVal Origen As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sexo As String, ByVal Edad As String, ByVal Examen As String, ByVal TipoDiagnostico As String, ByVal Conclusiones As String, ByVal IdMedico As String, ByVal Medico As String, ByVal MedicoTratante As String, ByVal TipoPaciente As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKG_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        daTabla.SelectCommand.Parameters.Add("@FechaToma", SqlDbType.SmallDateTime).Value = FechaToma
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Examen", SqlDbType.VarChar).Value = Examen
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Conclusiones", SqlDbType.VarChar).Value = Conclusiones
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@MedicoTratante", SqlDbType.VarChar).Value = MedicoTratante
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarHIS(ByVal IdInforme As String, ByVal Edad As String, ByVal TipoPaciente As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKG_ModificarHIS", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKG_Buscar", Cn)
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

    Public Function HIS(ByVal Fecha As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeEKG_HIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
