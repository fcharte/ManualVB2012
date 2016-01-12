Namespace Common

    ''' <summary>
    ''' Contenedor para <see cref="RichTextBlock"/> que crea tantas columnas de desbordamiento
    ''' adicionales como sea necesario para acomodar el contenido disponible.
    ''' </summary>
    ''' <example>
    ''' El siguiente código crea una colección de columnas de 400 píxeles de ancho y una separación de 50 píxeles
    ''' para acomodar contenido arbitrario enlazado a datos:
    ''' <code>
    ''' <RichTextColumns>
    '''     <RichTextColumns.ColumnTemplate>
    '''         <DataTemplate>
    '''             <RichTextBlockOverflow Width="400" Margin="50,0,0,0"/>
    '''         </DataTemplate>
    '''     </RichTextColumns.ColumnTemplate>
    '''     
    '''     <RichTextBlock Width="400">
    '''         <Paragraph>
    '''             <Run Text="{Binding Content}"/>
    '''         </Paragraph>
    '''     </RichTextBlock>
    ''' </RichTextColumns>
    ''' </code>
    ''' </example>
    ''' <remarks>Se usa normalmente en una región de desplazamiento horizontal donde una cantidad no enlazada de espacio permite
    ''' crear todas las columnas necesarias. Cuando se usa en un espacio de desplazamiento vertical
    ''' no habrá nunca columnas adicionales.</remarks>
    <Windows.UI.Xaml.Markup.ContentProperty(Name:="RichTextContent")>
    Public NotInheritable Class RichTextColumns
        Inherits Panel

        ''' <summary>
        ''' Identifica la propiedad de dependencia <see cref="RichTextContent"/>.
        ''' </summary>
        Public Shared ReadOnly RichTextContentProperty As DependencyProperty =
            DependencyProperty.Register("RichTextContent", GetType(RichTextBlock),
            GetType(RichTextColumns), New PropertyMetadata(Nothing, AddressOf ResetOverflowLayout))

        ''' <summary>
        ''' Identifica la propiedad de dependencia <see cref="ColumnTemplate"/>.
        ''' </summary>
        Public Shared ReadOnly ColumnTemplateProperty As DependencyProperty =
            DependencyProperty.Register("ColumnTemplate", GetType(DataTemplate),
            GetType(RichTextColumns), New PropertyMetadata(Nothing, AddressOf ResetOverflowLayout))

        ''' <summary>
        ''' Inicializa una nueva instancia de la clase <see cref="RichTextColumns"/>.
        ''' </summary>
        Public Sub New()
            Me.HorizontalAlignment = HorizontalAlignment.Left
        End Sub

        ''' <summary>
        ''' Obtiene o establece el contenido de texto enriquecido inicial para usarlo como primera columna.
        ''' </summary>
        Public Property RichTextContent As RichTextBlock
            Get
                Return DirectCast(Me.GetValue(RichTextContentProperty), RichTextBlock)
            End Get
            Set(value As RichTextBlock)
                Me.SetValue(RichTextContentProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Obtiene o establece la plantilla usada para crear
        ''' instancias de <see cref="RichTextBlockOverflow"/> adicionales.
        ''' </summary>
        Public Property ColumnTemplate As DataTemplate
            Get
                Return DirectCast(Me.GetValue(ColumnTemplateProperty), DataTemplate)
            End Get
            Set(value As DataTemplate)
                Me.SetValue(ColumnTemplateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Se invoca cuando se cambia la plantilla de contenido o desbordamiento para volver a crear el diseño de columna.
        ''' </summary>
        ''' <param name="d">Instancia de <see cref="RichTextColumns"/> donde se
        ''' produjo el cambio.</param>
        ''' <param name="e">Datos de evento que describen el cambio específico.</param>
        Public Shared Sub ResetOverflowLayout(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim target As RichTextColumns = TryCast(d, RichTextColumns)
            If target IsNot Nothing Then
                ' Cuando se realizan cambios drásticos, recompilar el diseño desde cero
                target._overflowColumns = Nothing
                target.Children.Clear()
                target.InvalidateMeasure()
            End If
        End Sub

        ''' <summary>
        ''' Enumera las columnas de desbordamiento ya creadas. Debe mantener una relación de 1:1 con
        ''' las instancias de la colección <see cref="Panel.Children"/> que siguen al
        ''' secundario de RichTextBlock inicial.
        ''' </summary>
        Private _overflowColumns As List(Of RichTextBlockOverflow) = Nothing

        ''' <summary>
        ''' Determina si se necesitan columnas de desbordamiento adicionales y si se pueden
        ''' quitar columnas existentes.
        ''' </summary>
        ''' <param name="availableSize">Tamaño del espacio disponible, usado para limitar el
        ''' número de columnas adicionales que se pueden crear.</param>
        ''' <returns>Tamaño resultante del contenido original más las columnas adicionales.</returns>
        Protected Overrides Function MeasureOverride(availableSize As Size) As Size
            If Me.RichTextContent Is Nothing Then Return New Size(0, 0)

            ' Asegurarse de que RichTextBlock es un secundario, por la ausencia de
            ' una lista de columnas adicionales como signo de que esto no se ha
            ' hecho aún
            If Me._overflowColumns Is Nothing Then
                Me.Children.Add(Me.RichTextContent)
                Me._overflowColumns = New List(Of RichTextBlockOverflow)()
            End If

            ' Comenzar midiendo el contenido de RichTextBlock original
            Me.RichTextContent.Measure(availableSize)
            Dim maxWidth As Double = Me.RichTextContent.DesiredSize.Width
            Dim maxHeight As Double = Me.RichTextContent.DesiredSize.Height
            Dim hasOverflow As Boolean = Me.RichTextContent.HasOverflowContent

            ' Asegurarse de que hay suficientes columnas de desbordamiento
            Dim overflowIndex As Integer = 0
            While hasOverflow AndAlso maxWidth < availableSize.Width AndAlso Me.ColumnTemplate IsNot Nothing

                ' Usar las columnas de desbordamiento existentes hasta que se agoten. Después, crear
                ' más a partir de la plantilla proporcionada
                Dim overflow As RichTextBlockOverflow
                If Me._overflowColumns.Count > overflowIndex Then
                    overflow = Me._overflowColumns(overflowIndex)
                Else
                    overflow = DirectCast(Me.ColumnTemplate.LoadContent(), RichTextBlockOverflow)
                    Me._overflowColumns.Add(overflow)
                    Me.Children.Add(overflow)
                    If overflowIndex = 0 Then
                        Me.RichTextContent.OverflowContentTarget = overflow
                    Else
                        Me._overflowColumns(overflowIndex - 1).OverflowContentTarget = overflow
                    End If
                End If

                ' Medir la nueva columna y preparar para repetir según sea necesario
                overflow.Measure(New Size(availableSize.Width - maxWidth, availableSize.Height))
                maxWidth += overflow.DesiredSize.Width
                maxHeight = Math.Max(maxHeight, overflow.DesiredSize.Height)
                hasOverflow = overflow.HasOverflowContent
                overflowIndex += 1
            End While

            ' Desconectar las columnas adicionales de la cadena de desbordamiento, quitarlas de nuestra lista privada
            ' de columnas y quitarlas como secundarios
            If Me._overflowColumns.Count > overflowIndex Then
                If overflowIndex = 0 Then
                    Me.RichTextContent.OverflowContentTarget = Nothing
                Else
                    Me._overflowColumns(overflowIndex - 1).OverflowContentTarget = Nothing
                End If

                While Me._overflowColumns.Count > overflowIndex
                    Me._overflowColumns.RemoveAt(overflowIndex)
                    Me.Children.RemoveAt(overflowIndex + 1)
                End While
            End If

            ' Notificar el tamaño final determinado
            Return New Size(maxWidth, maxHeight)
        End Function

        ''' <summary>
        ''' Organiza el contenido original y todas las columnas adicionales.
        ''' </summary>
        ''' <param name="finalSize">Define el tamaño del área en la que deben organizarse
        ''' los secundarios.</param>
        ''' <returns>Tamaño del área que realmente requieren los secundarios.</returns>
        Protected Overrides Function ArrangeOverride(finalSize As Size) As Size
            Dim maxWidth As Double = 0
            Dim maxHeight As Double = 0
            For Each child As UIElement In Children
                child.Arrange(New Rect(maxWidth, 0, child.DesiredSize.Width, finalSize.Height))
                maxWidth += child.DesiredSize.Width
                maxHeight = Math.Max(maxHeight, child.DesiredSize.Height)
            Next
            Return New Size(maxWidth, maxHeight)
        End Function

    End Class

End Namespace
