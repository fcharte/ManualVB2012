Namespace Common

    ''' <summary>
    ''' Implementación de <see cref="INotifyPropertyChanged"/> para simplificar los modelos.
    ''' </summary>
    <Windows.Foundation.Metadata.WebHostHidden>
    Public MustInherit Class BindableBase
        Implements INotifyPropertyChanged

        ''' <summary>
        ''' Evento de multidifusión para notificaciones de cambio de propiedad.
        ''' </summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ''' <summary>
        ''' Comprueba si una propiedad coincide ya con el valor deseado. Establece la propiedad y notifica
        ''' a los agentes de escucha solo si es necesario.
        ''' </summary>
        ''' <typeparam name="T">Tipo de la propiedad.</typeparam>
        ''' <param name="storage">Referencia a una propiedad con captador y establecedor.</param>
        ''' <param name="value">Valor deseado para la propiedad.</param>
        ''' <param name="propertyName">Nombre de la propiedad usada para notificar a los agentes de escucha. Este valor
        ''' es opcional y se puede proporcionar automáticamente cuando se invoca desde compiladores que admiten
        ''' CallerMemberName.</param>
        ''' <returns>True si se cambió el valor, false si el valor existente coincidía con el
        ''' valor deseado.</returns>
        Protected Function SetProperty(Of T)(ByRef storage As T, value As T,
                                        <CallerMemberName> Optional propertyName As String = Nothing) As Boolean

            If Object.Equals(storage, value) Then Return False

            storage = value
            Me.OnPropertyChanged(propertyName)
            Return True
        End Function

        ''' <summary>
        ''' Notifica a los agentes de escucha que ha cambiado un valor de propiedad.
        ''' </summary>
        ''' <param name="propertyName">Nombre de la propiedad usada para notificar a los agentes de escucha. Este valor
        ''' es opcional y se puede proporcionar automáticamente cuando se invoca desde compiladores que admiten
        ''' <see cref="CallerMemberNameAttribute"/>.</param>
        Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

    End Class

End Namespace
