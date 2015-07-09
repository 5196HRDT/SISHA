Imports System.Data.SqlClient
Public Class clsCupoEspirometria
    Public Sub Grabar(ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal FechaCita As String, ByVal TurnoCita As String, ByVal IdConsultaExa As String, ByVal Descripcion As String, ByVal Historia As String, ByVal Paciente As String, ByVal Edad As String, ByVal Sexo As String, ByVal MedicoSol As String, ByVal TipoPaciente As String, ByVal Indicacion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("CupoEspirometria_Grabar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        Cm.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
        Cm.Parameters.Add("@FechaCita", SqlDbType.SmallDateTime).Value = FechaCita
        Cm.Parameters.Add("@TurnoCita", SqlDbType.VarChar).Value = TurnoCita
        Cm.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = IdConsultaExa
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Cm.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@MedicoSol", SqlDbType.VarChar).Value = MedicoSol
        Cm.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        Cm.Parameters.Add("@Indicacion", SqlDbType.VarChar).Value = Indicacion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdCita As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim Cm As New SqlCommand("CupoEspirometria_Eliminar", Cn)
        Cm.CommandType = CommandType.StoredProcedure
        Cm.Parameters.Add("@IdCita", SqlDbType.Int).Value = IdCita
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Cm.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Fecha As String, ByVal Turno As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CupoEspirometria_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Turno", SqlDbType.VarChar).Value = Turno
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

End Class
