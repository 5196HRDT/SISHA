Imports System.Data.SqlClient
Public Class Programacion
    Public Sub Grabar(ByVal IdProgramacion As String, ByVal FechaRegistro As String, ByVal Fecha As String, ByVal Hora As String, ByVal Serie As String, ByVal Numero As String, ByVal Exonerado As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Operacion As String, ByVal IdSala As String, ByVal IdAnestesia As String, ByVal IdServicio As String, ByVal IdCirujano As String, ByVal Oper As String, ByVal Origen As String, ByVal TipoProgramacion As String, TipoCirugia As String)
        Dim daTabla As New SqlDataAdapter("CQProgramacion_Grabar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = Val(IdProgramacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        If FechaNac <> "" Then daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaNac, 10) Else daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(Date.Now, 10)
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Operacion", SqlDbType.VarChar).Value = Operacion
        daTabla.SelectCommand.Parameters.Add("@IdSala", SqlDbType.Int).Value = IdSala
        daTabla.SelectCommand.Parameters.Add("@IdCirujano", SqlDbType.Int).Value = IdCirujano
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = IdServicio
        daTabla.SelectCommand.Parameters.Add("@IdAnestesia", SqlDbType.Int).Value = IdAnestesia
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@TipoProgramacion", SqlDbType.VarChar).Value = TipoProgramacion
        daTabla.SelectCommand.Parameters.Add("@TipoCirugia", SqlDbType.VarChar).Value = TipoCirugia
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarEmergencia(ByVal IdProgramacion As String, ByVal FechaRegistro As String, ByVal Fecha As String, ByVal Hora As String, ByVal Serie As String, ByVal Numero As String, ByVal Exonerado As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Operacion As String, ByVal IdSala As String, ByVal IdAnestesia As String, ByVal IdServicio As String, ByVal IdCirujano As String, ByVal Oper As String, ByVal Origen As String, ByVal TipoProgramacion As String, ByVal IdAnestesista As String, TipoCirugia As String)
        Dim daTabla As New SqlDataAdapter("CQProgramacion_GrabarEmergencia", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = Val(IdProgramacion)
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        If FechaNac <> "" Then daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaNac, 10) Else daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(Date.Now, 10)
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Operacion", SqlDbType.VarChar).Value = Operacion
        daTabla.SelectCommand.Parameters.Add("@IdSala", SqlDbType.Int).Value = IdSala
        daTabla.SelectCommand.Parameters.Add("@IdCirujano", SqlDbType.Int).Value = IdCirujano
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = IdServicio
        daTabla.SelectCommand.Parameters.Add("@IdAnestesia", SqlDbType.Int).Value = IdAnestesia
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@TipoProgramacion", SqlDbType.VarChar).Value = TipoProgramacion
        daTabla.SelectCommand.Parameters.Add("@IdAnestesista", SqlDbType.Int).Value = IdAnestesista
        daTabla.SelectCommand.Parameters.Add("@TipoCirugia", SqlDbType.VarChar).Value = TipoCirugia
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Guardar(ByVal FechaRegistro As String, ByVal Fecha As String, ByVal Hora As String, ByVal Serie As String, ByVal Numero As String, ByVal Exonerado As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Operacion As String, ByVal IdSala As String, ByVal IdAnestesia As String, ByVal IdServicio As String, ByVal IdCirujano As String, ByVal Oper As String, ByVal Origen As String, ByVal TipoProgramacion As String, ByVal TipoCirugia As String, ByVal SalaOrigen As String, ByVal CodigoCPT As String, ByVal IdAnestesista As String) As String
        Dim daTabla As New SqlDataAdapter("CQProgramacion_Guardar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        If FechaNac <> "" Then daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaNac, 10) Else daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(Date.Now, 10)
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Operacion", SqlDbType.VarChar).Value = Operacion
        daTabla.SelectCommand.Parameters.Add("@IdSala", SqlDbType.Int).Value = IdSala
        daTabla.SelectCommand.Parameters.Add("@IdCirujano", SqlDbType.Int).Value = IdCirujano
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = IdServicio
        daTabla.SelectCommand.Parameters.Add("@IdAnestesia", SqlDbType.Int).Value = IdAnestesia
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@TipoProgramacion", SqlDbType.VarChar).Value = TipoProgramacion
        daTabla.SelectCommand.Parameters.Add("@TipoCirugia", SqlDbType.VarChar).Value = TipoCirugia
        daTabla.SelectCommand.Parameters.Add("@SalaOrigen", SqlDbType.VarChar).Value = SalaOrigen
        daTabla.SelectCommand.Parameters.Add("@CodigoCPT", SqlDbType.VarChar).Value = CodigoCPT
        daTabla.SelectCommand.Parameters.Add("@IdAnestesista", SqlDbType.Int).Value = IdAnestesista
        daTabla.SelectCommand.ExecuteNonQuery()
        Guardar = daTabla.SelectCommand.Parameters("@IdProgramacion").Value
    End Function

    Public Sub Modificar(ByVal IdProgramacion As String, ByVal FechaRegistro As String, ByVal Fecha As String, ByVal Hora As String, ByVal Serie As String, ByVal Numero As String, ByVal Exonerado As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal FechaNac As String, ByVal Edad As String, ByVal Operacion As String, ByVal IdSala As String, ByVal IdAnestesia As String, ByVal IdServicio As String, ByVal IdCirujano As String, ByVal Oper As String, ByVal Origen As String, ByVal TipoProgramacion As String, ByVal TipoCirugia As String, ByVal SalaOrigen As String, ByVal CodigoCPT As String, ByVal IdAnestesista As String)
        Dim daTabla As New SqlDataAdapter("CQProgramacion_Modificar", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = IdProgramacion
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Serie", SqlDbType.VarChar).Value = Serie
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero
        daTabla.SelectCommand.Parameters.Add("@Exonerado", SqlDbType.VarChar).Value = Exonerado
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        If FechaNac <> "" Then daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(FechaNac, 10) Else daTabla.SelectCommand.Parameters.Add("@FecNac", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Left(Date.Now, 10)
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Operacion", SqlDbType.VarChar).Value = Operacion
        daTabla.SelectCommand.Parameters.Add("@IdSala", SqlDbType.Int).Value = IdSala
        daTabla.SelectCommand.Parameters.Add("@IdCirujano", SqlDbType.Int).Value = IdCirujano
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = IdServicio
        daTabla.SelectCommand.Parameters.Add("@IdAnestesia", SqlDbType.Int).Value = IdAnestesia
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.Parameters.Add("@TipoProgramacion", SqlDbType.VarChar).Value = TipoProgramacion
        daTabla.SelectCommand.Parameters.Add("@TipoCirugia", SqlDbType.VarChar).Value = TipoCirugia
        daTabla.SelectCommand.Parameters.Add("@SalaOrigen", SqlDbType.VarChar).Value = SalaOrigen
        daTabla.SelectCommand.Parameters.Add("@CodigoCPT", SqlDbType.VarChar).Value = CodigoCPT
        daTabla.SelectCommand.Parameters.Add("@IdAnestesista", SqlDbType.Int).Value = IdAnestesista
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarCambio(ByVal IdProgramacion As String, ByVal Cambio As String)
        Dim daTabla As New SqlDataAdapter("CQProgramacion_GrabarCambio", CN)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = Val(IdProgramacion)
        daTabla.SelectCommand.Parameters.Add("@Cambio", SqlDbType.VarChar).Value = Cambio
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarOrigen(ByVal Fecha As String, ByVal Tipo As String, ByVal Origen As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgramacion_BuscarOrigen", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarReporteOrigen(ByVal Fecha As String, ByVal Origen As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgramacion_BuscarReporteOrigen", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarReporteWebOrigen(ByVal Fecha As String, ByVal Origen As String, ByVal fecha2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("CQProgramacion_BuscarReporteWebOrigen", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@fecha2", SqlDbType.SmallDateTime).Value = fecha2
        daTabla.SelectCommand.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub Eliminar(ByVal IdProgramacion As String)
        Dim daTabla As New SqlDataAdapter("CQProgramacion_Eliminar", CN)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdProgramacion", SqlDbType.Int).Value = IdProgramacion
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub
End Class
