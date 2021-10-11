<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RecepDocFisico.aspx.cs" Inherits="gestion_documental.RecepDocFisico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style5
        {
            width: 115px;
        }
        .style16
        {
            width: 213px;
        }
        .style19
        {
            width: 278px;
        }
        .style21
        {
            width: 153px;
        }
        .style25
        {
            width: 647px;
        }
        
        .container
        {
            margin: 20px;
        }
        .type-css
        {
            color: red;
        }
        .type-js
        {
            color: blue;
        }
        .row
        {
            margin: 5px;
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
            <asp:Label runat="server" ID="lblescaner" Style="width: 100%"> </asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Recepción Documento Físico">
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <table style="width: 100%; padding: 25px;">
            <caption>
                <br />
                <tr>
                    <td>
                        De
                        <asp:RequiredFieldValidator ID="rvfddlDe" runat="server" ControlToValidate="ddlDe"
                            CssClass="errorMessage" ErrorMessage="*" InitialValue="0" SetFocusOnError="true"
                            ValidationGroup="RecepDoc"></asp:RequiredFieldValidator>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDe" runat="server" AutoPostBack="True" Height="29px" OnSelectedIndexChanged="ddlDe_SelectedIndexChanged"
                            Width="413px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        Para
                        <asp:RequiredFieldValidator ID="rvfddlPara" runat="server" ControlToValidate="ddlPara"
                            CssClass="errorMessage" ErrorMessage="*" InitialValue="0" SetFocusOnError="true"
                            ValidationGroup="RecepDoc"></asp:RequiredFieldValidator>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPara" runat="server" AutoPostBack="True" Height="29px" OnSelectedIndexChanged="ddlPara_SelectedIndexChanged"
                            Width="413px">
                        </asp:DropDownList>
                        <asp:Button ID="Button6" runat="server" Text="Agregar" OnClick="Button6_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblEmirecep" runat="server" Text="Emisor :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="DdlEmisor" runat="server" Width="33px"></asp:TextBox>
                        <asp:TextBox ID="TxtNomemisor" runat="server" Enabled="False" Width="294px"></asp:TextBox>
                        <asp:TextBox ID="txtMail" runat="server" Width="336px" AutoPostBack="True" Enabled="False"></asp:TextBox>
                        <asp:ImageButton ID="btnBuscaEmisor" runat="server" Height="30px" ImageUrl="~/Images/Preview-icon.png"
                            OnClick="btnBuscaEmisor_Click" Width="29px" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Emisor" />
                    </td>
                    <td>
                        <table id="tablaMas">
                            <tr>
                                <td>
                                    <asp:ListBox ID="LstDestinos" runat="server" Width="407px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="Quitar" OnClick="Button7_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        Radicado
                        <asp:RequiredFieldValidator ID="rvftxtRadicado" runat="server" ControlToValidate="txtRadicado"
                            CssClass="errorMessage" ErrorMessage="*" InitialValue="" SetFocusOnError="true"
                            ValidationGroup="RecepDoc"></asp:RequiredFieldValidator>
                        :
                    </td>
                    <td class="style19">
                        <asp:TextBox ID="txtRadicado" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style16" align="right">
                        Folios
                    </td>
                    <td>
                        <asp:TextBox ID="TxtFolios" runat="server" Width="205px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        Anexos :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnexos" runat="server" Rows="3" TextMode="MultiLine" Width="225px"></asp:TextBox>
                    </td>
                    <td class="style16" align="right">
                        Asunto :
                    </td>
                    <td>
                        <asp:TextBox ID="TxtObservacion" runat="server" Rows="3" TextMode="MultiLine" Width="225px"
                            OnTextChanged="TxtObservacion_TextChanged"></asp:TextBox>
                    </td>
                </tr>
            </caption>
        </table>
        <hr />
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Grupo de Comunicaciones"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDLGrupoCom" runat="server" AutoPostBack="True" Height="23px"
                        OnSelectedIndexChanged="DDLGrupoCom_SelectedIndexChanged" Width="309px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="LblSemaforo" runat="server" Text="Tipo de Comunicación"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DmpSemaforo" runat="server" Height="23px" Width="354px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <hr />
        <hr />
        <table style="width: 100%">
            <tr>
                <td class="style4">
                </td>
                <td class="style25">
                    <asp:ListBox ID="lista" runat="server" Width="646px" Height="137px"></asp:ListBox>
                </td>
                <td>
                    <table border="1">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" Text="RESPUESTA" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="RADICADO:"></asp:Label><asp:TextBox ID="TextBox1"
                                    runat="server"></asp:TextBox>
                                <asp:Button ID="Button5" runat="server" Text="Buscar" OnClick="Button5_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Height="109px" Width="384px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style4">
                </td>
                <td class="style25">
                    <asp:TextBox ID="TxtIndice" runat="server" Width="301px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Adicionar Indice" UseSubmitBehavior="False"
                        OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" Text="Quitar Indice" OnClick="Button4_Click" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <hr />
        <table style="width: 80%">
            <tr>
                <td>
                </td>
                <td class="style21">
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" CssClass="submitButton"
                        CausesValidation="true" ValidationGroup="RecepDoc" Text="Guardar" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Deshacer" OnClick="btnEliminar_Click" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2"
            TargetControlID="HiddenField2" BackgroundCssClass="backgroundColor">
        </asp:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" BackColor="White">
            <asp:UpdatePanel ID="upSuppliers" runat="server">
                <ContentTemplate>
                    <iframe src="creaemisor.aspx" style="border: medium double #808080; width: 600px;
                        height: 600px" align="middle"></iframe>
                    <div align="center">
                        <asp:Button ID="Button2" runat="server" Text="cerrar" OnClick="Button2_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <%--
            </ContentTemplate>
        </asp:UpdatePanel>--%>
    </asp:Panel>
    <div>
        <asp:Panel ID="PanelModal" runat="server" Style="display: ; background: white; width: 63%;
            height: 70%" BorderColor="Blue" BorderStyle="Double">
            <div align="center">
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txtbuscarenelpanel" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btbuscarenelpanel" runat="server" Text="buscar" OnClick="btbuscarenelpanel_Click"
                                Width="100px" />
                        </td>
                        <td class="style118">
                        </td>
                        <td>
                            <asp:Button ID="btcrear" runat="server" Text="Crear" Width="100px" OnClick="btcrear_Click"
                                Visible="False" />
                        </td>
                        <td class="style119">
                        </td>
                        <td>
                            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClick="btnCerrar_Click"
                                Width="100px" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <div>
                <asp:GridView ID="gvpanel" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    Style="margin-right: 570px" Width="950px" DataKeyNames="Nit,Descripcion,Id,email"
                    OnSelectedIndexChanged="gvpanel_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvpanel_PageIndexChanging"
                    Height="400px" PageSize="7" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Nit" HeaderText="Nit" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
                        <asp:BoundField DataField="Id" HeaderText="Id" />
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
            <div>
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" PopupControlID="PanelModal" TargetControlID="HiddenField3">
                </asp:ModalPopupExtender>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
