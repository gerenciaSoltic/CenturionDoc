<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageSubSerie.aspx.cs" Inherits="gestion_documental.ManageSubSerie" %>

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
                    SubSeries</h1>
                <br />
                

                <div style="overflow: hidden;">
                            
                            <div style="width: 100%; float: right;">
                                <table style="margin: 0 auto;">
                                    
                                    <tr>
                                        <td>
                                            Serie<asp:RequiredFieldValidator ID="rfvddlSerie" runat ="server" SetFocusOnError="true" ControlToValidate ="ddlSerie" CssClass="errorMessage" ErrorMessage="*" ValidationGroup="SubSerie" InitialValue="0"></asp:RequiredFieldValidator>:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSerie" runat="server" CssClass="dropdown" 
                                                Height="24px" Width="392px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Codigo:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TxtoCodigo" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            SubSerie:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSubSerie" Height="27px" Width="395px" />
                                        </td>
                                    </tr>
                                   <tr><td>&nbsp;</td>
                                        <td   align="left">
                                         <asp:RequiredFieldValidator ID="rfvddlSubSerie" runat ="server" SetFocusOnError="true" ControlToValidate ="txtSubSerie" CssClass="errorMessage" ErrorMessage="Please enter SubSerie !" ValidationGroup="SubSerie"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Diposicion Final
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDispofin" runat="server" CssClass="dropdown" 
                                                Height="24px" Width="392px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tiempo Gestion :
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TxtoTiempoGestion" Width="70px" />
                                            <asp:RegularExpressionValidator ID="RgexpvlTgestion" runat="server" 
                                                ControlToValidate="TxtoTiempoGestion" Display="Dynamic" 
                                                ErrorMessage="* Ingrese Solo numeros" ForeColor="Red" 
                                                ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tiempo Central :
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TxtoTiempoCentral" Width="70px" />
                                            <asp:RegularExpressionValidator ID="RgexpvlTcentral" runat="server" 
                                                ControlToValidate="TxtoTiempoCentral" Display="Dynamic" 
                                                ErrorMessage="* Ingrese solo numeros" ForeColor="Red" 
                                                ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Tiempo Historico:
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="TxtoTiempoHistorico" Width="70px" />
                                            <asp:RegularExpressionValidator ID="RgexpvlTHistorico" runat="server" 
                                                ControlToValidate="TxtoTiempoHistorico" Display="Dynamic" 
                                                ErrorMessage="* Ingrese solo numeros" ForeColor="Red" 
                                                ValidationExpression="^[0-9]*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btnAddSubSerie" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="SubSerie"
                                                OnClick="btnAddSubSerie_Click" />
                                            <asp:Button ID="btnClearSubSerie" runat="server" CssClass="cancelButton" Text="Limpiar"
                                                OnClick="btnClearSubSerie_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <hr />
                             <div style="width: 100%; float: right;">
                                <table style="margin: 0 auto;">
                                <tr align="center">
                                <td>
                                <asp:Label ID="LblAtributos" runat="server" Text="ATRIBUTOS PARA INDICE" 
                                    Visible="False"></asp:Label>
                                </td>
                                </tr>
                                <tr align="center">
                                <td>
                                <asp:ListBox ID="LstAtributos" runat="server" Visible="False">
                                </asp:ListBox>
                                </td>
                                </tr>
                                <tr align="center">
                                <td>
                            <asp:TextBox ID="Txtatributo" runat="server" Visible="False"></asp:TextBox>
                            
                            <asp:Button ID="BtnAñadirAtributo" runat="server" Text="Añadir" 
                                    onclick="BtnAñadirAtributo_Click" Visible="False" />
                                <asp:Button ID="BtnQuitarAtributo"
                                runat="server" Text="Quitar" Visible="False" onclick="BtnQuitarAtributo_Click" />
                           </td>
                           </tr>
                                </table>
                            </div>
                            <hr />
                            <div class="Log" style="width: 100%; float: left;">
                                <asp:GridView runat="server" ID="gvSubSerie" AutoGenerateColumns="False"
                                    Width="100%" DataKeyNames="id" 
                                    OnSelectedIndexChanged="gvSubSerie_SelectedIndexChanged" 
                                    OnRowDeleting="gvSubSerie_DeleteEventHandler" 
                                    OnRowDataBound="gvShowSubSerie_RowDataBound" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRESERIE" HeaderText="Serie" />
                                        <asp:BoundField DataField="CODIGO" HeaderText="Código" />
                                        <asp:BoundField DataField="SUBSERIE" HeaderText="SubSerie" />
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
