Imports System.Data.SqlClient
Public Class clsCIE10HE
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

        Servidor = "ServidorSQL"
        Base = "dbCaja"
        Usuario = "SA"
        Password = "hrdt2003"


        Cn.ConnectionString = "Database='" + Base + "';Data Source='" + Servidor + "';User Id='" + Usuario + "';Password='" + Password + "'"
        Try
            Cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
    End Sub

    Public Function BuscarFiltro(ByVal Filtro As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10HE_BuscarFiltro", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCodigo(ByVal Codigo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10HE_BuscarCodigo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub Mantenimiento(ByVal IdCIE10 As String, ByVal desc_enf As String, ByVal cod_gen As String, ByVal Definitivo As String, ByVal Activo As String, ByVal Oper As String, ByVal Emergencia As String, ByVal PrioridadE As String, ByVal PrioridadH As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("CIE10HE_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdCIE10", SqlDbType.Int).Value = IdCIE10
        daTabla.SelectCommand.Parameters.Add("@desc_enf", SqlDbType.VarChar).Value = desc_enf
        daTabla.SelectCommand.Parameters.Add("@cod_gen", SqlDbType.VarChar).Value = cod_gen
        daTabla.SelectCommand.Parameters.Add("@Definitivo", SqlDbType.VarChar).Value = Definitivo
        daTabla.SelectCommand.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Activo
        daTabla.SelectCommand.Parameters.Add("@Emergencia", SqlDbType.VarChar).Value = Emergencia
        daTabla.SelectCommand.Parameters.Add("@PrioridadE", SqlDbType.VarChar).Value = PrioridadE
        daTabla.SelectCommand.Parameters.Add("@PrioridadH", SqlDbType.VarChar).Value = PrioridadH
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarDes(ByVal Des As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From CIE10HE Where desc_enf Like '" + Des + "%' Order By desc_enf", Cn)
        Dim dsTabla As New Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function
End Class
