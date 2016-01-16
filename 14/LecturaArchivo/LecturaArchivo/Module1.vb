Imports System.IO
Module Module1

   Sub Main()
      ' Recuperamos el camino de la carpeta actual
      Dim CaminoActual = My.Computer.FileSystem.CurrentDirectory
      ' y obtenemos el primero de los archivos que haya en ella
      Dim UnArchivo = My.Computer.FileSystem.GetFiles(CaminoActual)(0)
      Dim Dato As Integer, Indice As Integer

      ' Abrimos el archivo para lectura
      Dim FSArchivo = New FileStream(UnArchivo, FileMode.Open, FileAccess.Read)
      ' indicamos el archivo del que vamos a leer
      Console.WriteLine("Información del archivo {0}", UnArchivo)

      ' En este bucle vamos leyendo byte a byte
      For Indice = 1 To FSArchivo.Length
         Dato = FSArchivo.ReadByte
         ' mostrando el dato numérico y el carácter correspondiente
         Console.Write("{0} ({1}){2}", Dato, IIf(Dato > 31, Chr(Dato), "?"), vbTab)
      Next

      Dim Contenido = My.Computer.FileSystem.ReadAllBytes(
            My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory)(0))

      For Each Elemento As Byte In Contenido
         Console.Write("{0} ({1}){2}", Elemento,
             IIf(Elemento > 31, Chr(Elemento), "?"), vbTab)
      Next

   End Sub

End Module
