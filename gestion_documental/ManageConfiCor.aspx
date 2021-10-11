<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageConfiCor.aspx.cs" Inherits="gestion_documental.ManageConfiCor" %>

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
                    Configuracion de Correos</h1>
                <br />
                <div style="overflow: hidden;">
                    
                    <div style="width: 100%; float: right;">
                        <table style="margin: 0 auto;">
                                    
                            <tr>
                                <td>
                                    Email<asp:RequiredFieldValidator ID="rfvtxtEmail" runat ="server" SetFocusOnError="true" ControlToValidate ="txtEmail" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtEmail" Width="420px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Contraseña<asp:RequiredFieldValidator ID="rvftxtContrasena" runat ="server" SetFocusOnError="true" ControlToValidate ="txtContrasena" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtContrasena" Width="177px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Serv. POP Saliente<asp:RequiredFieldValidator ID="rvftxtServPopSaliente" runat ="server" SetFocusOnError="true" ControlToValidate ="txtServPopSaliente" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtServPopSaliente" Width="424px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Serv. POP Entrante<asp:RequiredFieldValidator ID="rvftxtServPopEntrante" runat ="server" SetFocusOnError="true" ControlToValidate ="txtServPopEntrante" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtServPopEntrante" Width="421px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Camino de Descarga<asp:RequiredFieldValidator ID="rvftxtCaminoDescarga" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCaminoDescarga" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCaminoDescarga" Width="420px" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    Caminos Escaner<asp:RequiredFieldValidator ID="rvftxtCaminosEscaner" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCaminosEscaner" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCaminosEscaner" Width="421px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Software Escaner<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCaminosEscaner" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSoftEscaner" runat="server"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Carpeta Temporal<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCaminosEscaner" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtCarpetaTemporal" runat="server"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Fecha Arranque Correo<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat ="server" SetFocusOnError="true" ControlToValidate ="txtCaminosEscaner" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="ConfiCor" InitialValue=""></asp:RequiredFieldValidator>:
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtFechaArranque" runat="server"></asp:TextBox>
                                     <asp:CalendarExtender ID="CalendarExtender2" Format="YYYY-MM-DD" TargetControlID="TxtFechaArranque" runat="server">
                                </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                            
                                </td>
                                <td align="center">
                                    <asp:Button runat="server" ID="btnAddConfiCor" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="ConfiCor"
                                        OnClick="btnAddConfiCor_Click" />
                                    <asp:Button ID="btnClearConfiCor" runat="server" CssClass="cancelButton" Text="Limpiar"
                                        OnClick="btnClearConfiCor_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <div class="Log" style="width: 100%; float: left;">
                        <asp:GridView runat="server" ID="gvConfiCor" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="id" 
                            OnSelectedIndexChanged="gvConfiCor_SelectedIndexChanged" 
                            OnRowDeleting="gvConfiCor_DeleteEventHandler" 
                            OnRowDataBound="gvShowConfiCor_RowDataBound" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                               
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                                <asp:BoundField DataField="SERVPOPSALIENTE" HeaderText="POP Saliente" />
                                <asp:BoundField DataField="SERVPOPENTRANTE" HeaderText="POP Entrante" />
                                <asp:BoundField DataField="CAMINODESCARGA" HeaderText="Camino De Descarga" />
                                <asp:BoundField DataField="caminoscanner" HeaderText="Camino Escaner" />
                                <asp:BoundField DataField="softescaner" HeaderText="Software Escaner" />
                                <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seleccionar" DeleteText="Eliminar"></asp:CommandField>
                                        
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