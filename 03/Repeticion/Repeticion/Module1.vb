Module Module1

    Sub Main()
        Dim N As Integer
        For N = 1 To 255 Step 3
            Console.WriteLine(N & "->" & Chr(N))
            If N > 100 Then Exit For
        Next

        Do While N <> 0
            N = Console.Read()
            N = 0
        Loop

        Dim Suma As Integer
        Dim Sumandos() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}

        For Each Sumando In Sumandos
            Suma = Suma + Sumando
        Next
        Console.WriteLine("Suma " & Suma)

    End Sub

End Module
