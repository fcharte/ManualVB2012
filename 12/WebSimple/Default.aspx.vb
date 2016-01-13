
Partial Class _Default
    Inherits System.Web.UI.Page

   Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
      For N = 1 To 5
         Response.Write("<h" & N & ">Hola mundo</h" & N & ">")
      Next

   End Sub
End Class
