Public Class Form1

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If My.Settings.ImagenFondo Then
         Me.BackgroundImage = My.Resources.LogoAnaya
         CheckBox1.Checked = True
      End If
      Me.Text = My.Resources.Titulo

   End Sub
   Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
      My.Settings.ImagenFondo = CheckBox1.Checked
      If My.Settings.ImagenFondo Then
         Me.BackgroundImage = My.Resources.LogoAnaya
      Else
         Me.BackgroundImage = Nothing
      End If
   End Sub
End Class
