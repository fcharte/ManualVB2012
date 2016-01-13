<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="OpcionesContent" Runat="Server">
    Opción 1<br />
    Opción 2<br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server">Salir</asp:HyperLink>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    Bienvenido a la web de Anaya Multimedia, la mayor editorial de libros técnicos en
    lengua española.<br />
    <br />
    <br />
    Introduzca su Id:
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Iniciar sesión" />
    <br />
    <br />
</asp:Content>