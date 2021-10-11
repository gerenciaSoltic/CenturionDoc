<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformeTRD.aspx.cs" Inherits="gestion_documental.Styles.InformeTRD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 547px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Informe Sobre Configuración  Series - Subseries- Tipologias"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<table style="width: 100%">
<tr>
   <td class="style1">
    <asp:Label ID="Label2" runat="server" Text="Serie"></asp:Label>
    <asp:DropDownList ID="DDLserie" runat="server" Height="20px" 
           style="margin-left: 10px" Width="346px" AutoPostBack="True" 
           onselectedindexchanged="DDLserie_SelectedIndexChanged" 
           ontextchanged="GrdTRD_SelectedIndexChanged">
    </asp:DropDownList>
    </td>
    
    <td>
    
    
    <asp:Label ID="Label3" runat="server" Text="Subserie"></asp:Label>
    <asp:DropDownList ID="DDLsubserie" runat="server" Height="16px" Width="397px" 
            AutoPostBack="True" onselectedindexchanged="DDLsubserie_SelectedIndexChanged" 
            ontextchanged="DDLsubserie_TextChanged">
    </asp:DropDownList>
    </td>

</tr>
</table>
<hr />
<table style="width: 100%">
<tr>
<td>
    <asp:GridView ID="GrdTRD" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="888px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="codserie" HeaderText="Cod. Serie" />
            <asp:BoundField DataField="serie" HeaderText="Serie" />
            <asp:BoundField DataField="codsubserie" HeaderText="Cod. Subseie" />
            <asp:BoundField DataField="subserie" HeaderText="Subserie" />
            <asp:BoundField DataField="codtipologia" HeaderText="Cod. Tipologia" />
            <asp:BoundField DataField="tipologia" HeaderText="Tipologia" />
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
