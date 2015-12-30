Imports System

Namespace Anaya.ManualVB2012.Constantes

   Class Aplicacion

      Const SegundosMinuto As Integer = 60
      Const MinutosHora As Integer = 60
      Const HorasDia As Integer = 24

      Shared Sub Main()
         Console.WriteLine("Un día tiene {0} segundos",
          SegundosMinuto * MinutosHora * HorasDia)
      End Sub
   End Class
End Namespace
