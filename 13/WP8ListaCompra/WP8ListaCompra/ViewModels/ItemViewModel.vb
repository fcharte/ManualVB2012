﻿Imports System.ComponentModel
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Public Class ItemViewModel
    Implements INotifyPropertyChanged
    Private _lineOne As String
    ''' <summary>
    ''' Propiedad Sample ViewModel; esta propiedad se usa en la vista para mostrar su valor mediante un enlace.
    ''' </summary>
    ''' <returns></returns>
    Public Property LineOne() As String
        Get
            Return _lineOne
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_lineOne) Then
                _lineOne = value
                NotifyPropertyChanged("LineOne")
            End If
        End Set
    End Property

    Private _lineTwo As String
    ''' <summary>
    ''' Propiedad Sample ViewModel; esta propiedad se usa en la vista para mostrar su valor mediante un enlace.
    ''' </summary>
    ''' <returns></returns>
    Public Property LineTwo() As String
        Get
            Return _lineTwo
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_lineTwo) Then
                _lineTwo = value
                NotifyPropertyChanged("LineTwo")
            End If
        End Set
    End Property

    Private _lineThree As String
    ''' <summary>
    ''' Propiedad Sample ViewModel; esta propiedad se usa en la vista para mostrar su valor mediante un enlace.
    ''' </summary>
    ''' <returns></returns>
    Public Property LineThree() As String
        Get
            Return _lineThree
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_lineThree) Then
                _lineThree = value
                NotifyPropertyChanged("LineThree")
            End If
        End Set
    End Property

   Private _comprado As Boolean
   Public Property Comprado() As Boolean
      Get
         Return _comprado
      End Get
      Set(ByVal value As Boolean)
         _comprado = value
         NotifyPropertyChanged("Comprado")
      End Set
   End Property



    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
        If Nothing IsNot handler Then
            handler(Me, New PropertyChangedEventArgs(propertyName))
        End If
    End Sub
End Class