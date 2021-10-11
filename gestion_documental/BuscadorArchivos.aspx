<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscadorArchivos.aspx.cs" Inherits="gestion_documental.BuscadorArchivos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 220px;
        }
        .style3
        {
            width: 56px;
        }
        .style4
        {
            width: 323px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <asp:Label ID="TituloLabel" runat="server" Text="Buscador de Documentos" CssClass="labelTitle"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Usuario" runat="server">
    <asp:Label runat="server" ID="usuarioLabel" Style="width: 100%"> </asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Mensajes" runat="server">
    <asp:Label ID="Msj" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">

            
                <asp:Panel ID="BuscadorPanel" runat="server" Width="98%" Height="100%" CssClass="-panel"
                    GroupingText="Buscador de Documentos">
                    <table style="width: 51%; padding: 25px;" align="center" >
                        <tr>
                            <td class="style3">
                               &nbsp;Indice :
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtIndice" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="34px" 
                                    ImageUrl="~/Images/search.jpeg" onclick="ImageButton1_Click" 
                                    Width="57px" />
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table align="center">
                        <tr>
                            <td>
                              <asp:CheckBox ID="CheckBox1" runat="server" Text="Coincidir Clasificación" />
                                <table>
                                    <tr>
                                        <td>

                                    &nbsp; Serie :</td>
                                        <td>
                                            <asp:DropDownList ID="ddlserie" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlserie_SelectedIndexChanged" style="margin-left: 0px" 
                                        Width="200px">
                                            </asp:DropDownList>
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                    &nbsp; SubSerie :</td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubserie" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlSubserie_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                    &nbsp; Tipologia :</td>
                                        <td>
                                            <asp:DropDownList ID="DdlTipologia" runat="server" AutoPostBack="True" 
                                               Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" class="style4">
                                <asp:GridView ID="gvindices" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="atributo">
                                    <Columns>
                                        <asp:BoundField DataField="ATRIBUTO" HeaderText="ATRIBUTO" />
                                        <asp:TemplateField HeaderText="INDICE">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtindicegv" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    
                    <div align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" 
                                    ImageUrl="~/Images/search.jpeg" 
                                    Width="57px" onclick="ImageButton2_Click" />
                    </div>
                    <hr />
                    <table>
                        <tr>
                            <td colspan="4">
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:GridView ID="DocumentosGridView" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDDOCUMENTOS" 
                                        ForeColor="#333333" GridLines="None" 
                                        onselectedindexchanged="DocumentosGridView_SelectedIndexChanged" 
                                        Width="1096px" AllowPaging="True" AllowSorting="True" PageSize="100" 
                                        onpageindexchanging="DocumentosGridView_PageIndexChanging">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField SelectText="Seleccionar" ShowCancelButton="False" 
                                                ShowSelectButton="True" />
                                            <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" />
                                            <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                                            <asp:BoundField DataField="FOLIOS" HeaderText="FOLIOS" />
                                            <asp:BoundField DataField="ANEXOS" HeaderText="ANEXOS" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#BFD13F" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#BFD13F" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    &nbsp;
                                </td>
                            <td>
                                    &nbsp;
                                </td>
                            <td>
                                    &nbsp;
                                </td>
                            <td>
                                    &nbsp;
                                </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="LblExpediente" runat="server" Text="Expediente :" 
                                Visible="False"></asp:Label>
                                <asp:TextBox ID="TxtExpediente" runat="server" Visible="False" Width="589px" 
                                Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbexpedienet" runat="server" Text="Caja # :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcodigoex" runat="server" Width="154px" 
                                 style="margin-bottom: 0px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbexpedienet1" runat="server" Text="Unidad"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtunidadext" runat="server" Width="154px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbexpediente2" runat="server" Text="Estante"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcontenedorext" runat="server" Width="154px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbexpediente3" runat="server" Text="Bandeja"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtcompartimientoext" runat="server" Width="154px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:GridView ID="DocExpediente" runat="server" 
                                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="1109px" 
                                    onselectedindexchanged="DocExpediente_SelectedIndexChanged" 
                                    DataKeyNames="IDDOCUMENTOS">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField SelectText="Seleccionar" ShowCancelButton="False" 
                                            ShowSelectButton="True" />
                                        <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" />
                                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN" />
                                        <asp:BoundField DataField="FOLIOS" HeaderText="FOLIOS" />
                                        <asp:BoundField DataField="ANEXOS" HeaderText="ANEXOS" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#BFD13F" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#BFD13F" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            
            
</asp:Content>
