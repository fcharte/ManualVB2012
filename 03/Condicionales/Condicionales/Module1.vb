Module Module1

    Sub Main()
        Dim Cadena As String
        Dim N As Integer = 2, Factor = 5, Resultado
        Dim ValorValido As Integer

        Cadena = IIf(N > 5, "Sí", "No")
        Console.WriteLine(Cadena)

        Cadena = Interaction.Switch(N > 5, "SI", N > 2, "CASI", N < 2, "NO")
        Console.WriteLine(Cadena)

        Console.WriteLine(Interaction.Switch(N = 1, "Enero", N = 2, "Febrero", N = 3, "Marzo"))

        Console.WriteLine(Choose(N, "Enero", "Febrero", "Marzo"))

        If N < 10 Then Beep()
        If N < 10 Then Beep() : N = 0 : ValorValido = False

        If N < 10 Then
            Beep()
            N = 0
            ValorValido = False
        End If

        If N < 10 Then
            Beep()  ' Esto se ejecuta si N es menor que 10
            ValorValido = False
        Else
            ValorValido = True  ' Esto se ejecuta si N no es menor que 10
            N = N * Factor
        End If

        Resultado = N ' Esto se ejecuta siempre

        If N < 10 Then
            N = 0
        ElseIf N < 15 Then
            N = N * 2
        Else
            N = N * 3
        End If


        Select Case N
            Case Is < 10
                N = 0
            Case Is < 15
                N = N * 2
            Case Else
                N = N * 3
        End Select


        If N = 3 Or N = 5 Or N >= 25 And N <= 35 Then
            N = N * 2
        ElseIf N = 2 Or N = 4 Or N >= 12 And N <= 24 Then
            N = N / 2
        Else
            N = 0
        End If

        Select Case N
            Case 3, 5, 25 To 35
                N = N * 2
            Case 2, 4, 12 To 24
                N = N / 2
            Case Else
                N = 0
        End Select

    End Sub

End Module
