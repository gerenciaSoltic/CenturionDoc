<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageEmiRecep.aspx.cs" Inherits="gestion_documental.ManageEmiRecep" %>

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
                    Emisores / Receptores</h1>
            <br />
            <div style="overflow: hidden;">
                <div style="width: 100%; float: right;">
                    <table style="margin: 0 auto;">
                        <tr>
                            <td>
                                    Nit<asp:RequiredFieldValidator ID="rfvtxtNit" runat ="server" SetFocusOnError="true" ControlToValidate ="txtNit" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNit" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Descripcion<asp:RequiredFieldValidator ID="rvftxtDescripcion" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDescripcion" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDescripcion" Width="423px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Direccion Fisica<asp:RequiredFieldValidator ID="rvftxtDireccionFisica" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDireccionFisica" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDireccionFisica" Width="424px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Pais<asp:RequiredFieldValidator ID="rfvddlPais" runat ="server" SetFocusOnError="true" ControlToValidate="ddlPais" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="dropdown" Width="242px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Departamento<asp:RequiredFieldValidator ID="rvfddlDepartamento" runat ="server" SetFocusOnError="true" ControlToValidate="ddlDepartamento" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="dropdown" 
                                        Width="245px" AutoPostBack="True" 
                                    onselectedindexchanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Municipio<asp:RequiredFieldValidator ID="fvrddlMunicipio" runat ="server" SetFocusOnError="true" ControlToValidate="ddlMunicipio" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlMunicipio" runat="server" CssClass="dropdown" 
                                        Height="16px" Width="238px" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Email<asp:RequiredFieldValidator ID="rvftxtEmail" runat ="server" SetFocusOnError="true" ControlToValidate ="txtEmail" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail" Height="24px" Width="438px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Telefono<asp:RequiredFieldValidator ID="rvftxtTelefono" runat ="server" SetFocusOnError="true" ControlToValidate ="txtTelefono" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTelefono" Width="247px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Codigo Usuario:
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="dropdown" 
                                        Height="16px" Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Tipo Emisor<asp:RequiredFieldValidator ID="rvfddlTipoEmisor" runat ="server" SetFocusOnError="true" ControlToValidate="ddlTipoEmisor" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="EmiRecep" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoEmisor" runat="server" CssClass="dropdown" 
                                        Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    ConfiCor:
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlConfiCor" runat="server" CssClass="dropdown" 
                                        Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Oficina productora:
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlEnte" runat="server" CssClass="dropdown" Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Cargo:
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlCargo" runat="server" CssClass="dropdown" 
                                        Height="19px" Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Radicado:
                                </td>
                            <td>
                                <asp:DropDownList ID="ddlRadicado" runat="server" CssClass="dropdown" 
                                        Height="26px" Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button runat="server" ID="btnAddEmiRecep" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="EmiRecep"
                                        OnClick="btnAddEmiRecep_Click" />
                                <asp:Button ID="btnClearEmiRecep" runat="server" CssClass="cancelButton" Text="Limpiar"
                                        OnClick="btnClearEmiRecep_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TxtBuscar" runat="server" Width="777px"></asp:TextBox>
                                <asp:Button ID="Button1"
                            runat="server" Text="Buscar" onclick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Log" style="width: 100%; float: left;">
                    <asp:GridView runat="server" ID="gvEmiRecep" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="id" 
                            OnSelectedIndexChanged="gvEmiRecep_SelectedIndexChanged"  
                            OnRowDeleting="gvEmiRecept_DeleteEventHandler" 
                            OnRowDataBound="gvShowEmiRecept_RowDataBound" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="NIT" HeaderText="NIT" />
                            <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                            <asp:BoundField DataField="DEPARTAMENTO" HeaderText="Departament" />
                            <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" />
                            <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                            <asp:BoundField DataField="FOTO" HeaderText="Foto" />
                            <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                            <asp:BoundField DataField="CODIGOUSUARIO" HeaderText="Usuario" />
                            <asp:BoundField DataField="IDTIPOEMISOR" HeaderText="Tipo Emisor" />
                            <asp:BoundField DataField="IDCONFICOR" HeaderText="ConfiCor" />
                            <asp:BoundField DataField="IDENTE" HeaderText="Ente" />
                            <asp:BoundField DataField="IDCARGO" HeaderText="Cargo" />
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
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .dropdown
        {}
    </style>
</asp:Content>
