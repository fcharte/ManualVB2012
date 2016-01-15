Imports System.IO

Module Module1

   Sub Main()
      ' Obtenemos el camino de la carpeta actual
      Dim Carpeta = My.Computer.FileSystem.CurrentDirectory
      ' y recuperamos el primero de los archivos
      Dim Archivo = My.Computer.FileSystem.GetFiles(Carpeta)(0)

      ' Mostramos los componentes de ese camino completo
      Console.WriteLine(
       "Camino completo= " & Archivo & vbCrLf &
       "Carpeta= " & Path.GetDirectoryName(Archivo) & vbCrLf &
       "Archivo= " & Path.GetFileName(Archivo) & vbCrLf &
       "Archivo sin extensión= " &
       Path.GetFileNameWithoutExtension(Archivo) & vbCrLf &
       "Extensión= " & Path.GetExtension(Archivo))

      ' Cambiamos la extensión
      Console.WriteLine("Camino tras cambiar la extensión= " &
       Path.ChangeExtension(Archivo, ".txt"))

      ' Obtenemos el camino para archivos temporales y un
      ' nombre de archivo temporal
      Console.WriteLine(
       "Carpeta temporal= " & Path.GetTempPath() & vbCrLf &
       "Archivo temporal= " & Path.GetTempFileName())

      Console.ReadLine()


      ' Matriz con los nombres de los miembros y el valor que contienen
      Dim Datos =
       {{"AltDirectorySeparatorChar", Path.AltDirectorySeparatorChar},
        {"DirectorySeparatorChar", Path.DirectorySeparatorChar},
        {"PathSeparator", Path.PathSeparator},
        {"VolumeSeparatorChar", Path.VolumeSeparatorChar},
        {"InvalidPathChars", Path.GetInvalidPathChars()}}

      Dim Indice As Integer
      ' Recorremos la matriz
      For Indice = 0 To Datos.GetUpperBound(0)
         ' mostrando la pareja Nombre=Valor
         Console.WriteLine("{0}= {1}", Datos(Indice, 0), Datos(Indice, 1))
      Next

   End Sub

End Module
