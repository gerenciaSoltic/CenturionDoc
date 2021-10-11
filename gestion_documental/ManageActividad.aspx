<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageActividad.aspx.cs" Inherits="gestion_documental.ManageActividad" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
            <h1>Actividad</h1>
            <br />
            <div >
                <div style="width: 100%; float: right;padding-bottom: 15px">
                    <table style="margin: 0 auto;">
                        <tr>

                            <td>Nombre Proceso:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProceso" runat="server" CssClass="dropdown"
                                    Height="24px" Width="392px" AutoPostBack="True" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>

                            <td>Nombre Actividad:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNombreActividad" Width="392px" />
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="rfvActividad" runat="server" SetFocusOnError="true" ControlToValidate="txtNombreActividad" CssClass="errorMessage" ErrorMessage="Please enter Proceso !" ValidationGroup="Actividad"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <asp:Button runat="server" ID="btnAddActividad" Text="Añadir" CssClass="submitButton" CausesValidation="true" ValidationGroup="actividad" OnClick="btnAddActividad_Click" />
                                <asp:Button ID="btnModelClear" runat="server" CssClass="cancelButton" Text="Limpiar" OnClick="btnModelClear_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="Log" style="width: 100%; float: left;padding-bottom: 15px">
                    <asp:GridView runat="server" ID="gvActividad" AutoGenerateColumns="False"
                        Width="100%" DataKeyNames="id"
                        CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowDataBound="gvActividad_RowDataBound" OnRowDeleting="gvActividad_RowDeleting" OnSelectedIndexChanged="gvActividad_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:BoundField DataField="ID" HeaderText="Id" />
                            <asp:BoundField DataField="ACTIVIDAD" HeaderText="Actividad" />
                            <asp:BoundField DataField="NOMBREPROCESO" HeaderText="Proceso" />
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
