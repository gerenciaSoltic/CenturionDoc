<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="digitaliza.aspx.cs" Inherits="gestion_documental.digitaliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 114px;
        }
        .style2
        {
            width: 220px;
        }
        .style3
        {
            width: 515px;
        }
        .style4
        {
            width: 298px;
        }
        .style5
        {
            width: 131px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
<asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
 <asp:Label runat="server" ID="Msj" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" GroupingText="Digitalización de Documentos">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    
    <hr />

    
    
     
    <table>
        
    <tr>
     <td class="style1">
     </td>
    
    <td class="style5">
        &nbsp;</td>
    <td>
        &nbsp;</td>

    <td>
        &nbsp;</td>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Oficina productora:"></asp:Label><asp:DropDownList
            ID="DdlEntes" runat="server" Height="21px" 
            onselectedindexchanged="DdlEntes_SelectedIndexChanged" Width="318px" 
            AutoPostBack="True">
        </asp:DropDownList>
    </td


    </tr>
    
    </table>
    <hr />
    <table>
    <tr>
    <td>

    <asp:Label ID="LblSerie" runat="server" Text="Serie:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlSerie" runat="server" Width="328px" 
            AutoPostBack="True" DataTextField="SERIE" DataValueField="ID" Enabled="False" 
            onselectedindexchanged="DdlSerie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    <td>
    <asp:Label ID="Llbl" runat="server" Text="SubSerie:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlSubserie" runat="server" Width="302px" 
            AutoPostBack="True" DataTextField="SUBSERIE" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlSubserie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>

    <td>
    <asp:Label ID="LblTipologia" runat="server" Text="Tipologia:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlTipologia" runat="server" Width="210px" 
            AutoPostBack="True" DataTextField="TIPOLOGIA" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlTipologia_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
      
    </tr>
    
    </table>
    <hr />

    <table>
    <tr>
    <td>
    <asp:Label ID="LblExpediente" runat="server" Text="Expediente:"></asp:Label>
    <asp:DropDownList ID="DdlExpediente" runat="server" Width="978px" Height="25px" 
            AutoPostBack="True" DataTextField="DESCRIPCION" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlExpediente_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    
    </table>
    <hr />
    <table>
    
        
    
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnescaner" runat="server" onclick="btnescaner_Click" 
                    Text="Escanear" style="height: 26px" />
                <asp:TextBox ID="txtDoc" runat="server" AutoPostBack="True" Width="923px"></asp:TextBox>
                 <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/buscar.jpg" onclick="ImageButton1_Click" />

            </td>
        </tr>
    </table>
    
    <hr />
    
    <table>
    <tr>
    <td align="justify">
        &nbsp;</td>
    
    </tr>
    
    </table>
    <hr />
    <table>
    <tr>
    <td class="style16">
                        Folios </td>
                    <td>
                       
                        <asp:TextBox ID="TxtFolios" runat="server" Width="205px"></asp:TextBox>
                    </td>
    <td class="style16">
                        Anexos :</td>
                    <td>
                       
                        <asp:TextBox ID="txtAnexos" runat="server" Rows="3" TextMode="MultiLine" 
                            Width="406px"></asp:TextBox>
                       
                    </td>
    </tr>
    </table>

    <table style="width: 100%">
    <tr>
    <td class="style4">
    </td>
    <td class="style3">
    <asp:Label ID="Label5" runat="server" Text="AGREGAR INDICES DEl DOCUMENTO" 
                                    Visible="False"></asp:Label>
    
    </td>
    <td>
    </td>
    </tr>

    <tr>
    <td class="style4">
    </td>
    <td class="style3">
    
        <asp:ListBox ID="LstIndice" runat="server" Width="349px"></asp:ListBox>
    </td>
    <td>
    </td>
    </tr>
    <tr>
    <td class="style4">
    </td>
    <td class="style3">
        <asp:TextBox ID="txtIndice" runat="server" Width="256px"></asp:TextBox>
        <asp:Button ID="Button3"   runat="server" Text="Añadir" 
            onclick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Quitar" onclick="Button4_Click" />
    </td>
    <td>
    </td>
    </tr>                        
    
    </table>

    <hr />


    
    <table style="width: 100%">
    <tr>
    <td class="style2"></td>
    <td>
    
        <asp:Button ID="Button1" runat="server" Text="Registrar" Width="139px" 
            onclick="Button1_Click" />
    </td>
    
    
    
    <td>
    
        <asp:Button ID="Button2" runat="server" Text="Salir" style="margin-left: 0px" 
            Width="134px" onclick="Button2_Click" />
    </td>
    </tr>
    
    
    </table>


    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

     
</asp:Content>
