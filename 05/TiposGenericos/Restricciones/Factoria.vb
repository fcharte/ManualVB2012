Public Class Factoria(Of TipoObjeto As {New, Control})
   ' Para conservar los objetos creados
   Private Lista As Hashtable = New Hashtable

   ' Este método crea un nuevo objeto del tipo adecuado
   ' asociándole una clave
   Public Function Nuevo(ByVal Clave As String) As TipoObjeto
      Dim Objeto = New TipoObjeto
      Lista.Add(Clave, Objeto)
      Return Objeto
   End Function

   ' Propiedad sólo de lectura que devuelve el objeto solicitado
   Public ReadOnly Property Elemento(ByVal Clave As String) As TipoObjeto
      Get
         Return Lista(Clave)
      End Get
   End Property
End Class

Public Class Factoria(Of TipoClave, TipoObjeto As {New, Control})
   ' Para conservar los objetos creados
   Private Lista As Hashtable = New Hashtable

   ' Este método crea un nuevo objeto del tipo adecuado
   ' asociándole una clave
   Public Function Nuevo(Clave As TipoClave) As TipoObjeto
      Dim Objeto = New TipoObjeto
      Lista.Add(Clave, Objeto)
      Return Objeto
   End Function

   ' Propiedad sólo de lectura que devuelve el objeto solicitado
   Public ReadOnly Property Elemento(Clave As TipoClave) As TipoObjeto
      Get
         Return Lista(Clave)
      End Get
   End Property
End Class
