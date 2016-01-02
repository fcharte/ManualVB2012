Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim MiFactoria As Factoria(Of String, Button) = New Factoria(Of String, Button)

      MiFactoria.Nuevo("Boton1").Text = "Primer botón"
      MiFactoria.Elemento("Boton1").Parent = Me
      MiFactoria.Elemento("Boton1").Show()

      Dim Boton As Button = MiFactoria.Nuevo("Boton2")
      Boton.Parent = Me
      Boton.Top = 100
      Boton.Text = "Botón 2"
      Boton.Show()

   End Sub
End Class
