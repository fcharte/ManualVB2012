Public Class Form1

   Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
      ' Creamos la nueva ventana
      Dim VentanaHija As frmarchivo = New frmArchivo()
      ' que será hija MDI de la ventana marco
      VentanaHija.MdiParent = Me
      VentanaHija.Show() ' y la mostramos
   End Sub
End Class
