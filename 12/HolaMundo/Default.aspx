<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html>
    <body>
<% 
    For I=1 To 5
      Response.Write("<h" & I.ToString() & 
                     ">Hola mundo")
    Next
 %>
        </body>
</html>
