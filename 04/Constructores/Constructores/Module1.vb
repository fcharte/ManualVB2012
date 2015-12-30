Class Agenda
   ' Constructor sin parámetros
   Shared Sub New()
      Console.WriteLine("Constructor de clase")
   End Sub

   Public Sub New()
      Console.WriteLine("Constructor por defecto")
   End Sub

   ' y con un parámetro
   Public Sub New(Parametro As String)
      Console.WriteLine("Constructor " & Parametro)
   End Sub

   ' Destructor
   Protected Overrides Sub Finalize()
      Console.WriteLine("Destructor")
   End Sub
End Class

Module Module1

   Sub Main()
      ' sin parámetros
      Dim MiAgenda As Agenda = New Agenda()
      ' con parámetros
      Dim OtraAgenda As Agenda = New Agenda("Parámetro")

   End Sub

End Module
