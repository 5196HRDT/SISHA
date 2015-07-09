Imports System.Data.SqlClient
Public Class Consulta

    Public Sub Grabar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As String, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String, IdResponsable As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarD(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarD", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarLab(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As String, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarLab", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
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

    Public Sub Modificar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As String, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String, IdResponsable As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_Modificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        daTabla.SelectCommand.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarD(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ModificarD", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub ModificarLab(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal IdCupo As String, ByVal Historia As String, ByVal Paciente As String, ByVal Sintomas As String, ByVal Talla As String, ByVal Peso As String, ByVal Pulso As String, ByVal Temp As String, ByVal Presion As String, ByVal CieP As String, ByVal DesP As String, ByVal Evaluacion As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal Tratamiento As String, ByVal Departamento As String, ByVal Provincia As String, ByVal Distrito As String, ByVal Ubigeo As String, ByVal IngEstablecimiento As String, ByVal IngServicio As String, ByVal Servicio As String, ByVal Responsable As String, ByVal TipoDiagnostico As String, ByVal Evolucion As String, ByVal TD1 As String, ByVal TD2 As String, ByVal TD3 As String, ByVal TD4 As String, ByVal TD5 As String, ByVal Lab1 As String, ByVal Lab2 As String, ByVal Lab3 As String, ByVal Lab4 As String, ByVal Lab5 As String, ByVal Lab6 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ModificarLab", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraRegistro, 5)
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
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
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Evolucion", SqlDbType.VarChar).Value = Evolucion
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
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

    Public Sub ModificarHIS(ByVal IdConsulta As String, ByVal Ubigeo As String, ByVal Cie1 As String, ByVal Des1 As String, ByVal TipoDiagnostico As String, ByVal Lab1 As String, ByVal Cie2 As String, ByVal Des2 As String, ByVal TD1 As String, ByVal Lab2 As String, ByVal Cie3 As String, ByVal Des3 As String, ByVal TD2 As String, ByVal Lab3 As String, ByVal Cie4 As String, ByVal Des4 As String, ByVal TD3 As String, ByVal Lab4 As String, ByVal Cie5 As String, ByVal Des5 As String, ByVal TD4 As String, ByVal Lab5 As String, ByVal Cie6 As String, ByVal Des6 As String, ByVal TD5 As String, ByVal Lab6 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_ModificarHIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = Val(IdConsulta)
        daTabla.SelectCommand.Parameters.Add("@Ubigeo", SqlDbType.VarChar).Value = Ubigeo
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@TipoDiagnostico", SqlDbType.VarChar).Value = TipoDiagnostico
        daTabla.SelectCommand.Parameters.Add("@Lab1", SqlDbType.VarChar).Value = Lab1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@TD1", SqlDbType.VarChar).Value = TD1
        daTabla.SelectCommand.Parameters.Add("@Lab2", SqlDbType.VarChar).Value = Lab2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@TD2", SqlDbType.VarChar).Value = TD2
        daTabla.SelectCommand.Parameters.Add("@Lab3", SqlDbType.VarChar).Value = Lab3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@TD3", SqlDbType.VarChar).Value = TD3
        daTabla.SelectCommand.Parameters.Add("@Lab4", SqlDbType.VarChar).Value = Lab4
        daTabla.SelectCommand.Parameters.Add("@Cie5", SqlDbType.VarChar).Value = Cie5
        daTabla.SelectCommand.Parameters.Add("@Des5", SqlDbType.VarChar).Value = Des5
        daTabla.SelectCommand.Parameters.Add("@TD4", SqlDbType.VarChar).Value = TD4
        daTabla.SelectCommand.Parameters.Add("@Lab5", SqlDbType.VarChar).Value = Lab5
        daTabla.SelectCommand.Parameters.Add("@Cie6", SqlDbType.VarChar).Value = Cie6
        daTabla.SelectCommand.Parameters.Add("@Des6", SqlDbType.VarChar).Value = Des6
        daTabla.SelectCommand.Parameters.Add("@TD5", SqlDbType.VarChar).Value = TD5
        daTabla.SelectCommand.Parameters.Add("@Lab6", SqlDbType.VarChar).Value = Lab6
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Consulta_GrabarMedicamentos(ByVal IdCupo As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarMedicamentos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Consulta_GrabarExamenesInd(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String, Tipo As String, SubTipo As String, TipoPaciente As String, NroPReliquidacion As String, SerieSis As String, NumeroSis As String, Historia As String, Paciente As String, ServicioCE As String, Indicacion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExamenesInd", Cn)
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
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Consulta_GrabarExamenesCanInd(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, FechaRegistro As String, HoraRegistro As String, UsuarioRegistro As String, EquipoRegistro As String, Tipo As String, SubTipo As String, TipoPaciente As String, NroPReliquidacion As String, SerieSis As String, NumeroSis As String, Historia As String, Paciente As String, ServicioCE As String, Indicacion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExamenesCanInd", Cn)
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
        daTabla.SelectCommand.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion

        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Consulta_GrabarExamenesFecha(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, UsuarioRegistro As String, EquipoRegistro As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GrabarExamenes", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = Val(IdCupo)
        daTabla.SelectCommand.Parameters.Add("@IdExamen", SqlDbType.VarChar).Value = IdExamen
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Importe", SqlDbType.Money).Value = Importe
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(Date.Now.ToShortTimeString, 5)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Consulta Where IdCupo = '" + IdCupo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarCPT(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From ConsultaCPT Where IdProcedimiento = '" + IdCupo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarExamenes(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Consulta_Examenes Where IdCupo = '" + IdCupo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarMedicamentos(ByVal IdCupo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Select * From Consulta_Medicamentos Where IdCupo = '" + IdCupo + "'", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function GenerarHIS(ByVal Medico As String, ByVal Especialidad As String, ByVal Fecha As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GenerarHIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function GenerarHISTurno(ByVal Medico As String, ByVal Especialidad As String, ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_GenerarHISTurno", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
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

    Public Function BuscarUbigeo(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarUbigeo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
    'REPORTE CONSULTORIO EXTERNO '
    Public Function Reporte_ConsultorioEx(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then
            Cn.Open()
        End If
        Dim daTabla As New SqlDataAdapter("TramaBaseCE_Reporte", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@fechaInicio", SqlDbType.SmallDateTime).Value = FechaInicio
        daTabla.SelectCommand.Parameters.Add("@fechaFin", SqlDbType.SmallDateTime).Value = FechaFin
        If Cn.State = ConnectionState.Closed Then
            Cn.Open()
        End If
        If Cn.State = ConnectionState.Closed Then
            Cn.Open()
        End If
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function


    Public Function BuscarHistoria(ByVal Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarHC", Cn)
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

    Public Function VerDiagnosticoDef(ByVal Historia As String, ByVal CIE As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_VerDiagnosticoDef", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@CIE", SqlDbType.VarChar).Value = CIE
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerDiagnosticoMorDef(ByVal Historia As String, ByVal CIE As String, ByVal ND As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_VerDiagnosticoMorDef", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@CIE", SqlDbType.VarChar).Value = CIE
        daTabla.SelectCommand.Parameters.Add("@ND", SqlDbType.Int).Value = ND
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarTemp(ByVal F1 As String, ByVal F2 As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarTemp", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub EliminarAtencion(ByVal IdConsulta As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_EliminarAtencion", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdConsulta", SqlDbType.Int).Value = IdConsulta
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub CancelarCostoCero(ByVal IdCupo As String, ByVal IdExamen As String, ByVal FecCan As String, ByVal HorCan As String, ByVal UsuCan As String, ByVal EquiCan As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_CancelarCostoCero", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCupo", SqlDbType.Int).Value = IdCupo
        daTabla.SelectCommand.Parameters.Add("@IdExamen", SqlDbType.Int).Value = IdExamen
        daTabla.SelectCommand.Parameters.Add("@FecCan", SqlDbType.SmallDateTime).Value = FecCan
        daTabla.SelectCommand.Parameters.Add("@HorCan", SqlDbType.VarChar).Value = HorCan
        daTabla.SelectCommand.Parameters.Add("@UsuCan", SqlDbType.VarChar).Value = UsuCan
        daTabla.SelectCommand.Parameters.Add("@EquiCan", SqlDbType.VarChar).Value = EquiCan
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
