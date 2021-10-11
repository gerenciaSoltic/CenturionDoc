<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageRadicados.aspx.cs" Inherits="gestion_documental.ManageRadicados" %>

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
                    Radicados</h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                            <div style="width: 100%; float: right;">
                                <table style="margin: 0 auto;">

                                    <tr>
                                        <td>
                                            conseInt<asp:RequiredFieldValidator ID="rfvtxtConseInt" runat ="server" SetFocusOnError="true" ControlToValidate ="txtConseInt" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtConseInt" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            ConseExtSal<asp:RequiredFieldValidator ID="rvftxtConseExtSal" runat ="server" SetFocusOnError="true" ControlToValidate ="txtConseExtSal" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtConseExtSal" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            ConseExtent<asp:RequiredFieldValidator ID="rvftxtConseExtent" runat ="server" SetFocusOnError="true" ControlToValidate ="txtConseInt" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtConseExtent" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            prefInter<asp:RequiredFieldValidator ID="rvftxtprefInter" runat ="server" SetFocusOnError="true" ControlToValidate ="txtprefInter" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtprefInter" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            PrefExtSal<asp:RequiredFieldValidator ID="rvftxtPrefExtSal" runat ="server" SetFocusOnError="true" ControlToValidate ="txtPrefExtSal" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPrefExtSal" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            PrefExtEnt<asp:RequiredFieldValidator ID="rvftxtPrefExtEnt" runat ="server" SetFocusOnError="true" ControlToValidate ="txtPrefExtEnt" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPrefExtEnt" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            UltimaFecha<asp:RequiredFieldValidator ID="rvftxtUltimaFecha" runat ="server" SetFocusOnError="true" ControlToValidate ="txtUltimaFecha" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Radicados"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtUltimaFecha" />
                                            <asp:CalendarExtender ID="CalendarExtender1" Format="d-MM-yyyy" TargetControlID="txtUltimaFecha" runat="server"></asp:CalendarExtender>  
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddRadicados" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="Radicados"
                                                OnClick="btnAddRadicados_Click" />
                                            <asp:Button ID="btnRadicadosClear" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearRadicados_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>


                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvRadicados" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="idradicados" 
                                    OnSelectedIndexChanged="gvRadicados_SelectedIndexChanged" 
                                    OnRowDeleting="gvRadicados_DeleteEventHandler" 
                                    OnRowDataBound="gvShowRadicados_RowDataBound" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>                                        
                                        <asp:BoundField DataField="IDRadicados" HeaderText="Id" />
                                        <asp:BoundField DataField="conseInt" HeaderText="conseInt" />
                                        <asp:BoundField DataField="ConseExtSal" HeaderText="ConseExtSal" />
                                        <asp:BoundField DataField="ConseExtent" HeaderText="ConseExtent" />
                                        <asp:BoundField DataField="prefInter" HeaderText="prefInter" />
                                        <asp:BoundField DataField="PrefExtSal" HeaderText="PrefExtSal" />
                                        <asp:BoundField DataField="PrefExtEnt" HeaderText="PrefExtEnt" />
                                        <asp:BoundField DataField="UltimaFecha" HeaderText="UltimaFecha" />
                                        <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seeleccionar" DeleteText="Eliminar">
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