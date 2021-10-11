<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDocumentos.aspx.cs" Inherits="gestion_documental.ManageDocumentos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="header">
                <asp:Panel ID="pnlButtons" runat="server">
                    <%--<asp:Button ID="btnback" runat="server" Text="Back to Settings" CssClass="Button"
                        OnClick="btnback_Click" />--%>
                </asp:Panel>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="300">
                <ProgressTemplate>
                    <div class="Progress">
                        <div style="position: absolute; top: 50%; left: 25%;">
                            <img alt="" src="Images/ajax-loader.gif" style="margin-left: 200px" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            
                <br />
                <h1>
                    Documentos</h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                            <div style="width: 100%; float: right; display:none !important;">
                                <table style="margin: 0 auto;">
                                    
                                    
                                    <tr>
                                        <td>
                                            Serie<asp:RequiredFieldValidator ID="rvfddlSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSerie" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlSerie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            SubSerie<asp:RequiredFieldValidator ID="rfvddlSubSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSubSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubSerie" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlSubSerie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            Tipologia<asp:RequiredFieldValidator ID="rvfddlTipologia" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlTipologia" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTipologia" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTipologia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            Expediente<asp:RequiredFieldValidator ID="rvfddlExpediente" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlExpediente" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlExpediente" runat="server" CssClass="dropdown"></asp:DropDownList>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            Documento<asp:RequiredFieldValidator ID="rvftxtDocumento" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDocumento"  CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDocumento" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            Camino<asp:RequiredFieldValidator ID="rvftxtCamino" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCamino" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Documentos"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCamino" />
                                        </td>
                                    </tr>

                                       
                                    
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddDocumentos" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="Documentos"
                                                OnClick="btnAddDocumentos_Click" />
                                            <asp:Button ID="btnClearDocumentos" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearDocumentos_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvDocumentos" AutoGenerateColumns="False" EnableModelValidation="True"
                                    Width="100%" DataKeyNames="idDOCUMENTOS" OnSelectedIndexChanged="gvDocumentos_SelectedIndexChanged" OnRowDeleting="gvDocumentos_DeleteEventHandler" OnRowDataBound="gvShowDocumentos_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="idDOCUMENTOS" HeaderText="Id" />
                                        <asp:BoundField DataField="IDSERIE" HeaderText="Serie" />
                                        <asp:BoundField DataField="IDSUBSERIE" HeaderText="SubSerie" />
                                        <asp:BoundField DataField="IDTIPOLOGIA" HeaderText="Tipologia" />
                                        <asp:BoundField DataField="IDEXPEDIENTE" HeaderText="Expediente" />
                                        <asp:BoundField DataField="DOCUMENTO" HeaderText="Documento" />
                                        <asp:BoundField DataField="CAMINO" HeaderText="Camino" />
                                        
                                        <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="false" SelectText="Seleccionar" DeleteText="Eliminar">
         </asp:CommandField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>