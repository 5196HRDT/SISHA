Imports System.Data.SqlClient
Public Class Ingreso
    Public Function Grabar(IdHospitalizacion As String, ByVal Fecha As String, ByVal Hora As String, IdViaAdmision As String, Referido As String, IdResponsable As String, IdCama As String, IdEnfermera As String, Departamento As String, Provincia As String, Distrito As String, Caserio As String) As String
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdViaAdmision", SqlDbType.Int).Value = Val(IdViaAdmision)
        daTabla.SelectCommand.Parameters.Add("@Referido", SqlDbType.VarChar).Value = Referido
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Caserio", SqlDbType.VarChar).Value = Caserio
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdIngreso").Value
    End Function

    Public Function GrabarP(ByVal IdHospitalizacion As String, ByVal Fecha As String, ByVal Hora As String, ByVal IdViaAdmision As String, ByVal Referido As String, ByVal IdResponsable As String, ByVal IdCama As String, ByVal IdEnfermera As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Caserio As String, ByVal TipoPaciente As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal NumeroPre As String) As String
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_GrabarP", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdViaAdmision", SqlDbType.Int).Value = Val(IdViaAdmision)
        daTabla.SelectCommand.Parameters.Add("@Referido", SqlDbType.VarChar).Value = Referido
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Caserio", SqlDbType.VarChar).Value = Caserio
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@NumeroPre", SqlDbType.Int).Value = Val(NumeroPre)
        daTabla.SelectCommand.ExecuteNonQuery()
        GrabarP = daTabla.SelectCommand.Parameters("@IdIngreso").Value
    End Function

    Public Sub Modificar(IdIngreso As String, IdHospitalizacion As String, ByVal Fecha As String, ByVal Hora As String, IdViaAdmision As String, Referido As String, IdResponsable As String, IdCama As String, IdEnfermera As String, Departamento As String, Provincia As String, Distrito As String, Caserio As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_Modificar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdViaAdmision", SqlDbType.Int).Value = Val(IdViaAdmision)
        daTabla.SelectCommand.Parameters.Add("@Referido", SqlDbType.VarChar).Value = Referido
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Caserio", SqlDbType.VarChar).Value = Caserio
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarP(ByVal IdIngreso As String, ByVal IdHospitalizacion As String, ByVal Fecha As String, ByVal Hora As String, ByVal IdViaAdmision As String, ByVal Referido As String, ByVal IdResponsable As String, ByVal IdCama As String, ByVal IdEnfermera As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Caserio As String, ByVal TipoPaciente As String, ByVal SerieSIS As String, ByVal NumeroSIS As String, ByVal NumeroPre As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_ModificarP", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioSistema
        daTabla.SelectCommand.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = My.Computer.Name
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@IdViaAdmision", SqlDbType.Int).Value = Val(IdViaAdmision)
        daTabla.SelectCommand.Parameters.Add("@Referido", SqlDbType.VarChar).Value = Referido
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        daTabla.SelectCommand.Parameters.Add("@IdCama", SqlDbType.Int).Value = Val(IdCama)
        daTabla.SelectCommand.Parameters.Add("@IdEnfermera", SqlDbType.Int).Value = Val(IdEnfermera)
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Caserio", SqlDbType.VarChar).Value = Caserio
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@SerieSIS", SqlDbType.VarChar).Value = SerieSIS
        daTabla.SelectCommand.Parameters.Add("@NumeroSIS", SqlDbType.Int).Value = Val(NumeroSIS)
        daTabla.SelectCommand.Parameters.Add("@NumeroPre", SqlDbType.Int).Value = Val(NumeroPre)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub AltaPaciente(ByVal IdIngreso As String, ByVal FechaAlta As String)
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_AltaPaciente", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FechaAlta", SqlDbType.SmallDateTime).Value = FechaAlta
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdHospitalizacion As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_Buscar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarHospitalizaciones(ByVal HClinica As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_BuscarHospitalizaciones", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HClinica", SqlDbType.Float).Value = Val(HClinica)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function RepEstadistica(ByVal F1 As String, F2 As String, Paciente As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_RepEstadistica", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Consolidado(ByVal F1 As String, F2 As String) As Data.DataSet
        If CN.State = ConnectionState.Closed Then CN.Open()
        Dim daTabla As New SqlDataAdapter("IngresoHospitalizacion_Consolidado", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
