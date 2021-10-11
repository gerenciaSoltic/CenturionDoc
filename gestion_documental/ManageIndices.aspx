<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageIndices.aspx.cs" Inherits="gestion_documental.ManageIndices" %>

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
                    Indices</h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                            <div style="width: 100%; float: right;">
                                <table style="margin: 0 auto;">
                                    
                                    <tr>
                                        <td>
                                            Documentos<asp:RequiredFieldValidator ID="rfvddlDocumentos" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlDocumentos" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Indices" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDocumentos" runat="server" CssClass="dropdown"></asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            Indice<asp:RequiredFieldValidator ID="rfvtxtIndice" runat ="server" SetFocusOnError="true" ControlToValidate ="txtIndice" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Indices"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtIndice" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddIndices" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="Indices"
                                                OnClick="btnAddIndices_Click" />
                                            <asp:Button ID="btnClearIndices" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearIndices_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvIndices" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="idINDICES" 
                                    OnSelectedIndexChanged="gvIndices_SelectedIndexChanged" 
                                    OnRowDeleting="gvIndices_DeleteEventHandler" 
                                    OnRowDataBound="gvShowIndices_RowDataBound" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>                                        
                                        <asp:BoundField DataField="idINDICES" HeaderText="Id" />
                                        <asp:BoundField DataField="iddocumento" HeaderText="Documento" />
                                        <asp:BoundField DataField="INDICE" HeaderText="INDICE" />
                                        <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seleccionar" DeleteText="Eliminar">
         </asp:CommandField>
                                        
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
                            </div>

                        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>