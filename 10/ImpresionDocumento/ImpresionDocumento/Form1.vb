Imports System.Drawing.Drawing2D

Public Class Form1
   ' Título del informe
   Private Titulo =
          "Informe sobre uso de lenguajes"

   ' Lenguajes supuestamente estudiados
   Private Titulos() = {
      "Visual Basic", "C++", "Java",
      "Delphi", "Otros"}

   ' Datos hipotéticos de los lenguajes
   Private Datos() = {
      "32%", "27%", "15%", "12%", "14%"}

   ' Puntos para el gráfico sectorial
   Private Puntos(,) = {
     {0, 32 * 3.6}, {32 * 3.6, 27 * 3.6},
     {(32 + 27) * 3.6, 15 * 3.6},
     {(32 + 27 + 15) * 3.6, 12 * 3.6},
     {(32 + 27 + 15 + 12) * 3.6, 14 * 3.6}}

   ' Estilos de relleno para cada sector
   Private Relleno() = {
     HatchStyle.BackwardDiagonal,
     HatchStyle.Cross, HatchStyle.DashedHorizontal,
     HatchStyle.LightDownwardDiagonal,
     HatchStyle.DottedDiamond}

   ' Línea que está imprimiéndose
   Private LineaTexto As Byte

   ' Texto del informe
   ' Texto del informe
   Private Texto() = {
    "Según el último sondeo efectuado por la pres-",
    "tigiosa  revista Mundo  Bits, Visual Basic es",
    "actualmente el  lenguaje de  programación más",
    "utilizado a nivel mundial, seguido de cerca -",
    "por C++.",
    "Más distantes quedan Java, Delphi y lenguajes",
    "minoritarios como FORTRAN o COBOL.",
    "Este estudio se ha centrado en  los lenguajes",
    "considerados de 'propósito general', aquellos",
    "que pueden utilizarse  para desarrollar tanto",
    "aplicaciones clásicas, basadas en  interfaces",
    "de usuario  gráficas con conexión a  bases de",
    "datos, como componentes  discretos, programas",
    "de servidor web y librerías conteniendo códi-",
    "go  precompilado listo para  reutilizar,  por",
    "ejemplo en forma de controles  ActiveX o com-",
    "ponentes JavaBeans.",
     "Según el último sondeo efectuado por la pres-",
    "tigiosa  revista Mundo  Bits, Visual Basic es",
    "actualmente el  lenguaje de  programación más",
    "utilizado a nivel mundial, seguido de cerca -",
    "por C++.",
    "Más distantes quedan Java, Delphi y lenguajes",
    "minoritarios como FORTRAN o COBOL.",
    "Este estudio se ha centrado en  los lenguajes",
    "considerados de 'propósito general', aquellos",
    "que pueden utilizarse  para desarrollar tanto",
    "aplicaciones clásicas, basadas en  interfaces",
    "de usuario  gráficas con conexión a  bases de",
    "datos, como componentes  discretos, programas",
    "de servidor web y librerías conteniendo códi-",
    "go  precompilado listo para  reutilizar,  por",
    "ejemplo en forma de controles  ActiveX o com-",
    "ponentes JavaBeans.",
    "Según el último sondeo efectuado por la pres-",
    "tigiosa  revista Mundo  Bits, Visual Basic es",
    "actualmente el  lenguaje de  programación más",
    "utilizado a nivel mundial, seguido de cerca -",
    "por C++.",
    "Más distantes quedan Java, Delphi y lenguajes",
    "minoritarios como FORTRAN o COBOL.",
    "Este estudio se ha centrado en  los lenguajes",
    "considerados de 'propósito general', aquellos",
    "que pueden utilizarse  para desarrollar tanto",
    "aplicaciones clásicas, basadas en  interfaces",
    "de usuario  gráficas con conexión a  bases de",
    "datos, como componentes  discretos, programas",
    "de servidor web y librerías conteniendo códi-",
    "go  precompilado listo para  reutilizar,  por",
    "ejemplo en forma de controles  ActiveX o com-",
     "ponentes JavaBeans."
   }

   Private PosY As Integer

   Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

      ' Tipos de letra a usar para los distintos
      ' elementos que van a imprimirse
      Dim TipoTexto =
        New Font("Courier New", 14, FontStyle.Regular)
      Dim TipoTitulo = New  _
        Font("Arial", 24, FontStyle.Bold)
      Dim TipoTitulosDatos = New  _
        Font("Courier New", 12, _
            FontStyle.Underline Or FontStyle.Bold)
      Dim TipoDatos = New  _
        Font("Courier New", 10, FontStyle.Italic)

      ' Brocha y lápiz para los dibujos
      Dim Brocha As Brush
      Dim Lapiz = New Pen(Color.Black, 3)

      If LineaTexto = 0 Then ' Si es la primera línea
         ' tomamos la posición de la primera línea
         PosY = e.MarginBounds.Y
         ' y dibujamos el título del informe
         Dim Tamano =
           e.Graphics.MeasureString(Titulo, TipoTitulo)
         ' centrándolo en la parte superior de la 
         ' página
         e.Graphics.DrawString(Titulo, TipoTitulo,
           Brushes.Black, (e.PageBounds.Width -
           Tamano.Width) / 2, PosY)

         ' Actualizamos la posición vertical
         PosY += Tamano.Height * 2
      End If

      Dim Indice As Byte ' para los bucles
      ' Alto de una línea de texto normal
      Dim AltoLinea =
                    TipoTexto.GetHeight(e.Graphics)

      ' Recorremos todas las líneas de texto
      For Indice = LineaTexto To Texto.GetUpperBound(0)
         ' imprimiéndolas en la posición adecuada
         e.Graphics.DrawString(Texto(Indice), TipoTexto,
               Brushes.Black, e.MarginBounds.Left, PosY)
         ' Actualizamos la posición vertical
         PosY += AltoLinea

         ' Si estamos al final de la página
         If PosY + AltoLinea >= e.MarginBounds.Bottom Then
            ' recordamos la línea en la que estamos
            LineaTexto = Indice
            ' retomamos la posición vertical
            PosY = e.MarginBounds.Top
            ' e indicamos que hay más páginas
            e.HasMorePages = True
            Exit Sub ' abandonando el método
         End If
      Next

      ' Al llegar aquí ya hemos terminado de
      ' imprimir el texto del informe
      LineaTexto = Texto.GetUpperBound(0) + 1
      ' y actualizamos la posición vertical
      PosY += AltoLinea * 2

      ' Comprobamos si queda espacio para los datos
      If PosY + TipoTitulosDatos.GetHeight(e.Graphics) *
            2 > e.MarginBounds.Bottom Then
         ' Si no es así retomamos la posición
         PosY = e.MarginBounds.Top
         ' indicamos que hay más páginas
         e.HasMorePages = True
         Exit Sub ' y salimos
      End If

      ' Vamos a imprimir los títulos y datos

      ' Tomamos la posición horizontal inicial
      Dim PosX As Integer = e.MarginBounds.Left
      ' y calculamos el alto de una línea
      AltoLinea = TipoTitulosDatos.GetHeight(e.Graphics)

      ' Recorremos los títulos a imprimir
      For Indice = 0 To Titulos.GetUpperBound(0)
         ' imprimimos el título
         e.Graphics.DrawString(Titulos(Indice),
          TipoTitulosDatos, Brushes.Black, PosX, PosY)
         ' y debajo el porcentaje
         e.Graphics.DrawString(Datos(Indice),
           TipoDatos, Brushes.Black, PosX,
           PosY + AltoLinea)

         ' preparamos una brocha de relleno
         Brocha = New HatchBrush(Relleno(Indice),
            Color.Black, Color.White)
         ' para dibujar un rectángulo debajo de
         ' cada título
         e.Graphics.FillRectangle(Brocha, PosX,
            PosY + AltoLinea * 2, 20, 20)
         ' Actualizamos la posición horizontal
         PosX += e.Graphics.MeasureString(
           Titulos(Indice), TipoTitulosDatos).Width + 10
      Next

      ' Vamos a dibujar el gráfico sectorial

      ' Obtenemos la posición de origen
      PosY += AltoLinea * 2 + 30
      PosX = e.MarginBounds.Left
      ' y las dimensiones del gráfico
      Dim Alto As Single = e.MarginBounds.Height - PosY
      Dim Ancho As Single = e.MarginBounds.Width

      ' Forzamos que el gráfico sea circular
      If Alto > Ancho Then Alto = Ancho
      If Ancho > Alto Then Ancho = Alto

      ' Recorremos los datos a dibujar
      For Indice = 0 To Datos.GetUpperBound(0)
         ' preparamos una brocha de relleno
         Brocha = New HatchBrush(Relleno(Indice),
           Color.Black, Color.White)

         ' rellenamos el sector
         e.Graphics.FillPie(Brocha, PosX, PosY,
           Ancho, Alto, Puntos(Indice, 0),
           Puntos(Indice, 1))
         ' y dibujamos el contorno
         e.Graphics.DrawPie(Lapiz, PosX, PosY,
           Ancho, Alto, Puntos(Indice, 0),
           Puntos(Indice, 1))
      Next



   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      PrintPreviewDialog1.ShowDialog()
   End Sub

   Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ' Recorremos la lista de impresoras instaladas
      For Each Impresora In Printing.PrinterSettings.InstalledPrinters
         ' añadiéndolas a la lista
         ListBox1.Items.Add(Impresora)
      Next
      ' mostrar el nombre de la impresora
      tbNombreImpresora.Text = PrintDocument1.PrinterSettings.PrinterName

   End Sub

   Private Sub Button3_Click(sender As Object, e As EventArgs)

   End Sub

   Private Sub Button2_Click(sender As Object, e As EventArgs)
      ' Mostramos el cuadro de diálogo y si se pulsa
      ' el botón OK
      If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         ' actualizamos el nombre de la impresora
         tbNombreImpresora.Text =
           PrintDocument1.PrinterSettings.PrinterName
      End If

   End Sub

   Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
      PageSetupDialog1.ShowDialog()
   End Sub
End Class
