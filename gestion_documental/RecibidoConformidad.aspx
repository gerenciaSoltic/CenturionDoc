<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecibidoConformidad.aspx.cs" Inherits="gestion_documental.RecibidoConformidad" %>
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
        <asp:Label ID="Label1" runat="server" Text="RECIBIDO A CONFORMIDAD" 
            Font-Bold="True"></asp:Label>
                
    </td>
    </tr>
      <tr align="center">
    <td>
        <asp:Label ID="Label2" runat="server" Text="RADICADO:" ></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>

        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
            onclick="BtnBuscar_Click" Width="141px" />
    </td>
    </tr>
  
    <tr align="center">
    <td>
        <br />
        Descripcion:
        <asp:TextBox ID="TxtDescripcion" runat="server" Height="38px" Width="600px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label3" runat="server" Text="" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="" Font-Bold="True"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="" Font-Bold="True"></asp:Label>

    </td>
    </tr>
    <tr>
    <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
            <ContentTemplate>
                <asp:FileUpload ID="ImageButton2" runat="server" Height="30px" Width="300px" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnGuardar" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Button ID="BtnGuardar" runat="server" onclick="BtnGuardar_Click" 
            Text="Guardar" />
        <br />
    </td>
    </tr>
    </table>
    <table width="100%" >
    <tr>
    <td width="100%">
        &nbsp;</td>
    </tr>
    <tr>
    <td width="100%">
        &nbsp;</td>

    </tr>
   
    </table>


 <%--   <table>

<tr>
<td class="style1">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
        <asp:FileUpload ID="ImageButton2" runat="server" Height="30px" Width="300px" />
        </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Button1" />
                    </Triggers>
                </asp:UpdatePanel>
    <asp:Button ID="Button2" runat="server" Text="Guardar" 
        onclick="Button1_Click" />

</td>

</tr>

</table>
--%>
</asp:Content>
