<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encriptar.aspx.cs" Inherits="gestion_documental.Encriptar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Msj" TagName="Mensajes" Src="~/Mensajes.ascx" %>

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
            <h1>
                    Usuarios Encriptar</h1>
            <br />
            <div style="overflow: hidden;">

                                
                <div class="Log" style="width: 100%; float: left;">
                    <asp:GridView runat="server" ID="gvUsuario" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="CODIGO" 
                            OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged" 
                            OnRowDataBound="gvShowUsuario_RowDataBound" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" PageSize="3">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CODIGO" HeaderText="CODIGO" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                            <asp:BoundField DataField="USUARIO" HeaderText="Usuario" />
                            <asp:BoundField DataField="CONTRASENA" HeaderText="Contraseña" />
                            <asp:BoundField DataField="ACTIVO" HeaderText="Activo" />
                            <asp:BoundField DataField="USUARIOWIN" HeaderText="Active Directory" />
                            <asp:BoundField DataField="CORREOELECTRONICO" HeaderText="Correo Electronico" />
                            <asp:BoundField DataField="CONTRASENACORREO" HeaderText="Contrasena Correo" />
                             <asp:BoundField DataField="ROL" HeaderText="Rol" />
                            <asp:CommandField HeaderText="Opciones" CausesValidation="true" 
                                ShowSelectButton="true" SelectText="Seleccionar" DeleteText="Eliminar">
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
                <br />

                <div style="width: 100%; float: right;">
                    <table style="margin: 0 auto; width: 281px;">
                        <tr>
                            <td class="style1">
                                &nbsp;</td>
                            <td class="style1">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="BtnListar" runat="server" CausesValidation="true" 
                                    CssClass="submitButton" OnClick="btnListar_Click" Text="Listar" 
                                    ValidationGroup="Usuario" ToolTip="Listar Usuarios" Width="75px" />
                                <asp:Button ID="BtnLimpiar" runat="server" CssClass="cancelButton" 
                                    OnClick="BtnLimpiar_Click" Text="Limpiar" Width="69px" />
                                <asp:Button ID="BtnEncriptar" runat="server" CausesValidation="true" 
                                    OnClick="BtnEncriptar_Click" Text="Encriptar" 
                                    ToolTip="Encriptar Las Contraseñas" />
                            </td>
                        </tr>
                    </table>
                </div>

                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

            <%--llamada de control de usuario--%>
    <asp:UpdatePanel ID="upPnlPage" runat="server">
        <ContentTemplate>
            <Msj:Mensajes ID="omb" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .submitButton
        {}
        .cancelButton
        {}
    </style>
</asp:Content>

