Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim N1 As Integer = 5, N2 = 7
      My.Utilidades.Intercambia(Of Integer)(N1, N2)
      Label1.Text = N1
      Label2.Text = N2

   End Sub
End Class
