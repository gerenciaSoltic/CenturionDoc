<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hojaruta.aspx.cs" Inherits="gestion_documental.hojaruta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
        .style6
    {
        width: 217px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Hojas de Ruta para Expedientes Fisicos por Oficina Productora"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" GroupingText="">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <table style="width: 100%">
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Oficina Productora"></asp:Label>
        </td>
        <td>

            <asp:DropDownList ID="DDlEntes" runat="server" Height="27px" Width="297px">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Buscar" onclick="Button1_Click" />
        </td>
        
        
        </tr>
        
        </table>
        <hr />

        <table>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Contenedor"></asp:Label>
        </td>
        <td>
        
            <asp:DropDownList ID="DDlContenedor" runat="server" Height="16px" Width="157px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
        
        <td>
            <asp:Label ID="Label4" runat="server" Text="Número"></asp:Label>
        </td>
        <td>
        
            <asp:TextBox ID="TxtNumero" runat="server" AutoPostBack="True"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Compartimientos"></asp:Label>
        </td>
        <td>
        
            <asp:TextBox ID="TxtCompartimientos" runat="server" AutoPostBack="True"></asp:TextBox>
        </td>
        </tr>
        </table>
        <hr />
        <table>
        <tr>
        <td class="style6">
        </td>
        <td>
            <asp:Button ID="BtnAdicionar" runat="server" Text="Adicionar" Width="131px" 
                onclick="BtnAdicionar_Click" />
        </td>
        <td>
            <asp:Button ID="BtnSalir" runat="server" Text="Salir" Width="125px" 
                onclick="BtnSalir_Click" />
        </td>
        <td>
        </td>
        </tr>
        
        </table>
        <table style="width: 100%">
        <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="636px" 
                DataKeyNames="identeruta" onrowdeleted="GridView1_RowDeleted" 
                onrowdeleting="GridView1_RowDeleting" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="contenedor" HeaderText="CONTENEDOR" />
                    <asp:BoundField DataField="numero" HeaderText="NUMERO" />
                    <asp:BoundField DataField="compartimiento" HeaderText="COMPARTIMIENTO" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" 
                        ShowSelectButton="True" />
                    <asp:CommandField InsertVisible="False" ShowCancelButton="False" 
                        ShowDeleteButton="True" />
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



 </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>




</asp:Content>
