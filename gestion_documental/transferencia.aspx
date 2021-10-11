<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="transferencia.aspx.cs" Inherits="gestion_documental.transferencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
TRANSFEENCIAS
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<div align = "center">
<table>
<tr>
<td>
 <asp:Label ID="Label1" runat="server" Text="Proyecto"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="ddlProyecto" runat="server">
    </asp:DropDownList>
</td>


<td>
    <asp:Label ID="Label2" runat="server" Text="Año"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtAño" runat="server" Width="117px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Desde la Caja"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtCajaDesde" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label4" runat="server" Text="Hasta la Caja"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtCajaHasta" runat="server"></asp:TextBox>
</td>
</tr>

</table>
</div>
<div align = "center">
<table>
<tr align = "center">
<td>
    <asp:Button ID="Button1" runat="server" Text="Agregar" Width="89px" 
        onclick="Button1_Click" />
</td>
</tr>

</div>
</table>
   
<hr />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        onrowdeleting="GridView1_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="proyecto" HeaderText="Proyecto" />
            <asp:BoundField DataField="año" HeaderText="año" />
            <asp:BoundField DataField="cajasdesde" HeaderText="Desde la Caja" />
            <asp:BoundField HeaderText="Hasta la Caja" DataField="cajashasta" />
            <asp:BoundField DataField="cantidadcajas" HeaderText="Cant Cajas" />
            <asp:BoundField DataField="cantidadcarpetas" HeaderText="Cant Carpetas" />
            <asp:BoundField DataField="cantidadcarpetas" HeaderText="Cant Contratos" />
            <asp:BoundField DataField="totalfolios" HeaderText="Total Folios" />
            <asp:BoundField DataField="fdesde" HeaderText="Fec Desde" />
            <asp:BoundField DataField="fhasta" HeaderText="Fec Hasta" />
            <asp:BoundField DataField="idproyecto" HeaderText="ID PROY" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
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
    <hr />
    <div align = "center">
    <table>
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Cantidad de Cajas"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtCatidadCajas" runat="server" Enabled="False"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Cantidad de Carpetas"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtCantidadCarpetas" runat="server" Enabled="False"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Cantidad de Contratos"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtCantidadContratos" runat="server" Enabled="False"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label8" runat="server" Text="Total Folios"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtTotalFolios" runat="server" Enabled="False"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="Label10" runat="server" Text="Fecha Extrema Desde"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtFDesde" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label11" runat="server" Text="Fecha Extrema Hasta"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtFHasta" runat="server" Enabled="False"></asp:TextBox>
    </td>
    </tr>
    <tr>
    
     <td>
        <asp:Label ID="Label9" runat="server" Text="Fecha de Entrega"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtFechaEntrega" runat="server"></asp:TextBox>
         <asp:CalendarExtender   
    ID = "CalendarExtender1"   
    TargetControlID = "txtFechaEntrega"   
    runat = "server" Format="yyyy-MM-dd" />
        <asp:Button ID="Button4" runat="server" Text="Traer" onclick="Button4_Click" />
    </td>
    </tr>

        <tr>
    
     <td>
        <asp:Label ID="Label12" runat="server" Text="Numero de Entrega"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtNumeroEntrega" runat="server"></asp:TextBox>
         
    </td>
    </tr>



    </table>
    </div>
    <hr />
    <div align = "center">
        <asp:Button ID="Button2" runat="server" Text="Registrar" 
            onclick="Button2_Click" Width="167px" />
        <asp:Button ID="Button3" runat="server" Text="Imprimir FUID " 
            onclick="Button3_Click" />
    </div>
</asp:Content>
