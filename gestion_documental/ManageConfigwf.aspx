<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageConfigwf.aspx.cs" Inherits="gestion_documental.ManageConfigwf" %>

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
            <h1>Configuracion Work Flow</h1>
            <br />
            <div style="overflow: hidden;">
                <div style="width: 100%; float: right;">
                    <table style="margin: 0 auto;">
                        <tr>
                            <td>Ente<asp:RequiredFieldValidator ID="rfvddlEnte" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlEnte" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlEnte" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Serie<asp:RequiredFieldValidator ID="rvfddlSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlSerie" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlSerie_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>SubSerie<asp:RequiredFieldValidator ID="rfvddlSubSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSubSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlSubSerie" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlSubSerie_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Tipologia<asp:RequiredFieldValidator ID="rvfddlTipologia" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlTipologia" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlTipologia" runat="server" CssClass="dropdown" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Orden<asp:RequiredFieldValidator ID="rfvtxtOrden" runat ="server" SetFocusOnError="true" ControlToValidate ="txtOrden"  CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtOrden" />
                            </td>
                        </tr>
                        <tr>
                            <td>Dias<asp:RequiredFieldValidator ID="rvftxtDias" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDias" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDias" />
                            </td>
                        </tr>
                        <tr>
                            <td>Tarea<asp:RequiredFieldValidator ID="rvfddlTarea" runat ="server" SetFocusOnError="true" ControlToValidate="ddlTarea" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlTarea" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Proceso<asp:RequiredFieldValidator ID="rvfddlProceso" runat ="server" SetFocusOnError="true" ControlToValidate="ddlProceso" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlProceso" runat="server" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Actividad<asp:RequiredFieldValidator ID="rvfddlActividad" runat ="server" SetFocusOnError="true" ControlToValidate="ddlActividad" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlActividad" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Asignado A<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" SetFocusOnError="true" ControlToValidate="ddlActividad" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Configwf" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td>
                                <asp:DropDownList ID="ddlEmirecep" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <asp:Button runat="server" ID="btnAddConfigwf" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="Configwf"
                                                OnClick="btnAddConfigwf_Click" />
                                <asp:Button ID="btnClearConfigwf" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearConfigwf_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Log" style="width: 100%; float: left;">
                    <asp:GridView runat="server" ID="gvConfigwf" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="id" 
                                    OnSelectedIndexChanged="gvConfigwf_SelectedIndexChanged" 
                                    OnRowDeleting="gvConfigwf_DeleteEventHandler" 
                                    OnRowDataBound="gvShowConfigwf_RowDataBound" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" />
                            <asp:BoundField DataField="IDENTE" HeaderText="Ente" />
                            <asp:BoundField DataField="IDSUBSERIE" HeaderText="SubSerie" />
                            <asp:BoundField DataField="IDTIPOLOGIA" HeaderText="Tipologia" />
                            <asp:BoundField DataField="ORDEN" HeaderText="Orden" />
                            <asp:BoundField DataField="DIAS" HeaderText="Dias" />
                            <asp:BoundField DataField="IDTAREA" HeaderText="Tarea" />
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