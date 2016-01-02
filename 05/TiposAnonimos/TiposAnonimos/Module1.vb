Module Module1

    Sub Main()
      Dim Anotacion = New With {
      .X = 17, .Y = 24, .Texto = "Puerto del aire"}

      Console.WriteLine(Anotacion.Texto)
      Console.WriteLine(Anotacion.GetType().ToString)
    End Sub

End Module
