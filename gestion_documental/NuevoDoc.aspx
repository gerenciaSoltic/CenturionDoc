<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDoc.aspx.cs" Inherits="gestion_documental.NuevoDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align="center">

    <asp:Label ID="Label1" runat="server" Text="Nuevo Documento" Font-Bold="True"></asp:Label>
</div>
<br />
<br />

<div align="left">
    
    
    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="522px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Crear" Width="62px" 
        onclick="Button1_Click" />
    <br />
    <br />
    <div align="center">
    <asp:Button ID="Button2" runat="server" Text="Enviar por correo Electronico" />
    </div>

    
</div>

<div>
    

</div>

</asp:Content>
