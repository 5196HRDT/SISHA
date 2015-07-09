Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmEnviarDocumento
    Dim objDocumento As New Documento
    Dim objAño As New NombreDelAnio
    Dim objTipoDoc As New TipoDocumento
    Dim objNumeracion As New Numeracion
    Dim objTrabajador As New Trabajador
    Dim objTipoDocAdj As New TipoDocAdj
    Dim objMotivoPase As New MotivoDelPAse
    Dim objMotivoEnvio As New MotivoEnvio
    Dim objCC As New ConCopia
    Dim objReferencia As New Referencia
    Dim objAdjunto As New Adjunto
    Dim objParametro As New Parametro
    Dim objAsignacionCargo As New clsAsignacionCargo
    Dim objHojaEnvio As New clsHojaEnvio
    Dim objArchivador As New Archivador
    Dim VarImpresion As Integer

    Dim dsDocVer As New Data.DataSet

    Dim I As Integer
    Dim NumeroDocumento As String
    Dim CodigoNumeracion As String
    Dim IdServiArea As String
    Dim IdAsignacionCargo As String
    Dim IdHojaEnvio As Integer
    Dim IdMotivoEnvio As Integer
    Dim SiglasInstitucion As String
    Dim IdDocumento As Integer
    Dim Fila As New ListViewItem

    Private Sub GenerarPDF(NombreDoc As String)
        Dim RutaPDF As String = ""
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim Ruta As String = Microsoft.VisualBasic.Left(Application.ExecutablePath, Application.ExecutablePath.Length - ((Application.ProductName & ".exe").Length + 1))
        Dim NombreArchivo As String = Ruta & "\" & NombreDoc & ".pdf"

        Dim Documento As New Document 'Declaración del documento
        Dim parrafo As New Paragraph ' Declaración de un parrafo
        Dim imagendemo As iTextSharp.text.Image 'Declaración de una imagen
        Dim LogoDerecha As iTextSharp.text.Image 'Declaración de una imagen
        Dim tablademo As New PdfPTable(4) 'Declaración de una tabla con 4 Columnas

        pdf.PdfWriter.GetInstance(Documento, New FileStream("Demo.pdf", FileMode.Create)) 'Crea el archivo "DEMO.PDF"
        'pdf.PdfWriter.GetInstance(Documento, New FileStream(NombreDoc, FileMode.Create)) 'Crea el archivo "DEMO.PDF"

        Documento.Open() 'Abre documento para su escritura

        'Encabezado
        Dim Encabezado As New Paragraph(lblAño.Text, FontFactory.GetFont("Calibri", 8, 1))
        Encabezado.Alignment = Element.ALIGN_CENTER
        Documento.Add(Encabezado)

        'Imagen del Escudo de la Region
        imagendemo = iTextSharp.text.Image.GetInstance(Ruta & "\Imagenes\EscudoGobierno.JPG") 'Dirección a la imagen que se hace referencia
        imagendemo.SetAbsolutePosition(40, 770) 'Posición en el eje cartesiano
        imagendemo.ScaleAbsoluteWidth(56) 'Ancho de la imagen
        imagendemo.ScaleAbsoluteHeight(62) 'Altura de la imagen
        Documento.Add(imagendemo) ' Agrega la imagen al documento  

        'Logo Derecha
        LogoDerecha = iTextSharp.text.Image.GetInstance(Ruta & "\Imagenes\LogoDerecha.JPG") 'Dirección a la imagen que se hace referencia
        LogoDerecha.SetAbsolutePosition(500, 780) 'Posición en el eje cartesiano
        LogoDerecha.ScaleAbsoluteWidth(56) 'Ancho de la imagen
        LogoDerecha.ScaleAbsoluteHeight(40) 'Altura de la imagen
        Documento.Add(LogoDerecha) ' Agrega la imagen al documento  
        Documento.Add(New Paragraph(" ")) 'Salto de linea

        'Numero de Documento
        parrafo.Alignment = Element.ALIGN_CENTER 'Alinea el parrafo para que sea centrado o justificado
        parrafo.Font = FontFactory.GetFont("Calibri", 10, 5) 'Asigna fuente de la letra
        parrafo.Add(lvDocumentosPendientes.SelectedItems(0).SubItems(4).Text & " " & lvDocumentosPendientes.SelectedItems(0).SubItems(6).Text) 'Texto que se insertara
        Documento.Add(parrafo) 'Agrega el parrafo al documento
        parrafo.Clear() 'Limpia el parrafo para que despues pueda ser utilizado nuevamente
        Documento.Add(New Paragraph(" ")) 'Salto de linea

        'CREANDO TABLA PARA EL ENCABEZADO
        'SI EL DOCUMENT ES UN INFORME
        If lvDocumentosPendientes.SelectedItems(0).SubItems(4).Text = "INFORME" Then
            Dim Tabla As New PdfPTable(3)
            Tabla.SetWidthPercentage(New Single() {150, 20, 350}, PageSize.A4)
            Tabla.HorizontalAlignment = Element.ALIGN_LEFT
            Dim celda1 As New PdfPCell(New Paragraph(StrDup(10, " ") & "A", FontFactory.GetFont("Calibri", 10, 1))) : celda1.Border = 0
            Dim celda2 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda2.Border = 0
            Dim celda3 As New PdfPCell(New Paragraph(lblDeNombre.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda3.Border = 0
            Dim celda4 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda4.Border = 0
            Dim celda5 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda5.Border = 0
            Dim celda6 As New PdfPCell(New Paragraph(lblDeCargo.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda6.Border = 0
            Dim celda7 As New PdfPCell(New Paragraph(StrDup(10, " ") & "De", FontFactory.GetFont("Calibri", 10, 1))) : celda7.Border = 0
            Dim celda8 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda8.Border = 0
            Dim celda9 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(7).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda9.Border = 0
            Dim celda10 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda10.Border = 0
            Dim celda11 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda11.Border = 0
            Dim celda12 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(8).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda12.Border = 0
            Dim celda13 As New PdfPCell(New Paragraph(StrDup(10, " ") & "ASUNTO", FontFactory.GetFont("Calibri", 10, 1))) : celda13.Border = 0
            Dim celda14 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda14.Border = 0
            Dim celda15 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(9).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda15.Border = 0
            Tabla.AddCell(celda1) : Tabla.AddCell(celda2) : Tabla.AddCell(celda3) : Tabla.AddCell(celda4) : Tabla.AddCell(celda5) : Tabla.AddCell(celda6) : Tabla.AddCell(celda7)
            Tabla.AddCell(celda8) : Tabla.AddCell(celda9) : Tabla.AddCell(celda10) : Tabla.AddCell(celda11) : Tabla.AddCell(celda12) : Tabla.AddCell(celda13) : Tabla.AddCell(celda14)
            Tabla.AddCell(celda15)

            If lvDocumentosPendientes.SelectedItems(0).SubItems(10).Text <> "" Then
                Dim celda1601 As New PdfPCell(New Paragraph(StrDup(10, " ") & "REFERENCIA", FontFactory.GetFont("Calibri", 10, 1))) : celda1601.Border = 0
                Tabla.AddCell(celda1601)
                Dim celda1701 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Colibri", 10, 1))) : celda1701.Border = 0
                Tabla.AddCell(celda1701)
                Dim celda1801 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(10).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda1801.Border = 0
                Tabla.AddCell(celda1801)
            End If

            Dim celda1901 As New PdfPCell(New Paragraph(StrDup(10, " ") & "FECHA", FontFactory.GetFont("Calibri", 10, 1))) : celda1901.Border = 0
            Dim celda2001 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda2001.Border = 0
            Dim celda2101 As New PdfPCell(New Paragraph(dtpFecha.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda2101.Border = 0
            Tabla.AddCell(celda1901) : Tabla.AddCell(celda2001) : Tabla.AddCell(celda2101)
            Documento.Add(Tabla)
        End If

        'SI EL DOCUMENTO ES UN MEMORANDO
        If lvDocumentosPendientes.SelectedItems(0).SubItems(4).Text = "MEMORANDO" Or lvDocumentosPendientes.SelectedItems(0).SubItems(4).Text = "MEMORANDO MULTIPLE" Then
            Dim Tabla As New PdfPTable(3)
            Tabla.SetWidthPercentage(New Single() {150, 20, 350}, PageSize.A4)
            Tabla.HorizontalAlignment = Element.ALIGN_LEFT
            Dim celda1 As New PdfPCell(New Paragraph(StrDup(10, " ") & "A", FontFactory.GetFont("Calibri", 10, 1))) : celda1.Border = 0
            Dim celda2 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda2.Border = 0
            Dim celda3 As New PdfPCell(New Paragraph(lblDeNombre.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda3.Border = 0
            Dim celda4 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda4.Border = 0
            Dim celda5 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda5.Border = 0
            Dim celda6 As New PdfPCell(New Paragraph(lblDeCargo.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda6.Border = 0
            Dim celda13 As New PdfPCell(New Paragraph(StrDup(10, " ") & "ASUNTO", FontFactory.GetFont("Calibri", 10, 1))) : celda13.Border = 0
            Dim celda14 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda14.Border = 0
            Dim celda15 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(9).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda15.Border = 0
            Tabla.AddCell(celda1) : Tabla.AddCell(celda2) : Tabla.AddCell(celda3) : Tabla.AddCell(celda4) : Tabla.AddCell(celda5) : Tabla.AddCell(celda6)
            Tabla.AddCell(celda13) : Tabla.AddCell(celda14) : Tabla.AddCell(celda15)

            If lvDocumentosPendientes.SelectedItems(0).SubItems(10).Text <> "" Then
                Dim celda1601 As New PdfPCell(New Paragraph(StrDup(10, " ") & "REFERENCIA", FontFactory.GetFont("Calibri", 10, 1))) : celda1601.Border = 0
                Tabla.AddCell(celda1601)
                Dim celda1701 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Colibri", 10, 1))) : celda1701.Border = 0
                Tabla.AddCell(celda1701)
                Dim celda1801 As New PdfPCell(New Paragraph(lvDocumentosPendientes.SelectedItems(0).SubItems(10).Text, FontFactory.GetFont("Calibri", 10, 1))) : celda1801.Border = 0
                Tabla.AddCell(celda1801)
            End If

            Dim celda1901 As New PdfPCell(New Paragraph(StrDup(10, " ") & "FECHA", FontFactory.GetFont("Calibri", 10, 1))) : celda1901.Border = 0
            Dim celda2001 As New PdfPCell(New Paragraph(":", FontFactory.GetFont("Calibri", 10, 1))) : celda2001.Border = 0
            Dim celda2101 As New PdfPCell(New Paragraph(dtpFecha.Text, FontFactory.GetFont("Calibri", 10, 1))) : celda2101.Border = 0
            Tabla.AddCell(celda1901) : Tabla.AddCell(celda2001) : Tabla.AddCell(celda2101)
            Documento.Add(Tabla)
        End If

        'SI EL DOCUMENTO ES UN INFORME



        'CREANDO TABLA PARA EL CUERPO
        Documento.Add(New Paragraph(" ")) 'Salto de línea
        Dim Tabla2 As New PdfPTable(2)
        Tabla2.SetWidthPercentage(New Single() {30, 540}, PageSize.A4)
        Tabla2.HorizontalAlignment = Element.ALIGN_LEFT
        Dim celda16 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda16.Border = 0
        Dim celda17 As New PdfPCell(New Paragraph(dsDocVer.Tables(0).Rows(0)("Cuerpo"), FontFactory.GetFont("Calibri", 10, 1))) : celda17.Border = 0
        Dim celda18 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda18.Border = 0
        Dim celda19 As New PdfPCell(New Paragraph("Sin otro particular.", FontFactory.GetFont("Calibri", 10, 1))) : celda19.Border = 0
        Dim celda20 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 10, 1))) : celda20.Border = 0
        Dim celda21 As New PdfPCell(New Paragraph("Atentamente,", FontFactory.GetFont("Calibri", 10, 1))) : celda21.Border = 0
        Tabla2.AddCell(celda16) : Tabla2.AddCell(celda17) : Tabla2.AddCell(celda18) : Tabla2.AddCell(celda19) : Tabla2.AddCell(celda20) : Tabla2.AddCell(celda21)
        Documento.Add(Tabla2)

        'CREANDO TABLA PARA FIRMA, NOMBRE Y CARGO
        Documento.Add(New Paragraph(" ")) 'Salto de línea
        Dim Tabla3 As New PdfPTable(1)
        Tabla3.SetWidthPercentage(New Single() {300}, PageSize.A4)
        Tabla3.HorizontalAlignment = Element.ALIGN_CENTER
        Dim celda22 As New PdfPCell(New Paragraph(StrDup(5, " ") & (StrDup(150, "-")), FontFactory.GetFont("Calibri", 5, 1))) : celda22.Border = 0
        'Dim celda23 As New PdfPCell(New Paragraph(StrDup(25, " ") & dsDocVer.Tables(0).Rows(0)("DENombres"), FontFactory.GetFont("Calibri", 8, 1))) : celda23.Border = 0
        'Dim celda24 As New PdfPCell(New Paragraph(StrDup(0, " ") & dsDocVer.Tables(0).Rows(0)("DEPuesto"), FontFactory.GetFont("Calibri", 6, 1))) : celda24.Border = 0
        Dim celda23 As New PdfPCell(New Paragraph(StrDup(25, " ") & lvDocumentosPendientes.SelectedItems(0).SubItems(7).Text, FontFactory.GetFont("Calibri", 8, 1))) : celda23.Border = 0
        Dim celda24 As New PdfPCell(New Paragraph(StrDup(0, " ") & lvDocumentosPendientes.SelectedItems(0).SubItems(8).Text, FontFactory.GetFont("Calibri", 6, 1))) : celda24.Border = 0
        Tabla3.AddCell(celda22)
        Tabla3.AddCell(celda23)
        Tabla3.AddCell(celda24)
        Documento.Add(Tabla3)

        'CREANDO TABLA PARA PIE DE PÁGINA
        Documento.Add(New Paragraph(" ")) 'Salto de línea
        Dim Tabla4 As New PdfPTable(2)
        Tabla4.SetWidthPercentage(New Single() {30, 500}, PageSize.A4)
        Tabla4.HorizontalAlignment = Element.ALIGN_LEFT
        Dim celda25 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda25.Border = 0
        Dim celda26 As New PdfPCell(New Paragraph("rgerg", FontFactory.GetFont("Calibri", 6, 1))) : celda26.Border = 0
        Dim celda27 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda27.Border = 0
        Dim celda28 As New PdfPCell(New Paragraph("Cc:", FontFactory.GetFont("Calibri", 6, 1))) : celda28.Border = 0
        Dim celda29 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda29.Border = 0
        Dim celda30 As New PdfPCell(New Paragraph("........", FontFactory.GetFont("Calibri", 6, 1))) : celda30.Border = 0
        Dim celda31 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda31.Border = 0
        Dim celda32 As New PdfPCell(New Paragraph("Adjunto:", FontFactory.GetFont("Calibri", 6, 1))) : celda32.Border = 0
        Dim celda33 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda33.Border = 0
        Dim celda34 As New PdfPCell(New Paragraph("........", FontFactory.GetFont("Calibri", 6, 1))) : celda34.Border = 0
        Dim celda35 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda35.Border = 0
        Dim celda36 As New PdfPCell(New Paragraph("SISGEDO: ......................", FontFactory.GetFont("Calibri", 6, 1))) : celda36.Border = 0
        Dim celda37 As New PdfPCell(New Paragraph(" ", FontFactory.GetFont("Calibri", 6, 1))) : celda37.Border = 0
        Dim celda38 As New PdfPCell(New Paragraph("N° de Folios: ..................", FontFactory.GetFont("Calibri", 6, 1))) : celda38.Border = 0
        Tabla4.AddCell(celda25) : Tabla4.AddCell(celda26) : Tabla4.AddCell(celda27) : Tabla4.AddCell(celda28) : Tabla4.AddCell(celda29) : Tabla4.AddCell(celda30)
        Tabla4.AddCell(celda31) : Tabla4.AddCell(celda32) : Tabla4.AddCell(celda33) : Tabla4.AddCell(celda34) : Tabla4.AddCell(celda35) : Tabla4.AddCell(celda36)
        Tabla4.AddCell(celda37) : Tabla4.AddCell(celda38)
        Documento.Add(Tabla4)
        Documento.Add(New Paragraph(" ")) 'Salto de linea

        Documento.Close() 'Cierra el documento
        System.Diagnostics.Process.Start("Demo.pdf") 'Abre el archivo DEMO.PDF
        'System.Diagnostics.Process.Start(NombreDoc) 'Abre el archivo DEMO.PDF
    End Sub

    'Mostrar Documentos que aun no han sido leídos
    Private Sub PendienteLectura()
        lvDocumentosPendientes.Items.Clear()
        Dim dsDocPL As New Data.DataSet
        dsDocPL = objDocumento.PendienteLectura(Convert.ToString(cboCargo.SelectedValue))
        For I = 0 To dsDocPL.Tables(0).Rows.Count - 1
            Fila = lvDocumentosPendientes.Items.Add(dsDocPL.Tables(0).Rows(I)("IdHojaEnvio"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("IdDocumento"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("IdServAreaOrigen"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("TipoEnvio").ToString)
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("TipoDocumento"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("FechaDoc"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("NumeroDoc"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("Origen"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("Cargo"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("Asunto"))
            Fila.SubItems.Add(dsDocPL.Tables(0).Rows(I)("Referencia"))
        Next
        lblTituloLista.Text = "UD tiene " & lvDocumentosPendientes.Items.Count & " documentos pendientes de lectura"
    End Sub

    'Mostrar Documentos Enviados
    Private Sub DocumentosEnviados()
        If IsNumeric(cboCargo.SelectedValue) Then
            lvDocumentosEnviados.Items.Clear()
            Dim dsDocEnviados As New Data.DataSet
            'dsDocEnviados = objDocumento.BuscarEnviado(IdAsignacionCargo)
            dsDocEnviados = objDocumento.BuscarEnviado(cboCargo.SelectedValue)
            If dsDocEnviados.Tables(0).Rows.Count > 0 Then
                For Me.I = 0 To dsDocEnviados.Tables(0).Rows.Count - 1
                    Fila = lvDocumentosEnviados.Items.Add(dsDocEnviados.Tables(0).Rows(I)("IdDocumento"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("IdServAreaDestino"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("TipoEnvio").ToString)
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("TipoDocumento"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("FechaDoc"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("NumeroDoc"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("Destino"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("Cargo"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("Asunto"))
                    Fila.SubItems.Add(dsDocEnviados.Tables(0).Rows(I)("Referencia"))
                Next
            End If
        End If
    End Sub

    'Mostrar Documentos Recibidos
    Private Sub DocumentosRecibidos()
        If IsNumeric(cboCargo.SelectedValue) Then
            lvDocumentosRecibidos.Items.Clear()
            Dim dsDocRecibidos As New Data.DataSet
            dsDocRecibidos = objDocumento.BuscarRecibidos(cboCargo.SelectedValue)
            If dsDocRecibidos.Tables(0).Rows.Count > 0 Then
                For Me.I = 0 To dsDocRecibidos.Tables(0).Rows.Count - 1
                    Fila = lvDocumentosRecibidos.Items.Add(dsDocRecibidos.Tables(0).Rows(I)("IdDocumento"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("IdServAreaOrigen"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("TipoEnvio").ToString)
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("TipoDocumento"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("FechaDoc"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("NumeroDoc"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("Origen"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("Cargo"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("Asunto"))
                    Fila.SubItems.Add(dsDocRecibidos.Tables(0).Rows(I)("Referencia"))
                Next
            End If
        End If
    End Sub

    Public Sub MostrarArchivadores()
        'Archivadores
        'cboCargo.SelectedIndex = -1
        If IsNumeric(cboCargo.SelectedValue) Then
            txtArchivadorDescripcion.Clear()
            gbArchivarMotivo.Visible = False
            Dim dsArchivador As New Data.DataSet
            dsArchivador = objArchivador.Combo(cboCargo.SelectedValue)
            cboArchivadorNombre.DataSource = dsArchivador.Tables(0)
            cboArchivadorNombre.DisplayMember = "Archivador"
            cboArchivadorNombre.ValueMember = "IdArchivador"
        End If
    End Sub

    Private Function Leer(ByVal RutaArchivo As String) As Byte()
        If Not System.IO.File.Exists(RutaArchivo) Then Return Nothing
        Try
            Dim fs As New System.IO.FileStream(RutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length)) {}
            fs.Read(data, 0, Convert.ToInt32(fs.Length))
            fs.Close()
            Return data
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub Escribir(ByVal aByte() As Byte, ByVal fileName As String) ', ByVal Borrar As String)
        'If (aByte Is Nothing) OrElse (fileName = "") Then Return
        Try
            If System.IO.File.Exists(fileName) Then
                System.IO.File.Delete(fileName)
            End If
            Dim data As Int64 = aByte.Length
            Dim tempFileName As String = System.IO.Path.GetTempFileName
            Dim fs As New System.IO.FileStream(tempFileName, System.IO.FileMode.OpenOrCreate)
            Dim bw As New System.IO.BinaryWriter(fs)
            bw.Write(aByte, 0, Convert.ToInt32(data))
            bw.Flush()
            bw.Close()
            fs.Close()
            bw = Nothing
            fs = Nothing
            System.IO.File.Move(tempFileName, fileName)
            'Dim oWord As New Word.ApplicationClass
            'oWord.Visible = True
            'oWord.WindowState = Word.WdWindowState.wdWindowStateMaximize
            'oWord.Documents.Add(fileName).SaveAs(fileName)
            System.Diagnostics.Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NombreAño()
        Dim dsAño As New Data.DataSet
        dsAño = objAño.Nombre(dtpFecha.Value.Year)
        If dsAño.Tables(0).Rows.Count > 0 Then
            lblAño.Text = dsAño.Tables(0).Rows(0)("Detalle")
        Else
            lblAño.Text = ""
            MessageBox.Show("Nombre de Año no ha sido definido", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmEnviarDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ControlesAD(Me, False)
        btnCancelar_Click(sender, e)
        lvBuscarTrabajador.Visible = False
        gbMotivoPase.Visible = False

        'Tipo Documento
        Dim dsTipoDoc As New Data.DataSet
        dsTipoDoc = objTipoDoc.Buscar("")
        cboTipoDoc.DataSource = dsTipoDoc.Tables(0)
        cboTipoDoc.DisplayMember = "Descripcion"
        cboTipoDoc.ValueMember = "IdTipoDocumento"

        'Parametro
        Dim dsParametro As New DataSet
        dsParametro = objParametro.Buscar("SIGLAS INSTITUCIONALES")
        If dsParametro.Tables(0).Rows.Count > 0 Then
            SiglasInstitucion = dsParametro.Tables(0).Rows(0)("Valor")
        End If
    End Sub

    Private Sub cboTipoDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoDoc.KeyDown
        If IsNumeric(cboTipoDoc.SelectedValue) And e.KeyCode = Keys.Enter Then txtDestino.Select()
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If IsNumeric(cboTipoDoc.SelectedValue) Then
            Dim dsCorrelativo As New Data.DataSet
            dsCorrelativo = objNumeracion.Correlativo(cboCargo.SelectedValue, cboTipoDoc.SelectedValue.ToString)
            If dsCorrelativo.Tables(0).Rows.Count > 0 Then
                CodigoNumeracion = dsCorrelativo.Tables(0).Rows(0)("IdNumeracion")
                NumeroDocumento = Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5)
                If dsCorrelativo.Tables(0).Rows(0)("SiglaServicio") = "" Then
                    lblNumeroDoc.Text = "N° " & Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5) & "-" & dtpFecha.Value.Year & "-" & SiglasInstitucion & dsCorrelativo.Tables(0).Rows(0)("SiglaDpto")
                Else
                    lblNumeroDoc.Text = "N° " & Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5) & "-" & dtpFecha.Value.Year & "-" & SiglasInstitucion & dsCorrelativo.Tables(0).Rows(0)("SiglaDpto") & "-" & dsCorrelativo.Tables(0).Rows(0)("SiglaServicio")
                End If
            Else
                MessageBox.Show("No existe registro de correlativo", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CodigoNumeracion = ""
                NumeroDocumento = ""
                lblNumeroDoc.Text = ""
            End If
        End If
    End Sub

    Private Sub cboTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If txtDestino.Text <> "" And e.KeyCode = Keys.Enter Then txtAsunto.Select()
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then cboTipoDoc.Select()
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        NombreAño()
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'DocumentoWord()
        ppDialogo.ShowDialog()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If lblNumeroDoc.Text = "" Then
            MessageBox.Show("Debe Seleccionar un Documento con Numeración válido", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TabControl1.SelectedIndex = 0
            cboTipoDoc.Select()
        Else
            If lvTrabajadorParaEnvio.Items.Count = 0 Then
                MessageBox.Show("Debe ingresar al menos 1 destino", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TabControl1.SelectedIndex = 0
                txtDestino.Select()
            Else
                If MessageBox.Show("Esta seguro de grabar el documento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim CodDocumento As String

                    'Documento
                    CodDocumento = objDocumento.Grabar(IdDocumento, cboTipoDoc.SelectedValue, dtpFecha.Value.Year.ToString, NumeroDocumento,
                                                       Microsoft.VisualBasic.Format(dtpFecha.Value, "dd/MM/yyyy"), lblNumeroDoc.Text, txtAsunto.Text,
                                                       txtReferencia.Text, "INTERNO", txtCuerpo.Text, (txtNumeroRegistro.Text), Trim(txtNumeroExpediente.Text), Trim(txtCantidadFolios.Text))

                    'Hoja de Envío
                    For Me.I = 0 To lvTrabajadorParaEnvio.Items.Count - 1
                        objHojaEnvio.Grabar(IdHojaEnvio, CodDocumento, cboCargo.SelectedValue, lvTrabajadorParaEnvio.Items(I).SubItems(0).Text, lvTrabajadorParaEnvio.Items(I).SubItems(2).Text,
                                            Microsoft.VisualBasic.Right("00" & Date.Now.Day, 2) & "-" & Microsoft.VisualBasic.Right("00" & Date.Now.Month, 2) & "-" & _
                                            Microsoft.VisualBasic.Right("0000" & Date.Now.Year, 4), Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2))

                        'Motivo Envio
                        If IdHojaEnvio <> 0 Then
                            objMotivoEnvio.Grabar(IdMotivoEnvio, IdHojaEnvio, lvTrabajadorParaEnvio.Items(I).SubItems(6).Text)
                        End If
                    Next

                    'Adjunto
                    For I = 0 To lvDocAdjuntos.Items.Count - 1
                        objAdjunto.Grabar(CodDocumento, lvDocAdjuntos.Items(I).SubItems(0).Text, lvDocAdjuntos.Items(I).SubItems(2).Text, lvDocAdjuntos.Items(I).SubItems(4).Text,
                                          lvDocAdjuntos.Items(I).SubItems(3).Text)
                    Next

                    ''Referencia
                    'If txtReferencia.Text <> "" And IsNumeric(txtReferencia.Tag) Then
                    '    objReferencia.Eliminar(CodDocumento)
                    '    objReferencia.Grabar(CodDocumento, txtReferencia.Tag)
                    'End If

                    objNumeracion.Actualizar(CodigoNumeracion)
                End If
            End If
        End If
        btnCancelar_Click(sender, e)
    End Sub

    Private Function VerificarPase() As Boolean
        'VerificarPase = False
        'For I = 0 To lvMotivo.Items.Count - 1
        '    If Val(lvMotivo.Items(I).SubItems(1).Text) = cboMotivoPase.SelectedValue Then
        '        VerificarPase = True
        '        MessageBox.Show("Motivo de pase ya fue asignado", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit For
        '    End If
        'Next
    End Function

    Private Sub cboMotivoPase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If IsNumeric(cboMotivoPase.SelectedValue) And e.KeyCode = Keys.Enter Then
        '    btnGrabar.Enabled = True
        '    If Not VerificarPase() Then
        '        Dim Fila As ListViewItem
        '        Fila = lvMotivo.Items.Add(cboMotivoPase.Text)
        '        Fila.SubItems.Add(cboMotivoPase.SelectedValue.ToString)
        '    End If
        'End If
    End Sub

    Private Sub lvMotivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If lvMotivo.Items.Count > 0 Then
        '    For I = 0 To lvMotivo.Items.Count - 1
        '        If lvMotivo.Items(I).Selected Then
        '            lvMotivo.Items.RemoveAt(I)
        '            Exit For
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar(Me)

        'Cargos del Trabajador
        Dim dsAsignacionCargo As New Data.DataSet
        dsAsignacionCargo = objAsignacionCargo.CargoPorTrabajador(CodigoTrabajador)
        IdAsignacionCargo = dsAsignacionCargo.Tables(0).Rows(0)("IdAsignacionCargo")
        cboCargo.DataSource = dsAsignacionCargo.Tables(0)
        cboCargo.DisplayMember = "Cargo"
        cboCargo.ValueMember = "IdAsignacionCargo"

        'Motivo de Pase
        Dim dsMotivo As New Data.DataSet
        dsMotivo = objMotivoPase.Combo
        cboMotivoPase.DataSource = dsMotivo.Tables(0)
        cboMotivoPase.DisplayMember = "Descripcion"
        cboMotivoPase.ValueMember = "IdMotivoPase"

        'Tipo Documento Adjunto
        Dim dsTipoDocAdj As New Data.DataSet
        dsTipoDocAdj = objTipoDocAdj.Buscar("")
        cboTipoDocAdj.DataSource = dsTipoDocAdj.Tables(0)
        cboTipoDocAdj.DisplayMember = "Descripcion"
        cboTipoDocAdj.ValueMember = "IdTipoDocAdj"

        dtpFecha.Value = Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy")
        lblDeNombre.Text = TituloOrigen & " " & TrabajadorOrigen  'TituloJefatura & " " & NombreTrabajador
        lblDeCargo.Text = CargoOrigen
        gbReferencia.Visible = False
        gbArchivarMotivo.Visible = False
        btnGenerar.Enabled = True
        PendienteLectura()
        DocumentosEnviados()
        DocumentosRecibidos()
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentosPendientes.DoubleClick
        If lvDocumentosPendientes.Items.Count > 0 Then
            If lvDocumentosPendientes.SelectedItems.Count > 0 Then
                If MessageBox.Show("Esta seguro de haber leido el documento", "Mensaje de Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    objDocumento.Leido(lvDocumentosPendientes.SelectedItems(0).SubItems(0).Text, Microsoft.VisualBasic.Format(Date.Now, "dd/MM/yyyy"),
                                       Microsoft.VisualBasic.Right("00" & Date.Now.Hour, 2) & ":" & Microsoft.VisualBasic.Right("00" & Date.Now.Minute, 2), CodigoTrabajador)
                    TabControl1.SelectedIndex = 3
                End If
                btnCancelar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub lvDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDocumentosPendientes.KeyDown
        If e.KeyCode = Keys.V And lvDocumentosPendientes.SelectedItems.Count > 0 Then
            VarImpresion = 2
            'Buscar Documento
            dsDocVer = objDocumento.BuscarId(lvDocumentosPendientes.SelectedItems(0).SubItems(1).Text)
            If dsDocVer.Tables(0).Rows.Count > 0 Then
                GenerarPDF(dsDocVer.Tables(0).Rows(0)("TipoDocumento") & dsDocVer.Tables(0).Rows(0)("NumeroDoc") & "-" & dsDocVer.Tables(0).Rows(0)("Año"))
            End If
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        lvTablaR.Items.Clear()
        If txtFiltro.Text <> "" Then
            Dim dsRef As New Data.DataSet
            dsRef = objDocumento.BuscarReferencia(txtFiltro.Text)
            If dsRef.Tables(0).Rows.Count > 0 Then
                For I = 0 To dsRef.Tables(0).Rows.Count - 1
                    Fila = lvTablaR.Items.Add(dsRef.Tables(0).Rows(I)("IdDocumento"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("FechaDoc"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("TipoDoc"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("NumeroDoc"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("Origen"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("Cargo"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("Asunto"))
                    Fila.SubItems.Add(dsRef.Tables(0).Rows(I)("Cuerpo").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub lvTablaR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTablaR.DoubleClick
        If lvTablaR.SelectedItems.Count > 0 Then
            If txtReferencia.Text = "" Then
                txtReferencia.Text = lvTablaR.SelectedItems(0).SubItems(2).Text & " " & lvTablaR.SelectedItems(0).SubItems(3).Text
                txtReferencia.Tag = lvTablaR.SelectedItems(0).SubItems(0).Text
            Else
                txtReferencia.Text = txtReferencia.Text & ", " & lvTablaR.SelectedItems(0).SubItems(2).Text & " " & lvTablaR.SelectedItems(0).SubItems(3).Text
            End If
        End If
        btnRetornar_Click(sender, e)
    End Sub

    Private Sub lvTablaR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTablaR.SelectedIndexChanged
        txtCuerpoR.Text = ""
        If lvTablaR.SelectedItems.Count > 0 Then
            txtCuerpoR.Text = lvTablaR.SelectedItems(0).SubItems(7).Text
        End If
    End Sub

    Private Sub cboCargo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCargo.SelectedIndexChanged
        PendienteLectura()
        lvDocAdjuntosEnviados.Items.Clear()
        If IsNumeric(cboCargo.SelectedValue) Then
            Dim dsCorrelativo As New Data.DataSet
            dsCorrelativo = objNumeracion.Correlativo(cboCargo.SelectedValue, cboTipoDoc.SelectedValue)
            If dsCorrelativo.Tables(0).Rows.Count > 0 Then
                CodigoNumeracion = dsCorrelativo.Tables(0).Rows(0)("IdNumeracion")
                NumeroDocumento = Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5)
                If dsCorrelativo.Tables(0).Rows(0)("SiglaServicio") = "" Then
                    lblNumeroDoc.Text = "N° " & Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5) & "-" & dtpFecha.Value.Year & "-" & SiglasInstitucion & dsCorrelativo.Tables(0).Rows(0)("SiglaDpto")
                Else
                    lblNumeroDoc.Text = "N° " & Microsoft.VisualBasic.Right("00000" & Val(dsCorrelativo.Tables(0).Rows(0)("Numero")), 5) & "-" & dtpFecha.Value.Year & "-" & SiglasInstitucion & dsCorrelativo.Tables(0).Rows(0)("SiglaDpto") & "-" & dsCorrelativo.Tables(0).Rows(0)("SiglaServicio")
                End If
            Else
                MessageBox.Show("No existe registro de correlativo", "Mensaje de Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CodigoNumeracion = ""
                NumeroDocumento = ""
                lblNumeroDoc.Text = ""
            End If
        End If
        lblDeCargo.Text = cboCargo.Text
        DocumentosEnviados()
        DocumentosRecibidos()
        MostrarArchivadores()
    End Sub

    Private Sub txtATrabajador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestino.TextChanged
        If txtDestino.Text <> "" Then
            lvBuscarTrabajador.Visible = True
            Dim dsTrabajador As DataSet
            lvBuscarTrabajador.Items.Clear()
            dsTrabajador = objTrabajador.BuscarParaEnvio(txtDestino.Text)
            Dim Fila As New ListViewItem
            For Me.I = 0 To dsTrabajador.Tables(0).Rows.Count - 1
                Fila = lvBuscarTrabajador.Items.Add(dsTrabajador.Tables(0).Rows(I)("IdAsignacionCargo"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("IdTrabajador"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Trabajador"))
                Fila.SubItems.Add(dsTrabajador.Tables(0).Rows(I)("Cargo"))
            Next
        Else
            If txtDestino.Text = "" Then
                lvBuscarTrabajador.Visible = False
                txtDestino.Select()
            End If
        End If
    End Sub

    Private Sub lvBuscarTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBuscarTrabajador.KeyDown
        If e.KeyCode = Keys.Enter And lvBuscarTrabajador.SelectedItems.Count > 0 Then
            Dim dsDocumento As New Data.DataSet
            dsDocumento = objDocumento.DocPendientePorTrabajador(lvBuscarTrabajador.SelectedItems(0).SubItems(1).Text)
            If dsDocumento.Tables(0).Rows.Count = 3 Then
                MessageBox.Show("El destinatario tiene 3 documentos pendientes.", "Mensaje de consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                gbMotivoPase.Visible = True
            End If
        End If
    End Sub

    Private Sub txtATrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDestino.KeyDown
        If e.KeyCode = Keys.Enter Then lvBuscarTrabajador.Select()
    End Sub

    Private Sub lvDocAdjuntosEnviados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDocAdjuntosEnviados.DoubleClick
        Dim dsAdjuntoEscribir As New Data.DataSet
        dsAdjuntoEscribir = objAdjunto.Escribir(lvDocAdjuntosEnviados.SelectedItems(0).SubItems(0).Text)
        If dsAdjuntoEscribir.Tables(0).Rows.Count > 0 Then
            If lvDocAdjuntosEnviados.SelectedItems.Count > 0 Then
                Dim NombreArchivo As String = lvDocAdjuntosEnviados.SelectedItems(0).SubItems(3).Text
                If NombreArchivo = "" Then
                    NombreArchivo = "ArchivoTemporal"
                End If
                If lvDocAdjuntosEnviados.SelectedItems(0).SubItems(2).Text = "PDF" Then
                    Escribir(dsAdjuntoEscribir.Tables(0).Rows(0)("Documento"), NombreArchivo & ".pdf")
                Else
                    If lvDocAdjuntosEnviados.SelectedItems(0).SubItems(2).Text = "DOCUMENTO" Then
                        Escribir(dsAdjuntoEscribir.Tables(0).Rows(0)("Documento"), NombreArchivo & ".doc")
                    Else
                        If lvDocAdjuntosEnviados.SelectedItems(0).SubItems(2).Text = "IMAGEN" Then
                            Escribir(dsAdjuntoEscribir.Tables(0).Rows(0)("Documento"), NombreArchivo & ".jpg")
                        Else
                            If lvDocAdjuntosEnviados.SelectedItems(0).SubItems(2).Text = "HOJA CALCULO" Then
                                Escribir(dsAdjuntoEscribir.Tables(0).Rows(0)("Documento"), NombreArchivo & ".xlsx")
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lvDocumentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDocumentosPendientes.SelectedIndexChanged
        lvDocAdjuntosEnviados.Items.Clear()
        If lvDocumentosPendientes.SelectedItems.Count > 0 Then
            Dim dsAdjuntoEscribir As New Data.DataSet
            dsAdjuntoEscribir = objAdjunto.Mostrar(lvDocumentosPendientes.SelectedItems(0).SubItems(1).Text)
            If dsAdjuntoEscribir.Tables(0).Rows.Count > 0 Then
                For Me.I = 0 To dsAdjuntoEscribir.Tables(0).Rows.Count - 1
                    Fila = lvDocAdjuntosEnviados.Items.Add(dsAdjuntoEscribir.Tables(0).Rows(I)("IdDocumento"))
                    Fila.SubItems.Add(dsAdjuntoEscribir.Tables(0).Rows(I)("FechaDoc"))
                    Fila.SubItems.Add(dsAdjuntoEscribir.Tables(0).Rows(I)("TipoArchivo"))
                    Fila.SubItems.Add(dsAdjuntoEscribir.Tables(0).Rows(I)("Nombre").ToString)
                    Fila.SubItems.Add(dsAdjuntoEscribir.Tables(0).Rows(I)("Descripcion"))
                Next
            Else
                lvDocAdjuntosEnviados.Items.Clear()
            End If
        End If
    End Sub

    Private Sub btnAgregarMotivoPase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMotivoPase.Click
        If IsNumeric(cboMotivoPase.SelectedValue) Then
            Fila = lvTrabajadorParaEnvio.Items.Add(lvBuscarTrabajador.SelectedItems(0).SubItems(0).Text)
            Fila.SubItems.Add(lvBuscarTrabajador.SelectedItems(0).SubItems(1).Text)
            If chkbConCopia.Checked = True Then
                Fila.SubItems.Add("COPIA")
            Else
                If chkbConCopia.Checked = False Then
                    Fila.SubItems.Add("ORIGINAL")
                End If
            End If
            Fila.SubItems.Add(lvBuscarTrabajador.SelectedItems(0).SubItems(2).Text)
            Fila.SubItems.Add(lvBuscarTrabajador.SelectedItems(0).SubItems(3).Text)
            Fila.SubItems.Add(cboMotivoPase.Text)
            Fila.SubItems.Add(cboMotivoPase.SelectedValue)
            lvBuscarTrabajador.Visible = False
            lvTrabajadorParaEnvio.Visible = True
            gbMotivoPase.Visible = False
            txtDestino.Text = ""
            txtDestino.Select()
        End If
    End Sub

    Private Sub btnRetornarMotivoPase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornarMotivoPase.Click
        gbMotivoPase.Visible = False
        lvBuscarTrabajador.Visible = False
    End Sub

    Private Sub btnRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRuta.Click
        If (Abrir.ShowDialog() = System.Windows.Forms.DialogResult.OK) And (Abrir.FileName.Length > 0) Then
            txtRuta.Text = Abrir.FileName
            txtRuta.Select()
        Else
            txtRuta.Text = ""
            txtRuta.Select()
        End If
    End Sub

    Private Sub txtNombreAdjunto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombreAdjunto.KeyDown
        If txtNombreAdjunto.Text <> "" And e.KeyCode = Keys.Enter Then
            Dim Fila As ListViewItem
            Dim Descripcion As String
            Descripcion = UCase(Microsoft.VisualBasic.InputBox("Ingresar Descripcion del Documento Adjunto", "Datos de Documento Adjunto"))
            If Descripcion = "" Then
                MessageBox.Show("Debe ingresar una descripción", "Mensaje de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombreAdjunto.Select()
            Else
                Fila = lvDocAdjuntos.Items.Add(cboTipoDocAdj.SelectedValue)
                Fila.SubItems.Add(cboTipoDocAdj.Text)
                Fila.SubItems.Add(txtNombreAdjunto.Text)
                Fila.SubItems.Add(txtRuta.Text)
                Fila.SubItems.Add(Descripcion)
                txtRuta.Text = ""
                cboTipoDocAdj.Select()
            End If
        End If
    End Sub

    Private Sub txtRuta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRuta.KeyDown
        If e.KeyCode = Keys.Enter And txtRuta.Text <> "" Then txtNombreAdjunto.Select()
    End Sub

    Private Sub lvDocAdjuntos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDocAdjuntos.KeyDown
        If e.KeyCode = Keys.Delete And lvDocAdjuntos.SelectedItems.Count > 0 Then
            lvDocAdjuntos.Items.RemoveAt(lvDocAdjuntos.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub lvTrabajadorParaEnvio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvTrabajadorParaEnvio.KeyDown
        If e.KeyCode = Keys.Delete And lvTrabajadorParaEnvio.SelectedItems.Count > 0 Then
            lvTrabajadorParaEnvio.Items.RemoveAt(lvTrabajadorParaEnvio.SelectedItems(0).Index)
        End If
    End Sub

    Private Sub txtAsunto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAsunto.KeyDown
        If txtAsunto.Text <> "" And e.KeyCode = Keys.Enter Then txtReferencia.Select()
    End Sub

    Private Sub btnRetornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetornar.Click
        txtFiltro.Text = ""
        txtCuerpoR.Text = ""
        gbReferencia.Visible = False
    End Sub

    Private Sub btnUbicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbicar.Click
        gbReferencia.Visible = True
        txtFiltro.Select()
    End Sub

    Private Sub lvDocumentosEnviados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDocumentosEnviados.DoubleClick
        ''Archivadores
        'Dim dsArchivador As New Data.DataSet
        'dsArchivador = objArchivador.Combo(cboCargo.SelectedValue)
        'cboArchivadorNombre.DataSource = dsArchivador.Tables(0)
        'cboArchivadorNombre.DisplayMember = "Archivador"
        'cboArchivadorNombre.ValueMember = "IdArchivador"
        MostrarArchivadores()

        gbArchivarMotivo.Visible = True
        cboArchivadorNombre.Select()
    End Sub

    Private Sub btnArchivarCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivarCancelar.Click
        txtArchivadorDescripcion.Text = ""
        gbArchivarMotivo.Visible = False
    End Sub

    Private Sub txtCantidadFolios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadFolios.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroRegistro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroRegistro.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroExpediente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroExpediente.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidadFolios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadFolios.TextChanged
        'ELIMINAR CUALQUIER ESPACIO EN BLANCO
        Dim cadena As String = Trim(txtCantidadFolios.Text)
        cadena = Replace(cadena, " ", "")
        txtCantidadFolios.Text = cadena
    End Sub

    Private Sub txtNumeroRegistro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroRegistro.TextChanged
        'ELIMINAR CUALQUIER ESPACIO EN BLANCO
        Dim cadena As String = Trim(txtNumeroRegistro.Text)
        cadena = Replace(cadena, " ", "")
        txtNumeroRegistro.Text = cadena
    End Sub

    Private Sub txtNumeroExpediente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroExpediente.TextChanged
        'ELIMINAR CUALQUIER ESPACIO EN BLANCO
        Dim cadena As String = Trim(txtNumeroExpediente.Text)
        cadena = Replace(cadena, " ", "")
        txtNumeroExpediente.Text = cadena
    End Sub
End Class