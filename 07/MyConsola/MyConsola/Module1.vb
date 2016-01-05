Imports System.IO
Module Module1

   Sub Main()
      Dim Archivo As StreamReader
      Dim Texto As String

      For Each Parametro As String In My.Application.CommandLineArgs
         ' Analizar parámetro y actuar en consecuencia
         Console.WriteLine(Parametro)

      Next

      Archivo = File.OpenText("Texto.txt")
      Texto = Archivo.ReadToEnd
      Archivo.Close()

      Texto = My.Computer.FileSystem.ReadAllText("Texto.txt")

   End Sub

End Module
