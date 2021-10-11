<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="gestion_documental.Estadisticas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
   
<div align = "center">
    
    <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Images/Escudo Alcaldia Municipal.png" Height="142px" 
        Width="160px" />
        <br/>
       
     <asp:Label ID="Label1" runat="server" Text="ESTADISTICA DE TRAMITES"></asp:Label>
</div>
<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
    <div align ="center">

    <table>
    <tr>
    <td>
    FECHAS
    </td>

    </tr>
  
    </table>
    <table>
    <tr>
    <td>
    Desde
    </td>
    <td>
          <asp:TextBox ID="txtFechadesde" runat="server"></asp:TextBox>
           <asp:CalendarExtender ID = "CalendarExtender1" TargetControlID = "txtFechadesde" runat = "server" Format="yyyy-MM-dd" />
    </td>
    <td>
    Hasta
    </td>
    <td>
          <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
          <asp:CalendarExtender ID = "CalendarExtender2" TargetControlID = "txtFechaHasta" runat = "server" Format="yyyy-MM-dd" />
    </td>
    </tr>
    </table>
    <hr />

    <table>
    <tr>
    <td>
      Oficina
    </td>
    <td>
    <asp:DropDownList ID="ddlOficinas" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlOficinas_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    <td>
    Funcionario
    </td>
        
    <td>
    <asp:DropDownList ID="ddlFuncionario" runat="server">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
    Tipo Agrupacion
    </td>
         <td>
        <asp:RadioButton ID="rdTotales" runat="server" GroupName="tipoinforme" 
                 Text="Total" />
        <asp:RadioButton ID="rdPorOficina" runat="server" GroupName="tipoinforme" 
                 Text="Por oficina" />
   
        <asp:RadioButton ID="rdPorFuncionario" runat="server" GroupName="tipoinforme" 
                 Text="Por Funcionario" />
        

    </td>
    </tr>
    
    </table>
       
    <hr />
     <asp:Button ID="btnConsultar" runat="server" Text="Consultar" 
            onclick="btnConsultar_Click" />
     
     <hr />
       

    </div>
    <div align= "center">
    
    <asp:GridView ID="grdEstadistica" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" Width="690px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
            <asp:BoundField DataField="Funcionario" HeaderText="Funcionario" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
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
    <br />
    <br />
  



    </form>
</body>
</html>
