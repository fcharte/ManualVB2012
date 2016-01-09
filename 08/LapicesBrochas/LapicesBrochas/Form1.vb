Imports System.Drawing.Drawing2D

Public Class Form1

   Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
      ' Definimos el área base para dibujar los distintos rectángulos
      Dim Rectangulo = New Rectangle(10, 10, 100, 100)

      ' Una brocha de transición entre dos colores en sentido diagonal
      Dim BrochaFundido = New LinearGradientBrush(Rectangulo,
       Color.Yellow, Color.Red, LinearGradientMode.BackwardDiagonal)

      ' Una brocha sólida con color a medida
      Dim BrochaSimple = New SolidBrush(Color.FromArgb(128, 0, 64))

      ' Una brocha con un patrón predefindo
      Dim BrochaPatron = New HatchBrush(HatchStyle.Plaid, Color.YellowGreen)

      ' Y una brocha con una textura gráfica
      Dim BrochaImagen = New TextureBrush(New Bitmap(My.Resources.Hoja))

      ' Un tipo de letra más o menos grande
      Dim Tipo = New Font("Courier New", 24, FontStyle.Bold)

      With e.Graphics ' A dibujar
         ' Dibujamos el primer rectángulo con 
         ' la brocha de transición entre colores
         .FillRectangle(BrochaFundido, Rectangulo)
         ' y nos deplazamos cien puntos a la derecha
         Rectangulo.Offset(100, 0)
         ' para dibujar el siguiente rectángulo
         .FillRectangle(BrochaSimple, Rectangulo)
         ' ahora cien puntos a la izquierda y abajo
         Rectangulo.Offset(-100, 100)
         ' para dibujar otro rectángulo
         .FillRectangle(BrochaPatron, Rectangulo)
         ' y finalmente cien puntos más a la derecha
         Rectangulo.Offset(100, 0)
         ' para dibujar el último
         .FillRectangle(BrochaImagen, Rectangulo)

         ' Usamos dos de las brochas para escribir un mismo texto
         .DrawString("Brochas", Tipo, BrochaImagen, 20, 210)
         .DrawString("Brochas", Tipo, BrochaFundido, 120, 230)
      End With

   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      Dim Lapices = New frmLapices()
      Lapices.ShowDialog()

   End Sub
End Class
