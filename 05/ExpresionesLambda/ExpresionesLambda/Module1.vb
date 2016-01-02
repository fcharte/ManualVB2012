Module Module1
   ' Procedimiento que supuestamente ordenará el vector 
   ' de enteros basándose en el criterio aportado por Compara
   Sub Ordena(N As Integer(), Compara As Func(Of Integer, Integer, Boolean))
      If Compara(N(0), N(1)) Then
         Console.WriteLine("Hay que intercambiar los elementos")
      End If
   End Sub

   ' Punto de entrada al programa
   Sub Main()
      ' Vector de elementos a ordenar
      Dim Numeros = New Integer() {5, 12}

      ' Al invocar a Ordena creamos la función de comparación
      ' mediante la expresión lambda
      Ordena(Numeros, Function(N1, N2) N1 < N2)

      ' Sentencia lambda almacenada en una variable
      Dim Debug = Sub(mensaje)
                     Console.WriteLine(
                         AppDomain.CurrentDomain.FriendlyName &
                         vbCrLf & mensaje)
                  End Sub

      ' Uso de la sentencia lambda
      Debug("Mensaje de depuración")

   End Sub
End Module
