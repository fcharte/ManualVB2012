Imports System.Drawing.Drawing2D
Public Class Form1

   Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
      ' Creamos un nuevo camino
      Dim Camino = New GraphicsPath()
      ' Matrices con los puntos de una línea curva
      Dim Puntos() = {
           New Point(50, 150),
           New Point(75, 200),
           New Point(120, 140)}

      With Camino ' Preparamos el camino
         .StartFigure() ' iniciando una nueva figura
         ' formada por un rectángulo
         .AddRectangle(New Rectangle(10, 10, 100, 100))
         ' y un arco
         .AddArc(50, 75, 100, 50, 0, 359)
         .CloseFigure() ' cerramos la figura
         .StartFigure() ' e iniciamos otra
         ' con una línea curva definida por los puntos
         .AddCurve(Puntos)
      End With

      ' Rellenamos el camino
      e.Graphics.FillPath(Brushes.Aqua, Camino)
      ' y dibujamos su contorno
      e.Graphics.DrawPath(Pens.Blue, Camino)

      ' Preparamos una matriz de transformación
      Dim Matriz = New Matrix()
      ' trasladando el camino en el espacio
      Matriz.Translate(200, 50)
      Matriz.Scale(0.75, 0.75)
      ' y rotándolo 45°
      Matriz.Rotate(45)

      ' Aplicamos la transformación al camino
      Camino.Transform(Matriz)
      ' y dibujamos sólo el contorno en rojo
      e.Graphics.DrawPath(Pens.Red, Camino)

   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      'Un rectángulo de las dimensiones del formulario
      Dim Rectangulo = New Rectangle(
                0, 0, Me.Size.Width, Me.Size.Height)
      ' un camino
      Dim Camino As GraphicsPath = New GraphicsPath()

      ' Preparamos un círculo
      Camino.AddArc(Rectangulo, 0, 359)
      ' para crear una región a partir de él
      Dim Area As Region = New Region(Camino)

      ' Añadimos a la región un rectángulo estrecho
      ' en la parte superior
      Rectangulo.Width = 100
      Rectangulo.Height = 40
      ' uniéndolo con el círculo
      Area.Union(Rectangulo)

      ' establecemos la región como apariencia
      ' de la ventana
      Me.Region = Area

   End Sub
End Class
