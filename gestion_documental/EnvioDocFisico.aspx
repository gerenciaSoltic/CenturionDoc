<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvioDocFisico.aspx.cs" Inherits="gestion_documental.EnvioDocFisico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<style type="text/css">
        .style5
        {
            width: 115px;
        }
        .style8
        {
            height: 53px;
        }
        .style16
        {
            width: 213px;
        }
        .style19
        {
            width: 278px;
        }
        .style20
        {
            width: 97px;
        }
        .style21
        {
            width: 153px;
        }
        .style22
        {
            width: 126px;
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
    <asp:HiddenField ID="hruta" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblescaner" Style="width: 100%" > </asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" GroupingText="Envío Documento Físico">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%; padding: 25px;">
                <tr>
                    <td class="style5">
                        De <asp:RequiredFieldValidator ID="rvfddlDe" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlDe" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="RecepDoc" InitialValue="0"></asp:RequiredFieldValidator>:
                    </td>
                    <td class="style19">
                        <asp:DropDownList ID="ddlDe" runat="server" 
                            onselectedindexchanged="ddlDe_SelectedIndexChanged" AutoPostBack="True" 
                            Width="200px" DataTextField="DESCRIPCION" DataValueField="IDENTE">
                        </asp:DropDownList>
                    </td>
                    <td class="style20">
                        Para <asp:RequiredFieldValidator ID="rvfddlPara" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlPara" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="RecepDoc" InitialValue="0"></asp:RequiredFieldValidator>:</td>
                    <td class="style16">
                        &nbsp;<asp:DropDownList ID="ddlPara" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlPara_SelectedIndexChanged" Width="213px" 
                            DataTextField="DESCRIPCION" DataValueField="IDENTE">
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    
                    <td class="style8" colspan="4">
                    <asp:RequiredFieldValidator ID="rvftxtDoc" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDoc" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="RecepDoc" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:Button ID="btnescaner" runat="server" onclick="btnescaner_Click" 
                            Text="Escanear" />
                        <asp:TextBox ID="txtDoc" runat="server" Width="491px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="btnPrevio" runat="server" Height="30px" 
                            ImageUrl="~/Images/Preview-icon.png" onclick="btnPrevio_Click" Width="29px" />
                    </td>
                    
                </tr>
                
                <tr>
                    
                <td>
                    <asp:Label ID="LblEmirecep" runat="server" Text="Para :"></asp:Label>
                    </td>
                    <td>
                <asp:DropDownList ID="DdlEmisor" runat="server" DataTextField="DESCRIPCION" 
                            DataValueField="ID" Width="243px">
                    </asp:DropDownList>
                   
                </td>
                </tr>

                <tr>
                    <td class="style5">
                        Radicado <asp:RequiredFieldValidator ID="rvftxtRadicado" runat ="server" SetFocusOnError="true" ControlToValidate ="txtRadicado" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="RecepDoc" InitialValue=""></asp:RequiredFieldValidator>:
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="txtRadicado" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="style16">
                        Folios </td>
                    <td>
                       
                        <asp:TextBox ID="TxtFolios" runat="server" Width="205px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        Anexos :</td>
                    <td>
                       
                        <asp:TextBox ID="txtAnexos" runat="server" Rows="3" TextMode="MultiLine" 
                            Width="225px"></asp:TextBox>
                       
                    </td>
                    <td class="style16">
                        Observaciones :</td>
                    <td>
                       
                        <asp:TextBox ID="TxtObservacion" runat="server" Rows="3" TextMode="MultiLine" 
                            Width="225px"></asp:TextBox>
                       
                    </td>
                </tr>
                
              </table>
              <hr />
              
              <table style="width: 611px">
              <tr>
              <td>
              </td>
              <td class="style22">
                <asp:Label ID="LblSemaforo" runat="server" Text="Tipo de Comunicación"></asp:Label>
               </td>
               <td>
            <asp:DropDownList ID="DmpSemaforo" runat="server" Height="16px" Width="183px">
            </asp:DropDownList>
            </td>
            </td>
              <td>
            </tr>

            </table>

              <hr />
              <table style="width: 100%">
    <tr>
    <td class="style4">
    </td>
    <td class="style3">
        <asp:ListBox ID="lista" runat="server" Width="550px" Visible="False"></asp:ListBox>
    </td>
    <td>
    </td>
    </tr>
    <tr>
    <td class="style4">
    </td>
    <td class="style3">
        <asp:TextBox ID="TxtIndice" runat="server" Width="301px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="Adicionar Indice" 
            UseSubmitBehavior="False" onclick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Quitar Indice" 
            onclick="Button4_Click" />

    </td>
    <td>
    </td>
    
    
    </tr>
    </table>
    <hr />

              <table style="width: 615px">
              
              <tr>
                    
                   
                    <td>
                    </td>
                    <td class="style21">
                        <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" CssClass="submitButton" CausesValidation="true" ValidationGroup="RecepDoc"
                            Text="Guardar" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Deshacer" 
                            onclick="btnEliminar_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
              </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
