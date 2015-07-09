Imports System.Data.SqlClient
Public Class SIS
    Dim objOcurrencia As New Ocurrencia

    Public Sub GrabarIngreso(ByVal HEI As String, ByVal Lote As String, ByVal Numero As String, ByVal DISAHEI As String, ByVal LoteDISA As String, ByVal NumeroDISA As String, ByVal Correlativo As String, ByVal Aseguramiento As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal Sexo As String, ByVal Atencion As String, ByVal ESReferido As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal NroReferencia As String, ByVal Peso As String, ByVal Talla As String, ByVal EdadGestacional As String, ByVal FV As String, ByVal DNI As String, ByVal GesPuer As String, ByVal AdmOxitocina As String, ByVal VitaminaK As String, ByVal ProfilaxisOcular As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_GrabarIngreso"
            Cm.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
            Cm.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
            Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
            Cm.Parameters.Add("@DISAHEI", SqlDbType.VarChar).Value = DISAHEI
            Cm.Parameters.Add("@LoteDISA", SqlDbType.VarChar).Value = LoteDISA
            Cm.Parameters.Add("@NumeroDISA", SqlDbType.Int).Value = Val(NumeroDISA)
            Cm.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Val(Correlativo)
            Cm.Parameters.Add("@Aseguramiento", SqlDbType.VarChar).Value = Aseguramiento
            Cm.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
            Cm.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
            Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
            Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
            Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
            Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
            Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
            Cm.Parameters.Add("@Atencion", SqlDbType.VarChar).Value = Atencion
            Cm.Parameters.Add("@ESReferido", SqlDbType.VarChar).Value = ESReferido
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
            Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
            Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
            Cm.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
            Cm.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
            Cm.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
            Cm.Parameters.Add("@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
            Cm.Parameters.Add("@FechaVtoContrato", SqlDbType.SmallDateTime).Value = FV
            Cm.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
            Cm.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
            Cm.Parameters.Add("@AdmOxitocina", SqlDbType.VarChar).Value = AdmOxitocina
            Cm.Parameters.Add("@VitaminaK", SqlDbType.VarChar).Value = VitaminaK
            Cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.VarChar).Value = ProfilaxisOcular
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmIngresoSIS", ex.Message)
        End Try
    End Sub

    Public Sub GrabarIngresoFV(ByVal HEI As String, ByVal Lote As String, ByVal Numero As String, ByVal DISAHEI As String, ByVal LoteDISA As String, ByVal NumeroDISA As String, ByVal Correlativo As String, ByVal Aseguramiento As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal Sexo As String, ByVal Atencion As String, ByVal ESReferido As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal NroReferencia As String, ByVal Peso As String, ByVal Talla As String, ByVal EdadGestacional As String, ByVal FV As String, ByVal DNI As String, ByVal GesPuer As String, ByVal AdmOxitocina As String, ByVal VitaminaK As String, ByVal ProfilaxisOcular As String, ByVal UsuarioAtencion As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_GrabarIngreso"
            Cm.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
            Cm.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
            Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
            Cm.Parameters.Add("@DISAHEI", SqlDbType.VarChar).Value = DISAHEI
            Cm.Parameters.Add("@LoteDISA", SqlDbType.VarChar).Value = LoteDISA
            Cm.Parameters.Add("@NumeroDISA", SqlDbType.Int).Value = Val(NumeroDISA)
            Cm.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Val(Correlativo)
            Cm.Parameters.Add("@Aseguramiento", SqlDbType.VarChar).Value = Aseguramiento
            Cm.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
            Cm.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
            Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
            Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
            Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
            Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
            Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
            Cm.Parameters.Add("@Atencion", SqlDbType.VarChar).Value = Atencion
            Cm.Parameters.Add("@ESReferido", SqlDbType.VarChar).Value = ESReferido
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
            Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
            Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
            Cm.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
            Cm.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
            Cm.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
            Cm.Parameters.Add("@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
            Cm.Parameters.Add("@FechaVtoContrato", SqlDbType.SmallDateTime).Value = FV
            Cm.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
            Cm.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
            Cm.Parameters.Add("@AdmOxitocina", SqlDbType.VarChar).Value = AdmOxitocina
            Cm.Parameters.Add("@VitaminaK", SqlDbType.VarChar).Value = VitaminaK
            Cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.VarChar).Value = ProfilaxisOcular
            Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmIngresoSIS", ex.Message)
        End Try
    End Sub

   


    


    Public Sub GrabarIngresoAP(ByVal HEI As String, ByVal Lote As String, ByVal Numero As String, ByVal DISAHEI As String, ByVal LoteDISA As String, ByVal NumeroDISA As String, ByVal Correlativo As String, ByVal Aseguramiento As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal Sexo As String, ByVal Atencion As String, ByVal ESReferido As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal NroReferencia As String, ByVal Peso As String, ByVal Talla As String, ByVal EdadGestacional As String, ByVal FV As String, ByVal DNI As String, ByVal GesPuer As String, ByVal AdmOxitocina As String, ByVal VitaminaK As String, ByVal ProfilaxisOcular As String, ByVal UsuarioAtencion As String, ByVal Apgar1 As String, ByVal Apgar5 As String, ByVal BCG As String, ByVal HVB As String, ByVal tipo As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_GrabarIngresoAP2"
            Cm.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
            Cm.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
            Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
            Cm.Parameters.Add("@DISAHEI", SqlDbType.VarChar).Value = DISAHEI
            Cm.Parameters.Add("@LoteDISA", SqlDbType.VarChar).Value = LoteDISA
            Cm.Parameters.Add("@NumeroDISA", SqlDbType.Int).Value = Val(NumeroDISA)
            Cm.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Val(Correlativo)
            Cm.Parameters.Add("@Aseguramiento", SqlDbType.VarChar).Value = Aseguramiento
            Cm.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
            Cm.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
            Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
            Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
            Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
            Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
            Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
            Cm.Parameters.Add("@Atencion", SqlDbType.VarChar).Value = Atencion
            Cm.Parameters.Add("@ESReferido", SqlDbType.VarChar).Value = ESReferido
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
            Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
            Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
            Cm.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
            Cm.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
            Cm.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
            Cm.Parameters.Add("@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
            Cm.Parameters.Add("@FechaVtoContrato", SqlDbType.SmallDateTime).Value = FV
            Cm.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
            Cm.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
            Cm.Parameters.Add("@AdmOxitocina", SqlDbType.VarChar).Value = AdmOxitocina
            Cm.Parameters.Add("@VitaminaK", SqlDbType.VarChar).Value = VitaminaK
            Cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.VarChar).Value = ProfilaxisOcular
            Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
            Cm.Parameters.Add("@Apgar1", SqlDbType.VarChar).Value = Apgar1
            Cm.Parameters.Add("@Apgar5", SqlDbType.VarChar).Value = Apgar5
            Cm.Parameters.Add("@BCG", SqlDbType.VarChar).Value = BCG
            Cm.Parameters.Add("@HVB", SqlDbType.VarChar).Value = HVB
            Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = tipo
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmIngresoSIS", ex.Message)
        End Try
    End Sub

    Public Sub ModificarIngreso(ByVal IdSIS As String, ByVal HEI As String, ByVal Lote As String, ByVal Numero As String, ByVal DISAHEI As String, ByVal LoteDISA As String, ByVal NumeroDISA As String, ByVal Correlativo As String, ByVal Aseguramiento As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal Sexo As String, ByVal Atencion As String, ByVal ESReferido As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal NroReferencia As String, ByVal Peso As String, ByVal Talla As String, ByVal EdadGestacional As String, ByVal FV As String, ByVal DNI As String, ByVal GesPuer As String, ByVal AdmOxitocina As String, ByVal VitaminaK As String, ByVal ProfilaxisOcular As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_ModificarIngreso"
        Cm.Parameters.Add("@IdSIS", SqlDbType.VarChar).Value = IdSIS
        Cm.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
        Cm.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        Cm.Parameters.Add("@DISAHEI", SqlDbType.VarChar).Value = DISAHEI
        Cm.Parameters.Add("@LoteDISA", SqlDbType.VarChar).Value = LoteDISA
        Cm.Parameters.Add("@NumeroDISA", SqlDbType.Int).Value = Val(NumeroDISA)
        Cm.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Val(Correlativo)
        Cm.Parameters.Add("@Aseguramiento", SqlDbType.VarChar).Value = Aseguramiento
        Cm.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
        Cm.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@Atencion", SqlDbType.VarChar).Value = Atencion
        Cm.Parameters.Add("@ESReferido", SqlDbType.VarChar).Value = ESReferido
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Cm.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
        Cm.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        Cm.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        Cm.Parameters.Add("@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
        Cm.Parameters.Add("@FechaVtoContrato", SqlDbType.SmallDateTime).Value = FV
        Cm.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        Cm.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
        Cm.Parameters.Add("@AdmOxitocina", SqlDbType.VarChar).Value = AdmOxitocina
        Cm.Parameters.Add("@VitaminaK", SqlDbType.VarChar).Value = VitaminaK
        Cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.VarChar).Value = ProfilaxisOcular
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub ModificarIngresoAP(ByVal IdSIS As String, ByVal HEI As String, ByVal Lote As String, ByVal Numero As String, ByVal DISAHEI As String, ByVal LoteDISA As String, ByVal NumeroDISA As String, ByVal Correlativo As String, ByVal Aseguramiento As String, ByVal Situacion As String, ByVal PlanSIS As String, ByVal Historia As String, ByVal APaterno As String, ByVal AMaterno As String, ByVal Nombres As String, ByVal Sexo As String, ByVal Atencion As String, ByVal ESReferido As String, ByVal FechaAtencion As String, ByVal HoraAtencion As String, ByVal EquipoAtencion As String, ByVal Especialidad As String, ByVal SubEspecialidad As String, ByVal NroReferencia As String, ByVal Peso As String, ByVal Talla As String, ByVal EdadGestacional As String, ByVal FV As String, ByVal DNI As String, ByVal GesPuer As String, ByVal AdmOxitocina As String, ByVal VitaminaK As String, ByVal ProfilaxisOcular As String, ByVal Apgar1 As String, ByVal Apgar5 As String, ByVal BCG As String, ByVal HVB As String, ByVal Tipo As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_ModificarIngresoAP2"
        Cm.Parameters.Add("@IdSIS", SqlDbType.VarChar).Value = IdSIS
        Cm.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
        Cm.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        Cm.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        Cm.Parameters.Add("@DISAHEI", SqlDbType.VarChar).Value = DISAHEI
        Cm.Parameters.Add("@LoteDISA", SqlDbType.VarChar).Value = LoteDISA
        Cm.Parameters.Add("@NumeroDISA", SqlDbType.Int).Value = Val(NumeroDISA)
        Cm.Parameters.Add("@Correlativo", SqlDbType.Int).Value = Val(Correlativo)
        Cm.Parameters.Add("@Aseguramiento", SqlDbType.VarChar).Value = Aseguramiento
        Cm.Parameters.Add("@Situacion", SqlDbType.VarChar).Value = Situacion
        Cm.Parameters.Add("@PlanSIS", SqlDbType.VarChar).Value = PlanSIS
        Cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        Cm.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = APaterno
        Cm.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = AMaterno
        Cm.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres
        Cm.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = Sexo
        Cm.Parameters.Add("@Atencion", SqlDbType.VarChar).Value = Atencion
        Cm.Parameters.Add("@ESReferido", SqlDbType.VarChar).Value = ESReferido
        Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = FechaAtencion
        Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = HoraAtencion
        Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
        Cm.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        Cm.Parameters.Add("@SubEspecialidad", SqlDbType.VarChar).Value = SubEspecialidad
        Cm.Parameters.Add("@NroReferencia", SqlDbType.VarChar).Value = NroReferencia
        Cm.Parameters.Add("@Peso", SqlDbType.VarChar).Value = Peso
        Cm.Parameters.Add("@Talla", SqlDbType.VarChar).Value = Talla
        Cm.Parameters.Add("@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
        Cm.Parameters.Add("@FechaVtoContrato", SqlDbType.SmallDateTime).Value = FV
        Cm.Parameters.Add("@DNI", SqlDbType.VarChar).Value = DNI
        Cm.Parameters.Add("@GesPuer", SqlDbType.VarChar).Value = GesPuer
        Cm.Parameters.Add("@AdmOxitocina", SqlDbType.VarChar).Value = AdmOxitocina
        Cm.Parameters.Add("@VitaminaK", SqlDbType.VarChar).Value = VitaminaK
        Cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.VarChar).Value = ProfilaxisOcular
        Cm.Parameters.Add("@Apgar1", SqlDbType.VarChar).Value = Apgar1
        Cm.Parameters.Add("@Apgar5", SqlDbType.VarChar).Value = Apgar5
        Cm.Parameters.Add("@BCG", SqlDbType.VarChar).Value = BCG
        Cm.Parameters.Add("@HVB", SqlDbType.VarChar).Value = HVB
        Cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        Cm.ExecuteNonQuery()
    End Sub

    Public Function ConsultarHEI(ByVal HEI As String, ByVal Lote As String, ByVal Numero As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From SISHRDT Where HEI = '" + HEI + "' And Lote = '" + Lote + "' And Numero =" + Numero + "", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    

    Public Function ConsultarHEIHistoria(ByVal Historia As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From SISHRDT Where Historia= '" + Historia + "' And FechaAlta Is Null", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Sub GrabarSalida(ByVal IdSiS As String, ByVal Servicio As String, ByVal Destino As String, ByVal FechaAlta As String, ByVal HoraAlta As String, ByVal EquipoAlta As String, ByVal CodDiagIng1 As String, ByVal DesDiagIng1 As String, ByVal TipoDiagIng1 As String, ByVal CodDiagIng2 As String, ByVal DesDiagIng2 As String, ByVal TipoDiagIng2 As String, ByVal CodDiagIng3 As String, ByVal DesDiagIng3 As String, ByVal TipoDiagIng3 As String, ByVal CodDiagIng4 As String, ByVal DesDiagIng4 As String, ByVal TipoDiagIng4 As String, ByVal CodDiagIng5 As String, ByVal DesDiagIng5 As String, ByVal TipoDiagIng5 As String, ByVal CodDiagEgr1 As String, ByVal TipoDiagEgr1 As String, ByVal CodDiagEgr2 As String, ByVal TipoDiagEgr2 As String, ByVal CodDiagEgr3 As String, ByVal TipoDiagEgr3 As String, ByVal CodDiagEgr4 As String, ByVal TipoDiagEgr4 As String, ByVal CodDiagEgr5 As String, ByVal TipoDiagEgr5 As String, ByVal IdResponsable As String, ByVal EsContraRef As String, ByVal Responsable As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_GrabarSalida"
            Cm.Parameters.Add("@IdSIS", SqlDbType.VarChar).Value = Val(IdSiS)
            Cm.Parameters.Add("@Servicio", SqlDbType.VarChar).Value = Servicio
            Cm.Parameters.Add("@Destino", SqlDbType.VarChar).Value = Destino
            Cm.Parameters.Add("@FechaAlta", SqlDbType.SmallDateTime).Value = FechaAlta
            Cm.Parameters.Add("@HoraAlta", SqlDbType.VarChar).Value = HoraAlta
            Cm.Parameters.Add("@EquipoAlta", SqlDbType.VarChar).Value = EquipoAlta
            Cm.Parameters.Add("@CodDiagIng1", SqlDbType.VarChar).Value = CodDiagIng1
            Cm.Parameters.Add("@DesDiagIng1", SqlDbType.VarChar).Value = DesDiagIng1
            Cm.Parameters.Add("@TipoDiagIng1", SqlDbType.VarChar).Value = TipoDiagIng1
            Cm.Parameters.Add("@CodDiagIng2", SqlDbType.VarChar).Value = CodDiagIng2
            Cm.Parameters.Add("@DesDiagIng2", SqlDbType.VarChar).Value = DesDiagIng2
            Cm.Parameters.Add("@TipoDiagIng2", SqlDbType.VarChar).Value = TipoDiagIng2
            Cm.Parameters.Add("@CodDiagIng3", SqlDbType.VarChar).Value = CodDiagIng3
            Cm.Parameters.Add("@DesDiagIng3", SqlDbType.VarChar).Value = DesDiagIng3
            Cm.Parameters.Add("@TipoDiagIng3", SqlDbType.VarChar).Value = TipoDiagIng3
            Cm.Parameters.Add("@CodDiagIng4", SqlDbType.VarChar).Value = CodDiagIng4
            Cm.Parameters.Add("@DesDiagIng4", SqlDbType.VarChar).Value = DesDiagIng4
            Cm.Parameters.Add("@TipoDiagIng4", SqlDbType.VarChar).Value = TipoDiagIng4
            Cm.Parameters.Add("@CodDiagIng5", SqlDbType.VarChar).Value = CodDiagIng5
            Cm.Parameters.Add("@DesDiagIng5", SqlDbType.VarChar).Value = DesDiagIng5
            Cm.Parameters.Add("@TipoDiagIng5", SqlDbType.VarChar).Value = TipoDiagIng5
            Cm.Parameters.Add("@CodDiagEgr1", SqlDbType.VarChar).Value = CodDiagEgr1
            Cm.Parameters.Add("@TipoDiagEgr1", SqlDbType.VarChar).Value = TipoDiagEgr1
            Cm.Parameters.Add("@CodDiagEgr2", SqlDbType.VarChar).Value = CodDiagEgr2
            Cm.Parameters.Add("@TipoDiagEgr2", SqlDbType.VarChar).Value = TipoDiagEgr2
            Cm.Parameters.Add("@CodDiagEgr3", SqlDbType.VarChar).Value = CodDiagEgr3
            Cm.Parameters.Add("@TipoDiagEgr3", SqlDbType.VarChar).Value = TipoDiagEgr3
            Cm.Parameters.Add("@CodDiagEgr4", SqlDbType.VarChar).Value = CodDiagEgr4
            Cm.Parameters.Add("@TipoDiagEgr4", SqlDbType.VarChar).Value = TipoDiagEgr4
            Cm.Parameters.Add("@CodDiagEgr5", SqlDbType.VarChar).Value = CodDiagEgr5
            Cm.Parameters.Add("@TipoDiagEgr5", SqlDbType.VarChar).Value = TipoDiagEgr5
            Cm.Parameters.Add("@IdResponsable", SqlDbType.Int).Value = Val(IdResponsable)
            Cm.Parameters.Add("@EsContraRef", SqlDbType.VarChar).Value = EsContraRef
            Cm.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = Responsable
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmSalidaSIS", ex.Message)
        End Try
    End Sub

    Public Sub GrabarProcedimientos(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_Procedimientos_Grabar"
            Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmProcedimientos", ex.Message)
        End Try
    End Sub

    Public Sub GrabarProcedimientosN(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, UsuRegistro As String, EquipoRegistro As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_Procedimientos_GrabarN"
            Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.Parameters.Add("@FechaRegistro", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
            Cm.Parameters.Add("@HoraRegistro", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
            Cm.Parameters.Add("@UsuRegistro", SqlDbType.VarChar).Value = UsuRegistro
            Cm.Parameters.Add("@EquipoRegistro", SqlDbType.VarChar).Value = EquipoRegistro
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmProcedimientos", ex.Message)
        End Try
    End Sub

    Public Sub GrabarProcedimientosAtendidos(ByVal IdSis As String, ByVal IdProcedimiento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String, UsuarioAtencion As String, EquipoAtencion As String)
        Try
            Dim Cm As New SqlCommand
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Cm.Connection = Cn
            Cm.CommandType = CommandType.StoredProcedure
            Cm.CommandText = "SisHRDT_Procedimientos_GrabarAtendidos"
            Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
            Cm.Parameters.Add("@IdProcedimiento", SqlDbType.Int).Value = Val(IdProcedimiento)
            Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
            Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
            Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
            Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
            Cm.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime).Value = Date.Now.ToShortDateString
            Cm.Parameters.Add("@HoraAtencion", SqlDbType.VarChar).Value = Date.Now.ToShortTimeString
            Cm.Parameters.Add("@UsuarioAtencion", SqlDbType.VarChar).Value = UsuarioAtencion
            Cm.Parameters.Add("@EquipoAtencion", SqlDbType.VarChar).Value = EquipoAtencion
            Cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "frmProcedimientos", ex.Message)
        End Try
    End Sub

    Public Sub GrabarMedicamentos(ByVal IdSis As String, ByVal IdMedicamento As String, ByVal Descripcion As String, ByVal Precio As String, ByVal Cantidad As String, ByVal Importe As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_Medicamentos_Grabar"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.Parameters.Add("@IdMedicamento", SqlDbType.VarChar).Value = IdMedicamento
        Cm.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        Cm.Parameters.Add("@Precio", SqlDbType.Money).Value = Val(Precio)
        Cm.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Val(Cantidad)
        Cm.Parameters.Add("@Importe", SqlDbType.Money).Value = Val(Importe)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function BuscarProcedimientos(ByVal IdSis As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From SisHRDT_Procedimientos Where IdSis = " + IdSis + "", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarProcedimientosAten(ByVal IdSis As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From SisHRDT_Procedimientos Where IdSis = " + IdSis + " And FechaAtencion Is Not Null", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarMedicamentos(ByVal IdSis As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("Select * From SisHRDT_Medicamentos Where IdSis = " + IdSis + " Order By Fecha, Hora", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function ConsultaAtencionSIS(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultaAtencionSIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente

        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaAtencionSIS1(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultaAtencionSIS1", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente

        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaAtencionHospSIS(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultaAtencionHospSIS", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente

        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaAtencionHospSISMES(ByVal F1 As String, ByVal F2 As String, ByVal Paciente As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultaAtencionHospSISMES", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Paciente", SqlDbType.VarChar).Value = Paciente

        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function PacientesAtendidos(ByVal Mes As String, ByVal Año As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_PacientesAtendidos", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Mes", SqlDbType.Int).Value = Mes
        daTabla.SelectCommand.Parameters.Add("@Año", SqlDbType.Int).Value = Año

        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function ConsultaAtencionPaciente(ByVal NHistoria As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_ConsultaAtencionPaciente", Cn)
        Dim dstabla As New Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@NHistoria", SqlDbType.VarChar).Value = NHistoria.ToString
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Sub RecuperarAlta(ByVal IdSis As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_RecuperarSIS"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub AnularSIS(ByVal IdSis As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_AnularSIS"
        Cm.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        Cm.ExecuteNonQuery()
    End Sub

    Public Sub AnularDetalle(ByVal Id As String)
        Dim Cm As New SqlCommand
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Cm.Connection = Cn
        Cm.CommandType = CommandType.StoredProcedure
        Cm.CommandText = "SisHRDT_AnularDetalle"
        Cm.Parameters.Add("@Id", SqlDbType.Int).Value = Val(Id)
        Cm.ExecuteNonQuery()
    End Sub

    Public Function ConsultarSusalud(ByVal mes As String, ByVal anio As Integer) As DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim dsTabla As New DataSet
        Dim daTabla As New SqlDataAdapter("SIS_REPORTE_SUSALUD", Cn)
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes
        daTabla.SelectCommand.Parameters.Add("@anio", SqlDbType.Int).Value = anio
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function BuscarProcedimientosConsolidados(ByVal IdSIS As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SisHRDT_BuscarProcedimientosConsolidados", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSIS", SqlDbType.Int).Value = IdSIS
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function


    Public Function BuscarInformRX(ByVal Id As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarInformeRX", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Int(Id)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function BuscarResumenMed(ByVal Id As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_BuscarResumenMed", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Int(Id)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Verificar(ByVal HEI As String, ByVal Lote As String, ByVal Numero As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_Verificar", Cn)
        Dim dstabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@HEI", SqlDbType.VarChar).Value = HEI
        daTabla.SelectCommand.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Lote
        daTabla.SelectCommand.Parameters.Add("@Numero", SqlDbType.Int).Value = Val(Numero)
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dstabla)
        Return dstabla
    End Function

    Public Function Produccion(ByVal F1 As String, ByVal F2 As String, ByVal Tipo As String, ByVal ClasLaboratorio As String, ByVal Especialidad As String, ByVal Descripcion As String, ByVal Oper As String) As Data.DataSet
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_Produccion", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@F1", SqlDbType.SmallDateTime).Value = F1
        daTabla.SelectCommand.Parameters.Add("@F2", SqlDbType.SmallDateTime).Value = F2
        daTabla.SelectCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
        daTabla.SelectCommand.Parameters.Add("@ClasLaboratorio", SqlDbType.VarChar).Value = ClasLaboratorio
        daTabla.SelectCommand.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = Especialidad
        daTabla.SelectCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion
        daTabla.SelectCommand.Parameters.Add("@Oper", SqlDbType.VarChar).Value = Oper
        daTabla.SelectCommand.ExecuteNonQuery()
        daTabla.Fill(dsTabla)
        Return dsTabla
    End Function

    Public Function Autogenerado() As String

        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_Autogenerado", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Direction = ParameterDirection.Output
        daTabla.SelectCommand.ExecuteNonQuery()
        Return daTabla.SelectCommand.Parameters("@IdSis").Value
    End Function

    Public Sub MontoUCI(ByVal IdSis As String, ByVal MontoUCI As String)
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim daTabla As New SqlDataAdapter("SISHRDT_MontoUCI", Cn)
        Dim dsTabla As New Data.DataSet
        daTabla.SelectCommand.CommandType = CommandType.StoredProcedure
        daTabla.SelectCommand.Parameters.Add("@IdSis", SqlDbType.Int).Value = Val(IdSis)
        daTabla.SelectCommand.Parameters.Add("@MontoUCI", SqlDbType.Money).Value = Val(MontoUCI)
        daTabla.SelectCommand.ExecuteNonQuery()
    End Sub

    Public Function LoteListar(ByVal IdTipoAfiliacion As Integer) As DataSet
        Dim ds As New DataSet
        If Cn.State = ConnectionState.Connecting Then Cn.Open()
        Dim da As New SqlDataAdapter("sp_TipoAfiliacionSISListar", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@idTipoAfiliacion", SqlDbType.Int).Value = IdTipoAfiliacion
        da.SelectCommand.ExecuteNonQuery()
        da.Fill(ds)
        Return ds
    End Function


    Public Function CentroSaludListar(ByVal Nombre As String) As DataSet
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_EstablecimientoSaludListar", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Nombre
        If Cn.State = ConnectionState.Connecting Then Cn.Open()
        da.SelectCommand.ExecuteNonQuery()
        da.Fill(ds)
        Return ds
    End Function

    Public Function NeoNatoBuscar(ByVal IdPaciente As Integer) As DataSet
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_NeoNatoBuscar", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@idpaciente", SqlDbType.Int).Value = IdPaciente
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        da.SelectCommand.ExecuteNonQuery()
        da.Fill(ds)
        Return ds
    End Function

    Public Function GestanteBuscar(ByVal IdPaciente As Integer) As DataSet
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_GestanteBuscar", Cn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@idpaciente", SqlDbType.Int).Value = IdPaciente
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        da.SelectCommand.ExecuteNonQuery()
        da.Fill(ds)
        Return ds
    End Function

    Public Sub GrabarGestante(ByVal IdPaciente As Integer, ByVal Peso As Integer, ByVal Talla As Integer, ByVal EdadGestacional As Integer, ByVal PresionArt As String, ByVal FechaParto As DateTime, ByVal tipoParto As String)
        Try
            Dim cm As New SqlCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "sp_GestanteIngresar"
            cm.Connection = Cn
            cm.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente
            cm.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso
            cm.Parameters.Add("@Tall", SqlDbType.TinyInt).Value = Talla
            cm.Parameters.Add("@EdadGestacional", SqlDbType.TinyInt).Value = EdadGestacional
            cm.Parameters.Add("@PresionArterial", SqlDbType.VarChar).Value = PresionArt
            cm.Parameters.Add("@FechaParto", SqlDbType.DateTime).Value = FechaParto
            cm.Parameters.Add("@TipoParto", SqlDbType.VarChar).Value = tipoParto
            If Cn.State <> ConnectionState.Open Then
                Cn.Open()
            End If
            cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub

    Public Sub GrabarNeoNato(ByVal IdPaciente As Integer, ByVal Peso As Integer, ByVal Talla As Integer, ByVal EdadGestacional As Integer, ByVal Apgar1 As Integer, ByVal Apgar5 As Integer, ByVal VacunaBCG As Boolean, ByVal VacunaHVB As Boolean, ByVal ProfilaxisOcular As Boolean, ByVal Tipo As String)

        Try
            Dim cm As New SqlCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.Connection = Cn
            cm.CommandText = "sp_NeoNatoIngresar"
            cm.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente
            cm.Parameters.Add("@Peso", SqlDbType.Int).Value = Val(Peso)
            cm.Parameters.Add("@Talla", SqlDbType.TinyInt).Value = Val(Talla)
            cm.Parameters.Add("@EdadGestacional", SqlDbType.TinyInt).Value = Val(EdadGestacional)
            cm.Parameters.Add("@Apgar1", SqlDbType.TinyInt).Value = Val(Apgar1)
            cm.Parameters.Add("@Apgar5", SqlDbType.TinyInt).Value = Val(Apgar5)
            cm.Parameters.Add("@VacunaBCG", SqlDbType.Bit).Value = Val(VacunaBCG)
            cm.Parameters.Add("@VacunaHVB", SqlDbType.Bit).Value = Val(VacunaHVB)
            cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.Bit).Value = Val(ProfilaxisOcular)
            cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If
            cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub
    Public Sub ModificarNeoNato(ByVal IdNeoNato As Integer, ByVal IdPaciente As Integer, ByVal Peso As Integer, ByVal Talla As Integer, ByVal EdadGestacional As Integer, ByVal Apgar1 As Integer, ByVal Apgar5 As Integer, ByVal VacunaBCG As Boolean, ByVal VacunaHVB As Boolean, ByVal ProfilaxisOcular As Boolean, ByVal Tipo As String)

        Try
            Dim cm As New SqlCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.Connection = Cn
            cm.CommandText = "sp_NeoNatoModificar"
            cm.Parameters.Add("@IdNeonato", SqlDbType.Int).Value = IdNeoNato
            cm.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente
            cm.Parameters.Add("@Peso", SqlDbType.Int).Value = Val(Peso)
            cm.Parameters.Add("@Talla", SqlDbType.TinyInt).Value = Val(Talla)
            cm.Parameters.Add("@EdadGestacional", SqlDbType.TinyInt).Value = Val(EdadGestacional)
            cm.Parameters.Add("@Apgar1", SqlDbType.TinyInt).Value = Val(Apgar1)
            cm.Parameters.Add("@Apgar5", SqlDbType.TinyInt).Value = Val(Apgar5)
            cm.Parameters.Add("@VacunaBCG", SqlDbType.Bit).Value = Val(VacunaBCG)
            cm.Parameters.Add("@VacunaHVB", SqlDbType.Bit).Value = Val(VacunaHVB)
            cm.Parameters.Add("@ProfilaxisOcular", SqlDbType.Bit).Value = Val(ProfilaxisOcular)
            cm.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Tipo
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If
            cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub
    Public Sub ModificarGestante(ByVal IdGestante As Integer, ByVal IdPaciente As Integer, ByVal Peso As Integer, ByVal Talla As Integer, ByVal EdadGestacional As Integer, ByVal PresionArt As String, ByVal FechaParto As DateTime, ByVal tipoParto As String)
        Try
            Dim cm As New SqlCommand
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandText = "sp_GestanteModificar"
            cm.Connection = Cn
            cm.Parameters.Add("@IdGestante", SqlDbType.Int).Value = IdGestante
            cm.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = IdPaciente
            cm.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso
            cm.Parameters.Add("@Talla", SqlDbType.TinyInt).Value = Talla
            cm.Parameters.Add("@EdadGestacional", SqlDbType.TinyInt).Value = EdadGestacional
            cm.Parameters.Add("@PresionArterial", SqlDbType.VarChar).Value = PresionArt
            cm.Parameters.Add("@FechaParto", SqlDbType.DateTime).Value = FechaParto
            cm.Parameters.Add("@TipoParto", SqlDbType.VarChar).Value = tipoParto
            If Cn.State <> ConnectionState.Open Then
                Cn.Open()
            End If
            cm.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub
    Public Sub EliminarNeoNato(ByVal IdNeoNato As Integer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_NeoNatoEliminar"
            cmd.Connection = Cn
            cmd.Parameters.Add("@IdNeoNato", SqlDbType.Int).Value = IdNeoNato
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub

    Public Sub EliminarGestante(ByVal idGestante As Integer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_GestanteEliminar"
            cmd.Connection = Cn
            cmd.Parameters.Add("@IdGestante", SqlDbType.Int).Value = idGestante
            If Cn.State = ConnectionState.Closed Then
                Cn.Open()
            End If
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            objOcurrencia.Grabar("SIS", "FrmIngresoSIS", ex.Message)
        End Try
    End Sub

End Class
