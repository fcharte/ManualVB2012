Module Module1

   Sub Main()
      Dim Valores() = {30, 15, 3.14, 7}
      Dim Unidades = My.Computer.FileSystem.Drives

      For Each Unidad In Unidades
         Console.WriteLine(Unidad.DriveType.ToString())
      Next

   End Sub
End Module
