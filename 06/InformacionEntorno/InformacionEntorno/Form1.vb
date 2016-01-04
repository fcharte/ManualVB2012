Public Class Form1

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ' Matriz con los datos a recuperar

      Dim Datos() = {
      "StartupPath= " + Application.StartupPath,
      "ExecutablePath= " + Application.ExecutablePath,
      "CompanyName= " + Application.CompanyName,
      "ProductName= " + Application.ProductName,
      "ProductVersion= " + Application.ProductVersion,
      "UserAppDataPath= " + Application.UserAppDataPath,
      "CommonAppDataPath= " + Application.CommonAppDataPath()
  }

      ' Recorremos la matriz añadiendo los datos 
      ' a la lista
      For Each Cadena As String In Datos
         lbDatos.Items.Add(Cadena)
      Next

   End Sub
End Class
