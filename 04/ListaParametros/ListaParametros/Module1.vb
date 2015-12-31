Imports System

Namespace Anaya.ManualVB2012.ListaParametros

   Class ParametrosMetodos
      ' Un método compartido, que puede utilizarse directamente sin
      ' necesidad de crear un objeto de la clase.
      ' Recibe una lista variable de parámetros
      Shared Sub Metodo(ParamArray Parametros() As Object)
         Dim Parametro As Object
         Dim Ind As Byte = 1
         ' mostramos el número de parámetros 
         Console.WriteLine("Hay {0} parámetros", Parametros.Length)

         ' recorremos la lista de parámetros
         For Each Parametro In Parametros
            ' mostrando el valor y su tipo
            Console.WriteLine("Parámetro {0}: Valor->{1}, Tipo->{2}",
              Ind, Parametro, Parametro.GetType().FullName)
            Ind += 1
         Next
      End Sub

      Shared Function Numero() As Integer
         Return 5
      End Function

      ' Al iniciar el programa simplemente llamamos al método anterior
      ' con una lista de  parámetros cualquiera
      Shared Sub Main()
         Metodo("Una cadena", 2, True, 7.5, "Otra cadena")
         Console.WriteLine(Numero())
      End Sub
   End Class
End Namespace
