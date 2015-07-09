Imports System.Data.SqlClient
Public Class Neo_Hospitaliza
    Dim Cn As New SqlConnection
    Dim Cm As New SqlCommand
    Public Sub Mantenimiento(ByVal IdHospitalizacion As String, ByVal Historia As String, ByVal FechaIngreso As String, ByVal HoraNacimiento As String, ByVal TipoNacimiento As String, ByVal PesoAlNacer As String, ByVal EdadGestacional As String, ByVal ApgarAlMinuto As String, ByVal RelaPesoEdadGes As String, ByVal ReanimaNeonatal As String, ByVal InfecIntrahos As String, ByVal OxigenoTerapia As String, ByVal OxigenoterapiaHoras As String, ByVal CpapNasalDias As String, ByVal CpapNasalCompli As String, ByVal VmcDias As String, ByVal VmcCompli As String, ByVal VafoDias As String, ByVal VafoCompli As String, ByVal SurfacDosis As String, ByVal SurfacCompli As String, ByVal FototerapiaDias As String, ByVal CateVenoCentralDias As String, ByVal CateVenoCentralCompli As String, ByVal CateArteUmbiDias As String, ByVal CateArteUmbiCompli As String, ByVal CateVenoUmbiDias As String, ByVal CateVenoUmbiCompli As String, ByVal CateVenoPeriDias As String, ByVal CateVenoPeriCompli As String, ByVal NutriParentTotDias As String, ByVal AlimenEnteDias As String, ByVal AlimenEnteCompli As String, ByVal ExoCompli As String, ByVal SondaEsoNasoDias As String, ByVal CuraHeriMenor As String, ByVal CuraHeriMayor As String, ByVal InterQuirur As String, ByVal DrenajePleuralDias As String, ByVal EcoCerebralCompli As String, ByVal EcoCardioCompli As String, ByVal EvalFondoOjoCompli As String, ByVal CiruLasserOjosCompli As String, ByVal UsoMonitorDias As String, ByVal UsoOxiPulsoDias As String, ByVal UsoBombaInfuDias As String, ByVal UsoIncubadoraDias As String, ByVal oper As String)
        Dim cm As New SqlCommand("HospiNeo_mantenimiento", Cn)
        cm.CommandType = CommandType.StoredProcedure
        cm.Parameters.Add("@IdHospitalizacion", SqlDbType.Int).Value = Val(IdHospitalizacion)
        cm.Parameters.Add("@Historia", SqlDbType.VarChar).Value = Historia
        cm.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = Microsoft.VisualBasic.Format(Date.Now, "dd/mm/yyyy")
        cm.Parameters.Add("@HoraNacimiento", SqlDbType.VarChar).Value = HoraNacimiento
        cm.Parameters.Add("@TipoNacimiento", SqlDbType.VarChar).Value = TipoNacimiento
        cm.Parameters.Add("@PesoAlNacer", SqlDbType.VarChar).Value = PesoAlNacer
        cm.Parameters.Add("@@EdadGestacional", SqlDbType.VarChar).Value = EdadGestacional
        cm.Parameters.Add("@ApgarAlMinuto", SqlDbType.VarChar).Value = ApgarAlMinuto
        cm.Parameters.Add("@RelaPesoEdadGes", SqlDbType.VarChar).Value = RelaPesoEdadGes
        cm.Parameters.Add("@ReanimaNeonatal", SqlDbType.VarChar).Value = ReanimaNeonatal
        cm.Parameters.Add("@InfecIntrahos", SqlDbType.VarChar).Value = InfecIntrahos
        cm.Parameters.Add("@OxigenoTerapia", SqlDbType.VarChar).Value = OxigenoTerapia
        cm.Parameters.Add("@OxigenoterapiaHoras", SqlDbType.VarChar).Value = OxigenoterapiaHoras
        cm.Parameters.Add("@CpapNasalDias", SqlDbType.VarChar).Value = CpapNasalDias
        cm.Parameters.Add("@CpapNasalCompli", SqlDbType.VarChar).Value = CpapNasalCompli
        cm.Parameters.Add("@VmcDias", SqlDbType.VarChar).Value = VmcDias
        cm.Parameters.Add("@VmcCompli", SqlDbType.VarChar).Value = VmcCompli
        cm.Parameters.Add("@VafoDias", SqlDbType.VarChar).Value = VafoDias
        cm.Parameters.Add("@VafoCompli", SqlDbType.VarChar).Value = VafoCompli
        cm.Parameters.Add("@SurfacDosis", SqlDbType.VarChar).Value = SurfacDosis
        cm.Parameters.Add("@SurfacCompli", SqlDbType.VarChar).Value = SurfacCompli
        cm.Parameters.Add("@FototerapiaDias", SqlDbType.VarChar).Value = FototerapiaDias
        cm.Parameters.Add("@CateVenoCentralDias", SqlDbType.VarChar).Value = CateVenoCentralDias
        cm.Parameters.Add("@CateVenoCentralCompli", SqlDbType.VarChar).Value = CateVenoCentralCompli
        cm.Parameters.Add("@CateArteUmbiDias", SqlDbType.VarChar).Value = CateArteUmbiDias
        cm.Parameters.Add("@CateArteUmbiCompli", SqlDbType.VarChar).Value = CateArteUmbiCompli
        cm.Parameters.Add("@CateVenoUmbiDias", SqlDbType.VarChar).Value = CateVenoUmbiDias
        cm.Parameters.Add("@CateVenoUmbiCompli", SqlDbType.VarChar).Value = CateVenoUmbiCompli
        cm.Parameters.Add("@CateVenoPeriDias", SqlDbType.VarChar).Value = CateVenoPeriDias
        cm.Parameters.Add("@CateVenoPeriCompli", SqlDbType.VarChar).Value = CateVenoPeriCompli
        cm.Parameters.Add("@NutriParentTotDias", SqlDbType.VarChar).Value = NutriParentTotDias
        cm.Parameters.Add("@AlimenEnteDias", SqlDbType.VarChar).Value = AlimenEnteDias
        cm.Parameters.Add("@AlimenEnteCompli", SqlDbType.VarChar).Value = AlimenEnteCompli
        cm.Parameters.Add("@ExoCompli", SqlDbType.VarChar).Value = ExoCompli
        cm.Parameters.Add("@SondaEsoNasoDias", SqlDbType.VarChar).Value = SondaEsoNasoDias
        cm.Parameters.Add("@CuraHeriMenor", SqlDbType.VarChar).Value = CuraHeriMenor
        cm.Parameters.Add("@CuraHeriMayor", SqlDbType.VarChar).Value = CuraHeriMayor
        cm.Parameters.Add("@InterQuirur", SqlDbType.VarChar).Value = InterQuirur
        cm.Parameters.Add("@DrenajePleuralDias", SqlDbType.VarChar).Value = DrenajePleuralDias
        cm.Parameters.Add("@EcoCerebralCompli", SqlDbType.VarChar).Value = EcoCerebralCompli
        cm.Parameters.Add("@EcoCardioCompli", SqlDbType.VarChar).Value = EcoCardioCompli
        cm.Parameters.Add("@EvalFondoOjoCompli", SqlDbType.VarChar).Value = EvalFondoOjoCompli
        cm.Parameters.Add("@CiruLasserOjosCompli", SqlDbType.VarChar).Value = CiruLasserOjosCompli
        cm.Parameters.Add("@UsoMonitorDias", SqlDbType.VarChar).Value = UsoMonitorDias
        cm.Parameters.Add("@UsoOxiPulsoDias", SqlDbType.VarChar).Value = UsoOxiPulsoDias
        cm.Parameters.Add("@UsoBombaInfuDias", SqlDbType.VarChar).Value = UsoBombaInfuDias
        cm.Parameters.Add("@UsoIncubadoraDias", SqlDbType.VarChar).Value = UsoIncubadoraDias
        cm.Parameters.Add("@Oper", SqlDbType.VarChar).Value = oper
        cm.ExecuteNonQuery()
    End Sub
    Public Function buscarnumero(ByVal IdHospitalizacion As String) As Data.DataSet
        Dim databla As New SqlDataAdapter("Historia_buscar", Cn)
        Dim dstabla As New Data.DataSet
        databla.SelectCommand.CommandType = CommandType.StoredProcedure
        databla.SelectCommand.Parameters.Add("@IdHospitalizacion", SqlDbType.VarChar).Value = Val(IdHospitalizacion)
        databla.SelectCommand.ExecuteNonQuery()
        databla.Fill(dstabla)
        Return dstabla

    End Function

End Class

