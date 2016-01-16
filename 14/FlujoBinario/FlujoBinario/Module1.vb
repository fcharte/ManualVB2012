Imports System.IO
Module Module1

   Sub Main()
      ' Obtenemos nombres temporales para los archivos
      Dim ArchTexto = Path.GetTempFileName
      Dim ArchBinario = Path.GetTempFileName
      ' preparamos un vector con varios datos
      Dim Datos() As Object = {8382321223, 166.386, True, "Hola"}
      Dim Dato As Object
      ' abrimos un flujo con StreamWriter
      Dim SWTexto As New StreamWriter(ArchTexto)
      ' y otro con BinaryWriter
      Dim BWBinario As New BinaryWriter(
         New FileStream(ArchBinario, FileMode.Create))

      ' Recorremos el arreglo
      For Each Dato In Datos
         ' escribiendo el mismo dato
         SWTexto.Write(Dato)
         ' en los dos flujos
         BWBinario.Write(Dato)
      Next

      ' cerramos los archivos
      SWTexto.Close()
      BWBinario.Close()

      ' y mostramos sus nombres por la consola
      Console.WriteLine("Texto -> {0}{1}Binario -> {2}", ArchTexto, vbCrLf, ArchBinario)
   End Sub

End Module
