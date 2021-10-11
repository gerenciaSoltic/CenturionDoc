<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Respuestasintramite.aspx.cs" Inherits="gestion_documental.Respuestasintramite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<table border="1" style="width: 100%">
    <tr>
    <td align="center">
        <asp:Label ID="Label1" runat="server" Text="RESPUESTA" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    <tr align="center">
    <td>
        <asp:Label ID="Label2" runat="server" Text="RADICADO:" ></asp:Label><asp:TextBox
            ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server"
                Text="Buscar" onclick="Button5_Click" />
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label3" runat="server" Text="" Font-Bold="True"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
        <asp:TextBox ID="TextBox2" runat="server" Height="109px" Width="100%" 
            TextMode="MultiLine"></asp:TextBox>
    </td>
    </tr>
    </table>
    <table width="100%" >
    <tr>
    <td width="100%">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="camino,documento" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="GridView2_SelectedIndexChanged" 
            Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="DOCUMENTO" HeaderText="Documento" />
                <asp:BoundField DataField="camino" HeaderText="camino" />
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
    </td>
    </tr>
    <tr>
    <td width="100%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Height="39px" Width="100%" CellPadding="4" DataKeyNames="id" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Destinatarios" DataField="destinatario" />
                <asp:BoundField DataField="Id" HeaderText="Id" />
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
    </td>

    </tr>
    <tr align="center" >
    <td style="border-style: ridge">
        <asp:Button ID="Button1" runat="server" Text="Grabar" onclick="Button1_Click" />
    </td>
    </tr>
    
    </table>
</asp:Content>
