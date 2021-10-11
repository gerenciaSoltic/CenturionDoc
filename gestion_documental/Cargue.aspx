<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cargue.aspx.cs" Inherits="gestion_documental.Cargue" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            width: 993px;
        }
        .style3
        {
            height: 30px;
        }
        .style4
        {
            width: 916px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" 
        Text="CARGUE DE DOCUMENTOS POR EXPEDIENTES" Font-Bold="True"></asp:Label>
    </div>
    <hr />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Oficina Productora"></asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="DDLOficina" runat="server" Height="21px" Width="241px" 
        AutoPostBack="True" onselectedindexchanged="DDLOficina_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Código Expediente"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="TxtCodigo" runat="server" ontextchanged="TxtCodigo_TextChanged"></asp:TextBox>
                <asp:TextBox ID="TxtExpediente" runat="server" Enabled="False" Width="630px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/buscar.jpg" 
        onclick="ImageButton1_Click" />
            </td>
        </tr>
    </table>
    <hr />
    <div align="center">
        <asp:Label ID="Label4" runat="server" Text="HOJA DE RUTA"></asp:Label>
    </div>
    <table style="border-style: groove; line-height: normal;">
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Contenedor"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtContenedor" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Compartimiento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCompartimiento" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Unidad de almmacenamiento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUnidad" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Numero de Unidad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtnumerounidad" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Label ID="Label8" runat="server" 
        Text="ARCHIVOS"></asp:Label>
    </div>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvprincipal" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="971px" 
        onselectedindexchanged="gvprincipal_SelectedIndexChanged" 
        DataKeyNames="idserie,idsubserie,iddocumentos,camino,documento" 
        onrowupdated="gvprincipal_RowUpdated" 
        onrowdatabound="gvprincipal_RowDataBound" 
        onrowdeleting="gvprincipal_DeleteEventHandler">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Serie" DataField="nomserie" />
                        <asp:BoundField HeaderText="Subserie" DataField="nomsubserie" />
                        <asp:BoundField DataField="nomtipologia" HeaderText="Tipologia" />
                        <asp:BoundField DataField="documento" HeaderText="Documento" />
                        <asp:TemplateField HeaderText="VER">
                            <ItemTemplate>
                                <asp:Button ID="btgvprincipal" runat="server" Text="Ver"  onclick="btgvprincipal_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="INDICES">
                            <ItemTemplate>
                                <asp:Button ID="btgvprincipalindices" runat="server" Text="Indices" onclick="btgvprincipalindices_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Indices" ShowSelectButton="True" />
                        <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
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
            </td>
        </tr>
    </table>
    <hr/>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Serie"></asp:Label>
                <asp:DropDownList ID="DDLSerie" runat="server" Width="284px" 
        AutoPostBack="True" onselectedindexchanged="DDLSerie_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Subserie"></asp:Label>
                <asp:DropDownList ID="DDLSubserie" runat="server"  Width="317px" 
        AutoPostBack="True" onselectedindexchanged="DDLSubserie_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Tipologia"></asp:Label>
                <asp:DropDownList ID="DDlTipoLogia" runat="server"  Width="223px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <hr/>
    <table>
        <tr>
            <td class="style1">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                    <ContentTemplate>
                        <asp:FileUpload ID="ImageButton2" runat="server" Height="30px" Width="300px" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Button1" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Button ID="Button1" runat="server" Text="Guardar" 
        onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    <hr />
    <table align = "center">
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" 
        Text="Descargar todo el expediente en un solo archivo" 
        onclick="Button2_Click" />
            </td>
        </tr>
    </table>
    <hr />
    <asp:Panel ID="Panel1" runat= "server" style=" display:none;  background:white; width:40%; height:80%" BorderColor="Blue" BorderStyle="Double">
        <br />
        <div>
            <table align="center">
                <tr>
                    <td>
                        <asp:Button ID="btcerrapanel" runat="server" Text="Cerrar" Width="109px" 
        onclick="btcerrapanel_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvindice" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="atributo" HeaderText="Atributo" />
                                <asp:TemplateField HeaderText="Indice">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtindicepanelgv" runat="server"  Width="163px" Text='<%# Eval("indice")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btguardarpanelgv" runat="server" Text="Guardar" 
        onclick="btguardarpanelgv_Click" />
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:ListBox ID="listpanel" runat="server" Height="134px" Width="193px">
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:TextBox ID="txtlistapanel" runat="server"></asp:TextBox>
                                    <asp:Button ID="btagregarindicepanel" runat="server" Text="Agregar" 
        onclick="btagregarindicepanel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:ModalPopupExtender ID="HiddenField2_ModalPopupExtender" runat="server" 
                      DynamicServicePath="" Enabled="True" PopupControlID="Panel1" 
                      TargetControlID="HiddenField2">
        </asp:ModalPopupExtender>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" style=" display:;  background:white; width:60%; height:90%" BorderColor="Blue" BorderStyle="Double">
        <div align="center">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="Txtbuscarenelpanel" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btbuscarenelpanel" runat="server" Text="buscar" Width="100px" 
                 onclick="btbuscarenelpanel_Click" />
                    </td>
                    <td class="style118">
                    </td>
                    <td>
            &nbsp;</td>
                    <td class="style119">
                    </td>
                    <td>
                        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar"  Width="100px" 
                          onclick="btnCerrar_Click"  />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div>
            <asp:GridView ID="gvpanel" runat="server" CellPadding="4" ForeColor="#333333" 
                      GridLines="None" style="margin-right: 100%"  Width="100%" DataKeyNames="id"
                      AllowPaging="True" 
                    
                      Height="278px" PageSize="7" 
                      onselectedindexchanged="gvpanel_SelectedIndexChanged" 
                      AutoGenerateColumns="False" 
                      onpageindexchanging="gvpanel_PageIndexChanging" 
                      onselectedindexchanging="gvpanel_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="Codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                          Height="10%" />
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
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" 
                      DynamicServicePath="" Enabled="True" PopupControlID="Panel2" 
                      TargetControlID="HiddenField1">
            </asp:ModalPopupExtender>
        </div>
    </asp:Panel>
</asp:Content>

