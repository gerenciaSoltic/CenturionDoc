
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True"
    CodeBehind="ManageExpediente.aspx.cs" Inherits="gestion_documental.ManageExpediente" %>

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
            <h1>
                    Expediente</h1>
            <br />
            <div style="overflow: hidden;">
                <div style="width: 100%; float: right;">
                    <table style="margin: 0 auto;">
                        <tr>
                            <td>
                                            Oficina Productora<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" SetFocusOnError="true" ControlToValidate="ddlEnte" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Expediente" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td class="style2">
                                <asp:DropDownList ID="DdlEnte" runat="server" CssClass="dropdown" 
                                                AutoPostBack="True" Width="372px" onselectedindexchanged="cambiaOficina">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Serie<asp:RequiredFieldValidator ID="rvfddlSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Expediente" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td class="style2">
                                <asp:DropDownList ID="ddlSerie" runat="server" CssClass="dropdown" 
                                                OnSelectedIndexChanged="ddlSerie_SelectedIndexChanged" AutoPostBack="True" 
                                                Width="372px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                            SubSerie<asp:RequiredFieldValidator ID="rfvddlSubSerie" runat ="server" SetFocusOnError="true" ControlToValidate="ddlSubSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Expediente" InitialValue="0"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td class="style4">
                                <asp:DropDownList ID="ddlSubSerie" runat="server" CssClass="dropdown" 
                                                OnSelectedIndexChanged="ddlSubSerie_SelectedIndexChanged" AutoPostBack="True" 
                                                Width="375px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Fase Archivo"></asp:Label>
                                        &nbsp;:</td>
                            <td class="style2">
                                <asp:DropDownList ID="DDLfasearchivo" runat="server" Height="18px" 
                                             Width="371px">
                                    <asp:ListItem>ARCHIVO GESTION</asp:ListItem>
                                    <asp:ListItem>ARCHIVO CENTRAL</asp:ListItem>
                                    <asp:ListItem>ARCHIVO HISTORICO</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Codigo"></asp:Label>
                                        &nbsp;:</td>
                            <td class="style2">
                                <asp:TextBox ID="txtcodigoexpediente" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    
                                        Numero de identificacion:</td>
                            <td>
                                <asp:TextBox ID="txtnumerodeidentificacion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Descripcion<asp:RequiredFieldValidator ID="rfvtxtDescripcion" runat ="server" SetFocusOnError="true" ControlToValidate ="txtDescripcion"  CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Expediente"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td class="style2">
                                <asp:TextBox runat="server" ID="txtDescripcion" Width="376px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Fecha Inicio<asp:RequiredFieldValidator ID="rvftxtFechainicio" runat ="server" SetFocusOnError="true" ControlToValidate ="txtFechainicio" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="Expediente"></asp:RequiredFieldValidator>
                                :
                                        </td>
                            <td class="style2">
                                <asp:TextBox runat="server" ID="txtFechainicio" Height="19px" Width="128px" />
                                <asp:CalendarExtender ID="CalendarExtender1" Format="d-MM-yyyy" TargetControlID="txtFechainicio" runat="server">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Fecha Final :</td>
                            <td class="style2">
                                <asp:TextBox runat="server" ID="txtFechafinal" />
                                <asp:CalendarExtender ID="CalendarExtender2" Format="d-MM-yyyy" TargetControlID="txtFechafinal" runat="server">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="font-weight: bold">
                                <hr />
                                Hoja de Ruta 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Contenedor:
                                        </td>
                            <td class="style2">
                                <asp:DropDownList ID="ddlContenedor" runat="server" CssClass="dropdown" 
                                                 AutoPostBack="True" 
                                                Width="372px" onselectedindexchanged="cambiaContenedor">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                            Compartimiento:
                                        </td>
                            <td class="style2">
                                <asp:DropDownList ID="ddlCompartimiento" runat="server" CssClass="dropdown" 
                                                 AutoPostBack="True" 
                                                Width="372px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Unidad"></asp:Label>
                                        &nbsp;:</td>
                            <td>
                                <asp:DropDownList ID="DDLunidad" runat="server" Width="371px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbnumerounidad" runat="server" Text="Numero Unidad"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnumerounidad" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    
                                        Unidad 2 :</td>
                            <td>
                                <asp:DropDownList ID="DDLunidad2" runat="server" Height="16px" Width="373px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    
                                        Numero Unidad 2</td>
                            <td>
                                <asp:TextBox ID="txtnumerounidad2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtbuscar" runat="server" Width="172px" AutoPostBack="True" 
                                            ontextchanged="txtbuscar_TextChanged" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button runat="server" ID="btnAddExpediente" Text="Añadir" 
                                                CssClass="submitButton" CausesValidation="true" ValidationGroup="Expediente"
                                                OnClick="btnAddExpediente_Click" Height="26px" />
                                <asp:Button ID="btnExpedienteClear" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearExpediente_Click" />
                                <asp:Button ID="Btnbuscar" runat="server" Text="Buscar" 
                                                onclick="Btnbuscar_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnRegistrar" runat="server" Text="Activar" 
                                                onclick="Btnbuscar_Click" />
                            </td>
                        </tr>
                    </table>
                    <table align="center">
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label6" runat="server" Text="Registrar a Inventario "></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:CheckBox ID="ckinventariohis" runat="server" Text="Historia Laboral" 
                                        AutoPostBack="True" oncheckedchanged="ckinventariohis_CheckedChanged" />
                            </td>
                        </tr>
                    </table>
                </div>
                <hr />
                <br />
                <br />
                <div align="center">
                    <asp:Label ID="Label1" runat="server" Text="INDICES DE BUSQUEDA DEL EXPEDIENTE" 
                                    Visible="False"></asp:Label>
                    <asp:GridView runat="server" ID="gvIndicesExpedientes" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="id" Visible="False" 
                                    onrowediting="gvIndicesExpedientes_RowEditing" 
                                    onrowcancelingedit="gvIndicesExpedientes_RowCancelingEdit" 
                                    onrowupdating="gvIndicesExpedientes_RowUpdating" 
                                    onrowdeleting="gvIndicesExpedientes_RowDeleting" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="HeaderId" runat="server" Text='ID' />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblID" runat="server" Text='<%# Bind("id")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("id")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="HeaderAtributo" runat="server" Text='ATRIBUTO' />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAtributo" runat="server" Text='<%# Bind("atributo")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblAtributo" runat="server" Text='<%# Bind("atributo")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="HeaderIndice" runat="server" Text='INDICE' />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblIndice" runat="server" Text='<%# Bind("indice")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIndice" runat="server" Text='<%# Bind("indice")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Opciones" CausesValidation="true" 
                                            ShowDeleteButton="True" DeleteText="Eliminar" EditText="Editar" 
                                            InsertText="Adicionar" NewText="Nuevo" SelectText="Seleccionar" 
                                            ShowEditButton="True" UpdateText="Actualizar">
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
                <hr />
                <br />
                <br />
                <div class="Log" style="width: 100%; float: left;">
                    <asp:Label ID="Label2" runat="server" Text="LISTADO  EXPEDIENTE"></asp:Label>
                    <asp:GridView runat="server" ID="gvExpediente" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="id" 
                                    OnSelectedIndexChanged="gvExpediente_SelectedIndexChanged" 
                                    OnRowDeleting="gvExpediente_DeleteEventHandler" 
                                    OnRowDataBound="gvShowExpediente_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" />
                            <asp:BoundField DataField="IDSERIE" HeaderText="Serie" />
                            <asp:BoundField DataField="IDSUBSERIE" HeaderText="Subserie" />
                            <asp:BoundField DataField="IDTIPOLOGIA" HeaderText="Tipologia" />
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                            <asp:BoundField DataField="FECHAINICIO" HeaderText="FechaInicio" />
                            <asp:BoundField DataField="FECHAFINAL" HeaderText="FechaFinal" />
                            <asp:CommandField HeaderText="Opciones" CausesValidation="true" ShowDeleteButton="True" ShowSelectButton="true" SelectText="Seeleccionar" DeleteText="Eliminar">
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .dropdown
        {}
        .style2
        {
            width: 306px;
        }
        .style3
        {
            height: 26px;
        }
        .style4
        {
            width: 306px;
            height: 26px;
        }
        .style6
        {
            width: 176px;
        }
        .style7
        {
            width: 162px;
        }
    .submitButton
    {}
    </style>
</asp:Content>
