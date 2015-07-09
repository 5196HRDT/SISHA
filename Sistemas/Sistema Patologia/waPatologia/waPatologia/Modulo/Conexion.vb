Imports System.Data.SqlClient
Module Conexion
    Public Cn As New SqlConnection
    Public Cx As New SqlConnection

    Public Sub AbrirBase()
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

        Dim Base2 As String = "dbCaja"
        Cx.ConnectionString = "Database='" + Base2 + "';Data Source='" + Servidor + "';User Id='" + Usuario + "';Password='" + Password + "'"

        Try
            Cn.Open()
            Cx.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Application.Exit()
        End Try
    End Sub
End Module
