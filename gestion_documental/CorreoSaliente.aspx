<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CorreoSaliente.aspx.cs" Inherits="gestion_documental.CorreoSaliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/JavaScript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script language="javascript" type="text/javascript">
       
    </script>

   
    <style type="text/css">
       
        .style1
        {
            width: 26%;
        }
       
    </style>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label runat="server" ID="title" Text="PlanSide" Style="width: 100%"/>
    <asp:HiddenField ID="HiddenField1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellpadding="10" width="100%">
        <tr>
            <td>
                <asp:Panel ID="PanelGeneral" runat="server" Width="100%" Height="100%" CssClass="panel" GroupingText="Correo Saliente">
                    <table width="100%" border="0" cellspacing="10">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="ParaLabel" runat="server" Width="40px" CssClass="label" Text="Para"></asp:Label>
                            </td>
                            <td width="90%">
                                <asp:DropDownList ID="DdlEmisor" runat="server" Height="16px" 
                                    Width="425px" AutoPostBack="True" 
                                    onselectedindexchanged="DdlEmisor_SelectedIndexChanged" 
                                    ontextchanged="DdlEmisor_TextChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label1" runat="server" Text="Correo" CssClass="label" 
                                    Font-Size="Smaller"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="302px" 
                                    AutoPostBack="True"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="AsuntoLabel" runat="server" Width="40px" CssClass="label" Text="Asunto"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AsuntoTextBox" Width="100%" runat="server" CssClass="textBox" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <textarea id="Mensaje" runat="server" name="elm1" rows="15" cols="80" style="width: 100%" ></textarea>
                            </td>
                        </tr>
                        <tr>
                           
                            </td>
                        </tr>
                        <tr>
                    <td align="center" class="style1">
                    <table width="100px" style="width: 508px">
                        <tr>
            <td>
                <asp:Label ID="LblRadicado" runat="server" Text="Radicado:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtRadicado" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
    <td>

    <asp:Label ID="LblSerie" runat="server" Text="Serie:"></asp:Label>
    </td>

    <td>
        <asp:DropDownList ID="DdlSerie" runat="server" Width="328px" 
            AutoPostBack="True" DataTextField="SERIE" DataValueField="ID" Enabled="True" 
            onselectedindexchanged="DdlSerie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Llbl" runat="server" Text="SubSerie:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DdlSubserie" runat="server" Width="302px" 
            AutoPostBack="True" DataTextField="SUBSERIE" DataValueField="ID" 
            Enabled="False" onselectedindexchanged="DdlSubserie_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
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
    <tr>
    <td>
    <asp:Label ID="LblExpediente" runat="server" Text="Expediente:"></asp:Label>
    </td>
    <td>
    <asp:DropDownList ID="DdlExpediente" runat="server" Width="508px" Height="16px" 
            AutoPostBack="True" DataTextField="DESCRIPCION" DataValueField="ID" 
            Enabled="False" 
            onselectedindexchanged="DdlExpediente_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
     <td height="10px" colspan="2">
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
                        <asp:FileUpload runat="server" ID="fuImagem" accept=".PNG"  />
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="BtnEnviar" />
                    </Triggers>
                </asp:UpdatePanel>
                </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table width="200px">
                                    <tr>
                                        <td>
                                            <asp:Button ID="BtnEnviar" runat="server" onclick="BtnEnviar_Click" 
                                                Text="Enviar" />
                                        </td>
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10px" colspan="2">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
   
</asp:Content>

