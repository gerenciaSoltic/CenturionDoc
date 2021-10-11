<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="configcertificado.aspx.cs" Inherits="gestion_documental.configcertificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 142px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="Label1" runat="server" Text="CONFIGURACION DEL CERTIFICADO"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Titulo del Certificado"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTituloCertificado" runat="server" TextMode="MultiLine" 
        Height="75px" Width="474px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Nombre del Firmante"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreFirmante" runat="server" TextMode="SingleLine" 
        Width="402px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Cargo del Firmante"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCargoFirmante" runat="server" TextMode="SingleLine" 
        Width="397px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Texto Estampillas"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEstampillasCertificado" runat="server" TextMo 
        TextMode="MultiLine" de="SingleLine" Width="431px" Height="74px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Firma"></asp:Label>
            </td>
            <td>
                <asp:Image ID="Image1" runat="server" />
            </td>

</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Cambiar firma"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Button1" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <hr />
    <table width="100%" align="center">
        <tr align="center">
            <td>
                <asp:Button ID="Button1" runat="server" Text="Grabar y Salir" 
        onclick="Button1_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
