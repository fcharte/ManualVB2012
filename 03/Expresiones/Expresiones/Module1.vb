Module Module1

    Sub Main()
        Dim Resultado = 16 Mod 3

        Console.WriteLine(5 * 10 > 5)
        Console.WriteLine(5 * (10 > 5))

        Dim A, B, C As Boolean, N As Integer
        N = 5

        A = N > 1  ' A es True o False
        B = N < 10  ' B es True o False
        C = A * B ' C será True si A y B son True

        C = (N > 1) * (N < 10)
    End Sub

End Module
