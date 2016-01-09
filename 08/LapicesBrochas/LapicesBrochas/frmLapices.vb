Imports System.Drawing.Drawing2D
Public Class frmLapices
   ' Miembros necesarios para mantener una lista
   ' de los estilos y terminadores existentes
   Private Terminadores As Array
   Private Trazos As Array
   ' así como el terminador y el estilo elegidos
   Private Terminador As LineCap
   Private Trazo As DashStyle

   Private Sub frmLapices_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
      ' Definimos una  brocha con una patrón
      Dim BrochaPatron = New HatchBrush(HatchStyle.Sphere, Color.Olive)
      ' y la usamos para construir el lápiz
      Dim Lapiz = New Pen(BrochaPatron, 8)

      ' Definimos el área base para una brocha
      Dim Rectangulo = New Rectangle(250, 150, 100, 150)

      ' De transición entre dos colores en sentido diagonal
      Dim BrochaFundido = New LinearGradientBrush(Rectangulo,
       Color.Yellow, Color.Red, LinearGradientMode.BackwardDiagonal)

      ' Establecemos el tipo de trazo y los terminadores
      Lapiz.DashStyle = Trazo
      Lapiz.StartCap = Terminador
      Lapiz.EndCap = Terminador

      ' y dibujamos dos líneas, una recta y una curva
      e.Graphics.DrawLine(Lapiz, 50, 150, 200, 250)
      ' cambiando la brocha de la segunda
      Lapiz.Brush = BrochaFundido
      e.Graphics.DrawArc(Lapiz, 250, 150, 100, 150, -90, 180)

   End Sub

   Private Sub frmLapices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ' Recuperamos la lista de terminadores
      Terminadores = System.Enum.GetValues(GetType(LineCap))
      ' y la lista de estilos
      Trazos = System.Enum.GetValues(GetType(DashStyle))

      ' Recorremos esas listas añadiendo el nombre
      For Each UnTerminador In Terminadores
         ' de cada terminador al ComboBox
         cbTerminadores.Items.Add(UnTerminador.ToString())
      Next

      ' que corresponda
      For Each UnTrazo In Trazos
         cbTrazo.Items.Add(UnTrazo.ToString())
      Next

      ' Seleccionamos el primer terminador y estilo
      cbTerminadores.SelectedIndex = 0
      cbTrazo.SelectedIndex = 0

   End Sub

   Private Sub cbTrazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTrazo.SelectedIndexChanged
      ' Recuperamos el trazo seleccionado
      Trazo = Trazos(cbTrazo.SelectedIndex)
      Invalidate() ' y redibujamos
   End Sub

   Private Sub cbTerminadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTerminadores.SelectedIndexChanged
      Terminador = Terminadores(cbTerminadores.SelectedIndex)
      Invalidate()
   End Sub
End Class