<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="camclave.aspx.cs" Inherits="gestion_documental.camclave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 454px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    CAMBIAR CONTRASEÑA
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table>
  <tr>
  <td>
      <asp:Label ID="Label1" runat="server" Text="CONTRASEÑA ACTUAL"></asp:Label>
  </td>
  <td>
      <asp:TextBox ID="txtActual" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  </tr>
   <tr>
  <td>
      <asp:Label ID="Label2" runat="server" Text="CONTRASEÑA NUEVA"></asp:Label>
  </td>
  <td>
      <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  </tr>
   <tr>
  <td>
      <asp:Label ID="Label3" runat="server" Text="CONFIRMAR CONTRASEÑA ACTUAL"></asp:Label>
  </td>
  <td>
      <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
  </td>
  </tr>
  
  </table>
  <table>
  <tr align = "center">
  <td class="style1">
      <asp:Button ID="Button1" runat="server" Text="Aceptar" 
          onclick="Button1_Click" />
  </td>
  </tr>
  </table>
</asp:Content>
