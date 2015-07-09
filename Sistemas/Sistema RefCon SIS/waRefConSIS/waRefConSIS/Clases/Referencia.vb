Imports System.Data.SqlClient
Public Class Referencia
    

    Public Sub Mantenimiento(ByVal IdReferencia As String, ByVal Fecha As String, ByVal Hora As String, ByVal Usuario As String,
                             ByVal Equipo As String, ByVal Historia As String, ByVal Apaterno As String, ByVal Amaterno As String,
                             ByVal Nombres As String, ByVal NroReferencia As String, ByVal IdGrupoEtareo As String, ByVal Sexo As String, ByVal IdEstablecimiento As String,
                             ByVal Cie1 As String, ByVal Des1 As String, ByVal Td1 As String,
                             ByVal Cie2 As String, ByVal Des2 As String, ByVal Td2 As String,
                             ByVal Cie3 As String, ByVal Des3 As String, ByVal Td3 As String,
                             ByVal Cie4 As String, ByVal Des4 As String, ByVal Td4 As String,
                             ByVal IdServicio As String, ByVal IdPersonalRes As String, ByVal FechaEgreso As String,
                             ByVal CieE1 As String, ByVal DesE1 As String, ByVal TdE1 As String,
                             ByVal CieE2 As String, ByVal DesE2 As String, ByVal TdE2 As String,
                             ByVal CieE3 As String, ByVal DesE3 As String, ByVal TdE3 As String,
                             ByVal CieE4 As String, ByVal DesE4 As String, ByVal TdE4 As String,
                             ByVal IdCondicionAlta As String, ByVal IdServicioContra As String, ByVal MedicoResp As String, ByVal Oper As String,
                             ByVal Mes As String, ByVal Año As String, ByVal GesPuer As String)

        Dim daTabla As New SqlDataAdapter("SISReferencia_Mantenimiento", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdReferencia", SqlDbType.Int).Value = Val(IdReferencia)
        daTabla.SelectCommand.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = Fecha
        daTabla.SelectCommand.Parameters.Add("@Hora", SqlDbType.VarChar).Value = Hora
        daTabla.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        daTabla.SelectCommand.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = Equipo
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.Parameters.Add("@Apaterno", SqlDbType.VarChar).Value = Apaterno
        daTabla.SelectCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = Amaterno
        daTabla.SelectCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        daTabla.SelectCommand.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
        daTabla.SelectCommand.Parameters.Add("@IdGrupoEtareo", SqlDbType.Int).Value = Val(IdGrupoEtareo)
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@IdEstablecimiento", SqlDbType.Int).Value = Val(IdEstablecimiento)
        daTabla.SelectCommand.Parameters.Add("@Cie1", SqlDbType.VarChar).Value = Cie1
        daTabla.SelectCommand.Parameters.Add("@Des1", SqlDbType.VarChar).Value = Des1
        daTabla.SelectCommand.Parameters.Add("@Td1", SqlDbType.VarChar).Value = Td1
        daTabla.SelectCommand.Parameters.Add("@Cie2", SqlDbType.VarChar).Value = Cie2
        daTabla.SelectCommand.Parameters.Add("@Des2", SqlDbType.VarChar).Value = Des2
        daTabla.SelectCommand.Parameters.Add("@Td2", SqlDbType.VarChar).Value = Td2
        daTabla.SelectCommand.Parameters.Add("@Cie3", SqlDbType.VarChar).Value = Cie3
        daTabla.SelectCommand.Parameters.Add("@Des3", SqlDbType.VarChar).Value = Des3
        daTabla.SelectCommand.Parameters.Add("@Td3", SqlDbType.VarChar).Value = Td3
        daTabla.SelectCommand.Parameters.Add("@Cie4", SqlDbType.VarChar).Value = Cie4
        daTabla.SelectCommand.Parameters.Add("@Des4", SqlDbType.VarChar).Value = Des4
        daTabla.SelectCommand.Parameters.Add("@Td4", SqlDbType.VarChar).Value = Td4
        daTabla.SelectCommand.Parameters.Add("@IdServicio", SqlDbType.Int).Value = Val(IdServicio)
        daTabla.SelectCommand.Parameters.Add("@IdPersonalRes", SqlDbType.Int).Value = Val(IdPersonalRes)
        daTabla.SelectCommand.Parameters.Add("@FechaEgreso", SqlDbType.SmallDateTime).Value = FechaEgreso
        daTabla.SelectCommand.Parameters.Add("@CieE1", SqlDbType.VarChar).Value = CieE1
        daTabla.SelectCommand.Parameters.Add("@DesE1", SqlDbType.VarChar).Value = DesE1
        daTabla.SelectCommand.Parameters.Add("@TdE1", SqlDbType.VarChar).Value = TdE1
        daTabla.SelectCommand.Parameters.Add("@CieE2", SqlDbType.VarChar).Value = CieE2
        daTabla.SelectCommand.Parameters.Add("@DesE2", SqlDbType.VarChar).Value = DesE2
        daTabla.SelectCommand.Parameters.Add("@TdE2", SqlDbType.VarChar).Value = TdE2
        daTabla.SelectCommand.Parameters.Add("@CieE3", SqlDbType.VarChar).Value = CieE3
        daTabla.SelectCommand.Parameters.Add("@DesE3", SqlDbType.VarChar).Value = DesE3
        daTabla.SelectCommand.Parameters.Add("@TdE3", SqlDbType.VarChar).Value = TdE3
        daTabla.SelectCommand.Parameters.Add("@CieE4", SqlDbType.VarChar).Value = CieE4
        daTabla.SelectCommand.Parameters.Add("@DesE4", SqlDbType.VarChar).Value = DesE4
        daTabla.SelectCommand.Parameters.Add("@TdE4", SqlDbType.VarChar).Value = TdE4
        daTabla.SelectCommand.Parameters.Add("@IdCondicionAlta", SqlDbType.Int).Value = Val(IdCondicionAlta)
        daTabla.SelectCommand.Parameters.Add("@IdServicioContra", SqlDbType.Int).Value = Val(IdServicioContra)
        daTabla.SelectCommand.Parameters.Add("@MedicoResp", SqlDbType.VarChar).Value = MedicoResp
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function Buscar(ByVal Paciente As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Buscar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaHC(ByVal Historia As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_ConsultaHC", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Consulta(ByVal Tipo As String) As String
        Dim daTabla As New SqlDataAdapter("SISReferencia_Consulta", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Res", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@Res").Value
    End Function

    Public Function BuscarCIE(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarCIE", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCIEMA(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarCIEMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCIECon(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarCIECon", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarCIEConMA(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarCIEConMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Atendidos(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Atendidos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function AtendidosMA(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_AtendidosMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Atenciones(ByVal F1 As String, ByVal F2 As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Atenciones", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function AtencionesMA(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_AtencionesMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function DestinoREF(ByVal F1 As String, ByVal F2 As String, ByVal Servicio As String, ByVal Grupo As String, ByVal Tipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_DestinoREF", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function DestinoREFMA(ByVal Mes As String, ByVal Año As String, ByVal Servicio As String, ByVal Grupo As String, ByVal Tipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_DestinoREFMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarEspRef(ByVal F1 As String, ByVal F2 As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarEspRef", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarEspRefMA(ByVal Mes As String, ByVal Año As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarEspRefMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.VarChar).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarEspRefContra(ByVal F1 As String, ByVal F2 As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarEspRefContra", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarEspRefContraMA(ByVal Mes As String, ByVal Año As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarEspRefContraMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarSexoRef(ByVal F1 As String, ByVal F2 As String, ByVal Sexo As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarSexoRef", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarSexoRefMA(ByVal Mes As String, ByVal Año As String, ByVal Sexo As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_BuscarSexoRefMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cuadro2Ref(ByVal F1 As String, ByVal F2 As String, ByVal Tipo As String, ByVal Servicio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Cuadro2Ref", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cuadro2RefCat(ByVal Mes As String, ByVal Año As String, ByVal Categoria As String, ByVal servicio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Cuadro2RefCat", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = Categoria
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = servicio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cuadro2RefMA(ByVal Mes As String, ByVal Año As String, ByVal Tipo As String, ByVal Servicio As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Cuadro2RefMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Cuadro2RefAD(ByVal Mes As String, ByVal Año As String, ByVal Categoria As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Cuadro2RefAD", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = Categoria
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function CondicionAlta(ByVal F1 As String, ByVal F2 As String, ByVal Tipo As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_CondicionAlta", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function CondicionAltaMA(ByVal Mes As String, ByVal Año As String, ByVal Tipo As String, ByVal Grupo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_CondicionAltaMA", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = Grupo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Gestantes(ByVal Mes As String, ByVal Año As String, ByVal Tipo As String) As Data.DataSet
        Dim daTabla As New SqlDataAdapter("SISReferencia_Gestantes", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.VarChar).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function
End Class
