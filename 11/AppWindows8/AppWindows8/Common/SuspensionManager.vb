Namespace Common

    ''' <summary>
    ''' SuspensionManager captura el estado de sesión global para simplificar la administración de la duración de los procesos
    ''' de una aplicación. Tenga en cuenta que el estado de la sesión se borrará automáticamente bajo diversas
    ''' condiciones y solamente debería usarse para almacenar información que sería conveniente
    ''' para el tema, pero se debe descartar cuando la aplicación se bloquea o se
    ''' actualiza.
    ''' </summary>
    Friend NotInheritable Class SuspensionManager

        Private Shared _sessionState As New Dictionary(Of String, Object)()
        Private Shared _knownTypes As New List(Of Type)()
        Private Const sessionStateFilename As String  = "_sessionState.xml"

        ''' <summary>
        ''' Proporciona acceso al estado de sesión global para la sesión actual. Este estado
        ''' se serializa mediante <see cref="SaveAsync"/> y se restaura con
        ''' <see cref="RestoreAsync"/>, por lo que los valores deben poder serializarse mediante
        ''' <see cref="Runtime.Serialization.DataContractSerializer"/> y ser tan compactos como sea
        ''' posible. Se recomienda el uso de cadenas y otros tipos de datos independientes.
        ''' </summary>
        Public Shared ReadOnly Property SessionState As Dictionary(Of String, Object)
            Get
                Return _sessionState
            End Get
        End Property

        ''' <summary>
        ''' Lista de tipos personalizados proporcionados a <see cref="Runtime.Serialization.DataContractSerializer"/>
        ''' al leer y escribir el estado de la sesión. Pueden agregarse tipos adicionales, inicialmente
        ''' vacíos, para personalizar el proceso de serialización.
        ''' </summary>
        Public Shared ReadOnly Property KnownTypes As List(Of Type)
            Get
                Return _knownTypes
            End Get
        End Property

        ''' <summary>
        ''' Guardar el <see cref="SessionState"/> actual. Toda instancia de <see cref="Frame"/>
        ''' registrada en <see cref="RegisterFrame"/> también conservará la
        ''' pila de navegación actual que, a su vez, ofrece a la <see cref="Page"/> activa la oportunidad
        ''' de guardar su estado.
        ''' </summary>
        ''' <returns>Tarea asincrónica que refleja cuándo se ha guardado el estado de la sesión.</returns>
        Public Shared Async Function SaveAsync() As Task
            Try

                ' Guardar el estado de navegación para todos los marcos registrados
                For Each weakFrameReference As WeakReference(Of Frame) In _registeredFrames
                    Dim frame As Frame = Nothing
                    If weakFrameReference.TryGetTarget(frame) Then
                        SaveFrameNavigationState(frame)
                    End If
                Next

                ' Serializar el estado de la sesión de forma sincrónica para impedir el acceso asincrónico al estado
                ' compartido
                Dim sessionData As New MemoryStream()
                Dim serializer As New Runtime.Serialization.DataContractSerializer(GetType(Dictionary(Of String, Object)), _knownTypes)
                serializer.WriteObject(sessionData, _sessionState)

                ' Obtener un flujo de salida para el archivo SessionState y escribir el estado de forma asincrónica
                Dim file As Windows.Storage.StorageFile = Await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(
                    sessionStateFilename, Windows.Storage.CreationCollisionOption.ReplaceExisting)
                Using fileStream As Stream = Await file.OpenStreamForWriteAsync()
                    sessionData.Seek(0, SeekOrigin.Begin)
                    Await sessionData.CopyToAsync(fileStream)
                    Await fileStream.FlushAsync()
                End Using
            Catch ex As Exception
                Throw New SuspensionManagerException(ex)
            End Try
        End Function

        ''' <summary>
        ''' Restaura el <see cref="SessionState"/> previamente guardado. Toda instancia de <see cref="Frame"/>
        ''' registrada en <see cref="RegisterFrame"/> también restaurará su estado de navegación
        ''' anterior lo que, a su vez, ofrece a su <see cref="Page"/> activa la oportunidad de restaurar su
        ''' estado.
        ''' </summary>
        ''' <returns>Tarea asincrónica que refleja cuándo se ha leído el estado de la sesión. No hay
        ''' que confiar en el contenido de <see cref="SessionState"/>hasta que no se complete
        ''' esta tarea.</returns>
        Public Shared Async Function RestoreAsync() As Task
            _sessionState = New Dictionary(Of String, Object)()

            Try

                ' Obtener el flujo de entrada para el archivo SessionState
                Dim file As Windows.Storage.StorageFile = Await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(sessionStateFilename)
                If file Is Nothing Then Return

                Using inStream As Windows.Storage.Streams.IInputStream = Await file.OpenSequentialReadAsync()

                    ' Deserializar el estado de sesión
                    Dim serializer As New Runtime.Serialization.DataContractSerializer(GetType(Dictionary(Of String, Object)), _knownTypes)
                    _sessionState = DirectCast(serializer.ReadObject(inStream.AsStreamForRead()), Dictionary(Of String, Object))
                End Using

                ' Restaurar los marcos registrados a su estado guardado
                For Each weakFrameReference As WeakReference(Of Frame) In _registeredFrames
                    Dim frame As Frame = Nothing
                    If weakFrameReference.TryGetTarget(frame) Then
                        frame.ClearValue(FrameSessionStateProperty)
                        RestoreFrameNavigationState(frame)
                    End If
                Next
            Catch ex As Exception
                Throw New SuspensionManagerException(ex)
            End Try
        End Function

        Private Shared FrameSessionStateKeyProperty As DependencyProperty =
            DependencyProperty.RegisterAttached("_FrameSessionStateKey", GetType(String), GetType(SuspensionManager), Nothing)
        Private Shared FrameSessionStateProperty As DependencyProperty =
            DependencyProperty.RegisterAttached("_FrameSessionState", GetType(Dictionary(Of String, Object)), GetType(SuspensionManager), Nothing)
        Private Shared _registeredFrames As New List(Of WeakReference(Of Frame))()

        ''' <summary>
        ''' Registra una instancia de <see cref="Frame"/> para permitir que su historial de navegación se guarde
        ''' y restaure desde <see cref="SessionState"/>. Los marcos deben registrarse una vez
        ''' inmediatamente tras su creación si van a participar en la administración del estado de sesión. Tras el
        ''' registro, si el estado ya se ha restaurado para la clave especificada,
        ''' se restaurará inmediatamente el historial de navegación. Las invocaciones subsiguientes de
        ''' <see cref="RestoreAsync"/> también restaurarán el historial de navegación.
        ''' </summary>
        ''' <param name="frame">Instancia cuyo historial de navegación debería administrarse mediante
        ''' <see cref="SuspensionManager"/></param>
        ''' <param name="sessionStateKey">Clave única de <see cref="SessionState"/> que se usa para
        ''' almacenar información relacionada con la navegación.</param>
        Public Shared Sub RegisterFrame(frame As Frame, sessionStateKey As String)
            If frame.GetValue(FrameSessionStateKeyProperty) IsNot Nothing Then
                Throw New InvalidOperationException("Frames can only be registered to one session state key")
            End If

            If frame.GetValue(FrameSessionStateProperty) IsNot Nothing Then
                Throw New InvalidOperationException("Frames must be either be registered before accessing frame session state, or not registered at all")
            End If

            ' Usar una propiedad de dependencia para asociar la clave de sesión a un marco y mantener una lista de marcos cuyo
            ' estado de navegación deba administrarse
            frame.SetValue(FrameSessionStateKeyProperty, sessionStateKey)
            _registeredFrames.Add(New WeakReference(Of Frame)(frame))

            ' Comprobar si el estado de navegación puede restaurarse
            RestoreFrameNavigationState(frame)
        End Sub

        ''' <summary>
        ''' Desasocia un <see cref="Frame"/> previamente registrado mediante <see cref="RegisterFrame"/>
        ''' de <see cref="SessionState"/>. Todo estado de navegación previamente capturado se
        ''' quitará.
        ''' </summary>
        ''' <param name="frame">Instancia cuyo historial de navegación debería dejar de ser
        ''' administrado.</param>
        Public Shared Sub UnregisterFrame(frame As Frame)

            ' Quitar estado de la sesión y quitar el marco de la lista de marcos cuyo estado
            ' de navegación se guardará (junto con cualquier referencia débil que haya dejado de estar accesible)
            SessionState.Remove(DirectCast(frame.GetValue(FrameSessionStateKeyProperty), String))
            _registeredFrames.RemoveAll(Function(weakFrameReference)
                                            Dim testFrame As Frame = Nothing
                                            Return Not weakFrameReference.TryGetTarget(testFrame) OrElse testFrame Is frame
                                        End Function)
        End Sub

        ''' <summary>
        ''' Proporciona almacenamiento para el estado de sesión asociado al <see cref="Frame"/> especificado.
        ''' El estado de sesión de los marcos registrados previamente en <see cref="RegisterFrame"/>
        ''' se guardó y restauró automáticamente como parte del
        ''' <see cref="SessionState"/> global. Los marcos no registrados tienen un estado transitorio
        ''' que puede ser útil al restaurar páginas descartadas de la
        ''' memoria caché de navegación.
        ''' </summary>
        ''' <remarks>Las aplicaciones pueden elegir basarse en <see cref="LayoutAwarePage"/> para administrar
        ''' el estado específico de página en lugar de trabajar directamente con el estado de sesión del marco.</remarks>
        ''' <param name="frame">Instancia para la que se desea obtener el estado de sesión.</param>
        ''' <returns>Colección de estados sujeta al mismo mecanismo de serialización que
        ''' <see cref="SessionState"/>.</returns>
        Public Shared Function SessionStateForFrame(frame As Frame) As Dictionary(Of String, Object)
            Dim frameState As Dictionary(Of String, Object) = DirectCast(frame.GetValue(FrameSessionStateProperty), Dictionary(Of String, Object))

            If frameState Is Nothing Then
                Dim frameSessionKey As String = DirectCast(frame.GetValue(FrameSessionStateKeyProperty), String)
                If frameSessionKey IsNot Nothing Then
                    If Not _sessionState.ContainsKey(frameSessionKey) Then

                        ' Los marcos registrados reflejan el estado de sesión correspondiente
                        _sessionState(frameSessionKey) = New Dictionary(Of String, Object)()
                    End If
                    frameState = DirectCast(_sessionState(frameSessionKey), Dictionary(Of String, Object))
                Else

                    ' Los marcos no registrados tienen un estado transitorio
                    frameState = New Dictionary(Of String, Object)()
                End If
                frame.SetValue(FrameSessionStateProperty, frameState)
            End If
            Return frameState
        End Function

        Private Shared Sub RestoreFrameNavigationState(frame As Frame)
            Dim frameState As Dictionary(Of String, Object) = SessionStateForFrame(frame)
            If frameState.ContainsKey("Navigation") Then
                frame.SetNavigationState(DirectCast(frameState("Navigation"), String))
            End If
        End Sub

        Private Shared Sub SaveFrameNavigationState(frame As Frame)
            Dim frameState As Dictionary(Of String, Object) = SessionStateForFrame(frame)
            frameState("Navigation") = frame.GetNavigationState()
        End Sub

    End Class
    Public Class SuspensionManagerException
        Inherits Exception
        Public Sub New()
        End Sub

        Public Sub New(ByRef e As Exception)
            MyBase.New("SuspensionManager failed", e)
        End Sub
    End Class
End Namespace
