Public Class frmArchivo

   Private Sub CambiarColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarColorToolStripMenuItem.Click
      ' Si se selecciona un color
      If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
         ' lo establecemos como color del texto
         TextBox1.ForeColor = ColorDialog1.Color
      End If

   End Sub
End Class