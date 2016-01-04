Public Class Form1

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      lbDatos.Items.Add(tbDato.Text) ' Añadimos el dato
      tbDato.SelectAll() ' Seleccionamos el texto
      tbDato.Select() ' y activamos el TextBox


   End Sub

   Shared Sub Main()
      Application.Run(New Form1())
   End Sub

End Class
