<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificadosEducacion.aspx.cs" Inherits="gestion_documental.CertificadosEducacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>
    </title>
    <style type="text/css">
        .zoom{
       
    }
    .zoom:hover{
       
    }
        .style1
        {
            height: 24px;
        }
        .style3
        {
            height: 493px;
        }
        .style4
        {
            height: 20px;
        }
        .style5
        {
            height: 90px;
        }
        .style6
        {
            height: 281px;
        }
        .style7
        {
            width: 393px;
        }
        .style8
        {
            width: 73px;
        }
    </style>
</head>
<body style="height: 1532px; margin-right: 0px">
    <form id="form1" runat="server">
     <asp:ToolkitScriptManager  runat="server" ID="MenuUserControlScriptManager" EnablePageMethods="true" AsyncPostBackTimeout = "36000">
</asp:ToolkitScriptManager >
    <div>
     <div align="center">
    <asp:Label ID="Label1" runat="server" Text="CERTIFICADOS" Font-Size="Large" 
        ForeColor="Black"></asp:Label>
   </div>

    </div>
    <table>
<tr>
<td>

</td>
<td>

</td>
<td>

</td>
</tr>
</table>

<table align="center">
<tr>
<td>
    <asp:Label ID="Label2" runat="server" Text="Municipio"></asp:Label>
</td>
<td class="style1">
    <asp:TextBox ID="txtmunicipio" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label3" runat="server" Text="Año"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtyear" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label4" runat="server" Text="Colegio"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtcolegio" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label5" runat="server" Text="Grado"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtgrado" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<br />
<div align ="center">
    <asp:Button ID="bt_buscar" runat="server" Text="Buscar" 
        onclick="bt_buscar_Click" /> 

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

    <asp:Button ID="Button1" runat="server" Text="Salir" onclick="Button1_Click" 
        Width="59px" />
    <br />
</div>
<br />
<div>

 <asp:updateprogress ID="updateprogress4" runat="server">
                                     <ProgressTemplate>
                                       <center>
                                        Procesando.. , Espere un momento por favor<br />
                                       <br />
                                     <img id="Img1" src="~/images/loader.gif" runat="server"/>
                                     <br />
                                     <br />
                                     <br />
                                   </center>
                                  </ProgressTemplate>
                               </asp:updateprogress></div>
<div align="center">
    <asp:GridView ID="gvprincipal" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Height="141px" 
        Width="766px" DataKeyNames="iddocumentos,colegio,municipio,year,grado,libro" 
        onselectedindexchanged="gvprincipal_SelectedIndexChanged" 
        OnPageIndexChanging="gvprincipal_PageIndexChanging"
        AllowPaging="True" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="documento" HeaderText="NOMBRE" />
            <asp:BoundField DataField="municipio" HeaderText="MUNICIPIO" />
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
<table align="center">
<tr>
<td>
    <asp:Label ID="Label6" runat="server" Text="Nombre :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtnombre" runat="server" Width="384px"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label7" runat="server" Text="Año :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtyearimprimir" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label8" runat="server" Text="Municipio :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtmunicipioimprimi" runat="server" Width="384px"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label9" runat="server" Text="Jornada :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtjornada" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label10" runat="server" Text="Colegio :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtcolegioimprimir" runat="server" Width="384px"></asp:TextBox>
</td>
<td>
    <asp:Label ID="Label11" runat="server" Text="Grado :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtgradoimprimir" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>

    <asp:Label ID="Label12" runat="server" Text="Libro :"></asp:Label>

</td>
<td>

    <asp:TextBox ID="txtlibro" runat="server" Width="381px"></asp:TextBox>

</td>
<td>
    <asp:Label ID="Label13" runat="server" Text="# Folio :"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtnumerofolios" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<table>
<tr>
<td>
    <asp:Label ID="Label17" runat="server" Text="Texto Estampillas"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtTextoEstampillas" runat="server" Height="53px" 
        TextMode="MultiLine" Width="739px"></asp:TextBox>
</td>
</tr>
</table>

<br />
<br />
<table>
<tr>
<td class="style3">
<table align="center" style="border: medium double #000000">
<tr>
<td class="style7">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/escudosantander.jpg" 
        Width="285px" />
</td>
<td>
<table>
<tr>
<td class="style4">
</td>
</tr>
<tr>
<td class="style6">
 <asp:Image class="zoom" ID="Image1" runat="server" Height="351px" 
        ImageUrl="" Width="421px"  />
</td>
</tr>
<tr>
<td class="style5">
    <asp:Button ID="Button2" runat="server" Text="Ver imagen independiente" 
        onclick="Button2_Click" />
</td>
</tr>
</table>
</td>
<td>
<table  align="center" >
<tr>
<td align="center">
    <asp:Label ID="Label14" runat="server" Text="Asignatura"></asp:Label>
</td>
<td align="center">
    <asp:Label ID="Label15" runat="server" Text="Calificacion"></asp:Label>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura1" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion1" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura2" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion2" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura3" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion3" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura4" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion4" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura5" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion5" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura6" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion6" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura7" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion7" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura8" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion8" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura9" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion9" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura10" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion10" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura11" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion11" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura12" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion12" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura13" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion13" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura14" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion14" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:TextBox ID="txtasignatura15" runat="server" Width="501px"></asp:TextBox>
</td>
<td>
    <asp:TextBox ID="txtcalificacion15" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
</table>
<br />
<table align="center">
<tr>
<td>
    <asp:Label ID="Label16" runat="server" Text="Fecha de Expedicion"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtfechaexpedicion" runat="server" Width="269px"></asp:TextBox>
</td>
</tr>
</table>
<br />
<div align="center">
    <asp:Button ID="btgenerarcertificado" runat="server" Text="Crear Certificado" 
        onclick="btgenerarcertificado_Click" />
</div>
</td>
<td>

</td>
</tr>
</table>

</td>
<td class="style3">

   

</td>
</tr>
</table>

    </form>
</body>
</html>
