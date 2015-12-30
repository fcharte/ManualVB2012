Imports System

' Toda la aplicación se incluye en un ámbito con 
' nombre que evita conflictos con otros proyectos
Namespace Anaya.ManualVB2012.ClasesAnidadas

   Class Agenda  ' Nuestra clase de primer nivel
      Public N As Integer
      Class Anotacion  ' contiene a otra
         ' ésta tiene un constructor de clase
         Shared Sub New()
            Console.WriteLine("Constructor de clase de Anotacion")
         End Sub

         ' un constructor sin parámetros
         Public Sub New()
            Console.WriteLine("Constructor de Anotacion")
         End Sub

         ' y un constructor con un parámetro
         Public Sub New(Parametro As String)
            Console.WriteLine("Constructor {0}", Parametro)
         End Sub

         ' destructor
         Protected Overrides Sub Finalize()
            Console.WriteLine("Destructor de Anotacion")
         End Sub
      End Class ' Fin de la clase Anotacion

      ' Esta declaración pertenece a la clase Agenda
      Private MiAnotacion As Anotacion

      ' Al construir un objeto de esta clase
      Public Sub New()
         Console.WriteLine("Constructor de Agenda")
         ' creamos uno de la clase Anotacion
         MiAnotacion = New Anotacion("Nueva anotación")
      End Sub

      ' Al destruir el objeto
      Protected Overrides Sub Finalize()
         Console.WriteLine("Destructor de Agenda")
         ' liberamos la referencia, aunque realmente no sería necesario
         MiAnotacion = Nothing
      End Sub
   End Class ' Fin de la clase Agenda

   ' Esta clase contiene simplemente el método Main(), que pone en marcha
   ' la aplicación creando un objeto Agenda
   Class Principal
      Shared Sub Main()
         Dim MiAgenda As Agenda = New Agenda()
         Console.WriteLine("Objeto creado")
         MiAgenda = Nothing
         Console.WriteLine("Fin de la aplicación")
      End Sub
   End Class ' Fin de la clase Principal

End Namespace ' Fin del ámbito con nombre
