<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TramiteCorreo.aspx.cs" Inherits="gestion_documental.TramiteCorreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Ventanilla Saliente Electrónica"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<table align="center">
<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="Radicado:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="txtRadicado" runat="server" Width="377px"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Para:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="TxtEmirecep" runat="server" Width="377px"></asp:TextBox>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label4" runat="server" Text="Correo:"></asp:Label>
</td>

<td>
    <asp:TextBox ID="TxtCorreo" runat="server" Width="375px"></asp:TextBox>
</td>
</tr>

</table>
<br />

<hr />

    <asp:Label ID="Label6" runat="server" Text="ASUNTO"></asp:Label>
<div align="center">

    <asp:TextBox ID="txtMensaje" runat="server" Height="157px" TextMode="MultiLine" 
        Width="557px"></asp:TextBox>

</div>
<br />
<hr />

<div align="center">
<asp:Label ID="Label5" runat="server" Text="Archivos a Adjuntar del Trámite"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="documento" HeaderText="Documento" />
        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</div>
<br />
<hr />
    
<table align="center">
<tr>
<td>
<asp:Button ID="Button1" runat="server" Text="Enviar" Width="137px" 
        onclick="Button1_Click" />
</td>
<td>
<asp:Button ID="Button3" runat="server" Text="Salir" Width="131px" 
        onclick="Button3_Click" />
</td>
</tr>
</table>
    
    
</asp:Content>
