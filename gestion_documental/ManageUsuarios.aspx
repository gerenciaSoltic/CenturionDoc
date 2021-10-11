<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageUsuarios.aspx.cs" Inherits="gestion_documental.ManageUsuarios" %>

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
                    Usuarios</h1>
            <br />
            <div style="overflow: hidden;">
                <div style="width: 100%; float: right;">
                    <table style="margin: 0 auto;">
                        <tr>
                            <td>
                                    Nombre<asp:RequiredFieldValidator ID="rfvtxtNombre" runat ="server" SetFocusOnError="true" ControlToValidate ="txtNombre" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Usuario" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNombre" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Usuario<asp:RequiredFieldValidator ID="rvftxtUsuario" runat ="server" SetFocusOnError="true" ControlToValidate ="txtUsuario" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Usuario" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUsuario" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    Contraseña<asp:RequiredFieldValidator ID="rvftxtDireccionFisica" runat ="server" SetFocusOnError="true" ControlToValidate ="txtContrasena" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Usuario" InitialValue=""></asp:RequiredFieldValidator>
                                :
                                </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtContrasena" input type="password" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblCorreoElectronico" runat="server" Text="Correo Electronico"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCorreoElectronico" runat="server" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtCorreoElectronico" ErrorMessage="Email is required"
                                SetFocusOnError="True" ></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ErrorMessage="Invalid Email" ControlToValidate="txtCorreoElectronico"
                                    SetFocusOnError="True"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    ValidationGroup="Usuario"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblContrasenaCorreo" runat="server" Text="Contraseña Correo"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContrasenaCorreo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Activo<asp:RequiredFieldValidator ID="rfvddlActivo" runat="server" 
                                    ControlToValidate="ddlActivo" CssClass="errorMessage" ErrorMessage="*" 
                                    InitialValue="0" SetFocusOnError="true" ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlActivo" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rol :<asp:RequiredFieldValidator ID="rfvddlRol" runat="server" 
                                    ControlToValidate="ddlRol" CssClass="errorMessage" ErrorMessage="*" 
                                    InitialValue="0" SetFocusOnError="true" ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRol" runat="server" CssClass="dropdown" Height="16px" 
                                    Width="126px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblActiveDirectory" runat="server" 
                                    Text="Listar Usuarios Windows"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkActiveDirectory" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="ChkActiveDirectory_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblGrupo" runat="server" Text="Grupo   Windows   :" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGruposWindows" runat="server" CssClass="dropdown" 
                                    Height="16px" Visible="False" Width="126px">
                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    ImageUrl="~/Images/lens_16x16.png" onclick="ImageButton1_Click" 
                                    ToolTip="Buscar Usuarios Windows" Visible="False" Height="25px" 
                                    Width="24px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblUsuario" runat="server" Text="Usuarios   Windows     :" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtUsuarioWin" runat="server" Enabled="False" Font-Bold="True" 
                                    Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
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
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                            
                                    &nbsp;</td>
                            <td align="center">
                                <asp:Button ID="btnAddUsuario" runat="server" CssClass="submitButton" Text="Añadir"
                                        OnClick="btnAddUsuario_Click" CausesValidation="true" 
                                    ValidationGroup="Usuario" />
                                <asp:Button ID="btnClearUsuario" runat="server" CssClass="cancelButton" 
                                    OnClick="btnClearUsuario_Click" Text="Limpiar" />
                                <asp:Button ID="btnSincroniza" runat="server" CausesValidation="true" 
                                    OnClick="btnSincroniza_Click" Text="Sincronizar" 
                                    ToolTip="Sincronizador Usuarios Windows Por Grupos" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Log" style="width: 100%; float: left;">
                    <asp:GridView runat="server" ID="gvUsuario" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="CODIGO" 
                            OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged" 
                            OnRowDeleting="gvUsuario_DeleteEventHandler" 
                            OnRowDataBound="gvShowUsuario_RowDataBound" CellPadding="4" ForeColor="#333333" 
                            GridLines="None">
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
                    <asp:Panel ID="PnlUsuariosAvtiveDirectory" runat="server" align="center" 
                        Width="100%" Visible="False">
                        <div align="center" style="width: 100%">
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                            Text="Usuarios Windows"></asp:Label>
                            <br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                            AllowSorting="True" AutoGenerateColumns="False" 
                                            DataKeyNames="UserName,DisplayName,Company,Deparment,JobTitle,Email,Phone,Mobile" 
                                            ForeColor="#333333" GridLines="None" 
                                            onpageindexchanging="GridView1_PageIndexChanging" 
                                            onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                            ShowHeaderWhenEmpty="True" Width="100%" CellPadding="4" 
                                PageSize="1000">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                    <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" />
                                    <asp:BoundField DataField="Company" HeaderText="Company" />
                                    <asp:BoundField DataField="Deparment" HeaderText="Deparment" />
                                    <asp:BoundField DataField="JobTitle" HeaderText="JobTitle" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                    <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" />
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
                    </asp:Panel>
                </div>
                <br />
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
        .dropdown
        {}
        .style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
