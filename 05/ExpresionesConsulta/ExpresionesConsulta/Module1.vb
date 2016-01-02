Module Module1

   Structure Agenda
      Dim Nombre, Direccion, TelfCasa, TelfMovil As String
      Dim FechaCumple As DateTime
   End Structure

   Sub Main()
      Dim Felicitaciones As New List(Of Agenda)

      With Felicitaciones
         .Add(New Agenda With {.Nombre = "Irene Gracia", .FechaCumple = #5/23/1966#})
         .Add(New Agenda With {.Nombre = "Mario Allende", .FechaCumple = #12/17/1976#})
      End With

      Dim FelicitarHoy =
        From Ficha In Felicitaciones Where
          Ficha.FechaCumple.Month = DateTime.Now.Month And
          Ficha.FechaCumple.Day = DateTime.Now.Day
        Select Ficha.Nombre

      Dim FelicitarHoy2 =
         Felicitaciones.Where(Function(
             Ficha) Ficha.FechaCumple.Month = DateTime.Now.Month And
            Ficha.FechaCumple.Day = DateTime.Now.Day).Select(
            Function(Ficha) Ficha.Nombre)

      Console.WriteLine(FelicitarHoy2.Count)
      If FelicitarHoy2.Count > 0 Then
         Console.WriteLine(FelicitarHoy2(0))
      End If
   End Sub

End Module


