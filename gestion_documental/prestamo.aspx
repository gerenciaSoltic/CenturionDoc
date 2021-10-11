<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="prestamo.aspx.cs" Inherits="gestion_documental.prestamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 106px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="MODULO DE PRESTAMOS" 
        Font-Size="Large"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <br />
    <br />
     <div align="center"  id="divprestamo" runat="server"  >
      
            <table>
            <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Recibe "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtrecibe" runat="server" Width="653px"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td>
            
                <asp:Label ID="Label4" runat="server" Text="Cargo"></asp:Label>
            
            </td>
             <td>
            
                 <asp:TextBox ID="txtcargopersona" runat="server" Width="650px"></asp:TextBox>
            
            </td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Detalle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdetalle" runat="server" Width="650px"></asp:TextBox>
            </td>
            </tr>
        </table>
        <table>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Numero"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtnumero" runat="server" Width="221px" Height="89px" 
                ontextchanged="txtnumero_TextChanged" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr>
        </table>
    </div>
   <br />
    <br />
    <hr />
   <br />
    <table align="center">
        <tr>
            <td>
                <asp:Button ID="btnprestamo" runat="server" Text="Prestamo" 
                    onclick="btnprestamo_Click" Width="159px" />
            </td>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnentrega" runat="server" Text="Devolucion" 
                    onclick="btnentrega_Click" Width="159px" />
            </td>
        </tr>
    </table>
   <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
