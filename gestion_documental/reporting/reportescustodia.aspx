<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportescustodia.aspx.cs" Inherits="gestion_documental.reporting.reportescustodia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
    <div >
    <br />
        <asp:Label ID="Label2" runat="server" Text="Reportes del Inventorio de Custodia" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <br />
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Tercero"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtnittercero" runat="server" AutoPostBack="True" 
            ontextchanged="txtnittercero_TextChanged"></asp:TextBox>
    </td>
    <td>
        <asp:TextBox ID="txtnombretercero" runat="server" Width="355px" Enabled="False"></asp:TextBox>
    </td>
    <td>
     <asp:ImageButton ID="ImageButton1" runat="server"  
            ImageUrl="~/Images/buscar.jpg"  Height="20px"  Width="35px" 
            onclick="ImageButton1_Click1" />
    </td>
    </tr>
    </table>
    <br />
    <table>
    <tr>
    <td>
        <asp:CheckBox ID="ckempresa" runat="server" Text="Empresa" AutoPostBack="True" 
            oncheckedchanged="ckempresa_CheckedChanged" />
    </td>
    <td>
    
    </td>
    <td>
        <asp:CheckBox ID="ckcliente" runat="server" Text="Cliente" AutoPostBack="True" 
            oncheckedchanged="ckcliente_CheckedChanged" />
    </td>
    </tr>
    </table>
    <br />
    <table>
    <tr>
    <td>
        <asp:Button ID="gtngenerar" runat="server" Text="Generar" Width="74px" 
            onclick="gtngenerar_Click" />
    </td>
    <td>
        <asp:Button ID="btnsalir" runat="server" Text="Salir"  Width="74px" 
            onclick="btnsalir_Click" />
    </td>
    </tr>
    </table>
    </div>
    <br />
    <hr />
    <br />
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="90%" 
            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
         <LocalReport ReportPath="reporting\inventariocustodia.rdlc">
             <DataSources>
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
             </DataSources>
         </LocalReport>
    </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="obternerinventariocustodia" 
            TypeName="gestion_documental.DataAccessLayer.inventarioconsul">
        </asp:ObjectDataSource>
    </div>
    <div>
    <asp:Panel ID="PanelModal" runat="server" 
            style=" display:;  background:white; width:60%; height:80%" BorderColor="Blue" 
            BorderStyle="Double">
           
            <div align="center">
            <br />
        <table>
        <tr>
        <td>
            <asp:TextBox ID="Txtbuscarenelpanel" runat="server"></asp:TextBox>
        </td>
         <td>
             <asp:Button ID="btbuscarenelpanel" runat="server" Text="buscar" 
                 onclick="btbuscarenelpanel_Click" Width="100px" />
        </td>
        <td class="style118">
        </td>
        <td>
            <asp:Button ID="btcrear" runat="server" Text="Crear" 
                Width="100px" Visible="False" />
        </td>
        <td class="style119">
        </td>
        <td> 
                      <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" 
                          onclick="btnCerrar_Click" Width="100px"  />
              </td>
        </tr>
        </table>
        <br />
            </div>
              <div >
                  <asp:GridView ID="gvpaneltercero" runat="server" CellPadding="4" ForeColor="#333333" 
                      GridLines="None" style="margin-right: 570px"  Width="950px" DataKeyNames="codigo,referencia"
                      onselectedindexchanged="gvpaneltercero_SelectedIndexChanged" AllowPaging="True" 
                      OnPageIndexChanging="gvpaneltercero_PageIndexChanging"
                      Height="16px" PageSize="7">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:CommandField ShowSelectButton="True" />
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
                  <asp:HiddenField ID="HiddenField1" runat="server" />
                  <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" 
                      DynamicServicePath="" Enabled="True" PopupControlID="PanelModal" 
                      TargetControlID="HiddenField1"></asp:ModalPopupExtender>
              </div>
              </asp:Panel>
    </div>
    </form>
</body>
</html>
