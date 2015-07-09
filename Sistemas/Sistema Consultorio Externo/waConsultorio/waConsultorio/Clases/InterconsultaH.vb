Imports System.Data.SqlClient
Public Class InterconsultaH
    Public Sub Grabar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sintomas", SqlDbType.VarChar).Value = Sintomas
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Temp", SqlDbType.VarChar).Value = Temp
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@CieP", SqlDbType.VarChar).Value = CieP
        daTabla.SelectCommand.Parameters.Add("@DesP", SqlDbType.VarChar).Value = DesP
        daTabla.SelectCommand.Parameters.Add("@Evaluacion", SqlDbType.VarChar).Value = Evaluacion
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Tratamiento", SqlDbType.VarChar).Value = Tratamiento
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarLab(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As TriState, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_GrabarLab", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sintomas", SqlDbType.VarChar).Value = Sintomas
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Temp", SqlDbType.VarChar).Value = Temp
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@CieP", SqlDbType.VarChar).Value = CieP
        daTabla.SelectCommand.Parameters.Add("@DesP", SqlDbType.VarChar).Value = DesP
        daTabla.SelectCommand.Parameters.Add("@Evaluacion", SqlDbType.VarChar).Value = Evaluacion
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@Des5", SqlDbType.VarChar).Value = Des5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@Des6", SqlDbType.VarChar).Value = Des6
        daTabla.SelectCommand.Parameters.Add("@Tratamiento", SqlDbType.VarChar).Value = Tratamiento
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(IdMedico)
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal IdInterconsultaH As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_Modificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInterconsultaH", SqlDbType.Int).Value = IdInterconsultaH
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sintomas", SqlDbType.VarChar).Value = Sintomas
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Temp", SqlDbType.VarChar).Value = Temp
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@CieP", SqlDbType.VarChar).Value = CieP
        daTabla.SelectCommand.Parameters.Add("@DesP", SqlDbType.VarChar).Value = DesP
        daTabla.SelectCommand.Parameters.Add("@Evaluacion", SqlDbType.VarChar).Value = Evaluacion
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Tratamiento", SqlDbType.VarChar).Value = Tratamiento
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarLab(ByVal IdInterconsultaH As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal IdMedico As String, ByVal Turno As String, ByVal Especialidad As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As TriState, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_ModificarLab", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInterconsultaH", SqlDbType.Int).Value = IdInterconsultaH
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Sintomas", SqlDbType.VarChar).Value = Sintomas
        daTabla.SelectCommand.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        daTabla.SelectCommand.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        daTabla.SelectCommand.Parameters.Add("@Pulso", SqlDbType.VarChar).Value = Pulso
        daTabla.SelectCommand.Parameters.Add("@Temp", SqlDbType.VarChar).Value = Temp
        daTabla.SelectCommand.Parameters.Add("@Presion", SqlDbType.VarChar).Value = Presion
        daTabla.SelectCommand.Parameters.Add("@CieP", SqlDbType.VarChar).Value = CieP
        daTabla.SelectCommand.Parameters.Add("@DesP", SqlDbType.VarChar).Value = DesP
        daTabla.SelectCommand.Parameters.Add("@Evaluacion", SqlDbType.VarChar).Value = Evaluacion
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@Des5", SqlDbType.VarChar).Value = Des5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@Des6", SqlDbType.VarChar).Value = Des6
        daTabla.SelectCommand.Parameters.Add("@Tratamiento", SqlDbType.VarChar).Value = Tratamiento
        daTabla.SelectCommand.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Departamento
        daTabla.SelectCommand.Parameters.Add("@Provincia", SqlDbType.VarChar).Value = Provincia
        daTabla.SelectCommand.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = Distrito
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@IngEstablecimiento", SqlDbType.VarChar).Value = IngEstablecimiento
        daTabla.SelectCommand.Parameters.Add("@IngServicio", SqlDbType.VarChar).Value = IngServicio
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdInterconsultaH As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From InterconsultaH Where IdInterconsultaH = '" + IdInterconsultaH + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarAtencion(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_BuscarAtencion", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarAtencionSubEspecialidad(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String, ByVal SubEspecialidad As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_BuscarAtencionSubEspecialidad", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = FechaCita
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(CodMedico)
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function GenerarHIS(ByVal IdMedico As String, ByVal Especialidad As String, ByVal Fecha As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_GenerarHIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function GenerarHISTurno(ByVal IdMedico As String, ByVal Especialidad As String, ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_GenerarHISTurno", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.VarChar).Value = IdMedico
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarAtencionAtendida(ByVal FechaCita As String, ByVal Turno As String, ByVal CodMedico As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("InterconsultaH_BuscarAtencionAtendida", Cn)
        Dim dstabla As New Data.DataSet
        Dim Fecha As String
        Fecha = Left(Format("dd/MM/yyyy", FechaCita), 10)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = CDate(FechaCita)
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        daTabla.SelectCommand.Parameters.Add("@IdMedico", SqlDbType.Int).Value = Val(CodMedico)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
