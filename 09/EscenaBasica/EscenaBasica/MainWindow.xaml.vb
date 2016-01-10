Imports System.Windows.Media.Media3D
Class MainWindow
   Private Sub Rot_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double))
      ' Crearemos un grupo con tres transformaciones
      Dim Transformacion = New Transform3DGroup()

      ' Una rotación sobre cada uno de los ejes
      Transformacion.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(1, 0, 0), RotX.Value)))
      Transformacion.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 1, 0), RotY.Value)))
      Transformacion.Children.Add(New RotateTransform3D(New AxisAngleRotation3D(New Vector3D(0, 0, 1), RotZ.Value)))

      ' Se aplica la transformación
      Octaedro.Transform = Transformacion
   End Sub

   Private Sub Dir_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double))
      Try
         ' Cambiar el color de la luz
         Luz.Color = Color.FromRgb(DirRed.Value, DirGreen.Value, DirBlue.Value)
         ' y el brillo del material
         CType(CType(Octaedro.Material, MaterialGroup).Children(1), SpecularMaterial).SpecularPower = Brillo.Value
      Catch ex As Exception

      End Try
   End Sub

End Class
