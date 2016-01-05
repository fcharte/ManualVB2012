Namespace My
   Public Class Utilities
      Private Shared strPropiedad As String
      Public Shared Property Propiedad() As String
         Get
            Return strPropiedad
         End Get
         Set(ByVal value As String)
            strPropiedad = value
         End Set
      End Property
   End Class
End Namespace