Imports System.IO

Module Module1

   Sub Main()
      ' Obtenemos un nombre de archivo temporal
      Dim NombreArchivo = My.Computer.FileSystem.GetTempFileName()
      ' y lo creamos abriéndolo para escritura
      Dim FSArchivo As New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write)
      Dim Linea As String, Indice As Integer

      ' Solicitamos los datos en un bucle
      Console.WriteLine("Introduzca líneas de datos. Deje la línea vacía para terminar")
      Do
         Console.Write("Dato: ")
         Linea = Console.ReadLine
         ' Recorremos la cadena de caracteres
         For Indice = 0 To Linea.Length - 1
            ' escribiendo cada byte obtenido del código de cada carácter
            FSArchivo.WriteByte(Asc(Linea.Chars(Indice)))
         Next
      Loop While Linea <> "" ' hasta que no se introduzca nada
      ' cerramos el archivo
      FSArchivo.Close()
      ' e indicamos el camino y nombre del archivo donde está la información
      Console.WriteLine("Información escrita en " & NombreArchivo)

   End Sub

End Module
