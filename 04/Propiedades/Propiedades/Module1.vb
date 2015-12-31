Imports System

Namespace Anaya.ManualVB2012.Propiedades

   ' Esta clase tiene como miembros
   Class Ficha
      ' dos variables privadas
      Private Pnombre As String, Pdireccion As String

      ' el constructor sin parámetros también es privado, de tal forma
      ' que no sea posible crear un objeto de esta clase con él
      Private Sub New()
         '
      End Sub

      ' siendo obligatorio el uso de este segundo constructor
      Public Sub New(N As String, D As String)
         Pnombre = N
         Pdireccion = D
      End Sub

      Public Sub New(N As String, D As String, E As String)
         Pnombre = N
         Pdireccion = D
         _Email = E
      End Sub

      ' La propiedad Nombre solo puede leerse
      Public ReadOnly Property Nombre() As String
         Get
            Return Pnombre
         End Get
      End Property

      ' La propiedad Dirección puede leerse y escribirse
      Public Property Direccion() As String
         Get
            Return Pdireccion
         End Get
         Set(Value As String)
            Pdireccion = Value
         End Set
      End Property

      ' Propiedad autoimplementada
      Public Property Email As String
   End Class

   ' Usamos desde esta clase un objeto  de la anterior
   Class Aplicacion
      Shared Sub Main()
         Dim MiFicha As Ficha = New Ficha(
             "Francisco Charte", "El Almendral", "francisco@fcharte.com")
         Console.WriteLine("{0} -> {1}, {2}",
            MiFicha.Nombre, MiFicha.Direccion, MiFicha.Email)
         ' MiFicha.Nombre = "Paco Charte";
         MiFicha.Direccion = "El Nogal"
         Console.WriteLine("{0} -> {1}", MiFicha.Nombre, MiFicha.Direccion)
      End Sub
   End Class
End Namespace
