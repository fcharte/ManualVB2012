Imports System

Namespace Anaya.ManualVB2012.Interfaces

   ' la interfaz IAgenda cuenta con un método
   Interface IAgenda
      Sub Enumera()
   End Interface


   ' la interfaz IPersistente con dos
   Interface IPersistente
      Function Almacena() As Boolean
      Function Recupera() As Boolean
   End Interface

   ' Esta clase, al implementar la interfaz IAgenda,
   ' deberá contar con el método Enumera()
   Class Agenda
      Implements IAgenda
      Public Function Add(
      ByVal Anotacion As String) As Boolean
         Return True
      End Function

      Public Sub Enumera() Implements IAgenda.Enumera
      End Sub

      Default Public ReadOnly Property Item(Indice As Integer) As String
         Get
            Return "Agenda"
         End Get
      End Property
   End Class

   ' y esta también
   Class AgendaArchivo
      Implements IAgenda, IPersistente

      Public Sub Enumera() Implements IAgenda.Enumera
      End Sub

      Public Function Almacena() As Boolean Implements IPersistente.Almacena
         Return True
      End Function

      Public Function Recupera() As Boolean Implements IPersistente.Recupera
         Return True
      End Function
   End Class

   ' Podemos usar IAgenda como un tipo cualquiera,
   ' con la ventaja del polimorfismo
   Class Aplicacion
      Shared Sub Main()
         Dim MiAgenda As IAgenda = New Agenda()
         MiAgenda = New AgendaArchivo()
      End Sub
   End Class
End Namespace
