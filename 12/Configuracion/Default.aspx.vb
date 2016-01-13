Imports System.Web.Configuration
Partial Class _Default
    Inherits System.Web.UI.Page

   Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

   End Sub

   Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      Dim Valores = WebConfigurationManager.AppSettings
      Response.Write(Valores(DropDownList1.SelectedItem.Value))
   End Sub
End Class
