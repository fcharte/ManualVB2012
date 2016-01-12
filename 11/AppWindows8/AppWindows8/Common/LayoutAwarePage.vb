Namespace Common

    ''' <summary>
    ''' Implementación típica de Page que proporciona varias facilidades importantes:
    ''' <list type="bullet">
    ''' <item>
    ''' <description>Asignación del estado de vista de la aplicación a un estado visual</description>
    ''' </item>
    ''' <item>
    ''' <description>Controladores de eventos GoBack, GoForward y GoHome event</description>
    ''' </item>
    ''' <item>
    ''' <description>Accesos directos de mouse y teclado para la navegación</description>
    ''' </item>
    ''' <item>
    ''' <description>Administración del estado para la administración de la navegación y la duración de los procesos</description>
    ''' </item>
    ''' <item>
    ''' <description>Modelo de vista predeterminada</description>
    ''' </item>
    ''' </list>
    ''' </summary>
    <Windows.Foundation.Metadata.WebHostHidden>
    Public Class LayoutAwarePage
        Inherits Page

        ''' <summary>
        ''' Identifica la propiedad de dependencia <see cref="DefaultViewModel"/>.
        ''' </summary>
        Public Shared ReadOnly DefaultViewModelProperty As DependencyProperty =
            DependencyProperty.Register("DefaultViewModel", GetType(IObservableMap(Of String, Object)),
            GetType(LayoutAwarePage), Nothing)

        Private _layoutAwareControls As List(Of Control)

        ''' <summary>
        ''' Cuando esta página forma parte del árbol visual, realizar dos cambios:
        ''' 1) Asignar el estado de vista de la aplicación a un estado visual para la página
        ''' 2) Controlar las solicitudes de navegación con el teclado y el mouse
        ''' </summary>
        ''' <param name="sender">Objeto que inició la solicitud.</param>
        ''' <param name="e">Datos de evento que describen cómo se realizó la solicitud.</param>
        Private Sub OnLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            Me.StartLayoutUpdates(sender, e)

            ' La navegación con el teclado y el mouse se aplica únicamente cuando se ocupa toda la ventana
            If Me.ActualHeight = Window.Current.Bounds.Height AndAlso
                    Me.ActualWidth = Window.Current.Bounds.Width Then

                ' Escuchar a la ventana directamente de forma que el foco no es necesario
                AddHandler Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated,
                    AddressOf Me.CoreDispatcher_AcceleratorKeyActivated
                AddHandler Window.Current.CoreWindow.PointerPressed,
                    AddressOf Me.CoreWindow_PointerPressed
            End If
        End Sub

        ''' <summary>
        ''' Deshacer los cambios realizados en <see cref="OnLoaded"/> cuando la página deje de estar visible.
        ''' </summary>
        ''' <param name="sender">Objeto que inició la solicitud.</param>
        ''' <param name="e">Datos de evento que describen cómo se realizó la solicitud.</param>
        Private Sub OnUnloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
            Me.StopLayoutUpdates(sender, e)
            RemoveHandler Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated,
                AddressOf Me.CoreDispatcher_AcceleratorKeyActivated
            RemoveHandler Window.Current.CoreWindow.PointerPressed,
                AddressOf Me.CoreWindow_PointerPressed
        End Sub

        ''' <summary>
        ''' Inicializa una nueva instancia de la clase <see cref="LayoutAwarePage"/>.
        ''' </summary>
        Public Sub New()
            If Windows.ApplicationModel.DesignMode.DesignModeEnabled Then Return

            ' Crea un modelo de vista predeterminada vacía
            Me.DefaultViewModel = New ObservableDictionary(Of String, Object)
        End Sub

        ''' <summary>
        ''' Implementación de <see cref="IObservableMap(Of String, Object)"/> diseñada para
        ''' usarla como modelo de vista trivial.
        ''' </summary>
        Protected Property DefaultViewModel As IObservableMap(Of String, Object)
            Get
                Return DirectCast(Me.GetValue(DefaultViewModelProperty), IObservableMap(Of String, Object))
            End Get
            Set(value As IObservableMap(Of String, Object))
                Me.SetValue(DefaultViewModelProperty, value)
            End Set
        End Property

#Region "Admitir navegación"

        ''' <summary>
        ''' Se invoca como controlador de eventos para navegar hacia atrás en el
        ''' <see cref="Frame"/> asociado de la página hasta alcanzar el principio de la pila de navegación.
        ''' </summary>
        ''' <param name="sender">Instancia que desencadena el evento.</param>
        ''' <param name="e">Datos de evento que describen las condiciones que dan lugar al evento.</param>
        Protected Overridable Sub GoHome(sender As Object, e As RoutedEventArgs)

            ' Usar el entorno de exploración para volver a la página superior
            If Me.Frame IsNot Nothing Then
                While Me.Frame.CanGoBack
                    Me.Frame.GoBack()
                End While
            End If
        End Sub

        ''' <summary>
        ''' Se invoca como controlador de eventos para navegar hacia atrás en la pila de navegación
        ''' asociada con el <see cref="Frame"/> de esta página.
        ''' </summary>
        ''' <param name="sender">Instancia que desencadena el evento.</param>
        ''' <param name="e">Datos de evento que describen las condiciones que dan lugar al evento.</param>
        Protected Overridable Sub GoBack(sender As Object, e As RoutedEventArgs)

            ' Usar el entorno de exploración para volver a la página anterior
            If Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoBack Then
                Me.Frame.GoBack()
            End If
        End Sub

        ''' <summary>
        ''' Se invoca como controlador de eventos para navegar hacia delante en la pila de navegación
        ''' asociada con el <see cref="Frame"/> de esta página.
        ''' </summary>
        ''' <param name="sender">Instancia que desencadena el evento.</param>
        ''' <param name="e">Datos de evento que describen las condiciones que dan lugar al evento.</param>
        Protected Overridable Sub GoForward(sender As Object, e As RoutedEventArgs)

            ' Usar el marco de navegación para avanzar a la siguiente página
            If Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoForward Then
                Me.Frame.GoForward()
            End If
        End Sub

        ''' <summary>
        ''' Se invoca en cada pulsación de tecla, incluidas las teclas del sistema como las combinaciones con la tecla Alt, cuando
        ''' esta página está activa y ocupa toda la ventana. Se usa para detectar la navegación con el teclado
        ''' entre páginas incluso cuando la página no tiene el foco.
        ''' </summary>
        ''' <param name="sender">Instancia que desencadena el evento.</param>
        ''' <param name="args">Datos de evento que describen las condiciones que dan lugar al evento.</param>
        Private Sub CoreDispatcher_AcceleratorKeyActivated(sender As Windows.UI.Core.CoreDispatcher,
                                                           args As Windows.UI.Core.AcceleratorKeyEventArgs)
            Dim virtualKey As Windows.System.VirtualKey = args.VirtualKey

            ' Investigar más solo cuando se presionan las teclas Izquierda, Derecha o las teclas
            ' dedicadas Repág o Avpág
            If (args.EventType = Windows.UI.Core.CoreAcceleratorKeyEventType.SystemKeyDown OrElse
                args.EventType = Windows.UI.Core.CoreAcceleratorKeyEventType.KeyDown) AndAlso
                (virtualKey = Windows.System.VirtualKey.Left OrElse
                virtualKey = Windows.System.VirtualKey.Right OrElse
                virtualKey = 166 OrElse
                virtualKey = 167) Then

                ' Determinar las teclas modificadoras presionadas
                Dim coreWindow As Windows.UI.Core.CoreWindow = Window.Current.CoreWindow
                Dim downState As Windows.UI.Core.CoreVirtualKeyStates = Windows.UI.Core.CoreVirtualKeyStates.Down
                Dim menuKey As Boolean = (coreWindow.GetKeyState(Windows.System.VirtualKey.Menu) And downState) = downState
                Dim controlKey As Boolean = (coreWindow.GetKeyState(Windows.System.VirtualKey.Control) And downState) = downState
                Dim shiftKey As Boolean = (coreWindow.GetKeyState(Windows.System.VirtualKey.Shift) And downState) = downState
                Dim noModifiers As Boolean = Not menuKey AndAlso Not controlKey AndAlso Not shiftKey
                Dim onlyAlt As Boolean = menuKey AndAlso Not controlKey AndAlso Not shiftKey

                If (virtualKey = 166 AndAlso noModifiers) OrElse
                    (virtualKey = Windows.System.VirtualKey.Left AndAlso onlyAlt) Then

                    ' Cuando se presionan las teclas Repág o Alt+Izquierda, navegar hacia atrás
                    args.Handled = True
                    Me.GoBack(Me, New RoutedEventArgs())
                ElseIf (virtualKey = 167 AndAlso noModifiers) OrElse
                    (virtualKey = Windows.System.VirtualKey.Right AndAlso onlyAlt) Then

                    ' Cuando se presionan las teclas Avpág o Alt+Derecha, navegar hacia delante
                    args.Handled = True
                    Me.GoForward(Me, New RoutedEventArgs())
                End If
            End If
        End Sub

        ''' <summary>
        ''' Se invoca en cada clic del mouse, punteo en la pantalla táctil o una interacción equivalente cuando esta
        ''' página está activa y ocupa toda la ventana. Se usa para detectar los clics de botón del mouse
        ''' siguiente y anterior del estilo del explorador para navegar entre páginas.
        ''' </summary>
        ''' <param name="sender">Instancia que desencadena el evento.</param>
        ''' <param name="args">Datos de evento que describen las condiciones que dan lugar al evento.</param>
        Private Sub CoreWindow_PointerPressed(sender As Windows.UI.Core.CoreWindow,
                                              args As Windows.UI.Core.PointerEventArgs)
            Dim properties As Windows.UI.Input.PointerPointProperties = args.CurrentPoint.Properties

            ' Omitir la presión simultánea de botones con los botones Izquierda, Derecha y Medio
            If properties.IsLeftButtonPressed OrElse properties.IsRightButtonPressed OrElse
                properties.IsMiddleButtonPressed Then Return

            ' Si se presiona Repág o Avpág (pero no ambos), navegar adecuadamente
            Dim backPressed As Boolean = properties.IsXButton1Pressed
            Dim forwardPressed As Boolean = properties.IsXButton2Pressed
            If backPressed Xor forwardPressed Then
                args.Handled = True
                If backPressed Then Me.GoBack(Me, New RoutedEventArgs())
                If forwardPressed Then Me.GoForward(Me, New RoutedEventArgs())
            End If
        End Sub

#End Region

#Region "Conmutación de estado visual"

        ''' <summary>
        ''' Se invoca como controlador de eventos, normalmente en el evento <see cref="Loaded"/> de un
        ''' <see cref="Control"/> dentro de la página, para indicar que el remitente debe comenzar a recibir
        ''' cambios de administración del estado visual que corresponden a los cambios de estado de vista de la aplicación.
        ''' </summary>
        ''' <param name="sender">Instancia de <see cref="Control"/> que admite administración
        ''' del estado visual correspondiente a estados de vista.</param>
        ''' <param name="e">Datos de evento que describen cómo se realizó la solicitud.</param>
        ''' <remarks>El estado de vista actual se usará inmediatamente para establecer el correspondiente
        ''' estado visual cuando se soliciten actualizaciones de diseño. Se recomienda encarecidamente
        ''' controlador de eventos <see cref="Unloaded"/> correspondiente conectado a <see cref="StopLayoutUpdates"/>.
        ''' Las instancias de <see cref="LayoutAwarePage"/> invocan automáticamente
        ''' a estos controladores en sus eventos Loaded y Unloaded.</remarks>
        ''' <seealso cref="DetermineVisualState"/>
        ''' <seealso cref="InvalidateVisualState"/>
        Public Sub StartLayoutUpdates(sender As Object, e As RoutedEventArgs)
            If Windows.ApplicationModel.DesignMode.DesignModeEnabled Then Return

            Dim control As Control = TryCast(sender, Control)
            If control Is Nothing Then Return

            If Me._layoutAwareControls Is Nothing Then

                ' Comenzar a escuchar cambios de estado de vista cuando hay controles interesados en
                ' actualizaciones
                AddHandler Window.Current.SizeChanged, AddressOf Me.WindowSizeChanged
                Me._layoutAwareControls = New List(Of Control)
            End If
            Me._layoutAwareControls.Add(control)

            ' Establecer el estado visual inicial del control
            VisualStateManager.GoToState(control, DetermineVisualState(ApplicationView.Value), False)
        End Sub

        Private Sub WindowSizeChanged(sender As Object, e As Windows.UI.Core.WindowSizeChangedEventArgs)
            Me.InvalidateVisualState()
        End Sub

        ''' <summary>
        ''' Se invoca como controlador de eventos, normalmente en el evento <see cref="Unloaded"/> de un
        ''' <see cref="Control"/>, para indicar que el remitente debe comenzar a recibir cambios de
        ''' administración del estado visual que corresponden a cambios de estado de vista de la aplicación.
        ''' </summary>
        ''' <param name="sender">Instancia de <see cref="Control"/> que admite administración
        ''' del estado visual correspondiente a estados de vista.</param>
        ''' <param name="e">Datos de evento que describen cómo se realizó la solicitud.</param>
        ''' <remarks>El estado de vista actual se usará inmediatamente para establecer el correspondiente
        ''' estado visual cuando se solicitan actualizaciones.</remarks>
        ''' <seealso cref="StartLayoutUpdates"/>
        Public Sub StopLayoutUpdates(sender As Object, e As RoutedEventArgs)
            If Windows.ApplicationModel.DesignMode.DesignModeEnabled Then Return

            Dim control As Control = TryCast(sender, Control)
            If control Is Nothing OrElse Me._layoutAwareControls Is Nothing Then Return

            Me._layoutAwareControls.Remove(control)
            If Me._layoutAwareControls.Count = 0 Then

                ' Dejar de escuchar cambios de estado de vista cuando no hay controles interesados en actualizaciones
                Me._layoutAwareControls = Nothing
                RemoveHandler Window.Current.SizeChanged, AddressOf Me.WindowSizeChanged
            End If
        End Sub

        ''' <summary>
        ''' Convierte valores <see cref="ApplicationViewState"/> en cadenas para la administración
        ''' del estado visual dentro de la página. La implementación predeterminada usa los nombres de valores enum.
        ''' Las subclases pueden invalidar este método para controlar la combinación de asignación usada.
        ''' </summary>
        ''' <param name="viewState">Ver el estado para el que se desea un estado visual.</param>
        ''' <returns>Nombre del estado visual usado para controlar el <see cref="VisualStateManager"/></returns>
        ''' <seealso cref="InvalidateVisualState"/>
        Protected Overridable Function DetermineVisualState(viewState As ApplicationViewState) As String
            Return viewState.ToString()
        End Function

        ''' <summary>
        ''' Actualiza todos los controles que escuchan cambios de estado visual con el
        ''' estado visual correcto.
        ''' </summary>
        ''' <remarks>
        ''' Se usa normalmente junto con la invalidación de <see cref="DetermineVisualState"/> para
        ''' indicar que se puede devolver un valor diferente incluso si el estado de vista
        ''' no ha cambiado.
        ''' </remarks>
        Public Sub InvalidateVisualState()
            If Me._layoutAwareControls IsNot Nothing Then
                Dim visualState As String = DetermineVisualState(ApplicationView.Value)
                For Each layoutAwareControl As Control In Me._layoutAwareControls
                    VisualStateManager.GoToState(layoutAwareControl, visualState, False)
                Next
            End If
        End Sub

#End Region

#Region "Administración de la duración de los procesos"

        Private _pageKey As String

        ''' <summary>
        ''' Se invoca cuando esta página se va a mostrar en un objeto Frame.
        ''' </summary>
        ''' <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        ''' proporciona el grupo que se va a mostrar.</param>
        Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

            ' La devolución a una página almacenada en caché mediante navegación no debe desencadenar una carga de estado
            If Me._pageKey IsNot Nothing Then Return

            Dim frameState As Dictionary(Of String, Object) = SuspensionManager.SessionStateForFrame(Me.Frame)
            Me._pageKey = "Page-" & Me.Frame.BackStackDepth

            If e.NavigationMode = Navigation.NavigationMode.New Then

                ' Borrar el estado existente para la navegación hacia delante cuando se agregue una nueva página a la
                ' pila de navegación
                Dim nextPageKey As String = Me._pageKey
                Dim nextPageIndex As Integer = Me.Frame.BackStackDepth
                While (frameState.Remove(nextPageKey))
                    nextPageIndex += 1
                    nextPageKey = "Page-" & nextPageIndex
                End While


                ' Pasar el parámetro de navegación a la nueva página
                Me.LoadState(e.Parameter, Nothing)
            Else

                ' Pasar el parámetro de navegación y el estado de página mantenido a la página usando
                ' la misma estrategia para cargar el estado suspendido y volver a crear las páginas descartadas
                ' a partir de la memoria caché
                Me.LoadState(e.Parameter, DirectCast(frameState(Me._pageKey), Dictionary(Of String, Object)))
            End If
        End Sub

        ''' <summary>
        ''' Se invoca cuando esta página deja de estar visible en un marco.
        ''' </summary>
        ''' <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        ''' proporciona el grupo que se va a mostrar.</param>
        Protected Overrides Sub OnNavigatedFrom(e As Navigation.NavigationEventArgs)
            Dim frameState As Dictionary(Of String, Object) = SuspensionManager.SessionStateForFrame(Me.Frame)
            Dim pageState As New Dictionary(Of String, Object)()
            Me.SaveState(pageState)
            frameState(_pageKey) = pageState
        End Sub

        ''' <summary>
        ''' Rellena la página con el contenido pasado durante la navegación. Cualquier estado guardado se
        ''' proporciona también al crear de nuevo una página a partir de una sesión anterior.
        ''' </summary>
        ''' <param name="navigationParameter">Valor de parámetro pasado a
        ''' <see cref="Frame.Navigate"/> cuando se solicitó inicialmente esta página.
        ''' </param>
        ''' <param name="pageState">Diccionario del estado mantenido por esta página durante una sesión
        ''' anterior. Será null la primera vez que se visite una página.</param>
        Protected Overridable Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))

        End Sub

        ''' <summary>
        ''' Mantiene el estado asociado con esta página en caso de que se suspenda la aplicación o
        ''' se descarte la página de la memoria caché de navegación. Los valores deben cumplir los requisitos
        ''' de serialización de <see cref="SuspensionManager.SessionState"/>.
        ''' </summary>
        ''' <param name="pageState">Diccionario vacío para rellenar con un estado serializable.</param>
        Protected Overridable Sub SaveState(pageState As Dictionary(Of String, Object))

        End Sub

#End Region

        ''' <summary>
        ''' Implementación de IObservableMap que admite reentrada para usarla como
        ''' modelo de vista predeterminada.
        ''' </summary>
        Private Class ObservableDictionary(Of K, V)
            Implements IObservableMap(Of K, V)

            Private Class ObservableDictionaryChangedEventArgs
                Implements IMapChangedEventArgs(Of K)

                Private _change As CollectionChange
                Private _key As K

                Public Sub New(change As CollectionChange, key As K)
                    Me._change = change
                    Me._key = key
                End Sub

                ReadOnly Property CollectionChange As CollectionChange Implements IMapChangedEventArgs(Of K).CollectionChange
                    Get
                        Return _change
                    End Get
                End Property

                ReadOnly Property Key As K Implements IMapChangedEventArgs(Of K).Key
                    Get
                        Return _key
                    End Get
                End Property

            End Class

            Public Event MapChanged(sender As IObservableMap(Of K, V), [event] As IMapChangedEventArgs(Of K)) Implements IObservableMap(Of K, V).MapChanged
            Private _dictionary As New Dictionary(Of K, V)()

            Private Sub InvokeMapChanged(change As CollectionChange, key As K)
                RaiseEvent MapChanged(Me, New ObservableDictionaryChangedEventArgs(change, key))
            End Sub

            Public Sub Add(key As K, value As V) Implements IDictionary(Of K, V).Add
                Me._dictionary.Add(key, value)
                Me.InvokeMapChanged(CollectionChange.ItemInserted, key)
            End Sub

            Public Sub AddKeyValuePair(item As KeyValuePair(Of K, V)) Implements ICollection(Of KeyValuePair(Of K, V)).Add
                Me.Add(item.Key, item.Value)
            End Sub

            Public Function Remove(key As K) As Boolean Implements IDictionary(Of K, V).Remove
                If Me._dictionary.Remove(key) Then
                    Me.InvokeMapChanged(CollectionChange.ItemRemoved, key)
                    Return True
                End If
                Return False
            End Function

            Public Function RemoveKeyValuePair(item As KeyValuePair(Of K, V)) As Boolean Implements ICollection(Of KeyValuePair(Of K, V)).Remove
                Dim currentValue As V
                If Me._dictionary.TryGetValue(item.Key, currentValue) AndAlso
                    Object.Equals(item.Value, currentValue) AndAlso Me._dictionary.Remove(item.Key) Then

                    Me.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key)
                    Return True
                End If
                Return False
            End Function

            Default Public Property Item(key As K) As V Implements IDictionary(Of K, V).Item
                Get
                    Return Me._dictionary(key)
                End Get
                Set(value As V)
                    Me._dictionary(key) = value
                    Me.InvokeMapChanged(CollectionChange.ItemChanged, key)
                End Set
            End Property

            Public Sub Clear() Implements ICollection(Of KeyValuePair(Of K, V)).Clear
                Dim priorKeys As K() = Me._dictionary.Keys.ToArray()
                Me._dictionary.Clear()
                For Each key As K In priorKeys
                    Me.InvokeMapChanged(CollectionChange.ItemRemoved, key)
                Next
            End Sub

            Public Function Contains(item As KeyValuePair(Of K, V)) As Boolean Implements ICollection(Of KeyValuePair(Of K, V)).Contains
                Return Me._dictionary.Contains(item)
            End Function

            Public ReadOnly Property Count As Integer Implements ICollection(Of KeyValuePair(Of K, V)).Count
                Get
                    Return Me._dictionary.Count
                End Get
            End Property

            Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of KeyValuePair(Of K, V)).IsReadOnly
                Get
                    Return False
                End Get
            End Property

            Public Function ContainsKey(key As K) As Boolean Implements IDictionary(Of K, V).ContainsKey
                Return Me._dictionary.ContainsKey(key)
            End Function

            Public ReadOnly Property Keys As ICollection(Of K) Implements IDictionary(Of K, V).Keys
                Get
                    Return Me._dictionary.Keys
                End Get
            End Property

            Public Function TryGetValue(key As K, ByRef value As V) As Boolean Implements IDictionary(Of K, V).TryGetValue
                Return Me._dictionary.TryGetValue(key, value)
            End Function

            Public ReadOnly Property Values As ICollection(Of V) Implements IDictionary(Of K, V).Values
                Get
                    Return Me._dictionary.Values
                End Get
            End Property

            Public Function GetGenericEnumerator() As IEnumerator(Of KeyValuePair(Of K, V)) Implements IEnumerable(Of KeyValuePair(Of K, V)).GetEnumerator
                Return Me._dictionary.GetEnumerator()
            End Function

            Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
                Return Me._dictionary.GetEnumerator()
            End Function

            Public Sub CopyTo(array() As KeyValuePair(Of K, V), arrayIndex As Integer) Implements ICollection(Of KeyValuePair(Of K, V)).CopyTo
                Dim arraySize As Integer = array.Length
                For Each pair As KeyValuePair(Of K, V) In Me._dictionary
                    If arrayIndex >= arraySize Then Exit For
                    array(arrayIndex) = pair
                    arrayIndex += 1
                Next
            End Sub

        End Class

    End Class

End Namespace
