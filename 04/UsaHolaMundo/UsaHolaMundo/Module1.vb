Imports System
' Incluimos referencia a los dos ámbitos
Imports VS = ClasesAnaya.ManualVS2012
Imports VB = ClasesAnaya.ManualVB2012

Module Module1

   Sub Main()
      Dim MiHolaMundo As VB.HolaMundo = New VB.HolaMundo()

      Console.WriteLine(MiHolaMundo.Saludo())
   End Sub

End Module
