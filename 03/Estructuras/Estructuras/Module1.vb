Public Structure Anotacion
    Public Fecha As Date
    Public Anotador As String
    Public Nota As String
    Public Sub New(ByVal F As Date,
       ByVal A As String, ByVal N As String)
        Fecha = F
        Anotador = A
        Nota = N
    End Sub
End Structure

Public Structure Temperaturas
    Public Capital As String
    Public Temperaturas() As Byte
    Public Sub New(C As String)
        Capital = C
        ReDim Temperaturas(23)
    End Sub
End Structure

Module Module1

    Sub Main()
        Dim MiAnotacion As Anotacion
        Dim Anotaciones = New Anotacion With {.Fecha = Date.Now(), .Nota = "Revisión CPU"}

        MiAnotacion = New Anotacion(Now, "Francisco",
                     "Hay que llamar a los pintores")

        With MiAnotacion
            System.Console.WriteLine(.Fecha & " - " &
                         .Anotador & " - " & .Nota)
        End With

        Console.WriteLine(MiAnotacion.Anotador)

        Dim T1 = New Temperaturas("Jaén")
        T1.Temperaturas(0) = 5

        Dim T2(365) As Temperaturas
        T2(23) = New Temperaturas("Jaén")
        T2(23).Temperaturas(0) = 5

    End Sub

End Module
