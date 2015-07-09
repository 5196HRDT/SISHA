Module NumerosLetras
    Public Function ValorEnLetras(ByVal ElValor As Double, Optional ByVal Moneda As String = "Cordobas") As String

        Dim Letras1 As String, Letras2 As String = "", Letras3 As String

        Dim ElValor1 As Long, ElValor2 As Long, LetrasM As String = ""



        If ElValor < 0 Then

            ElValor1 = Math.Abs(Int(ElValor))

        Else

            ElValor1 = Math.Abs(Int(ElValor))

        End If

        ElValor2 = Math.Round(((Math.Abs(ElValor) - ElValor1) * 100), 2)



        If ElValor = 0 Then

            ValorEnLetras = "Cero"

        ElseIf ElValor > 0 Then

            If Int(ElValor1 / 1000000) > 0 Then LetrasM = CienMiles(Int(ElValor1 / 1000000))

            If Int((ElValor1 - (Int(ElValor1 / 1000000) * 1000000)) / 1000) > 0 Then Letras1 = CienMiles((Int(ElValor1 / 1000)) - (1000 * Int(ElValor1 / 1000000))) & " mil " Else If Int(ElValor1 / 1000000) > 0 Then Letras1 = " de " Else Letras1 = ""

            If ElValor1 - (1000 * Int(ElValor1 / 1000)) > 0 Then Letras2 = CienMiles(ElValor1 - (1000 * Int(ElValor1 / 1000)))

            If ElValor2 = 0 Then

                ValorEnLetras = IIf(ElValor < 0, "Menos ", "") & LetrasM & IIf(LetrasM <> "", IIf((Int(ElValor1 / 1000000)) > 1, "Millones ", "Millon "), "") & Letras1 & IIf(Letras1 <> "", "", "") & Letras2 & " con 00/100 " & Moneda

            Else

                'Letras3 = CienMiles(ElValor2)
                Letras3 = ElValor2

                If ElValor <> (ElValor2 / 100) Then

                    ValorEnLetras = IIf(ElValor < 0, "Menos ", "") & LetrasM & IIf(LetrasM <> "", IIf((Int(ElValor1 / 1000000)) > 1, "Millones ", "Millon "), "") & Letras1 & IIf(Letras1 <> "", "", "") & Letras2 & " con " & Microsoft.VisualBasic.Right("00" & Letras3, 2) & "/100 " & Moneda

                Else

                    ValorEnLetras = IIf(ElValor < 0, "Menos ", "") & Letras3 & " centavos de " & IIf(UCase$(Moneda) = "DOLARES" Or UCase$(Moneda) = UCase$("D�LARES"), "D�lar", "C�rdoba")

                End If

            End If

        Else

            ValorEnLetras = "Sobregirado"

        End If



    End Function



    '##ModelId=39DCAD7702E4

    Private Function CienMiles(ByVal Centenar As Long) As String

        Dim Cadena As String = ""



        If Centenar > 99 Then

            Select Case Int(Centenar / 100)

                Case 0

                    Cadena = ""

                Case 1

                    If (Centenar - (100 * Int(Centenar / 100))) = 0 Then

                        Cadena = Cadena & "Cien "

                    Else

                        Cadena = Cadena & "Ciento "

                    End If

                Case 2

                    Cadena = Cadena & "Doscientos "

                Case 3

                    Cadena = Cadena & "Trescientos "

                Case 4

                    Cadena = Cadena & "Cuatrocientos "

                Case 5

                    Cadena = Cadena & "Quinientos "

                Case 6

                    Cadena = Cadena & "Seiscientos "

                Case 7

                    Cadena = Cadena & "Setecientos "

                Case 8

                    Cadena = Cadena & "Ochocientos "

                Case 9

                    Cadena = Cadena & "Novecientos "



            End Select

        End If





        Dim Valor2 As Integer, Cadena1 As String = ""



        Valor2 = Centenar - (Int(Centenar / 100) * 100)



        Select Case Valor2

            Case 10

                Cadena = Cadena & "Diez "

            Case 11

                Cadena = Cadena & "Once "

            Case 12

                Cadena = Cadena & "Doce "

            Case 13

                Cadena = Cadena & "Trece "

            Case 14

                Cadena = Cadena & "Catorce "

            Case 15

                Cadena = Cadena & "Quince "

            Case 16 To 19

                Cadena = Cadena & "Diez "

            Case 20 To 29

                Cadena = Cadena & "Veinte "

            Case 30 To 39

                Cadena = Cadena & "Treinta "

            Case 40 To 49

                Cadena = Cadena & "Cuarenta "

            Case 50 To 59

                Cadena = Cadena & "Cincuenta "

            Case 60 To 69

                Cadena = Cadena & "Sesenta "

            Case 70 To 79

                Cadena = Cadena & "Setenta "

            Case 80 To 89

                Cadena = Cadena & "Ochenta "

            Case 90 To 99

                Cadena = Cadena & "Noventa "



            Case Else



        End Select



        Valor2 = Centenar - (Int(Centenar / 10) * 10)

        Dim Valor3 As Integer



        Valor3 = Int((Centenar - ((Int(Centenar / 100) * 100))) / 10)



        If ((Centenar - (Int(Centenar / 100) * 100)) >= 10) And ((Centenar - (Int(Centenar / 100) * 100)) <= 15) Then

        Else

            If Valor2 <> 0 Then

                If Trim$(Cadena) <> "" Then

                    If Valor3 <> 0 Then

                        Cadena = Cadena & "y "

                    End If

                End If

            End If



            Select Case Valor2



                Case 1

                    Cadena = Cadena & "Un "



                Case 2

                    Cadena = Cadena & "Dos "



                Case 3

                    Cadena = Cadena & "Tres "



                Case 4

                    Cadena = Cadena & "Cuatro "



                Case 5

                    Cadena = Cadena & "Cinco "



                Case 6

                    Cadena = Cadena & "Seis "



                Case 7

                    Cadena = Cadena & "Siete "



                Case 8

                    Cadena = Cadena & "Ocho "



                Case 9

                    Cadena = Cadena & "Nueve "



            End Select

        End If



        If Centenar = 0 Then

            Cadena = "Cero"

        End If

        CienMiles = Cadena



    End Function

    Public Function Redondear(ByVal Numero As Double, ByVal Decimales As Integer) As Double
        On Error GoTo ElFallo

        Dim Val1 As Single
        Dim Val2 As Double

        Val1 = (Numero * (10 ^ (Decimales))) - Int((Numero * (10 ^ (Decimales))))
        Val2 = CInt(Val1 + 1) - 1

        Redondear = (Int(Numero * (10 ^ (Decimales)) + Val2)) / (10 ^ (Decimales))

        Exit Function
ElFallo:

        If Err.Number <> 0 Then

            MsgBox(Err.Description)

        End If

    End Function
End Module
