Class MainWindow 

   Private Sub Ellipse1_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Ellipse1.MouseUp
      Ellipse1.Fill.Opacity *= 0.9
      Ellipse1.RenderTransformOrigin = New Point(0.5, 0.5)
      Ellipse1.RenderTransform = New RotateTransform(45)

   End Sub
End Class
