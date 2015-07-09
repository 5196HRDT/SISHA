Imports System.Data.SqlClient
Public Class clsEmergenciaSer
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

    'Public Sub GrabarContado(ByVal IdIngreso As String, ByVal IdServicio As String, Descripcion As String, Precio As String, Cantidad As String, Tipo As String)
    '    Do While Cn.State = ConnectionState.Closed
    '        Cn.Open()
    '    Loop
    '    Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarContado", Cn)
    '    Dim dstabla As New Data.DataSet
    '    daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
    '    daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
    '    daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
    '    daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
    '    daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
    '    daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
    '    daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
    '    Do While Cn.State = ConnectionState.Closed
    '        Cn.Open()
    '    Loop
    '    daTabla.SelectCommand.ExecuteNonQuery()
    'End Sub

    Public Sub GrabarContado(ByVal IdIngreso As String, ByVal IdServicio As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Tipo As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal SubTipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarContado", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal IdEmerSer As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_Eliminar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = Val(IdEmerSer)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub GrabarConvenio(ByVal IdIngreso As String, ByVal IdServicio As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Cancelado As String, ByVal FecCan As String, ByVal HorCan As String, ByVal UsuCan As String, ByVal EquipoAtencion As String, ByVal IdPersonal As String, ByVal Personal As String, ByVal Tipo As String, ByVal FechaRegistro As String, ByVal HoraRegistro As String, ByVal UsuarioRegistro As String, ByVal SubTipo As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_GrabarConvenio", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio
        daTabla.SelectCommand.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad
        daTabla.SelectCommand.Parameters.Add("@Cancelado", SqlDbType.VarChar).Value = Cancelado
        daTabla.SelectCommand.Parameters.Add("@FecCan", SqlDbType.SmallDateTime).Value = FecCan
        daTabla.SelectCommand.Parameters.Add("@HorCan", SqlDbType.VarChar).Value = HorCan
        daTabla.SelectCommand.Parameters.Add("@UsuCan", SqlDbType.VarChar).Value = Microsoft.VisualBasic.Left(UsuCan, 10)
        daTabla.SelectCommand.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        daTabla.SelectCommand.Parameters.Add("@IdPersonal", SqlDbType.Int).Value = Val(IdPersonal)
        daTabla.SelectCommand.Parameters.Add("@Personal", SqlDbType.VarChar).Value = Personal
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = FechaRegistro
        daTabla.SelectCommand.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = HoraRegistro
        daTabla.SelectCommand.Parameters.Add("@UsuarioRegistro", SqlDbType.VarChar).Value = UsuarioRegistro
        daTabla.SelectCommand.Parameters.Add("@SubTipo", SqlDbType.VarChar).Value = SubTipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub PendientePago(ByVal IdEmerSer As String, ByVal FechaPendiente As String, HoraPendiente As String, UsuarioPendiente As String, EquipoPendiente As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_PendientePago", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = Val(IdEmerSer)
        daTabla.SelectCommand.Parameters.Add("@FechaPendiente", SqlDbType.SmallDateTime).Value = FechaPendiente
        daTabla.SelectCommand.Parameters.Add("@HoraPendiente", SqlDbType.VarChar).Value = HoraPendiente
        daTabla.SelectCommand.Parameters.Add("@UsuarioPendiente", SqlDbType.VarChar).Value = UsuarioPendiente
        daTabla.SelectCommand.Parameters.Add("@EquipoPendiente", SqlDbType.VarChar).Value = EquipoPendiente
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function BuscarTipo(IdIngreso As String, Tipo As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarTipo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarTodo(IdIngreso As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarTodo", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarDeuda(IdIngreso As String) As Data.DataSet
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_BuscarDeuda", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = IdIngreso
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub AnularProcedimientos(ByVal IdIngreso As String, ByVal FecAnu As String, HorAnu As String, UsuAnu As String, MotivoAnu As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_AnularProcedimientos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Val(IdIngreso)
        daTabla.SelectCommand.Parameters.Add("@FecAnu", SqlDbType.SmallDateTime).Value = FecAnu
        daTabla.SelectCommand.Parameters.Add("@HorAnu", SqlDbType.VarChar).Value = HorAnu
        daTabla.SelectCommand.Parameters.Add("@UsuAnu", SqlDbType.VarChar).Value = UsuAnu
        daTabla.SelectCommand.Parameters.Add("@MotivoAnu", SqlDbType.VarChar).Value = MotivoAnu
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Sub AnularProcedimientosDet(ByVal IdEmerSer As String, ByVal FecAnu As String, ByVal HorAnu As String, ByVal UsuAnu As String, ByVal MotivoAnu As String)
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        Dim daTabla As New SqlDataAdapter("EmergenciaSer_AnularProcedimientosDet", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdEmerSer", SqlDbType.Int).Value = Val(IdEmerSer)
        daTabla.SelectCommand.Parameters.Add("@FecAnu", SqlDbType.SmallDateTime).Value = FecAnu
        daTabla.SelectCommand.Parameters.Add("@HorAnu", SqlDbType.VarChar).Value = HorAnu
        daTabla.SelectCommand.Parameters.Add("@UsuAnu", SqlDbType.VarChar).Value = UsuAnu
        daTabla.SelectCommand.Parameters.Add("@MotivoAnu", SqlDbType.VarChar).Value = MotivoAnu
        Do While Cn.State = ConnectionState.Closed
            Cn.Open()
        Loop
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

End Class

