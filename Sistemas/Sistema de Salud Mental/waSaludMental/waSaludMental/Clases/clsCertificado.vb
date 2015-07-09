Imports System.Data.SqlClient
Public Class clsCertificado
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

    Public Sub Mantenimiento(ByVal IdCertificado As String, ByVal Fecha As String, Hora As String, Usuario As String, Equipo As String, Historia As String, DNI As String, Paciente As String, Personalidad As String, PuntajeTotal As String, CategoriaInteligencia As String, Organicidad As String, Inestabilidad As String, Agrecividad As String, Impulsividad As String, Hostilidad As String, Retraimiento As String, CondicionPS As String, CieQA As String, DesQA As String, CieQB As String, DesQB As String, CieQC As String, DesQC As String, Drogas As String, CondicionPQ As String, IdPsicologo As String, Psicologo As String, IdPsiquiatra As String, Psiquiatra As String, Oper As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_Mantenimiento", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCertificado", SqlDbType.Int).Value = Val(IdCertificado)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Personalidad", SqlDbType.VarChar).Value = Personalidad
        daTabla.SelectCommand.Parameters.Add("@PuntajeTotal", SqlDbType.VarChar).Value = PuntajeTotal
        daTabla.SelectCommand.Parameters.Add("@CategoriaInteligencia", SqlDbType.VarChar).Value = CategoriaInteligencia
        daTabla.SelectCommand.Parameters.Add("@Organicidad", SqlDbType.VarChar).Value = Organicidad
        daTabla.SelectCommand.Parameters.Add("@Inestabilidad", SqlDbType.VarChar).Value = Inestabilidad
        daTabla.SelectCommand.Parameters.Add("@Agrecividad", SqlDbType.VarChar).Value = Agrecividad
        daTabla.SelectCommand.Parameters.Add("@Impulsividad", SqlDbType.VarChar).Value = Impulsividad
        daTabla.SelectCommand.Parameters.Add("@Hostilidad", SqlDbType.VarChar).Value = Hostilidad
        daTabla.SelectCommand.Parameters.Add("@Retraimiento", SqlDbType.VarChar).Value = Retraimiento
        daTabla.SelectCommand.Parameters.Add("@CondicionPS", SqlDbType.VarChar).Value = CondicionPS
        daTabla.SelectCommand.Parameters.Add("@CieQA", SqlDbType.VarChar).Value = CieQA
        daTabla.SelectCommand.Parameters.Add("@DesQA", SqlDbType.VarChar).Value = DesQA
        daTabla.SelectCommand.Parameters.Add("@CieQB", SqlDbType.VarChar).Value = CieQB
        daTabla.SelectCommand.Parameters.Add("@DesQB", SqlDbType.VarChar).Value = DesQB
        daTabla.SelectCommand.Parameters.Add("@CieQC", SqlDbType.VarChar).Value = CieQC
        daTabla.SelectCommand.Parameters.Add("@DesQC", SqlDbType.VarChar).Value = DesQC
        daTabla.SelectCommand.Parameters.Add("@Drogas", SqlDbType.VarChar).Value = Drogas
        daTabla.SelectCommand.Parameters.Add("@CondicionPQ", SqlDbType.VarChar).Value = CondicionPQ
        daTabla.SelectCommand.Parameters.Add("@IdPsicologo", SqlDbType.Int).Value = IdPsicologo
        daTabla.SelectCommand.Parameters.Add("@Psicologo", SqlDbType.VarChar).Value = Psicologo
        daTabla.SelectCommand.Parameters.Add("@IdPsiquiatra", SqlDbType.Int).Value = IdPsiquiatra
        daTabla.SelectCommand.Parameters.Add("@Psiquiatra", SqlDbType.VarChar).Value = Psiquiatra
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.Int).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Entrega(ByVal IdCertificado As String, IdVisador As String, Visador As String, ByVal FechaImpresion As String, HoraImpresion As String, UsuarioImpresion As String, EquipoImpresion As String, NroCertificado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_Entrega", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCertificado", SqlDbType.Int).Value = Val(IdCertificado)
        daTabla.SelectCommand.Parameters.Add("@FechaImpresion", SqlDbType.SmallDateTime).Value = FechaImpresion
        daTabla.SelectCommand.Parameters.Add("@HoraImpresion", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(HoraImpresion, 5)
        daTabla.SelectCommand.Parameters.Add("@UsuarioImpresion", SqlDbType.VarChar).Value = UsuarioImpresion
        daTabla.SelectCommand.Parameters.Add("@EquipoImpresion", SqlDbType.VarChar).Value = EquipoImpresion
        daTabla.SelectCommand.Parameters.Add("@IdVisador", SqlDbType.Int).Value = IdVisador
        daTabla.SelectCommand.Parameters.Add("@Visador", SqlDbType.VarChar).Value = Visador
        daTabla.SelectCommand.Parameters.Add("@NroCertificado", SqlDbType.Int).Value = NroCertificado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdCertificado As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_Eliminar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCertificado", SqlDbType.Int).Value = Val(IdCertificado)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarEntrega(Paciente As String, Condicion As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_BuscarEntrega", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.Parameters.Add("@Condicion", SqlDbType.VarChar).Value = Condicion
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarId(IdCertificado As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_BuscarId", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCertificado", SqlDbType.Int).Value = IdCertificado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarHistoria(Historia As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_BuscarHistoria", Cn)
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

    Public Function VerificarNroCertificado(NroCertificado As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CertificadoArmasCivil_VerificarNroCertificado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NroCertificado", SqlDbType.VarChar).Value = NroCertificado
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
