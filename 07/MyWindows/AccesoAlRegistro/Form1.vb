Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim Clave = My.Computer.Registry.LocalMachine.OpenSubKey(
           "HARDWARE\DESCRIPTION\System\CentralProcessor\0")

      For Each Nombre As String In Clave.GetValueNames
         Try
            ListBox1.Items.Add(Nombre & ": " & Clave.GetValue(Nombre).ToString)
         Catch ex As Exception
            Continue For
         End Try
      Next

   End Sub
End Class
