
Partial Class _Default
    Inherits System.Web.UI.Page

   Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
      TextBox1.Text = "Has elegido la fecha " & Calendar1.SelectedDate
   End Sub
End Class
