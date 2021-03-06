﻿Namespace My
   ' Los siguientes eventos están disponibles para MyApplication:
   ' 
   ' Inicio: se desencadena cuando se inicia la aplicación, antes de que se cree el formulario de inicio.
   ' Apagado: generado después de cerrar todos los formularios de la aplicación. Este evento no se genera si la aplicación termina de forma anómala.
   ' UnhandledException: generado si la aplicación detecta una excepción no controlada.
   ' StartupNextInstance: se desencadena cuando se inicia una aplicación de instancia única y la aplicación ya está activa. 
   ' NetworkAvailabilityChanged: se desencadena cuando la conexión de red está conectada o desconectada.
   Partial Friend Class MyApplication
      Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
         If My.Computer.Network.IsAvailable Then
            MessageBox.Show("Detectada conexión a red")
         Else
            MessageBox.Show("Se ha perdido la conexión a red")
         End If
      End Sub
   End Class


End Namespace

