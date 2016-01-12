' La plantilla Aplicación vacía está documentada en http://go.microsoft.com/fwlink/?LinkId=234227

''' <summary>
''' Proporciona un comportamiento específico de la aplicación para complementar la clase Application predeterminada.
''' </summary>
NotInheritable Class App
    Inherits Application

    ''' <summary>
    ''' Se invoca cuando la aplicación la inicia normalmente el usuario final. Se usarán otros puntos
    ''' de entrada cuando la aplicación se inicie para abrir un archivo específico, para mostrar
    ''' resultados de la búsqueda, etc.
    ''' </summary>
    ''' <param name="args">Información detallada acerca de la solicitud y el proceso de inicio.</param>
    Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
        Dim rootFrame As Frame = Window.Current.Content

        ' No repetir la inicialización de la aplicación si la ventana tiene contenido todavía,
        ' solo asegurarse de que la ventana está activa.

        If rootFrame Is Nothing Then
            ' Crear un marco para que actúe como contexto de navegación y navegar a la primera página.
            rootFrame = New Frame()
            If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                ' TODO: Cargar el estado de la aplicación suspendida previamente
            End If
            ' Poner el marco en la ventana actual.
            Window.Current.Content = rootFrame
        End If
        If rootFrame.Content Is Nothing Then
            ' Cuando no se restaura la pila de navegación para navegar a la primera página,
            ' configurar la nueva página al pasar la información requerida como parámetro
            ' parámetro
            If Not rootFrame.Navigate(GetType(MainPage), args.Arguments) Then
                Throw New Exception("Failed to create initial page")
            End If
        End If

        ' Asegurarse de que la ventana actual está activa.
        Window.Current.Activate()
   End Sub

   Private Sub App_Resuming(sender As Object, e As Object) Handles Me.Resuming

   End Sub

    ''' <summary>
    ''' Se invoca al suspender la ejecución de la aplicación. El estado de la aplicación se guarda
    ''' sin saber si la aplicación se terminará o se reanudará con el contenido
    ''' de la memoria aún intacto.
    ''' </summary>
    ''' <param name="sender">Origen de la solicitud de suspensión.</param>
    ''' <param name="e">Detalles sobre la solicitud de suspensión.</param>
    Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
        Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
        ' TODO: Guardar el estado de la aplicación y detener toda actividad en segundo plano
      deferral.Complete()

    End Sub

End Class
