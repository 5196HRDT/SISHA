Imports System.Data.SqlClient
Public Class clsInforme
    Public Function Grabar(ByVal FIngreso As String, ByVal Historia As String, ByVal Paciente As String, ByVal Procedencia As String, ByVal Servicio As String, ByVal Edad As String, ByVal Cama As String, ByVal TipoPaciente As String, ByVal FEntrega As String, ByVal IdFormato As String, ByVal Cuerpo As String, ByVal Sexo As String, ByVal NroRegistro As String, ByVal Medico As String, ByVal Diagnostico As String, Organo As String, Muestra As String, Cuerpo1 As String) As String
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_Grabar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@FIngreso", SqlDbType.SmallDateTime).Value = FIngreso
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Procedencia", SqlDbType.VarChar).Value = Procedencia
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Cama", SqlDbType.VarChar).Value = Cama
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@FEntrega", SqlDbType.SmallDateTime).Value = FEntrega
        daTabla.SelectCommand.Parameters.Add("@IdFormato", SqlDbType.Int).Value = Val(IdFormato)
        daTabla.SelectCommand.Parameters.Add("@Cuerpo", SqlDbType.VarChar).Value = Cuerpo
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@NroRegistro", SqlDbType.VarChar).Value = NroRegistro
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@Organo", SqlDbType.VarChar).Value = Organo
        daTabla.SelectCommand.Parameters.Add("@Muestra", SqlDbType.VarChar).Value = Muestra
        daTabla.SelectCommand.Parameters.Add("@Cuerpo1", SqlDbType.VarChar).Value = Cuerpo1
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        Grabar = daTabla.SelectCommand.Parameters("@IdInforme").Value

    End Function

    Public Sub Modificar(ByVal IdInforme As String, ByVal FIngreso As String, ByVal Historia As String, ByVal Paciente As String, ByVal Procedencia As String, ByVal Servicio As String, ByVal Edad As String, ByVal Cama As String, ByVal TipoPaciente As String, ByVal FEntrega As String, ByVal IdFormato As String, ByVal Cuerpo As String, ByVal Sexo As String, ByVal Medico As String, ByVal Diagnostico As String, Organo As String, Muestra As String, Cuerpo1 As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_Modificar", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = Val(IdInforme)
        daTabla.SelectCommand.Parameters.Add("@FIngreso", SqlDbType.SmallDateTime).Value = FIngreso
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Procedencia", SqlDbType.VarChar).Value = Procedencia
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Edad", SqlDbType.VarChar).Value = Edad
        daTabla.SelectCommand.Parameters.Add("@Cama", SqlDbType.VarChar).Value = Cama
        daTabla.SelectCommand.Parameters.Add("@TipoPaciente", SqlDbType.VarChar).Value = TipoPaciente
        daTabla.SelectCommand.Parameters.Add("@FEntrega", SqlDbType.SmallDateTime).Value = FEntrega
        daTabla.SelectCommand.Parameters.Add("@IdFormato", SqlDbType.Int).Value = Val(IdFormato)
        daTabla.SelectCommand.Parameters.Add("@Cuerpo", SqlDbType.VarChar).Value = Cuerpo
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Medico", SqlDbType.VarChar).Value = Medico
        daTabla.SelectCommand.Parameters.Add("@Organo", SqlDbType.VarChar).Value = Organo
        daTabla.SelectCommand.Parameters.Add("@Muestra", SqlDbType.VarChar).Value = Muestra
        daTabla.SelectCommand.Parameters.Add("@Cuerpo1", SqlDbType.VarChar).Value = Cuerpo1
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Paciente As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_Consulta", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(ByVal IdInforme As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdInforme", SqlDbType.Int).Value = IdInforme
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function VerificarRegistro(ByVal NroRegistro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_VerificarRegistro", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NroRegistro", SqlDbType.VarChar).Value = NroRegistro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaEpi(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Informe_ConsultaEpi", Cn)
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
End Class
