<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sincronizacion.aspx.cs" Inherits="gestion_documental.Sincronizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="TituloLabel" runat="server" Text="Proceso de sincronización" CssClass="labelTitle"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label ID="Msj" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<div align="center">
    
 
 <asp:Label ID="Label1" runat="server" Text="EMISORES RECEPTORES"></asp:Label>
 
 
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="399px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="descripcion" HeaderText="Nombre" />
             <asp:BoundField DataField="nit" HeaderText="Nit" />
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
 
 <asp:Label ID="Label2" runat="server" Text="DOCUMENTOS"></asp:Label>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="407px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="documento" HeaderText="Documento" />
             <asp:BoundField DataField="camino" HeaderText="Camino" />
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
   
  <asp:Label ID="Label3" runat="server" Text="RADICADOS"></asp:Label>
     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="384px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="radicado" HeaderText="Radicado" />
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
 
 
 <br />
 <br />


 
    <asp:Button ID="Btn_Sincronizar" runat="server" Text="Sincronizar" 
        onclick="Btn_Sincronizar_Click" />
        </div>
</asp:Content>
