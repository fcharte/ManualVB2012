Module Module1
   Structure Agenda
      Dim Nombre, Direccion, TelfCasa, TelfMovil As String
      Dim FechaCumple As DateTime
      Private _p1 As String
      Private _p2 As String

      Sub New(p1 As String, p2 As String)
         ' TODO: Complete member initialization 
         _p1 = p1
         _p2 = p2
      End Sub

   End Structure

   Sub Main()
      Dim Irene As New Agenda With {
         .Nombre = "Irene Gracia", .TelfMovil = "12345678"}

      Dim Felicitaciones As New List(Of Agenda) From {
         New Agenda("Irene Gracia", "12345678"),
         New Agenda("Mario Allende", "54345344")}
   End Sub
End Module
