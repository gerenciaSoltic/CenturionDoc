<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaWorkFlowFuncionario.aspx.cs" Inherits="gestion_documental.ConsultaWorkFlowFuncionario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="Msj" TagName="Mensajes" Src="~/Mensajes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:Label ID="Label2" runat="server" Text="De"></asp:Label>
                <asp:TextBox ID="Txt_Fecha_Inicio" runat="server" Height="19px" Width="77px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="Txt_Fecha_Inicio" runat="server"
                    Format="yyyy-MM-dd" />
                &nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Hasta"></asp:Label>
                <asp:TextBox ID="Txt_Fecha_Fin" runat="server" Height="20px" Width="81px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="Txt_Fecha_Fin" runat="server"
                    Format="yyyy-MM-dd" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Funcionario"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="DdlFuncionario" runat="server" Height="20px" 
                    Width="304px">
                </asp:DropDownList>
            </td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="DdlEstado" runat="server" Height="20px" Width="304px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImgBtnConsulta" runat="server" ImageUrl="~/Images/lens_16x16.png"
                    Style="width: 16px; height: 16px;" onclick="ImgBtnConsulta_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label>
            </td>
            <td class="style3">
                <strong><asp:Label ID="LblMovimientos" runat="server"></asp:Label></strong>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Total Estado"></asp:Label>
            </td>
            <td class="style3">
                <strong><asp:Label ID="LblEstado" runat="server"></asp:Label></strong>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <%--<tr>
            <td class="style1">
                <asp:Label ID="LblRadicado" runat="server" Text="Radicado"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TxtRadicado" runat="server" Width="301px"></asp:TextBox>
                <asp:ImageButton ID="ImgBtnRadicado" runat="server" ImageUrl="~/Images/lens_16x16.png"
                    OnClick="ImgBtnRadicado_Click" Style="height: 16px" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="ImgBtnBorrarRadicado" runat="server" ImageUrl="~/Images/trash_16x16.png"
                    OnClick="ImgBtnBorrarRadicado_Click" ToolTip="Borrar Radicado" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="LblIndice" runat="server" Text="Indice"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TxtIndice" runat="server" Width="301px"></asp:TextBox>
                <asp:ImageButton ID="ImgBtnIndice" runat="server" ImageUrl="~/Images/lens_16x16.png"
                    OnClick="ImgBtnIndice_Click" Style="width: 16px" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="ImgBtnBorrarIndice" runat="server" ImageUrl="~/Images/trash_16x16.png"
                    OnClick="ImgBtnBorrarIndice_Click" ToolTip="Borrar Indice" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>--%>

    </table>
    <hr />
    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GrvWorkFlow" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="888px" OnSelectedIndexChanged="GrvWorkFlow_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Radicado" HeaderText="Rad Resp" />
                        <asp:BoundField DataField="De" HeaderText="De" />
                        <asp:BoundField DataField="Para" HeaderText="Para" />
                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                        <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Visualiza" ShowHeader="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Images/document_16x16.png"
                                    NavigateUrl='<%# Eval("camino") %>' Target="_blank">HyperLink</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/document_16x16.png"
                            NavigateUrl="camino" Target="_blank">HyperLink</asp:HyperLink>
                    </EmptyDataTemplate>
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
    <%--llamada de control de usuario--%>
    <asp:UpdatePanel ID="upPnlPage" runat="server">
        <ContentTemplate>
            <Msj:Mensajes ID="omb" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

