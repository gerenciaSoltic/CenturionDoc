<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CERTIFICADOS.aspx.cs" Inherits="gestion_documental.CERTIFICADOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
 <div align="center">
 <asp:Label ID="Label5" runat="server" Text="CERTIFICADOS" Font-Size="Larger"></asp:Label>
 </div>
    
<table>
<tr>
<td>

    <asp:Label ID="Label1" runat="server" Text="Municipio"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label2" runat="server" Text="Año"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  

</td>
<td>
    <asp:Label ID="Label3" runat="server" Text="Colegio"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  

</td>
<td>
    <asp:Label ID="Label4" runat="server" Text="Grado"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  

</td>
</tr>

<tr>
<td>
    <asp:Button ID="Button1" runat="server" Text="Buscar" />
</td>
</tr>

</table>
<table>
<tr>
<td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="850px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Archivos seleccionados" />
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

</table>
</asp:Content>
