Imports Windows.UI.Xaml.Shapes
Imports Microsoft.VisualBasic

' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class MainPage
   Inherits Page

   ''' <summary>
   ''' Se invoca cuando esta página se va a mostrar en un objeto Frame.
   ''' </summary>
   ''' <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
   ''' se usa normalmente para configurar la página.</param>
   Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

   End Sub

   Private SecuenciaOriginal, SecuenciaIntroducida As String
   Private Sonido(5) As MediaElement
   Private Record As Integer

   Private Sub ActualizaMarcador()
      If SecuenciaIntroducida IsNot Nothing Then
         If SecuenciaIntroducida.Length > Record Then
            Record = SecuenciaIntroducida.Length
         End If
         Marcador.Text = "Actual: " & SecuenciaIntroducida.Length & vbCrLf & "Record: " & Record
      End If
   End Sub

   Private Async Function GeneraSecuencia() As Task
      Dim Generador As New Random
      Dim Botones() As Ellipse = {Nothing, Btn1, Btn2, Btn3, Btn4}
      SecuenciaOriginal = SecuenciaOriginal & Generador.Next(1, 4)

      For Each Boton As Char In SecuenciaOriginal
         Dim Indice As Integer = AscW(Boton) - AscW("0")
         Botones(Indice).Opacity = 0.3
         Sonido(Indice).Play()
         Await Task.Delay(1000)
         Botones(Indice).Opacity = 1
         Await Task.Delay(250)
      Next
   End Function

   Private Async Function CompruebaSecuencia() As Task
      If SecuenciaOriginal.Substring(0, SecuenciaIntroducida.Length) = SecuenciaIntroducida Then
         ActualizaMarcador()  
         If SecuenciaIntroducida.Length = SecuenciaOriginal.Length Then
            SecuenciaIntroducida = ""
            Await Task.Delay(1000)
            Await GeneraSecuencia()
         End If
      Else
         Sonido(5).Play()
         Await Task.Delay(1000)
         SecuenciaOriginal = ""
         SecuenciaIntroducida = ""
         BtnComenzar.IsTapEnabled = True
         BtnComenzar.Opacity = 1.0
         ActualizaMarcador()
      End If
   End Function

   Private Async Sub Btn1_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles Btn1.Tapped, Btn2.Tapped, Btn3.Tapped, Btn4.Tapped
      With CType(sender, Ellipse)
         .Opacity = 0.3
         SecuenciaIntroducida = SecuenciaIntroducida & .Tag
         Sonido(.Tag).Play()
         Await Task.Delay(500)
         .Opacity = 1.0
      End With
      Await CompruebaSecuencia()
   End Sub

   Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
      Dim Carpeta = Await Package.Current.InstalledLocation.GetFolderAsync("Sonidos")
      For Indice = 1 To 5
         Dim Archivo = Await Carpeta.GetFileAsync("Simon" & Indice & ".wav")
         Sonido(Indice) = New MediaElement()
         With Sonido(Indice)
            .AutoPlay = False
            .AudioCategory = AudioCategory.GameEffects
            .SetSource(Await Archivo.OpenAsync(Windows.Storage.FileAccessMode.Read), Archivo.ContentType)
         End With
      Next
      BtnComenzar.IsTapEnabled = True
      BtnComenzar.Opacity = 1.0
      ActualizaMarcador()
   End Sub

   Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
      BtnComenzar.IsTapEnabled = False
      BtnComenzar.Opacity = 0
      GeneraSecuencia()
   End Sub
End Class
