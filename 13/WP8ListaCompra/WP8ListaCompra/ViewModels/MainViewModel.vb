Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization

Public Class MainViewModel
    Implements INotifyPropertyChanged

    Public Sub New()
      Me.Items = New ObservableCollection(Of ItemViewModel)()

    End Sub

    ''' <summary>
    ''' Colección para objetos ItemViewModel.
    ''' </summary>
   Public Property Items() As ObservableCollection(Of ItemViewModel)

   Public ReadOnly Property FilteredItems() As ObservableCollection(Of ItemViewModel)
      Get
         Return New ObservableCollection(Of ItemViewModel)((
                From item In Me.Items
                Order By item.LineOne
                Where item.Comprado = False).ToList())
      End Get
   End Property

    Private _sampleProperty As String = "Sample Runtime Property Value"
    ''' <summary>
    ''' Propiedad Sample ViewModel; esta propiedad se usa en la vista para mostrar su valor mediante un enlace
    ''' </summary>
    ''' <returns></returns>
    Public Property SampleProperty() As String
        Get
            Return _sampleProperty
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_sampleProperty) Then
                _sampleProperty = value
                NotifyPropertyChanged("SampleProperty")
            End If
        End Set
    End Property

    ''' <summary>
    ''' Propiedad de ejemplo que devuelve una cadena traducida
    ''' </summary>
    Public ReadOnly Property LocalizedSampleProperty() As String
        Get
            Return AppResources.SampleProperty
        End Get
    End Property

    Public Property IsDataLoaded() As Boolean

    ''' <summary>
    ''' Crear y agregar unos pocos objetos ItemViewModel a la colección Items.
    ''' </summary>
    Public Sub LoadData()
      ' Datos de ejemplo; reemplazar por los datos reales
      Try
         Dim archivo = IsolatedStorageFile.GetUserStoreForApplication.OpenFile("ListaCompra.xml", IO.FileMode.Open)
         Dim serializador = New XmlSerializer(GetType(ObservableCollection(Of ItemViewModel)))
         Me.Items = serializador.Deserialize(archivo)
      Catch e As Exception
      End Try
      Me.IsDataLoaded = True
   End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
        If Nothing IsNot handler Then
            handler(Me, New PropertyChangedEventArgs(propertyName))
        End If
    End Sub
End Class