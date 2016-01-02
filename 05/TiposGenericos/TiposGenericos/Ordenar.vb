Public Class Ordenar(Of TipoElemento As IComparable)
   Public Shared Sub Ordena(Elementos() As TipoElemento)
      Dim I, J As Integer
      For I = 0 To Elementos.GetUpperBound(0)
         For J = 0 To I
            If Elementos(I).CompareTo(Elementos(J)) < 0 Then
               Dim Temporal As TipoElemento = Elementos(I)
               Elementos(I) = Elementos(J)
               Elementos(J) = Temporal
            End If
         Next
      Next
   End Sub
End Class

Public Class OrdenarB
   Public Shared Sub Ordena(Elementos() As Object)
      Dim I, J As Integer
      For I = 0 To Elementos.GetUpperBound(0)
         For J = 0 To I
            If Elementos(I) < Elementos(J) Then
               Dim Temporal As Object = Elementos(I)
               Elementos(I) = Elementos(J)
               Elementos(J) = Temporal
            End If
         Next
      Next
   End Sub

   ' Método específico para tipo Integer
   Public Shared Sub OrdenaInt(Elementos() As Integer)
      Dim I, J As Integer
      For I = 0 To Elementos.GetUpperBound(0)
         For J = 0 To I
            If Elementos(I) < Elementos(J) Then
               Dim Temporal As Integer = Elementos(I)
               Elementos(I) = Elementos(J)
               Elementos(J) = Temporal
            End If
         Next
      Next
   End Sub

   ' Métodos específico para tipo Double
   Public Shared Sub OrdenaDbl(Elementos() As Double)
      Dim I, J As Integer
      For I = 0 To Elementos.GetUpperBound(0)
         For J = 0 To I
            If Elementos(I) < Elementos(J) Then
               Dim Temporal As Double = Elementos(I)
               Elementos(I) = Elementos(J)
               Elementos(J) = Temporal
            End If
         Next
      Next
   End Sub
End Class
