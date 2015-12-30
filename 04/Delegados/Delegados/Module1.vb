Imports System

Namespace Anaya.ManualVB2012.Eventos

   ' Definimos el tipo de evento
   Public Delegate Sub OnTickReloj(ByVal Ticks As Integer)

   ' Esta clase cuenta con un evento del tipo OnTickReloj
   Public Class Reloj
      Event Tick As OnTickReloj

      ' inicialmente el evento no está asignado
      Public Sub New()
         ' Tick = Nothing
      End Sub

      ' Este método simplemente
      Public Sub Inicio()
         ' simula un reloj que genera una señal cada 100 tics
         Dim N As Integer
         For N = 0 To 1000
            If N Mod 100 = 0 Then
               RaiseEvent Tick(N) ' generando el evento
            End If
         Next
      End Sub
   End Class

   ' Esta es otra clase que hace uso de la anterior
   Class Aplicacion
      Sub New() ' creamos un reloj
         Dim MiReloj As Reloj = New Reloj()

         ' y llamamos al método Inicio() antes de asignar el gestor
         Console.WriteLine("Antes de asignar el gestor de evento")
         MiReloj.Inicio()

         ' asignamos el gestor
         AddHandler MiReloj.Tick, New OnTickReloj(AddressOf TickReloj)
         Console.WriteLine("Después de asignar el gestor de evento")
         Console.ReadLine() ' esperamos Intro
         MiReloj.Inicio() ' y repetimos
      End Sub

      ' Al recibir el evento
      Sub TickReloj(Ticks As Integer)
         ' simplemente mostramos el valor
         Console.WriteLine(Ticks)
      End Sub

      Shared Sub Main()
         Dim MiAplicacion As Aplicacion = New Aplicacion()
      End Sub
   End Class
End Namespace
