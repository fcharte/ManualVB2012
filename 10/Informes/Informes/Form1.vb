Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      'TODO: esta línea de código carga datos en la tabla 'bibliotecaDataSet.libros' Puede moverla o quitarla según sea necesario.
      Me.librosTableAdapter.Fill(Me.bibliotecaDataSet.libros)

      Me.ReportViewer1.RefreshReport()
   End Sub
End Class
