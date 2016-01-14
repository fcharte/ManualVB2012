Partial Public Class Nuevo
    Inherits PhoneApplicationPage

    Public Sub New()
        InitializeComponent()
    End Sub

   Private Sub ApplicationBarIconButton_Click_1(sender As Object, e As EventArgs)
      NavigationService.GoBack()
   End Sub

   Private Sub ApplicationBarIconButton_Click_2(sender As Object, e As EventArgs)
      App.ViewModel.Items.Add(New ItemViewModel() With {.LineOne = Titulo.Text, .LineTwo = Descripción.Text, .Comprado = False})
      NavigationService.GoBack()
   End Sub
End Class
