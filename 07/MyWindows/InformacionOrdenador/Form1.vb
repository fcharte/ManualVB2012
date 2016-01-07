Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      With My.Computer
         Dim Datos = Split(
             "Memoria física total: " &
             Format(.Info.TotalPhysicalMemory, "#,#") & " bytes," &
             "Memoria física disponible: " &
             Format(.Info.AvailablePhysicalMemory, "#,#") & " bytes," &
             "Memoria virtual total: " &
             Format(.Info.TotalVirtualMemory, "#,#") & " bytes," &
             "Memoria virtual disponible: " &
             Format(.Info.AvailableVirtualMemory, "#,#") & " bytes," &
             "Configuración regional: " &
             .Info.InstalledUICulture.DisplayName & "," &
             "Sistema operativo: " & .Info.OSFullName & "," &
             "Plataforma: " & .Info.OSPlatform & "," &
             "Versión del sistema: " & .Info.OSVersion & ",", ",")

         For Each Cadena As String In Datos
            ListBox1.Items.Add(Cadena)
         Next
      End With

   End Sub
End Class
