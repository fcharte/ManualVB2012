Class MainWindow 

   Private Sub Button1_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click
      ListBox1.Items.Add(TextBox1.Text)
      TextBox1.SelectAll()

   End Sub
End Class
