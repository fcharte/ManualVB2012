Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports System.Windows.Data

Partial Public Class MainPage
   Inherits PhoneApplicationPage

   ' Constructor
   Public Sub New()
      InitializeComponent()

      ' Establecer el contexto de datos del control ListBox control en los datos de ejemplo
      DataContext = App.ViewModel

      ' Código de ejemplo para traducir ApplicationBar
      'BuildLocalizedApplicationBar()
   End Sub

   ' Cargar datos para los elementos ViewModel
   Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
      If Not App.ViewModel.IsDataLoaded Then
         App.ViewModel.LoadData()
      End If
   End Sub

   Private Sub ActualizaLista()
      'ListaTodas.ItemsSource.Clear()
      'ListaPendientes.ItemsSource.Clear()

   End Sub

   ' Código de ejemplo para compilar una ApplicationBar traducida
   'Private Sub BuildLocalizedApplicationBar()
   '    ' Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
   '    ApplicationBar = New ApplicationBar()

   '    ' Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
   '    Dim appBarButton As New ApplicationBarIconButton(New Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative))
   '    appBarButton.Text = AppResources.AppBarButtonText
   '    ApplicationBar.Buttons.Add(appBarButton)

   '    ' Crear un nuevo elemento de menú con la cadena traducida de AppResources.
   '    Dim appBarMenuItem As New ApplicationBarMenuItem(AppResources.AppBarMenuItemText)
   '    ApplicationBar.MenuItems.Add(appBarMenuItem)
   'End Sub

   Private Sub PhoneApplicationPage_Loaded_1(sender As Object, e As RoutedEventArgs)
      ActualizaLista()
   End Sub

   Private Sub PhoneApplicationPage_OrientationChanged_1(sender As Object, e As OrientationChangedEventArgs)

   End Sub

   Private Sub ApplicationBarIconButton_Click_1(sender As Object, e As EventArgs)
      NavigationService.Navigate(New Uri("/Nuevo.xaml", UriKind.Relative))
   End Sub

   Private Sub CheckBox_Click(sender As Object, e As RoutedEventArgs)
      With CType(sender, CheckBox)

         CType(.DataContext, ItemViewModel).Comprado = .IsChecked

         ListaPendientes.ItemsSource.Clear()
         ListaPendientes.ItemsSource = App.ViewModel.FilteredItems

      End With

   End Sub

   Private Sub ApplicationBarIconButton_Click_2(sender As Object, e As EventArgs)
      App.ViewModel.Items.Clear()
   End Sub
End Class