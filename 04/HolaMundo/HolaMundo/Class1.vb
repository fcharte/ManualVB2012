Namespace ClasesAnaya
   ' ClasesAnaya es el espacio superior

   Namespace ManualVS2012
      ' ManualVS2012 es un espacio interior
      Public Class HolaMundo
         ' con una clase llamada HolaMundo
         Public Function Saludo() As String
            Return "Hola desde el ámbito Anaya.ManualVS2012"
         End Function
      End Class
   End Namespace

   Namespace ManualVB2012
      ' ManualVB2012 es otro espacio interior
      Public Class HolaMundo
         ' también tiene una clase HolaMundo
         Public Function Saludo() As String
            Return "Hola desde el ámbito Anaya.ManualVB2012"
         End Function
      End Class
   End Namespace
End Namespace
