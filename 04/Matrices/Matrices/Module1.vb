Imports System

Namespace Anaya.ManualVB2012.Matrices

   ' Una nueva versión de la clase Agenda
   Class Agenda
      Const NumeroMaximoEntradas As Byte = 100

      ' capaz de almacenar hasta cien anotaciones
      Private Anotaciones(NumeroMaximoEntradas) As String

      Private UltimaAnotacion As Byte = 0 ' índice de la última

      ' Disponemos un operador que facilitará  la inserción
      Public Shared Operator +(Destino As Agenda,
                               Anotacion As String) As Boolean
         ' si no hay espacio en la matriz
         If Destino.UltimaAnotacion = Destino.Anotaciones.Length Then
            Return False ' devolvemos false
         Else
            ' en caso contrario añadimos la anotación
            Destino.Anotaciones(Destino.UltimaAnotacion) = Anotacion
            Destino.UltimaAnotacion += 1
            Return True ' y devolvemos true
         End If
      End Operator

      Default Public Property Item(Indice As Integer) As String
         Get
            If Indice >= UltimaAnotacion Then
               Throw New Exception("Índice inválido")
            Else
               Return Anotaciones(Indice)
            End If
         End Get
         Set(Value As String)
            If Indice >= UltimaAnotacion Then
               Throw New Exception("Índice inválido")
            Else
               Anotaciones(Indice) = Value
            End If
         End Set
      End Property

      ' método que enumera el contenido de la matriz
      Public Sub Enumera()
         Dim Ind As Byte
         For Ind = 0 To UltimaAnotacion - 1
            Console.WriteLine(Anotaciones(Ind))
         Next
      End Sub
   End Class

   Public Structure Anotacion
      Public Fecha As Date
      Public Anotador As String
      Public Nota As String
      Public Sub New(F As Date, A As String, N As String)
         Fecha = F
         Anotador = A
         Nota = N
      End Sub
   End Structure

   ' Desde la clase principal
   Class Aplicacion
      Shared Sub Main()
         Dim NuevaAnotacion As String
         Dim MiAgenda As Agenda = New Agenda()

         While True ' insertamos anotaciones
            Console.Write("Introduzca anotación :")
            NuevaAnotacion = Console.ReadLine()
            ' hasta que se pulse sólo Intro
            If NuevaAnotacion = "" Then
               Exit While
            End If
            ' Comprobar si se inserta con éxito
            If MiAgenda + NuevaAnotacion Then
               Console.WriteLine("Añadido con éxito")
            Else
               Console.WriteLine("No fue posible añadir la anotación")
            End If
         End While

         ' al terminar enumeramos el contenido
         MiAgenda.Enumera()
         Console.WriteLine("Voy a modificar el quinto elemento")
         Console.ReadLine()
         MiAgenda(4) = "Pepito Grillo"
         MiAgenda.Enumera()
      End Sub
   End Class
End Namespace