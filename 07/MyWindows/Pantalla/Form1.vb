Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      With My.Computer.Screen
         ListBox1.Items.Add("Nombre: " & .DeviceName)
         ListBox1.Items.Add("Coordenadas: " & .Bounds.ToString)
         ListBox1.Items.Add("Área disponible: " & .WorkingArea.ToString)
         ListBox1.Items.Add("Bits de color: " & .BitsPerPixel)
      End With
         My.Computer.Registry.
   End Sub
End Class
