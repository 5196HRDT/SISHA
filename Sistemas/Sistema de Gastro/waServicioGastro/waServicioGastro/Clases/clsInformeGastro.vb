Imports System.Data.SqlClient
Public Class clsInformeGastro
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Function Grabar(FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String, Fecha As String, Hora As String, Origen As String, Servicio As String, TipoPaciente As String, Historia As String, Paciente As String, EdadA As String, EdadM As String, Sexo As String, SerieSIS As String, NumeroSIS As String, NumeroPre As String, ExamenSol As String, Solicitante As String, IndicacionesExa As String, Informe As String, IdMedico As String, Medico As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeGastro_Grabar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@EdadA", SqlDbType.Int).Value = Val(EdadA)
        daTabla.SelectCommand.Parameters.Add("@EdadM", SqlDbType.Int).Value = Val(EdadM)
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@NumeroPre", SqlDbType.Int).Value = Val(NumeroPre)
        daTabla.SelectCommand.Parameters.Add("@ExamenSol", SqlDbType.VarChar).Value = ExamenSol
        daTabla.SelectCommand.Parameters.Add("@Solicitante", SqlDbType.VarChar).Value = Solicitante
        daTabla.SelectCommand.Parameters.Add("@IndicacionesExa", SqlDbType.VarChar).Value = IndicacionesExa
        daTabla.SelectCommand.Parameters.Add("@Informe", SqlDbType.VarChar).Value = Informe
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico


        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdInforme").Value
    End Function

    Public Function BuscarHistoria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InformeGastro_BuscarHistoria", Cn)
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
End Class
