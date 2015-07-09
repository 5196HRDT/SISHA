Imports System.Data.SqlClient
Public Class clsControlAnulacionResLab
    Dim Cn As New SqlConnection

    Public Sub New()
        If Cn.State = ConnectionState.Closed Then
            Cn.ConnectionString = "Data Source=SERVIDORSQL;Initial Catalog=dbCaja;UID=sa;PWD=hrdt2003"
            Cn.Open()
        End If
    End Sub

    Public Sub Grabar(ByVal Fecha As String, ByVal Hora As String, Usuario As String, Equipo As String, IdDetalle As String, Origen As String, Motivo As String)
        Dim Cm As New SqlCommand
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "ControlAnulacionResLab_Grabar"
        Cm.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        Cm.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        Cm.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        Cm.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        Cm.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Val(IdDetalle)
        Cm.Parameters.Add("@Origen", SqlDbType.VarChar).Value = Origen
        Cm.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Motivo
        Cm.ExecuteNonQuery()
    End Sub
End Class
