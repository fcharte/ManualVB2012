﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.17626
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'StronglyTypedResourceBuilder generó automáticamente esta clase
'a través de una herramienta como ResGen o Visual Studio.
'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
'con la opción /str o recompila tu proyecto de Visual Studio.
'''<summary>
'''  Clase de recurso fuertemente tipado para buscar cadenas traducidas, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Public Class AppResources

    Private Shared resourceMan As Global.System.Resources.ResourceManager

    Private Shared resourceCulture As Global.System.Globalization.CultureInfo

    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub

    '''<summary>
    '''  Devuelve la instancia de ResourceManager almacenada en caché usada por esta clase.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WP8ListaCompra.AppResources", GetType(AppResources).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property

    '''<summary>
    '''  Invalida la propiedad CurrentUICulture del subproceso actual para todas las
    '''  búsquedas de recursos que usan esta clase de recurso fuertemente tipado.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar a LeftToRight.
    '''</summary>
    Public Shared ReadOnly Property ResourceFlowDirection() As String
        Get
            Return ResourceManager.GetString("ResourceFlowDirection", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar a us-EN.
    '''</summary>
    Public Shared ReadOnly Property ResourceLanguage() As String
        Get
            Return ResourceManager.GetString("ResourceLanguage", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar a MI APLICACIÓN.
    '''</summary>
    Public Shared ReadOnly Property ApplicationTitle() As String
        Get
            Return ResourceManager.GetString("ApplicationTitle", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar a Valor de propiedad en tiempo de ejecución de ejemplo.
    '''</summary>
    Public Shared ReadOnly Property SampleProperty() As String
        Get
            Return ResourceManager.GetString("SampleProperty", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar al texto del botón.
    '''</summary>
    Public Shared ReadOnly Property AppBarButtonText() As String
        Get
            Return ResourceManager.GetString("AppBarButtonText", resourceCulture)
        End Get
    End Property

    '''<summary>
    '''  Busca una cadena traducida similar a Elemento de menú.
    '''</summary>
    Public Shared ReadOnly Property AppBarMenuItemText() As String
        Get
            Return ResourceManager.GetString("AppBarMenuItemText", resourceCulture)
        End Get
    End Property
End Class