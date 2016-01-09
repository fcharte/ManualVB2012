Public Class Form1
   ' Para mantener la imagen en memoria
   Private Imagen As Image
   ' Al hacer clic sobre el formulario
   Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
      ' Si se selecciona un archivo
      If OpenFileDialog1.ShowDialog() =
                                 Windows.Forms.DialogResult.OK Then
         ' mostramos su nombre
         Me.Text = OpenFileDialog1.FileName
         ' y recuperamos la imagen
         Imagen = Image.FromFile(
               OpenFileDialog1.FileName)
         ' estableciendo el área de desplazamiento
         Me.AutoScrollMinSize = Imagen.Size

         Invalidate() ' forzamos la actualización
      End If
   End Sub
   ' Controlamos las pulsaciones de tecla
   Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      ' Si se ha pulsado "R" rotamos la imagen
      If Char.ToUpper(e.KeyChar) = "R" Then
         ' rotamos la imagen 90 grados
         Imagen.RotateFlip(RotateFlipType.Rotate90FlipNone)
         Invalidate() ' y actualizamos
      End If

      ' Si se ha pulsado "T" añadimos un titulo
      If Char.ToUpper(e.KeyChar) = "T" Then
         Dim Grafico As Graphics
         Dim TipoLetra As Font
         ' Obtenemos un Graphics a partir de la imagen
         Grafico = Graphics.FromImage(Imagen)
         ' preparamos el tipo de letra
         TipoLetra = New Font("Courier New", 24,
             FontStyle.Bold Or FontStyle.Italic)
         ' escribimos el título
         Grafico.DrawString("GDI+", TipoLetra,
             Brushes.Blue, 10, 10)
         Invalidate() ' y actualizamos
      End If
   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub
   ' Cada vez que tenga que actualizarse la ventana
   Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
      ' Sólo si tenemos una imagen
      If Not (Imagen Is Nothing) Then
         ' la mostramos en el formulario
         e.Graphics.DrawImage(Imagen, Me.AutoScrollPosition)
      End If
   End Sub
   ' Si se cambia el formulario de tamaño
   Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Invalidate() ' actualizar la visualización
   End Sub
End Class
