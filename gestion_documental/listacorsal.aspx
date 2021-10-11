<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listacorsal.aspx.cs" Inherits="gestion_documental.listacorsal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <p>
        LISTA DE CORREOS SALIENTES
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table width = "100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Buscar Clave:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="193px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Filtrar" onclick="Button1_Click" 
                    style="height: 26px" />
            </td>
            
        </tr>
    </table>
    <div align = "center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
            DataKeyNames="id,texto" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="asunto" HeaderText="Asunto" />
                <asp:BoundField DataField="texto" HeaderText="Texto" />
                <asp:BoundField DataField="radicado" HeaderText="Radicado" />
                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Emisor" HeaderText="Emisor" />
                <asp:CommandField ShowSelectButton="True" />
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
    <table>
        <tr>
            <td>
 Texto completo

            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTexto" runat="server" Height="93px" TextMode="MultiLine" 
         Width="613px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
    </table>

<hr />
<div>
ADJUNTOS
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        DataKeyNames="archivo" onselectedindexchanged="GridView2_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="archivo" HeaderText="Documento" />
        <asp:CommandField ShowSelectButton="True" />
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
</asp:Content>

