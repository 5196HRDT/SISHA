Imports System.Data.SqlClient
Public Class clsConsulta
    Dim Cn As New SqlConnection

    Public Sub New()
        Dim Ruta, Servidor, Base, Usuario, Password As String
        Dim Encontro As Boolean = False

        Ruta = System.IO.Directory.GetCurrentDirectory() & "\Servidor.ini"

        Dim objReader As New IO.StreamReader(Ruta)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        Servidor = Microsoft.VisualBasic.Right(arrText(1), arrText(1).ToString.Length - 9)
        Base = Microsoft.VisualBasic.Right(arrText(2), arrText(2).ToString.Length - 5)
        Usuario = Microsoft.VisualBasic.Right(arrText(3), arrText(3).ToString.Length - 8)
        Password = Microsoft.VisualBasic.Right(arrText(4), arrText(4).ToString.Length - 9)


        Cn.ConnectionString = "Database='" + Base + "';Data Source='" + Servidor + "';User Id='" + Usuario + "';Password='" + Password + "'"
        Try
            Cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
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

    Public Function BuscarExaSinAtencionComun(ByVal Historia As String) As DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("Consulta_BuscarExaSinAtencionComun", Cn)
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

    Public Sub Consulta_GrabarExamenesInd(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPReliquidacion As String, ByVal SerieSis As String, ByVal NumeroSis As String, ByVal Historia As String, ByVal Paciente As String, ByVal ServicioCE As String, ByVal Indicacion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Try

            Dim daTabla As New SqlDataAdapter("Consulta_GrabarExamenesServicios", Cn)
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GrabarExamenesCanInd(ByVal IdCupo As String, ByVal IdExamen As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal EquipoRegistro As String, ByVal Tipo As String, ByVal SubTipo As String, ByVal TipoPaciente As String, ByVal NroPReliquidacion As String, ByVal SerieSis As String, ByVal NumeroSis As String, ByVal Historia As String, ByVal Paciente As String, ByVal ServicioCE As String, ByVal Indicacion As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Try

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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub EliminarExamen(ByVal IdConsultaExa As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Try

            Dim daTabla As New SqlDataAdapter("ConsultaExamenes_EliminarExamen", Cn)
            Dim dstabla As New Data.DataSet
            daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
            daTabla.SelectCommand.Parameters.Add("@IdConsultaExa", SqlDbType.Int).Value = Val(IdConsultaExa)

            Do While Cn.State = ConnectionState.Closed
                Cn.Open()
            Loop

            daTabla.SelectCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
