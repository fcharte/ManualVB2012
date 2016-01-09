Public Class Form1

   Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
      ' Creamos el lápiz inicial
      Dim Pincel = New Pen(Color.Aqua, 5)
      With e.Graphics
         ' lo usamos para dibujar un rectángulo
         .FillRectangle(Brushes.Gold, 10, 10, 100, 100)
         .DrawRectangle(Pincel, 10, 10, 100, 100)
         ' cambiamos su color
         Pincel.Color = Color.DarkCyan
         ' y dibujamos un arco
         .DrawArc(Pincel, 100, 100, 50, 50, 0, 180)
         ' cambiamos color y grosor
         Pincel.Color = Color.Blue
         Pincel.Width = 8
         ' y dibujamos una línea
         .DrawLine(Pincel, 10, 10, 110, 110)
         ' Creamos el objeto Font
         Dim TipoLetra As Font = New Font("Courier New", 14,
         FontStyle.Underline Or FontStyle.Bold)
         ' Insertamos un texto
         .DrawString("GDI+ y Visual Basic 2012", TipoLetra, Brushes.Blue, 10, 200)
      End With
   End Sub
End Class
