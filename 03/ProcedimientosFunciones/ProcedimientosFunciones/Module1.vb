Module Module1

    Sub Main()
        Dim X As Integer = 16
        RaizCuarta(X)    ' Aquí X es 16
        RaizCuarta(X)    ' Aquí X es 4

        Dim Valores() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
        Console.WriteLine(SumaMatriz(Valores))
    End Sub

    Private Sub RaizCuarta(ByRef N As Long)
        N = Math.Sqrt(N)
        Console.WriteLine(Math.Sqrt(N))
    End Sub

    Private Function SumaMatriz(N() As Integer) As Long
        Dim X As Object, Suma As Long

        For Each X In N ' Recorremos todos los elementos
            Suma = Suma + X ' sumando el valor de cada uno
        Next
        Return Suma
        'SumaMatriz = Suma ' Facilitamos el resultado
    End Function

End Module
