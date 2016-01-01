Imports System
Imports System.Console

Namespace Anaya.ManualVB2012.Visibilidad

   ' Tenemos una clase pública
   Public Class ClaseBase
      ' con algunas variables en distintos ámbitos
      Dim AmbitoDefecto As Integer
      Private AmbitoPrivado As Integer
      Protected AmbitoProtegido As Integer
      Friend AmbitoInterno As Integer
      Protected Friend AmbitoProtegidoeInterno As Integer
      Public AmbitoPublico As Integer

      Public Sub New()
         ' Aquí podemos acceder a todos los miembros
         AmbitoDefecto = 5
         AmbitoPrivado = 2
         AmbitoProtegido = 10
         AmbitoInterno = 15
         AmbitoProtegidoeInterno = 12
         AmbitoPublico = 20
      End Sub

      ' Este método muestra los valores de los miembros
      Public Overridable Sub Muestra()
         WriteLine("ClaseBase.Muestra()")
         WriteLine("-------------------")
         WriteLine("AmbitoDefecto = {0}", AmbitoDefecto)
         WriteLine("AmbitoPrivado = {0}", AmbitoPrivado)
         WriteLine("AmbitoProtegido = {0}", AmbitoProtegido)
         WriteLine("AmbitoInterno = {0}", AmbitoInterno)
         WriteLine("AmbitoProtegidoeInterno = {0}",
                AmbitoProtegidoeInterno)
         WriteLine("AmbitoPublico = {0}", AmbitoPublico)
         WriteLine("-------------------")
      End Sub

   End Class ' Fin de la clase base

   ' Una clase derivada de la anterior
   Class ClaseDerivada
      Inherits ClaseBase

      ' en el constructor modificamos los miembros heredados
      Public Sub New()
         ' AmbitoDefecto++;
         ' AmbitoPrivado++;
         AmbitoProtegido += 1
         AmbitoInterno += 1
         AmbitoProtegidoeInterno += 1
         AmbitoPublico += 1
      End Sub

      ' Este método muestra los valores de los miembros
      Public Overrides Sub Muestra()
         WriteLine("ClaseDerivada.Muestra()")
         WriteLine("-------------------")
         ' WriteLine("AmbitoDefecto = {0}", AmbitoDefecto)
         ' WriteLine("AmbitoPrivado = {0}", AmbitoPrivado)
         WriteLine("AmbitoProtegido = {0}", AmbitoProtegido)
         WriteLine("AmbitoInterno = {0}", AmbitoInterno)
         WriteLine("AmbitoProtegidoeInterno = {0}",
                 AmbitoProtegidoeInterno)
         WriteLine("AmbitoPublico = {0}", AmbitoPublico)
         WriteLine("-------------------")
      End Sub

   End Class ' Fin de la clase derivada

   ' Esta clase es independiente de la anterior
   Class Principal
      ' Este método muestra los valores de miembros
      Public Shared Sub Muestra(MiClaseBase As ClaseBase)
         WriteLine("Principal.Muestra()")
         WriteLine("-------------------")
         ' WriteLine("AmbitoDefecto = {0}", MiClaseBase.AmbitoDefecto)
         ' WriteLine("AmbitoPrivado = {0}", MiClaseBase.AmbitoPrivado)
         ' WriteLine("AmbitoProtegido = {0}", MiClaseBase.AmbitoProtegido)
         WriteLine("AmbitoInterno = {0}", MiClaseBase.AmbitoInterno)
         WriteLine("AmbitoProtegidoeInterno = {0}",
                 MiClaseBase.AmbitoProtegidoeInterno)
         WriteLine("AmbitoPublico = {0}", MiClaseBase.AmbitoPublico)
         WriteLine("-------------------")
      End Sub

      Shared Sub Main()
         ' Creamos un objeto de la clase base o derivada
         Dim MiClaseBase As ClaseBase = New ClaseBase()
         Dim MiClaseDerivada As ClaseDerivada = New ClaseDerivada()

         MiClaseBase.Muestra()
         MiClaseDerivada.Muestra()
         Muestra(MiClaseBase)
      End Sub
   End Class ' Fin de la clase Principal

End Namespace ' Fin del espacio con nombre
