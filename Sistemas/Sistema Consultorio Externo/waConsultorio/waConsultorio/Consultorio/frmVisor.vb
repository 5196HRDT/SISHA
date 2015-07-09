Public Class frmVisor
    Public Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
    Public Modificacion As String

    Sub modificar(ByRef tipo_modificacion)
        Dim i, j As Long
        Dim bmp As New Bitmap(Niveles.GetUpperBound(0) + 1, Niveles.GetUpperBound(1) + 1)
        Dim img As Image
        img = CType(bmp, Image)


        Dim Rojo, Verde, Azul As Byte 'Declaramos tres variables que almacenarán los colores
        For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
            For j = 0 To Niveles.GetUpperBound(1) 'Recorremos la matriz
                Select Case tipo_modificacion  'Seleccionamos entre las diferentes modificaciones
                    Case "invertir"
                        Rojo = 255 - (Niveles(i, j).R) 'Realizamos la inversión de los colores
                        Verde = 255 - (Niveles(i, j).G) 'Realizamos la inversión de los colores
                        Azul = 255 - (Niveles(i, j).B) 'Realizamos la inversión de los colores


                    Case "+brillo"
                        Dim AuxiliarR, AuxiliarG, AuxiliarB As Integer
                        'Realizamos primeramente el cálculo con variables auxiliares, para 
                        'que no se desborde las variables Rojo, Verde, Azul
                        AuxiliarR = (Niveles(i, j).R) + 20 'Aumentamos en 20 unidades el color rojo
                        AuxiliarG = (Niveles(i, j).G) + 20 'Aumentamos en 20 unidades el color verde
                        AuxiliarB = (Niveles(i, j).B) + 20 'Aumentamos en 20 unidades el color azul
                        'Comprobamos que no hay valores no válidos, es decir, mayores de 255
                        'Si hay valores mayores, los igualamos a 255
                        If AuxiliarR > 255 Then AuxiliarR = 255
                        If AuxiliarG > 255 Then AuxiliarG = 255
                        If AuxiliarB > 255 Then AuxiliarB = 255
                        Rojo = AuxiliarR
                        Verde = AuxiliarG
                        Azul = AuxiliarB

                    Case "-brillo"
                        Dim AuxiliarR, AuxiliarG, AuxiliarB As Integer
                        'Realizamos primeramente el cálculo con variables auxiliares, para 
                        'que no se desborde las variables Rojo, Verde, Azul
                        AuxiliarR = (Niveles(i, j).R) - 20 'Disminuimos en 20 unidades el color rojo
                        AuxiliarG = (Niveles(i, j).G) - 20 'Disminuimos en 20 unidades el color verde
                        AuxiliarB = (Niveles(i, j).B) - 20 'Disminuimos en 20 unidades el color azul
                        'Comprobamos que no hay valores no válidos, es decir, menores de 0
                        'Si hay valores menores, los igualamos a 0
                        If AuxiliarR < 0 Then AuxiliarR = 0
                        If AuxiliarG < 0 Then AuxiliarG = 0
                        If AuxiliarB < 0 Then AuxiliarB = 0
                        Rojo = AuxiliarR
                        Verde = AuxiliarG
                        Azul = AuxiliarB


                    Case "b/n"
                        'Calculamos la media de los tres colores
                        Dim media As Double 'Variable para calcular la media
                        Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
                        'para que no se desborde
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B


                        'Calculamos la media 
                        media = (rojoaux + verdeaux + azulaux) / 3
                        'En función de si el valor es mayor o menor de 128 (mitad aproximada
                        'de 255), lo convertimos en blanco o negro
                        If media >= 128 Then
                            Rojo = 255
                            Verde = 255
                            Azul = 255
                        Else
                            Rojo = 0
                            Verde = 0
                            Azul = 0
                        End If


                    Case "grises"
                        'Se calcula la media de los tres colores (de cada píxel), y se le asigna ese valores 
                        'a cada color
                        'Calculamos la media de los tres colores
                        Dim media As Double 'Variable para calcular la media
                        Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
                        'para que no se desborde
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B


                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = media
                        Azul = media


                    Case "rojo"
                        'Calculamos la media, y asignamos el color al rojo y al resto 0
                        'Calculamos la media de los tres colores
                        Dim media As Double 'Variable para calcular la media
                        Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
                        'para que no se desborde
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = 0
                        Azul = 0


                    Case "verde"
                        'Calculamos la media, y asignamos el color al verde y al resto 0
                        'Calculamos la media de los tres colores
                        Dim media As Double 'Variable para calcular la media
                        Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
                        'para que no se desborde
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = 0
                        Verde = media
                        Azul = 0


                    Case "azul"
                        'Calculamos la media, y asignamos el color al verde y al resto 0
                        'Calculamos la media de los tres colores
                        Dim media As Double 'Variable para calcular la media
                        Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
                        'para que no se desborde
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = 0
                        Verde = 0
                        Azul = media
                End Select
                bmp.SetPixel(i, j, Color.FromArgb(Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
            Next
        Next


        pbImagen.Image = img
        Panel1.AutoScrollMinSize = pbImagen.Image.Size
        pbImagen.Refresh()
    End Sub


    Private Sub AplicarZoom()
        Dim Ancho As Single, Alto As Single
        With pbImagen
            ' Ancho y alto de la imagen      
            Ancho = .Image.Width * txtZoom.Value
            Alto = .Image.Height * txtZoom.Value
            .Width = Ancho
            .Height = Alto
        End With

    End Sub

    Private Sub frmVisor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Ancho As Single, Alto As Single
        With pbImagen
            ' Ancho y alto de la imagen      
            Ancho = .Image.Width * txtZoom.Value
            Alto = .Image.Height * txtZoom.Value
            .Width = Ancho
            .Height = Alto
        End With

        'Dim i, j As Long
        'ReDim Niveles(pbImagen.Image.Width - 1, pbImagen.Image.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
        'Dim bmp As New Bitmap(pbImagen.Image)  'Creamos un objeto de la clase Bitmap
        'For i = 0 To pbImagen.Image.Width - 1 'Recorremos la matriz a lo ancho
        '    For j = 0 To pbImagen.Image.Height - 1 'Recorremos la matriz a lo largo
        '        Niveles(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
        '    Next
        'Next
    End Sub

    Private Sub txtZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZoom.Click
        AplicarZoom()
    End Sub

    Private Sub txtZoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZoom.ValueChanged

    End Sub

    Private Sub btnBrilloMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrilloMenos.Click
        modificar("-brillo")
    End Sub

    Private Sub btnBrilloMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrilloMas.Click
        modificar("+brillo")
    End Sub
End Class