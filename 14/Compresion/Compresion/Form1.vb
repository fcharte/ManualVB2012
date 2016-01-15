Imports System.IO
Imports System.IO.Compression

Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      For Each Unidad In My.Computer.FileSystem.Drives
         If Unidad.IsReady Then
            cbUnidades.Items.Add(Unidad.Name & " [" & Unidad.VolumeLabel & "]")
         Else
            cbUnidades.Items.Add(Unidad.Name)
         End If

         If cbUnidades.SelectedIndex = -1 AndAlso
             Unidad.DriveType = DriveType.Fixed Then
            cbUnidades.SelectedIndex = cbUnidades.Items.Count - 1
         End If
      Next
   End Sub

   Private Sub cbUnidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnidades.SelectedIndexChanged
      lbCarpetas.Items.Clear()

      For Each Carpeta In My.Computer.FileSystem.GetDirectories(
            Mid(cbUnidades.Text, 1, 3))
         lbCarpetas.Items.Add(Path.GetFileName(Carpeta))
      Next
      lbCarpetas.SelectedIndex = 0
   End Sub

   Private Sub lbCarpetas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbCarpetas.SelectedIndexChanged
      lbArchivos.Items.Clear()
      Try
         For Each Archivo In My.Computer.FileSystem.GetFiles(
             Mid(cbUnidades.Text, 1, 3) & lbCarpetas.Text,
             FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            lbArchivos.Items.Add(Path.GetFileName(Archivo))
         Next
      Catch
      End Try
   End Sub

   Private Sub lbArchivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbArchivos.SelectedIndexChanged
      Dim NombreArchivo =
       Mid(cbUnidades.Text, 1, 3) & lbCarpetas.Text & "\" &
       lbArchivos.Text

      Dim Inf As New FileInfo(NombreArchivo)

      ' Mostramos el número de bytes de longitud
      lbTamano.Text = Inf.Length & " bytes"

      ' Activamos o desactivamos los botones según la extensión del archivo
      btnComprimir.Enabled = Path.GetExtension(lbArchivos.Text) <> ".gz"
      btnDescomprimir.Enabled = Path.GetExtension(lbArchivos.Text) = ".gz"
   End Sub

   Private Sub btnComprimir_Click(sender As Object, e As EventArgs) Handles btnComprimir.Click
      ' Componemos el nombre del archivo
      Dim NombreArchivo = Mid(cbUnidades.Text, 1, 3) & lbCarpetas.Text & "\" &
       lbArchivos.Text
      ' y obtenemos información sobre él
      Dim Inf As New FileInfo(NombreArchivo)

      ' Leemos todo el contenido del archivo en una matriz
      Dim Contenido(CInt(Inf.Length)) As Byte
      Contenido = My.Computer.FileSystem.ReadAllBytes(NombreArchivo)

      ' Creamos un archivo donde escribir los datos comprimidos
      Using Salida As New FileStream(NombreArchivo & ".gz", FileMode.Create)
         ' y el objeto asociado que los comprimirá
         Using Compresor As New GZipStream(Salida, CompressionMode.Compress, True)
            ' Escribimos los datos en el flujo comprimido 
            Compresor.Write(Contenido, 0, Contenido.Length)
            ' lo cerramos para escribir las cabeceras en el archivo
            Compresor.Close()
            ' mostramos el tamaño de la información comprimida
            lbTamano.Text = "Comprimido a " & Salida.Length & " bytes"
         End Using
      End Using

      ' Actualizamos la lista de archivos para mostrar el recién creado
      lbCarpetas_SelectedIndexChanged(Me, System.EventArgs.Empty)
   End Sub

   Private Sub btnDescomprimir_Click(sender As Object, e As EventArgs) Handles btnDescomprimir.Click
      ' Componemos el nombre del archivo
      Dim NombreArchivo = Mid(cbUnidades.Text, 1, 3) & lbCarpetas.Text & "\" &
       lbArchivos.Text

      ' Creamos el objeto de descompresión para que lea del archivo
      Using Compresor As New GZipStream(New FileStream(NombreArchivo, FileMode.Open),
        CompressionMode.Decompress)
         ' creamos el archivo de salida
         Using Salida As New FileStream(Mid(cbUnidades.Text, 1, 3) &
             lbCarpetas.Text & "\" & Path.GetFileNameWithoutExtension(NombreArchivo),
             FileMode.Create)

            Dim Contenido(256) As Byte
            Dim BytesLeidos As Integer, Inicio As Integer = 0
            While True ' Vamos leyendo bloques de 256 bytes
               BytesLeidos = Compresor.Read(Contenido, 0, 256)
               If BytesLeidos <> 0 Then
                  ' y escribiéndolos en el archivo de saluda
                  Salida.Write(Contenido, 0, BytesLeidos)
               Else
                  Exit While
               End If
            End While
         End Using
      End Using

      ' Actualizamos la lista de archivos para mostrar el recién creado
      lbCarpetas_SelectedIndexChanged(Me, System.EventArgs.Empty)
   End Sub
End Class
