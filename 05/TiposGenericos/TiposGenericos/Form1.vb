Public Class Form1

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      Dim Numeros() As Double = {23.4, 65, -2.32, 11, 36, 8, 5, 44}
      Ordenar(Of Double).Ordena(Numeros)
      For Each Numero As Double In Numeros
         ListBox1.Items.Add(Numero)
      Next

   End Sub
End Class
