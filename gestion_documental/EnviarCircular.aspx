<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnviarCircular.aspx.cs"
    Inherits="gestion_documental.EnviarCircular" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label runat="server" ID="Msj" Style="width: 100%"></asp:Label>
    <asp:HiddenField ID="hruta" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblescaner" Style="width: 100%"> </asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel2" runat="server" GroupingText="Enviar circular">
        <table border="0" style="width: 100%; text-align: left;" cellspacing="0">
            <tr>
                <td>
                    Radicado
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtRadicado" runat="server" ReadOnly="true" Enabled="true"></asp:TextBox>
                    <asp:ImageButton ID="btn_buscarcircular" runat="server" Height="30px" ImageUrl="~/Images/Preview-icon.png"
                        Width="29px" OnClick="btn_buscarcircular_Click" />
                    <asp:HiddenField ID="hidde_id_circular" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 5%;">
                    De :
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlDe" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 5%;">
                    Para :
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlPara" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ListBox ID="LstDestinos" runat="server" Width="407px"></asp:ListBox>
                </td>
            </tr>
            <tr style="text-align: left;">
                <td>
                </td>
                <td colspan="2">
                </td>
                <td>
                    <asp:Button ID="btn_agregar_envio" runat="server" Text="Agregar" OnClick="btn_agregar_envio_Click" />
                    <asp:Button ID="btn_quitar_envio" runat="server" Text="Quitar" OnClick="btn_quitar_envio_Click" />
                </td>
            </tr>
        </table>
        <br />
        <table border="0" style="width: 100%; text-align: left;" cellspacing="0">
            <tr>
                <td style="width: 50px;">
                    Asunto
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txt_Asunto" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
                </td>
            </tr>
            <%-- <tr>
                <td style="width: 60px;">
                    Observaciones
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtObservacion" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <asp:UpdatePanel ID="update_archivo" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_enviar" />
                </Triggers>
                <ContentTemplate>
                    <tr>
                        <td colspan="4" style="text-align: right;">
                            <asp:FileUpload ID="FileUpload1" runat="server" accept="application/pdf"></asp:FileUpload>
                        </td>
                    </tr>
                    <tr style="text-align: center;">
                        <td colspan="4">
                            <asp:Button ID="btn_enviar" runat="server" Text="Enviar Circular" OnClick="btn_enviar_Click" />
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:UpdatePanel>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="PanelModal" runat="server" Style="display: ; background: white; width: 60%;
        height: 80%" BorderColor="Blue" BorderStyle="Double">
        <div align="center">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="Txtbuscarenelpanel" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btbuscarenelpanel" runat="server" Text="buscar" Width="100px" OnClick="btbuscarenelpanel_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" Width="100px" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div>
            <asp:GridView ID="gvpanel" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Style="margin-right: 570px" Width="99%" DataKeyNames="id,consecutivo" AllowPaging="True"
                Height="16px" PageSize="10" AutoGenerateColumns="false" OnPageIndexChanging="gvpanel_PageIndexChanging"
                OnSelectedIndexChanged="gvpanel_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="plantilla" HeaderText="PLANTILLA" />
                    <asp:BoundField DataField="consecutivo" HeaderText="CONSECUTIVO" />
                    <asp:BoundField DataField="fecha" HeaderText="FECHA DE REGISTRO" />
                    <asp:CommandField ShowSelectButton="True" SelectText="SELECIONAR" />
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
            <div>
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" PopupControlID="PanelModal" TargetControlID="HiddenField2">
                </asp:ModalPopupExtender>
            </div>
    </asp:Panel>
</asp:Content>
