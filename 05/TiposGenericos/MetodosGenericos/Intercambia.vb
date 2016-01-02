Namespace My
   Public Class Utilidades
      Public Shared Sub Intercambia(Of Tipo)(ByRef El1 As Tipo,
                                              ByRef El2 As Tipo)
         Dim Temp As Tipo = El1
         El1 = El2
         El2 = Temp
      End Sub
   End Class
End Namespace
