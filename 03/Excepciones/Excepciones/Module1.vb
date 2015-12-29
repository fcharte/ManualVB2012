Module Module1
    
    Sub Main()
        ' Variables para los valores
        Dim Cociente As Byte
        Dim Dividendo, Divisor As Integer

        Try
            ' Solicitamos la introducción de los datos
            Console.WriteLine("Introduzca el dividendo: ")
            ' y convertimos a número
            Dividendo = CInt(Console.ReadLine())
            Console.WriteLine("Introduzca el divisor: ")
            ' La conversión puede generar una excepción
            Divisor = CInt(Console.ReadLine())

            ' Efectuamos la división
            Cociente = Dividendo \ Divisor
            ' y mostramos el resultado
            Console.WriteLine("El resultado es {0}",
               Cociente)
            ' Si se produce una división por cero
        Catch X As DivideByZeroException
            Console.WriteLine(
                "Se ha producido una división por cero")
            ' Si se ha producido un desbordamiento
        Catch X As OverflowException
            Console.WriteLine(
                "Se ha producido un desbordamiento")
            ' En cualquier otro error aritmético
        Catch X As ArithmeticException
            Console.WriteLine(
                "Se ha producido otro error aritmético")
            Console.WriteLine(X.Message)
            Console.WriteLine(X.ToString)
        End Try

    End Sub

End Module
