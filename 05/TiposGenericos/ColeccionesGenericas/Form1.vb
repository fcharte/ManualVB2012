Option Strict On
Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim Pila As New Stack(Of Integer)
      Pila.Push(5)
      Pila.Push(9)
      Pila.Push(3)
      Pila.Push("Cinco")

      While Pila.Count > 0
         ListBox1.Items.Add(Pila.Pop)
      End While
   End Sub
End Class
