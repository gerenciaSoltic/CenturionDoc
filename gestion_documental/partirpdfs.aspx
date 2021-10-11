<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partirpdfs.aspx.cs" Inherits="gestion_documental.partirpdfs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>UNIR DOCUMENTOS PDFS</title>
<script src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script src="jquery.MultiFile.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
<div align ="center">
<table>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="PARTIR DOCUMENTOS PDFS" 
        Font-Size="Larger"></asp:Label>
   
</td>
</tr>
</table>
 <asp:Label ID="Label2" runat="server" Text="Seleccione el documento a partir"></asp:Label>
<asp:FileUpload ID="file_upload" class="multi" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload"
onclick="btnUpload_Click" /><br />


    <asp:TextBox ID="txtverdoc" runat="server" AutoPostBack="True"></asp:TextBox>
    <asp:Button ID="Button4"
        runat="server" Text="Ver" onclick="Button4_Click" />
        <br />
<br />
<table>

<tr>
<td>
    <asp:Label ID="Label6" runat="server" Text="Desde la Pagina"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtpagdesde" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Solo Numero" ControlToValidate="txtpagdesde" 
        ValidationExpression="\d+"></asp:RegularExpressionValidator>
</td>

</tr>
<tr>
<td>
    <asp:Label ID="Label7" runat="server" Text="Hasta la página"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtpaghasta" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ErrorMessage="Solo Número" ControlToValidate="txtpaghasta" 
        ValidationExpression="\d+"></asp:RegularExpressionValidator>
</td>

</tr>

</table>
<br />
    <asp:Button ID="Button2" runat="server" Text="Agregar" 
        onclick="Button2_Click" />
    <asp:Button ID="Button3"
        runat="server" Text="Quitar" onclick="Button3_Click" />

        <br />
        <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="pagdesde" HeaderText="Desde pag." />
            <asp:BoundField DataField="paghasta" HeaderText="Hasta Pag." />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
   <br />
   <br />
    
    
    
    <asp:Button ID="Button1" runat="server" Text="Dividir" 
        onclick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Errores en el proceso.." Visible="False"></asp:Label>
        <br />
        <br />
    <asp:Button ID="Button5" runat="server" Text="" onclick="Button5_Click" 
        Visible="False" />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
</div>
</form>
</body>
</html>