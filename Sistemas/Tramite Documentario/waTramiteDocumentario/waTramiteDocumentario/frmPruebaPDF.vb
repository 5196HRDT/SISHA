Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class frmPruebaPDF

    Private Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = Application.StartupPath & "\Documentos PDF\ejemplo.pdf"
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            'Apertura del documento.
            oDoc.Open()
            cb = pdfw.DirectContent
            'Agregamos una pagina.
            oDoc.NewPage()
            'Iniciamos el flujo de bytes.
            cb.BeginText()
            'Instanciamos el objeto para la tipo de letra.
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'Seteamos el tipo de letra y el tamaño.
            cb.SetFontAndSize(fuente, 12)
            'Seteamos el color del texto a escribir.
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            'Aqui es donde se escribe el texto.
            'Aclaracion: Por alguna razon la coordenada vertical siempre es tomada desde el borde inferior (de ahi que se calcule como “PageSize.A4.Height – 50″)
            Dim Y As Integer
            Y = PageSize.A4.Height - 50
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "HOSPITAL REGIONAL DOCENTE DE TRUJILLO", 200, Y, 0)
            'Fin del flujo de bytes.
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            'Cerramos el documento.
            oDoc.Close()
        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(NombreArchivo) Then
                'Cerramos el documento si esta abierto.
                'Y asi desbloqueamos el archivo para su eliminacion.
                If oDoc.IsOpen Then oDoc.Close()
                '… lo eliminamos de disco.
                File.Delete(NombreArchivo)
            End If
            Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Private Sub frmPruebaPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GenerarPDF()
    End Sub
End Class